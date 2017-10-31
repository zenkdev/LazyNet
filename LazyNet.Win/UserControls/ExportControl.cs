using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraPrinting;

namespace Dekart.LazyNet.Win.UserControls
{
    public partial class ExportControl : RibbonApplicationUserControl
    {
        public ExportControl()
        {
            InitializeComponent();
        }

        readonly List<ImageFormat> _formats = new List<ImageFormat> { ImageFormat.Bmp, ImageFormat.Gif, ImageFormat.Jpeg, ImageFormat.Png, ImageFormat.Tiff, ImageFormat.Emf, ImageFormat.Wmf, ImageFormat.Png };
        
        void GalleryControlGallery1ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            string index = string.Format("{0}", e.Item.Tag);
            var frm = BackstageView.Ribbon.FindForm() as MainForm;
            if (frm == null) return;
            if (index.Contains("PDF"))
                saveFileDialog1.Filter = ConstStrings.PDFFilter;
            else if (index.Contains("HTML"))
                saveFileDialog1.Filter = ConstStrings.HTMLFilter;
            else if (index.Contains("MHT"))
                saveFileDialog1.Filter = ConstStrings.MHTFilter;
            else if (index.Contains("RTF"))
                saveFileDialog1.Filter = ConstStrings.RTFFilter;
            else if (index.Contains("XLS"))
                saveFileDialog1.Filter = ConstStrings.XLSFilter;
            else if (index.Contains("XLSX"))
                saveFileDialog1.Filter = ConstStrings.XLSXFilter;
            else if (index.Contains("CSV"))
                saveFileDialog1.Filter = ConstStrings.CSVFilter;
            else if (index.Contains("Text"))
                saveFileDialog1.Filter = ConstStrings.TextFilter;
            else if (index.Contains("Image"))
                saveFileDialog1.Filter = ConstStrings.ImageFilter;
            saveFileDialog1.Filter += @"|" + ConstStrings.AllFilesFilter;
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.FileName = frm.CurrentModuleName;
            if (saveFileDialog1.ShowDialog(frm) != DialogResult.OK) return;
            Cursor.Current = Cursors.WaitCursor;
            var ps = new PrintingSystem();
            var link = new PrintableComponentLink(ps) { Component = frm.CurrentExportComponent };
            link.CreateDocument();
            ExportTo(index, saveFileDialog1.FileName, ps);
        }

        void ExportTo(string index, string fileName, PrintingSystemBase ps)
        {
            if (String.IsNullOrEmpty(fileName)) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (index.Contains("PDF")) ps.ExportToPdf(fileName);
                else if (index.Contains("HTML")) ps.ExportToHtml(fileName);
                else if (index.Contains("MHT")) ps.ExportToMht(fileName);
                else if (index.Contains("RTF")) ps.ExportToRtf(fileName);
                else if (index.Contains("XLS")) ps.ExportToXls(fileName);
                else if (index.Contains("XLSX")) ps.ExportToXlsx(fileName);
                else if (index.Contains("CSV")) ps.ExportToCsv(fileName);
                else if (index.Contains("Text")) ps.ExportToText(fileName);
                else if (index.Contains("Image"))
                    ps.ExportToImage(fileName, _formats[saveFileDialog1.FilterIndex]);
                Cursor.Current = Cursors.Default;
                ObjectHelper.OpenExportedFile(saveFileDialog1.FileName);
            }
            catch
            {
                ObjectHelper.ShowExportErrorMessage();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                BackstageView.Ribbon.HideApplicationButtonContentControl();
            }
        }
    }
}
