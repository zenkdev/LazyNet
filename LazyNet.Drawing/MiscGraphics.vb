Module MiscGraphics

    ' Width of grab rectangles. Should be odd.
    Public GrabHandleWidth As Integer = 5
    Public GrabHandleHalfWidth As Integer = GrabHandleWidth \ 2

    Public Sub DrawGrabHandle(ByVal gr As Graphics, ByVal x As Integer, ByVal y As Integer)
        ' Fill a white rectangle.
        gr.FillRectangle(Brushes.White, _
            x - GrabHandleHalfWidth, _
            y - GrabHandleHalfWidth, _
            GrabHandleWidth, _
            GrabHandleWidth)

        ' Outline it in black.
        gr.DrawRectangle(Pens.Black, _
            x - GrabHandleHalfWidth, _
            y - GrabHandleHalfWidth, _
            GrabHandleWidth, _
            GrabHandleWidth)
    End Sub
End Module
