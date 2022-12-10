Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Class MetroRichtextbox
    Private subSuperScript As Boolean = False
    Private originalFontSize As Integer = 0
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
        InitializeComponent()
        Me.DoubleBuffered = True
        Me.BorderStyle = BorderStyle.None
        If mResizable Then
            Dim rc As New ResizeableControl(Me)
        End If
    End Sub

    Private Sub MyPaint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        'Me.BorderStyle = BorderStyle.None
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect As Rectangle = Me.ClientRectangle 'Drawing Rounded Rectangle
        Using graphPath As GraphicsPath = GetPath(rect, BorderRadius)
            Using br As Brush = New SolidBrush(BorderColor)
                e.Graphics.FillPath(br, graphPath)
            End Using
        End Using
    End Sub

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
    End Sub

    Private Sub ToolStripButton_Italic_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Italic.Click
        If rtbEditor.SelectionFont.Italic Then
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style And Not FontStyle.Italic)
        Else
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style Or FontStyle.Italic)
        End If
    End Sub

    Private Sub ToolStripButton_Underline_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Underline.Click
        If rtbEditor.SelectionFont.Underline Then
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style And Not FontStyle.Underline)
        Else
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style Or FontStyle.Underline)
        End If
    End Sub

    Private Sub ToolStripButton_Strike_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Strike.Click
        If rtbEditor.SelectionFont.Strikeout Then
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style And Not FontStyle.Strikeout)
        Else
            rtbEditor.SelectionFont = New Font(rtbEditor.SelectionFont,
                                               rtbEditor.SelectionFont.Style Or FontStyle.Strikeout)
        End If
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
    End Sub

    Private Sub ToolStripButton_LeftAlign_Click(sender As Object, e As EventArgs) Handles ToolStripButton_LeftAlign.Click
        rtbEditor.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub ToolStripButton_CenterAlign_Click(sender As Object, e As EventArgs) Handles ToolStripButton_CenterAlign.Click
        rtbEditor.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub ToolStripButton_RightAlign_Click(sender As Object, e As EventArgs) Handles ToolStripButton_RightAlign.Click
        rtbEditor.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub ToolStripButton_Bullet_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Bullet.Click
        rtbEditor.SelectionBullet = Not rtbEditor.SelectionBullet
    End Sub

    Private Sub ToolStripButton_List_Click(sender As Object, e As EventArgs) Handles ToolStripButton_List.Click
        If rtbEditor.SelectedRtf.Contains("\pntext") Then
            NumberedListToNormal()
        Else
            NormalToNumberedList()
        End If
    End Sub

    Private Sub NumberedListToNormal()
        Const RTF_START As String = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Calibri;}}" &
                            "{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\f0\fs18 "
        Const RTF_ITEM_END As String = "\par"
        Const RTF_END As String = "}"

        Dim old_text As String =
            rtbEditor.SelectedText.Replace(vbCrLf, vbLf)
        Dim lines() As String = Split(old_text, vbLf)

        ' Start the list.
        Dim new_text As String = RTF_START

        ' Add the other lines.
        For i As Integer = 0 To lines.Length - 1
            new_text &=
                lines(i) & RTF_ITEM_END & vbCrLf
        Next i

        ' Remove the final vbCrLf.
        new_text = new_text.Substring(0, new_text.Length - vbCrLf.Length)

        ' End the list.
        new_text &= RTF_END

        ' Save the result.
        rtbEditor.SelectedRtf = new_text
    End Sub

    Private Sub NormalToNumberedList()
        Const RTF_START As String = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Calibri;}}" &
                            "{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard{\pntext\f0 1.\tab}{\*\pn\pnlvlbody\pnf0\pnindent0\pnstart1\pndec{\pntxta.}}" &
                            "\fi-360\li720\sa200\sl276\slmult1\lang9\f0\fs22 "
        Const RTF_NUM_ITEM As String = "{\pntext\f0 @%@.\tab}"
        Const RTF_NUM_ITEM_END As String = "\par"
        Const RTF_END As String = "}"

        Dim old_text As String =
            rtbEditor.SelectedText.Replace(vbCrLf, vbLf)
        Dim lines() As String = Split(old_text, vbLf)

        ' Start the list.
        Dim new_text As String = RTF_START & lines(0) & RTF_NUM_ITEM_END & vbCrLf

        ' Add the other lines.
        For i As Integer = 1 To lines.Length - 1
            new_text &=
                RTF_NUM_ITEM.Replace("@%@", (i + 1).ToString()) &
                lines(i) & RTF_NUM_ITEM_END & vbCrLf
        Next i

        ' Remove the final vbCrLf.
        new_text = new_text.Substring(0, new_text.Length - vbCrLf.Length)

        ' End the list.
        new_text &= RTF_END

        ' Save the result.
        rtbEditor.SelectedRtf = new_text
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

        openFileDlg.DefaultExt = "*.dat"
        openFileDlg.Filter = "Binary Data Files|*.dat"

        If (openFileDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) _
            And (openFileDlg.FileName.Length > 0) Then
            Dim contentData As Byte() = File.ReadAllBytes(openFileDlg.FileName)
            rtbEditor.Rtf = System.Text.Encoding.Default.GetString(contentData)
        End If

    End Sub

    Private Sub ToolStripButton_Binary_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Binary.Click
        Dim Save As New SaveFileDialog()
        Save.Filter = "Binary Data File (*.dat)|*.dat"
        Save.CheckPathExists = True
        If Save.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Try
                Dim contentData As Byte() = System.Text.Encoding.Default.GetBytes(rtbEditor.Rtf)
                File.WriteAllBytes(Save.FileName, contentData)
                Me.Text = Save.FileName
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ToolStripButton_Print_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Print.Click
        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

#Region "Printing"
    Private checkPrint As Integer

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        checkPrint = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        checkPrint = rtbEditor.Print(checkPrint, rtbEditor.TextLength, e)
        If checkPrint < rtbEditor.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

#End Region

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
                sbTaRtf.Append("\cellx" & j * cellWidth & "\clbrdrb")
            Next
            sbTaRtf.Append("\intbl \cell \row")
        Next
        sbTaRtf.Append("\pard")
        sbTaRtf.Append("}")
        rtbEditor.SelectedRtf = sbTaRtf.ToString()
    End Sub

#End Region

End Class

Public Class RichTextBoxPrintCtrl
    Inherits System.Windows.Forms.RichTextBox
    Private Const AnInch As Double = 14.4

    <StructLayout(LayoutKind.Sequential)>
    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure CHARRANGE
        Public cpMin As Integer          ' First character of range (0 for start of doc)
        Public cpMax As Integer          ' Last character of range (-1 for end of doc)
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure FORMATRANGE
        Public hdc As IntPtr             ' Actual DC to draw on
        Public hdcTarget As IntPtr       ' Target DC for determining text formatting
        Public rc As RECT                ' Region of the DC to draw to (in twips)
        Public rcPage As RECT            ' Region of the whole DC (page size) (in twips)
        Public chrg As CHARRANGE         ' Range of text to draw (see above declaration)
    End Structure

    Private Const WM_USER As Integer = &H400
    Private Const EM_FORMATRANGE As Integer = WM_USER + 57

    Private Declare Function SendMessage Lib "USER32" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr

    Public Function Print(ByVal charFrom As Integer, ByVal charTo As Integer, ByVal e As PrintPageEventArgs) As Integer

        ' Mark starting and ending character 
        Dim cRange As CHARRANGE
        cRange.cpMin = charFrom
        cRange.cpMax = charTo

        ' Calculate the area to render and print
        Dim rectToPrint As RECT
        rectToPrint.Top = CInt(e.MarginBounds.Top * AnInch)
        rectToPrint.Bottom = CInt(e.MarginBounds.Bottom * AnInch)
        rectToPrint.Left = CInt(e.MarginBounds.Left * AnInch)
        rectToPrint.Right = CInt(e.MarginBounds.Right * AnInch)

        ' Calculate the size of the page
        Dim rectPage As RECT
        rectPage.Top = CInt(e.PageBounds.Top * AnInch)
        rectPage.Bottom = CInt(e.PageBounds.Bottom * AnInch)
        rectPage.Left = CInt(e.PageBounds.Left * AnInch)
        rectPage.Right = CInt(e.PageBounds.Right * AnInch)

        Dim hdc As IntPtr = e.Graphics.GetHdc()

        Dim fmtRange As FORMATRANGE
        fmtRange.chrg = cRange                 ' Indicate character from to character to 
        fmtRange.hdc = hdc                     ' Use the same DC for measuring and rendering
        fmtRange.hdcTarget = hdc               ' Point at printer hDC
        fmtRange.rc = rectToPrint              ' Indicate the area on page to print
        fmtRange.rcPage = rectPage             ' Indicate whole size of page

        Dim res As IntPtr = IntPtr.Zero

        Dim wparam As IntPtr = IntPtr.Zero
        wparam = New IntPtr(1)

        ' Move the pointer to the FORMATRANGE structure in memory
        Dim lparam As IntPtr = IntPtr.Zero
        lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange))
        Marshal.StructureToPtr(fmtRange, lparam, False)

        ' Send the rendered data for printing 
        res = SendMessage(Handle, EM_FORMATRANGE, wparam, lparam)

        ' Free the block of memory allocated
        Marshal.FreeCoTaskMem(lparam)

        ' Release the device context handle obtained by a previous call
        e.Graphics.ReleaseHdc(hdc)

        ' Return last + 1 character printer
        Return res.ToInt32()
    End Function

End Class