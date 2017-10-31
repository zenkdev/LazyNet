using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Drawing;

namespace Dekart.LazyNet
{
    [ToolboxItem(false)]
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
            if (parent == null)
                return Color.Transparent;
            return parent.GetBackgroundColor();
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
