using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace Dekart.LazyNet.Win
{
    public partial class FindDevices : RibbonForm, IFormWithLayoutManager
    {
        int _threadCount;
        readonly List<BackgroundWorker> _workers = new List<BackgroundWorker>();
        readonly List<FindDeviceItem> _found = new List<FindDeviceItem>();
        readonly Form _parent;

        BindingList<FindDeviceItem> _dataSource;

        UnitOfWork _session;
        bool _closeFormPending;
        bool _scanInProgress;

        long _fromIpInt;
        long _toIpInt;
        List<Manufacturer> _manufacturers;
        List<Device> _devices;

        public FindDevices(Form parent)
        {
            InitializeComponent();

            _parent = parent;
            Icon = ImagesHelper.AppIcon;
            beiProgressBar.EditValue = 0;
            EditorsHelpers.InitDeviceTypeComboBox(riDeviceType);
        }

        public FormLayoutManager LayoutManager
        {
            get
            {
                var frm = _parent as IFormWithLayoutManager;
                if (frm != null)
                    return frm.LayoutManager;
                return null;
            }
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitData();

            if (LayoutManager != null)
                LayoutManager.RestoreFormLayout(new FormLayoutInfo(null, this, lcMain, gridView, null, Ribbon.Toolbar, null));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.WParam.ToInt32() == (int)Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_workers.Any() || bwAddDevice.IsBusy || bwImport.IsBusy)
            {
                e.Cancel = true;
                _closeFormPending = true;
                foreach (var worker in _workers.Where(worker => worker.IsBusy))
                {
                    worker.CancelAsync();
                }
                if (bwAddDevice.IsBusy)
                {
                    bwAddDevice.CancelAsync();
                }
                if (bwImport.IsBusy)
                {
                    bwImport.CancelAsync();
                }
            }
            else
            {
                CloseForm();
            }
        }

        void InitData()
        {
            _session = new UnitOfWork();
            _dataSource = new BindingList<FindDeviceItem>();

            IPAddress startIP, endIP;
            var ipAddress = NetHelper.GetIPAddressFromHostName(Environment.MachineName);
            NetHelper.GetAddressRange(ipAddress, ipAddress.GetSubnetMask(), out startIP, out endIP);

            ipAddressFrom.IPAddress = startIP.ToString();
            ipAddressTo.IPAddress = endIP.ToString();
            gridControl.DataSource = _dataSource;

            _manufacturers = DataHelper.GetManufacturers(_session);
        }

        void EnableButtons(bool enable, bool? enableFindButton = null)
        {
            bbiFind.Enabled = enableFindButton ?? enable;
            bbiAddDevice.Enabled = enable;
            bbiImportManufacturers.Enabled = enable;
            bbiClose.Enabled = enable;

            ipAddressFrom.Enabled = enable;
            ipAddressTo.Enabled = enable;
            seThreads.Enabled = enable;
        }
        
        void CloseForm()
        {
            if (LayoutManager != null)
                LayoutManager.SaveFormLayout(new FormLayoutInfo(null, this, lcMain, gridView, null, Ribbon.Toolbar, null));

            if (_session != null)
            {
                _session.Dispose();
                _session = null;
            }
            Cursor.Current = Cursors.Default;
            Dispose();
        }

        string GetManufacturerFromMAC(string mac)
        {
            var str = System.Text.RegularExpressions.Regex.Replace(mac ?? "", "[^0-9|a-f|A-F]", "");
            if (!string.IsNullOrWhiteSpace(str))
            {
                var manufacturer = _manufacturers.FirstOrDefault(m => str.StartsWith(m.MAC));
                if (manufacturer != null)
                {
                    return manufacturer.Name;
                }
            }

            return ConstStrings.ManufacturerUnknown;
        }

        #region New Devices

        void bbiAddDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView.CloseEditor();
            gridView.UpdateCurrentRow();

            EnableButtons(false);
            bsiInfo.Caption = ConstStrings.WarmingUpText;

            _found.Clear();
            foreach (var i in gridView.GetSelectedRows())
            {
                _found.Add(gridView.GetRow(i) as FindDeviceItem);
            }
            bwAddDevice.RunWorkerAsync();
        }

        void bwAddDevice_DoWork(object sender, DoWorkEventArgs e)
        {
            var wrk = (BackgroundWorker)sender;

            for (var i = 0; i < _found.Count; i++)
            {
                if (wrk.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                wrk.ReportProgress(i, _found.Count);
                var deviceDataItem = _found[i];
                var device = _session.FindObject<Device>(CriteriaOperator.Parse("MAC=?", deviceDataItem.MAC));
                if (device == null)
                {
                    device = new Device(_session)
                    {
                        DeviceType = deviceDataItem.DeviceType,
                        Name = deviceDataItem.Name,
                        HostName = deviceDataItem.HostName,
                        IP = deviceDataItem.IP,
                        MAC = deviceDataItem.MAC
                    };
                    if (device.DeviceType == DeviceTypeEnum.Computer)
                    {
                        string managedBy, operatingSystemFull, room;
                        if (AdHelper.GetComputerPropertiesFromAD(device.HostName, out managedBy, out operatingSystemFull, out room))
                        {
                            if (room != null)
                                device.Room = _session.FindObject<Room>(CriteriaOperator.Parse("Name=? And DeletionMark=0", room));
                        }
                    }
                    if (device.Room == null)
                        device.Room = DataHelper.GetRootRoom(_session);
                }
                else
                {
                    device.IP = deviceDataItem.IP;
                }
                device.Save();
            }
            SessionHelper.CommitSession(_session, null);
        }

        void bwAddDevice_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            riProgressBar.Maximum = (int)e.UserState;
            beiProgressBar.EditValue = e.ProgressPercentage;
            bsiInfo.Caption = string.Format(ConstStrings.AddDeviceText, beiProgressBar.EditValue, riProgressBar.Maximum);
        }

        void bwAddDevice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableButtons(true);
            beiProgressBar.EditValue = 0;
            if (e.Error != null)
            {
                XtraMessageBox.Show(this, e.Error.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }


        #endregion

        #region Find Devices

        void bbiFind_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_scanInProgress)
            {
                bbiFind.Caption = ConstStrings.FindButtonCaptionStopPending;
                EnableButtons(false);
                foreach (var worker in _workers.Where(worker => worker.IsBusy))
                {
                    worker.CancelAsync();
                }
            }
            else
            {
                _fromIpInt = IPAddress.Parse(ipAddressFrom.IPAddress).AddressToInt();
                _toIpInt = IPAddress.Parse(ipAddressTo.IPAddress).AddressToInt();

                if (_fromIpInt > _toIpInt)
                {
                    XtraMessageBox.Show(this, "Начальный IP адрес должен быть меньше конечного", ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _scanInProgress = true;
                bsiInfo.Caption = ConstStrings.WarmingUpText;
                bbiFind.Caption = ConstStrings.FindButtonCaptionStop;
                bbiFind.Glyph = Properties.Resources.icon_network_cancel_16;
                bbiFind.LargeGlyph = Properties.Resources.icon_network_cancel_32;
                EnableButtons(false, true);
                beiProgressBar.EditValue = 0;

                _threadCount = Convert.ToInt32(seThreads.Value);
                if (_threadCount < 1)
                {
                    _threadCount = 1;
                    seThreads.Value = 1;
                }

                for (var i = 0; i < _threadCount; i++)
                {
                    var bwFind = new BackgroundWorker { WorkerSupportsCancellation = true };
                    bwFind.DoWork += bwFind_DoWork;
                    bwFind.RunWorkerCompleted += bwFind_RunWorkerCompleted;
                    _workers.Add(bwFind);
                }

                var ipCount = Math.Abs(_toIpInt - _fromIpInt) + 1;

                riProgressBar.Maximum = (int)ipCount;

                _devices = new XPCollection<Device>(_session, CriteriaOperator.Parse("DeletionMark=0 And IsNull(IP,'')<>''")).ToList();

                _dataSource.Clear();

                var step = (int)ipCount / _threadCount;
                for (var i = 0; i < _threadCount - 1; i++)
                {
                    var iFromIp = _fromIpInt;
                    var iToIp = iFromIp + step - 1;

                    _workers[i].RunWorkerAsync(new { FromIp = iFromIp, ToIp = iToIp });
                    _fromIpInt += step;
                }
                // остальные на последнем потоке
                _workers.Last().RunWorkerAsync(new { FromIp = _fromIpInt, ToIp = _toIpInt });
            }
        }

        void bwFind_DoWork(object sender, DoWorkEventArgs e)
        {
            var wrk = (BackgroundWorker) sender;
            
            var arg = (dynamic)e.Argument;
            if (arg == null) return;

            long ipInt = arg.FromIp;
            long toIpInt = arg.ToIp;

            while (ipInt <= toIpInt)
            {
                if (wrk.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                var ipAddress = NetHelper.IntToAddress(ipInt);
                var macAddressFromArp = NetHelper.GetMacAddressFromArp(ipAddress.ToString());
                if (!string.IsNullOrEmpty(macAddressFromArp))
                {
                    var hostname = NetHelper.GetHostByAddress(ipAddress.ToString());
                    var name = hostname ?? string.Format("IP_{0}", ipAddress);
                    var item = new FindDeviceItem { IP = ipAddress.ToString(), Name = name, HostName = hostname, MAC = macAddressFromArp };
                    item.Manufacturer = GetManufacturerFromMAC(item.MAC);

                    var device = _devices.FirstOrDefault(d => d.MAC == item.MAC);
                    if (device != null)
                    {
                        if (string.Equals(device.IP, item.IP, StringComparison.InvariantCultureIgnoreCase))
                        {
                            Invoke((MethodInvoker) (bwFind_ProgressChanged));
                            ipInt++;
                            continue;
                        }
                        item.Name = device.Name;
                        item.UpdateIP = true;
                    }
                    Invoke((MethodInvoker)(delegate{_dataSource.Add(item);}));
                }

                Invoke((MethodInvoker)(bwFind_ProgressChanged));
                ipInt++;
            }
        }

        void bwFind_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var wrk = sender as BackgroundWorker;

            _workers.Remove(wrk);
            if (_workers.Any()) return;

            if (e.Cancelled && _closeFormPending)
            {
                Close();
                return;
            }

            _scanInProgress = false;
            beiProgressBar.EditValue = 0;
            bbiFind.Caption = ConstStrings.FindButtonCaption;
            bbiFind.Glyph = Properties.Resources.icon_network_find_16;
            bbiFind.LargeGlyph = Properties.Resources.icon_network_find_32;
            EnableButtons(true);

            bsiInfo.Caption = string.Format(ConstStrings.DeviceCountText, gridView.RowCount);
        }

        void bwFind_ProgressChanged()
        {
            beiProgressBar.EditValue = (int)beiProgressBar.EditValue + 1;
            bsiInfo.Caption = string.Format(ConstStrings.DeviceFindText, beiProgressBar.EditValue, riProgressBar.Maximum);
        }

        #endregion

        #region Import Manufacturers

        void bbiImportManufacturers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EnableButtons(false);
            bsiInfo.Caption = ConstStrings.WarmingUpText;
            bwImport.RunWorkerAsync();
        }

        void bwImport_DoWork(object sender, DoWorkEventArgs e)
        {
            var wrk = (BackgroundWorker) sender;
            
            var session = new Session();
            var waitHandle = new ManualResetEvent(false);
            var downloader = new FileDownloader();
            downloader.DownloadStatusChanged+=downloader_DownloadStatusChanged;
            downloader.DownloadProgressChanged += downloader_DownloadProgressChanged;
            downloader.DownloadCompleted += (ss, ee) => waitHandle.Set();
            downloader.Download(Properties.Settings.Default.LazyNet_Win_standards_url, Path.GetTempPath());
            waitHandle.WaitOne(15000);

            if (wrk.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            if (File.Exists(downloader.DownloadingTo))
            {
                var text = File.ReadAllText(downloader.DownloadingTo);
                File.Delete(downloader.DownloadingTo);

                if (!string.IsNullOrEmpty(text))
                {
                    var n = 0;
                    var strings = text.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                    if (strings.Length > 1)
                    {
                        var createdOn = DateTime.Now;
                        foreach (var s in strings)
                        {
                            if (wrk.CancellationPending)
                            {
                                e.Cancel = true;
                                return;
                            }
                            wrk.ReportProgress(n++, strings.Length);
                            if (s.Contains("Generated:"))
                            {
                                createdOn = DateTime.Parse(s.Replace("Generated:", "").Trim());
                            }

                            if (s.Contains("(base 16)"))
                            {
                                var compArgs = s.Split(new[] {'\t', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                                var mac = compArgs[0].Replace("(base 16)", "").Trim().ToUpper();
                                var name = compArgs[1].Trim();
                                var manufacturer = session.FindObject<Manufacturer>(CriteriaOperator.Parse("MAC=?", mac));
                                if (manufacturer == null)
                                {
                                    manufacturer = new Manufacturer(session)
                                    {
                                        CreatedOn = createdOn,
                                        MAC = mac,
                                        Name = name
                                    };
                                    manufacturer.Save();
                                }
                            }
                        }
                        wrk.ReportProgress(n, strings.Length);
                    }
                }
            }
            _manufacturers = DataHelper.GetManufacturers(_session);
            foreach (var deviceDataItem in _dataSource)
            {
                if (string.IsNullOrEmpty(deviceDataItem.Manufacturer))
                {
                    deviceDataItem.Manufacturer = GetManufacturerFromMAC(deviceDataItem.MAC);
                }
            }
        }

        void bwImport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            riProgressBar.Maximum = (int) e.UserState;
            beiProgressBar.EditValue = e.ProgressPercentage;
            bsiInfo.Caption = string.Format(ConstStrings.ManufacturersImportedText, beiProgressBar.EditValue, riProgressBar.Maximum);
        }

        void downloader_DownloadStatusChanged(object sender, FileDownloadStatusChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => downloader_DownloadStatusChanged(sender, e)));
            }
            else
            {
                bsiInfo.Caption = e.Message;
            }
        }

        void downloader_DownloadProgressChanged(object sender, FileDownloadProgressChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(()=>downloader_DownloadProgressChanged(sender, e)));
            }
            else
            {
                riProgressBar.Maximum = (int)e.TotalBytesToReceive;
                beiProgressBar.EditValue = e.BytesReceived;
                bsiInfo.Caption = string.Format(ConstStrings.BytesDownloadedText, beiProgressBar.EditValue, riProgressBar.Maximum);
            }
        }

        void bwImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled && _closeFormPending)
            {
                Close();
                return;
            }

            EnableButtons(true);
            beiProgressBar.EditValue = 0;
            if (e.Error != null)
            {
                XtraMessageBox.Show(this, string.Format("Не удалось обработать данные из url {0}", Properties.Settings.Default.LazyNet_Win_standards_url), ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bsiInfo.Caption = string.Format("ОРГАНИЗАЦИЙ:{0:n0}", riProgressBar.Maximum);
            }
        }

        #endregion

        void gridView_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            if (e.Column != gcIPAddress) return;

            e.Handled = true;
            var ip1 = IPAddress.Parse((string)e.Value1).AddressToInt();
            var ip2 = IPAddress.Parse((string)e.Value2).AddressToInt();

            if (ip1 < ip2)
                e.Result = -1;
            else if (ip2 < ip1)
                e.Result = 1;
            else
                e.Result = 0;
        }

        void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            var view = (ColumnView)sender;
            if (e.KeyCode == Keys.C && e.Control)
                e.Handled = GridHelper.GridViewCopyCell(view);
        }

        void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column == gcIPAddress)
            {
                var item = gridView.GetRow(e.RowHandle) as FindDeviceItem;
                if (item != null && item.UpdateIP)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
            }
        }

        void bvbiExit_ItemClick(object sender, BackstageViewItemEventArgs e)
        {
            Close();
        }

        void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

    }

}