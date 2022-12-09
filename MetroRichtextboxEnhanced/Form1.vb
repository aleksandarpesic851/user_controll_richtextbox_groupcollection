Imports MetroUC

Public Class Form1
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub MetroGroupBox3_ExpandEvent(sender As Object)
    End Sub

    Private Sub GroupboxCollection1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private addedGroupbox As MetroGroupBox
    'Private Sub ButtonAdd_Click(sender As Object, e As EventArgs)
    '    addedGroupbox = GroupboxCollection1.AddGroupbox()
    '    addedGroupbox.Height = 300
    'End Sub

    Private Sub MetroGroupBox2_CollapseEvent(sender As Object)
        MessageBox.Show("Collapsed")
    End Sub

    Private addedControl As Control

    Private Sub MetroGroupBox3_ExpandEvent_1(sender As Object) Handles MetroGroupBox3.ExpandEvent
        Dim _control As Button = New Button()
        _control.Text = "Created Programatically"
        MetroGroupBox3.Controls.Add(_control)
        _control.Location = New Point(50, 100)
        _control.Size = New Size(100, 100)

        Dim other_control As Richtextbox = New Richtextbox
        MetroGroupBox3.Controls.Add(other_control)
        other_control.Location = New Point(50, 250)

        MessageBox.Show("Expanded")
    End Sub
End Class
