﻿Imports System.Drawing
Imports System.IO
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Imports Microsoft.DotNet.DesignTools.Designers

'<Designer(GetType(NestedControlDesigner))>
<Designer(GetType(MetroGroupboxCollectionDesigner))>
Public Class GroupboxCollection
    Inherits Panel

#Region "Collection Properties"
    ''' <summary>
    ''' Collection Properties
    ''' </summary>
    Private mBorderColor As Color = Color.Black
    Private mPadding As Integer = DEFAULT_GROUPBOX_BORDER_THICKNESS + 5
    Public Property BorderColor As Color
        Get
            Return mBorderColor
        End Get
        Set(value As Color)
            mBorderColor = value
            Me.Refresh()
        End Set
    End Property

    Private mBorderThickness As Integer = 1
    Public Property BorderThickness As Integer
        Get
            Return mBorderThickness
        End Get
        Set(value As Integer)
            mBorderThickness = value
            mPadding = mBorderThickness + 5
            Me.Padding = New Padding(mPadding)
            Me.Refresh()
        End Set
    End Property

    Private mBorderRadius As Integer = 1
    Public Property BorderRadius As Integer
        Get
            Return mBorderRadius
        End Get
        Set(value As Integer)
            mBorderRadius = value
            Me.Invalidate()
        End Set
    End Property

    Private mGroupboxCount As Integer = 0
    Public ReadOnly Property GroupboxCount As Integer
        Get
            Return mGroupboxCount
        End Get
        'Set(value As Integer)
        '    Dim nOldCnt As Integer = mGroupboxCount
        '    mGroupboxCount = value
        '    If mGroupboxCount > nOldCnt Then
        '        For i As Integer = nOldCnt To mGroupboxCount - 1
        '            AddGroupbox()
        '        Next
        '    End If
        '    If mGroupboxCount < nOldCnt Then
        '        For i As Integer = mGroupboxCount To nOldCnt - 1
        '            RemoveGroupboxAt(-1)
        '        Next
        '    End If
        'End Set
    End Property

#End Region
    Friend WithEvents pnlWorkingArea As FlowLayoutPanel

    <Category("Appearance"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public Property WorkingArea() As FlowLayoutPanel
        Get
            Return Me.pnlWorkingArea
        End Get
        Set(val As FlowLayoutPanel)
            Me.pnlWorkingArea = val
        End Set
    End Property

    Public Sub New()
        InitControl()
    End Sub
    Public Sub New(con As IContainer)
        con.Add(Me)
        InitControl()
    End Sub

    Private Sub InitControl()
        Me.SuspendLayout()
        Me.DoubleBuffered = True
        Me.Size = New Size(GroupboxConsts.DEFAULT_COLLECTION_WIDTH, GroupboxConsts.DEFAULT_COLLECTION_HEIGHT)
        Dim rc As New ResizeableControl(Me)
        Me.Padding = New Padding(mPadding)

        pnlWorkingArea = New FlowLayoutPanel()
        Me.Controls.Add(pnlWorkingArea)
        pnlWorkingArea.Size = Me.Size
        pnlWorkingArea.Location = New Point(0, 0)
        pnlWorkingArea.AutoScroll = True
        pnlWorkingArea.Dock = DockStyle.Fill
        pnlWorkingArea.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight
        'Me.Controls.Add(pnlWorkingArea)
        Me.ResumeLayout(False)
    End Sub

    Private Sub mypaint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        'e.Graphics.Clear(Color.FromArgb(255, Color.White))
        MyBase.BackColor = Color.FromArgb(0, Color.White)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = New Rectangle(0, 0, Width, Height)
        Dim borderPen As Pen = New Pen(BorderColor, BorderThickness)
        Dim backBrush As SolidBrush = New SolidBrush(Me.BackColor)
        DrawHelpers.DrawRoundedRectangle(e.Graphics, rect, BorderRadius, borderPen, backBrush)

        'Dim rectView As Rectangle = New Rectangle(0, 0, Width, Height) 'Drawing Rounded Rectangle

        'e.Graphics.ExcludeClip(rectView)
    End Sub
    Private Sub My_Scroll(sender As Object, e As ScrollEventArgs) Handles pnlWorkingArea.Scroll
        Me.Invalidate()
    End Sub

    Private Sub MyControlAdded(sender As Object, e As ControlEventArgs) Handles pnlWorkingArea.ControlAdded
        If IsValidControl(e.Control) Then
            mGroupboxCount = pnlWorkingArea.Controls.Count
            e.Control.Width = GetGroupboxWidth()
            UpdateLayout()
        End If
    End Sub

    Private Sub MyControlRemoved(sender As Object, e As ControlEventArgs) Handles pnlWorkingArea.ControlRemoved
        mGroupboxCount = pnlWorkingArea.Controls.Count
        UpdateLayout()
    End Sub

    Private Sub MySizeChanged(sender As Object, e As EventArgs) Handles pnlWorkingArea.SizeChanged
        UpdateLayout()
    End Sub


    Public Function AddGroupbox() As MetroGroupBox
        Dim newControl As MetroGroupBox = New MetroGroupBox()
        'newControl.Width = GetGroupboxWidth()
        pnlWorkingArea.Controls.Add(newControl)
        Return newControl
    End Function

    Public Sub AddGroupbox(ByRef _control As MetroGroupBox)
        '_control.Width = GetGroupboxWidth()
        pnlWorkingArea.Controls.Add(_control)
    End Sub

    Private Function GetGroupboxWidth() As Integer
        Dim nWidth As Integer
        nWidth = Me.Width - mPadding * 2 - pnlWorkingArea.Margin.Left - pnlWorkingArea.Margin.Right
        If pnlWorkingArea.VerticalScroll.Visible Then
            nWidth -= System.Windows.Forms.SystemInformation.VerticalScrollBarWidth
        End If
        For Each _control As MetroGroupBox In pnlWorkingArea.Controls
            If _control.GroupboxHeightOption = HeightOptions.Expanable Then
                nWidth = Math.Max(nWidth, _control.Width)
            End If
        Next
        Return nWidth
    End Function

    Public Sub RemoveGroupbox(ByVal _control As Control)
        If pnlWorkingArea.Controls.Contains(_control) Then
            pnlWorkingArea.Controls.Remove(_control)
        End If
    End Sub
    ' if idx is -1, remove last one
    Public Sub RemoveGroupboxAt(ByVal idx As Integer)
        If idx < 0 Then
            If pnlWorkingArea.Controls.Count > 0 Then
                pnlWorkingArea.Controls.RemoveAt(pnlWorkingArea.Controls.Count - 1)
            End If
        Else
            If pnlWorkingArea.Controls.Count > idx Then
                pnlWorkingArea.Controls.RemoveAt(idx)
            End If
        End If
    End Sub

    Private Sub UpdateLayout()
        Dim nControlCnt As Integer = pnlWorkingArea.Controls.Count
        Dim nOffsetX As Integer = mPadding + 3 + pnlWorkingArea.Margin.Left
        Dim nOffsetY As Integer = mPadding + 3 + pnlWorkingArea.Margin.Top
        Dim nTopY As Integer = nOffsetX
        'Update location
        For i As Integer = 0 To nControlCnt - 1
            pnlWorkingArea.Controls.Item(i).SuspendLayout()
        Next
        Me.SuspendLayout()

        Dim childGroupbox As MetroGroupBox
        For i As Integer = 0 To nControlCnt - 1
            childGroupbox = TryCast(pnlWorkingArea.Controls.Item(i), MetroGroupBox)
            childGroupbox.Location = New Point(nOffsetY, nTopY)
            If childGroupbox.AutoSize Then
                childGroupbox.AutoSize = False
                childGroupbox.Width = GetGroupboxWidth()
                childGroupbox.AutoSize = True
            Else
                childGroupbox.Width = GetGroupboxWidth()
            End If
            nTopY += pnlWorkingArea.Controls.Item(i).Height + GROUPBOX_GAP
        Next

        For i As Integer = 0 To nControlCnt - 1
            pnlWorkingArea.Controls.Item(i).ResumeLayout(False)
        Next
        Me.Refresh()
    End Sub

    Private Function IsValidControl(_control As Control) As Boolean
        If _control.GetType() IsNot GetType(MetroGroupBox) Then
            'MessageBox.Show("You can add only MetroGroupBox control.")
            pnlWorkingArea.Controls.Remove(_control)
            Return False
        End If
        Return True
    End Function
End Class







Public Class MetroGroupBox
    Inherits Panel
    Friend WithEvents titleContainer As Panel = New Panel()
    Friend WithEvents titleExpandMark As Label = New Label()
    Friend WithEvents titleLabel As Label = New Label()

    Public Event ExpandEvent(ByVal sender As Object)
    Public Event CollapseEvent(ByVal sender As Object)
    Private nOriginHeight As Integer
    Private mExpanded As Boolean = True
#Region "Groupbox Item Properties"
    ''' <summary>
    ''' Groupbox Items' Propertie
    ''' </summary>
    Private mGroupboxTitleText As String = GroupboxConsts.DEFAULT_GROUPBOX_TITLE_TEXT
    Public Property GroupboxTitleText As String
        Get
            Return mGroupboxTitleText
        End Get
        Set(value As String)
            mGroupboxTitleText = value
            titleLabel.Text = value
        End Set
    End Property

    Private mGroupboxTitleBackgroundColor As Color = GroupboxConsts.DEFAULT_GROUPBOX_TITLE_BACKGROUND_COLOR
    Public Property GroupboxTitleBackgroundColor As Color
        Get
            Return mGroupboxTitleBackgroundColor
        End Get
        Set(value As Color)
            mGroupboxTitleBackgroundColor = value
            'titleLabel.BackColor = value
            titleContainer.BackColor = value
        End Set
    End Property

    Private mGroupboxTitleTextColor As Color = GroupboxConsts.DEFAULT_GROUPBOX_TITLE_TEXT_COLOR
    Public Property GroupboxTitleTextColor As Color
        Get
            Return mGroupboxTitleTextColor
        End Get
        Set(value As Color)
            mGroupboxTitleTextColor = value
            titleLabel.ForeColor = value
            titleExpandMark.ForeColor = value
        End Set
    End Property

    Private mGroupboxTitleTextFont As Font = GroupboxConsts.DEFAULT_GROUPBOX_TITLE_FONT
    Public Property GroupboxTitleTextFont As Font
        Get
            Return mGroupboxTitleTextFont
        End Get
        Set(value As Font)
            mGroupboxTitleTextFont = value
            Me.titleLabel.Font = value
            Me.titleLabel.AutoSize = True
            titleContainer.Height = GetTitleHeight()
        End Set
    End Property

    Private mGroupboxBorderColor As Color = GroupboxConsts.DEFAULT_GROUPBOX_BORDER_COLOR
    Public Property GroupboxBorderColor As Color
        Get
            Return mGroupboxBorderColor
        End Get
        Set(value As Color)
            mGroupboxBorderColor = value
            Me.Refresh()
        End Set
    End Property

    Private mGroupboxBorderThickness As Integer = GroupboxConsts.DEFAULT_GROUPBOX_BORDER_THICKNESS
    Public Property GroupboxBorderThickness As Integer
        Get
            Return mGroupboxBorderThickness
        End Get
        Set(value As Integer)
            mGroupboxBorderThickness = value
            Me.Refresh()
        End Set
    End Property

    Private mGroupboxBorderRadius As Integer = GroupboxConsts.DEFAULT_GROUPBOX_BORDER_RADIUS
    Public Property GroupboxBorderRadius As Integer
        Get
            Return mGroupboxBorderRadius
        End Get
        Set(value As Integer)
            mGroupboxBorderRadius = value
            Me.Refresh()
        End Set
    End Property

    Private mGroupboxEnableCollapsable As Boolean = GroupboxConsts.DEFAULT_GROUPBOX_COLLAPSABLE
    Public Property GroupboxEnableCollapsable As Boolean
        Get
            Return mGroupboxEnableCollapsable
        End Get
        Set(value As Boolean)
            mGroupboxEnableCollapsable = value
            If Not mGroupboxEnableCollapsable Then
                Expand()
                Me.titleExpandMark.Text = ""
            End If
        End Set
    End Property

    Private mGroupboxHeightOption As HeightOptions = GroupboxConsts.DEFAULT_GROUPBOX_HEIGHT_OPTION
    Public Property GroupboxHeightOption As HeightOptions
        Get
            Return mGroupboxHeightOption
        End Get
        Set(value As HeightOptions)
            mGroupboxHeightOption = value
            UpdateHeight()
        End Set
    End Property
#End Region

    Sub New()
        InitControl(GroupboxConsts.DEFAULT_GROUPBOX_WIDTH)
    End Sub

    Private Sub InitControl(ByVal nWidth As Integer)
        Me.titleContainer.SuspendLayout()
        Me.SuspendLayout()

        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.DoubleBuffered = True
        Me.Size = New Size(nWidth, GroupboxConsts.DEFAULT_GROUPBOX_HEIGHT)
        Me.AutoScroll = True

        Me.Controls.Add(titleContainer)
        Me.titleContainer.Controls.Add(Me.titleLabel)
        Me.titleContainer.Controls.Add(Me.titleExpandMark)
        Me.titleContainer.Location = New System.Drawing.Point(0, 0)
        Me.titleContainer.BackColor = GroupboxTitleBackgroundColor
        Me.titleContainer.Padding = New Padding(5)

        Me.titleExpandMark.AutoSize = True
        Me.titleExpandMark.Dock = System.Windows.Forms.DockStyle.Right
        Me.titleExpandMark.Font = GroupboxTitleTextFont
        Me.titleExpandMark.Text = "-"
        Me.titleExpandMark.ForeColor = GroupboxTitleTextColor

        Me.titleLabel.AutoSize = True
        Me.titleLabel.Dock = System.Windows.Forms.DockStyle.Left
        Me.titleLabel.Font = GroupboxTitleTextFont
        Me.titleLabel.Text = GroupboxTitleText
        Me.titleLabel.ForeColor = GroupboxTitleTextColor

        Me.titleContainer.Size = New System.Drawing.Size(nWidth, GetTitleHeight())

        Me.titleContainer.ResumeLayout(False)
        Me.ResumeLayout(False)
        'MessageBox.Show("Creaated")

    End Sub

    Private Sub mypaint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        MyBase.BackColor = Color.FromArgb(0, Color.White)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = New Rectangle(0, 0, Width, Height) 'Drawing Rounded Rectangle
        Dim borderPen As Pen = New Pen(GroupboxBorderColor, GroupboxBorderThickness)
        Dim backBrush As SolidBrush = New SolidBrush(Me.BackColor)
        DrawHelpers.DrawRoundedRectangle(e.Graphics, rect, GroupboxBorderRadius, borderPen, backBrush)
    End Sub

    Private Function GetTitleHeight() As Integer
        Return titleLabel.Height + 5 * 2
    End Function
    Private Sub My_Scroll(sender As Object, e As ScrollEventArgs) Handles Me.Scroll
        Me.titleContainer.Location = New Point(0, 0)
    End Sub
    Private Sub My_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.titleContainer.Size = New Size(Me.Width, GetTitleHeight)
        Me.titleContainer.MaximumSize = New Size(Me.Width, GetTitleHeight)
        'MessageBox.Show(Me.Size.ToString())
    End Sub

    Private Sub My_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Validated
        Me.titleContainer.Size = New Size(Me.Width, GetTitleHeight)
    End Sub
    Private Sub Title_Click(sender As Object, e As EventArgs) Handles titleContainer.Click
        CollapseOrExpand()
    End Sub
    Private Sub TitleText_Click(sender As Object, e As EventArgs) Handles titleLabel.Click
        CollapseOrExpand()
    End Sub
    Private Sub TitleMark_Click(sender As Object, e As EventArgs) Handles titleExpandMark.Click
        CollapseOrExpand()
    End Sub
    Private Sub CollapseOrExpand()
        If GroupboxEnableCollapsable = False Then
            Return
        End If

        If mExpanded Then
            Collapse()
        Else
            Expand()
        End If
    End Sub

    Private Sub UpdateHeight()
        If mExpanded Then
            If GroupboxHeightOption = HeightOptions.Expanable Then
                Me.AutoScroll = False
                Me.AutoSize = True
                Me.SetAutoSizeMode(AutoSizeMode.GrowAndShrink)
            Else
                Me.AutoSize = False
                Me.AutoScroll = True
                Me.Height = nOriginHeight
            End If

        Else
            nOriginHeight = Me.Height
            Me.AutoSize = False
            Me.AutoScroll = False
            Me.Height = GetTitleHeight()
        End If
    End Sub

    Public Sub Expand()
        If mExpanded Then
            Return
        End If
        mExpanded = True
        Me.titleExpandMark.Text = "-"
        UpdateHeight()
        RaiseEvent ExpandEvent(Me)
        Me.Refresh()
    End Sub

    Public Sub Collapse()
        If Not GroupboxEnableCollapsable Or Not mExpanded Then
            Return
        End If
        mExpanded = False
        Me.titleExpandMark.Text = "+"
        UpdateHeight()
        RaiseEvent CollapseEvent(Me)
        Me.Refresh()
    End Sub
End Class





#Region "BASE"
Public Module DrawHelpers

    Dim Height As Integer
    Dim Width As Integer

    Public Function RoundRect(ByVal rect As Rectangle, ByVal slope As Integer) As GraphicsPath
        Dim gp As GraphicsPath = New GraphicsPath()
        Dim arcWidth As Integer = slope * 2
        gp.AddArc(New Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180, 90)
        gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90, 90)
        gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0, 90)
        gp.AddArc(New Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90, 90)
        gp.CloseAllFigures()
        Return gp
    End Function

    Public Function RoundRectangle(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

    Public Function RoundRectLogin(x!, y!, w!, h!, Optional r! = 0.3, Optional TL As Boolean = True, Optional TR As Boolean = True, Optional BR As Boolean = True, Optional BL As Boolean = True) As GraphicsPath
        Dim d! = Math.Min(w, h) * r, xw = x + w, yh = y + h
        RoundRectLogin = New GraphicsPath

        With RoundRectLogin
            If TL Then .AddArc(x, y, d, d, 180, 90) Else .AddLine(x, y, x, y)
            If TR Then .AddArc(xw - d, y, d, d, 270, 90) Else .AddLine(xw, y, xw, y)
            If BR Then .AddArc(xw - d, yh - d, d, d, 0, 90) Else .AddLine(xw, yh, xw, yh)
            If BL Then .AddArc(x, yh - d, d, d, 90, 90) Else .AddLine(x, yh, x, yh)

            .CloseFigure()
        End With
    End Function

    Public Function TopRoundRect(ByVal rect As Rectangle, ByVal slope As Integer) As GraphicsPath
        Dim gp As GraphicsPath = New GraphicsPath
        Dim arcWidth As Integer = slope * 2
        gp.AddArc(New Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180, 90)
        gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90, 90)
        gp.AddLine(New Point(rect.X + rect.Width, rect.Y + arcWidth), New Point(rect.X + rect.Width, rect.Y + rect.Height))
        gp.AddLine(New Point(rect.X + rect.Width, rect.Y + rect.Height), New Point(rect.X, rect.Y + rect.Height))
        gp.AddLine(New Point(rect.X, rect.Y + rect.Height), New Point(rect.X, rect.Y + arcWidth))
        gp.CloseAllFigures()
        Return gp
    End Function

    Public Function LeftRoundRect(ByVal rect As Rectangle, ByVal slope As Integer) As GraphicsPath
        Dim gp As GraphicsPath = New GraphicsPath()
        Dim arcWidth As Integer = slope * 2
        gp.AddArc(New Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180, 90)
        gp.AddLine(New Point(rect.X + arcWidth, rect.Y), New Point(rect.Width, rect.Y))
        gp.AddLine(New Point(rect.X + rect.Width, rect.Y), New Point(rect.X + rect.Width, rect.Y + rect.Height))
        gp.AddLine(New Point(rect.X + rect.Width, rect.Y + rect.Height), New Point(rect.X + arcWidth, rect.Y + rect.Height))
        gp.AddArc(New Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90, 90)
        gp.CloseAllFigures()
        Return gp
    End Function

    Public Function TabControlRect(ByVal rect As Rectangle, ByVal slope As Integer) As GraphicsPath
        Dim gp As GraphicsPath = New GraphicsPath()
        Dim arcWidth As Integer = slope * 2
        gp.AddLine(New Point(rect.X, rect.Y), New Point(rect.X, rect.Y))
        gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90, 90)
        gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0, 90)
        gp.AddArc(New Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90, 90)
        gp.CloseAllFigures()
        Return gp
    End Function

    Public Sub ShadowedString(ByVal g As Graphics, ByVal s As String, ByVal font As Font, ByVal brush As Brush, ByVal pos As Point)
        g.DrawString(s, font, Brushes.Black, New Point(pos.X + 1, pos.Y + 1))
        g.DrawString(s, font, brush, pos)
    End Sub

    Public Function getSmallerRect(ByVal rect As Rectangle, ByVal value As Integer) As Rectangle
        Return New Rectangle(rect.X + value, rect.Y + value, rect.Width - (value * 2), rect.Height - (value * 2))
    End Function

    Public Function AlterColor(ByVal original As Color, Optional ByVal amount As Integer = -20) As Color
        Dim c As Color = original, a As Integer = amount
        Dim r, g, b As Integer
        If c.R + a < 0 Then
            r = 0
        ElseIf c.R + a > 255 Then
            r = 255
        Else
            r = c.R + a
        End If
        If c.G + a < 0 Then
            g = 0
        ElseIf c.G + a > 255 Then
            g = 255
        Else
            g = c.G + a
        End If
        If c.B + a < 0 Then
            b = 0
        ElseIf c.B + a > 255 Then
            b = 255
        Else
            b = c.B + a
        End If
        Return Color.FromArgb(r, g, b)
    End Function

    Public Sub DrawCross(ByVal Graphics As Graphics, ByVal Bounds As Rectangle, ByVal Fill As LinearGradientBrush, ByVal Size As Integer, Optional ByVal Angle As Integer = 0)
        Using Path As New GraphicsPath()
            Path.AddRectangle(New Rectangle(((Bounds.X + Bounds.Width + (Size \ 2)) \ 2), Bounds.Y, Size, Bounds.Height))
            Path.AddRectangle(New Rectangle(Bounds.X, ((Bounds.Y + Bounds.Height + (Size \ 2)) \ 2), Bounds.Width, Size))
            Path.AddRectangle(New Rectangle(((Bounds.X + Bounds.Width + (Size \ 2)) \ 2), ((Bounds.Y + Bounds.Height + (Size \ 2)) \ 2), Size, Size))
            If (Angle > 0) AndAlso (Angle < 360) Then
                Graphics.TranslateTransform(((Bounds.X + Bounds.Width + Size) \ 2), ((Bounds.Y + Bounds.Height + Size) \ 2))
                Graphics.RotateTransform(CSng(Angle))
                Graphics.TranslateTransform(-((Bounds.X + Bounds.Width + Size) \ 2), -((Bounds.Y + Bounds.Height + Size) \ 2))
            End If
            Graphics.FillPath(Fill, Path)
        End Using
    End Sub

    Public Sub DrawRoundedRectangle(ByVal Graphics As Graphics, ByVal Bounds As Rectangle, ByVal Radius As Integer, ByVal Outline As Pen, ByVal Fill As Brush)
        Dim Stroke As Integer = Convert.ToInt32(Math.Ceiling(Outline.Width))
        Dim Offset As Integer = Convert.ToInt32(Math.Ceiling(Stroke / 2))
        Bounds = Rectangle.Inflate(Bounds, -Offset, -Offset)

        Outline.EndCap = Outline.StartCap = LineCap.Round
        If Radius > 0 Then
            Using Path As New GraphicsPath()
                Path.AddLine(Bounds.X + Radius, Bounds.Y, Bounds.X + Bounds.Width - (Radius * 2), Bounds.Y)
                Path.AddArc(Bounds.X + Bounds.Width - (Radius * 2), Bounds.Y, Radius * 2, Radius * 2, 270, 90)
                Path.AddLine(Bounds.X + Bounds.Width, Bounds.Y + Radius, Bounds.X + Bounds.Width, Bounds.Y + Bounds.Height - (Radius * 2))
                Path.AddArc(Bounds.X + Bounds.Width - (Radius * 2), Bounds.Y + Bounds.Height - (Radius * 2), Radius * 2, Radius * 2, 0, 90)
                Path.AddLine(Bounds.X + Bounds.Width - (Radius * 2), Bounds.Y + Bounds.Height, Bounds.X + Radius, Bounds.Y + Bounds.Height)
                Path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - (Radius * 2), Radius * 2, Radius * 2, 90, 90)
                Path.AddLine(Bounds.X, Bounds.Y + Bounds.Height - (Radius * 2), Bounds.X, Bounds.Y + Radius)
                Path.AddArc(Bounds.X, Bounds.Y, Radius * 2, Radius * 2, 180, 90)
                Path.CloseFigure()
                'Graphics.FillPath(Fill, Path)
                Graphics.DrawPath(Outline, Path)
            End Using
        Else
            'Graphics.FillRectangle(Fill, Bounds)
            Graphics.DrawRectangle(Outline, Bounds)
        End If
    End Sub

    Public Sub FillGradientBeam(ByVal g As Graphics, ByVal Col1 As Color, ByVal Col2 As Color, ByVal rect As Rectangle, ByVal align As GradientAlignment)
        Dim stored As SmoothingMode = g.SmoothingMode
        Dim Blend As New ColorBlend
        g.SmoothingMode = SmoothingMode.HighQuality
        Select Case align
            Case GradientAlignment.Vertical
                Dim PathGradient As New LinearGradientBrush(New Point(rect.X, rect.Y), New Point(rect.X + rect.Width - 1, rect.Y), Color.Black, Color.Black)
                Blend.Positions = {0, 1 / 2, 1}
                Blend.Colors = {Col1, Col2, Col1}
                PathGradient.InterpolationColors = Blend
                g.FillRectangle(PathGradient, rect)
            Case GradientAlignment.Horizontal
                Dim PathGradient As New LinearGradientBrush(New Point(rect.X, rect.Y), New Point(rect.X, rect.Y + rect.Height), Color.Black, Color.Black)
                Blend.Positions = {0, 1 / 2, 1}
                Blend.Colors = {Col1, Col2, Col1}
                PathGradient.InterpolationColors = Blend
                PathGradient.RotateTransform(0)
                g.FillRectangle(PathGradient, rect)
        End Select
        g.SmoothingMode = stored
    End Sub

    Public Sub DrawTextWithShadow(ByVal G As Graphics, ByVal ContRect As Rectangle, ByVal Text As String, ByVal TFont As Font, ByVal TAlign As HorizontalAlignment, ByVal TColor As Color, ByVal BColor As Color)
        DrawText(G, New Rectangle(ContRect.X + 1, ContRect.Y + 1, ContRect.Width, ContRect.Height), Text, TFont, TAlign, BColor)
        DrawText(G, ContRect, Text, TFont, TAlign, TColor)
    End Sub

    Public Sub FillDualGradPath(ByVal g As Graphics, ByVal Col1 As Color, ByVal Col2 As Color, ByVal rect As Rectangle, ByVal gp As GraphicsPath, ByVal align As GradientAlignment)
        Dim stored As SmoothingMode = g.SmoothingMode
        Dim Blend As New ColorBlend
        g.SmoothingMode = SmoothingMode.HighQuality
        Select Case align
            Case GradientAlignment.Vertical
                Dim PathGradient As New LinearGradientBrush(New Point(rect.X, rect.Y), New Point(rect.X + rect.Width - 1, rect.Y), Color.Black, Color.Black)
                Blend.Positions = {0, 1 / 2, 1}
                Blend.Colors = {Col1, Col2, Col1}
                PathGradient.InterpolationColors = Blend
                g.FillPath(PathGradient, gp)
            Case GradientAlignment.Horizontal
                Dim PathGradient As New LinearGradientBrush(New Point(rect.X, rect.Y), New Point(rect.X, rect.Y + rect.Height), Color.Black, Color.Black)
                Blend.Positions = {0, 1 / 2, 1}
                Blend.Colors = {Col1, Col2, Col1}
                PathGradient.InterpolationColors = Blend
                PathGradient.RotateTransform(0)
                g.FillPath(PathGradient, gp)
        End Select
        g.SmoothingMode = stored
    End Sub

    Public Sub DrawText(ByVal G As Graphics, ByVal ContRect As Rectangle, ByVal Text As String, ByVal TFont As Font, ByVal TAlign As HorizontalAlignment, ByVal TColor As Color)
        If String.IsNullOrEmpty(Text) Then Return
        Dim TextSize As Size = G.MeasureString(Text, TFont).ToSize
        Dim CenteredY As Integer = ContRect.Height \ 2 - TextSize.Height \ 2
        Select Case TAlign
            Case HorizontalAlignment.Left
                Dim sf As New StringFormat
                sf.LineAlignment = StringAlignment.Near
                sf.Alignment = StringAlignment.Near
                G.DrawString(Text, TFont, New SolidBrush(TColor), New Rectangle(ContRect.X, ContRect.Y + ContRect.Height / 2 - TextSize.Height / 2, ContRect.Width, ContRect.Height), sf)
            Case HorizontalAlignment.Right
                Dim sf As New StringFormat
                sf.LineAlignment = StringAlignment.Far
                sf.Alignment = StringAlignment.Far
                G.DrawString(Text, TFont, New SolidBrush(TColor), New Rectangle(ContRect.X, ContRect.Y, ContRect.Width, ContRect.Height / 2 + TextSize.Height / 2), sf)
            Case HorizontalAlignment.Center
                Dim sf As New StringFormat
                sf.LineAlignment = StringAlignment.Center
                sf.Alignment = StringAlignment.Center
                G.DrawString(Text, TFont, New SolidBrush(TColor), ContRect, sf)
        End Select
    End Sub

    Public Class Palette
        Public ColHighest As Color
        Public ColHigh As Color
        Public ColMed As Color
        Public ColDim As Color
        Public ColDark As Color
    End Class

    Public Enum GradientAlignment As Byte
        Vertical = 0
        Horizontal = 1
    End Enum


    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum
End Module

Public Module GroupboxConsts

#Region "Declarations"
    Public Const GROUPBOX_GAP As Integer = 20
    Public Const DEFAULT_COLLECTION_WIDTH As Integer = 218
    Public Const DEFAULT_COLLECTION_HEIGHT As Integer = 250

    Public Const DEFAULT_GROUPBOX_WIDTH As Integer = 200
    Public Const DEFAULT_GROUPBOX_HEIGHT As Integer = 100
    Public DEFAULT_GROUPBOX_TITLE_BACKGROUND_COLOR As Color = System.Drawing.SystemColors.GradientActiveCaption
    Public DEFAULT_GROUPBOX_TITLE_FONT As Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
    Public DEFAULT_GROUPBOX_TITLE_TEXT_COLOR As Color = Color.White
    Public DEFAULT_GROUPBOX_TITLE_TEXT As String = "Title"
    Public DEFAULT_GROUPBOX_BORDER_COLOR As Color = System.Drawing.SystemColors.GradientInactiveCaption
    Public Const DEFAULT_GROUPBOX_BORDER_THICKNESS As Integer = 1
    Public Const DEFAULT_GROUPBOX_BORDER_RADIUS As Integer = 0
    Public DEFAULT_GROUPBOX_COLLAPSABLE As Boolean = True
    Public DEFAULT_GROUPBOX_HEIGHT_OPTION As HeightOptions = HeightOptions.Fixed

    Public Enum HeightOptions
        Fixed
        Expanable
    End Enum
#End Region

End Module

Public Class ResizeableControl

    Private WithEvents mControl As Control
    Private mMouseDown As Boolean = False
    Private mEdge As EdgeEnum = EdgeEnum.None
    Private mWidth As Integer = 4
    Private mOutlineDrawn As Boolean = False

    Private Enum EdgeEnum
        None
        Right
        Left
        Top
        Bottom
        TopLeft
    End Enum

    Public Sub New(ByVal Control As Control)
        mControl = Control
    End Sub

    Private Sub mControl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            mMouseDown = True
        End If
    End Sub

    Private Sub mControl_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseUp
        mMouseDown = False
    End Sub

    Private Sub mControl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseMove
        Dim c As Control = CType(sender, Control)
        Dim g As Graphics = c.CreateGraphics
        Select Case mEdge
            Case EdgeEnum.TopLeft
                'g.FillRectangle(Brushes.GreenYellow, 0, 0, mWidth * 4, mWidth * 4)
                mOutlineDrawn = True
            Case EdgeEnum.Left
                'g.FillRectangle(Brushes.GreenYellow, 0, 0, mWidth, c.Height)
                mOutlineDrawn = True
            Case EdgeEnum.Right
                'g.FillRectangle(Brushes.GreenYellow, c.Width - mWidth, 0, c.Width, c.Height)
                mOutlineDrawn = True
            Case EdgeEnum.Top
                'g.FillRectangle(Brushes.GreenYellow, 0, 0, c.Width, mWidth)
                mOutlineDrawn = True
            Case EdgeEnum.Bottom
                'g.FillRectangle(Brushes.GreenYellow, 0, c.Height - mWidth, c.Width, mWidth)
                mOutlineDrawn = True
            Case EdgeEnum.None
                If mOutlineDrawn Then
                    c.Refresh()
                    mOutlineDrawn = False
                End If
        End Select

        If mMouseDown And mEdge <> EdgeEnum.None Then
            c.SuspendLayout()
            Select Case mEdge
                Case EdgeEnum.TopLeft
                    c.SetBounds(c.Left + e.X, c.Top + e.Y, c.Width, c.Height)
                Case EdgeEnum.Left
                    c.SetBounds(c.Left + e.X, c.Top, c.Width - e.X, c.Height)
                Case EdgeEnum.Right
                    c.SetBounds(c.Left, c.Top, c.Width - (c.Width - e.X), c.Height)
                Case EdgeEnum.Top
                    c.SetBounds(c.Left, c.Top + e.Y, c.Width, c.Height - e.Y)
                Case EdgeEnum.Bottom
                    c.SetBounds(c.Left, c.Top, c.Width, c.Height - (c.Height - e.Y))
            End Select
            c.ResumeLayout()
            c.Refresh()
        Else
            Select Case True
                Case e.X <= (mWidth * 4) And e.Y <= (mWidth * 4) 'top left corner
                    c.Cursor = Cursors.SizeAll
                    mEdge = EdgeEnum.TopLeft
                Case e.X <= mWidth 'left edge
                    c.Cursor = Cursors.VSplit
                    mEdge = EdgeEnum.Left
                Case e.X > c.Width - (mWidth + 1) 'right edge
                    c.Cursor = Cursors.VSplit
                    mEdge = EdgeEnum.Right
                Case e.Y <= mWidth 'top edge
                    c.Cursor = Cursors.HSplit
                    mEdge = EdgeEnum.Top
                Case e.Y > c.Height - (mWidth + 1) 'bottom edge
                    c.Cursor = Cursors.HSplit
                    mEdge = EdgeEnum.Bottom
                Case Else 'no edge
                    c.Cursor = Cursors.Default
                    mEdge = EdgeEnum.None
            End Select
        End If
    End Sub

    Private Sub mControl_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mControl.MouseLeave
        Dim c As Control = CType(sender, Control)
        mEdge = EdgeEnum.None
        c.Refresh()
    End Sub

End Class

#End Region




'#Region "GROUPBOX_COLLECTION_DESIGNER"
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")>
Public Class MetroGroupboxCollectionDesigner
    Inherits ParentControlDesigner

    'Private lists As DesignerActionListCollection

    Public Overrides Sub Initialize(component As System.ComponentModel.IComponent)
        MyBase.Initialize(component)
        Dim content As Panel = DirectCast(Me.Control, GroupboxCollection).WorkingArea
        EnableDesignMode(content, "WorkingArea")
    End Sub

    'Use pull model To populate smart tag menu. 
    'Public Overrides ReadOnly Property ActionLists() _
    'As DesignerActionListCollection
    '    Get
    '        If lists Is Nothing Then
    '            lists = New DesignerActionListCollection()
    '            lists.Add(
    '            New MetroGroupboxCollectionActionList(Me.Component))
    '        End If
    '        Return lists
    '    End Get
    'End Property
End Class

'Public Class MetroGroupboxCollectionActionList
'    Inherits DesignerActionList

'    Private metroGroupboxCollection As GroupboxCollection

'    Private designerActionUISvc As DesignerActionUIService = Nothing

'    The constructor associates the control  
'    With the smart tag list. 
'    Public Sub New(ByVal component As IComponent)

'        MyBase.New(component)
'        Me.metroGroupboxCollection = component

'        Cache a reference To DesignerActionUIService, so the 
'         DesignerActionList can be refreshed. 
'        Me.designerActionUISvc =
'        CType(GetService(GetType(DesignerActionUIService)),
'        DesignerActionUIService)

'    End Sub

'    Helper method To retrieve control properties. Use Of  
'     GetProperties enables undo And menu updates To work properly. 
'    Private Function GetPropertyByName(ByVal propName As String) _
'    As PropertyDescriptor
'        Dim prop As PropertyDescriptor
'        prop = TypeDescriptor.GetProperties(metroGroupboxCollection)(propName)
'        If prop Is Nothing Then
'            Throw New ArgumentException(
'            "Matching ColorLabel property not found!", propName)
'        Else
'            Return prop
'        End If
'    End Function

'    Properties that are targets Of DesignerActionPropertyItem entries. 
'    Public Property BorderColor() As Color
'        Get
'            Return metroGroupboxCollection.BorderColor
'        End Get
'        Set(ByVal value As Color)
'            GetPropertyByName("BorderColor").SetValue(metroGroupboxCollection, value)
'        End Set
'    End Property

'    Public Property BorderThickness() As Integer
'        Get
'            Return metroGroupboxCollection.BorderThickness
'        End Get
'        Set(ByVal value As Integer)
'            GetPropertyByName("BorderThickness").SetValue(metroGroupboxCollection, value)
'        End Set
'    End Property

'    Public Property BorderRadius() As Integer
'        Get
'            Return metroGroupboxCollection.BorderRadius
'        End Get
'        Set(ByVal value As Integer)
'            GetPropertyByName("BorderRadius").SetValue(metroGroupboxCollection, value)
'        End Set
'    End Property

'    Public Property GroupboxCount() As Integer
'        Get
'            Return metroGroupboxCollection.GroupboxCount
'        End Get
'        Set(ByVal value As Integer)
'            GetPropertyByName("GroupboxCount").SetValue(metroGroupboxCollection, value)
'        End Set
'    End Property

'    Public Sub AddGroupbox()
'TODO:   Add GroupBox Logic Here
'    End Sub
'    Implementation of this virtual method creates smart tag   
'     items, associates their targets, And collects into list. 
'    Public Overrides Function GetSortedActionItems() _
'    As DesignerActionItemCollection
'        Dim items As New DesignerActionItemCollection()

'        Define static section header entries.
'        items.Add(New DesignerActionHeaderItem("Appearance"))
'        items.Add(New DesignerActionHeaderItem("Behavior"))
'        items.Add(New DesignerActionHeaderItem("Information"))

'        items.Add(
'        New DesignerActionPropertyItem(
'        "BorderColor",
'        "Border Color",
'        "Appearance",
'        "Selects the border color."))

'        items.Add(
'        New DesignerActionPropertyItem(
'        "BorderThickness",
'        "Border Thickness",
'        "Appearance",
'        "Inserts the border thickness."))

'        items.Add(
'        New DesignerActionPropertyItem(
'        "BorderRadius",
'        "Border Radius",
'        "Appearance",
'        "Inserts the border corner radius."))

'        This next method item Is also added to the context menu  
'         (as a designer verb).
'        items.Add(
'        New DesignerActionMethodItem(
'        Me,
'        "AddGroupbox",
'        "Add Groupbox",
'        "Behavior",
'        "Add new groupbox.",
'        True))

'        Create entries for static Information section. 
'        items.Add(
'        New DesignerActionTextItem(
'        Convert.ToString(GroupboxCount),
'        "Information"))
'        Return items
'    End Function

'End Class
'#End Region
