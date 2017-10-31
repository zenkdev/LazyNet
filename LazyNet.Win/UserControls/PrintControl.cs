using System;
using System.Drawing.Printing;
using Dekart.LazyNet.Win.Properties;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using Padding = System.Windows.Forms.Padding;

namespace Dekart.LazyNet.Win.UserControls
{
    public partial class PrintControl : RibbonApplicationUserControl
    {
        GalleryItem _tableStyle, _memoStyle;
        bool _updatedZoom;

        public PrintControl()
        {
            InitializeComponent();
            splitContainer1.Panel1MinSize = layoutControlGroup1.MinSize.Width + 6;
            ddbOrientation.DropDownControl = CreateOrientationGallery();
            ddbMargins.DropDownControl = CreateMarginsGallery();
            ddbPaperSize.DropDownControl = CreatePageSizeGallery();
            ddbCollate.DropDownControl = CreateCollateGallery();
            ddbPrinter.DropDownControl = CreatePrintersGallery();
            ddbDuplex.DropDownControl = CreateDuplexGallery();
            ddbPrintStyle.DropDownControl = CreatePrintStyleGallery();
            _updatedZoom = true;
            zoomTextEdit.EditValue = 70;
            _updatedZoom = false;
        }
        int GetZoomValue()
        {
            if (zoomTrackBarControl1.Value <= 40)
                return 10 + 90 * (zoomTrackBarControl1.Value - 0) / 40;
            return 100 + 400 * (zoomTrackBarControl1.Value - 40) / 40;
        }
        Margins GetMargins()
        {
            var p = (Padding)ddbMargins.Tag;
            return new Margins((int)(p.Left * 3.9), (int)(p.Right * 3.9), (int)(p.Top * 3.9), (int)(p.Bottom * 3.9));
        }
        PaperKind GetPaperKind()
        {
            return (PaperKind)ddbPaperSize.Tag;
        }
        bool GetLandscape()
        {
            if (ddbOrientation.DropDownControl != null)
                return ((GalleryDropDown)ddbOrientation.DropDownControl).Gallery.Groups[0].Items[1].Checked;
            return false;
        }
        int ZoomValueToValue(int zoomValue)
        {
            if (zoomValue < 100)
                return Math.Min(80, Math.Max(0, (zoomValue - 10) * 40 / 90));
            return Math.Min(80, Math.Max(0, (zoomValue - 100) * 40 / 400 + 40));
        }
        void ZoomTrackBarControl1EditValueChanged(object sender, EventArgs e)
        {
            if (_updatedZoom) return;
            _updatedZoom = true;
            try
            {
                zoomTextEdit.EditValue = GetZoomValue();
            }
            finally
            {
                _updatedZoom = false;
            }
        }
        public void InitPrintingSystem()
        {
            var frm = BackstageView.Ribbon.FindForm() as MainForm;
            BarManager manager = frm == null || frm.Ribbon == null ? null : frm.Ribbon.Manager;
            ((GalleryDropDown)ddbOrientation.DropDownControl).Manager = manager;
            ((GalleryDropDown)ddbMargins.DropDownControl).Manager = manager;
            ((GalleryDropDown)ddbPaperSize.DropDownControl).Manager = manager;
            ((GalleryDropDown)ddbCollate.DropDownControl).Manager = manager;
            ((GalleryDropDown)ddbPrinter.DropDownControl).Manager = manager;
            ((GalleryDropDown)ddbDuplex.DropDownControl).Manager = manager;
            ((GalleryDropDown)ddbPrintStyle.DropDownControl).Manager = manager;
            lciPrintStyle.Visibility = frm == null || frm.CurrentRichEdit == null ? LayoutVisibility.Never : LayoutVisibility.Always;

            CreateDocument();
        }
        void CreateDocument()
        {
            var frm = BackstageView.Ribbon.FindForm();
            
            if (SplashScreenManager.Default == null)
                SplashScreenManager.ShowForm(frm, typeof(WfMain), false, true);

            try
            {
                if (true.Equals(printControl1.Tag))
                    printControl1.PrintingSystem.StartPrint -= OnStartPrint;
                var ps = CreateLink();
                printControl1.PrintingSystem = ps;
                ps.StartPrint += OnStartPrint;
                printControl1.Tag = true;
                pageButtonEdit.EditValue = 1;
                UpdatePagesInfo();
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
        PrintingSystemBase CreateLink()
        {
            var ps = new PrintingSystem();
            var frm = BackstageView.Ribbon.FindForm() as MainForm;
            if (frm == null) return ps;

            if (_memoStyle.Checked && frm.CurrentRichEdit != null)
            {
                var link = new Link(ps)
                {
                    RtfReportHeader = frm.CurrentRichEdit.RtfText,
                    PaperKind = GetPaperKind(),
                    Landscape = GetLandscape(),
                    Margins = GetMargins()
                };
                link.CreateDocument();
            }
            else if (_tableStyle.Checked && frm.CurrentPrintableComponent != null)
            {
                var link = new PrintableComponentLink(ps)
                {
                    Component = frm.CurrentPrintableComponent,
                    PaperKind = GetPaperKind(),
                    Landscape = GetLandscape(),
                    Margins = GetMargins()
                };
                link.CreateDocument();
            }

            return ps;
        }
        void OnStartPrint(object sender, PrintDocumentEventArgs e)
        {
            e.PrintDocument.PrinterSettings.Copies = (short)copySpinEdit.Value;
            GetMargins();
            e.PrintDocument.PrinterSettings.Collate = (bool)ddbCollate.Tag;
            e.PrintDocument.PrinterSettings.Duplex = ((bool)ddbDuplex.Tag) ? Duplex.Horizontal : Duplex.Simplex;
        }
        void ZoomTextEditEditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var zoomValue = Int32.Parse(zoomTextEdit.EditValue.ToString());
                zoomTrackBarControl1.Value = ZoomValueToValue(zoomValue);
                printControl1.Zoom = 0.01f * zoomValue;
            }
            catch
            {
                // ignored
            }
        }
        GalleryDropDown CreateListBoxGallery()
        {
            var res = new GalleryDropDown();
            res.Gallery.FixedImageSize = false;
            res.Gallery.ShowItemText = true;
            res.Gallery.ColumnCount = 1;
            res.Gallery.CheckDrawMode = CheckDrawMode.OnlyImage;
            res.Gallery.ShowGroupCaption = false;
            res.Gallery.AutoSize = GallerySizeMode.Vertical;
            res.Gallery.SizeMode = GallerySizeMode.None;
            res.Gallery.ShowScrollBar = ShowScrollBar.Hide;
            res.Gallery.ItemCheckMode = ItemCheckMode.SingleRadio;
            res.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = true;
            res.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = HorzAlignment.Near;
            res.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.VAlignment = VertAlignment.Center;
            res.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseTextOptions = true;
            res.Gallery.Appearance.ItemCaptionAppearance.Hovered.TextOptions.HAlignment = HorzAlignment.Near;
            res.Gallery.Appearance.ItemCaptionAppearance.Hovered.TextOptions.VAlignment = VertAlignment.Center;
            res.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseTextOptions = true;
            res.Gallery.Appearance.ItemCaptionAppearance.Pressed.TextOptions.HAlignment = HorzAlignment.Near;
            res.Gallery.Appearance.ItemCaptionAppearance.Pressed.TextOptions.VAlignment = VertAlignment.Center;

            res.Gallery.ItemImageLocation = Locations.Left;
            res.Gallery.Appearance.ItemDescriptionAppearance.Normal.TextOptions.HAlignment = HorzAlignment.Near;
            res.Gallery.Appearance.ItemDescriptionAppearance.Normal.Options.UseTextOptions = true;
            res.Gallery.Appearance.ItemDescriptionAppearance.Hovered.TextOptions.HAlignment = HorzAlignment.Near;
            res.Gallery.Appearance.ItemDescriptionAppearance.Hovered.Options.UseTextOptions = true;
            res.Gallery.Appearance.ItemDescriptionAppearance.Pressed.TextOptions.HAlignment = HorzAlignment.Near;
            res.Gallery.Appearance.ItemDescriptionAppearance.Pressed.Options.UseTextOptions = true;
            res.Gallery.Groups.Add(new GalleryItemGroup());
            res.Gallery.StretchItems = true;

            return res;
        }
        GalleryDropDown CreateOrientationGallery()
        {
            GalleryDropDown res = CreateListBoxGallery();
            var portraitItem = new GalleryItem
            {
                Image = Resources.PageOrientationPortrait,
                Caption = ConstStrings.PortraitOrientation
            };
            var landscapeItem = new GalleryItem
            {
                Image = Resources.PageOrientationLandscape,
                Caption = ConstStrings.LandscapeOrientation
            };
            res.Gallery.Groups[0].Items.Add(portraitItem);
            res.Gallery.Groups[0].Items.Add(landscapeItem);
            res.Gallery.ItemCheckedChanged += OnOrientationGalleryItemCheckedChanged;
            portraitItem.Checked = true;
            return res;
        }
        GalleryDropDown CreateMarginsGallery()
        {
            GalleryDropDown res = CreateListBoxGallery();
            var normal = new GalleryItem
            {
                Image = Resources.PageMarginsNormal,
                Caption = ConstStrings.MarginsNormal,
                Description = ConstStrings.MarginsNormalDescription,
                Tag = new Padding(25, 25, 25, 25)
            };
            var narrow = new GalleryItem
            {
                Image = Resources.PageMarginsNarrow,
                Caption = ConstStrings.MarginsNarrow,
                Description = ConstStrings.MarginsNarrowDescription,
                Tag = new Padding(12, 12, 12, 12)
            };
            var moderate = new GalleryItem
            {
                Image = Resources.PageMarginsModerate,
                Caption = ConstStrings.MarginsModerate,
                Description = ConstStrings.MarginsModerateDescription,
                Tag = new Padding(19, 25, 19, 25)
            };
            var wide = new GalleryItem
            {
                Image = Resources.PageMarginsWide,
                Caption = ConstStrings.MarginsWide,
                Description = ConstStrings.MarginsWideDescription,
                Tag = new Padding(50, 25, 50, 25)
            };
            res.Gallery.Groups[0].Items.Add(normal);
            res.Gallery.Groups[0].Items.Add(narrow);
            res.Gallery.Groups[0].Items.Add(moderate);
            res.Gallery.Groups[0].Items.Add(wide);
            res.Gallery.ItemCheckedChanged += OnMarginsGalleryItemCheckedChanged;
            normal.Checked = true;
            return res;
        }
        GalleryDropDown CreatePageSizeGallery()
        {
            GalleryDropDown res = CreateListBoxGallery();
            var letter = new GalleryItem
            {
                Image = Resources.PaperKind_Letter,
                Caption = ConstStrings.PaperKindLetter,
                Description = ConstStrings.PaperKindLetterDescription,
                Tag = PaperKind.Letter
            };
            var tabloid = new GalleryItem
            {
                Image = Resources.PaperKind_Tabloid,
                Caption = ConstStrings.PaperKindTabloid,
                Description = ConstStrings.PaperKindTabloidDescription,
                Tag = PaperKind.Tabloid
            };
            var legal = new GalleryItem
            {
                Image = Resources.PaperKind_Legal,
                Caption = ConstStrings.PaperKindLegal,
                Description = ConstStrings.PaperKindLegalDescription,
                Tag = PaperKind.Legal
            };
            var executive = new GalleryItem
            {
                Image = Resources.PaperKind_Executive,
                Caption = ConstStrings.PaperKindExecutive,
                Description = ConstStrings.PaperKindExecutiveDescription,
                Tag = PaperKind.Executive
            };
            var a3 = new GalleryItem
            {
                Image = Resources.PaperKind_A3,
                Caption = ConstStrings.PaperKindA3,
                Description = ConstStrings.PaperKindA3Description,
                Tag = PaperKind.A3
            };
            var a4 = new GalleryItem
            {
                Image = Resources.PaperKind_A4,
                Caption = ConstStrings.PaperKindA4,
                Description = ConstStrings.PaperKindA4Description,
                Tag = PaperKind.A4
            };
            var a5 = new GalleryItem
            {
                Image = Resources.PaperKind_A5,
                Caption = ConstStrings.PaperKindA5,
                Description = ConstStrings.PaperKindA5Description,
                Tag = PaperKind.A5
            };
            var a6 = new GalleryItem
            {
                Image = Resources.PaperKind_A6,
                Caption = ConstStrings.PaperKindA6,
                Description = ConstStrings.PaperKindA6Description,
                Tag = PaperKind.A6
            };
            res.Gallery.Groups[0].Items.Add(letter);
            res.Gallery.Groups[0].Items.Add(tabloid);
            res.Gallery.Groups[0].Items.Add(legal);
            res.Gallery.Groups[0].Items.Add(executive);
            res.Gallery.Groups[0].Items.Add(a3);
            res.Gallery.Groups[0].Items.Add(a4);
            res.Gallery.Groups[0].Items.Add(a5);
            res.Gallery.Groups[0].Items.Add(a6);
            res.Gallery.ItemCheckedChanged += OnPaperSizeGalleryItemCheckedChanged;
            a4.Checked = true;
            return res;
        }
        GalleryDropDown CreateCollateGallery()
        {
            var res = CreateListBoxGallery();
            var collated = new GalleryItem
            {
                Image = Resources.MultiplePagesLarge,
                Caption = ConstStrings.Collated,
                Description = ConstStrings.CollatedDescription,
                Tag = true
            };
            var uncollated = new GalleryItem
            {
                Image = Resources.MultiplePagesLarge,
                Caption = ConstStrings.Uncollated,
                Description = ConstStrings.UncollatedDescription,
                Tag = false
            };
            res.Gallery.Groups[0].Items.Add(collated);
            res.Gallery.Groups[0].Items.Add(uncollated);
            res.Gallery.ItemCheckedChanged += OnCollateGalleryItemCheckedChanged;
            collated.Checked = true;
            return res;
        }
        GalleryDropDown CreateDuplexGallery()
        {
            GalleryDropDown res = CreateListBoxGallery();
            var oneSided = new GalleryItem
            {
                Image = Resources.MultiplePagesLarge,
                Caption = ConstStrings.OneSide,
                Description = ConstStrings.OneSideDescription,
                Tag = false
            };
            var twoSided = new GalleryItem
            {
                Image = Resources.MultiplePagesLarge,
                Caption = ConstStrings.TwoSide,
                Description = ConstStrings.TwoSideDescription,
                Tag = false
            };
            res.Gallery.Groups[0].Items.Add(oneSided);
            res.Gallery.Groups[0].Items.Add(twoSided);
            res.Gallery.ItemCheckedChanged += OnDuplexGalleryItemCheckedChanged;
            oneSided.Checked = true;
            return res;
        }
        GalleryDropDown CreatePrintStyleGallery()
        {
            GalleryDropDown res = CreateListBoxGallery();
            res.Gallery.ItemCheckMode = ItemCheckMode.SingleRadio;
            _tableStyle = new GalleryItem
            {
                Image = Resources.TableStyle,
                Caption = ConstStrings.TableStyleString
            };
            _memoStyle = new GalleryItem
            {
                Image = Resources.MemoStyle,
                Caption = ConstStrings.MemoStyleString
            };
            res.Gallery.Groups[0].Items.Add(_tableStyle);
            res.Gallery.Groups[0].Items.Add(_memoStyle);
            res.Gallery.ItemCheckedChanged += OnPrintStyleGalleryItemCheckedChanged;
            _tableStyle.Checked = true;
            return res;
        }
        GalleryDropDown CreatePrintersGallery()
        {
            GalleryDropDown res = CreateListBoxGallery();
            var ps = new PrinterSettings();
            GalleryItem defaultPrinter = null;
            try
            {
                foreach (string str in PrinterSettings.InstalledPrinters)
                {
                    var item = new GalleryItem
                    {
                        Image = Resources.icon_print_32,
                        Caption = str
                    };
                    res.Gallery.Groups[0].Items.Add(item);
                    ps.PrinterName = str;
                    if (ps.IsDefaultPrinter)
                        defaultPrinter = item;
                }
            }
            catch
            {
                // ignored
            }
            res.Gallery.ItemCheckedChanged += OnPrinterGalleryItemCheckedChanged;
            if (defaultPrinter != null)
                defaultPrinter.Checked = true;
            return res;
        }
        void OnPrintStyleGalleryItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
            ddbPrintStyle.Text = e.Item.Caption;
            ddbPrintStyle.Image = e.Item.Image;
            if (printControl1.PrintingSystem != null)
                CreateDocument();
        }
        void OnDuplexGalleryItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
            ddbDuplex.Text = e.Item.Caption;
            ddbDuplex.Image = e.Item.Image;
            ddbDuplex.Tag = e.Item.Tag;
        }
        void OnMarginsGalleryItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
            ddbMargins.Image = e.Item.Image;
            ddbMargins.Text = e.Item.Caption;
            ddbMargins.Tag = e.Item.Tag;
            if (printControl1.PrintingSystem != null)
            {
                var margins = GetMargins();
                printControl1.PrintingSystem.PageSettings.LeftMargin = margins.Left;
                printControl1.PrintingSystem.PageSettings.RightMargin = margins.Right;
                printControl1.PrintingSystem.PageSettings.TopMargin = margins.Top;
                printControl1.PrintingSystem.PageSettings.BottomMargin = margins.Bottom;
            }
            UpdatePageButtonsEnabledState();
        }
        void OnPrinterGalleryItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
            ddbPrinter.Text = e.Item.Caption;
            ddbPrinter.Image = e.Item.Image;
        }
        void OnCollateGalleryItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
            ddbCollate.Image = e.Item.Image;
            ddbCollate.Text = e.Item.Caption;
            ddbCollate.Tag = e.Item.Tag;
        }
        void OnPaperSizeGalleryItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
            ddbPaperSize.Image = e.Item.Image;
            ddbPaperSize.Text = e.Item.Caption;
            ddbPaperSize.Tag = e.Item.Tag;
            if (printControl1.PrintingSystem != null)
                printControl1.PrintingSystem.PageSettings.PaperKind = GetPaperKind();
            UpdatePageButtonsEnabledState();
        }
        void OnOrientationGalleryItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
            ddbOrientation.Text = e.Item.Caption;
            ddbOrientation.Image = e.Item.Image;
            if (printControl1.PrintingSystem != null)
                printControl1.PrintingSystem.PageSettings.Landscape = GetLandscape();
            UpdatePageButtonsEnabledState();
        }
        void PrintButtonClick(object sender, EventArgs e)
        {
            new PrintTool(printControl1.PrintingSystem).Print(ddbPrinter.Text);
        }
        void PageButtonEditButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var pageIndex = (int)pageButtonEdit.EditValue;
            if (e.Button.Kind == ButtonPredefines.Left)
            {
                if (pageIndex > 1)
                    pageIndex--;
            }
            else if (e.Button.Kind == ButtonPredefines.Right)
            {
                if (pageIndex < printControl1.PrintingSystem.Pages.Count)
                    pageIndex++;
            }
            pageButtonEdit.EditValue = pageIndex;
        }
        void PageButtonEditEditValueChanging(object sender, ChangingEventArgs e)
        {
            try
            {
                var pageIndex = Int32.Parse(e.NewValue.ToString());
                if (pageIndex < 1)
                    pageIndex = 1;
                else if (pageIndex > printControl1.PrintingSystem.Pages.Count)
                    pageIndex = printControl1.PrintingSystem.Pages.Count;
                e.NewValue = pageIndex;
            }
            catch (Exception)
            {
                e.NewValue = 1;
            }
        }
        void UpdatePagesInfo()
        {
            if (printControl1.PrintingSystem != null)
            {
                pageButtonEdit.Properties.DisplayFormat.FormatString = ConstStrings.PageInfo + printControl1.PrintingSystem.Pages.Count;
                printButton.Enabled = printControl1.PrintingSystem.Pages.Count > 0;
                pageButtonEdit.Enabled = printControl1.PrintingSystem.Pages.Count > 0;
            }
        }
        void UpdatePageButtonsEnabledState(int pageIndex)
        {
            if (printControl1.PrintingSystem == null) return;
            pageButtonEdit.Properties.Buttons[0].Enabled = pageIndex != 1;
            pageButtonEdit.Properties.Buttons[1].Enabled = pageIndex != printControl1.PrintingSystem.Pages.Count;
            UpdatePagesInfo();
        }
        void UpdatePageButtonsEnabledState()
        {
            UpdatePageButtonsEnabledState(printControl1.SelectedPageIndex + 1);
        }
        void PageButtonEditEditValueChanged(object sender, EventArgs e)
        {
            var pageIndex = Convert.ToInt32(pageButtonEdit.EditValue);
            printControl1.SelectedPageIndex = pageIndex - 1;
            UpdatePageButtonsEnabledState(pageIndex);
        }
        void PrintControl1SelectedPageChanged(object sender, EventArgs e)
        {
            pageButtonEdit.EditValue = printControl1.SelectedPageIndex + 1;
        }
    }
}
