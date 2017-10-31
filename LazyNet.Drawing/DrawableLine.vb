Imports System.Math
Imports System.Xml.Serialization

<Serializable()> _
Public Class DrawableLine
    Inherits Drawable

    ' Constructors.
    Public Sub New()
    End Sub
    Public Sub New(ByVal fore_color As Color, Optional ByVal line_width As Integer = 0, Optional ByVal new_x1 As Integer = 0, Optional ByVal new_y1 As Integer = 0, Optional ByVal new_x2 As Integer = 1, Optional ByVal new_y2 As Integer = 1)
        MyBase.New(fore_color, Nothing, line_width)

        X1 = new_x1
        Y1 = new_y1
        X2 = new_x2
        Y2 = new_y2
    End Sub

    ' Draw the object on this Graphics surface.
    Public Overrides Sub Draw(ByVal gr As System.Drawing.Graphics)
        If IsSelected Then
            ' Draw the line highlighted.
            Dim highlight_pen As New Pen(Color.Yellow, LineWidth)
            gr.DrawLine(highlight_pen, X1, Y1, X2, Y2)
            highlight_pen.Dispose()

            ' Draw grab handles.
            DrawGrabHandle(gr, X1, Y1)
            DrawGrabHandle(gr, X2, Y2)
        Else
            ' Just draw the line.
            Dim fg_pen As New Pen(ForeColor, LineWidth)
            gr.DrawLine(fg_pen, X1, Y1, X2, Y2)
            fg_pen.Dispose()
        End If
    End Sub

    ' Return the object's bounding rectangle.
    Public Overrides Function GetBounds() As System.Drawing.Rectangle
        Return New Rectangle( _
            Min(X1, X2), _
            Min(Y1, Y2), _
            Abs(X2 - X1), _
            Abs(Y2 - Y1))
    End Function

    ' Return True if this point is on the object.
    Public Overrides Function IsAt(ByVal x As Integer, ByVal y As Integer) As Boolean
        Return PointNearSegment(x, y, X1, Y1, X2, Y2)
    End Function

    ' Move the second point.
    Public Overrides Sub NewPoint(ByVal x As Integer, ByVal y As Integer)
        X2 = x
        Y2 = y
    End Sub

    ' Return True if the object is empty (e.g. a zero-length line).
    Public Overrides Function IsEmpty() As Boolean
        Return (X1 = X2) AndAlso (Y1 = Y2)
    End Function
End Class
