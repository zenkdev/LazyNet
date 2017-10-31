using System.Drawing;
using System.Windows.Forms;

namespace Dekart.LazyNet
{
    [System.Runtime.InteropServices.ComVisible(false)]
    public partial class DrawingControl
    {
        bool _mScrollVisible = true;

        public DrawingControl()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
        }

        #region "Public Properties"

        public bool PanMode
        {
            get { return DrawingBoard1.PanMode; }
            set { DrawingBoard1.PanMode = value; }
        }

        public MouseButtons PanButton
        {
            get { return DrawingBoard1.PanButton; }
            set { DrawingBoard1.PanButton = value; }
        }

        public bool ZoomOnMouseWheel
        {
            get { return DrawingBoard1.ZoomOnMouseWheel; }
            set { DrawingBoard1.ZoomOnMouseWheel = value; }
        }

        public double ZoomFactor
        {
            get { return DrawingBoard1.ZoomFactor; }
            set { DrawingBoard1.ZoomFactor = value; }
        }

        public Point Origin
        {
            get { return DrawingBoard1.Origin; }
            set { DrawingBoard1.Origin = value; }
        }

        public bool StretchImageToFit
        {
            get { return DrawingBoard1.StretchImageToFit; }
            set { DrawingBoard1.StretchImageToFit = value; }
        }

        public Size ApparentImageSize
        {
            get { return DrawingBoard1.ApparentImageSize; }
        }

        public void FitToScreen()
        {
            DrawingBoard1.FitToScreen();
        }

        public void InvertColors()
        {
            DrawingBoard1.InvertColors();
        }

        public void ZoomIn()
        {
            DrawingBoard1.ZoomIn();
        }

        public void ZoomOut()
        {
            DrawingBoard1.ZoomOut();
        }

        public bool ScrollbarsVisible
        {
            get { return _mScrollVisible; }
            set
            {
                _mScrollVisible = value;
                HScrollBar1.Visible = value;
                VScrollBar1.Visible = value;
                if (value == false)
                {
                    DrawingBoard1.Dock = DockStyle.Fill;
                }
                else
                {
                    DrawingBoard1.Dock = DockStyle.None;
                    DrawingBoard1.Location = new Point(0, 0);
                    DrawingBoard1.Width = ClientSize.Width - VScrollBar1.Width;
                    DrawingBoard1.Height = ClientSize.Height - HScrollBar1.Height;
                }
            }
        }

        public Point PointToClient2(Point p)
        {
            return DrawingBoard1.PointToClient(p);
        }

        public Point ImagePoint(Point screenPoint)
        {
            var zoomPercent = (int)(ZoomFactor * 100f);

            var imageX = ScreenToImage(screenPoint.X, Origin.X, HScrollBar1, zoomPercent);
            var imageY = ScreenToImage(screenPoint.Y, Origin.Y, VScrollBar1, zoomPercent);

            if (Image == null ||
                imageX < 0 || imageX >= Image.Width ||
                imageY < 0 || imageY >= Image.Height)
                return Point.Empty;

            return new Point(imageX, imageY);
        }

        public Point ScreenPoint(Point imagePoint)
        {
            var zoomPercent = (int)(ZoomFactor * 100f);

            return new Point(ImageToScreen(imagePoint.X, Origin.X, HScrollBar1, zoomPercent), ImageToScreen(imagePoint.Y, Origin.Y, VScrollBar1, zoomPercent));
        }

        #endregion

        #region "Public/Private Shadows"
        public Image Image
        {
            get { return DrawingBoard1.Image; }
            set
            {
                DrawingBoard1.Image = value;
                if (value != null) return;
                HScrollBar1.Enabled = false;
                VScrollBar1.Enabled = false;
            }
        }

        public Image InitialImage
        {
            get { return DrawingBoard1.InitialImage; }
            set
            {
                DrawingBoard1.InitialImage = value;
                if (value != null) return;
                HScrollBar1.Enabled = false;
                VScrollBar1.Enabled = false;
            }
        }

        public new Image BackgroundImage
        {
            get { return DrawingBoard1.BackgroundImage; }
            set
            {
                DrawingBoard1.BackgroundImage = value;
                if (value != null) return;
                HScrollBar1.Enabled = false;
                VScrollBar1.Enabled = false;
            }
        }

        #endregion

        static int ScreenToImage(int screenCoord, int pictureStart, ScrollBar scrollBar, int zoomPercent)
        {
            return screenCoord * 100 / zoomPercent + (scrollBar.Visible ? scrollBar.Value : -pictureStart);
        }

        static int ImageToScreen(int imageCoord, int pictureStart, ScrollBar scrollBar, int zoomPercent)
        {
            return (imageCoord - (scrollBar.Visible ? scrollBar.Value : -pictureStart)) * zoomPercent / 100;
        }

        public void RotateFlip(RotateFlipType rotateFlipType)
        {
            DrawingBoard1.RotateFlip(rotateFlipType);
        }

        void DrawingBoard1SetScrollPositions()
        {
            //int drawingWidth = DrawingBoard1.Image.Width;
            //int drawingHeight = DrawingBoard1.Image.Height;
            int originX = DrawingBoard1.Origin.X;
            int originY = DrawingBoard1.Origin.Y;
            int factoredCtrlWidth = (int)(DrawingBoard1.Width / DrawingBoard1.ZoomFactor);
            int factoredCtrlHeight = (int)(DrawingBoard1.Height / DrawingBoard1.ZoomFactor);
            HScrollBar1.Maximum = DrawingBoard1.Image.Width;
            VScrollBar1.Maximum = DrawingBoard1.Image.Height;

            if (factoredCtrlWidth >= DrawingBoard1.Image.Width | StretchImageToFit)
            {
                HScrollBar1.Enabled = false;
                HScrollBar1.Value = 0;
            }
            else
            {
                HScrollBar1.LargeChange = factoredCtrlWidth;
                HScrollBar1.Enabled = true;
                HScrollBar1.Value = originX;
            }

            if (factoredCtrlHeight >= DrawingBoard1.Image.Height | StretchImageToFit)
            {
                VScrollBar1.Enabled = false;
                VScrollBar1.Value = 0;
            }
            else
            {
                VScrollBar1.Enabled = true;
                VScrollBar1.LargeChange = factoredCtrlHeight;
                VScrollBar1.Value = originY;
            }

        }

        void ScrollBarValueChanged(object sender, System.EventArgs e)
        {
            DrawingBoard1.Origin = new Point(HScrollBar1.Value, VScrollBar1.Value);
        }

        public event PaintEventHandler DrawingBoardPaint;

        void DrawingBoard1Paint(object sender, PaintEventArgs e)
        {
            if (DrawingBoardPaint != null)
            {
                DrawingBoardPaint(sender, e);
            }
        }

        public event MouseEventHandler DrawingBoardMouseDown;

        void DrawingBoard1MouseDown(object sender, MouseEventArgs e)
        {
            if (DrawingBoardMouseDown != null)
            {
                DrawingBoardMouseDown(sender, e);
            }
        }

        public event MouseEventHandler DrawingBoardMouseMove;

        void DrawingBoard1MouseMove(object sender, MouseEventArgs e)
        {
            if (DrawingBoardMouseMove != null)
            {
                DrawingBoardMouseMove(sender, e);
            }
        }
    }

}
