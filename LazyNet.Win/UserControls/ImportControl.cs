using System;
using System.Collections.Generic;
using Dekart.LazyNet.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;

namespace Dekart.LazyNet.Win.UserControls
{
    public partial class ImportControl : RibbonApplicationUserControl
    {
        UnitOfWork _session;

        public ImportControl()
        {
            InitializeComponent();
            splitContainer1.Panel1MinSize = Root.MinSize.Width + 6;
            EditorsHelpers.InitDeviceTypeComboBox(riDeviceType);
            teDomain.Text = Environment.UserDomainName;
        }

        public void InitData()
        {
            _session = new UnitOfWork();

            SplashScreenManager.ShowForm(this, typeof(DemoWaitForm), true, true);
            try
            {
                var dataSource = new List<ADObjectItem>();
                var computers = AdHelper.GetListOfDomainComputers(teDomain.Text);
                foreach (var name in computers)
                {
                    string hostName, managedBy, operatingSystemFull, room;
                    if (AdHelper.GetComputerPropertiesFromAD("(&(objectCategory=computer)(name=" + name + "))", out hostName, out managedBy, out operatingSystemFull, out room))
                    {
                        if (_session.FindObject<Device>(CriteriaOperator.Parse("DeletionMark=0 And DeviceType=? And HostName=?", DeviceTypeEnum.Computer, hostName)) == null)
                        {
                            var item = new ADObjectItem
                            {
                                DeviceType = DeviceTypeEnum.Computer,
                                Name = name,
                                HostName = hostName,
                                ManagedBy = managedBy,
                                Room = room,
                                OperatingSystem = operatingSystemFull
                            };
                            dataSource.Add(item);
                        }
                    }
                }
                var printers = AdHelper.GetListOfDomainPrinters(teDomain.Text);
                foreach (var name in printers)
                {
                    string printerName, managedBy, printShareName, room;
                    if (AdHelper.GetPrinterPropertiesFromAD(name, out printerName, out managedBy, out printShareName, out room))
                    {
                        if (_session.FindObject<Device>(CriteriaOperator.Parse("DeletionMark=0 And DeviceType=? And HostName=?", DeviceTypeEnum.Printer, printShareName)) == null)
                        {
                            var item = new ADObjectItem
                            {
                                DeviceType = DeviceTypeEnum.Printer,
                                Name = printerName,
                                HostName = printShareName,
                                ManagedBy = managedBy,
                                Room = room
                            };
                            dataSource.Add(item);
                        }
                    }
                }
                gridControl1.DataSource = dataSource;
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }

        void RefreshButtonClick(object sender, EventArgs e)
        {
            InitData();
        }

        void ImportButtonClick(object sender, EventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows();

            try
            {
                foreach (var rowHandle in selectedRows)
                {
                    var row = gridView1.GetRow(rowHandle) as ADObjectItem;
                    if (row == null) continue;

                    if (row.DeviceType == DeviceTypeEnum.Computer)
                    {
                        var obj = _session.FindObject<Device>(CriteriaOperator.Parse("DeletionMark=0 And DeviceType=? And HostName=?", DeviceTypeEnum.Computer, row.HostName));
                        if (obj == null)
                        {
                            obj = new Device(_session) {DeviceType = DeviceTypeEnum.Computer};
                            if (row.Room != null)
                            {
                                obj.Room = _session.FindObject<Room>(CriteriaOperator.Parse("Name=? And DeletionMark=0", row.Room));
                            }
                            if (obj.Room == null)
                            {
                                obj.Room = DataHelper.GetRootRoom(_session);
                            }
                            obj.Name = row.Name;
                            obj.HostName = row.HostName;
                            //todo:obj.ManagedBy = row.ManagedBy;
                            //todo:obj.OperatingSystem = row.OperatingSystem;

                            obj.Save();
                        }
                    }
                    else if (row.DeviceType == DeviceTypeEnum.Printer)
                    {
                        var obj = _session.FindObject<Device>(CriteriaOperator.Parse("DeletionMark=0 And DeviceType=? And HostName=?", DeviceTypeEnum.Printer, row.HostName));
                        if (obj == null)
                        {
                            obj = new Device(_session) { DeviceType = DeviceTypeEnum.Printer };
                            if (row.Room != null)
                            {
                                obj.Room = _session.FindObject<Room>(CriteriaOperator.Parse("Name=? And DeletionMark=0", row.Room));
                            }
                            if (obj.Room == null)
                            {
                                obj.Room = DataHelper.GetRootRoom(_session);
                            }
                            obj.Name = row.Name;
                            obj.HostName = row.HostName;

                            obj.Save();
                        }
                    }
                }
                _session.CommitChanges();
            }
            finally
            {
                InitData();

                BackstageView.Ribbon.HideApplicationButtonContentControl();
            }
        }

        private void gridView1_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            if (e.Column == gcIcon)
            {
                e.Handled = true;
                e.Result = Convert.ToInt32(e.Value1) < Convert.ToInt32(e.Value2) ? -1 : Convert.ToInt32(e.Value1) > Convert.ToInt32(e.Value2) ? 1 : 0;
            }
        }
    }

    public class ADObjectItem
    {
        public DeviceTypeEnum DeviceType { get; set; }
        public string Name { get; set; }
        public string HostName { get; set; }
        public string ManagedBy { get; set; }
        public string Room { get; set; }
        public string OperatingSystem { get; set; }

    }
}
