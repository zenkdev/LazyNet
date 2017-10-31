Imports System.Xml.Serialization
Imports System.Xml
Imports System.IO
Imports System.Collections.Generic

<Serializable()> _
Public Class DrawablePicture
    ' The list where we will store objects.
    <XmlElement(GetType(Drawable)), _
     XmlElement(GetType(DrawableLine)), _
     XmlElement(GetType(DrawableRectangle)), _
     XmlElement(GetType(DrawableEllipse)), _
     XmlElement(GetType(DrawableStar)), _
     XmlElement(GetType(DrawableImage))> _
    Public Drawables As New List(Of Drawable)

    ' The background color.
    <XmlIgnore()> Public BackColor As Color = SystemColors.Control
    ' Property procedures to serialize and
    ' deserialize BackColor.
    <XmlAttributeAttribute("BackColor")> _
    Public Property BackColorArgb() As Integer
        Get
            Return BackColor.ToArgb()
        End Get
        Set(ByVal Value As Integer)
            BackColor = Color.FromArgb(Value)
        End Set
    End Property

    ' Constructors.
    Public Sub New()
    End Sub
    Public Sub New(ByVal background_color As Color)
        BackColor = background_color
    End Sub

    ' The currently selected object. A more elaborate
    ' application might use a selection list and make
    ' this a collection.
    Private m_SelectedDrawable As Drawable
    ' Initial mouse position when the object was selected.
    Private m_SelectedMouseX As Integer
    Private m_SelectedMouseY As Integer
    Public Property SelectedDrawable() As Drawable
        Get
            Return m_SelectedDrawable
        End Get
        Set(ByVal Value As Drawable)
            ' Mark the currently selected object
            ' as not selected.
            If Not (m_SelectedDrawable Is Nothing) Then
                m_SelectedDrawable.IsSelected = False
            End If

            ' Select the new object.
            m_SelectedDrawable = Value
            If Not (m_SelectedDrawable Is Nothing) Then
                m_SelectedDrawable.IsSelected = True
            End If
        End Set
    End Property

    ' Add a new Drawable object to the list.
    Public Sub Add(ByVal new_drawable As Drawable)
        Drawables.Add(new_drawable)
    End Sub

    ' Remove this object from the list.
    Public Sub Remove(ByVal target As Drawable)
        Drawables.Remove(target)
    End Sub

    ' Select the Drawable at this point. Highlight it
    ' and return it.
    Public Function SelectObjectAt(ByVal x As Integer, ByVal y As Integer) As Drawable
        ' Deselect the previously selected object.
        SelectedDrawable = Nothing

        ' Find the object at this point (if any).
        ' Search the list backwards so we find objects
        ' at the top of the stack first.
        For i As Integer = Drawables.Count - 1 To 0 Step -1
            Dim dr As Drawable = DirectCast(Drawables(i), Drawable)
            If dr.IsAt(x, y) Then
                SelectedDrawable = dr
                m_SelectedMouseX = x
                m_SelectedMouseY = y
                Exit For
            End If
        Next i

        ' Return the selected object.
        Return SelectedDrawable
    End Function

    ' Draw all the objects.
    Public Sub Draw(ByVal gr As Graphics)
        ' Clear the background.
        gr.Clear(BackColor)
        gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Draw the objects.
        For Each dr As Drawable In Drawables
            dr.Draw(gr)
        Next dr
    End Sub

    ' Move the selected drawable. The mouse has moved from
    ' (m_SelectedMouseX, m_SelectedMouseY) to (x, y).
    Public Sub MoveSelectedDrawableToMouse(ByVal x As Integer, ByVal y As Integer)
        ' Do nothing if nothing is selected.
        If SelectedDrawable Is Nothing Then Exit Sub

        ' See how far we want it moved.
        Dim new_dx As Integer = x - m_SelectedMouseX
        Dim new_dy As Integer = y - m_SelectedMouseY

        ' Move it.
        SelectedDrawable.MoveRelative(new_dx, new_dy)

        ' Save the new mouse position.
        m_SelectedMouseX = x
        m_SelectedMouseY = y
    End Sub

    ' Send the object to the back of the stack.
    Public Sub SendToBack(ByVal dr As Drawable)
        If Not (dr Is Nothing) Then
            Drawables.Remove(dr)
            Drawables.Insert(0, dr)
        End If
    End Sub

    ' Bring the object to the front of the stack.
    Public Sub BringToFront(ByVal dr As Drawable)
        If Not (dr Is Nothing) Then
            Drawables.Remove(dr)
            Drawables.Insert(Drawables.Count, dr)
        End If
    End Sub

    ' Delete the object.
    Public Sub Delete(ByVal dr As Drawable)
        If Not (dr Is Nothing) Then
            Drawables.Remove(dr)
        End If
    End Sub

    ' Save the picture into the file.
    Public Sub SavePicture(ByVal file_name As String)
        Try
            Dim xml_serializer As New XmlSerializer(GetType(DrawablePicture))
            Dim stream_writer As New StreamWriter(file_name)
            xml_serializer.Serialize(stream_writer, Me)
            stream_writer.Close()
        Catch ex As Exception
            If MessageBox.Show(ex.Message & vbCrLf & _
                "Show internal error?", "Save Error", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                MessageBox.Show(ex.InnerException.ToString, "Internal Error", _
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Try
    End Sub

    ' Laod the picture from the file.
    Public Shared Function LoadPicture(ByVal file_name As String) As DrawablePicture
        Try
            Dim xml_serializer As New XmlSerializer(GetType(DrawablePicture))
            Dim file_stream As New FileStream(file_name, FileMode.Open)
            Dim new_picture As DrawablePicture = _
                DirectCast(xml_serializer.Deserialize(file_stream), DrawablePicture)
            file_stream.Close()
            Return new_picture
        Catch ex As Exception
            If MessageBox.Show(ex.Message & vbCrLf & _
                "Show internal error?", "Save Error", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                MessageBox.Show(ex.InnerException.ToString, "Internal Error", _
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Return Nothing
        End Try
    End Function

    ' Return the bounds of all drawable objects.
    Public Function GetBounds() As Rectangle
        If Drawables.Count < 1 Then Return (New Rectangle(0, 0, 0, 0))

        Dim result As Rectangle = Drawables(0).GetBounds()

        For Each dr As Drawable In Drawables
            result = Rectangle.Union(result, dr.GetBounds())
        Next dr

        Return result
    End Function
End Class
