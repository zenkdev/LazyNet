using System;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;

namespace Dekart.LazyNet.Drawing
{
    public static class DrawableHelper
    {
        // Width of grab rectangles. Should be odd.
        public static int GrabHandleWidth = 5;

        public static int GrabHandleHalfWidth = GrabHandleWidth/2;

        public static void DrawGrabHandle(this Graphics gr, int x, int y)
        {
            // Fill a white rectangle.
            gr.FillRectangle(Brushes.White, x - GrabHandleHalfWidth, y - GrabHandleHalfWidth, GrabHandleWidth, GrabHandleWidth);

            // Outline it in black.
            gr.DrawRectangle(Pens.Black, x - GrabHandleHalfWidth, y - GrabHandleHalfWidth, GrabHandleWidth, GrabHandleWidth);
        }


        /// 
        /// Extension method for PictureEdit to convert screen coordinates to image coordinates.
        /// 
        public static Point ImagePoint(this PictureEdit pictureEdit, Point screenPoint)
        {
            HScrollBar hScrollBar = null;
            VScrollBar vScrollBar = null;
            PictureEditViewInfo viewInfo = null;

            if (!CommonSetup(pictureEdit, ref hScrollBar, ref vScrollBar, ref viewInfo))
                return Point.Empty;

            var zoomPercent = (int)pictureEdit.Properties.ZoomPercent * 100;

            var imageX = ScreenToImage(screenPoint.X, (int)viewInfo.PicturePosition.X, hScrollBar, zoomPercent);
            var imageY = ScreenToImage(screenPoint.Y, (int)viewInfo.PicturePosition.Y, vScrollBar, zoomPercent);

            if (imageX < 0 || imageX >= pictureEdit.Image.Width ||
                imageY < 0 || imageY >= pictureEdit.Image.Height)
                return Point.Empty;

            return new Point(imageX, imageY);
        }


        /// 
        /// Extension method for PictureEdit to convert image coordinates to screen coordinates, and
        /// check the screen coordinates are in the displayable window.
        /// 
        public static Point ScreenPointChecked(this PictureEdit pictureEdit, Point imagePoint)
        {
            var screenPoint = ScreenPoint(pictureEdit, imagePoint);

            if (screenPoint.X < pictureEdit.ClientRectangle.Left ||
                screenPoint.X >= pictureEdit.ClientRectangle.Right ||
                screenPoint.Y < pictureEdit.ClientRectangle.Top ||
                screenPoint.Y >= pictureEdit.ClientRectangle.Bottom)
                return Point.Empty;

            return screenPoint;
        }


        /// 
        /// Extension method for PictureEdit to convert image coordinates to screen coordinates, but
        /// without checking if the screen coordinate is in the displayable window. This can be an
        /// advantage in some situations, for example drawing a line from a point that is displayable
        /// to a point that is outside the window - let CGI do the clipping.
        /// 
        public static Point ScreenPoint(this PictureEdit pictureEdit, Point imagePoint)
        {
            HScrollBar hScrollBar = null;
            VScrollBar vScrollBar = null;
            PictureEditViewInfo viewInfo = null;

            if (!CommonSetup(pictureEdit, ref hScrollBar, ref vScrollBar, ref viewInfo))
                return Point.Empty;

            var zoomPercent = (int)pictureEdit.Properties.ZoomPercent * 100;

            return new Point(ImageToScreen(imagePoint.X, (int)viewInfo.PicturePosition.X, hScrollBar, zoomPercent), ImageToScreen(imagePoint.Y, (int)viewInfo.PicturePosition.Y, vScrollBar, zoomPercent));
        }


        static bool CommonSetup(PictureEdit pictureEdit, ref HScrollBar hScrollBar, ref VScrollBar vScrollBar, ref PictureEditViewInfo viewInfo)
        {
            if (pictureEdit.Image == null || pictureEdit.Controls.Count < 2)
                return false;

            hScrollBar = pictureEdit.Controls.OfType<HScrollBar>().FirstOrDefault();
            vScrollBar = pictureEdit.Controls.OfType<VScrollBar>().FirstOrDefault();
            viewInfo = pictureEdit.GetViewInfo() as PictureEditViewInfo;

            return hScrollBar != null && vScrollBar != null && viewInfo != null;
        }


        static int ScreenToImage(int screenCoord, int pictureStart, ScrollBarBase scrollBar, int zoomPercent)
        {
            return (screenCoord + (scrollBar.Visible ? scrollBar.Value : -pictureStart))* 100/zoomPercent;
        }


        static int ImageToScreen(int imageCoord, int pictureStart, ScrollBarBase scrollBar, int zoomPercent)
        {
            return imageCoord*zoomPercent/100 - (scrollBar.Visible ? scrollBar.Value : - pictureStart);
        }

        public static Rectangle ImageRectangle(this Rectangle bounds, double zoomFactor, int startX, int startY)
        {
            var x = Convert.ToInt32(Convert.ToDouble(bounds.X) * zoomFactor) + startX;
            var y = Convert.ToInt32(Convert.ToDouble(bounds.Y) * zoomFactor) + startY;
            var width = Convert.ToInt32(Convert.ToDouble(bounds.Width)*zoomFactor);
            var height = Convert.ToInt32(Convert.ToDouble(bounds.Height)*zoomFactor);
            return new Rectangle(x, y, width, height);
        }
    
    }


}
