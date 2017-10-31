using DevExpress.XtraEditors;

namespace Dekart.LazyNet.SQLBackup2Remote.Controls
{
    public class BackstageViewLabel : LabelControl
    {
        public BackstageViewLabel()
        {
            Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            AutoSizeMode = LabelAutoSizeMode.None;
            LineLocation = LineLocation.Bottom;
            LineVisible = true;
            ShowLineShadow = false;
        }
    }
}
