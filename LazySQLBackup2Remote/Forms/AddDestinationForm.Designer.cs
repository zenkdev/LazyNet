namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    partial class AddDestinationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDestinationForm));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.sbFolderDestination = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sbFtpServer = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Network_Folder.png");
            this.imageCollection1.Images.SetKeyName(1, "Network_Drive.png");
            // 
            // sbFolderDestination
            // 
            this.sbFolderDestination.AllowFocus = false;
            this.sbFolderDestination.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.sbFolderDestination.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbFolderDestination.Appearance.Options.UseBackColor = true;
            this.sbFolderDestination.Appearance.Options.UseTextOptions = true;
            this.sbFolderDestination.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.sbFolderDestination.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.sbFolderDestination.Dock = System.Windows.Forms.DockStyle.Top;
            this.sbFolderDestination.ImageIndex = 0;
            this.sbFolderDestination.ImageList = this.imageCollection1;
            this.sbFolderDestination.Location = new System.Drawing.Point(10, 33);
            this.sbFolderDestination.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.sbFolderDestination.LookAndFeel.UseDefaultLookAndFeel = false;
            this.sbFolderDestination.Name = "sbFolderDestination";
            this.sbFolderDestination.Size = new System.Drawing.Size(264, 36);
            this.sbFolderDestination.TabIndex = 2;
            this.sbFolderDestination.Text = "<size=+1><color=blue><u>Local/Network Folder<u></color></size>\r\n<color=gray>Local" +
    "/Network folder/External HDD/NAS</color>";
            this.sbFolderDestination.Click += new System.EventHandler(this.SbFolderDestinationClick);
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(10, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(264, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Select where to store the backups";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(10, 23);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(264, 10);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(10, 69);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(264, 10);
            this.panelControl2.TabIndex = 3;
            // 
            // sbFtpServer
            // 
            this.sbFtpServer.AllowFocus = false;
            this.sbFtpServer.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.sbFtpServer.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbFtpServer.Appearance.Options.UseBackColor = true;
            this.sbFtpServer.Appearance.Options.UseTextOptions = true;
            this.sbFtpServer.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.sbFtpServer.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.sbFtpServer.Dock = System.Windows.Forms.DockStyle.Top;
            this.sbFtpServer.ImageIndex = 1;
            this.sbFtpServer.ImageList = this.imageCollection1;
            this.sbFtpServer.Location = new System.Drawing.Point(10, 79);
            this.sbFtpServer.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.sbFtpServer.LookAndFeel.UseDefaultLookAndFeel = false;
            this.sbFtpServer.Name = "sbFtpServer";
            this.sbFtpServer.Size = new System.Drawing.Size(264, 36);
            this.sbFtpServer.TabIndex = 4;
            this.sbFtpServer.Text = "<size=+1><color=blue><u>FTP Server<u></color></size>\r\n<color=gray>FTP/SFTP server" +
    "</color>";
            this.sbFtpServer.Click += new System.EventHandler(this.SbFtpServerClick);
            // 
            // AddDestinationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 139);
            this.Controls.Add(this.sbFtpServer);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.sbFolderDestination);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDestinationForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add destination";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbFolderDestination;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton sbFtpServer;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}