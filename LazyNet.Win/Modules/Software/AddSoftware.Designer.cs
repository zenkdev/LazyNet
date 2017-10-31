namespace Dekart.LazyNet.Win.Modules
{
    partial class AddSoftware
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
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.lciName = new DevExpress.XtraLayout.LayoutControlItem();
            this.teSKU = new DevExpress.XtraEditors.TextEdit();
            this.lciSKU = new DevExpress.XtraLayout.LayoutControlItem();
            this.mruCompany = new DevExpress.XtraEditors.MRUEdit();
            this.lciCompany = new DevExpress.XtraLayout.LayoutControlItem();
            this.deBuyedOn = new DevExpress.XtraEditors.DateEdit();
            this.lciBuyedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.deExpiredOn = new DevExpress.XtraEditors.DateEdit();
            this.lciExpiredOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.teSerial = new DevExpress.XtraEditors.TextEdit();
            this.lciSerial = new DevExpress.XtraLayout.LayoutControlItem();
            this.seUsed = new DevExpress.XtraEditors.SpinEdit();
            this.lciUsed = new DevExpress.XtraLayout.LayoutControlItem();
            this.seAvailable = new DevExpress.XtraEditors.SpinEdit();
            this.lciAvailable = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.meNote = new DevExpress.XtraEditors.MemoEdit();
            this.lciNote = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSKU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSKU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mruCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBuyedOn.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBuyedOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBuyedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deExpiredOn.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deExpiredOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExpiredOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSerial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSerial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seUsed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUsed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAvailable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.meNote);
            this.lcMain.Controls.Add(this.seAvailable);
            this.lcMain.Controls.Add(this.seUsed);
            this.lcMain.Controls.Add(this.teSerial);
            this.lcMain.Controls.Add(this.deExpiredOn);
            this.lcMain.Controls.Add(this.deBuyedOn);
            this.lcMain.Controls.Add(this.mruCompany);
            this.lcMain.Controls.Add(this.teSKU);
            this.lcMain.Controls.Add(this.teName);
            this.lcMain.LayoutVersion = "v2";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(906, 437, 250, 350);
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
            this.lcMain.Size = new System.Drawing.Size(759, 651);
            // 
            // lcgRoot
            // 
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciName,
            this.lciSKU,
            this.lciCompany,
            this.lciBuyedOn,
            this.lciExpiredOn,
            this.lciSerial,
            this.lciUsed,
            this.lciAvailable,
            this.emptySpaceItem1,
            this.lciNote});
            this.lcgRoot.Name = "Root";
            this.lcgRoot.Size = new System.Drawing.Size(759, 651);
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(87, 26);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(670, 20);
            this.teName.StyleController = this.lcMain;
            this.teName.TabIndex = 4;
            // 
            // lciName
            // 
            this.lciName.Control = this.teName;
            this.lciName.Location = new System.Drawing.Point(0, 24);
            this.lciName.Name = "lciName";
            this.lciName.Size = new System.Drawing.Size(759, 24);
            this.lciName.Text = "Продукт";
            this.lciName.TextSize = new System.Drawing.Size(81, 13);
            // 
            // teSKU
            // 
            this.teSKU.Location = new System.Drawing.Point(87, 2);
            this.teSKU.Name = "teSKU";
            this.teSKU.Size = new System.Drawing.Size(670, 20);
            this.teSKU.StyleController = this.lcMain;
            this.teSKU.TabIndex = 5;
            // 
            // lciSKU
            // 
            this.lciSKU.Control = this.teSKU;
            this.lciSKU.Location = new System.Drawing.Point(0, 0);
            this.lciSKU.Name = "lciSKU";
            this.lciSKU.Size = new System.Drawing.Size(759, 24);
            this.lciSKU.Text = "Номер лицензии";
            this.lciSKU.TextSize = new System.Drawing.Size(81, 13);
            // 
            // mruCompany
            // 
            this.mruCompany.Location = new System.Drawing.Point(87, 50);
            this.mruCompany.Name = "mruCompany";
            this.mruCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mruCompany.Properties.Sorted = true;
            this.mruCompany.Size = new System.Drawing.Size(670, 20);
            this.mruCompany.StyleController = this.lcMain;
            this.mruCompany.TabIndex = 6;
            // 
            // lciCompany
            // 
            this.lciCompany.Control = this.mruCompany;
            this.lciCompany.Location = new System.Drawing.Point(0, 48);
            this.lciCompany.Name = "lciCompany";
            this.lciCompany.Size = new System.Drawing.Size(759, 24);
            this.lciCompany.Text = "Организация";
            this.lciCompany.TextSize = new System.Drawing.Size(81, 13);
            // 
            // deBuyedOn
            // 
            this.deBuyedOn.EditValue = null;
            this.deBuyedOn.Location = new System.Drawing.Point(87, 74);
            this.deBuyedOn.Name = "deBuyedOn";
            this.deBuyedOn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deBuyedOn.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deBuyedOn.Size = new System.Drawing.Size(670, 20);
            this.deBuyedOn.StyleController = this.lcMain;
            this.deBuyedOn.TabIndex = 7;
            // 
            // lciBuyedOn
            // 
            this.lciBuyedOn.Control = this.deBuyedOn;
            this.lciBuyedOn.Location = new System.Drawing.Point(0, 72);
            this.lciBuyedOn.Name = "lciBuyedOn";
            this.lciBuyedOn.Size = new System.Drawing.Size(759, 24);
            this.lciBuyedOn.Text = "Дата покупки";
            this.lciBuyedOn.TextSize = new System.Drawing.Size(81, 13);
            // 
            // deExpiredOn
            // 
            this.deExpiredOn.EditValue = null;
            this.deExpiredOn.Location = new System.Drawing.Point(87, 98);
            this.deExpiredOn.Name = "deExpiredOn";
            this.deExpiredOn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deExpiredOn.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deExpiredOn.Size = new System.Drawing.Size(670, 20);
            this.deExpiredOn.StyleController = this.lcMain;
            this.deExpiredOn.TabIndex = 8;
            // 
            // lciExpiredOn
            // 
            this.lciExpiredOn.Control = this.deExpiredOn;
            this.lciExpiredOn.Location = new System.Drawing.Point(0, 96);
            this.lciExpiredOn.Name = "lciExpiredOn";
            this.lciExpiredOn.Size = new System.Drawing.Size(759, 24);
            this.lciExpiredOn.Text = "Заканчивается";
            this.lciExpiredOn.TextSize = new System.Drawing.Size(81, 13);
            // 
            // teSerial
            // 
            this.teSerial.Location = new System.Drawing.Point(87, 122);
            this.teSerial.Name = "teSerial";
            this.teSerial.Size = new System.Drawing.Size(670, 20);
            this.teSerial.StyleController = this.lcMain;
            this.teSerial.TabIndex = 9;
            // 
            // lciSerial
            // 
            this.lciSerial.Control = this.teSerial;
            this.lciSerial.Location = new System.Drawing.Point(0, 120);
            this.lciSerial.Name = "lciSerial";
            this.lciSerial.Size = new System.Drawing.Size(759, 24);
            this.lciSerial.Text = "Ключ";
            this.lciSerial.TextSize = new System.Drawing.Size(81, 13);
            // 
            // seUsed
            // 
            this.seUsed.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seUsed.Location = new System.Drawing.Point(87, 146);
            this.seUsed.Name = "seUsed";
            this.seUsed.Properties.Appearance.Options.UseTextOptions = true;
            this.seUsed.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.seUsed.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seUsed.Properties.IsFloatValue = false;
            this.seUsed.Properties.Mask.EditMask = "N00";
            this.seUsed.Size = new System.Drawing.Size(290, 20);
            this.seUsed.StyleController = this.lcMain;
            this.seUsed.TabIndex = 11;
            this.seUsed.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.MinPowerSpinEdit_CustomDisplayText);
            // 
            // lciUsed
            // 
            this.lciUsed.Control = this.seUsed;
            this.lciUsed.Location = new System.Drawing.Point(0, 144);
            this.lciUsed.Name = "lciUsed";
            this.lciUsed.Size = new System.Drawing.Size(379, 24);
            this.lciUsed.Text = "Использовано";
            this.lciUsed.TextSize = new System.Drawing.Size(81, 13);
            // 
            // seAvailable
            // 
            this.seAvailable.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seAvailable.Location = new System.Drawing.Point(466, 146);
            this.seAvailable.Name = "seAvailable";
            this.seAvailable.Properties.Appearance.Options.UseTextOptions = true;
            this.seAvailable.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.seAvailable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seAvailable.Properties.IsFloatValue = false;
            this.seAvailable.Properties.Mask.EditMask = "N00";
            this.seAvailable.Size = new System.Drawing.Size(291, 20);
            this.seAvailable.StyleController = this.lcMain;
            this.seAvailable.TabIndex = 12;
            this.seAvailable.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.MinPowerSpinEdit_CustomDisplayText);
            // 
            // lciAvailable
            // 
            this.lciAvailable.Control = this.seAvailable;
            this.lciAvailable.Location = new System.Drawing.Point(379, 144);
            this.lciAvailable.Name = "lciAvailable";
            this.lciAvailable.Size = new System.Drawing.Size(380, 24);
            this.lciAvailable.Text = "Доступно";
            this.lciAvailable.TextSize = new System.Drawing.Size(81, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 168);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 15);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 15);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(759, 15);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // meNote
            // 
            this.meNote.Location = new System.Drawing.Point(2, 201);
            this.meNote.Name = "meNote";
            this.meNote.Size = new System.Drawing.Size(755, 440);
            this.meNote.StyleController = this.lcMain;
            this.meNote.TabIndex = 13;
            // 
            // lciNote
            // 
            this.lciNote.Control = this.meNote;
            this.lciNote.Location = new System.Drawing.Point(0, 183);
            this.lciNote.Name = "lciNote";
            this.lciNote.Size = new System.Drawing.Size(759, 460);
            this.lciNote.Text = "Заметки";
            this.lciNote.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciNote.TextSize = new System.Drawing.Size(81, 13);
            // 
            // AddSoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 697);
            this.MinimumSize = new System.Drawing.Size(306, 207);
            this.Name = "AddSoftware";
            this.Text = "Программное обеспечение";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSKU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSKU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mruCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBuyedOn.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deBuyedOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBuyedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deExpiredOn.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deExpiredOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExpiredOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSerial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSerial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seUsed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUsed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAvailable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAvailable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraLayout.LayoutControlItem lciName;
        private DevExpress.XtraEditors.TextEdit teSKU;
        private DevExpress.XtraLayout.LayoutControlItem lciSKU;
        private DevExpress.XtraEditors.MRUEdit mruCompany;
        private DevExpress.XtraLayout.LayoutControlItem lciCompany;
        private DevExpress.XtraEditors.DateEdit deBuyedOn;
        private DevExpress.XtraLayout.LayoutControlItem lciBuyedOn;
        private DevExpress.XtraEditors.DateEdit deExpiredOn;
        private DevExpress.XtraLayout.LayoutControlItem lciExpiredOn;
        private DevExpress.XtraEditors.TextEdit teSerial;
        private DevExpress.XtraLayout.LayoutControlItem lciSerial;
        private DevExpress.XtraEditors.SpinEdit seAvailable;
        private DevExpress.XtraEditors.SpinEdit seUsed;
        private DevExpress.XtraLayout.LayoutControlItem lciUsed;
        private DevExpress.XtraLayout.LayoutControlItem lciAvailable;
        private DevExpress.XtraEditors.MemoEdit meNote;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem lciNote;
    }
}