using System;
using System.Drawing;

namespace Dekart.LazyNet.Drawing
{
    [Serializable]
    public class DrawableLine : Drawable
    {

        // Constructors.
        public DrawableLine()
        {
        }
        public DrawableLine(Color foreColor, int lineWidth = 0, int x1 = 0, int y1 = 0, int x2 = 1, int y2 = 1)
            : base(foreColor, Color.Empty, lineWidth)
        {

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        // Draw the object on this Graphics surface.
        public override void Draw(Graphics gr, double zoomFactor, int startX, int startY, bool showPreview)
        {
            if (IsSelected)
            {
                // Draw the line highlighted.
                var highlightPen = new Pen(Color.Yellow, LineWidth);
                gr.DrawLine(highlightPen, X1, Y1, X2, Y2);
                highlightPen.Dispose();

                // Draw grab handles.
                gr.DrawGrabHandle(X1, Y1);
                gr.DrawGrabHandle( X2, Y2);
            }
            else
            {
                // Just draw the line.
                var fgPen = new Pen(ForeColor, LineWidth);
                gr.DrawLine(fgPen, X1, Y1, X2, Y2);
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
            return Geometry.PointNearSegment(x, y, X1, Y1, X2, Y2);
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
