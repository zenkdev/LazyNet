using System;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraSplashScreen;

namespace Dekart.LazyNet.Win
{
    /// <summary> LoginForm </summary>
    public partial class LoginForm : XtraForm
    {
        readonly Session _session;

        /// <summary> LoginForm </summary>
        public LoginForm(Session session)
        {
            InitializeComponent();

            Icon = ImagesHelper.AppIcon;
            _session = session;
            lcError.Text = string.Empty;
        }

        /// <summary>override OnLoad</summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbUser.Properties.Items.Clear();
            var theCriteria = CriteriaOperator.Parse("UserState<>? And UserName<>? And IsAdmin=?", UserStateEnum.Terminated, "", true);
            foreach (var user in new XPCollection<User>(_session, theCriteria))
            {
                cbUser.Properties.Items.Add(new ImageComboBoxItem {Description = user.FullName, Value = user.UserName});
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SplashScreenManager.CloseForm(false);
        }

        void SbLoginClick(object sender, EventArgs e)
        {
            lcError.Text = string.Empty;
            var userName = (string)cbUser.EditValue;
            var password = bePassword.Text.Trim();
            
            try
            {
                if (string.IsNullOrEmpty(userName))
                {
                    lcError.Text = ConstStrings.UserNameEmptyError;
                }
                else if (password == string.Empty)
                {
                    lcError.Text = ConstStrings.UserPasswordEmptyError;
                }
                else
                {
                    //проверяем пользователя в базе
                    var user = _session.FindObject<User>(CriteriaOperator.Parse("UserName=? And IsAdmin=?", userName, true));
                    if (user == null)
                    {
                        lcError.Text = string.Format(ConstStrings.UserNotFoundError, userName);
                    }
                    else if (user.UserState == UserStateEnum.Terminated)
                    {
                        lcError.Text = string.Format(ConstStrings.UserTerminatedError, userName);
                    }
                    else if (string.IsNullOrEmpty(user.Password) || user.Password != password)
                    {
                        lcError.Text = ConstStrings.UserInvalidPasswordError;
                    }
                    else
                    {
                        //меняем секьюрити инфо
                        DataHelper.CurrentUser = user;

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            catch (Exception exc)
            {
                lcError.Text = exc.Message;
            }
        }

        void BePasswordMouseDown(object sender, MouseEventArgs e)
        {
            var viewInfo = (ButtonEditViewInfo)bePassword.GetViewInfo();
            var hitInfo = viewInfo.CalcHitInfo(e.Location);
            if (hitInfo.HitTest == EditHitTest.Button && e.Button == MouseButtons.Left)
            {
                bePassword.Properties.UseSystemPasswordChar = false;
            }
        }

        void BePasswordMouseUp(object sender, MouseEventArgs e)
        {
            bePassword.Properties.UseSystemPasswordChar = true;
        }

    }
}