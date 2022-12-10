Imports MetroUC

Public Class Form1
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private addedGroupbox As MetroGroupbox

    Private addedControl As Control

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        addedGroupbox = GroupboxCollection1.AddGroupbox()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim _metroGroupbox As MetroGroupbox
        Dim nCnt As Integer = GroupboxCollection1.WorkingArea.Controls.Count
        If nCnt < 1 Then
            MessageBox.Show("Please insert first")
        End If
        _metroGroupbox = TryCast(GroupboxCollection1.WorkingArea.Controls.Item(nCnt - 1), MetroGroupbox)

        Dim _control As Button = New Button()
        _control.Text = "Created Programatically"
        _metroGroupbox.WorkingArea.Controls.Add(_control)
        _control.Location = New Point(50, 100)
        _control.Size = New Size(100, 100)

        Dim other_control As RichTextBox = New RichTextBox
        _metroGroupbox.WorkingArea.Controls.Add(other_control)
        other_control.Location = New Point(50, 250)

    End Sub
End Class
