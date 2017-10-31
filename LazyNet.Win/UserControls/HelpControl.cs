using System;
using System.Drawing;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Utils;
using DevExpress.Utils.About;
using DevExpress.XtraBars.Ribbon;

namespace Dekart.LazyNet.Win.UserControls
{
    public partial class HelpControl : RibbonApplicationUserControl
    {
        Form _aboutPanel;
        public HelpControl()
        {
            InitializeComponent();
            Load += HelpControlLoad;
        }

        void HelpControlLoad(object sender, EventArgs e)
        {
            _aboutPanel = new AboutForm12(new ProductInfo(ProductKind.DXperienceWin, new ProductStringInfo("WinForms Controls", "Build Your Own Office")))
                {
                    TopLevel = false,
                    Parent = splitContainer1.Panel2
                };
            ResizeAbout();
            _aboutPanel.Show();
            splitContainer1.Panel2.Resize += Panel2Resize;
            ResizeAbout();
        }

        void Panel2Resize(object sender, EventArgs e)
        {
            ResizeAbout();
        }
        void ResizeAbout()
        {
            var pnl = _aboutPanel.Parent;
            _aboutPanel.Location = new Point((pnl.Width - _aboutPanel.Width) / 2, (pnl.Height - _aboutPanel.Height) / 2);
        }
        void GalleryControlGallery1ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            string link = string.Format("{0}", e.Item.Tag);
            switch (link)
            {
                case "LinkHelp": link = AssemblyInfo.DXLinkHelp; break;
                case "LinkGetSupport": link = AssemblyInfo.DXLinkGetSupport; break;
                case "LinkGetStarted": link = AssemblyInfo.DXLinkGetStarted; break;
            }
            if (!string.IsNullOrEmpty(link)) ObjectHelper.StartProcess(link);
        }
    }
}
