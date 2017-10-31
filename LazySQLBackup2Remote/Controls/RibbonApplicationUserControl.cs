using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon.Drawing;
using DevExpress.XtraBars.Ribbon;

namespace Dekart.LazyNet.SQLBackup2Remote.Controls
{
    public partial class RibbonApplicationUserControl : UserControl
    {
        public RibbonApplicationUserControl()
        {
            InitializeComponent();
        }
        public override Color BackColor
        {
            get
            {
                return GetBackgroundColor();
            }
            set
            {
                base.BackColor = value;
            }
        }
        private Color GetBackgroundColor()
        {
            var parent = Parent as BackstageViewClientControl;
            return parent == null ? Color.Transparent : parent.GetBackgroundColor();
        }
        public BackstageViewControl BackstageView
        {
            get
            {
                if (Parent == null)
                    return null;
                return Parent.Parent as BackstageViewControl;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (BackstageView != null)
                BackstageViewPainter.DrawBackstageViewImage(e, this, BackstageView);
        }
    }
}
