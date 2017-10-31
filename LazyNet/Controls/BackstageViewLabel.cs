using System.Drawing;
using DevExpress.XtraEditors;

namespace Dekart.LazyNet
{
    public class BackstageViewLabel : LabelControl
    {
        public BackstageViewLabel()
        {
            Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AutoSizeMode = LabelAutoSizeMode.None;
            LineLocation = LineLocation.Bottom;
            LineVisible = true;
            ShowLineShadow = false;
        }
    }
}