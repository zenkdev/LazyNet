namespace Dekart.LazyNet.Win
{
    partial class AddMovement
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
            this.lciSrcRoom = new DevExpress.XtraLayout.LayoutControlItem();
            this.leSrcRoom = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lciCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.deCreatedOn = new DevExpress.XtraEditors.DateEdit();
            this.meNote = new DevExpress.XtraEditors.MemoEdit();
            this.lciNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDstRoom = new DevExpress.XtraLayout.LayoutControlItem();
            this.leDstRoom = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.seAmount = new DevExpress.XtraEditors.SpinEdit();
            this.lciAmount = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSrcRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSrcRoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreatedOn.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreatedOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDstRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leDstRoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.seAmount);
            this.lcMain.Controls.Add(this.meNote);
            this.lcMain.Controls.Add(this.deCreatedOn);
            this.lcMain.Controls.Add(this.leSrcRoom);
            this.lcMain.Controls.Add(this.leDstRoom);
            this.lcMain.LayoutVersion = "v2";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(718, 59, 250, 350);
            this.lcMain.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcMain.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcMain.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lcMain.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcMain.Size = new System.Drawing.Size(560, 315);
            // 
            // lcgRoot
            // 
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciNote,
            this.lciDstRoom,
            this.lciSrcRoom,
            this.lciAmount,
            this.lciCreatedOn});
            this.lcgRoot.Size = new System.Drawing.Size(560, 315);
            // 
            // lciSrcRoom
            // 
            this.lciSrcRoom.Control = this.leSrcRoom;
            this.lciSrcRoom.Location = new System.Drawing.Point(0, 24);
            this.lciSrcRoom.Name = "lciSrcRoom";
            this.lciSrcRoom.Size = new System.Drawing.Size(560, 24);
            this.lciSrcRoom.Text = "Исходное помещение:";
            this.lciSrcRoom.TextSize = new System.Drawing.Size(118, 13);
            // 
            // leSrcRoom
            // 
            this.leSrcRoom.Location = new System.Drawing.Point(124, 26);
            this.leSrcRoom.Name = "leSrcRoom";
            this.leSrcRoom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leSrcRoom.Properties.DisplayMember = "Name";
            this.leSrcRoom.Properties.NullText = "";
            this.leSrcRoom.Properties.PopupSizeable = false;
            this.leSrcRoom.Properties.ValueMember = "Id";
            this.leSrcRoom.Properties.View = this.searchLookUpEdit1View;
            this.leSrcRoom.Size = new System.Drawing.Size(434, 20);
            this.leSrcRoom.StyleController = this.lcMain;
            this.leSrcRoom.TabIndex = 1;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsCustomization.AllowGroup = false;
            this.searchLookUpEdit1View.OptionsMenu.EnableColumnMenu = false;
            this.searchLookUpEdit1View.OptionsMenu.EnableFooterMenu = false;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowColumnHeaders = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            this.searchLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // lciCreatedOn
            // 
            this.lciCreatedOn.Control = this.deCreatedOn;
            this.lciCreatedOn.CustomizationFormText = "CreatedOn:";
            this.lciCreatedOn.Location = new System.Drawing.Point(0, 0);
            this.lciCreatedOn.Name = "lciCreatedOn";
            this.lciCreatedOn.Size = new System.Drawing.Size(560, 24);
            this.lciCreatedOn.Text = "Дата перемещения:";
            this.lciCreatedOn.TextSize = new System.Drawing.Size(118, 13);
            // 
            // deCreatedOn
            // 
            this.deCreatedOn.EditValue = null;
            this.deCreatedOn.Location = new System.Drawing.Point(124, 2);
            this.deCreatedOn.Name = "deCreatedOn";
            this.deCreatedOn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCreatedOn.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCreatedOn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.deCreatedOn.Size = new System.Drawing.Size(434, 20);
            this.deCreatedOn.StyleController = this.lcMain;
            this.deCreatedOn.TabIndex = 0;
            // 
            // meNote
            // 
            this.meNote.Location = new System.Drawing.Point(124, 98);
            this.meNote.Name = "meNote";
            this.meNote.Size = new System.Drawing.Size(434, 207);
            this.meNote.StyleController = this.lcMain;
            this.meNote.TabIndex = 4;
            // 
            // lciNote
            // 
            this.lciNote.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lciNote.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lciNote.Control = this.meNote;
            this.lciNote.CustomizationFormText = "Tag:";
            this.lciNote.Location = new System.Drawing.Point(0, 96);
            this.lciNote.Name = "lciNote";
            this.lciNote.Size = new System.Drawing.Size(560, 211);
            this.lciNote.Text = "Заметки:";
            this.lciNote.TextSize = new System.Drawing.Size(118, 13);
            // 
            // lciDstRoom
            // 
            this.lciDstRoom.Control = this.leDstRoom;
            this.lciDstRoom.Location = new System.Drawing.Point(0, 48);
            this.lciDstRoom.Name = "lciDstRoom";
            this.lciDstRoom.Size = new System.Drawing.Size(560, 24);
            this.lciDstRoom.Text = "Конечное размещение:";
            this.lciDstRoom.TextSize = new System.Drawing.Size(118, 13);
            // 
            // leDstRoom
            // 
            this.leDstRoom.Location = new System.Drawing.Point(124, 50);
            this.leDstRoom.Name = "leDstRoom";
            this.leDstRoom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leDstRoom.Properties.DisplayMember = "Name";
            this.leDstRoom.Properties.NullText = "";
            this.leDstRoom.Properties.PopupSizeable = false;
            this.leDstRoom.Properties.ValueMember = "Id";
            this.leDstRoom.Properties.View = this.gridView1;
            this.leDstRoom.Size = new System.Drawing.Size(434, 20);
            this.leDstRoom.StyleController = this.lcMain;
            this.leDstRoom.TabIndex = 2;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // seAmount
            // 
            this.seAmount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seAmount.Location = new System.Drawing.Point(124, 74);
            this.seAmount.Name = "seAmount";
            this.seAmount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seAmount.Properties.Mask.EditMask = "c";
            this.seAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.seAmount.Size = new System.Drawing.Size(434, 20);
            this.seAmount.StyleController = this.lcMain;
            this.seAmount.TabIndex = 3;
            // 
            // lciAmount
            // 
            this.lciAmount.Control = this.seAmount;
            this.lciAmount.CustomizationFormText = "Amount:";
            this.lciAmount.Location = new System.Drawing.Point(0, 72);
            this.lciAmount.Name = "lciAmount";
            this.lciAmount.Size = new System.Drawing.Size(560, 24);
            this.lciAmount.Text = "Стоимость ремонта:";
            this.lciAmount.TextSize = new System.Drawing.Size(118, 13);
            // 
            // AddMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "AddMovement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Перемещения";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSrcRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSrcRoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreatedOn.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreatedOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDstRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leDstRoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlItem lciSrcRoom;
        private DevExpress.XtraLayout.LayoutControlItem lciCreatedOn;
        private DevExpress.XtraEditors.MemoEdit meNote;
        private DevExpress.XtraLayout.LayoutControlItem lciNote;
        private DevExpress.XtraLayout.LayoutControlItem lciDstRoom;
        private DevExpress.XtraEditors.DateEdit deCreatedOn;
        private DevExpress.XtraEditors.SpinEdit seAmount;
        private DevExpress.XtraLayout.LayoutControlItem lciAmount;
        private DevExpress.XtraEditors.SearchLookUpEdit leSrcRoom;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SearchLookUpEdit leDstRoom;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;


    }
}