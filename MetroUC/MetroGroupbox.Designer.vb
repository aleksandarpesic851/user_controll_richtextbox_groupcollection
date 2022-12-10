<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MetroGroupbox
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
        Me.titleContainer = New System.Windows.Forms.Panel()
        Me.titleExpandMark = New System.Windows.Forms.Label()
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.pnlWorkingArea = New System.Windows.Forms.Panel()
        Me.titleContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'titleContainer
        '
        Me.titleContainer.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.titleContainer.Controls.Add(Me.titleExpandMark)
        Me.titleContainer.Controls.Add(Me.titleLabel)
        Me.titleContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.titleContainer.Location = New System.Drawing.Point(1, 1)
        Me.titleContainer.Name = "titleContainer"
        Me.titleContainer.Size = New System.Drawing.Size(198, 50)
        Me.titleContainer.TabIndex = 0
        '
        'titleExpandMark
        '
        Me.titleExpandMark.AutoSize = True
        Me.titleExpandMark.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.titleExpandMark.ForeColor = System.Drawing.Color.White
        Me.titleExpandMark.Location = New System.Drawing.Point(150, 10)
        Me.titleExpandMark.Name = "titleExpandMark"
        Me.titleExpandMark.Size = New System.Drawing.Size(45, 30)
        Me.titleExpandMark.TabIndex = 1
        Me.titleExpandMark.Text = " - "
        Me.titleExpandMark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'titleLabel
        '
        Me.titleLabel.AutoSize = True
        Me.titleLabel.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.titleLabel.ForeColor = System.Drawing.Color.White
        Me.titleLabel.Location = New System.Drawing.Point(0, 10)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(52, 30)
        Me.titleLabel.TabIndex = 0
        Me.titleLabel.Text = "Title"
        Me.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlWorkingArea
        '
        Me.pnlWorkingArea.AutoScroll = True
        Me.pnlWorkingArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlWorkingArea.Location = New System.Drawing.Point(1, 51)
        Me.pnlWorkingArea.Name = "pnlWorkingArea"
        Me.pnlWorkingArea.Size = New System.Drawing.Size(198, 98)
        Me.pnlWorkingArea.TabIndex = 1
        '
        'Groupbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlWorkingArea)
        Me.Controls.Add(Me.titleContainer)
        Me.MinimumSize = New System.Drawing.Size(100, 10)
        Me.Name = "Groupbox"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.Size = New System.Drawing.Size(200, 150)
        Me.titleContainer.ResumeLayout(False)
        Me.titleContainer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents titleContainer As Panel
    Friend WithEvents pnlWorkingArea As Panel
    Friend WithEvents titleExpandMark As Label
    Friend WithEvents titleLabel As Label
End Class
