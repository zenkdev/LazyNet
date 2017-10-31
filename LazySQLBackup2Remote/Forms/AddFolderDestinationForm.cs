using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    public partial class AddFolderDestinationForm : AddFormBase
    {
        public AddFolderDestinationForm(Form parent, DestinationData editObject, IDXMenuManager manager)
            : base(parent, editObject, manager)
        {
            InitializeComponent();
        }

        /// <summary>Destination</summary>
        public DestinationData Destination => EditObject as DestinationData;

        protected override void CreateNewObject()
        {
            EditObject = new DestinationData { Type = 0, DeleteAfterMonths = 6 };
        }

        protected override void InitData()
        {
            tePath.Text = Destination.Path;
            teUserName.Text = Destination.UserName;
            tePassword.Text = Destination.Password;
            seDeleteAfterMonths.Value = Destination.DeleteAfterMonths;
            seDeleteAfterDays.Value = Destination.DeleteAfterDays;
            lcgLogon.Expanded = false;
        }

        protected override bool ValidateData(bool hideOnSuccessMessage)
        {
            if (!base.ValidateData(hideOnSuccessMessage)) return false;

            //elevate privileges before doing file copy to handle domain security
            WindowsImpersonationContext impersonationContext = null;
            IntPtr userHandle = IntPtr.Zero;
            try
            {
                var userName = teUserName.Text.Trim();
                if (userName != "")
                {
                    string domain, user;
                    var split = userName.Split('\\');
                    if (split.Length > 1)
                    {
                        domain = split[0];
                        user = split[1];
                    }
                    else
                    {
                        // if domain name was blank, assume local machine
                        domain = Environment.UserDomainName;
                        user = userName;
                    }

                    // Call LogonUser to get a token for the user
                    if (!WinHelper.LogonUser(user, domain, tePassword.Text, WinHelper.LOGON32_LOGON_INTERACTIVE, WinHelper.LOGON32_PROVIDER_DEFAULT, ref userHandle))
                    {
                        throw new Exception("Exception impersonating user, error code: " + Marshal.GetLastWin32Error());
                    }

                    // Begin impersonating the user
                    impersonationContext = WindowsIdentity.Impersonate(userHandle);
                }

                //run the program with elevated privileges (like file copying from a domain server)
                var path = Path.Combine(tePath.Text, "test.txt");
                File.WriteAllText(path, "");
                File.Delete(path);

                if (!hideOnSuccessMessage)
                {
                    XtraMessageBox.Show(this, "Folder destination has been successfully tested", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // Clean up
                impersonationContext?.Undo();

                if (userHandle != IntPtr.Zero)
                {
                    WinHelper.CloseHandle(userHandle);
                }
            }

            return true;
        }

        protected override void SaveData()
        {
            Destination.Path = tePath.Text;
            Destination.UserName = teUserName.Text;
            Destination.Password = tePassword.Text;
            Destination.DeleteAfterMonths = Convert.ToInt32(seDeleteAfterMonths.Value);
            Destination.DeleteAfterDays = Convert.ToInt32(seDeleteAfterDays.Value);
        }

        void LcMainGroupExpandChanged(object sender, DevExpress.XtraLayout.Utils.LayoutGroupEventArgs e)
        {
            Height = ((LayoutControl)sender).Root.MinSize.Height + 110;
        }
    }
}
