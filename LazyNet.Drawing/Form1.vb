Imports System.Drawing.Imaging

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents picCanvas As System.Windows.Forms.PictureBox
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileNew As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileExit As System.Windows.Forms.MenuItem
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents tbtnLine As System.Windows.Forms.ToolBarButton
    Friend WithEvents imlToolbarButtons As System.Windows.Forms.ImageList
    Friend WithEvents tbtnPointer As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbtnRectangle As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuFormat As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFormatOrder As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFormatOrderBringToFront As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFormatOrderSendToBack As System.Windows.Forms.MenuItem
    Friend WithEvents tbtnBringToFront As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbtnSendToBack As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEditDelete As System.Windows.Forms.MenuItem
    Friend WithEvents tbtnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbarSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tcboThickness As System.Windows.Forms.ToolBarButton
    Friend WithEvents ctxLineThickness As System.Windows.Forms.ContextMenu
    Friend WithEvents tbarSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuThick1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuThick2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuThick3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuThick4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuThick5 As System.Windows.Forms.MenuItem
    Friend WithEvents tcboLineColor As System.Windows.Forms.ToolBarButton
    Friend WithEvents tcboFillColor As System.Windows.Forms.ToolBarButton
    Friend WithEvents ctxLineColor As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuLineColorRed As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLineColorGreen As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLineColorBlue As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLineColorYellow As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLineColorOrange As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLineColorPurple As System.Windows.Forms.MenuItem
    Friend WithEvents ctxFillColor As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuFillColorRed As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFillColorGreen As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFillColorBlue As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFillColorYellow As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFillColorOrange As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFillColorPurple As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLineColorBlack As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLineColorWhite As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFillColorBlack As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFillColorWhite As System.Windows.Forms.MenuItem
    Friend WithEvents tbtnEllipse As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuFileSave As System.Windows.Forms.MenuItem
    Friend WithEvents dlgSavePicture As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mnuFileOpen As System.Windows.Forms.MenuItem
    Friend WithEvents dlgOpenPicture As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tbtnStar As System.Windows.Forms.ToolBarButton
    Friend WithEvents dlgBackColor As System.Windows.Forms.ColorDialog
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents pdPrint As System.Drawing.Printing.PrintDocument
    Friend WithEvents ppdPrint As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFilePrintPreview As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFilePrint As System.Windows.Forms.MenuItem
    Friend WithEvents tbtnImage As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuFileSaveImage As System.Windows.Forms.MenuItem
    Friend WithEvents ofdImage As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfdImage As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mnuOptSetBackColor As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.picCanvas = New System.Windows.Forms.PictureBox
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.mnuFileNew = New System.Windows.Forms.MenuItem
        Me.mnuFileOpen = New System.Windows.Forms.MenuItem
        Me.mnuFileSave = New System.Windows.Forms.MenuItem
        Me.mnuFileSaveImage = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuFilePrintPreview = New System.Windows.Forms.MenuItem
        Me.mnuFilePrint = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.mnuFileExit = New System.Windows.Forms.MenuItem
        Me.mnuEdit = New System.Windows.Forms.MenuItem
        Me.mnuEditDelete = New System.Windows.Forms.MenuItem
        Me.mnuFormat = New System.Windows.Forms.MenuItem
        Me.mnuFormatOrder = New System.Windows.Forms.MenuItem
        Me.mnuFormatOrderBringToFront = New System.Windows.Forms.MenuItem
        Me.mnuFormatOrderSendToBack = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.mnuOptSetBackColor = New System.Windows.Forms.MenuItem
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.tbtnPointer = New System.Windows.Forms.ToolBarButton
        Me.tbtnLine = New System.Windows.Forms.ToolBarButton
        Me.tbtnRectangle = New System.Windows.Forms.ToolBarButton
        Me.tbtnEllipse = New System.Windows.Forms.ToolBarButton
        Me.tbtnStar = New System.Windows.Forms.ToolBarButton
        Me.tbtnImage = New System.Windows.Forms.ToolBarButton
        Me.tbarSep1 = New System.Windows.Forms.ToolBarButton
        Me.tcboThickness = New System.Windows.Forms.ToolBarButton
        Me.ctxLineThickness = New System.Windows.Forms.ContextMenu
        Me.mnuThick1 = New System.Windows.Forms.MenuItem
        Me.mnuThick2 = New System.Windows.Forms.MenuItem
        Me.mnuThick3 = New System.Windows.Forms.MenuItem
        Me.mnuThick4 = New System.Windows.Forms.MenuItem
        Me.mnuThick5 = New System.Windows.Forms.MenuItem
        Me.tcboLineColor = New System.Windows.Forms.ToolBarButton
        Me.ctxLineColor = New System.Windows.Forms.ContextMenu
        Me.mnuLineColorRed = New System.Windows.Forms.MenuItem
        Me.mnuLineColorGreen = New System.Windows.Forms.MenuItem
        Me.mnuLineColorBlue = New System.Windows.Forms.MenuItem
        Me.mnuLineColorYellow = New System.Windows.Forms.MenuItem
        Me.mnuLineColorOrange = New System.Windows.Forms.MenuItem
        Me.mnuLineColorPurple = New System.Windows.Forms.MenuItem
        Me.mnuLineColorBlack = New System.Windows.Forms.MenuItem
        Me.mnuLineColorWhite = New System.Windows.Forms.MenuItem
        Me.tcboFillColor = New System.Windows.Forms.ToolBarButton
        Me.ctxFillColor = New System.Windows.Forms.ContextMenu
        Me.mnuFillColorRed = New System.Windows.Forms.MenuItem
        Me.mnuFillColorGreen = New System.Windows.Forms.MenuItem
        Me.mnuFillColorBlue = New System.Windows.Forms.MenuItem
        Me.mnuFillColorYellow = New System.Windows.Forms.MenuItem
        Me.mnuFillColorOrange = New System.Windows.Forms.MenuItem
        Me.mnuFillColorPurple = New System.Windows.Forms.MenuItem
        Me.mnuFillColorBlack = New System.Windows.Forms.MenuItem
        Me.mnuFillColorWhite = New System.Windows.Forms.MenuItem
        Me.tbarSep2 = New System.Windows.Forms.ToolBarButton
        Me.tbtnBringToFront = New System.Windows.Forms.ToolBarButton
        Me.tbtnSendToBack = New System.Windows.Forms.ToolBarButton
        Me.tbtnDelete = New System.Windows.Forms.ToolBarButton
        Me.imlToolbarButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.dlgSavePicture = New System.Windows.Forms.SaveFileDialog
        Me.dlgOpenPicture = New System.Windows.Forms.OpenFileDialog
        Me.dlgBackColor = New System.Windows.Forms.ColorDialog
        Me.pdPrint = New System.Drawing.Printing.PrintDocument
        Me.ppdPrint = New System.Windows.Forms.PrintPreviewDialog
        Me.ofdImage = New System.Windows.Forms.OpenFileDialog
        Me.sfdImage = New System.Windows.Forms.SaveFileDialog
        CType(Me.picCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picCanvas
        '
        Me.picCanvas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picCanvas.Location = New System.Drawing.Point(0, 28)
        Me.picCanvas.Name = "picCanvas"
        Me.picCanvas.Size = New System.Drawing.Size(416, 245)
        Me.picCanvas.TabIndex = 0
        Me.picCanvas.TabStop = False
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.mnuEdit, Me.mnuFormat, Me.MenuItem5})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFileNew, Me.mnuFileOpen, Me.mnuFileSave, Me.mnuFileSaveImage, Me.MenuItem2, Me.mnuFilePrintPreview, Me.mnuFilePrint, Me.MenuItem6, Me.mnuFileExit})
        Me.MenuItem1.Text = "&File"
        '
        'mnuFileNew
        '
        Me.mnuFileNew.Index = 0
        Me.mnuFileNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.mnuFileNew.Text = "&New"
        '
        'mnuFileOpen
        '
        Me.mnuFileOpen.Index = 1
        Me.mnuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.mnuFileOpen.Text = "&Open"
        '
        'mnuFileSave
        '
        Me.mnuFileSave.Index = 2
        Me.mnuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuFileSave.Text = "&Save"
        '
        'mnuFileSaveImage
        '
        Me.mnuFileSaveImage.Index = 3
        Me.mnuFileSaveImage.Text = "Save &Image..."
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 4
        Me.MenuItem2.Text = "-"
        '
        'mnuFilePrintPreview
        '
        Me.mnuFilePrintPreview.Index = 5
        Me.mnuFilePrintPreview.Text = "Print Preview..."
        '
        'mnuFilePrint
        '
        Me.mnuFilePrint.Index = 6
        Me.mnuFilePrint.Text = "Print..."
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 7
        Me.MenuItem6.Text = "-"
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Index = 8
        Me.mnuFileExit.Text = "E&xit"
        '
        'mnuEdit
        '
        Me.mnuEdit.Index = 1
        Me.mnuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEditDelete})
        Me.mnuEdit.Text = "&Edit"
        '
        'mnuEditDelete
        '
        Me.mnuEditDelete.Index = 0
        Me.mnuEditDelete.Shortcut = System.Windows.Forms.Shortcut.Del
        Me.mnuEditDelete.Text = "&Delete"
        '
        'mnuFormat
        '
        Me.mnuFormat.Index = 2
        Me.mnuFormat.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFormatOrder})
        Me.mnuFormat.Text = "F&ormat"
        '
        'mnuFormatOrder
        '
        Me.mnuFormatOrder.Index = 0
        Me.mnuFormatOrder.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFormatOrderBringToFront, Me.mnuFormatOrderSendToBack})
        Me.mnuFormatOrder.Text = "&Order"
        '
        'mnuFormatOrderBringToFront
        '
        Me.mnuFormatOrderBringToFront.Index = 0
        Me.mnuFormatOrderBringToFront.Text = "&Bring to Front"
        '
        'mnuFormatOrderSendToBack
        '
        Me.mnuFormatOrderSendToBack.Index = 1
        Me.mnuFormatOrderSendToBack.Text = "&Send to Back"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 3
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuOptSetBackColor})
        Me.MenuItem5.Text = "&Options"
        '
        'mnuOptSetBackColor
        '
        Me.mnuOptSetBackColor.Index = 0
        Me.mnuOptSetBackColor.Shortcut = System.Windows.Forms.Shortcut.F4
        Me.mnuOptSetBackColor.Text = "&Set Background Color"
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbtnPointer, Me.tbtnLine, Me.tbtnRectangle, Me.tbtnEllipse, Me.tbtnStar, Me.tbtnImage, Me.tbarSep1, Me.tcboThickness, Me.tcboLineColor, Me.tcboFillColor, Me.tbarSep2, Me.tbtnBringToFront, Me.tbtnSendToBack, Me.tbtnDelete})
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.imlToolbarButtons
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(416, 28)
        Me.ToolBar1.TabIndex = 1
        '
        'tbtnPointer
        '
        Me.tbtnPointer.ImageIndex = 0
        Me.tbtnPointer.Name = "tbtnPointer"
        Me.tbtnPointer.Pushed = True
        Me.tbtnPointer.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.tbtnPointer.ToolTipText = "Pointer"
        '
        'tbtnLine
        '
        Me.tbtnLine.ImageIndex = 1
        Me.tbtnLine.Name = "tbtnLine"
        Me.tbtnLine.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.tbtnLine.ToolTipText = "Line"
        '
        'tbtnRectangle
        '
        Me.tbtnRectangle.ImageIndex = 2
        Me.tbtnRectangle.Name = "tbtnRectangle"
        Me.tbtnRectangle.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.tbtnRectangle.ToolTipText = "Rectangle"
        '
        'tbtnEllipse
        '
        Me.tbtnEllipse.ImageIndex = 3
        Me.tbtnEllipse.Name = "tbtnEllipse"
        Me.tbtnEllipse.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.tbtnEllipse.ToolTipText = "Ellipse"
        '
        'tbtnStar
        '
        Me.tbtnStar.ImageIndex = 4
        Me.tbtnStar.Name = "tbtnStar"
        Me.tbtnStar.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.tbtnStar.ToolTipText = "Star"
        '
        'tbtnImage
        '
        Me.tbtnImage.ImageIndex = 8
        Me.tbtnImage.Name = "tbtnImage"
        Me.tbtnImage.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.tbtnImage.ToolTipText = "Image"
        '
        'tbarSep1
        '
        Me.tbarSep1.Name = "tbarSep1"
        Me.tbarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tcboThickness
        '
        Me.tcboThickness.DropDownMenu = Me.ctxLineThickness
        Me.tcboThickness.Name = "tcboThickness"
        Me.tcboThickness.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.tcboThickness.ToolTipText = "Line thickness"
        '
        'ctxLineThickness
        '
        Me.ctxLineThickness.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuThick1, Me.mnuThick2, Me.mnuThick3, Me.mnuThick4, Me.mnuThick5})
        '
        'mnuThick1
        '
        Me.mnuThick1.Index = 0
        Me.mnuThick1.Text = "1"
        '
        'mnuThick2
        '
        Me.mnuThick2.Index = 1
        Me.mnuThick2.Text = "2"
        '
        'mnuThick3
        '
        Me.mnuThick3.Index = 2
        Me.mnuThick3.Text = "3"
        '
        'mnuThick4
        '
        Me.mnuThick4.Index = 3
        Me.mnuThick4.Text = "4"
        '
        'mnuThick5
        '
        Me.mnuThick5.Index = 4
        Me.mnuThick5.Text = "5"
        '
        'tcboLineColor
        '
        Me.tcboLineColor.DropDownMenu = Me.ctxLineColor
        Me.tcboLineColor.Name = "tcboLineColor"
        Me.tcboLineColor.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.tcboLineColor.ToolTipText = "Line color"
        '
        'ctxLineColor
        '
        Me.ctxLineColor.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuLineColorRed, Me.mnuLineColorGreen, Me.mnuLineColorBlue, Me.mnuLineColorYellow, Me.mnuLineColorOrange, Me.mnuLineColorPurple, Me.mnuLineColorBlack, Me.mnuLineColorWhite})
        '
        'mnuLineColorRed
        '
        Me.mnuLineColorRed.Index = 0
        Me.mnuLineColorRed.Text = "Red"
        '
        'mnuLineColorGreen
        '
        Me.mnuLineColorGreen.Index = 1
        Me.mnuLineColorGreen.Text = "Green"
        '
        'mnuLineColorBlue
        '
        Me.mnuLineColorBlue.Index = 2
        Me.mnuLineColorBlue.Text = "Blue"
        '
        'mnuLineColorYellow
        '
        Me.mnuLineColorYellow.Index = 3
        Me.mnuLineColorYellow.Text = "Yellow"
        '
        'mnuLineColorOrange
        '
        Me.mnuLineColorOrange.Index = 4
        Me.mnuLineColorOrange.Text = "Orange"
        '
        'mnuLineColorPurple
        '
        Me.mnuLineColorPurple.Index = 5
        Me.mnuLineColorPurple.Text = "Purple"
        '
        'mnuLineColorBlack
        '
        Me.mnuLineColorBlack.Index = 6
        Me.mnuLineColorBlack.Text = "Black"
        '
        'mnuLineColorWhite
        '
        Me.mnuLineColorWhite.Index = 7
        Me.mnuLineColorWhite.Text = "White"
        '
        'tcboFillColor
        '
        Me.tcboFillColor.DropDownMenu = Me.ctxFillColor
        Me.tcboFillColor.Name = "tcboFillColor"
        Me.tcboFillColor.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.tcboFillColor.ToolTipText = "Fill color"
        '
        'ctxFillColor
        '
        Me.ctxFillColor.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFillColorRed, Me.mnuFillColorGreen, Me.mnuFillColorBlue, Me.mnuFillColorYellow, Me.mnuFillColorOrange, Me.mnuFillColorPurple, Me.mnuFillColorBlack, Me.mnuFillColorWhite})
        '
        'mnuFillColorRed
        '
        Me.mnuFillColorRed.Index = 0
        Me.mnuFillColorRed.Text = "Red"
        '
        'mnuFillColorGreen
        '
        Me.mnuFillColorGreen.Index = 1
        Me.mnuFillColorGreen.Text = "Green"
        '
        'mnuFillColorBlue
        '
        Me.mnuFillColorBlue.Index = 2
        Me.mnuFillColorBlue.Text = "Blue"
        '
        'mnuFillColorYellow
        '
        Me.mnuFillColorYellow.Index = 3
        Me.mnuFillColorYellow.Text = "Yellow"
        '
        'mnuFillColorOrange
        '
        Me.mnuFillColorOrange.Index = 4
        Me.mnuFillColorOrange.Text = "Orange"
        '
        'mnuFillColorPurple
        '
        Me.mnuFillColorPurple.Index = 5
        Me.mnuFillColorPurple.Text = "Purple"
        '
        'mnuFillColorBlack
        '
        Me.mnuFillColorBlack.Index = 6
        Me.mnuFillColorBlack.Text = "Black"
        '
        'mnuFillColorWhite
        '
        Me.mnuFillColorWhite.Index = 7
        Me.mnuFillColorWhite.Text = "White"
        '
        'tbarSep2
        '
        Me.tbarSep2.Name = "tbarSep2"
        Me.tbarSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbtnBringToFront
        '
        Me.tbtnBringToFront.ImageIndex = 5
        Me.tbtnBringToFront.Name = "tbtnBringToFront"
        Me.tbtnBringToFront.ToolTipText = "Bring To Front"
        '
        'tbtnSendToBack
        '
        Me.tbtnSendToBack.ImageIndex = 6
        Me.tbtnSendToBack.Name = "tbtnSendToBack"
        Me.tbtnSendToBack.ToolTipText = "Send To Back"
        '
        'tbtnDelete
        '
        Me.tbtnDelete.ImageIndex = 7
        Me.tbtnDelete.Name = "tbtnDelete"
        Me.tbtnDelete.ToolTipText = "Delete"
        '
        'imlToolbarButtons
        '
        Me.imlToolbarButtons.ImageStream = CType(resources.GetObject("imlToolbarButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlToolbarButtons.TransparentColor = System.Drawing.Color.Transparent
        Me.imlToolbarButtons.Images.SetKeyName(0, "")
        Me.imlToolbarButtons.Images.SetKeyName(1, "")
        Me.imlToolbarButtons.Images.SetKeyName(2, "")
        Me.imlToolbarButtons.Images.SetKeyName(3, "")
        Me.imlToolbarButtons.Images.SetKeyName(4, "")
        Me.imlToolbarButtons.Images.SetKeyName(5, "")
        Me.imlToolbarButtons.Images.SetKeyName(6, "")
        Me.imlToolbarButtons.Images.SetKeyName(7, "")
        Me.imlToolbarButtons.Images.SetKeyName(8, "tbtnImage.bmp")
        '
        'dlgSavePicture
        '
        Me.dlgSavePicture.Filter = "Picture Files (*.pic)|*.pic|All FIles (*.*)|*.*"
        '
        'dlgOpenPicture
        '
        Me.dlgOpenPicture.Filter = "Picture Files (*.pic)|*.pic|All FIles (*.*)|*.*"
        '
        'pdPrint
        '
        '
        'ppdPrint
        '
        Me.ppdPrint.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdPrint.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdPrint.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdPrint.Document = Me.pdPrint
        Me.ppdPrint.Enabled = True
        Me.ppdPrint.Icon = CType(resources.GetObject("ppdPrint.Icon"), System.Drawing.Icon)
        Me.ppdPrint.Name = "ppdPrint"
        Me.ppdPrint.Visible = False
        '
        'ofdImage
        '
        Me.ofdImage.FileName = "OpenFileDialog1"
        Me.ofdImage.Filter = "Graphics Files|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif;*.tiff|All Files|*.*"
        '
        'sfdImage
        '
        Me.sfdImage.Filter = "Graphics Files|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif;*.tiff|All Files|*.*"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 273)
        Me.Controls.Add(Me.picCanvas)
        Me.Controls.Add(Me.ToolBar1)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "DrawingFramework"
        CType(Me.picCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    ' Holds the picture we are drawing.
    Private m_Picture As New DrawablePicture(Me.BackColor)

    ' The current drawing attributes.
    Private m_CurrentLineWidth As Integer = 1
    Private m_CurrentForeColor As Color = Color.Black
    Private m_CurrentFillColor As Color = Color.White

    ' The object we are currently drawing.
    Private m_NewDrawable As Drawable

    ' The tool we have currently selected.
    Private m_SelectedToolButton As ToolBarButton

    ' The index of the first thickness image in its ImageList.
    Private m_FirstLineThicknessImage As Integer
    Private m_FirstLineColorImage As Integer
    Private m_FirstFillColorImage As Integer

#Region "Setup"
    ' Get ready.
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the initial directory for dialogs.
        Dim init_dir As String = Application.StartupPath
        If init_dir.EndsWith("\bin") Then init_dir = init_dir.Substring(0, init_dir.Length - 4)
        dlgSavePicture.InitialDirectory = init_dir
        dlgOpenPicture.InitialDirectory = init_dir

        ' Start with the Pointer tool selected.
        m_SelectedToolButton = tbtnPointer
        m_SelectedToolButton.Pushed = True

        ' Make line color images.
        MakeLineThicknessImages()

        ' Set line thickness menu event handlers.
        PrepareThicknessMenu(mnuThick1)
        PrepareThicknessMenu(mnuThick2)
        PrepareThicknessMenu(mnuThick3)
        PrepareThicknessMenu(mnuThick4)
        PrepareThicknessMenu(mnuThick5)
        mnuThick1.PerformClick()

        ' Make line color images.
        MakeLineColorImages()

        ' Set line color menu event handlers.
        PrepareLineColorMenu(mnuLineColorRed)
        PrepareLineColorMenu(mnuLineColorGreen)
        PrepareLineColorMenu(mnuLineColorBlue)
        PrepareLineColorMenu(mnuLineColorYellow)
        PrepareLineColorMenu(mnuLineColorOrange)
        PrepareLineColorMenu(mnuLineColorPurple)
        PrepareLineColorMenu(mnuLineColorBlack)
        PrepareLineColorMenu(mnuLineColorWhite)
        mnuLineColorBlack.PerformClick()

        ' Make fill color images.
        MakeFillColorImages()

        ' Set fill color menu event handlers.
        PrepareFillColorMenu(mnuFillColorRed)
        PrepareFillColorMenu(mnuFillColorGreen)
        PrepareFillColorMenu(mnuFillColorBlue)
        PrepareFillColorMenu(mnuFillColorYellow)
        PrepareFillColorMenu(mnuFillColorOrange)
        PrepareFillColorMenu(mnuFillColorPurple)
        PrepareFillColorMenu(mnuFillColorBlack)
        PrepareFillColorMenu(mnuFillColorWhite)
        mnuFillColorWhite.PerformClick()
    End Sub

    ' Make line thickness images.
    Private Sub MakeLineThicknessImages()
        Dim bm As New Bitmap(16, 16)
        Dim gr As Graphics = Graphics.FromImage(bm)

        m_FirstLineThicknessImage = imlToolbarButtons.Images.Count
        For i As Integer = 1 To 5
            gr.Clear(SystemColors.Control)
            gr.DrawLine(New Pen(Color.Black, i), 0, 8, 16, 8)
            imlToolbarButtons.Images.Add(bm)
        Next i
    End Sub

    ' Add Click, MeasureItem, and DrawItem event handlers
    ' to this MenuItem.
    Private Sub PrepareThicknessMenu(ByVal menu_item As MenuItem)
        AddHandler menu_item.Click, AddressOf mnuLineThick_Click
        AddHandler menu_item.MeasureItem, AddressOf mnuLineThick_MeasureItem
        AddHandler menu_item.DrawItem, AddressOf mnuLineThick_DrawItem
        menu_item.OwnerDraw = True
    End Sub

    ' Make line color images.
    Private Sub MakeLineColorImages()
        Dim colors() As Color = { _
            Color.Red, Color.Green, Color.Blue, _
            Color.Yellow, Color.Orange, Color.Purple, _
            Color.Black, Color.White}
        Dim bm As New Bitmap(16, 16)
        Dim gr As Graphics = Graphics.FromImage(bm)

        m_FirstLineColorImage = imlToolbarButtons.Images.Count
        For Each clr As Color In colors
            gr.Clear(SystemColors.Control)
            gr.DrawLine(New Pen(clr, 4), 0, 8, 16, 8)
            imlToolbarButtons.Images.Add(bm)
        Next clr
    End Sub

    ' Add Click, MeasureItem, and DrawItem event handlers
    ' to this MenuItem.
    Private Sub PrepareLineColorMenu(ByVal menu_item As MenuItem)
        AddHandler menu_item.Click, AddressOf mnuLineColor_Click
        AddHandler menu_item.MeasureItem, AddressOf mnuLineColor_MeasureItem
        AddHandler menu_item.DrawItem, AddressOf mnuLineColor_DrawItem
        menu_item.OwnerDraw = True
    End Sub

    ' Make flll color images.
    Private Sub MakeFillColorImages()
        Dim colors() As Color = { _
            Color.Red, Color.Green, Color.Blue, _
            Color.Yellow, Color.Orange, Color.Purple, _
            Color.Black, Color.White}
        Dim bm As New Bitmap(16, 16)
        Dim gr As Graphics = Graphics.FromImage(bm)

        m_FirstFillColorImage = imlToolbarButtons.Images.Count
        For Each clr As Color In colors
            gr.Clear(clr)
            imlToolbarButtons.Images.Add(bm)
        Next clr
    End Sub

    ' Add Click, MeasureItem, and DrawItem event handlers
    ' to this MenuItem.
    Private Sub PrepareFillColorMenu(ByVal menu_item As MenuItem)
        AddHandler menu_item.Click, AddressOf mnuFillColor_Click
        AddHandler menu_item.MeasureItem, AddressOf mnuFillColor_MeasureItem
        AddHandler menu_item.DrawItem, AddressOf mnuFillColor_DrawItem
        menu_item.OwnerDraw = True
    End Sub
#End Region
    ' Setup
    ' Redraw.
    Private Sub picCanvas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picCanvas.Paint
        m_Picture.Draw(e.Graphics)
    End Sub

    ' Start a new picture.
    Private Sub mnuFileNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNew.Click
        ' See if the data is safe.
        '...

        ' Start the new picture.
        m_Picture = New DrawablePicture(Me.BackColor)
        m_Picture.Draw(picCanvas.CreateGraphics())
    End Sub

    ' Exit.
    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        ' See if the data is safe.
        '...

        Me.Close()
    End Sub

    ' Save the drawing.
    Private Sub mnuFileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileSave.Click
        ' Let the user select the file to save into.
        If dlgSavePicture.ShowDialog() = DialogResult.OK Then
            m_Picture.SavePicture(dlgSavePicture.FileName)
            dlgOpenPicture.InitialDirectory = dlgSavePicture.FileName
        End If
    End Sub

    ' Load a drawing.
    Private Sub mnuFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click
        ' Let the user select the file to load.
        If dlgOpenPicture.ShowDialog() = DialogResult.OK Then
            ' Load the picture.
            Dim new_picture As DrawablePicture = _
                DrawablePicture.LoadPicture(dlgOpenPicture.FileName)

            ' If we succeeded, display the new picture.
            If Not (new_picture Is Nothing) Then
                m_Picture = new_picture
                picCanvas.Invalidate()
            End If
            dlgSavePicture.InitialDirectory = dlgOpenPicture.FileName
        End If
    End Sub

    ' Bring the selected object to the front.
    Private Sub mnuFormatOrderBringToFront_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFormatOrderBringToFront.Click
        m_Picture.BringToFront(m_Picture.SelectedDrawable)
        picCanvas.Invalidate()
    End Sub

    ' Set the picture's BackColor.
    Private Sub mnuOptSetBackColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptSetBackColor.Click
        If dlgBackColor.ShowDialog() = DialogResult.OK Then
            m_Picture.BackColor = dlgBackColor.Color
            picCanvas.Invalidate()
        End If
    End Sub

    ' Send the selected object to the back.
    Private Sub mnuFormatOrderSendToBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFormatOrderSendToBack.Click
        m_Picture.SendToBack(m_Picture.SelectedDrawable)
        picCanvas.Invalidate()
    End Sub

    ' Delete the selected object.
    Private Sub mnuEditDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditDelete.Click
        m_Picture.Delete(m_Picture.SelectedDrawable)
        picCanvas.Invalidate()
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        ' See what kind of button this is.
        If e.Button.Style = ToolBarButtonStyle.ToggleButton Then
            ' ToggleButton.
            If (m_SelectedToolButton Is e.Button) Then
                e.Button.Pushed = True
            Else
                ' Pop the previously selected button up.
                m_SelectedToolButton.Pushed = False

                ' Save a reference to the selected tool.
                m_SelectedToolButton = e.Button
            End If

            ' Deselect any selected Drawable.
            If Not (m_Picture.SelectedDrawable Is Nothing) Then
                m_Picture.SelectedDrawable = Nothing
                picCanvas.Invalidate()
            End If
        ElseIf e.Button.Style = ToolBarButtonStyle.PushButton Then
            ' PushButton.
            Select Case e.Button.ToolTipText
                Case "Bring To Front"
                    m_Picture.BringToFront(m_Picture.SelectedDrawable)
                    picCanvas.Invalidate()
                Case "Send To Back"
                    m_Picture.SendToBack(m_Picture.SelectedDrawable)
                    picCanvas.Invalidate()
                Case "Delete"
                    m_Picture.Delete(m_Picture.SelectedDrawable)
                    picCanvas.Invalidate()
            End Select
        End If
    End Sub

#Region "New object event handlers"
    ' Perform an action depending on the currently pushed tool.
    Private Sub picCanvas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCanvas.MouseDown
        ' See which button was pressed.
        If e.Button = MouseButtons.Right Then
            ' Right button. See if we're drawing something.
            If m_NewDrawable Is Nothing Then
                ' We are not drawing. Ignore this button.
            Else
                ' We are drawing something. Cancel it.
                m_Picture.Remove(m_NewDrawable)

                m_NewDrawable = Nothing
                RemoveHandler picCanvas.MouseMove, AddressOf NewDrawable_MouseMove
                RemoveHandler picCanvas.MouseUp, AddressOf NewDrawable_MouseUp

                ' Redraw to erase the new object.
                picCanvas.Invalidate()
            End If
        Else
            ' Left button. See which tool is pushed.
            Select Case m_SelectedToolButton.ToolTipText
                Case "Pointer"
                    ' Select an object.
                    m_Picture.SelectObjectAt(e.X, e.Y)
                Case "Line"
                    ' Start drawing a line.
                    m_NewDrawable = New DrawableLine(m_CurrentForeColor, m_CurrentLineWidth, e.X, e.Y, e.X, e.Y)
                    m_Picture.Add(m_NewDrawable)
                    AddHandler picCanvas.MouseMove, AddressOf NewDrawable_MouseMove
                    AddHandler picCanvas.MouseUp, AddressOf NewDrawable_MouseUp
                Case "Rectangle"
                    ' Start drawing a rectangle.
                    m_NewDrawable = New DrawableRectangle(m_CurrentForeColor, m_CurrentFillColor, m_CurrentLineWidth, e.X, e.Y, e.X, e.Y)
                    m_Picture.Add(m_NewDrawable)
                    AddHandler picCanvas.MouseMove, AddressOf NewDrawable_MouseMove
                    AddHandler picCanvas.MouseUp, AddressOf NewDrawable_MouseUp
                Case "Ellipse"
                    ' Start drawing an ellipse.
                    m_NewDrawable = New DrawableEllipse(m_CurrentForeColor, m_CurrentFillColor, m_CurrentLineWidth, e.X, e.Y, e.X, e.Y)
                    m_Picture.Add(m_NewDrawable)
                    AddHandler picCanvas.MouseMove, AddressOf NewDrawable_MouseMove
                    AddHandler picCanvas.MouseUp, AddressOf NewDrawable_MouseUp
                Case "Star"
                    ' Start drawing a star.
                    m_NewDrawable = New DrawableStar(m_CurrentForeColor, m_CurrentFillColor, m_CurrentLineWidth, e.X, e.Y, e.X, e.Y)
                    m_Picture.Add(m_NewDrawable)
                    AddHandler picCanvas.MouseMove, AddressOf NewDrawable_MouseMove
                    AddHandler picCanvas.MouseUp, AddressOf NewDrawable_MouseUp
                Case "Image"
                    ' Start drawing an image.
                    m_NewDrawable = New DrawableImage(e.X, e.Y, e.X, e.Y)
                    m_Picture.Add(m_NewDrawable)
                    AddHandler picCanvas.MouseMove, AddressOf NewDrawable_MouseMove
                    AddHandler picCanvas.MouseUp, AddressOf NewDrawable_MouseUp
            End Select

            ' Redraw.
            picCanvas.Invalidate()
        End If
    End Sub

    ' If we have an object selected, move it.
    Private Sub picCanvas_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCanvas.MouseMove
        ' Only move if the left button is down.
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' Move it.
            m_Picture.MoveSelectedDrawableToMouse(e.X, e.Y)

            ' Redraw to show the new position.
            picCanvas.Invalidate()
        End If
    End Sub

    ' On mouse move, continue drawing.
    Private Sub NewDrawable_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        ' Update the new line's coordinates.
        m_NewDrawable.NewPoint(e.X, e.Y)

        ' Redraw to show the new line.
        picCanvas.Invalidate()
    End Sub

    ' On mouse up, finish drawing the new object.
    Private Sub NewDrawable_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        ' No longer watch for MouseMove or MouseUp.
        RemoveHandler picCanvas.MouseMove, AddressOf NewDrawable_MouseMove
        RemoveHandler picCanvas.MouseUp, AddressOf NewDrawable_MouseUp

        ' See if the new object is empty (e.g. a zero-length line).
        If m_NewDrawable.IsEmpty() Then
            ' Discard this object.
            m_Picture.Remove(m_NewDrawable)
        Else
            ' If it's a new image, get the image file.
            If TypeOf (m_NewDrawable) Is DrawableImage Then
                If ofdImage.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ' Discard this object.
                    Dim drawable_image As DrawableImage = DirectCast(m_NewDrawable, DrawableImage)
                    drawable_image.Picture = New Bitmap(ofdImage.FileName)
                Else
                    ' Discard this object.
                    m_Picture.Remove(m_NewDrawable)
                End If
            End If
        End If

        ' We're no longer working with the new object.
        m_NewDrawable = Nothing

        ' Redraw.
        picCanvas.Invalidate()
    End Sub
#End Region ' New object event handlers

#Region "Line Thickness Menu Routines"
    ' The user has selected a new line thickness.
    Private Sub mnuLineThick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Update the current pen.
        Dim menu_item As MenuItem = DirectCast(sender, MenuItem)
        m_CurrentLineWidth = Integer.Parse(menu_item.Text)

        ' Update the toolbar display.
        tcboThickness.ImageIndex = m_CurrentLineWidth + _
            m_FirstLineThicknessImage - 1

        ' Update the selected object if there is one.
        If Not (m_Picture.SelectedDrawable Is Nothing) Then
            m_Picture.SelectedDrawable.LineWidth = m_CurrentLineWidth
            picCanvas.Invalidate()
        End If

        ' Reselect the currently selected tool.
        m_SelectedToolButton.Pushed = True
    End Sub

    ' Allow room for the MenuItem.
    Private Sub mnuLineThick_MeasureItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs)
        e.ItemWidth = 16
        e.ItemHeight = 16
    End Sub

    ' Draw the menu item.
    Private Sub mnuLineThick_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Dim menu_item As MenuItem = DirectCast(sender, MenuItem)
        Dim thickness As Integer = Integer.Parse(menu_item.Text)

        ' See if we're selected.
        Dim fg_pen As Pen
        Dim bg_brush As Brush
        If (e.State And DrawItemState.Selected) = 0 Then
            ' Not selected.
            ' Use a light background and dark foreground.
            fg_pen = New Pen(SystemColors.MenuText, thickness)
            bg_brush = New SolidBrush(SystemColors.Menu)
        Else
            ' Selected.
            ' Use a dark background and light foreground.
            fg_pen = New Pen(SystemColors.HighlightText, thickness)
            bg_brush = New SolidBrush(SystemColors.Highlight)
        End If

        ' Erase the background.
        e.Graphics.FillRectangle(bg_brush, e.Bounds)

        ' Draw the line.
        Dim y As Integer = e.Bounds.Y + e.Bounds.Height \ 2
        e.Graphics.DrawLine(fg_pen, e.Bounds.X, y, e.Bounds.Right, y)

        fg_pen.Dispose()
        bg_brush.Dispose()
    End Sub
#End Region ' Line Thickness Menu Routines

#Region "Line Color Menu Routines"
    ' The user has selected a new line color.
    Private Sub mnuLineColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Update the current pen.
        Dim menu_item As MenuItem = DirectCast(sender, MenuItem)
        m_CurrentForeColor = Color.FromName(menu_item.Text)

        ' Update the toolbar display.
        Select Case menu_item.Text
            Case "Red"
                tcboLineColor.ImageIndex = m_FirstLineColorImage + 0
            Case "Green"
                tcboLineColor.ImageIndex = m_FirstLineColorImage + 1
            Case "Blue"
                tcboLineColor.ImageIndex = m_FirstLineColorImage + 2
            Case "Yellow"
                tcboLineColor.ImageIndex = m_FirstLineColorImage + 3
            Case "Orange"
                tcboLineColor.ImageIndex = m_FirstLineColorImage + 4
            Case "Purple"
                tcboLineColor.ImageIndex = m_FirstLineColorImage + 5
            Case "Black"
                tcboLineColor.ImageIndex = m_FirstLineColorImage + 6
            Case "White"
                tcboLineColor.ImageIndex = m_FirstLineColorImage + 7
        End Select

        ' Update the selected object if there is one.
        If Not (m_Picture.SelectedDrawable Is Nothing) Then
            m_Picture.SelectedDrawable.ForeColor = m_CurrentForeColor
            picCanvas.Invalidate()
        End If

        ' Reselect the currently selected tool.
        m_SelectedToolButton.Pushed = True
    End Sub

    ' Allow room for the MenuItem.
    Private Sub mnuLineColor_MeasureItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs)
        e.ItemWidth = 16
        e.ItemHeight = 16
    End Sub

    ' Draw the menu item.
    Private Sub mnuLineColor_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Dim menu_item As MenuItem = DirectCast(sender, MenuItem)
        Dim new_color As Color = Color.FromName(menu_item.Text)

        ' See if we're selected.
        Dim bg_brush As Brush
        If (e.State And DrawItemState.Selected) = 0 Then
            ' Not selected.
            ' Use a light background.
            bg_brush = New SolidBrush(SystemColors.Menu)
        Else
            ' Selected.
            ' Use a dark background.
            bg_brush = New SolidBrush(SystemColors.Highlight)
        End If

        ' Erase the background.
        e.Graphics.FillRectangle(bg_brush, e.Bounds)

        ' Draw the line.
        Dim y As Integer = e.Bounds.Y + e.Bounds.Height \ 2
        Dim fg_pen As New Pen(new_color, 4)
        e.Graphics.DrawLine(fg_pen, e.Bounds.X, y, e.Bounds.Right, y)
        fg_pen.Dispose()
    End Sub
#End Region ' Line Color Menu Routines

#Region "Fill Color Menu Routines"
    ' The user has selected a new line color.
    Private Sub mnuFillColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Update the current pen.
        Dim menu_item As MenuItem = DirectCast(sender, MenuItem)
        m_CurrentFillColor = Color.FromName(menu_item.Text)

        ' Update the toolbar display.
        Select Case menu_item.Text
            Case "Red"
                tcboFillColor.ImageIndex = m_FirstFillColorImage + 0
            Case "Green"
                tcboFillColor.ImageIndex = m_FirstFillColorImage + 1
            Case "Blue"
                tcboFillColor.ImageIndex = m_FirstFillColorImage + 2
            Case "Yellow"
                tcboFillColor.ImageIndex = m_FirstFillColorImage + 3
            Case "Orange"
                tcboFillColor.ImageIndex = m_FirstFillColorImage + 4
            Case "Purple"
                tcboFillColor.ImageIndex = m_FirstFillColorImage + 5
            Case "Black"
                tcboFillColor.ImageIndex = m_FirstFillColorImage + 6
            Case "White"
                tcboFillColor.ImageIndex = m_FirstFillColorImage + 7
        End Select

        ' Update the selected object if there is one.
        If Not (m_Picture.SelectedDrawable Is Nothing) Then
            m_Picture.SelectedDrawable.FillColor = m_CurrentFillColor
            picCanvas.Invalidate()
        End If

        ' Reselect the currently selected tool.
        m_SelectedToolButton.Pushed = True
    End Sub

    ' Allow room for the MenuItem.
    Private Sub mnuFillColor_MeasureItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs)
        e.ItemWidth = 16
        e.ItemHeight = 16
    End Sub

    ' Draw the menu item.
    Private Sub mnuFillColor_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Dim menu_item As MenuItem = DirectCast(sender, MenuItem)
        Dim new_color As Color = Color.FromName(menu_item.Text)

        ' See if we're selected.
        Dim bg_brush As Brush
        If (e.State And DrawItemState.Selected) = 0 Then
            ' Not selected.
            ' Use a light background.
            bg_brush = New SolidBrush(SystemColors.Menu)
        Else
            ' Selected.
            ' Use a dark background.
            bg_brush = New SolidBrush(SystemColors.Highlight)
        End If

        ' Erase the background.
        e.Graphics.FillRectangle(bg_brush, e.Bounds)

        ' Draw a filled area.
        Dim fg_brush As New SolidBrush(new_color)
        e.Graphics.FillRectangle(fg_brush, _
            e.Bounds.X + 2, _
            e.Bounds.Y + 2, _
            e.Bounds.Width - 4, _
            e.Bounds.Height - 4)
        fg_brush.Dispose()
    End Sub
#End Region ' Fill Color Menu Routines

    ' Display the print preview dialog.
    ' Note that ppdPreview.Document = pdPrint was set in the form designer.
    Private Sub mnuFilePrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilePrintPreview.Click
        ppdPrint.ShowDialog()
    End Sub

    ' Print.
    ' Note: PRINT_ENLARGED cannot be True unless PRINT_CENTERED is also.
    ' Note: If PRINT_CENTERED is False, the picture is drawn
    ' in the upper left corner where it will be chopped because
    ' the printer cannot print all the way to the edges of the paper.
    Private Sub pdPrint_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdPrint.PrintPage
#Const PRINT_CENTERED = True
#Const PRINT_ENLARGED = True
        '#Const PRINT_MARGIN = True

#If PRINT_CENTERED Then ' Center the picture.
        ' Get the picture's bounds.
        Dim bounds As Rectangle = m_Picture.GetBounds()

        ' Translate the drawing to the origin.
        e.Graphics.TranslateTransform(-bounds.X, -bounds.Y)

        Dim scale As Single = 1

#If PRINT_ENLARGED Then ' Scale to fit.
        Dim xscale As Double = 1
        If bounds.Width > 0 Then xscale = e.MarginBounds.Width / bounds.Width
        Dim yscale As Double = 1
        If bounds.Height > 0 Then yscale = e.MarginBounds.Height / bounds.Height

        If xscale > yscale Then
            scale = CSng(yscale)
        Else
            scale = CSng(xscale)
        End If
        e.Graphics.ScaleTransform(scale, scale, Drawing2D.MatrixOrder.Append)
#End If

        ' Translate to center the drawing.
        Dim cx As Integer = CInt((e.MarginBounds.Width - bounds.Width * scale) / 2)
        Dim cy As Integer = CInt((e.MarginBounds.Height - bounds.Height * scale) / 2)
        e.Graphics.TranslateTransform( _
            e.MarginBounds.X + cx, _
            e.MarginBounds.Y + cy, _
            Drawing2D.MatrixOrder.Append)
#End If

        ' Draw the picture.
        m_Picture.Draw(e.Graphics)

#If PRINT_MARGIN Then
        ' Draw the margin.
        e.Graphics.ResetTransform()
        Using margin_pen As New Pen(Color.Red)
            margin_pen.DashPattern = New Single() {5, 5}
            e.Graphics.DrawRectangle(margin_pen, e.MarginBounds)
        End Using
#End If
    End Sub

    ' Print.
    Private Sub mnuFilePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilePrint.Click
        pdPrint.Print()
    End Sub

    ' Enable or disable the Edit menu commands.
    Private Sub mnuEdit_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit.Popup
        mnuEditDelete.Enabled = m_Picture.SelectedDrawable IsNot Nothing
    End Sub

    ' Enable or disable the Format menu commands.
    Private Sub mnuFormat_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat.Popup
        mnuFormatOrder.Enabled = m_Picture.SelectedDrawable IsNot Nothing
    End Sub

    ' Save the picture as an image.
    Private Sub mnuFileSaveImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileSaveImage.Click
        If sfdImage.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Draw the picture into a Bitmap.
            Dim rect As Rectangle = m_Picture.GetBounds()
            Dim bm As New Bitmap(rect.Width, rect.Height)
            Using gr As Graphics = Graphics.FromImage(bm)
                m_Picture.Draw(gr)
            End Using

            ' Save the Bitmap.
            Dim filename As String = sfdImage.FileName
            Dim ext As String = filename.Substring(filename.LastIndexOf("."))
            ext = ext.ToLower()
            Select Case (ext)
                Case ".bmp"
                    bm.Save(filename, ImageFormat.Bmp)
                Case ".gif"
                    bm.Save(filename, ImageFormat.Gif)
                Case ".jpg", ".jpeg"
                    bm.Save(filename, ImageFormat.Jpeg)
                Case ".png"
                    bm.Save(filename, ImageFormat.Png)
                Case ".tif", ".tiff"
                    bm.Save(filename, ImageFormat.Tiff)
                Case Else
                    MessageBox.Show("Unknown file extension '" & ext & "'", _
                        "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select
        End If
    End Sub
End Class
