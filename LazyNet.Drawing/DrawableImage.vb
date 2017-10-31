Imports System.Math
Imports System.Xml.Serialization
Imports System.ComponentModel
Imports System.IO

<Serializable()> _
Public Class DrawableImage
    Inherits Drawable

    Private m_Image As Image = Nothing
    <XmlIgnore()> _
    Public Property Picture() As Image
        Get
            Return m_Image
        End Get
        Set(ByVal value As Image)
            m_Image = value

            ' If we should preserve the image's aspect ratio, do so.
#Const PRESERVE_ASPECT_RATIO = True
#If PRESERVE_ASPECT_RATIO Then
            Dim rect As Rectangle = GetBounds()
            If Picture.Width / Picture.Height > rect.Width / rect.Height Then
                ' The area is too tall and thin. Make it shorter.
                Dim hgt As Integer = (CInt(Int(rect.Width / Picture.Width * Picture.Height)))
                Y1 = rect.Y + (rect.Height - hgt) \ 2
                Y2 = Y1 + hgt
            Else
                ' The area is too short and wide. Make it thinner.
                Dim wid As Integer = (CInt(Int(Picture.Width / Picture.Height * rect.Height)))
                X1 = rect.X + (rect.Width - wid) \ 2
                X2 = X1 + wid
            End If
#End If
        End Set
    End Property

    ' An array of bytes used to serialize and deserialize the bitmap
    Public Property BitmapBytes() As Byte()
        Get
            If m_Image Is Nothing Then
                Return Nothing
            Else
                Dim converter As TypeConverter = _
                    TypeDescriptor.GetConverter(Picture.GetType())
                Return DirectCast( _
                    converter.ConvertTo(m_Image, GetType(Byte())), _
                    Byte())
            End If
        End Get
        Set(ByVal value As Byte())
            If value Is Nothing Then
                m_Image = Nothing
            Else
                m_Image = New Bitmap(New MemoryStream(value))
            End If
        End Set
    End Property

    ' Constructors.
    Public Sub New()
    End Sub
    Public Sub New(ByVal new_x1 As Integer, Optional ByVal new_y1 As Integer = 0, Optional ByVal new_x2 As Integer = 1, Optional ByVal new_y2 As Integer = 1)
        MyBase.New()

        X1 = new_x1
        Y1 = new_y1
        X2 = new_x2
        Y2 = new_y2
    End Sub

    ' Draw the object on this Graphics surface.
    Public Overrides Sub Draw(ByVal gr As System.Drawing.Graphics)
        ' Make a Rectangle representing this rectangle.
        Dim rect As Rectangle = GetBounds()

        ' Draw the image.
        If m_Image IsNot Nothing Then
            gr.DrawImage(m_Image, rect)
        Else
            gr.FillRectangle(Brushes.White, rect)
            gr.DrawRectangle(Pens.Black, rect)
        End If

        ' See if we're selected.
        If IsSelected Then
            ' Draw the rectangle highlighted.
            Dim highlight_pen As New Pen(Color.Yellow, LineWidth)
            gr.DrawRectangle(highlight_pen, rect)
            highlight_pen.Dispose()

            ' Draw grab handles.
            DrawGrabHandle(gr, X1, Y1)
            DrawGrabHandle(gr, X1, Y2)
            DrawGrabHandle(gr, X2, Y2)
            DrawGrabHandle(gr, X2, Y1)
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
        Return (x >= Min(X1, X2)) AndAlso _
               (x <= Max(X1, X2)) AndAlso _
               (y >= Min(Y1, Y2)) AndAlso _
               (y <= Max(Y1, Y2))
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
