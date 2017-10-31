using System;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Dekart.LazyNet.SQLBackup2Remote
{
    /// <summary>DxSplashScreen</summary>
    public partial class DxSplashScreen : SplashScreen
    {
        int _dotCount;
        /// <summary>ctor</summary>
        public DxSplashScreen()
        {
            InitializeComponent();
            lcCopyright.Text = $"{lcCopyright.Text}{GetYearString()}";
            var tmr = new Timer { Interval = 400 };
            tmr.Tick += TmrTick;
            tmr.Start();
        }
        void TmrTick(object sender, EventArgs e)
        {
            if (++_dotCount > 3) _dotCount = 0;
            lcHeader.Text = string.Format("{1}{0}", GetDots(_dotCount), ConstStrings.Starting);
        }

        string GetDots(int count)
        {
            var ret = string.Empty;
            for (var i = 0; i < count; i++) ret += ".";
            return ret;
        }
        int GetYearString()
        {
            var ret = DateTime.Now.Year;
            return (ret < 2010 ? 2010 : ret);
        }
    }
}
