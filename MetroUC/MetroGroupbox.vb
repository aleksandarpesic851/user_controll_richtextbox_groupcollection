Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports Microsoft.DotNet.DesignTools.Designers

<Designer(GetType(GroupboxDesigner))>
Public Class MetroGroupbox
    <Category("Appearance"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public Property WorkingArea() As Panel
        Get
            Return Me.pnlWorkingArea
        End Get
        Set(val As Panel)
            Me.pnlWorkingArea = val
        End Set
    End Property

    Public Event ExpandEvent(ByVal sender As Object)
    Public Event CollapseEvent(ByVal sender As Object)
    Private nOriginHeight As Integer
    Private mExpanded As Boolean = True
#Region "Groupbox Item Properties"
    Private mGroupboxTitleText As String = GroupboxConsts.DEFAULT_GROUPBOX_TITLE_TEXT
    Public Property GroupboxTitleText As String
        Get
            Return mGroupboxTitleText
        End Get
        Set(value As String)
            mGroupboxTitleText = value
            Me.titleLabel.AutoSize = True
            Me.titleLabel.Text = value
            Me.Refresh()
        End Set
    End Property

    Private mGroupboxTitleBackgroundColor As Color = GroupboxConsts.DEFAULT_GROUPBOX_TITLE_BACKGROUND_COLOR
    Public Property GroupboxTitleBackgroundColor As Color
        Get
            Return mGroupboxTitleBackgroundColor
        End Get
        Set(value As Color)
            mGroupboxTitleBackgroundColor = value
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
            Me.titleExpandMark.Font = value
            Me.titleLabel.Location = New Point(0, (GroupboxTitleHeight - Me.titleLabel.Height) / 2)
            Me.titleExpandMark.Location = New Point(Me.Width - 45 - GroupboxBorderThickness, (GroupboxTitleHeight - Me.titleExpandMark.Height) / 2)
        End Set
    End Property

    Private mGroupboxTitleHeight As Integer = GroupboxConsts.DEFAULT_GROUPBOX_TITLE_HEIGHT
    Public Property GroupboxTitleHeight As Integer
        Get
            Return mGroupboxTitleHeight
        End Get
        Set(value As Integer)
            mGroupboxTitleHeight = value
            titleContainer.Height = value
            Me.titleLabel.Location = New Point(0, (GroupboxTitleHeight - Me.titleLabel.Height) / 2)
            Me.titleExpandMark.Location = New Point(Me.Width - 45 - GroupboxBorderThickness, (GroupboxTitleHeight - Me.titleExpandMark.Height) / 2)
            Me.Refresh()
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
            Me.Padding = New Padding(mGroupboxBorderThickness)
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
                Me.titleExpandMark.Text = "   "
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

    Dim rc As New ResizeableControl(Me)

    Private Sub mypaint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        MyBase.BackColor = Color.FromArgb(0, Color.White)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = New Rectangle(0, 0, Width, Height) 'Drawing Rounded Rectangle
        Dim borderPen As Pen = New Pen(GroupboxBorderColor, GroupboxBorderThickness)
        Dim backBrush As SolidBrush = New SolidBrush(Me.BackColor)
        DrawHelpers.DrawRoundedRectangle(e.Graphics, rect, GroupboxBorderRadius, borderPen, backBrush)
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
                Me.pnlWorkingArea.AutoScroll = False
                Me.titleExpandMark.Location = New Point(0, 0)
                Me.pnlWorkingArea.AutoSize = True
                Me.pnlWorkingArea.AutoSizeMode = AutoSizeMode.GrowAndShrink

                Me.AutoScroll = False
                Me.AutoSize = True
                Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
            Else
                Me.pnlWorkingArea.AutoScroll = True
                Me.pnlWorkingArea.AutoSize = False
                Me.AutoScroll = True
                Me.AutoSize = False
                If nOriginHeight > 1 Then
                    Me.Height = nOriginHeight
                End If
            End If

        Else
            nOriginHeight = Me.Height
            Me.Height = GroupboxTitleHeight + 2 * GroupboxBorderThickness
            Me.AutoSize = False
        End If
    End Sub

    Public Sub Expand()
        If mExpanded Then
            Return
        End If
        mExpanded = True
        Me.titleExpandMark.Text = " - "
        UpdateHeight()
        RaiseEvent ExpandEvent(Me)
        Me.Refresh()
    End Sub

    Public Sub Collapse()
        If Not GroupboxEnableCollapsable Or Not mExpanded Then
            Return
        End If
        mExpanded = False
        Me.titleExpandMark.Text = " + "
        UpdateHeight()
        RaiseEvent CollapseEvent(Me)
        Me.Refresh()
    End Sub

    Private Sub Groupbox_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.titleExpandMark.Location = New Point(Me.Width - 45 - GroupboxBorderThickness, (GroupboxTitleHeight - Me.titleExpandMark.Height) / 2)
        Me.titleContainer.Width = Me.Width - GroupboxBorderThickness * 2
        Me.pnlWorkingArea.Width = Me.Width - GroupboxBorderThickness * 2
        Me.Refresh()
    End Sub
End Class


'#Region "GROUPBOX_COLLECTION_DESIGNER"
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")>
Public Class GroupboxDesigner
    Inherits ParentControlDesigner
    Public Overrides Sub Initialize(component As System.ComponentModel.IComponent)
        MyBase.Initialize(component)
        Dim content As Panel = DirectCast(Me.Control, MetroGroupbox).WorkingArea
        EnableDesignMode(content, "WorkingArea")
    End Sub
End Class
