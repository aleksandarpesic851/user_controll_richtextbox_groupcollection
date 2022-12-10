Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports Microsoft.DotNet.DesignTools.Designers

<Designer(GetType(MetroGroupboxCollectionDesigner))>
Public Class MetroGroupboxCollection
    Inherits Panel

    Friend WithEvents pnlWorkingArea As FlowLayoutPanel
    Private mResizableObject As ResizeableControl

#Region "Collection Properties"
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
    End Property

    Private mGroupboxGrowToCollectionWidth As Boolean = False
    Public Property GroupboxGrowToCollectionWidth As Boolean
        Get
            Return mGroupboxGrowToCollectionWidth
        End Get
        Set(value As Boolean)
            mGroupboxGrowToCollectionWidth = value
            UpdateLayout(False)
        End Set
    End Property

    Private mEndUserCanResize As Boolean = True
    Public Property EndUserCanResize As Boolean
        Get
            Return mEndUserCanResize
        End Get
        Set(value As Boolean)
            mEndUserCanResize = value
            mResizableObject.EnabledResize = mEndUserCanResize
        End Set
    End Property


#End Region

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
        mResizableObject = New ResizeableControl(Me)
        Me.Padding = New Padding(mPadding)

        pnlWorkingArea = New FlowLayoutPanel()
        Me.Controls.Add(pnlWorkingArea)
        pnlWorkingArea.Size = Me.Size
        pnlWorkingArea.Location = New Point(0, 0)
        pnlWorkingArea.AutoScroll = True
        pnlWorkingArea.Dock = DockStyle.Fill
        pnlWorkingArea.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight

        Me.ResumeLayout(False)
    End Sub

    Private Sub mypaint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        MyBase.BackColor = Color.FromArgb(0, Color.White)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = New Rectangle(0, 0, Width, Height)
        Dim borderPen As Pen = New Pen(BorderColor, BorderThickness)
        Dim backBrush As SolidBrush = New SolidBrush(Me.BackColor)
        DrawHelpers.DrawRoundedRectangle(e.Graphics, rect, BorderRadius, borderPen, backBrush)
    End Sub
    Private Sub My_Scroll(sender As Object, e As ScrollEventArgs) Handles pnlWorkingArea.Scroll
        Me.Invalidate()
    End Sub

    Private Sub MyControlAdded(sender As Object, e As ControlEventArgs) Handles pnlWorkingArea.ControlAdded
        If IsValidControl(e.Control) Then
            mGroupboxCount = pnlWorkingArea.Controls.Count
            e.Control.Width = GetGroupboxWidth()
            UpdateLayout(False)
        End If
    End Sub

    Private Sub MyControlRemoved(sender As Object, e As ControlEventArgs) Handles pnlWorkingArea.ControlRemoved
        mGroupboxCount = pnlWorkingArea.Controls.Count
        UpdateLayout(False)
    End Sub

    Private Sub MySizeChanged(sender As Object, e As EventArgs) Handles pnlWorkingArea.SizeChanged
        UpdateLayout(True)
    End Sub


    Public Function AddGroupbox() As MetroGroupbox
        Dim newControl As MetroGroupbox = New MetroGroupbox()
        pnlWorkingArea.Controls.Add(newControl)
        Return newControl
    End Function

    Public Sub AddGroupbox(ByRef _control As MetroGroupbox)
        '_control.Width = GetGroupboxWidth()
        pnlWorkingArea.Controls.Add(_control)
    End Sub

    Private Function GetGroupboxWidth() As Integer
        Dim nWidth As Integer
        nWidth = Me.Width - mPadding * 2 - pnlWorkingArea.Margin.Left - pnlWorkingArea.Margin.Right
        If pnlWorkingArea.VerticalScroll.Visible Then
            nWidth -= System.Windows.Forms.SystemInformation.VerticalScrollBarWidth
        End If
        For Each _control As MetroGroupbox In pnlWorkingArea.Controls
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

    Private Sub UpdateLayout(ByVal onlySize As Boolean)
        Dim nControlCnt As Integer = pnlWorkingArea.Controls.Count
        Dim nOffsetX As Integer = mPadding + 3 + pnlWorkingArea.Margin.Left
        Dim nOffsetY As Integer = mPadding + 3 + pnlWorkingArea.Margin.Top
        Dim nTopY As Integer = nOffsetX

        For i As Integer = 0 To nControlCnt - 1
            pnlWorkingArea.Controls.Item(i).SuspendLayout()
        Next
        Me.SuspendLayout()

        Dim childGroupbox As MetroGroupbox
        For i As Integer = 0 To nControlCnt - 1
            childGroupbox = TryCast(pnlWorkingArea.Controls.Item(i), MetroGroupbox)
            If Not onlySize Then
                childGroupbox.Location = New Point(nOffsetY, nTopY)
            End If
            If Not GroupboxGrowToCollectionWidth Then
                Continue For
            End If
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
        Me.ResumeLayout(False)
    End Sub

    Private Function IsValidControl(_control As Control) As Boolean
        If _control.GetType() IsNot GetType(MetroGroupbox) Then
            pnlWorkingArea.Controls.Remove(_control)
            Return False
        End If
        Return True
    End Function
End Class







<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")>
Public Class MetroGroupboxCollectionDesigner
    Inherits ParentControlDesigner

    Public Overrides Sub Initialize(component As System.ComponentModel.IComponent)
        MyBase.Initialize(component)
        Dim content As Panel = DirectCast(Me.Control, MetroGroupboxCollection).WorkingArea
        EnableDesignMode(content, "WorkingArea")
    End Sub
End Class