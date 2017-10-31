namespace Dekart.LazyNet.Win
{
    partial class AddAccountForm
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
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            this.lciPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.teLogin = new DevExpress.XtraEditors.TextEdit();
            this.lciLogin = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciComment = new DevExpress.XtraLayout.LayoutControlItem();
            this.mruComment = new DevExpress.XtraEditors.MRUEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mruComment.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.teLogin);
            this.lcMain.Controls.Add(this.tePassword);
            this.lcMain.Controls.Add(this.mruComment);
            this.lcMain.LayoutVersion = "22102014";
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
            this.lcMain.Size = new System.Drawing.Size(368, 122);
            // 
            // lcgRoot
            // 
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciLogin,
            this.lciPassword,
            this.lciComment});
            this.lcgRoot.Size = new System.Drawing.Size(368, 122);
            // 
            // tePassword
            // 
            this.tePassword.Location = new System.Drawing.Point(77, 26);
            this.tePassword.Name = "tePassword";
            this.tePassword.Size = new System.Drawing.Size(289, 20);
            this.tePassword.StyleController = this.lcMain;
            this.tePassword.TabIndex = 7;
            // 
            // lciPassword
            // 
            this.lciPassword.Control = this.tePassword;
            this.lciPassword.CustomizationFormText = "Пароль:";
            this.lciPassword.Location = new System.Drawing.Point(0, 24);
            this.lciPassword.Name = "lciPassword";
            this.lciPassword.Size = new System.Drawing.Size(368, 24);
            this.lciPassword.Text = "Пароль:";
            this.lciPassword.TextSize = new System.Drawing.Size(71, 13);
            // 
            // teLogin
            // 
            this.teLogin.Location = new System.Drawing.Point(77, 2);
            this.teLogin.Name = "teLogin";
            this.teLogin.Size = new System.Drawing.Size(289, 20);
            this.teLogin.StyleController = this.lcMain;
            this.teLogin.TabIndex = 10;
            // 
            // lciLogin
            // 
            this.lciLogin.Control = this.teLogin;
            this.lciLogin.CustomizationFormText = "Логин:";
            this.lciLogin.Location = new System.Drawing.Point(0, 0);
            this.lciLogin.Name = "lciLogin";
            this.lciLogin.Size = new System.Drawing.Size(368, 24);
            this.lciLogin.Text = "Логин:";
            this.lciLogin.TextSize = new System.Drawing.Size(71, 13);
            // 
            // lciComment
            // 
            this.lciComment.Control = this.mruComment;
            this.lciComment.CustomizationFormText = "Комментарий:";
            this.lciComment.Location = new System.Drawing.Point(0, 48);
            this.lciComment.Name = "lciComment";
            this.lciComment.Size = new System.Drawing.Size(368, 66);
            this.lciComment.Text = "Комментарий:";
            this.lciComment.TextSize = new System.Drawing.Size(71, 13);
            // 
            // mruComment
            // 
            this.mruComment.Location = new System.Drawing.Point(77, 50);
            this.mruComment.Name = "mruComment";
            this.mruComment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mruComment.Properties.Sorted = true;
            this.mruComment.Properties.ValidateOnEnterKey = false;
            this.mruComment.Size = new System.Drawing.Size(289, 20);
            this.mruComment.StyleController = this.lcMain;
            this.mruComment.TabIndex = 12;
            // 
            // AddAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 168);
            this.MinimumSize = new System.Drawing.Size(306, 206);
            this.Name = "AddAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddAccountForm";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mruComment.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tePassword;
        private DevExpress.XtraLayout.LayoutControlItem lciPassword;
        private DevExpress.XtraEditors.TextEdit teLogin;
        private DevExpress.XtraLayout.LayoutControlItem lciLogin;
        private DevExpress.XtraLayout.LayoutControlItem lciComment;
        private DevExpress.XtraEditors.MRUEdit mruComment;


    }
}