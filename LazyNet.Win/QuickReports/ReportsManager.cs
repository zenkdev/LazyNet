using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace Dekart.LazyNet.Win.QuickReports
{
    class ReportsManager
    {
        readonly ModulesNavigator _modulesNavigator;
        readonly RibbonGalleryBarItem _biGallery;
        readonly Type[] _reports;
        public ReportsManager(ModulesNavigator modulesNavigator, RibbonGalleryBarItem biGallery, params Type[] reports)
        {
            _modulesNavigator = modulesNavigator;
            _biGallery = biGallery;
            _reports = reports;
            
            InitReportGallery(biGallery);
        }

        void InitReportGallery(RibbonGalleryBarItem gddReport)
        {
            gddReport.Gallery.BeginUpdate();
            try
            {
                InitReport(gddReport.Gallery);
            }
            finally
            {
                gddReport.Gallery.EndUpdate();
            }
            gddReport.GalleryItemClick += GddReportGalleryItemClick;
        }
        void InitReport(BaseGallery gallery)
        {
            gallery.Destroy();
            var galleryItemGroup = new GalleryItemGroup { Caption = ConstStrings.QuickReports };
            foreach (var report in _reports)
            {
                var galleryItem = new GalleryItem
                {
                    Caption = GetReportName(report),
                    Image = GetReportImage(report),
                    Tag = report
                };
                galleryItem.HoverImage = galleryItem.Image;
                galleryItemGroup.Items.Add(galleryItem);
            }
            gallery.Groups.Add(galleryItemGroup);
        }

        void GddReportGalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            var frm = _biGallery.Gallery.GetRibbon().FindForm();

            if (SplashScreenManager.Default == null)
                SplashScreenManager.ShowForm(frm, typeof(WfMain), false, true);
            try
            {
                var ds = new ArrayList();
                var grid = _modulesNavigator.CurrentModule.Grid;
                if (grid != null)
                {
                    for (var i = 0; i < grid.MainView.DataRowCount; i++)
                        ds.Add(grid.MainView.GetRow(i));
                }
                var constructorInfoObj = ((Type) e.Item.Tag).GetConstructor(Type.EmptyTypes);
                var xtraReport = constructorInfoObj?.Invoke(null) as XtraReport;
                if (xtraReport != null)
                {
                    xtraReport.DataSource = ds;
                    var topForm = Application.OpenForms["MainForm"];
                    var form = new ReportViewForm(topForm)
                    {
                        Report = xtraReport,
                        Text = GetReportName((Type) e.Item.Tag)
                    };
                    form.Show(topForm);
                }
            }
            finally
            {
                if (SplashScreenManager.Default != null)
                {
                    if (frm != null)
                    {
                        if (SplashScreenManager.FormInPendingState)
                            SplashScreenManager.CloseForm();
                        else
                            SplashScreenManager.CloseForm(false, 500, frm);
                    }
                    else
                        SplashScreenManager.CloseForm();
                }
            }
        }

        static string GetReportName(Type t)
        {
            if (t == typeof(Labels))
            {
                return "Стикеры";
            }
            if (t == typeof(InventoryCards))
            {
                return "Инвентарные карточки";
            }
            if (t == typeof(PrintingCosts))
            {
                return "Печать расход";
            }
            return t.ToString();
        }
        static Image GetReportImage(Type t)
        {
            if (t == typeof(Labels))
            {
                return Properties.Resources.icon_card_16;
            }
            if (t == typeof(InventoryCards))
            {
                return Properties.Resources.icon_list_16;
            }
            if (t == typeof(PrintingCosts))
            {
                return Properties.Resources.icon_print_16;
            }
            return null;
        }
    }
    
}
