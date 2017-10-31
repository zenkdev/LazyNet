Imports System.Math
Imports System.Drawing.Drawing2D

Module Geometry
    ' Return True if (x1, y1) is within close_distance 
    ' vertically and horizontally of (x2, y2).
    Public Function PointNearPoint(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, Optional ByVal close_distance As Integer = 2) As Boolean
        Return (Abs(x2 - x1) <= close_distance) AndAlso _
               (Abs(y2 - y1) <= close_distance)
    End Function

    ' Return True if (px, py) is within close_distance 
    ' if the segment from (x1, y1) to (X2, y2).
    Public Function PointNearSegment(ByVal px As Integer, ByVal py As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, Optional ByVal close_distance As Integer = 2) As Boolean
        Return DistToSegment(px, py, x1, y1, x2, y2) <= close_distance
    End Function

    ' Calculate the distance between the point and the segment.
    Private Function DistToSegment(ByVal px As Integer, ByVal py As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As Double
        Dim dx As Double
        Dim dy As Double
        Dim t As Double

        dx = X2 - X1
        dy = Y2 - Y1
        If dx = 0 And dy = 0 Then
            ' It's a point not a line segment.
            dx = px - X1
            dy = py - Y1
            DistToSegment = Sqrt(dx * dx + dy * dy)
            Exit Function
        End If

        t = (px + py - X1 - Y1) / (dx + dy)

        If t < 0 Then
            dx = px - X1
            dy = py - Y1
        ElseIf t > 1 Then
            dx = px - X2
            dy = py - Y2
        Else
            Dim x3 As Double = X1 + t * dx
            Dim y3 As Double = Y1 + t * dy
            dx = px - x3
            dy = py - y3
        End If
        DistToSegment = Sqrt(dx * dx + dy * dy)
    End Function

    ' Return True if the point is inside the ellipse
    ' (expanded by distance close_distance vertically
    ' and horizontally).
    Public Function PointNearEllipse(ByVal px As Integer, ByVal py As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, Optional ByVal close_distance As Integer = 0) As Boolean
        Dim a As Double = Abs(x2 - x1) / 2 + close_distance
        Dim b As Double = Abs(y2 - y1) / 2 + close_distance
        px -= (x2 + x1) \ 2
        py -= (y2 + y1) \ 2
        Return ((px * px) / (a * a) + (py * py) / (b * b) <= 1)
    End Function

    ' Return True if the point is within the polygon.
    Public Function PointNearPolygon(ByVal x As Integer, ByVal y As Integer, ByVal pgon_pts() As PointF) As Boolean
        ' Make a region for the polygon.
        Dim pgon_path As New GraphicsPath(FillMode.Alternate)
        pgon_path.AddPolygon(pgon_pts)
        Dim pgon_region As New Region(pgon_path)

        ' See if the point is in the region.
        Return pgon_region.IsVisible(x, y)
    End Function
End Module
