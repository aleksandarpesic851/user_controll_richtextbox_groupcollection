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
        Me.components = New System.ComponentModel.Container()
        Me.GroupboxCollection1 = New MetroUC.GroupboxCollection(Me.components)
        Me.MetroGroupBox1 = New MetroUC.MetroGroupBox()
        Me.Richtextbox1 = New MetroUC.Richtextbox()
        Me.MetroGroupBox2 = New MetroUC.MetroGroupBox()
        Me.Richtextbox2 = New MetroUC.Richtextbox()
        Me.GroupboxCollection1.SuspendLayout()
        Me.MetroGroupBox1.SuspendLayout()
        Me.MetroGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupboxCollection1
        '
        Me.GroupboxCollection1.BorderColor = System.Drawing.Color.Black
        Me.GroupboxCollection1.BorderRadius = 1
        Me.GroupboxCollection1.BorderThickness = 1
        Me.GroupboxCollection1.Controls.Add(Me.MetroGroupBox1)
        Me.GroupboxCollection1.Controls.Add(Me.MetroGroupBox2)
        Me.GroupboxCollection1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupboxCollection1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.GroupboxCollection1.Location = New System.Drawing.Point(0, 0)
        Me.GroupboxCollection1.Name = "GroupboxCollection1"
        Me.GroupboxCollection1.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupboxCollection1.Size = New System.Drawing.Size(984, 749)
        Me.GroupboxCollection1.TabIndex = 0
        '
        'MetroGroupBox1
        '
        Me.MetroGroupBox1.AutoScroll = True
        Me.MetroGroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.MetroGroupBox1.Controls.Add(Me.Richtextbox1)
        Me.MetroGroupBox1.GroupboxBorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MetroGroupBox1.GroupboxBorderRadius = 0
        Me.MetroGroupBox1.GroupboxBorderThickness = 1
        Me.MetroGroupBox1.GroupboxEnableCollapsable = True
        Me.MetroGroupBox1.GroupboxHeightOption = MetroUC.GroupboxConsts.HeightOptions.Fixed
        Me.MetroGroupBox1.GroupboxTitleBackgroundColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.MetroGroupBox1.GroupboxTitleText = "Metro Enhanced RichEditBox"
        Me.MetroGroupBox1.GroupboxTitleTextColor = System.Drawing.Color.White
        Me.MetroGroupBox1.GroupboxTitleTextFont = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.MetroGroupBox1.Location = New System.Drawing.Point(9, 9)
        Me.MetroGroupBox1.Name = "MetroGroupBox1"
        Me.MetroGroupBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.MetroGroupBox1.Size = New System.Drawing.Size(966, 358)
        Me.MetroGroupBox1.TabIndex = 0
        '
        'Richtextbox1
        '
        Me.Richtextbox1.BorderColor = System.Drawing.Color.Black
        Me.Richtextbox1.BorderRadius = 0
        Me.Richtextbox1.BorderThickness = 1
        Me.Richtextbox1.Location = New System.Drawing.Point(44, 64)
        Me.Richtextbox1.Name = "Richtextbox1"
        Me.Richtextbox1.Padding = New System.Windows.Forms.Padding(1)
        Me.Richtextbox1.Resizable = True
        Me.Richtextbox1.Size = New System.Drawing.Size(785, 267)
        Me.Richtextbox1.TabIndex = 1
        Me.Richtextbox1.ToolbarColor = System.Drawing.SystemColors.Control
        '
        'MetroGroupBox2
        '
        Me.MetroGroupBox2.AutoSize = True
        Me.MetroGroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.MetroGroupBox2.Controls.Add(Me.Richtextbox2)
        Me.MetroGroupBox2.GroupboxBorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MetroGroupBox2.GroupboxBorderRadius = 10
        Me.MetroGroupBox2.GroupboxBorderThickness = 3
        Me.MetroGroupBox2.GroupboxEnableCollapsable = True
        Me.MetroGroupBox2.GroupboxHeightOption = MetroUC.GroupboxConsts.HeightOptions.Expanable
        Me.MetroGroupBox2.GroupboxTitleBackgroundColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.MetroGroupBox2.GroupboxTitleText = "Expanable"
        Me.MetroGroupBox2.GroupboxTitleTextColor = System.Drawing.Color.White
        Me.MetroGroupBox2.GroupboxTitleTextFont = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.MetroGroupBox2.Location = New System.Drawing.Point(9, 373)
        Me.MetroGroupBox2.Name = "MetroGroupBox2"
        Me.MetroGroupBox2.Padding = New System.Windows.Forms.Padding(3)
        Me.MetroGroupBox2.Size = New System.Drawing.Size(905, 352)
        Me.MetroGroupBox2.TabIndex = 1
        '
        'Richtextbox2
        '
        Me.Richtextbox2.BorderColor = System.Drawing.Color.Black
        Me.Richtextbox2.BorderRadius = 0
        Me.Richtextbox2.BorderThickness = 1
        Me.Richtextbox2.Location = New System.Drawing.Point(114, 79)
        Me.Richtextbox2.Name = "Richtextbox2"
        Me.Richtextbox2.Padding = New System.Windows.Forms.Padding(1)
        Me.Richtextbox2.Resizable = True
        Me.Richtextbox2.Size = New System.Drawing.Size(785, 267)
        Me.Richtextbox2.TabIndex = 1
        Me.Richtextbox2.ToolbarColor = System.Drawing.SystemColors.Control
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 749)
        Me.Controls.Add(Me.GroupboxCollection1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupboxCollection1.ResumeLayout(False)
        Me.GroupboxCollection1.PerformLayout()
        Me.MetroGroupBox1.ResumeLayout(False)
        Me.MetroGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupboxCollection1 As MetroUC.GroupboxCollection
    Friend WithEvents MetroGroupBox1 As MetroUC.MetroGroupBox
    Friend WithEvents Richtextbox1 As MetroUC.Richtextbox
    Friend WithEvents MetroGroupBox2 As MetroUC.MetroGroupBox
    Friend WithEvents Richtextbox2 As MetroUC.Richtextbox
End Class
