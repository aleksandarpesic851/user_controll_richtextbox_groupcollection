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
        Me.WorkingArea = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Groupbox4 = New MetroUC.MetroGroupbox()
        Me.Groupbox3 = New MetroUC.MetroGroupbox()
        Me.Richtextbox1 = New MetroUC.MetroRichtextbox()
        Me.Groupbox2 = New MetroUC.MetroGroupbox()
        Me.GroupboxCollection1 = New MetroUC.MetroGroupboxCollection(Me.components)
        Me.MetroGroupboxCollection1 = New MetroUC.MetroGroupboxCollection(Me.components)
        Me.MetroGroupbox1 = New MetroUC.MetroGroupbox()
        Me.MetroGroupbox2 = New MetroUC.MetroGroupbox()
        Me.Groupbox4.SuspendLayout()
        Me.Groupbox3.WorkingArea.SuspendLayout()
        Me.Groupbox3.SuspendLayout()
        Me.Groupbox2.SuspendLayout()
        Me.GroupboxCollection1.WorkingArea.SuspendLayout()
        Me.GroupboxCollection1.SuspendLayout()
        Me.MetroGroupboxCollection1.WorkingArea.SuspendLayout()
        Me.MetroGroupboxCollection1.SuspendLayout()
        Me.MetroGroupbox1.SuspendLayout()
        Me.MetroGroupbox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'WorkingArea
        '
        Me.WorkingArea.AutoScroll = True
        Me.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkingArea.Location = New System.Drawing.Point(0, 0)
        Me.WorkingArea.Name = "WorkingArea"
        Me.WorkingArea.Size = New System.Drawing.Size(200, 100)
        Me.WorkingArea.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(736, 94)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(201, 93)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Add Groupbox into Collection"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(736, 234)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(201, 83)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Add a control into last groupbox"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Groupbox4
        '
        Me.Groupbox4.AutoScroll = True
        Me.Groupbox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Groupbox4.GroupboxBorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Groupbox4.GroupboxBorderRadius = 0
        Me.Groupbox4.GroupboxBorderThickness = 1
        Me.Groupbox4.GroupboxEnableCollapsable = True
        Me.Groupbox4.GroupboxHeightOption = MetroUC.GroupboxConsts.HeightOptions.Fixed
        Me.Groupbox4.GroupboxTitleBackgroundColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Groupbox4.GroupboxTitleHeight = 50
        Me.Groupbox4.GroupboxTitleText = "Title"
        Me.Groupbox4.GroupboxTitleTextColor = System.Drawing.Color.White
        Me.Groupbox4.GroupboxTitleTextFont = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Groupbox4.Location = New System.Drawing.Point(3, 523)
        Me.Groupbox4.MinimumSize = New System.Drawing.Size(100, 10)
        Me.Groupbox4.Name = "Groupbox4"
        Me.Groupbox4.Padding = New System.Windows.Forms.Padding(1)
        Me.Groupbox4.Size = New System.Drawing.Size(566, 150)
        Me.Groupbox4.TabIndex = 2
        '
        'Groupbox4.WorkingArea
        '
        Me.Groupbox4.WorkingArea.AutoScroll = True
        Me.Groupbox4.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Groupbox4.WorkingArea.Location = New System.Drawing.Point(1, 51)
        Me.Groupbox4.WorkingArea.Name = "WorkingArea"
        Me.Groupbox4.WorkingArea.Size = New System.Drawing.Size(564, 98)
        Me.Groupbox4.WorkingArea.TabIndex = 1
        '
        'Groupbox3
        '
        Me.Groupbox3.AutoScroll = True
        Me.Groupbox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Groupbox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Groupbox3.GroupboxBorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Groupbox3.GroupboxBorderRadius = 5
        Me.Groupbox3.GroupboxBorderThickness = 5
        Me.Groupbox3.GroupboxEnableCollapsable = True
        Me.Groupbox3.GroupboxHeightOption = MetroUC.GroupboxConsts.HeightOptions.Expanable
        Me.Groupbox3.GroupboxTitleBackgroundColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Groupbox3.GroupboxTitleHeight = 50
        Me.Groupbox3.GroupboxTitleText = "Title"
        Me.Groupbox3.GroupboxTitleTextColor = System.Drawing.Color.White
        Me.Groupbox3.GroupboxTitleTextFont = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Groupbox3.Location = New System.Drawing.Point(3, 159)
        Me.Groupbox3.MinimumSize = New System.Drawing.Size(100, 10)
        Me.Groupbox3.Name = "Groupbox3"
        Me.Groupbox3.Padding = New System.Windows.Forms.Padding(5)
        Me.Groupbox3.Size = New System.Drawing.Size(566, 358)
        Me.Groupbox3.TabIndex = 1
        '
        'Groupbox3.WorkingArea
        '
        Me.Groupbox3.WorkingArea.AutoScroll = True
        Me.Groupbox3.WorkingArea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Groupbox3.WorkingArea.Controls.Add(Me.Richtextbox1)
        Me.Groupbox3.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Groupbox3.WorkingArea.Location = New System.Drawing.Point(5, 55)
        Me.Groupbox3.WorkingArea.Name = "WorkingArea"
        Me.Groupbox3.WorkingArea.Size = New System.Drawing.Size(556, 298)
        Me.Groupbox3.WorkingArea.TabIndex = 1
        '
        'Richtextbox1
        '
        Me.Richtextbox1.BorderColor = System.Drawing.Color.Black
        Me.Richtextbox1.BorderRadius = 0
        Me.Richtextbox1.BorderThickness = 1
        Me.Richtextbox1.Location = New System.Drawing.Point(25, 31)
        Me.Richtextbox1.Name = "Richtextbox1"
        Me.Richtextbox1.Padding = New System.Windows.Forms.Padding(1)
        Me.Richtextbox1.Resizable = True
        Me.Richtextbox1.Size = New System.Drawing.Size(749, 267)
        Me.Richtextbox1.TabIndex = 0
        Me.Richtextbox1.ToolbarColor = System.Drawing.SystemColors.Control
        '
        'Groupbox2
        '
        Me.Groupbox2.AutoScroll = True
        Me.Groupbox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Groupbox2.GroupboxBorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Groupbox2.GroupboxBorderRadius = 0
        Me.Groupbox2.GroupboxBorderThickness = 10
        Me.Groupbox2.GroupboxEnableCollapsable = True
        Me.Groupbox2.GroupboxHeightOption = MetroUC.GroupboxConsts.HeightOptions.Fixed
        Me.Groupbox2.GroupboxTitleBackgroundColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Groupbox2.GroupboxTitleHeight = 50
        Me.Groupbox2.GroupboxTitleText = "Title"
        Me.Groupbox2.GroupboxTitleTextColor = System.Drawing.Color.White
        Me.Groupbox2.GroupboxTitleTextFont = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Groupbox2.Location = New System.Drawing.Point(3, 3)
        Me.Groupbox2.MinimumSize = New System.Drawing.Size(100, 10)
        Me.Groupbox2.Name = "Groupbox2"
        Me.Groupbox2.Padding = New System.Windows.Forms.Padding(10)
        Me.Groupbox2.Size = New System.Drawing.Size(566, 150)
        Me.Groupbox2.TabIndex = 0
        '
        'Groupbox2.WorkingArea
        '
        Me.Groupbox2.WorkingArea.AutoScroll = True
        Me.Groupbox2.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Groupbox2.WorkingArea.Location = New System.Drawing.Point(10, 60)
        Me.Groupbox2.WorkingArea.Name = "WorkingArea"
        Me.Groupbox2.WorkingArea.Size = New System.Drawing.Size(546, 80)
        Me.Groupbox2.WorkingArea.TabIndex = 1
        '
        'GroupboxCollection1
        '
        Me.GroupboxCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupboxCollection1.BorderColor = System.Drawing.Color.Black
        Me.GroupboxCollection1.BorderRadius = 1
        Me.GroupboxCollection1.BorderThickness = 1
        Me.GroupboxCollection1.EndUserCanResize = False
        Me.GroupboxCollection1.GroupboxGrowToCollectionWidth = True
        Me.GroupboxCollection1.Location = New System.Drawing.Point(299, 12)
        Me.GroupboxCollection1.Name = "GroupboxCollection1"
        Me.GroupboxCollection1.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupboxCollection1.Size = New System.Drawing.Size(584, 636)
        Me.GroupboxCollection1.TabIndex = 3
        '
        'GroupboxCollection1.WorkingArea
        '
        Me.GroupboxCollection1.WorkingArea.AutoScroll = True
        Me.GroupboxCollection1.WorkingArea.Controls.Add(Me.Groupbox2)
        Me.GroupboxCollection1.WorkingArea.Controls.Add(Me.Groupbox3)
        Me.GroupboxCollection1.WorkingArea.Controls.Add(Me.Groupbox4)
        Me.GroupboxCollection1.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupboxCollection1.WorkingArea.Location = New System.Drawing.Point(6, 6)
        Me.GroupboxCollection1.WorkingArea.Name = "WorkingArea"
        Me.GroupboxCollection1.WorkingArea.Size = New System.Drawing.Size(572, 624)
        Me.GroupboxCollection1.WorkingArea.TabIndex = 0
        '
        'MetroGroupboxCollection1
        '
        Me.MetroGroupboxCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MetroGroupboxCollection1.BorderColor = System.Drawing.Color.Black
        Me.MetroGroupboxCollection1.BorderRadius = 1
        Me.MetroGroupboxCollection1.BorderThickness = 1
        Me.MetroGroupboxCollection1.EndUserCanResize = True
        Me.MetroGroupboxCollection1.GroupboxGrowToCollectionWidth = True
        Me.MetroGroupboxCollection1.Location = New System.Drawing.Point(81, 61)
        Me.MetroGroupboxCollection1.Name = "MetroGroupboxCollection1"
        Me.MetroGroupboxCollection1.Padding = New System.Windows.Forms.Padding(6)
        Me.MetroGroupboxCollection1.Size = New System.Drawing.Size(218, 250)
        Me.MetroGroupboxCollection1.TabIndex = 6
        '
        'MetroGroupboxCollection1.WorkingArea
        '
        Me.MetroGroupboxCollection1.WorkingArea.AutoScroll = True
        Me.MetroGroupboxCollection1.WorkingArea.Controls.Add(Me.MetroGroupbox1)
        Me.MetroGroupboxCollection1.WorkingArea.Controls.Add(Me.MetroGroupbox2)
        Me.MetroGroupboxCollection1.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroGroupboxCollection1.WorkingArea.Location = New System.Drawing.Point(6, 6)
        Me.MetroGroupboxCollection1.WorkingArea.Name = "WorkingArea"
        Me.MetroGroupboxCollection1.WorkingArea.Size = New System.Drawing.Size(206, 238)
        Me.MetroGroupboxCollection1.WorkingArea.TabIndex = 0
        '
        'MetroGroupbox1
        '
        Me.MetroGroupbox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MetroGroupbox1.GroupboxBorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MetroGroupbox1.GroupboxBorderRadius = 0
        Me.MetroGroupbox1.GroupboxBorderThickness = 1
        Me.MetroGroupbox1.GroupboxEnableCollapsable = True
        Me.MetroGroupbox1.GroupboxHeightOption = MetroUC.GroupboxConsts.HeightOptions.Fixed
        Me.MetroGroupbox1.GroupboxTitleBackgroundColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.MetroGroupbox1.GroupboxTitleHeight = 20
        Me.MetroGroupbox1.GroupboxTitleText = "Title"
        Me.MetroGroupbox1.GroupboxTitleTextColor = System.Drawing.Color.White
        Me.MetroGroupbox1.GroupboxTitleTextFont = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.MetroGroupbox1.Location = New System.Drawing.Point(3, 3)
        Me.MetroGroupbox1.MinimumSize = New System.Drawing.Size(100, 10)
        Me.MetroGroupbox1.Name = "MetroGroupbox1"
        Me.MetroGroupbox1.Padding = New System.Windows.Forms.Padding(1)
        Me.MetroGroupbox1.Size = New System.Drawing.Size(200, 150)
        Me.MetroGroupbox1.TabIndex = 0
        '
        'MetroGroupbox1.WorkingArea
        '
        Me.MetroGroupbox1.WorkingArea.AutoScroll = True
        Me.MetroGroupbox1.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroGroupbox1.WorkingArea.Location = New System.Drawing.Point(1, 21)
        Me.MetroGroupbox1.WorkingArea.Name = "WorkingArea"
        Me.MetroGroupbox1.WorkingArea.Size = New System.Drawing.Size(198, 128)
        Me.MetroGroupbox1.WorkingArea.TabIndex = 1
        '
        'MetroGroupbox2
        '
        Me.MetroGroupbox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MetroGroupbox2.GroupboxBorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MetroGroupbox2.GroupboxBorderRadius = 0
        Me.MetroGroupbox2.GroupboxBorderThickness = 1
        Me.MetroGroupbox2.GroupboxEnableCollapsable = True
        Me.MetroGroupbox2.GroupboxHeightOption = MetroUC.GroupboxConsts.HeightOptions.Expanable
        Me.MetroGroupbox2.GroupboxTitleBackgroundColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.MetroGroupbox2.GroupboxTitleHeight = 20
        Me.MetroGroupbox2.GroupboxTitleText = "Title"
        Me.MetroGroupbox2.GroupboxTitleTextColor = System.Drawing.Color.White
        Me.MetroGroupbox2.GroupboxTitleTextFont = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.MetroGroupbox2.Location = New System.Drawing.Point(3, 159)
        Me.MetroGroupbox2.MinimumSize = New System.Drawing.Size(100, 10)
        Me.MetroGroupbox2.Name = "MetroGroupbox2"
        Me.MetroGroupbox2.Padding = New System.Windows.Forms.Padding(1)
        Me.MetroGroupbox2.Size = New System.Drawing.Size(200, 22)
        Me.MetroGroupbox2.TabIndex = 1
        '
        'MetroGroupbox2.WorkingArea
        '
        Me.MetroGroupbox2.WorkingArea.AutoScroll = True
        Me.MetroGroupbox2.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroGroupbox2.WorkingArea.Location = New System.Drawing.Point(1, 21)
        Me.MetroGroupbox2.WorkingArea.Name = "WorkingArea"
        Me.MetroGroupbox2.WorkingArea.Size = New System.Drawing.Size(198, 0)
        Me.MetroGroupbox2.WorkingArea.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 749)
        Me.Controls.Add(Me.MetroGroupboxCollection1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupboxCollection1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Groupbox4.ResumeLayout(False)
        Me.Groupbox3.WorkingArea.ResumeLayout(False)
        Me.Groupbox3.ResumeLayout(False)
        Me.Groupbox2.ResumeLayout(False)
        Me.GroupboxCollection1.WorkingArea.ResumeLayout(False)
        Me.GroupboxCollection1.ResumeLayout(False)
        Me.MetroGroupboxCollection1.WorkingArea.ResumeLayout(False)
        Me.MetroGroupboxCollection1.ResumeLayout(False)
        Me.MetroGroupbox1.ResumeLayout(False)
        Me.MetroGroupbox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WorkingArea As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Groupbox4 As MetroGroupbox
    Friend WithEvents Groupbox3 As MetroGroupbox
    Friend WithEvents Richtextbox1 As MetroRichtextbox
    Friend WithEvents Groupbox2 As MetroGroupbox
    Friend WithEvents GroupboxCollection1 As MetroGroupboxCollection
    Friend WithEvents MetroGroupboxCollection1 As MetroGroupboxCollection
    Friend WithEvents MetroGroupbox1 As MetroGroupbox
    Friend WithEvents MetroGroupbox2 As MetroGroupbox
End Class
