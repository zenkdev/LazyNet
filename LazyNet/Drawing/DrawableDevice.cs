using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace Dekart.LazyNet.Drawing
{
    [Serializable]
    public class DrawableDevice : Drawable
    {
        public const int ImageSize = 64;

        public string Text { get; set; }

        Image _picture;

        [XmlIgnore]
        public Image Picture
        {
            get { return _picture; }
            set
            {
                _picture = value;

                // If we should preserve the image's aspect ratio, do so.
#if (PRESERVE_ASPECT_RATIO)
                var rect = GetBounds();
                if (Picture.Width / Picture.Height > rect.Width / rect.Height)
                {
                    // The area is too tall and thin. Make it shorter.
                    var hgt = Convert.ToInt32(rect.Width / Picture.Width * Picture.Height);
                    Y1 = rect.Y + (rect.Height - hgt) / 2;
                    Y2 = Y1 + hgt;
                }
                else
                {
                    // The area is too short and wide. Make it thinner.
                    var wid = Convert.ToInt32(Picture.Width / Picture.Height * rect.Height);
                    X1 = rect.X + (rect.Width - wid) / 2;
                    X2 = X1 + wid;
                }
#endif
            }
        }

        // An array of bytes used to serialize and deserialize the bitmap
        public byte[] BitmapBytes
        {
            get
            {
                if (_picture == null)
                {
                    return null;
                }
                TypeConverter converter = TypeDescriptor.GetConverter(Picture.GetType());
                return (byte[])converter.ConvertTo(_picture, typeof(byte[]));
            }
            set
            {
                _picture = value == null ? null : new Bitmap(new MemoryStream(value));
            }
        }

        // Constructors.
        public DrawableDevice()
        {
        }

        public DrawableDevice(int x1, int y1)
            : this(x1, y1, x1 + ImageSize, y1 + ImageSize)
        {
        }

        public DrawableDevice(int x1, int y1, int x2, int y2)
        {

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        // Draw the object on this Graphics surface.
        public override void Draw(Graphics gr, double zoomFactor, int startX, int startY, bool showPreview)
        {
            // Make a Rectangle representing this rectangle.
            var rect = GetBounds().ImageRectangle(zoomFactor, startX, startY);

            // Draw the image.
            if (_picture != null)
            {
                gr.DrawImage(_picture, rect);
            }
            else
            {
                gr.FillRectangle(Brushes.White, rect);
                gr.DrawRectangle(Pens.Black, rect);
            }

            // See if we're selected.
            if (IsSelected)
            {
                // Draw the rectangle highlighted.
                var highlightPen = new Pen(Color.Yellow, LineWidth);
                gr.DrawRectangle(highlightPen, rect);
                highlightPen.Dispose();

                // Draw grab handles.
                gr.DrawGrabHandle(rect.Left, rect.Top); //gr.DrawGrabHandle(X1, Y1);
                gr.DrawGrabHandle(rect.Left, rect.Bottom); //gr.DrawGrabHandle(X1, Y2);
                gr.DrawGrabHandle(rect.Right, rect.Bottom); //gr.DrawGrabHandle(X2, Y2);
                gr.DrawGrabHandle(rect.Right, rect.Top); //gr.DrawGrabHandle(X2, Y1);
            }

            if (showPreview && !string.IsNullOrWhiteSpace(Text))
            {
                float fontSize = 9F * Convert.ToSingle(zoomFactor);
                if (fontSize < 7F) fontSize = 7F;
                if (fontSize > 12F) fontSize = 12F;
                var fontStyle = IsSelected ? FontStyle.Bold : FontStyle.Regular;
                var sizeF = gr.MeasureString(Text, new Font("", fontSize, fontStyle));
                gr.FillRectangle(Brushes.White, rect.Left, rect.Top + rect.Width + 2, (int)sizeF.Width, (int)sizeF.Height);
                gr.DrawString(Text, new Font("", fontSize, fontStyle), Brushes.Black, rect.Left, rect.Top + rect.Width + 2);
            }
        }

        // Return the object's bounding rectangle.
        public override Rectangle GetBounds()
        {
            return new Rectangle(Math.Min(X1, X2), Math.Min(Y1, Y2), Math.Abs(X2 - X1), Math.Abs(Y2 - Y1));
        }

        // Return True if this point is on the object.
        public override bool IsAt(int x, int y)
        {
            return (x >= Math.Min(X1, X2)) && (x <= Math.Max(X1, X2)) && (y >= Math.Min(Y1, Y2)) && (y <= Math.Max(Y1, Y2));
        }

        // Move the second point.
        public override void NewPoint(int x, int y)
        {
            X2 = x;
            Y2 = y;
        }

        // Return True if the object is empty (e.g. a zero-length line).
        public override bool IsEmpty()
        {
            return (X1 == X2) && (Y1 == Y2);
        }
    }
}