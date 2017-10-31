using DevExpress.XtraWaitForm;

namespace Dekart.LazyNet.Win
{
    public partial class WfMain : DemoWaitForm
    {
        public WfMain()
        {
            InitializeComponent();
            ProgressPanel.Caption = ConstStrings.ProgressPanelCaption;
            ProgressPanel.Description = ConstStrings.ProgressPanelDescription;
        }
    }
}
