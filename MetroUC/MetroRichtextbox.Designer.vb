<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MetroRichtextbox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MetroRichtextbox))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Open = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Binary = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Print = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_Cut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Copy = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Paste = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Undo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Redo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_Font = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Color = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_BG_Color = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_Bold = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Italic = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Underline = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Strike = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_Superscript = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Subscript = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Normal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_LeftAlign = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_CenterAlign = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_RightAlign = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_Bullet = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_List = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_Picture = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Table = New System.Windows.Forms.ToolStripButton()
        Me.rtbEditor = New RichTextBoxPrintCtrl()
        Me.OpenFileDialogForPicture = New System.Windows.Forms.OpenFileDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Open, Me.ToolStripButton_Binary, Me.ToolStripButton_Print, Me.ToolStripSeparator6, Me.ToolStripButton_Cut, Me.ToolStripButton_Copy, Me.ToolStripButton_Paste, Me.ToolStripButton_Undo, Me.ToolStripButton_Redo, Me.ToolStripSeparator1, Me.ToolStripButton_Font, Me.ToolStripButton_Color, Me.ToolStripButton_BG_Color, Me.ToolStripSeparator7, Me.ToolStripButton_Bold, Me.ToolStripButton_Italic, Me.ToolStripButton_Underline, Me.ToolStripButton_Strike, Me.ToolStripSeparator2, Me.ToolStripButton_Superscript, Me.ToolStripButton_Subscript, Me.ToolStripButton_Normal, Me.ToolStripSeparator3, Me.ToolStripButton_LeftAlign, Me.ToolStripButton_CenterAlign, Me.ToolStripButton_RightAlign, Me.ToolStripSeparator4, Me.ToolStripButton_Bullet, Me.ToolStripButton_List, Me.ToolStripSeparator5, Me.ToolStripButton_Picture, Me.ToolStripButton_Table})
        Me.ToolStrip1.Location = New System.Drawing.Point(1, 1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(747, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton_Open
        '
        Me.ToolStripButton_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Open.Image = CType(resources.GetObject("ToolStripButton_Open.Image"), System.Drawing.Image)
        Me.ToolStripButton_Open.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Open.Name = "ToolStripButton_Open"
        Me.ToolStripButton_Open.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Open.Text = "Open"
        '
        'ToolStripButton_Binary
        '
        Me.ToolStripButton_Binary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Binary.Image = CType(resources.GetObject("ToolStripButton_Binary.Image"), System.Drawing.Image)
        Me.ToolStripButton_Binary.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Binary.Name = "ToolStripButton_Binary"
        Me.ToolStripButton_Binary.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Binary.Text = "Save as Binary"
        '
        'ToolStripButton_Print
        '
        Me.ToolStripButton_Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Print.Image = CType(resources.GetObject("ToolStripButton_Print.Image"), System.Drawing.Image)
        Me.ToolStripButton_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Print.Name = "ToolStripButton_Print"
        Me.ToolStripButton_Print.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Print.Text = "Print"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Cut
        '
        Me.ToolStripButton_Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Cut.Image = CType(resources.GetObject("ToolStripButton_Cut.Image"), System.Drawing.Image)
        Me.ToolStripButton_Cut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Cut.Name = "ToolStripButton_Cut"
        Me.ToolStripButton_Cut.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Cut.Text = "Cut"
        '
        'ToolStripButton_Copy
        '
        Me.ToolStripButton_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Copy.Image = CType(resources.GetObject("ToolStripButton_Copy.Image"), System.Drawing.Image)
        Me.ToolStripButton_Copy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Copy.Name = "ToolStripButton_Copy"
        Me.ToolStripButton_Copy.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Copy.Text = "Copy"
        '
        'ToolStripButton_Paste
        '
        Me.ToolStripButton_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Paste.Image = CType(resources.GetObject("ToolStripButton_Paste.Image"), System.Drawing.Image)
        Me.ToolStripButton_Paste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Paste.Name = "ToolStripButton_Paste"
        Me.ToolStripButton_Paste.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Paste.Text = "Paste"
        '
        'ToolStripButton_Undo
        '
        Me.ToolStripButton_Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Undo.Image = CType(resources.GetObject("ToolStripButton_Undo.Image"), System.Drawing.Image)
        Me.ToolStripButton_Undo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Undo.Name = "ToolStripButton_Undo"
        Me.ToolStripButton_Undo.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Undo.Text = "Undo"
        Me.ToolStripButton_Undo.ToolTipText = "Undo"
        '
        'ToolStripButton_Redo
        '
        Me.ToolStripButton_Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Redo.Image = CType(resources.GetObject("ToolStripButton_Redo.Image"), System.Drawing.Image)
        Me.ToolStripButton_Redo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Redo.Name = "ToolStripButton_Redo"
        Me.ToolStripButton_Redo.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Redo.Text = "Redo"
        Me.ToolStripButton_Redo.ToolTipText = "Redo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Font
        '
        Me.ToolStripButton_Font.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Font.Image = CType(resources.GetObject("ToolStripButton_Font.Image"), System.Drawing.Image)
        Me.ToolStripButton_Font.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Font.Name = "ToolStripButton_Font"
        Me.ToolStripButton_Font.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Font.Text = "Choose Font"
        '
        'ToolStripButton_Color
        '
        Me.ToolStripButton_Color.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Color.Image = CType(resources.GetObject("ToolStripButton_Color.Image"), System.Drawing.Image)
        Me.ToolStripButton_Color.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Color.Name = "ToolStripButton_Color"
        Me.ToolStripButton_Color.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Color.Text = "Color"
        '
        'ToolStripButton_BG_Color
        '
        Me.ToolStripButton_BG_Color.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_BG_Color.Image = CType(resources.GetObject("ToolStripButton_BG_Color.Image"), System.Drawing.Image)
        Me.ToolStripButton_BG_Color.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_BG_Color.Name = "ToolStripButton_BG_Color"
        Me.ToolStripButton_BG_Color.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_BG_Color.Text = "Background Color"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Bold
        '
        Me.ToolStripButton_Bold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Bold.Image = CType(resources.GetObject("ToolStripButton_Bold.Image"), System.Drawing.Image)
        Me.ToolStripButton_Bold.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Bold.Name = "ToolStripButton_Bold"
        Me.ToolStripButton_Bold.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Bold.Text = "Bold"
        Me.ToolStripButton_Bold.ToolTipText = "Bold"
        '
        'ToolStripButton_Italic
        '
        Me.ToolStripButton_Italic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Italic.Image = CType(resources.GetObject("ToolStripButton_Italic.Image"), System.Drawing.Image)
        Me.ToolStripButton_Italic.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Italic.Name = "ToolStripButton_Italic"
        Me.ToolStripButton_Italic.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Italic.Text = "Italic"
        '
        'ToolStripButton_Underline
        '
        Me.ToolStripButton_Underline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Underline.Image = CType(resources.GetObject("ToolStripButton_Underline.Image"), System.Drawing.Image)
        Me.ToolStripButton_Underline.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Underline.Name = "ToolStripButton_Underline"
        Me.ToolStripButton_Underline.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Underline.Text = "Underline"
        '
        'ToolStripButton_Strike
        '
        Me.ToolStripButton_Strike.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Strike.Image = CType(resources.GetObject("ToolStripButton_Strike.Image"), System.Drawing.Image)
        Me.ToolStripButton_Strike.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Strike.Name = "ToolStripButton_Strike"
        Me.ToolStripButton_Strike.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Strike.Text = "Strike"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Superscript
        '
        Me.ToolStripButton_Superscript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Superscript.Image = CType(resources.GetObject("ToolStripButton_Superscript.Image"), System.Drawing.Image)
        Me.ToolStripButton_Superscript.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Superscript.Name = "ToolStripButton_Superscript"
        Me.ToolStripButton_Superscript.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Superscript.Text = "Superscript"
        '
        'ToolStripButton_Subscript
        '
        Me.ToolStripButton_Subscript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Subscript.Image = CType(resources.GetObject("ToolStripButton_Subscript.Image"), System.Drawing.Image)
        Me.ToolStripButton_Subscript.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Subscript.Name = "ToolStripButton_Subscript"
        Me.ToolStripButton_Subscript.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Subscript.Text = "Subscript"
        '
        'ToolStripButton_Normal
        '
        Me.ToolStripButton_Normal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Normal.Image = CType(resources.GetObject("ToolStripButton_Normal.Image"), System.Drawing.Image)
        Me.ToolStripButton_Normal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Normal.Name = "ToolStripButton_Normal"
        Me.ToolStripButton_Normal.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Normal.Text = "Normal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_LeftAlign
        '
        Me.ToolStripButton_LeftAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_LeftAlign.Image = CType(resources.GetObject("ToolStripButton_LeftAlign.Image"), System.Drawing.Image)
        Me.ToolStripButton_LeftAlign.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_LeftAlign.Name = "ToolStripButton_LeftAlign"
        Me.ToolStripButton_LeftAlign.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_LeftAlign.Text = "Left Align"
        '
        'ToolStripButton_CenterAlign
        '
        Me.ToolStripButton_CenterAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_CenterAlign.Image = CType(resources.GetObject("ToolStripButton_CenterAlign.Image"), System.Drawing.Image)
        Me.ToolStripButton_CenterAlign.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_CenterAlign.Name = "ToolStripButton_CenterAlign"
        Me.ToolStripButton_CenterAlign.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_CenterAlign.Text = "Center Align"
        '
        'ToolStripButton_RightAlign
        '
        Me.ToolStripButton_RightAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_RightAlign.Image = CType(resources.GetObject("ToolStripButton_RightAlign.Image"), System.Drawing.Image)
        Me.ToolStripButton_RightAlign.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_RightAlign.Name = "ToolStripButton_RightAlign"
        Me.ToolStripButton_RightAlign.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_RightAlign.Text = "Right Align"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Bullet
        '
        Me.ToolStripButton_Bullet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Bullet.Image = CType(resources.GetObject("ToolStripButton_Bullet.Image"), System.Drawing.Image)
        Me.ToolStripButton_Bullet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Bullet.Name = "ToolStripButton_Bullet"
        Me.ToolStripButton_Bullet.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Bullet.Text = "Bullet"
        '
        'ToolStripButton_List
        '
        Me.ToolStripButton_List.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_List.Image = CType(resources.GetObject("ToolStripButton_List.Image"), System.Drawing.Image)
        Me.ToolStripButton_List.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_List.Name = "ToolStripButton_List"
        Me.ToolStripButton_List.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_List.Text = "List"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Picture
        '
        Me.ToolStripButton_Picture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Picture.Image = CType(resources.GetObject("ToolStripButton_Picture.Image"), System.Drawing.Image)
        Me.ToolStripButton_Picture.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Picture.Name = "ToolStripButton_Picture"
        Me.ToolStripButton_Picture.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Picture.Text = "Picture"
        '
        'ToolStripButton_Table
        '
        Me.ToolStripButton_Table.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Table.Image = CType(resources.GetObject("ToolStripButton_Table.Image"), System.Drawing.Image)
        Me.ToolStripButton_Table.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Table.Name = "ToolStripButton_Table"
        Me.ToolStripButton_Table.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Table.Text = "Table"
        '
        'rtbEditor
        '
        Me.rtbEditor.AllowDrop = True
        Me.rtbEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbEditor.Location = New System.Drawing.Point(1, 26)
        Me.rtbEditor.Name = "rtbEditor"
        Me.rtbEditor.Size = New System.Drawing.Size(747, 240)
        Me.rtbEditor.TabIndex = 1
        Me.rtbEditor.Text = ""
        '
        'OpenFileDialogForPicture
        '
        Me.OpenFileDialogForPicture.FileName = "OpenFileDialogForPicture"
        Me.OpenFileDialogForPicture.Title = "Select an Image"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Richtextbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rtbEditor)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Richtextbox"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.Size = New System.Drawing.Size(749, 267)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents rtbEditor As RichTextBoxPrintCtrl
    Friend WithEvents ToolStripButton_Cut As ToolStripButton
    Friend WithEvents ToolStripButton_Copy As ToolStripButton
    Friend WithEvents ToolStripButton_Paste As ToolStripButton
    Friend WithEvents ToolStripButton_Undo As ToolStripButton
    Friend WithEvents ToolStripButton_Redo As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton_Bold As ToolStripButton
    Friend WithEvents ToolStripButton_Italic As ToolStripButton
    Friend WithEvents ToolStripButton_Underline As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripButton_Superscript As ToolStripButton
    Friend WithEvents ToolStripButton_Subscript As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripButton_LeftAlign As ToolStripButton
    Friend WithEvents ToolStripButton_CenterAlign As ToolStripButton
    Friend WithEvents ToolStripButton_RightAlign As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripButton_Bullet As ToolStripButton
    Friend WithEvents ToolStripButton_List As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStripButton_Picture As ToolStripButton
    Friend WithEvents ToolStripButton_Table As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripButton_Binary As ToolStripButton
    Friend WithEvents ToolStripButton_Normal As ToolStripButton
    Friend WithEvents ToolStripButton_Color As ToolStripButton
    Friend WithEvents ToolStripButton_BG_Color As ToolStripButton
    Friend WithEvents ToolStripButton_Font As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents OpenFileDialogForPicture As OpenFileDialog
    Friend WithEvents ToolStripButton_Strike As ToolStripButton
    Friend WithEvents ToolStripButton_Open As ToolStripButton
    Friend WithEvents ToolStripButton_Print As ToolStripButton
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
End Class
