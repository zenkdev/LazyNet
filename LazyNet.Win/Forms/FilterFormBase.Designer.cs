namespace Dekart.LazyNet.Win
{
    partial class FilterFormBase
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
            this.okBtn = new DevExpress.XtraEditors.SimpleButton();
            this.moduleLayout = new DevExpress.XtraLayout.LayoutControl();
            this.saveFilter = new DevExpress.XtraEditors.CheckEdit();
            this.filterName = new DevExpress.XtraEditors.TextEdit();
            this.filterControl = new DevExpress.XtraEditors.FilterControl();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itemForControl = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForOkBtn = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForCancelBtn = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForSaveCheck = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem = new DevExpress.XtraLayout.EmptySpaceItem();
            this.separator = new DevExpress.XtraLayout.SimpleSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.moduleLayout)).BeginInit();
            this.moduleLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saveFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForOkBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForCancelBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForSaveCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separator)).BeginInit();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(452, 407);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(78, 22);
            this.okBtn.StyleController = this.moduleLayout;
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "OK";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // moduleLayout
            // 
            this.moduleLayout.AllowCustomization = false;
            this.moduleLayout.Controls.Add(this.saveFilter);
            this.moduleLayout.Controls.Add(this.filterName);
            this.moduleLayout.Controls.Add(this.filterControl);
            this.moduleLayout.Controls.Add(this.cancelBtn);
            this.moduleLayout.Controls.Add(this.okBtn);
            this.moduleLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduleLayout.Location = new System.Drawing.Point(0, 0);
            this.moduleLayout.Name = "moduleLayout";
            this.moduleLayout.Root = this.layoutControlGroup;
            this.moduleLayout.Size = new System.Drawing.Size(624, 441);
            this.moduleLayout.TabIndex = 0;
            // 
            // saveFilter
            // 
            this.saveFilter.AutoSizeInLayoutControl = true;
            this.saveFilter.Location = new System.Drawing.Point(12, 332);
            this.saveFilter.Name = "saveFilter";
            this.saveFilter.Properties.Caption = "Сохранить для последующего использования";
            this.saveFilter.Size = new System.Drawing.Size(258, 19);
            this.saveFilter.StyleController = this.moduleLayout;
            this.saveFilter.TabIndex = 5;
            // 
            // filterName
            // 
            this.filterName.EditValue = "";
            this.filterName.Location = new System.Drawing.Point(12, 355);
            this.filterName.Name = "filterName";
            this.filterName.Properties.NullValuePrompt = "Enter a name for your custom filter";
            this.filterName.Properties.NullValuePromptShowForEmptyValue = true;
            this.filterName.Size = new System.Drawing.Size(600, 20);
            this.filterName.StyleController = this.moduleLayout;
            this.filterName.TabIndex = 4;
            // 
            // filterControl
            // 
            this.filterControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.filterControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.filterControl.Location = new System.Drawing.Point(0, 0);
            this.filterControl.Name = "filterControl";
            this.filterControl.Size = new System.Drawing.Size(624, 314);
            this.filterControl.TabIndex = 2;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(534, 407);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(78, 22);
            this.cancelBtn.StyleController = this.moduleLayout;
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Отмена";
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.CustomizationFormText = "Root";
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itemForControl,
            this.itemForOkBtn,
            this.itemForCancelBtn,
            this.itemForName,
            this.itemForSaveCheck,
            this.emptySpaceItem,
            this.separator});
            this.layoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup.Name = "Root";
            this.layoutControlGroup.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup.Size = new System.Drawing.Size(624, 441);
            // 
            // itemForControl
            // 
            this.itemForControl.Control = this.filterControl;
            this.itemForControl.CustomizationFormText = "itemForControl";
            this.itemForControl.Location = new System.Drawing.Point(0, 0);
            this.itemForControl.Name = "itemForControl";
            this.itemForControl.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.itemForControl.Size = new System.Drawing.Size(624, 314);
            this.itemForControl.TextSize = new System.Drawing.Size(0, 0);
            this.itemForControl.TextVisible = false;
            // 
            // itemForOkBtn
            // 
            this.itemForOkBtn.Control = this.okBtn;
            this.itemForOkBtn.CustomizationFormText = "itemForOkBtn";
            this.itemForOkBtn.Location = new System.Drawing.Point(440, 395);
            this.itemForOkBtn.MaxSize = new System.Drawing.Size(92, 46);
            this.itemForOkBtn.MinSize = new System.Drawing.Size(92, 46);
            this.itemForOkBtn.Name = "itemForOkBtn";
            this.itemForOkBtn.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 2, 12, 12);
            this.itemForOkBtn.Size = new System.Drawing.Size(92, 46);
            this.itemForOkBtn.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itemForOkBtn.TextSize = new System.Drawing.Size(0, 0);
            this.itemForOkBtn.TextVisible = false;
            // 
            // itemForCancelBtn
            // 
            this.itemForCancelBtn.Control = this.cancelBtn;
            this.itemForCancelBtn.CustomizationFormText = "itemForCancelBtn";
            this.itemForCancelBtn.Location = new System.Drawing.Point(532, 395);
            this.itemForCancelBtn.MaxSize = new System.Drawing.Size(92, 46);
            this.itemForCancelBtn.MinSize = new System.Drawing.Size(92, 46);
            this.itemForCancelBtn.Name = "itemForCancelBtn";
            this.itemForCancelBtn.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 12, 12, 12);
            this.itemForCancelBtn.Size = new System.Drawing.Size(92, 46);
            this.itemForCancelBtn.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itemForCancelBtn.TextSize = new System.Drawing.Size(0, 0);
            this.itemForCancelBtn.TextVisible = false;
            // 
            // itemForName
            // 
            this.itemForName.Control = this.filterName;
            this.itemForName.CustomizationFormText = "itemForName";
            this.itemForName.Location = new System.Drawing.Point(0, 351);
            this.itemForName.Name = "itemForName";
            this.itemForName.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 12, 4, 20);
            this.itemForName.Size = new System.Drawing.Size(624, 44);
            this.itemForName.TextSize = new System.Drawing.Size(0, 0);
            this.itemForName.TextVisible = false;
            // 
            // itemForSaveCheck
            // 
            this.itemForSaveCheck.Control = this.saveFilter;
            this.itemForSaveCheck.CustomizationFormText = "itemForSaveCheck";
            this.itemForSaveCheck.Location = new System.Drawing.Point(0, 316);
            this.itemForSaveCheck.Name = "itemForSaveCheck";
            this.itemForSaveCheck.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 12, 16, 0);
            this.itemForSaveCheck.Size = new System.Drawing.Size(624, 35);
            this.itemForSaveCheck.TextSize = new System.Drawing.Size(0, 0);
            this.itemForSaveCheck.TextVisible = false;
            // 
            // emptySpaceItem
            // 
            this.emptySpaceItem.AllowHotTrack = false;
            this.emptySpaceItem.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem.Location = new System.Drawing.Point(0, 395);
            this.emptySpaceItem.Name = "emptySpaceItem1";
            this.emptySpaceItem.Size = new System.Drawing.Size(440, 46);
            this.emptySpaceItem.TextSize = new System.Drawing.Size(0, 0);
            // 
            // separator
            // 
            this.separator.AllowHotTrack = false;
            this.separator.CustomizationFormText = "simpleSeparator1";
            this.separator.Location = new System.Drawing.Point(0, 314);
            this.separator.Name = "simpleSeparator1";
            this.separator.Size = new System.Drawing.Size(624, 2);
            // 
            // FilterFormBase
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.moduleLayout);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Name = "FilterFormBase";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.moduleLayout)).EndInit();
            this.moduleLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saveFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForOkBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForCancelBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForSaveCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separator)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraEditors.SimpleButton okBtn;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraLayout.LayoutControl moduleLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem itemForControl;
        private DevExpress.XtraLayout.LayoutControlItem itemForOkBtn;
        private DevExpress.XtraLayout.LayoutControlItem itemForCancelBtn;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem;
        private DevExpress.XtraEditors.TextEdit filterName;
        private DevExpress.XtraLayout.LayoutControlItem itemForName;
        private DevExpress.XtraEditors.CheckEdit saveFilter;
        private DevExpress.XtraLayout.LayoutControlItem itemForSaveCheck;
        private DevExpress.XtraLayout.SimpleSeparator separator;
        protected DevExpress.XtraEditors.FilterControl filterControl;
    }
}