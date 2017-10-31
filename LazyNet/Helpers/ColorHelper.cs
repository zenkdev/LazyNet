using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;

namespace Dekart.LazyNet.Helpers
{
    public static class ColorHelper
    {
        public static void UpdateColor(ImageList list, UserLookAndFeel lf)
        {
            for (int i = 0; i < list.Images.Count; i++)
                list.Images[i] = SetColor(list.Images[i] as Bitmap, GetHeaderForeColor(lf));
        }
        public static Color GetHeaderForeColor(UserLookAndFeel lf)
        {
            Color ret = SystemColors.ControlText;
            if (lf.ActiveStyle != ActiveLookAndFeelStyle.Skin) return ret;
            return GridSkins.GetSkin(lf)[GridSkins.SkinHeader].Color.GetForeColor();
        }
        static Bitmap SetColor(Bitmap bmp, Color color)
        {
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                    if (bmp.GetPixel(i, j).Name != "0")
                        bmp.SetPixel(i, j, color);
            return bmp;
        }
        public static Color TextColor
        {
            get { return CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.ControlText); }
        }

        public static string HtmlHyperLinkTextColor
        {
            get { return GetRGBColor(HyperLinkTextColor); }
        }
        public static Color HyperLinkTextColor
        {
            get { return EditorsSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor("HyperLinkTextColor"); }
        }
        public static string HtmlHighlightTextColor
        {
            get
            {
                Color color = CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor("HighlightText");
                return GetRGBColor(color);
            }
        }
        public static string HtmlControlTextColor
        {
            get
            {
                Color color = CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor("ControlText");
                return GetRGBColor(color);
            }
        }
        public static string HtmlControlTextColor2
        {
            get
            {
                Color color = CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor("WindowText");
                return GetRGBColor(color);
            }
        }
        public static string HtmlQuestionColor
        {
            get
            {
                Color color = CommonColors.GetQuestionColor(UserLookAndFeel.Default);
                return GetRGBColor(color);
            }
        }
        public static string HtmlWarningColor
        {
            get
            {
                Color color = CommonColors.GetWarningColor(UserLookAndFeel.Default);
                return GetRGBColor(color);
            }
        }
        public static Color DisabledTextColor
        {
            get
            {
                return CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor("DisabledText");
            }
        }
        public static Color CriticalColor
        {
            get
            {
                return CommonColors.GetCriticalColor(UserLookAndFeel.Default);
            }
        }
        public static Color WarningColor
        {
            get
            {
                return CommonColors.GetWarningColor(UserLookAndFeel.Default);
            }
        }
        public static string GetHtmlTextColor(bool focused)
        {
            if (focused)
                return HtmlHighlightTextColor;
            return AllowControlTextColor ? HtmlControlTextColor : HtmlControlTextColor2;
        }

        static string GetRGBColor(Color color)
        {
            return String.Format("{0},{1},{2}", color.R, color.G, color.B);
        }

        static bool AllowControlTextColor { get { return UserLookAndFeel.Default.ActiveSkinName != "Glass Oceans"; } }
    }
}
