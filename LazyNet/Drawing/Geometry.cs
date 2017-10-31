using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Dekart.LazyNet.Drawing
{
    static class Geometry
    {
        // Return True if (x1, y1) is within close_distance 
        // vertically and horizontally of (x2, y2).
        public static bool PointNearPoint(int x1, int y1, int x2, int y2, int closeDistance = 2)
        {
            return (Math.Abs(x2 - x1) <= closeDistance) && (Math.Abs(y2 - y1) <= closeDistance);
        }

        // Return True if (px, py) is within close_distance 
        // if the segment from (x1, y1) to (X2, y2).
        public static bool PointNearSegment(int px, int py, int x1, int y1, int x2, int y2, int closeDistance = 2)
        {
            return DistToSegment(px, py, x1, y1, x2, y2) <= closeDistance;
        }

        // Calculate the distance between the point and the segment.
        private static double DistToSegment(int px, int py, int x1, int y1, int x2, int y2)
        {
            double functionReturnValue;

            double dx = x2 - x1;
            double dy = y2 - y1;
            if (dx.Equals(0f) & dy.Equals(0f))
            {
                // It's a point not a line segment.
                dx = px - x1;
                dy = py - y1;
                functionReturnValue = Math.Sqrt(dx * dx + dy * dy);
                return functionReturnValue;
            }

            double t = (px + py - x1 - y1) / (dx + dy);

            if (t < 0)
            {
                dx = px - x1;
                dy = py - y1;
            }
            else if (t > 1)
            {
                dx = px - x2;
                dy = py - y2;
            }
            else
            {
                double x3 = x1 + t * dx;
                double y3 = y1 + t * dy;
                dx = px - x3;
                dy = py - y3;
            }
            functionReturnValue = Math.Sqrt(dx * dx + dy * dy);
            return functionReturnValue;
        }

        // Return True if the point is inside the ellipse
        // (expanded by distance close_distance vertically
        // and horizontally).
        public static bool PointNearEllipse(int px, int py, int x1, int y1, int x2, int y2, int closeDistance = 0)
        {
            double a = Math.Abs(x2 - x1) / 2 + closeDistance;
            double b = Math.Abs(y2 - y1) / 2 + closeDistance;
            px -= (x2 + x1) / 2;
            py -= (y2 + y1) / 2;
            return ((px * px) / (a * a) + (py * py) / (b * b) <= 1);
        }

        // Return True if the point is within the polygon.
        public static bool PointNearPolygon(int x, int y, PointF[] pgonPts)
        {
            // Make a region for the polygon.
            var pgonPath = new GraphicsPath(FillMode.Alternate);
            pgonPath.AddPolygon(pgonPts);
            var pgonRegion = new Region(pgonPath);

            // See if the point is in the region.
            return pgonRegion.IsVisible(x, y);
        }
    }
}
