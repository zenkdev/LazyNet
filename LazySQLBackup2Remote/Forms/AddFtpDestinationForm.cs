using System;
using System.IO;
using System.Windows.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using WinSCP;

namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    public partial class AddFtpDestinationForm : AddFormBase
    {
        public AddFtpDestinationForm(Form parent, DestinationData editObject, IDXMenuManager manager)
            : base(parent, editObject, manager)
        {
            InitializeComponent();
        }

        /// <summary>Destination</summary>
        public DestinationData Destination => EditObject as DestinationData;

        protected override void CreateNewObject()
        {
            EditObject = new DestinationData { Type = 1, DeleteAfterMonths = 6, Protocol = 0, Port = 21, RemoteFolder = "/"};
        }

        protected override void InitData()
        {
            teHost.Text = Destination.Path;
            teUserName.Text = Destination.UserName;
            tePassword.Text = Destination.Password;
            seDeleteAfterMonths.Value = Destination.DeleteAfterDays;
            seDeleteAfterMonths.Value = Destination.DeleteAfterDays;
            cbProtocol.SelectedIndex = Destination.Protocol;
            sePort.Value = Destination.Port;
            teRemoteFolder.Text = Destination.RemoteFolder;
            lcgAdvanced.Expanded = false;
        }

        protected override bool ValidateData(bool hideOnSuccessMessage)
        {
            if (!base.ValidateData(hideOnSuccessMessage)) return false;

            if (!teRemoteFolder.Text.EndsWith("/"))
            {
                teRemoteFolder.Text += @"/";
            }

            try
            {
                var path = WinHelper.GetTempDirectory() + "\\test.txt";
                File.WriteAllText(path, "");

                // Setup session options
                var sessionOptions = new SessionOptions
                {
                    Protocol = cbProtocol.SelectedIndex == 0 ? Protocol.Ftp : Protocol.Sftp,
                    HostName = teHost.Text,
                    PortNumber = Convert.ToInt32(sePort.Value),
                    UserName = teUserName.Text,
                    Password = tePassword.Text,
                    GiveUpSecurityAndAcceptAnySshHostKey = true,
                    //SshHostKeyFingerprint = "ssh-rsa 1024 da:7d:21:d0:28:b6:ad:d8:76:35:58:d0:05:9b:b8:ce"
                };

                using (var session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    // Upload files
                    var transferOptions = new TransferOptions { TransferMode = TransferMode.Binary };

                    var transferResult = session.PutFiles(path, teRemoteFolder.Text, false, transferOptions);

                    // Throw on any error
                    transferResult.Check();

                    var removeResult = session.RemoveFiles(teRemoteFolder.Text + "test.txt");

                    removeResult.Check();

                }
                File.Delete(path);

                if (!hideOnSuccessMessage)
                {
                    XtraMessageBox.Show(this, "FTP Server destination has been successfully tested", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        protected override void SaveData()
        {
            if (!teRemoteFolder.Text.EndsWith("/"))
            {
                teRemoteFolder.Text += @"/";
            }

            Destination.Path = teHost.Text;
            Destination.UserName = teUserName.Text;
            Destination.Password = tePassword.Text;
            Destination.DeleteAfterMonths = Convert.ToInt32(seDeleteAfterMonths.Value);
            Destination.DeleteAfterDays = Convert.ToInt32(seDeleteAfterDays.Value);
            Destination.Protocol = cbProtocol.SelectedIndex;
            Destination.Port = Convert.ToInt32(sePort.Value);
            Destination.RemoteFolder = teRemoteFolder.Text;
        }

        void LcMainGroupExpandChanged(object sender, DevExpress.XtraLayout.Utils.LayoutGroupEventArgs e)
        {
            Height = ((LayoutControl)sender).Root.MinSize.Height + 110;
        }

        void CbProtocolSelectedIndexChanged(object sender, EventArgs e)
        {
            sePort.Value = cbProtocol.SelectedIndex + 21;
        }
    }
}
