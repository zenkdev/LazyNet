using System;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using DevExpress.XtraEditors;

// Source code designed by Alireza shirazi
// www.ShiraziOnline.net
// year 2007
// This source code is absolutely FREE ! Do whatever you want to do with it ;)



namespace Dekart.LazyNet.Win
{
    public partial class SystemInfoForm : XtraForm
    {
        private readonly string _computer;

        public SystemInfoForm(string computer)
        {
            _computer = computer;
            InitializeComponent();
            cmbxOption.SelectedItem = "Win32_Processor";
        }

        private void InsertInfo(string key, ref ListView lst, bool dontInsertNull)
        {
            Cursor.Current = Cursors.WaitCursor;

            lst.Items.Clear();

            try
            {
                var options = new ConnectionOptions {Impersonation = ImpersonationLevel.Impersonate};
                var scope = new ManagementScope("\\\\" + _computer + "\\root\\cimv2", options);
                scope.Connect();

                var query = new ObjectQuery("select * from " + key);
                var searcher = new ManagementObjectSearcher(scope, query);

                foreach (var o in searcher.Get())
                {
                    var share = (ManagementObject) o;

                    ListViewGroup grp;
                    try
                    {
                        grp = lst.Groups.Add(share["Name"].ToString(), share["Name"].ToString());
                    }
                    catch
                    {
                        grp = lst.Groups.Add(share.ToString(), share.ToString());
                    }

                    if (share.Properties.Count <= 0)
                    {
                        MessageBox.Show(@"No Information Available", @"No Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    foreach (var pc in share.Properties)
                    {

                        var item = new ListViewItem(grp)
                        {
                            BackColor = lst.Items.Count%2 != 0 ? Color.White : Color.WhiteSmoke,
                            Text = pc.Name
                        };

                        if (pc.Value != null && pc.Value.ToString() != "")
                        {
                            switch (pc.Value.GetType().ToString())
                            {
                                case "System.String[]":
                                    var str = (string[]) pc.Value;
                                    var str2 = str.Aggregate("", (current, st) => current + (st + " "));
                                    item.SubItems.Add(str2.Trim());
                                    break;
                                case "System.UInt16[]":
                                    var shortData = (ushort[]) pc.Value;
                                    var tstr2 = shortData.Aggregate("", (current, st) => current + (st + " "));
                                    item.SubItems.Add(tstr2.Trim());
                                    break;
                                default:
                                    item.SubItems.Add(pc.Value.ToString().Trim());
                                    break;
                            }
                        }
                        else
                        {
                            if (!dontInsertNull)
                                item.SubItems.Add("No Information available");
                            else
                                continue;
                        }
                        lst.Items.Add(item);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show($"can't get data because of the followeing error \n{exp.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void RemoveNullValue(ref ListView lst)
        {
            foreach (ListViewItem item in lst.Items)
                if (item.SubItems[1].Text == @"No Information available")
                    item.Remove();
        }

        private void CopySelectedValuesToClipboard()
        {
            var items = lstDisplayHardware.SelectedItems;
            if (items.Count == 0) return;

            var text = items.Cast<ListViewItem>().Aggregate("", (current, item) => current + item.SubItems[1].Text + Environment.NewLine);
            Clipboard.SetText(text);
        }

        #region Control events ...

        private void cmbxNetwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(cmbxNetwork.SelectedItem.ToString(), ref lstNetwork, chkNetwork.Checked);
        }

        private void cmbxSystemInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(cmbxSystemInfo.SelectedItem.ToString(), ref lstSystemInfo, chkSystemInfo.Checked);
        }

        private void cmbxUtility_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(cmbxUtility.SelectedItem.ToString(), ref lstUtility, chkUtility.Checked);
        }

        private void cmbxUserAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(cmbxUserAccount.SelectedItem.ToString(), ref lstUserAccount, chkUserAccount.Checked);
        }

        private void cmbxStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(cmbxStorage.SelectedItem.ToString(), ref lstStorage, chkDataStorage.Checked);
        }

        private void cmbxDeveloper_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(cmbxDeveloper.SelectedItem.ToString(), ref lstDeveloper, chkDeveloper.Checked);
        }

        private void cmbxMemory_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(cmbxMemory.SelectedItem.ToString(), ref lstMemory, chkMemory.Checked);
        }

        private void chkHardware_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHardware.Checked)
                RemoveNullValue(ref lstDisplayHardware);
            else
                InsertInfo(cmbxOption.SelectedItem.ToString(), ref lstDisplayHardware, chkHardware.Checked);
        }

        private void cmbxOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(cmbxOption.SelectedItem.ToString(), ref lstDisplayHardware, chkHardware.Checked);
        }

        private void chkDataStorage_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDataStorage.Checked)
                RemoveNullValue(ref lstStorage);
            else
                InsertInfo(cmbxStorage.SelectedItem.ToString(), ref lstStorage, chkDataStorage.Checked);
        }

        private void chkMemory_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMemory.Checked)
                RemoveNullValue(ref lstMemory);
            else
                InsertInfo(cmbxMemory.SelectedItem.ToString(), ref lstStorage, false);
        }

        private void chkSystemInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSystemInfo.Checked)
                RemoveNullValue(ref lstSystemInfo);
            else
                InsertInfo(cmbxSystemInfo.SelectedItem.ToString(), ref lstSystemInfo, false);
        }

        private void chkNetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNetwork.Checked)
                RemoveNullValue(ref lstNetwork);
            else
                InsertInfo(cmbxNetwork.SelectedItem.ToString(), ref lstNetwork, false);
        }

        private void chkUserAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUserAccount.Checked)
                RemoveNullValue(ref lstUserAccount);
            else
                InsertInfo(cmbxUserAccount.SelectedItem.ToString(), ref lstUserAccount, false);
        }

        private void chkDeveloper_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeveloper.Checked)
                RemoveNullValue(ref lstDeveloper);
            else
                InsertInfo(cmbxDeveloper.SelectedItem.ToString(), ref lstDeveloper, false);
        }

        private void chkUtility_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUtility.Checked)
                RemoveNullValue(ref lstUtility);
            else
                InsertInfo(cmbxUtility.SelectedItem.ToString(), ref lstUtility, false);
        }

        private void linkLabel1_LinkClicked(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.ShiraziOnline.net");
        }

        private void lstDisplayHardware_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopySelectedValuesToClipboard();
            }
        }

        private void MainTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tabMemory && cmbxMemory.SelectedItem == null)
            {
                cmbxMemory.SelectedItem = "Win32_PhysicalMemory";
            }

        }

        #endregion

    }
}