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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.NestedControlDesignerLibrary1 = New MetroRichtextboxEnhanced.NestedControlDesignerLibrary()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(286, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(423, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(288, 197)
        Me.Panel1.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(10, 10)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 23)
        Me.TextBox1.TabIndex = 4
        '
        'NestedControlDesignerLibrary1
        '
        Me.NestedControlDesignerLibrary1.Caption1 = "Label1"
        Me.NestedControlDesignerLibrary1.Location = New System.Drawing.Point(61, 66)
        Me.NestedControlDesignerLibrary1.Name = "NestedControlDesignerLibrary1"
        Me.NestedControlDesignerLibrary1.Size = New System.Drawing.Size(244, 260)
        Me.NestedControlDesignerLibrary1.TabIndex = 5
        '
        '
        '
        Me.NestedControlDesignerLibrary1.WorkingArea.BackColor = System.Drawing.SystemColors.ControlDark
        Me.NestedControlDesignerLibrary1.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NestedControlDesignerLibrary1.WorkingArea.Location = New System.Drawing.Point(0, 15)
        Me.NestedControlDesignerLibrary1.WorkingArea.Name = "pnlWorkingArea"
        Me.NestedControlDesignerLibrary1.WorkingArea.Size = New System.Drawing.Size(244, 245)
        Me.NestedControlDesignerLibrary1.WorkingArea.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 539)
        Me.Controls.Add(Me.NestedControlDesignerLibrary1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents NestedControlDesignerLibrary1 As NestedControlDesignerLibrary
End Class
