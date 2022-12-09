<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Richtextbox1 = New MetroUC.Richtextbox()
        Me.SuspendLayout()
        '
        'Richtextbox1
        '
        Me.Richtextbox1.BorderColor = System.Drawing.Color.Black
        Me.Richtextbox1.BorderRadius = 0
        Me.Richtextbox1.BorderThickness = 1
        Me.Richtextbox1.Location = New System.Drawing.Point(14, 85)
        Me.Richtextbox1.Name = "Richtextbox1"
        Me.Richtextbox1.Padding = New System.Windows.Forms.Padding(1)
        Me.Richtextbox1.Resizable = True
        Me.Richtextbox1.Size = New System.Drawing.Size(749, 267)
        Me.Richtextbox1.TabIndex = 0
        Me.Richtextbox1.ToolbarColor = System.Drawing.SystemColors.Control
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 749)
        Me.Controls.Add(Me.Richtextbox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Richtextbox1 As MetroUC.Richtextbox
End Class
