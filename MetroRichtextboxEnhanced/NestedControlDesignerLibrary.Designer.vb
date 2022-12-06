<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NestedControlDesignerLibrary
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.pnlWorkingArea = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'lblCaption
        '
        Me.lblCaption.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCaption.Location = New System.Drawing.Point(0, 0)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(244, 15)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Text = "Label1"
        '
        'pnlWorkingArea
        '
        Me.pnlWorkingArea.BackColor = System.Drawing.SystemColors.ControlDark
        Me.pnlWorkingArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlWorkingArea.Location = New System.Drawing.Point(0, 15)
        Me.pnlWorkingArea.Name = "pnlWorkingArea"
        Me.pnlWorkingArea.Size = New System.Drawing.Size(244, 245)
        Me.pnlWorkingArea.TabIndex = 1
        '
        'NestedControlDesignerLibrary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlWorkingArea)
        Me.Controls.Add(Me.lblCaption)
        Me.Name = "NestedControlDesignerLibrary"
        Me.Size = New System.Drawing.Size(244, 260)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblCaption As Label
    Friend WithEvents pnlWorkingArea As Panel
End Class
