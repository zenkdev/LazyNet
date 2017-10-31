namespace Dekart.LazyNet.Win {
    partial class LayoutOptions {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit2 = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.ceAllowRestoreGridViewLayout = new DevExpress.XtraEditors.CheckEdit();
            this.ceAllowRestoreLayoutControlLayout = new DevExpress.XtraEditors.CheckEdit();
            this.ceAllowRestoreFormLayout = new DevExpress.XtraEditors.CheckEdit();
            this.sbClearLayouts = new DevExpress.XtraEditors.SimpleButton();
            this.ceDefaultEditGridViewInDetailForms = new DevExpress.XtraEditors.CheckEdit();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAllowRestoreGridViewLayout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAllowRestoreLayoutControlLayout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAllowRestoreFormLayout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceDefaultEditGridViewInDetailForms.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.AllowCustomization = false;
            this.lcMain.Controls.Add(this.labelControl1);
            this.lcMain.Controls.Add(this.spinEdit2);
            this.lcMain.Controls.Add(this.spinEdit1);
            this.lcMain.Controls.Add(this.sbCancel);
            this.lcMain.Controls.Add(this.sbOK);
            this.lcMain.Controls.Add(this.ceAllowRestoreGridViewLayout);
            this.lcMain.Controls.Add(this.ceAllowRestoreLayoutControlLayout);
            this.lcMain.Controls.Add(this.ceAllowRestoreFormLayout);
            this.lcMain.Controls.Add(this.sbClearLayouts);
            this.lcMain.Controls.Add(this.ceDefaultEditGridViewInDetailForms);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.lcgMain;
            this.lcMain.Size = new System.Drawing.Size(338, 229);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 104);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.StyleController = this.lcMain;
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Шаг сетки";
            // 
            // spinEdit2
            // 
            this.spinEdit2.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinEdit2.Location = new System.Drawing.Point(253, 121);
            this.spinEdit2.Name = "spinEdit2";
            this.spinEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit2.Properties.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinEdit2.Properties.IsFloatValue = false;
            this.spinEdit2.Properties.Mask.EditMask = "N00";
            this.spinEdit2.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEdit2.Properties.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinEdit2.Size = new System.Drawing.Size(73, 20);
            this.spinEdit2.StyleController = this.lcMain;
            this.spinEdit2.TabIndex = 7;
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(94, 121);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit1.Properties.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinEdit1.Properties.IsFloatValue = false;
            this.spinEdit1.Properties.Mask.EditMask = "N00";
            this.spinEdit1.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEdit1.Properties.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinEdit1.Size = new System.Drawing.Size(73, 20);
            this.spinEdit1.StyleController = this.lcMain;
            this.spinEdit1.TabIndex = 6;
            // 
            // sbCancel
            // 
            this.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbCancel.Location = new System.Drawing.Point(246, 195);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(80, 22);
            this.sbCancel.StyleController = this.lcMain;
            this.sbCancel.TabIndex = 10;
            this.sbCancel.Text = "&Отмена";
            // 
            // sbOK
            // 
            this.sbOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sbOK.Location = new System.Drawing.Point(166, 195);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(76, 22);
            this.sbOK.StyleController = this.lcMain;
            this.sbOK.TabIndex = 9;
            this.sbOK.Text = "&ОК";
            // 
            // ceAllowRestoreGridViewLayout
            // 
            this.ceAllowRestoreGridViewLayout.Location = new System.Drawing.Point(12, 58);
            this.ceAllowRestoreGridViewLayout.Name = "ceAllowRestoreGridViewLayout";
            this.ceAllowRestoreGridViewLayout.Properties.Caption = "Сохранять компоновку таблиц";
            this.ceAllowRestoreGridViewLayout.Size = new System.Drawing.Size(314, 19);
            this.ceAllowRestoreGridViewLayout.StyleController = this.lcMain;
            this.ceAllowRestoreGridViewLayout.TabIndex = 2;
            // 
            // ceAllowRestoreLayoutControlLayout
            // 
            this.ceAllowRestoreLayoutControlLayout.Location = new System.Drawing.Point(12, 35);
            this.ceAllowRestoreLayoutControlLayout.Name = "ceAllowRestoreLayoutControlLayout";
            this.ceAllowRestoreLayoutControlLayout.Properties.Caption = "Сохранять компоновку модулей";
            this.ceAllowRestoreLayoutControlLayout.Size = new System.Drawing.Size(314, 19);
            this.ceAllowRestoreLayoutControlLayout.StyleController = this.lcMain;
            this.ceAllowRestoreLayoutControlLayout.TabIndex = 1;
            // 
            // ceAllowRestoreFormLayout
            // 
            this.ceAllowRestoreFormLayout.Location = new System.Drawing.Point(12, 12);
            this.ceAllowRestoreFormLayout.Name = "ceAllowRestoreFormLayout";
            this.ceAllowRestoreFormLayout.Properties.Caption = "Сохранять компоновку деталей";
            this.ceAllowRestoreFormLayout.Size = new System.Drawing.Size(314, 19);
            this.ceAllowRestoreFormLayout.StyleController = this.lcMain;
            this.ceAllowRestoreFormLayout.TabIndex = 0;
            // 
            // sbClearLayouts
            // 
            this.sbClearLayouts.Location = new System.Drawing.Point(12, 155);
            this.sbClearLayouts.Name = "sbClearLayouts";
            this.sbClearLayouts.Size = new System.Drawing.Size(314, 22);
            this.sbClearLayouts.StyleController = this.lcMain;
            this.sbClearLayouts.TabIndex = 8;
            this.sbClearLayouts.Text = "Настройки по умолчанию";
            this.sbClearLayouts.Click += new System.EventHandler(this.SbClearLayoutsClick);
            // 
            // ceDefaultEditGridViewInDetailForms
            // 
            this.ceDefaultEditGridViewInDetailForms.Location = new System.Drawing.Point(12, 81);
            this.ceDefaultEditGridViewInDetailForms.Name = "ceDefaultEditGridViewInDetailForms";
            this.ceDefaultEditGridViewInDetailForms.Properties.Caption = "Разрешить редактирование таблиц в деталях";
            this.ceDefaultEditGridViewInDetailForms.Size = new System.Drawing.Size(314, 19);
            this.ceDefaultEditGridViewInDetailForms.StyleController = this.lcMain;
            this.ceDefaultEditGridViewInDetailForms.TabIndex = 4;
            // 
            // lcgMain
            // 
            this.lcgMain.CustomizationFormText = "lcgMain";
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem10,
            this.layoutControlItem9,
            this.layoutControlItem11});
            this.lcgMain.Location = new System.Drawing.Point(0, 0);
            this.lcgMain.Name = "lcgMain";
            this.lcgMain.Size = new System.Drawing.Size(338, 229);
            this.lcgMain.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ceAllowRestoreFormLayout;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(318, 23);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ceAllowRestoreLayoutControlLayout;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(318, 23);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ceAllowRestoreGridViewLayout;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(318, 23);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.sbClearLayouts;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 143);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(318, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 133);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(318, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 169);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(318, 14);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 183);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(154, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.sbOK;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(154, 183);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.sbCancel;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(234, 183);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.ceDefaultEditGridViewInDetailForms;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 69);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(318, 23);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.spinEdit2;
            this.layoutControlItem10.CustomizationFormText = "по вертикали:";
            this.layoutControlItem10.Location = new System.Drawing.Point(159, 109);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(159, 24);
            this.layoutControlItem10.Text = "по вертикали";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.spinEdit1;
            this.layoutControlItem9.CustomizationFormText = "по горизонтали:";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 109);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(159, 24);
            this.layoutControlItem9.Text = "по горизонтали";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.labelControl1;
            this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(318, 17);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // LayoutOptions
            // 
            this.AcceptButton = this.sbOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.sbCancel;
            this.ClientSize = new System.Drawing.Size(338, 229);
            this.Controls.Add(this.lcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayoutOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки компоновки";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAllowRestoreGridViewLayout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAllowRestoreLayoutControlLayout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAllowRestoreFormLayout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceDefaultEditGridViewInDetailForms.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>For design purposes</summary>
        protected DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraEditors.SimpleButton sbClearLayouts;
        /// <summary>For design purposes</summary>
        protected DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.CheckEdit ceAllowRestoreGridViewLayout;
        private DevExpress.XtraEditors.CheckEdit ceAllowRestoreLayoutControlLayout;
        private DevExpress.XtraEditors.CheckEdit ceAllowRestoreFormLayout;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.CheckEdit ceDefaultEditGridViewInDetailForms;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spinEdit2;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
    }
}
