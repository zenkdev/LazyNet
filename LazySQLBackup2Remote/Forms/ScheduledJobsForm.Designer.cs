namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    partial class ScheduledJobsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduledJobsForm));
            this.pcButtons = new DevExpress.XtraEditors.PanelControl();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            this.sbDelete = new DevExpress.XtraEditors.SimpleButton();
            this.gcJobs = new DevExpress.XtraGrid.GridControl();
            this.gvJobs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcEnabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLastRunTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gcLastTaskResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNextRunTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNumberOfMissedRuns = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pcButtons)).BeginInit();
            this.pcButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDateEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDateEdit.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // pcButtons
            // 
            this.pcButtons.Controls.Add(this.sbClose);
            this.pcButtons.Controls.Add(this.sbDelete);
            this.pcButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pcButtons.Location = new System.Drawing.Point(10, 323);
            this.pcButtons.Name = "pcButtons";
            this.pcButtons.Size = new System.Drawing.Size(702, 44);
            this.pcButtons.TabIndex = 0;
            // 
            // sbClose
            // 
            this.sbClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sbClose.Appearance.Options.UseFont = true;
            this.sbClose.AutoSize = true;
            this.sbClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbClose.Image = global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.close_32x32;
            this.sbClose.Location = new System.Drawing.Point(613, 2);
            this.sbClose.Name = "sbClose";
            this.sbClose.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.sbClose.Size = new System.Drawing.Size(87, 40);
            this.sbClose.TabIndex = 1;
            this.sbClose.Text = "Close";
            this.sbClose.Click += new System.EventHandler(this.SbCloseClick);
            // 
            // sbDelete
            // 
            this.sbDelete.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sbDelete.Appearance.Options.UseFont = true;
            this.sbDelete.AutoSize = true;
            this.sbDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.sbDelete.Image = global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.delete_32x32;
            this.sbDelete.Location = new System.Drawing.Point(2, 2);
            this.sbDelete.Name = "sbDelete";
            this.sbDelete.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.sbDelete.Size = new System.Drawing.Size(187, 40);
            this.sbDelete.TabIndex = 0;
            this.sbDelete.Text = "Delete Scheduled Job";
            this.sbDelete.Click += new System.EventHandler(this.SbDeleteClick);
            // 
            // gcJobs
            // 
            this.gcJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcJobs.Location = new System.Drawing.Point(10, 10);
            this.gcJobs.MainView = this.gvJobs;
            this.gcJobs.Name = "gcJobs";
            this.gcJobs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riDateEdit});
            this.gcJobs.ShowOnlyPredefinedDetails = true;
            this.gcJobs.Size = new System.Drawing.Size(702, 313);
            this.gcJobs.TabIndex = 0;
            this.gcJobs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvJobs});
            // 
            // gvJobs
            // 
            this.gvJobs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcEnabled,
            this.gcName,
            this.gcLastRunTime,
            this.gcLastTaskResult,
            this.gcNextRunTime,
            this.gcNumberOfMissedRuns});
            this.gvJobs.GridControl = this.gcJobs;
            this.gvJobs.Name = "gvJobs";
            this.gvJobs.OptionsBehavior.Editable = false;
            this.gvJobs.OptionsCustomization.AllowFilter = false;
            this.gvJobs.OptionsCustomization.AllowGroup = false;
            this.gvJobs.OptionsMenu.EnableColumnMenu = false;
            this.gvJobs.OptionsMenu.EnableFooterMenu = false;
            this.gvJobs.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvJobs.OptionsView.ColumnAutoWidth = false;
            this.gvJobs.OptionsView.ShowGroupPanel = false;
            this.gvJobs.OptionsView.ShowIndicator = false;
            // 
            // gcEnabled
            // 
            this.gcEnabled.Caption = "Enabled";
            this.gcEnabled.FieldName = "Enabled";
            this.gcEnabled.Name = "gcEnabled";
            this.gcEnabled.OptionsColumn.FixedWidth = true;
            this.gcEnabled.Visible = true;
            this.gcEnabled.VisibleIndex = 0;
            this.gcEnabled.Width = 60;
            // 
            // gcName
            // 
            this.gcName.Caption = "Job";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 1;
            this.gcName.Width = 300;
            // 
            // gcLastRunTime
            // 
            this.gcLastRunTime.Caption = "Last run time";
            this.gcLastRunTime.ColumnEdit = this.riDateEdit;
            this.gcLastRunTime.FieldName = "LastRunTime";
            this.gcLastRunTime.Name = "gcLastRunTime";
            this.gcLastRunTime.OptionsColumn.FixedWidth = true;
            this.gcLastRunTime.Visible = true;
            this.gcLastRunTime.VisibleIndex = 2;
            this.gcLastRunTime.Width = 130;
            // 
            // riDateEdit
            // 
            this.riDateEdit.AutoHeight = false;
            this.riDateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riDateEdit.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riDateEdit.DisplayFormat.FormatString = "G";
            this.riDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.riDateEdit.EditFormat.FormatString = "G";
            this.riDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.riDateEdit.Mask.EditMask = "G";
            this.riDateEdit.Name = "riDateEdit";
            this.riDateEdit.NullDate = new System.DateTime(((long)(0)));
            this.riDateEdit.NullText = "Never";
            // 
            // gcLastTaskResult
            // 
            this.gcLastTaskResult.Caption = "Last task result";
            this.gcLastTaskResult.FieldName = "LastTaskResult";
            this.gcLastTaskResult.Name = "gcLastTaskResult";
            this.gcLastTaskResult.OptionsColumn.FixedWidth = true;
            this.gcLastTaskResult.Visible = true;
            this.gcLastTaskResult.VisibleIndex = 3;
            this.gcLastTaskResult.Width = 90;
            // 
            // gcNextRunTime
            // 
            this.gcNextRunTime.Caption = "Next run time";
            this.gcNextRunTime.ColumnEdit = this.riDateEdit;
            this.gcNextRunTime.FieldName = "NextRunTime";
            this.gcNextRunTime.Name = "gcNextRunTime";
            this.gcNextRunTime.OptionsColumn.FixedWidth = true;
            this.gcNextRunTime.Visible = true;
            this.gcNextRunTime.VisibleIndex = 4;
            this.gcNextRunTime.Width = 130;
            // 
            // gcNumberOfMissedRuns
            // 
            this.gcNumberOfMissedRuns.Caption = "Number of missed runs";
            this.gcNumberOfMissedRuns.FieldName = "NumberOfMissedRuns";
            this.gcNumberOfMissedRuns.Name = "gcNumberOfMissedRuns";
            this.gcNumberOfMissedRuns.Visible = true;
            this.gcNumberOfMissedRuns.VisibleIndex = 5;
            this.gcNumberOfMissedRuns.Width = 127;
            // 
            // ScheduledJobsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 377);
            this.Controls.Add(this.gcJobs);
            this.Controls.Add(this.pcButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScheduledJobsForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scheduled Jobs";
            ((System.ComponentModel.ISupportInitialize)(this.pcButtons)).EndInit();
            this.pcButtons.ResumeLayout(false);
            this.pcButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDateEdit.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDateEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcButtons;
        private DevExpress.XtraEditors.SimpleButton sbDelete;
        private DevExpress.XtraEditors.SimpleButton sbClose;
        private DevExpress.XtraGrid.GridControl gcJobs;
        private DevExpress.XtraGrid.Views.Grid.GridView gvJobs;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcLastRunTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcLastTaskResult;
        private DevExpress.XtraGrid.Columns.GridColumn gcNextRunTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumberOfMissedRuns;
        private DevExpress.XtraGrid.Columns.GridColumn gcEnabled;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit riDateEdit;
    }
}