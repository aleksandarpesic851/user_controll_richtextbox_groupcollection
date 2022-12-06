Imports System.Diagnostics.Metrics
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net.Http
Imports System.Text

Public Class MetroRichtextboxControl
    Private subSuperScript As Boolean = False
    Private originalFontSize As Integer = 0
    Private mRtfToHtml As New RTFtoHTML()
    Private mTableSizeDlg As Form

    Private mBorderColor As Color = Color.Black
    Private mBorderThickness As Integer = 1
    Private mBorderRadius As Integer = 0
    Private mResizable As Boolean = True

    Public Property BorderColor As Color
        Get
            Return mBorderColor
        End Get
        Set(value As Color)
            mBorderColor = value
        End Set
    End Property
    Public Property ToolbarColor As Color
        Get
            Return ToolStrip1.BackColor
        End Get
        Set(value As Color)
            ToolStrip1.BackColor = value
        End Set
    End Property
    Public Property BorderThickness As Integer
        Get
            Return mBorderThickness
        End Get
        Set(value As Integer)
            mBorderThickness = value
            Me.Padding = New Padding(value)
        End Set
    End Property
    Public Property BorderRadius As Integer
        Get
            Return mBorderRadius
        End Get
        Set(value As Integer)
            mBorderRadius = value
        End Set
    End Property
    Public Property Resizable As Boolean
        Get
            Return mResizable
        End Get
        Set(value As Boolean)
            mResizable = value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.DoubleBuffered = True
        ' Add any initialization after the InitializeComponent() call.
        Me.BorderStyle = BorderStyle.None
        If mResizable Then
            Dim rc As New ResizeableControl(Me)
        End If
    End Sub

    Private Sub MyPaint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        'Me.BorderStyle = BorderStyle.None
        Dim rect As Rectangle = Me.ClientRectangle 'Drawing Rounded Rectangle
        Using graphPath As GraphicsPath = GetPath(rect, BorderRadius)
            Using br As Brush = New SolidBrush(BorderColor)
                e.Graphics.FillPath(br, graphPath)
            End Using
        End Using
    End Sub

    'Returns the GraphicsPath to Draw a RoundedRectangle
    Protected Function GetPath(ByVal rc As Rectangle, ByVal r As Int32) As GraphicsPath
        Dim x As Int32 = rc.X, y As Int32 = rc.Y, w As Int32 = rc.Width, h As Int32 = rc.Height
        r = r << 1
        Dim path As GraphicsPath = New GraphicsPath()
        If r > 0 Then
            If (r > h) Then r = h
            If (r > w) Then r = w
            path.AddArc(x, y, r, r, 180, 90)
            path.AddArc(x + w - r, y, r, r, 270, 90)
            path.AddArc(x + w - r, y + h - r, r, r, 0, 90)
            path.AddArc(x, y + h - r, r, r, 90, 90)
            path.CloseFigure()
        Else
            path.AddRectangle(rc)
        End If
        Return path
    End Function

#Region "Resizable Control"
    Public Class ResizeableControl

        Private WithEvents mControl As Control
        Private mMouseDown As Boolean = False
        Private mEdge As EdgeEnum = EdgeEnum.None
        Private mWidth As Integer = 4
        Private mOutlineDrawn As Boolean = False

        Private Enum EdgeEnum
            None
            Right
            Left
            Top
            Bottom
            TopLeft
        End Enum

        Public Sub New(ByVal Control As Control)
            mControl = Control
        End Sub

        Private Sub mControl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseDown
            If e.Button = Windows.Forms.MouseButtons.Left Then
                mMouseDown = True
            End If
        End Sub

        Private Sub mControl_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseUp
            mMouseDown = False
        End Sub

        Private Sub mControl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseMove
            Dim c As Control = CType(sender, Control)
            Dim g As Graphics = c.CreateGraphics
            Select Case mEdge
                Case EdgeEnum.TopLeft
                    'g.FillRectangle(Brushes.GreenYellow, 0, 0, mWidth * 4, mWidth * 4)
                    mOutlineDrawn = True
                Case EdgeEnum.Left
                    'g.FillRectangle(Brushes.GreenYellow, 0, 0, mWidth, c.Height)
                    mOutlineDrawn = True
                Case EdgeEnum.Right
                    'g.FillRectangle(Brushes.GreenYellow, c.Width - mWidth, 0, c.Width, c.Height)
                    mOutlineDrawn = True
                Case EdgeEnum.Top
                    'g.FillRectangle(Brushes.GreenYellow, 0, 0, c.Width, mWidth)
                    mOutlineDrawn = True
                Case EdgeEnum.Bottom
                    'g.FillRectangle(Brushes.GreenYellow, 0, c.Height - mWidth, c.Width, mWidth)
                    mOutlineDrawn = True
                Case EdgeEnum.None
                    If mOutlineDrawn Then
                        c.Refresh()
                        mOutlineDrawn = False
                    End If
            End Select

            If mMouseDown And mEdge <> EdgeEnum.None Then
                'c.SuspendLayout()
                Select Case mEdge
                    Case EdgeEnum.TopLeft
                        c.SetBounds(c.Left + e.X, c.Top + e.Y, c.Width, c.Height)
                    Case EdgeEnum.Left
                        c.SetBounds(c.Left + e.X, c.Top, c.Width - e.X, c.Height)
                    Case EdgeEnum.Right
                        c.SetBounds(c.Left, c.Top, c.Width - (c.Width - e.X), c.Height)
                    Case EdgeEnum.Top
                        c.SetBounds(c.Left, c.Top + e.Y, c.Width, c.Height - e.Y)
                    Case EdgeEnum.Bottom
                        c.SetBounds(c.Left, c.Top, c.Width, c.Height - (c.Height - e.Y))
                End Select
                'c.ResumeLayout()
                c.Refresh()
            Else
                Select Case True
                    Case e.X <= (mWidth * 4) And e.Y <= (mWidth * 4) 'top left corner
                        c.Cursor = Cursors.SizeAll
                        mEdge = EdgeEnum.TopLeft
                    Case e.X <= mWidth 'left edge
                        c.Cursor = Cursors.VSplit
                        mEdge = EdgeEnum.Left
                    Case e.X > c.Width - (mWidth + 1) 'right edge
                        c.Cursor = Cursors.VSplit
                        mEdge = EdgeEnum.Right
                    Case e.Y <= mWidth 'top edge
                        c.Cursor = Cursors.HSplit
                        mEdge = EdgeEnum.Top
                    Case e.Y > c.Height - (mWidth + 1) 'bottom edge
                        c.Cursor = Cursors.HSplit
                        mEdge = EdgeEnum.Bottom
                    Case Else 'no edge
                        c.Cursor = Cursors.Default
                        mEdge = EdgeEnum.None
                End Select
            End If
        End Sub

        Private Sub mControl_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mControl.MouseLeave
            Dim c As Control = CType(sender, Control)
            mEdge = EdgeEnum.None
            c.Refresh()
        End Sub

    End Class

#End Region

#Region "Tool Event Proc"
    Private Sub ToolStripButton_Cut_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Cut.Click
        rtbEditor.Cut()
    End Sub

    Private Sub ToolStripButton_Copy_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Copy.Click
        rtbEditor.Copy()
    End Sub

    Private Sub ToolStripButton_Paste_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Paste.Click
        rtbEditor.Paste()
    End Sub

    Private Sub ToolStripButton_Undo_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Undo.Click
        rtbEditor.Undo()
    End Sub

    Private Sub ToolStripButton_Redo_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Redo.Click
        rtbEditor.Redo()
    End Sub

    Private Sub ToolStripButton_Font_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Font.Click
        Dim Font As New FontDialog()
        Font.Font = rtbEditor.SelectionFont
        If Font.ShowDialog(Me) = DialogResult.OK Then
            Try
                rtbEditor.SelectionFont = Font.Font
            Catch ex As Exception
                ' Do nothing on Exception
            End Try
        End If
    End Sub

    Private Sub ToolStripButton_Color_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Color.Click
        Dim Colour As New ColorDialog()
        Colour.Color = rtbEditor.SelectionColor
        If Colour.ShowDialog(Me) = DialogResult.OK Then
            Try
                rtbEditor.SelectionColor = Colour.Color
            Catch ex As Exception
                ' Do nothing on Exception
            End Try
        End If
    End Sub

    Private Sub ToolStripButton_BG_Color_Click(sender As Object, e As EventArgs) Handles ToolStripButton_BG_Color.Click
        Dim Colour As New ColorDialog()
        Colour.Color = rtbEditor.SelectionBackColor
        If Colour.ShowDialog(Me) = DialogResult.OK Then
            Try
                rtbEditor.SelectionBackColor = Colour.Color
            Catch ex As Exception
                ' Do nothing on Exception
            End Try
        End If
    End Sub

    Private Sub ToolStripButton_Bold_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Bold.Click
        If rtbEditor.SelectionFont.Bold Then
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style And Not FontStyle.Bold)
        Else
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style Or FontStyle.Bold)
        End If
        ToolStripButton_Bold.Checked = rtbEditor.SelectionFont.Bold
    End Sub

    Private Sub ToolStripButton_Italic_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Italic.Click
        If rtbEditor.SelectionFont.Italic Then
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style And Not FontStyle.Italic)
        Else
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style Or FontStyle.Italic)
        End If
        ToolStripButton_Italic.Checked = rtbEditor.SelectionFont.Italic
    End Sub

    Private Sub ToolStripButton_Underline_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Underline.Click
        If rtbEditor.SelectionFont.Underline Then
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style And Not FontStyle.Underline)
        Else
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style Or FontStyle.Underline)
        End If
        ToolStripButton_Underline.Checked = rtbEditor.SelectionFont.Underline
    End Sub

    Private Sub ToolStripButton_Strike_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Strike.Click
        If rtbEditor.SelectionFont.Strikeout Then
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style And Not FontStyle.Strikeout)
        Else
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style Or FontStyle.Strikeout)
        End If
        ToolStripButton_Strike.Checked = rtbEditor.SelectionFont.Strikeout
    End Sub

    Private Sub ToolStripButton_Subscript_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Subscript.Click
        If (subSuperScript.Equals(False)) Then
            subSuperScript = True
            If IsNothing(rtbEditor.SelectionFont) Then
                originalFontSize = 12
            Else
                originalFontSize = rtbEditor.SelectionFont.SizeInPoints
            End If
        End If
        rtbEditor.SelectionCharOffset = -originalFontSize / 2

        Dim fontFamily As FontFamily
        If IsNothing(rtbEditor.SelectionFont) Then
            fontFamily = New FontFamily("Segoe UI")
        Else
            fontFamily = rtbEditor.SelectionFont.FontFamily
        End If

        rtbEditor.SelectionFont = New Font(fontFamily, originalFontSize / 2)
        ToolStripButton_Subscript.Checked = True
        ToolStripButton_Superscript.Checked = False
        ToolStripButton_Normal.Checked = False
    End Sub

    Private Sub ToolStripButton_Superscript_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Superscript.Click
        If (subSuperScript.Equals(False)) Then
            subSuperScript = True
            If IsNothing(rtbEditor.SelectionFont) Then
                originalFontSize = 12
            Else
                originalFontSize = rtbEditor.SelectionFont.SizeInPoints
            End If
        End If
        rtbEditor.SelectionCharOffset = originalFontSize / 2

        Dim fontFamily As FontFamily
        If IsNothing(rtbEditor.SelectionFont) Then
            fontFamily = New FontFamily("Segoe UI")
        Else
            fontFamily = rtbEditor.SelectionFont.FontFamily
        End If

        rtbEditor.SelectionFont = New Font(fontFamily, originalFontSize / 2)
        ToolStripButton_Subscript.Checked = False
        ToolStripButton_Superscript.Checked = True
        ToolStripButton_Normal.Checked = False
    End Sub

    Private Sub ToolStripButton_Normal_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Normal.Click
        If (subSuperScript) Then
            subSuperScript = False
        Else
            subSuperScript = True
            Return
        End If

        Dim fontFamily As FontFamily
        If IsNothing(rtbEditor.SelectionFont) Then
            fontFamily = New FontFamily("Segoe UI")
        Else
            fontFamily = rtbEditor.SelectionFont.FontFamily
        End If

        rtbEditor.SelectionCharOffset = 0
        rtbEditor.SelectionFont = New Font(fontFamily, originalFontSize)
        ToolStripButton_Subscript.Checked = False
        ToolStripButton_Superscript.Checked = False
        ToolStripButton_Normal.Checked = True
    End Sub

    Private Sub ToolStripButton_LeftAlign_Click(sender As Object, e As EventArgs) Handles ToolStripButton_LeftAlign.Click
        rtbEditor.SelectionAlignment = HorizontalAlignment.Left
        ToolStripButton_LeftAlign.Checked = True
        ToolStripButton_CenterAlign.Checked = False
        ToolStripButton_RightAlign.Checked = False
    End Sub

    Private Sub ToolStripButton_CenterAlign_Click(sender As Object, e As EventArgs) Handles ToolStripButton_CenterAlign.Click
        rtbEditor.SelectionAlignment = HorizontalAlignment.Center
        ToolStripButton_LeftAlign.Checked = False
        ToolStripButton_CenterAlign.Checked = True
        ToolStripButton_RightAlign.Checked = False
    End Sub

    Private Sub ToolStripButton_RightAlign_Click(sender As Object, e As EventArgs) Handles ToolStripButton_RightAlign.Click
        rtbEditor.SelectionAlignment = HorizontalAlignment.Right
        ToolStripButton_LeftAlign.Checked = False
        ToolStripButton_CenterAlign.Checked = False
        ToolStripButton_RightAlign.Checked = True
    End Sub

    Private Sub ToolStripButton_Bullet_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Bullet.Click
        rtbEditor.SelectionBullet = Not rtbEditor.SelectionBullet
        ToolStripButton_Bullet.Checked = rtbEditor.SelectionBullet
    End Sub


    Private Sub ToolStripButton_Picture_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Picture.Click
        With OpenFileDialogForPicture
            .InitialDirectory = "C:\"
            .Filter = "Image Files|*.jpg;*.gif;*.png;*.bmp"
            .FilterIndex = 1
        End With
        If OpenFileDialogForPicture.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim img As Image
            img = Image.FromFile(OpenFileDialogForPicture.FileName)
            Clipboard.SetImage(img)
            rtbEditor.Paste()
        End If
    End Sub

    Private Sub ToolStripButton_Table_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Table.Click
        If IsNothing(mTableSizeDlg) Then
            createTableSizeDlg()
        End If
        mTableSizeDlg.Show()
    End Sub

    Private Sub createTableSizeDlg()
        mTableSizeDlg = New Form
        With mTableSizeDlg
            .Text = "Insert Cols and Rows"
            .Size = New Size(350, 140)
        End With

        Dim ColsLabel As New Label
        With ColsLabel
            .Text = "Cols:"
            .Size = New Size(40, 20)
            .Location = New Point(20, 20)
        End With
        mTableSizeDlg.Controls.Add(ColsLabel)

        Dim ColsTextbox As New TextBox
        With ColsTextbox
            .Name = "Cols"
            .Text = "5"
            .Size = New Size(80, 20)
            .Location = New Point(70, 20)
        End With
        mTableSizeDlg.Controls.Add(ColsTextbox)

        Dim RowsLabel As New Label
        With RowsLabel
            .Text = "Rows:"
            .Size = New Size(40, 20)
            .Location = New Point(180, 20)
        End With
        mTableSizeDlg.Controls.Add(RowsLabel)

        Dim RowsTextbox As New TextBox
        With RowsTextbox
            .Name = "Rows"
            .Text = "5"
            .Size = New Size(80, 20)
            .Location = New Point(230, 20)
        End With
        mTableSizeDlg.Controls.Add(RowsTextbox)

        Dim ConfrimButton As New Button
        With ConfrimButton
            .Text = "Create"
            .Size = New Size(100, 30)
            .Location = New Point(125, 60)
        End With
        mTableSizeDlg.Controls.Add(ConfrimButton)
        AddHandler ConfrimButton.Click, AddressOf CreateTable_Clicked
    End Sub
    Private Sub CreateTable_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cols As Integer = 0, rows As Integer = 0
        For Each ctrl As Control In mTableSizeDlg.Controls
            Select Case ctrl.Name
                Case "Cols"
                    Integer.TryParse(ctrl.Text, cols)
                Case "Rows"
                    Integer.TryParse(ctrl.Text, rows)
            End Select
        Next
        If cols < 1 Or rows < 1 Then
            MessageBox.Show("Please insert positive integer.")
            Return
        End If
        InsertTable(rows, cols)
        mTableSizeDlg.Hide()
    End Sub

    Private Sub rtbEditor_DragEnter(ByVal sender As Object, ByVal e As _
    System.Windows.Forms.DragEventArgs) Handles rtbEditor.DragEnter
        ' Check the format of the data being dropped.
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub rtbEditor_DragDrop(ByVal sender As Object, ByVal e As _
        System.Windows.Forms.DragEventArgs) Handles rtbEditor.DragDrop
        Dim dropImages As String() = e.Data.GetData(DataFormats.FileDrop, False)
        Dim img As Image
        Dim extension As String

        For Each imagePath As String In dropImages
            extension = Path.GetExtension(imagePath).ToLower()
            If extension <> ".jpg" And extension <> ".png" And extension <> ".bmp" And extension <> ".gif" And extension <> ".ico" Then
                Continue For
            End If

            img = Image.FromFile(imagePath)
            Clipboard.SetImage(img)
            rtbEditor.Paste()
        Next
    End Sub

    Private Sub ToolStripButton_Open_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Open.Click
        Dim openFileDlg As New OpenFileDialog()

        ' Initialize the OpenFileDialog to look for RTF files.
        openFileDlg.DefaultExt = "*.rtf"
        openFileDlg.Filter = "RTF Files|*.rtf"

        ' Determine whether the user selected a file from the OpenFileDialog.
        If (openFileDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) _
            And (openFileDlg.FileName.Length > 0) Then

            ' Load the contents of the file into the RichTextBox.
            rtbEditor.LoadFile(openFileDlg.FileName)
        End If
    End Sub

    Private Sub ToolStripButton_Binary_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Binary.Click
        Dim Save As New SaveFileDialog()
        Save.Filter = "Rich Text Document (*.rtf)|*.rtf"
        Save.CheckPathExists = True
        If Save.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Try
                rtbEditor.SaveFile(Save.FileName)
                Me.Text = Save.FileName
            Catch ex As Exception
                ' Do nothing on Exception
            End Try
        End If
    End Sub

    Private Sub ToolStripButton_Html_Click(sender As Object, e As EventArgs) Handles ToolStripButton_HTML.Click
        Dim Save As New SaveFileDialog()
        Dim filePath As String
        Save.Filter = "Html (*.html)|*.html"
        Save.CheckPathExists = True
        If Save.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Try
                filePath = Save.FileName
                If Not System.IO.File.Exists(filePath) = True Then
                    Dim file As System.IO.FileStream
                    file = System.IO.File.Create(filePath)
                    file.Close()
                End If
                mRtfToHtml.rtf = rtbEditor.Rtf
                Dim contentHtml As String = mRtfToHtml.html
                My.Computer.FileSystem.WriteAllText(filePath, contentHtml, False, Encoding.UTF8)
            Catch ex As Exception
                ' Do nothing on Exception
            End Try
        End If
    End Sub
#End Region

#Region "Manage Table"
    Public Sub InsertTable(ByVal vRows As Integer, ByVal vCols As Integer)
        Dim i As Integer, j As Integer
        Dim sbTaRtf As New System.Text.StringBuilder
        Dim cellWidth As Integer = Me.ClientSize.Width * 15 / vCols
        sbTaRtf.Append("{\rtf1")
        For i = 1 To vRows
            sbTaRtf.Append("\trowd")
            For j = 1 To vCols
                sbTaRtf.Append("\cellx" & j * cellWidth)
            Next
            sbTaRtf.Append("\intbl \cell \row")
        Next
        sbTaRtf.Append("\pard")
        sbTaRtf.Append("}")
        rtbEditor.SelectedRtf = sbTaRtf.ToString()
    End Sub


#End Region

End Class

Public Class RTFtoHTML

#Region "Private Members"

    ' A RichTextBox control to use to help with parsing.
    Private _rtfSource As New System.Windows.Forms.RichTextBox

#End Region

#Region "Read/Write Properties"

    ''' <summary>
    ''' Returns/Sets The RTF formatted text to parse
    ''' </summary>
    Public Property rtf() As String
        Get
            Return _rtfSource.Rtf
        End Get
        Set(ByVal value As String)
            _rtfSource.Rtf = value
        End Set
    End Property

#End Region

#Region "ReadOnly Properties"

    ''' <summary>
    ''' Returns the HTML code for the provided RTF
    ''' </summary>
    Public ReadOnly Property html() As String
        Get
            Return GetHtml()
        End Get
    End Property

#End Region

#Region "Private Functions"

    ''' <summary>
    ''' Returns an HTML Formated Color string for the style from a system.drawing.color
    ''' </summary>
    ''' <param name="clr">The color you wish to convert</param>
    Private Function HtmlColorFromColor(ByRef clr As System.Drawing.Color) As String
        Dim strReturn As String = ""
        If clr.IsNamedColor Then
            strReturn = clr.Name.ToLower
        Else
            strReturn = clr.Name
            If strReturn.Length > 6 Then
                strReturn = strReturn.Substring(strReturn.Length - 6, 6)
            End If
            strReturn = "#" & strReturn
        End If
        Return strReturn
    End Function

    ''' <summary>
    ''' Provides the font style per given font
    ''' </summary>
    ''' <param name="fnt">The font you wish to convert</param>
    Private Function HtmlFontStyleFromFont(ByRef fnt As System.Drawing.Font) As String
        Dim strReturn As String = ""
        'style
        If fnt.Italic Then
            strReturn &= "italic "
        Else
            strReturn &= "normal "
        End If
        'variant
        strReturn &= "normal "
        'weight
        If fnt.Bold Then
            strReturn &= "bold "
        Else
            strReturn &= "normal "
        End If
        'size
        strReturn &= fnt.SizeInPoints & "pt/normal "
        'family
        strReturn &= fnt.FontFamily.Name
        Return strReturn
    End Function

    ''' <summary>
    ''' Parses the given rich text and returns the html.
    ''' </summary>
    Private Function GetHtml() As String
        Dim strReturn As String = "<div>"
        Dim clrForeColor As System.Drawing.Color = Color.Black
        Dim clrBackColor As System.Drawing.Color = Color.Black
        Dim fntCurrentFont As System.Drawing.Font = _rtfSource.Font
        Dim altCurrent As System.Windows.Forms.HorizontalAlignment = HorizontalAlignment.Left
        Dim intPos As Integer = 0
        For intPos = 0 To _rtfSource.Text.Length - 1
            _rtfSource.Select(intPos, 1)
            'Forecolor
            If intPos = 0 Then
                strReturn &= "<span style=""color:" & HtmlColorFromColor(_rtfSource.SelectionColor) & """>"
                clrForeColor = _rtfSource.SelectionColor
            Else
                If _rtfSource.SelectionColor <> clrForeColor Then
                    strReturn &= "</span>"
                    strReturn &= "<span style=""color:" & HtmlColorFromColor(_rtfSource.SelectionColor) & """>"
                    clrForeColor = _rtfSource.SelectionColor
                End If
            End If
            'Background color
            If intPos = 0 Then
                strReturn &= "<span style=""background-color:" & HtmlColorFromColor(_rtfSource.SelectionBackColor) & """>"
                clrBackColor = _rtfSource.SelectionBackColor
            Else
                If _rtfSource.SelectionBackColor <> clrBackColor Then
                    strReturn &= "</span>"
                    strReturn &= "<span style=""background-color:" & HtmlColorFromColor(_rtfSource.SelectionBackColor) & """>"
                    clrBackColor = _rtfSource.SelectionBackColor
                End If
            End If
            'Font
            If intPos = 0 Then
                strReturn &= "<span style=""font:" & HtmlFontStyleFromFont(_rtfSource.SelectionFont) & """>"
                fntCurrentFont = _rtfSource.SelectionFont
            Else
                If _rtfSource.SelectionFont.GetHashCode <> fntCurrentFont.GetHashCode Then
                    strReturn &= "</span>"
                    strReturn &= "<span style=""font:" & HtmlFontStyleFromFont(_rtfSource.SelectionFont) & """>"
                    fntCurrentFont = _rtfSource.SelectionFont
                End If
            End If
            'Alignment
            If intPos = 0 Then
                strReturn &= "<p style=""text-align:" & _rtfSource.SelectionAlignment.ToString & """>"
                altCurrent = _rtfSource.SelectionAlignment
            Else
                If _rtfSource.SelectionAlignment <> altCurrent Then
                    strReturn &= "</p>"
                    strReturn &= "<p style=""text-align:" & _rtfSource.SelectionAlignment.ToString & """>"
                    altCurrent = _rtfSource.SelectionAlignment
                End If
            End If
            strReturn &= _rtfSource.Text.Substring(intPos, 1)
        Next
        'close all the spans
        strReturn &= "</span>"
        strReturn &= "</span>"
        strReturn &= "</span>"
        strReturn &= "</p>"
        strReturn &= "</div>"
        strReturn = strReturn.Replace(Convert.ToChar(10), "<br />")
        Return strReturn
    End Function

#End Region

End Class

'#Region "RTF-HTML"
'Public Class RTF2HTML
'    ' =======================================================================
'    ' = Define constants that are need to build the outline RTF file format =
'    ' =======================================================================

'    ' Define Start and End strings for RTF Formatting
'    Const RTF_START = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033"
'    Const RTF_END = "}"
'    ' Define Start and End strings for FONT tables
'    Const FONT_TABLE_START = "{\fonttbl"
'    Const FONT_TABLE_END = "}"
'    ' Define Start and End strings for COLOR tables (Next version maybe)
'    'Const COLOR_TABLE_START = "{\colortbl "
'    'Const COLOR_TABLE_END = ";}"
'    ' Define End Paragraph constant
'    Const LINE_BREAK = "\par" & vbCrLf
'    ' Define Indent constant - No HTML equivalent ;-)
'    'Const RTF_TAB = "\tab "
'    ' Define New Paragraph constant
'    Const NEW_PARAGRAPH = "\pard"
'    ' Define Bold constants, as unlikely that you are only enboldening one character
'    Const BOLD_START = "\b "
'    Const BOLD_END = "\b0 "
'    ' Define Underline constants
'    Const UNDERLINE_START = "\ul "
'    Const UNDERLINE_END = "\ul0 "
'    ' Define Italic constants
'    Const ITALIC_START = "\i "
'    Const ITALIC_END = "\i0 "
'    ' Define View and charset
'    Const DOCUMENT_START = "\viewkind4\uc1"
'    ' ======================================================
'    ' = RenderHTML                                         =
'    ' =                                                    =
'    ' = Input : HTML encoded string (Content of body only) =
'    ' =                                                    =
'    ' = Output : RTF encoded string                        =
'    ' =                                                    = 
'    ' ======================================================
'    Private Sub RenderHTML(ByVal strInput As String) As String
'        Dim intPos As Integer
'        Dim strText As String

'        ' Create initial header strings for the RTF format - Set font to Arial
'        strText = RTF_START + FONT_TABLE_START + "{\f0\fnil\fcharset0 Arial;}" + FONT_TABLE_END + vbCrLf
'        ' Add view and charset
'        strText += DOCUMENT_START
'        ' Start the document
'        strText += NEW_PARAGRAPH
'        ' Set the font to Arial 11 and Justify the text
'        strText += "\sa200\sl276\slmult1\qj\f0\fs22\lang9 "

'        ' Start Processing the HTML string
'        Do
'            ' Check for < in HTML string
'            If Mid(strInput, 1, 1) = "<" Then
'                ' Look for different tags and move input to next element in HTML
'                If Mid(strInput, 1, 3) = "<p>" Or Mid(strInput, 1, 3) = "<P>" Then
'                    strInput = Mid(strInput, 4)
'                ElseIf Mid(strInput, 1, 4) = "</p>" Or Mid(strInput, 1, 3) = "</P>" Then
'                    strText += LINE_BREAK
'                    strInput = Mid(strInput, 5)
'                ElseIf Mid(strInput, 1, 3) = "<b>" Or Mid(strInput, 1, 3) = "<B>" Then
'                    strText += BOLD_START
'                    strInput = Mid(strInput, 4)
'                ElseIf Mid(strInput, 1, 4) = "</b>" Or Mid(strInput, 1, 3) = "</B>" Then
'                    strText += BOLD_END
'                    strInput = Mid(strInput, 5)
'                ElseIf Mid(strInput, 1, 3) = "<i>" Or Mid(strInput, 1, 3) = "<I>" Then
'                    strText += ITALIC_START
'                    strInput = Mid(strInput, 4)
'                ElseIf Mid(strInput, 1, 4) = "</i>" Or Mid(strInput, 1, 3) = "</I>" Then
'                    strText += ITALIC_END
'                    strInput = Mid(strInput, 5)
'                ElseIf Mid(strInput, 1, 8) = "<strong>" Or Mid(strInput, 1, 8) = "<STRONG>" Then
'                    strText += BOLD_START
'                    strInput = Mid(strInput, 9)
'                ElseIf Mid(strInput, 1, 9) = "</strong>" Or Mid(strInput, 1, 9) = "</STRONG>" Then
'                    strText += BOLD_END
'                    strInput = Mid(strInput, 10)
'                ElseIf Mid(strInput, 1, 4) = "<em>" Or Mid(strInput, 1, 4) = "<EM>" Then
'                    strText += ITALIC_START
'                    strInput = Mid(strInput, 5)
'                ElseIf Mid(strInput, 1, 5) = "</em>" Or Mid(strInput, 1, 5) = "</EM>" Then
'                    strText += ITALIC_END
'                    strInput = Mid(strInput, 6)
'                ElseIf Mid(strInput, 1, 3) = "<u>" Or Mid(strInput, 1, 3) = "<U>" Then
'                    strText += UNDERLINE_START
'                    strInput = Mid(strInput, 4)
'                ElseIf Mid(strInput, 1, 4) = "</u>" Or Mid(strInput, 1, 3) = "</U>" Then
'                    strText += UNDERLINE_END
'                    strInput = Mid(strInput, 5)
'                Else
'                    ' ============================================================================
'                    ' = Catch all remaining HTML and show on the browser the unsupported element = 
'                    ' ============================================================================
'                    intPos = InStr(strInput, ">")
'                    HttpContext.Current.Response.Write("UNSUPPORTED : " + Mid(strInput, 1, intPos) + "<br/>")
'                    strInput = Mid(strInput, intPos + 1)
'                End If
'            Else
'                ' Check for & in the HTML input and replace
'                If Mid(strInput, 1, 1) = "&" Then
'                    If Mid(strInput, 1, 6) = "&nbsp;" Then
'                        strText += " "
'                        strInput = Mid(strInput, 7)
'                    ElseIf Mid(strInput, 1, 5) = "&amp;" Then
'                        strText += "&"
'                        strInput = Mid(strInput, 6)
'                    ElseIf Mid(strInput, 1, 4) = "&lt;" Then
'                        strText += "<"
'                        strInput = Mid(strInput, 5)
'                    ElseIf Mid(strInput, 1, 4) = "&gt;" Then
'                        strText += ">"
'                        strInput = Mid(strInput, 5)
'                    ElseIf Mid(strInput, 1, 6) = "&copy;" Then
'                        strText += "\'a9"
'                        strInput = Mid(strInput, 7)
'                    ElseIf Mid(strInput, 1, 5) = "&reg;" Then
'                        strText += "\'ae"
'                        strInput = Mid(strInput, 6)
'                    ElseIf Mid(strInput, 1, 7) = "&trade;" Then
'                        strText += "\'99"
'                        strInput = Mid(strInput, 8)
'                    ElseIf Mid(strInput, 1, 7) = "&pound;" Then
'                        strText += "£"
'                        strInput = Mid(strInput, 8)
'                    ElseIf Mid(strInput, 1, 6) = "&euro;" Then
'                        strText += "\'80"
'                        strInput = Mid(strInput, 7)
'                    ElseIf Mid(strInput, 1, 2) = "&#" Then
'                        ' Handle &# 
'                        If CType(Mid(strInput, 3, InStr(strInput, ";") - 1), Integer) <= 127 Then
'                            strText += Chr(CType(Mid(strInput, 3, InStr(strInput, ";") - 1), Integer))
'                        ElseIf CType(Mid(strInput, 3, InStr(strInput, ";") - 1), Integer) <= 255 Then
'                            strText += "\'" + Hex(CType(Mid(strInput, 3, InStr(strInput, ";") - 1), Integer))
'                        Else
'                            strText += "\u" + Hex(CType(Mid(strInput, 3, InStr(strInput, ";") - 1), Integer))
'                        End If
'                        strInput = Mid(strInput, 3, InStr(strInput, ";") + 1)
'                    Else
'                        ' ============================================================================
'                        ' = Catch all remaining HTML and show on the browser the unsupported element = 
'                        ' ============================================================================
'                        intPos = InStr(strInput, ";")

'                        HttpContext.Current.Response.Write("UNSUPPORTED : " + Mid(strInput, 1, intPos) + "<br/>")
'                        strInput = Mid(strInput, intPos + 1)
'                    End If
'                Else
'                    strText += Mid(strInput, 1, 1)
'                    strInput = Mid(strInput, 2)
'                End If
'            End If
'        Loop Until strInput = ""
'        strText += RTF_END
'        Return strText
'    End Sub
'End Class
'#End Region