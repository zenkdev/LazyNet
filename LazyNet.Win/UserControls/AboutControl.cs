using System.ComponentModel;
using Dekart.LazyNet.Helpers;
using DevExpress.Utils.Design;
using DevExpress.XtraBars.Docking2010;

namespace Dekart.LazyNet.Win.UserControls
{
    [ToolboxItem(true)]
    public partial class AboutControl : RibbonApplicationUserControl
    {
        public AboutControl()
        {
            InitializeComponent();

            if (DesignTimeTools.IsDesignMode) return;

            descriptionLabel.AutoSizeInLayoutControl = false;
            descriptionLabel.Text = string.Format(ConstStrings.AboutDescription, ColorHelper.TextColor.ToArgb(), ColorHelper.DisabledTextColor.ToArgb());
        }

        void buttonsPanel_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (!Program.ExecuteClickOnce((string) e.Button.Properties.Tag))
            {
                e.Button.Properties.Enabled = false;
            }
            else
            {
                BackstageView.Ribbon.HideApplicationButtonContentControl();
            }
        }
    }
}
