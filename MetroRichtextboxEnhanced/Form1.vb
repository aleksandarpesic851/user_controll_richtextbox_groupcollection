Public Class Form1
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.SuspendLayout()
        'Dim GroupBox_Avatar1 As MetroGroupbox = New MetroGroupbox()
        'GroupBox_Avatar1.BackColorGradient = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        'GroupBox_Avatar1.Border = True
        'GroupBox_Avatar1.BorderColor = System.Drawing.Color.Black
        'GroupBox_Avatar1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        ''GroupBox_Avatar1.Colors = New ToolsBox.Controller.Bloom(-1) {}
        'GroupBox_Avatar1.Customization = ""
        'GroupBox_Avatar1.Font = New System.Drawing.Font("Verdana", 8.0!)
        'GroupBox_Avatar1.ForeColors = System.Drawing.Color.White
        'GroupBox_Avatar1.Image = Nothing
        'GroupBox_Avatar1.Location = New System.Drawing.Point(179, 62)
        'GroupBox_Avatar1.Movable = True
        'GroupBox_Avatar1.Name = "GroupBox_Avatar1"
        'GroupBox_Avatar1.NoRounding = False
        'GroupBox_Avatar1.Opacity = 10
        'GroupBox_Avatar1.Sizable = True
        'GroupBox_Avatar1.Size = New System.Drawing.Size(150, 100)
        'GroupBox_Avatar1.SmartBounds = True
        'GroupBox_Avatar1.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        'GroupBox_Avatar1.TabIndex = 10
        'GroupBox_Avatar1.Text = "GroupBox_Avatar1"
        'GroupBox_Avatar1.TitleColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        'GroupBox_Avatar1.TitleColorGradient = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        'GroupBox_Avatar1.TransparencyKey = System.Drawing.Color.Empty
        'GroupBox_Avatar1.Transparent = False

        'Me.Controls.Add(GroupBox_Avatar1)
        Me.ResumeLayout(False)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        Dim newGroupbox As MetroUC.MetroGroupBox = New MetroUC.MetroGroupBox()
        Me.Controls.Add(newGroupbox)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub mypaint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

    End Sub


    Private Sub Panel1_ControlAdded(sender As Object, e As ControlEventArgs)

    End Sub

    Private Sub Panel1_ControlRemoved(sender As Object, e As ControlEventArgs)

    End Sub

    Private Sub Panel1_Scroll(sender As Object, e As ScrollEventArgs)

    End Sub

    Private Sub Panel1_SizeChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs)
        GroupboxCollection1.AddGroupbox()
    End Sub

    Private Sub MetroGroupBox1_CollapseEvent(sender As Object)
        MessageBox.Show("Collapse Event Fired")
    End Sub

    Private Sub MetroGroupBox1_ExpandEvent(sender As Object)
        MessageBox.Show("Expand Event Fired")

    End Sub
End Class
