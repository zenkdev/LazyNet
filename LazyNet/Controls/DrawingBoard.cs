using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dekart.LazyNet
{
    [ComVisible(false)]
    internal partial class DrawingBoard : UserControl
    {
        //Public Events

        public delegate void SetScrollPositionsEventHandler();

        private readonly Pen _mSelectPen = new Pen(Color.Blue, 2);

        //Member Variables

        private Rectangle _destRect;
        private Point _endPoint;
        private Rectangle _srcRect;

        private Size _mApparentImageSize = new Size(0, 0);

        private int _mDrawHeight;
        private int _mDrawWidth;
        private MouseButtons _mMouseButtons = MouseButtons.Left;
        private Point _mOrigin = new Point(0, 0);
        private Bitmap _mOriginalImage;

        private bool _mPanMode = true;

        private Rectangle _mSelectRect;
        private Point _mStartPoint;
        private bool _mStretchImageToFit;
        private double _mZoomFactor = 1.0;
        private bool _mZoomOnMouseWheel = true;
        private Point _mCenterpoint;

        #region "Public/Private Shadows"

        public Image Image
        {
            get { return _mOriginalImage; }
            set
            {
                if ((_mOriginalImage != null))
                {
                    _mOriginalImage.Dispose();
                    _mSelectRect = Rectangle.Empty;
                    _mOrigin = new Point(0, 0);
                    _mApparentImageSize = new Size(0, 0);
                    _mZoomFactor = 1;
                    GC.Collect();
                }

                if (value == null)
                {
                    _mOriginalImage = null;
                    Invalidate();
                    return;
                }

                var r = new Rectangle(0, 0, value.Width, value.Height);
                _mOriginalImage = new Bitmap(value);
                _mOriginalImage = _mOriginalImage.Clone(r, PixelFormat.Format32bppPArgb);

                //Force a paint
                Invalidate();
            }
        }

        public Image InitialImage
        {
            get { return _mOriginalImage; }
            set
            {
                Image = value;
                ZoomFactor = 1;
            }
        }

        public new Image BackgroundImage
        {
            get { return null; }
            set
            {
                Image = value;
                ZoomFactor = 1;
            }
        }

        #endregion

        #region "Protected Overrides"

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            DrawImage(e.Graphics);
            base.OnPaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            _destRect = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
            ComputeDrawingArea();
            base.OnSizeChanged(e);
        }

        #endregion

        #region "Public Properties"

        public MouseButtons PanButton
        {
            get { return _mMouseButtons; }
            set { _mMouseButtons = value; }
        }

        public bool ZoomOnMouseWheel
        {
            get { return _mZoomOnMouseWheel; }
            set { _mZoomOnMouseWheel = value; }
        }

        public double ZoomFactor
        {
            get { return _mZoomFactor; }
            set
            {
                _mZoomFactor = value;
                if (_mZoomFactor > 15)
                    _mZoomFactor = 15;
                if (_mZoomFactor < 0.05)
                    _mZoomFactor = 0.05;
                if ((_mOriginalImage != null))
                {
                    _mApparentImageSize.Height = (int)(_mOriginalImage.Height*_mZoomFactor);
                    _mApparentImageSize.Width = (int)(_mOriginalImage.Width*_mZoomFactor);
                    ComputeDrawingArea();
                    CheckBounds();
                }
                Invalidate();
            }
        }

        public Point Origin
        {
            get { return _mOrigin; }
            set
            {
                _mOrigin = value;
                Invalidate();
            }
        }

        public Size ApparentImageSize
        {
            get { return _mApparentImageSize; }
        }

        public bool PanMode
        {
            get { return _mPanMode; }
            set { _mPanMode = value; }
        }

        public bool StretchImageToFit
        {
            get { return _mStretchImageToFit; }
            set
            {
                _mStretchImageToFit = value;
                Invalidate();
            }
        }

        public void ZoomIn()
        {
            ZoomImage(true);
        }

        public void ZoomOut()
        {
            ZoomImage(false);
        }

        private void ZoomImage(bool zoomIn)
        {
            // Get center point
            _mCenterpoint.X = _mOrigin.X + _srcRect.Width/2;
            _mCenterpoint.Y = _mOrigin.Y + _srcRect.Height/2;

            //set new zoomfactor
            ZoomFactor = zoomIn ? Math.Round(ZoomFactor*1.1, 2) : Math.Round(ZoomFactor*0.9, 2);

            //Reset the origin to maintain center point
            _mOrigin.X = (int)(_mCenterpoint.X - ClientSize.Width/_mZoomFactor/2);
            _mOrigin.Y = (int)(_mCenterpoint.Y - ClientSize.Height/_mZoomFactor/2);

            CheckBounds();
        }

        public void InvertColors()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (_mOriginalImage == null)
                    return;
                // This is the color matrix to invert the image colors.
                var cm = new ColorMatrix(new[]
                {
                    new float[]
                    {
                        -1,
                        0,
                        0,
                        0,
                        0
                    },
                    new float[]
                    {
                        0,
                        -1,
                        0,
                        0,
                        0
                    },
                    new float[]
                    {
                        0,
                        0,
                        -1,
                        0,
                        0
                    },
                    new float[]
                    {
                        0,
                        0,
                        0,
                        1,
                        0
                    },
                    new float[]
                    {
                        1,
                        1,
                        1,
                        1,
                        1
                    }
                });

                var imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(cm);

                var g = Graphics.FromImage(_mOriginalImage);

                var rc = new Rectangle(0, 0, _mOriginalImage.Width, _mOriginalImage.Height);
                g.DrawImage(_mOriginalImage, rc, 0, 0, _mOriginalImage.Width, _mOriginalImage.Height, GraphicsUnit.Pixel,
                    imageAttributes);

                Invalidate();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public void FitToScreen()
        {
            StretchImageToFit = false;
            Origin = new Point(0, 0);
            if (_mOriginalImage == null)
                return;
            ZoomFactor = Math.Min(ClientSize.Width/_mOriginalImage.Width, ClientSize.Height/_mOriginalImage.Height);
        }

        #endregion

        public DrawingBoard()
        {
            Resize += DrawingBoardResize;
            MouseWheel += ImageViewerMouseWheel;
            MouseUp += DrawingBoardMouseUp;
            MouseMove += ImageViewerMouseMove;
            MouseDown += ImageViewerMouseDown;
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        // Pen used to indicate a selection on the image (zoom window)

        private Rectangle SelectedRectangle
        {
            get { return _mSelectRect; }
            set
            {
                _mSelectRect = value;
                Invalidate();
            }
        }

        public event SetScrollPositionsEventHandler SetScrollPositions;

        private void DrawRectangle(MouseEventArgs e)
        {
            if ((new Rectangle(0, 0, Width, Height)).Contains(PointToClient(Cursor.Position)))
            {
                int width = Math.Abs(_mStartPoint.X - e.X);
                int height = Math.Abs(_mStartPoint.Y - e.Y);
                //need to determine the  upper left corner of the rectangel regardless of whether it's 
                //the start point or the end point, or other.
                var upperLeft = new Point(Math.Min(_mStartPoint.X, e.X), Math.Min(_mStartPoint.Y, e.Y));
                SelectedRectangle = new Rectangle(upperLeft.X, upperLeft.Y, width, height);
            }
        }

        private void DrawImage(Graphics g)
        {
            if (_mOriginalImage == null)
                return;

            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            _srcRect = _mStretchImageToFit ? new Rectangle(0, 0, _mOriginalImage.Width, _mOriginalImage.Height) : new Rectangle(_mOrigin.X, _mOrigin.Y, _mDrawWidth, _mDrawHeight);

            g.DrawImage(_mOriginalImage, _destRect, _srcRect, GraphicsUnit.Pixel);

            if (!PanMode)
            {
                g.DrawRectangle(_mSelectPen, SelectedRectangle);
            }

            if (SetScrollPositions != null)
            {
                SetScrollPositions();
            }
        }

        private void ComputeDrawingArea()
        {
            _mDrawHeight = (int)(Height / _mZoomFactor);
            _mDrawWidth = (int)(Width / _mZoomFactor);
        }

        private void ImageViewerMouseDown(object sender, MouseEventArgs e)
        {
            if (_mOriginalImage == null)
                return;
            _endPoint = Point.Empty;
            SelectedRectangle = Rectangle.Empty;

            //Set the start point. This is used for panning and zooming so we always set it.
            _mStartPoint = new Point(e.X, e.Y);
            Focus();
        }

        private void ImageViewerMouseMove(object sender, MouseEventArgs e)
        {
            if (_mOriginalImage == null)
                return;

            if (e.Button == _mMouseButtons)
            {
                int deltaX = _mStartPoint.X - e.X;
                int deltaY = _mStartPoint.Y - e.Y;

                if (PanMode)
                {
                    //Set the origin of the new image

                    _mOrigin.X = _mOrigin.X + (int)(deltaX / _mZoomFactor);
                    _mOrigin.Y = _mOrigin.Y + (int)(deltaY / _mZoomFactor);

                    CheckBounds();

                    //reset the startpoints
                    _mStartPoint.X = e.X;
                    _mStartPoint.Y = e.Y;

                    //Force a paint
                    Invalidate();
                }
                else
                {
                    DrawRectangle(e);
                }
            }
        }

        private void CheckBounds()
        {
            if (_mOriginalImage == null)
                return;
            //Make sure we don't go out of bounds
            if (_mOrigin.X < 0)
                _mOrigin.X = 0;
            if (_mOrigin.Y < 0)
                _mOrigin.Y = 0;
            if (_mOrigin.X > _mOriginalImage.Width - (int)(ClientSize.Width / _mZoomFactor))
            {
                _mOrigin.X = _mOriginalImage.Width - (int)(ClientSize.Width/_mZoomFactor);
            }
            if (_mOrigin.Y > _mOriginalImage.Height - (int)(ClientSize.Height / _mZoomFactor))
            {
                _mOrigin.Y = _mOriginalImage.Height - (int)(ClientSize.Height / _mZoomFactor);
            }

            if (_mOrigin.X < 0)
                _mOrigin.X = 0;
            if (_mOrigin.Y < 0)
                _mOrigin.Y = 0;
        }

        private void DrawingBoardMouseUp(object sender, MouseEventArgs e)
        {
            if (_mOriginalImage == null)
                return;
            if (!PanMode)
            {
                _endPoint = new Point(e.X, e.Y);
                if (SelectedRectangle == Rectangle.Empty)
                    return;
                ZoomSelection();
            }
        }

        private void ZoomSelection()
        {
            if (_mOriginalImage == null)
                return;

            var newOrigin = new Point(Convert.ToInt32(Origin.X + (SelectedRectangle.X/ZoomFactor)),
                Origin.Y + (int)(SelectedRectangle.Y/ZoomFactor));

            double newFactor;
            if (SelectedRectangle.Width > SelectedRectangle.Height)
            {
                newFactor = (ClientSize.Width/(SelectedRectangle.Width/ZoomFactor));
            }
            else
            {
                newFactor = (ClientSize.Height/(SelectedRectangle.Height/ZoomFactor));
            }

            Origin = newOrigin;
            ZoomFactor = newFactor;
            SelectedRectangle = Rectangle.Empty;
        }


        private void ImageViewerMouseWheel(object sender, MouseEventArgs e)
        {
            if (!ZoomOnMouseWheel)
                return;
            //set new zoomfactor
            if (e.Delta > 0)
            {
                ZoomImage(true);
            }
            else if (e.Delta < 0)
            {
                ZoomImage(false);
            }
        }

        public void RotateFlip(RotateFlipType rotateFlipType)
        {
            if (_mOriginalImage == null)
                return;
            _mOriginalImage.RotateFlip(rotateFlipType);
            Invalidate();
        }


        private void DrawingBoardResize(object sender, EventArgs e)
        {
            ComputeDrawingArea();
            if (StretchImageToFit)
                Invalidate();
        }
    }
}