using System;
using System.Drawing;

namespace Dekart.LazyNet.Drawing
{
    [Serializable]
    public class DrawableEllipse : Drawable
    {

        // Constructors.
        public DrawableEllipse()
        {
        }
        public DrawableEllipse(Color foreColor, Color fillColor, int lineWidth = 0, int x1 = 0, int y1 = 0, int x2 = 1, int y2 = 1)
            : base(foreColor, fillColor, lineWidth)
        {

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        // Draw the object on this Graphics surface.
        public override void Draw(Graphics gr, double zoomFactor, int startX, int startY, bool showPreview)
        {
            // Make a Rectangle representing this ellipse.
            var rect = GetBounds();

            // Fill the ellipse as usual.
            var fillBrush = new SolidBrush(FillColor);
            gr.FillEllipse(fillBrush, rect);
            fillBrush.Dispose();

            // See if we're selected.
            if (IsSelected)
            {
                // Draw the ellipse highlighted.
                var highlightPen = new Pen(Color.Yellow, LineWidth);
                gr.DrawEllipse(highlightPen, rect);
                highlightPen.Dispose();

                // Draw grab handles.
                gr.DrawGrabHandle(X1, Y1);
                gr.DrawGrabHandle(X1, Y2);
                gr.DrawGrabHandle(X2, Y2);
                gr.DrawGrabHandle(X2, Y1);
            }
            else
            {
                // Just draw the ellipse.
                var fgPen = new Pen(ForeColor, LineWidth);
                gr.DrawEllipse(fgPen, rect);
                fgPen.Dispose();
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
            return Geometry.PointNearEllipse(x, y, X1, Y1, X2, Y2);
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
