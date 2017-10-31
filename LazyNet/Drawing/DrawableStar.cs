using System;
using System.Drawing;

namespace Dekart.LazyNet.Drawing
{
    [Serializable]
    public class DrawableStar : Drawable
    {

        // Constructors.
        public DrawableStar()
        {
        }
        public DrawableStar(Color foreColor, Color fillColor, int lineWidth = 0, int x1 = 0, int y1 = 0, int x2 = 1, int y2 = 1)
            : base(foreColor, fillColor, lineWidth)
        {

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        /// <summary>
        /// Draw the object on this Graphics surface.
        /// </summary>
        public override void Draw(Graphics gr, double zoomFactor, int startX, int startY, bool showPreview)
        {
            // Make an array of points representing this star.
            var pts = GetStarPoints();

            // Fill the star as usual.
            var fillBrush = new SolidBrush(FillColor);
            gr.FillPolygon(fillBrush, pts);
            fillBrush.Dispose();

            // See if we're selected.
            if (IsSelected)
            {
                // Draw the star highlighted.
                var highlightPen = new Pen(Color.Yellow, LineWidth);
                gr.DrawPolygon(highlightPen, pts);
                highlightPen.Dispose();

                // Draw grab handles.
                gr.DrawGrabHandle(X1, Y1);
                gr.DrawGrabHandle(X1, Y2);
                gr.DrawGrabHandle(X2, Y2);
                gr.DrawGrabHandle(X2, Y1);
            }
            else
            {
                // Just draw the star.
                var fgPen = new Pen(ForeColor, LineWidth);
                gr.DrawPolygon(fgPen, pts);
                fgPen.Dispose();
            }
        }

        // Return an array of points for the star.
        private PointF[] GetStarPoints()
        {
            // Create a basic star of radius 1.
            const double r1 = 1,r2 = 0.5, dt = 2 * Math.PI / 10;
            var t = -Math.PI / 2;
            var pts = new PointF[10];
            for (var i = 0; i <= 9; i += 2)
            {
                pts[i].X = Convert.ToSingle(r1 * Math.Cos(t));
                pts[i].Y = Convert.ToSingle(r1 * Math.Sin(t));
                t += dt;
                pts[i + 1].X = Convert.ToSingle(r2 * Math.Cos(t));
                pts[i + 1].Y = Convert.ToSingle(r2 * Math.Sin(t));
                t += dt;
            }

            // Transform to the bounding rectangle.
            double xScale = Math.Abs(X2 - X1) / 2f;
            double yScale = Math.Abs(Y2 - Y1) / 2f;
            double dx = (X2 + X1) / 2f;
            double dy = (Y2 + Y1) / 2f;
            for (var i = 0; i <= 9; i++)
            {
                pts[i].X = Convert.ToSingle(pts[i].X * xScale + dx);
                pts[i].Y = Convert.ToSingle(pts[i].Y * yScale + dy);
            }

            return pts;
        }

        // Return the object's bounding rectangle.
        public override Rectangle GetBounds()
        {
            return new Rectangle(Math.Min(X1, X2), Math.Min(Y1, Y2), Math.Abs(X2 - X1), Math.Abs(Y2 - Y1));
        }

        // Return True if this point is on the object.
        public override bool IsAt(int x, int y)
        {
            return Geometry.PointNearPolygon(x, y, GetStarPoints());
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
