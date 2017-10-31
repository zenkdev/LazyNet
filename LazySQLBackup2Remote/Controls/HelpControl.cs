namespace Dekart.LazyNet.SQLBackup2Remote.Controls
{
    public partial class HelpControl : RibbonApplicationUserControl
    {
        public HelpControl()
        {
            InitializeComponent();
            versionLabel.Text = AssemblyInfo.Version;
            copyrightLabel.Text = AssemblyInfo.AssemblyCopyright;
            serialNumberLabel.Text = DevExpress.Utils.About.Utility.GetSerial(DevExpress.Utils.About.ProductKind.DXperienceWin, DevExpress.Utils.About.ProductInfoStage.Registered);
        }
    }
}
