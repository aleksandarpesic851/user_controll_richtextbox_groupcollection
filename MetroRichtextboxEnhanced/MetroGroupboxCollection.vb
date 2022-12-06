Imports System.IO
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

<System.ComponentModel.Designer(GetType(MetroGroupboxCollection.Designer))>
Public Class MetroGroupboxCollection
    Inherits UserControl

    Private Panel1 As Panel
    Public Class Designer
        Inherits System.Windows.Forms.Design.ParentControlDesigner

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)
            Dim content As Panel = DirectCast(Me.Control, MetroGroupboxCollection).Content
            EnableDesignMode(content, "Content")

        End Sub
        'Public Overrides Function CanParent(control As Control) As Boolean
        '    Return False
        'End Function

        'Protected Overrides Sub OnDragOver(de As DragEventArgs)
        '    de.Effect = DragDropEffects.None
        'End Sub
        'Protected Overrides Function CreateToolCore(tool As ToolboxItem, x As Integer, y As Integer, width As Integer, height As Integer, hasLocation As Boolean, hasSize As Boolean) As IComponent()
        '    Return Nothing
        'End Function
    End Class

    Public Class MyPanelDesigner
        Inherits System.Windows.Forms.Design.ParentControlDesigner

        Public Overrides ReadOnly Property SelectionRules As SelectionRules
            Get
                Dim _selectionRules As SelectionRules = MyBase.SelectionRules
                _selectionRules &= Not SelectionRules.AllSizeable
                Return _selectionRules
            End Get
        End Property

        Protected Overrides Sub PostFilterAttributes(attributes As IDictionary)
            MyBase.PostFilterAttributes(attributes)
            attributes(GetType(DockingAttribute)) = New DockingAttribute(DockingBehavior.Never)
        End Sub

        Protected Overrides Sub PostFilterProperties(properties As IDictionary)

            MyBase.PostFilterProperties(properties)
            Dim propertiesToRemove As String() = {
                "Dock", "Anchor",
                "Size", "Location", "Width", "Height",
                "MinimumSize", "MaximumSize",
                "AutoSize", "AutoSizeMode",
                "Visible", "Enabled"
            }
            For Each item As String In propertiesToRemove
                If properties.Contains(item) Then
                    properties(item) = TypeDescriptor.CreateProperty(Me.Component.GetType(), DirectCast(properties(item), PropertyDescriptor), New BrowsableAttribute(False))
                End If
            Next
        End Sub
    End Class
    <Category("Appearance")>
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)>
    Public ReadOnly Property Content() As Panel
        Get
            Return Panel1
        End Get
    End Property

#Region "Declarations"
    Private Const DEFAULT_GROUPBOX_WIDTH As Integer = 200
    Private Const DEFAULT_GROUPBOX_HEIGHT As Integer = 200
    Private DEFAULT_GROUPBOX_TITLE_BACKGROUND_COLOR As Color = System.Drawing.SystemColors.ActiveCaption
    Private DEFAULT_GROUPBOX_TITLE_FONT As Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
    Private DEFAULT_GROUPBOX_TITLE_TEXT_COLOR As Color = Color.White
    Private Const DEFAULT_GROUPBOX_TITLE_TEXT As String = "Title"
    Private DEFAULT_GROUPBOX_BORDER_COLOR As Color = Color.Black
    Private Const DEFAULT_GROUPBOX_BORDER_THICKNESS As Integer = 1
    Private Const DEFAULT_GROUPBOX_BORDER_RADIUS As Integer = 0
    Private DEFAULT_GROUPBOX_COLLAPSABLE As Boolean = False
    Private DEFAULT_GROUPBOX_HEIGHT_OPTION As HeightOptions = HeightOptions.Fixed

    Private Const WS_EX_TRANSPARENT As Integer = &H20
    Public Enum HeightOptions
        Fixed
        Expanable
    End Enum
#End Region

    Public Sub New()
        SetStyle(ControlStyles.Opaque, True)
        Me.Size = New Size(DEFAULT_GROUPBOX_WIDTH, DEFAULT_GROUPBOX_HEIGHT * 1.2)
        Me.Padding = New Padding(3)
        Me.Controls.Add(mGroupboxs(0))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Dock = DockStyle.Top
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(20, 100)
        Me.Panel1.BackColor = Color.Yellow
        Me.Controls.Add(Me.Panel1)
        TypeDescriptor.AddAttributes(Me.Content, New DesignerAttribute(GetType(Designer)))
        'Me.AutoSize = True
        'Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    End Sub
    Public Sub New(con As IContainer)
        con.Add(Me)
    End Sub

#Region "Properties"

#Region "Groupbox Item Properties"
    Public mGroupboxs As MetroGroupbox() = {New MetroGroupbox()}


    ''' <summary>
    ''' Groupbox Items' Propertie
    ''' </summary>
    Private mGroupboxTitleTexts As String() = {DEFAULT_GROUPBOX_TITLE_TEXT}
    Public Property GroupboxTitleTexts As String()
        Get
            Return mGroupboxTitleTexts
        End Get
        Set(value As String())
            mGroupboxTitleTexts = value
            GroupboxCount = value.Length
        End Set
    End Property

    Private mGroupboxTitleBackgroundColors As Color() = {DEFAULT_GROUPBOX_TITLE_BACKGROUND_COLOR}
    Public Property GroupboxTitleBackgroundColors As Color()
        Get
            Return mGroupboxTitleBackgroundColors
        End Get
        Set(value As Color())
            mGroupboxTitleBackgroundColors = value
            GroupboxCount = value.Length
        End Set
    End Property

    Private mGroupboxTitleTextColors As Color() = {DEFAULT_GROUPBOX_TITLE_TEXT_COLOR}
    Public Property GroupboxTitleTextColors As Color()
        Get
            Return mGroupboxTitleTextColors
        End Get
        Set(value As Color())
            mGroupboxTitleTextColors = value
            GroupboxCount = value.Length
        End Set
    End Property

    Private mGroupboxTitleTextFonts As Font() = {DEFAULT_GROUPBOX_TITLE_FONT}
    Public Property GroupboxTitleTextFonts As Font()
        Get
            Return mGroupboxTitleTextFonts
        End Get
        Set(value As Font())
            mGroupboxTitleTextFonts = value
            GroupboxCount = value.Length
        End Set
    End Property

    Private mGroupboxBorderColors As Color() = {DEFAULT_GROUPBOX_BORDER_COLOR}
    Public Property GroupboxBorderColors As Color()
        Get
            Return mGroupboxBorderColors
        End Get
        Set(value As Color())
            mGroupboxBorderColors = value
            GroupboxCount = value.Length
        End Set
    End Property

    Private mGroupboxBorderThicknesses As Integer() = {DEFAULT_GROUPBOX_BORDER_THICKNESS}
    Public Property GroupboxBorderThicknesses As Integer()
        Get
            Return mGroupboxBorderThicknesses
        End Get
        Set(value As Integer())
            mGroupboxBorderThicknesses = value
            GroupboxCount = value.Length
        End Set
    End Property

    Private mGroupboxBorderRadiuses As Integer() = {DEFAULT_GROUPBOX_BORDER_RADIUS}
    Public Property GroupboxBorderRadiuses As Integer()
        Get
            Return mGroupboxBorderRadiuses
        End Get
        Set(value As Integer())
            mGroupboxBorderRadiuses = value
            GroupboxCount = value.Length
        End Set
    End Property

    Private mGroupboxEnableCollapses As Boolean() = {DEFAULT_GROUPBOX_COLLAPSABLE}
    Public Property GroupboxEnableCollapses As Boolean()
        Get
            Return mGroupboxEnableCollapses
        End Get
        Set(value As Boolean())
            mGroupboxEnableCollapses = value
            GroupboxCount = value.Length
        End Set
    End Property

    Private mGroupboxHeightOptions As HeightOptions() = {DEFAULT_GROUPBOX_HEIGHT_OPTION}
    Public Property GroupboxHeightOptions As HeightOptions()
        Get
            Return mGroupboxHeightOptions
        End Get
        Set(value As HeightOptions())
            mGroupboxHeightOptions = value
            GroupboxCount = value.Length
        End Set
    End Property
#End Region

#Region "Collection Properties"
    ''' <summary>
    ''' Collection Properties
    ''' </summary>
    Private mBorderColor As Color = Color.Black
    Public Property BorderColor As Color
        Get
            Return mBorderColor
        End Get
        Set(value As Color)
            mBorderColor = value
            'TODO: Refresh Collection
        End Set
    End Property

    Private mBorderThickness As Integer = 1
    Public Property BorderThickness As Integer
        Get
            Return mBorderThickness
        End Get
        Set(value As Integer)
            mBorderThickness = value
            'TODO: Refresh Collection
        End Set
    End Property

    Private mBorderRadius As Integer = 1
    Public Property BorderRadius As Integer
        Get
            Return mBorderRadius
        End Get
        Set(value As Integer)
            mBorderRadius = value
            'TODO: Refresh Collection
        End Set
    End Property

    Private mCollectionWidth As Integer = DEFAULT_GROUPBOX_WIDTH
    Public Property CollectionWidth As Integer
        Get
            Return mCollectionWidth
        End Get
        Set(value As Integer)
            mCollectionWidth = value
            UpdateProperties()
        End Set
    End Property

    Private mGroupboxCount As Integer = 1
    Public Property GroupboxCount As Integer
        Get
            Return mGroupboxCount
        End Get
        Set(value As Integer)
            mGroupboxCount = value
            UpdateProperties()
        End Set
    End Property


#End Region

#End Region

#Region "Functions"

    Private Sub UpdateProperties()
        Dim oldLength As Integer

        ReDim Preserve mGroupboxs(GroupboxCount - 1)

        oldLength = mGroupboxBorderColors.Length
        ReDim Preserve mGroupboxBorderColors(GroupboxCount - 1)
        For i As Integer = oldLength To GroupboxCount - 1
            mGroupboxBorderColors(i) = DEFAULT_GROUPBOX_BORDER_COLOR
        Next

        oldLength = mGroupboxTitleBackgroundColors.Length
        ReDim Preserve mGroupboxTitleBackgroundColors(GroupboxCount - 1)
        For i As Integer = oldLength To GroupboxCount - 1
            mGroupboxTitleBackgroundColors(i) = DEFAULT_GROUPBOX_TITLE_BACKGROUND_COLOR
        Next

        oldLength = mGroupboxTitleTextColors.Length
        ReDim Preserve mGroupboxTitleTextColors(GroupboxCount - 1)
        For i As Integer = oldLength To GroupboxCount - 1
            mGroupboxTitleTextColors(i) = DEFAULT_GROUPBOX_TITLE_TEXT_COLOR
        Next

        oldLength = mGroupboxTitleTextFonts.Length
        ReDim Preserve mGroupboxTitleTextFonts(GroupboxCount - 1)
        For i As Integer = oldLength To GroupboxCount - 1
            mGroupboxTitleTextFonts(i) = DEFAULT_GROUPBOX_TITLE_FONT
        Next

        oldLength = mGroupboxBorderThicknesses.Length
        ReDim Preserve mGroupboxBorderThicknesses(GroupboxCount - 1)
        For i As Integer = oldLength To GroupboxCount - 1
            mGroupboxBorderThicknesses(i) = DEFAULT_GROUPBOX_BORDER_THICKNESS
        Next

        oldLength = mGroupboxBorderRadiuses.Length
        ReDim Preserve mGroupboxBorderRadiuses(GroupboxCount - 1)
        For i As Integer = oldLength To GroupboxCount - 1
            mGroupboxBorderRadiuses(i) = DEFAULT_GROUPBOX_BORDER_RADIUS
        Next

        oldLength = mGroupboxEnableCollapses.Length
        ReDim Preserve mGroupboxEnableCollapses(GroupboxCount - 1)
        For i As Integer = oldLength To GroupboxCount - 1
            mGroupboxEnableCollapses(i) = DEFAULT_GROUPBOX_COLLAPSABLE
        Next

        oldLength = mGroupboxHeightOptions.Length
        ReDim Preserve mGroupboxHeightOptions(GroupboxCount - 1)
        For i As Integer = oldLength To GroupboxCount - 1
            mGroupboxHeightOptions(i) = DEFAULT_GROUPBOX_HEIGHT_OPTION
        Next

        oldLength = mGroupboxTitleTexts.Length
        ReDim Preserve mGroupboxTitleTexts(GroupboxCount - 1)
        For i As Integer = oldLength To GroupboxCount - 1
            mGroupboxTitleTexts(i) = DEFAULT_GROUPBOX_TITLE_TEXT
        Next

        UpdateControls()
    End Sub
    Private Sub UpdateControls()
        Me.SuspendLayout()

        For i As Integer = 0 To mGroupboxs.Length - 1
            If IsNothing(mGroupboxs(i)) Then
                mGroupboxs(i) = New MetroGroupbox()
                Me.Controls.Add(mGroupboxs(i))
            End If
            'mGroupboxs(i).TitleTextColor = GroupboxTitleTextColors(i)
            'mGroupboxs(i).TitleTextFont = GroupboxTitleTextFonts(i)
            'mGroupboxs(i).TitleBackgroundColor = GroupboxTitleBackgroundColors(i)
            'mGroupboxs(i).TitleText = GroupboxTitleTexts(i)
            'mGroupboxs(i).BorderColor = GroupboxBorderColors(i)
            'mGroupboxs(i).BorderThickness = GroupboxBorderThicknesses(i)
            'mGroupboxs(i).BorderRadius = GroupboxBorderRadiuses(i)
            'mGroupboxs(i).EnableCollapsable = GroupboxEnableCollapses(i)
            'mGroupboxs(i).HeightOption = GroupboxHeightOptions(i)
            'mGroupboxs(i).MyWidth = CollectionWidth

            'mGroupboxs(i).UpdateProps()
        Next

        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
#End Region

    <Category("MetroGroupbox Properties")>
    Protected Overrides ReadOnly Property CreateParams() _
           As CreateParams
        Get
            Dim cpar As CreateParams = MyBase.CreateParams
            cpar.ExStyle = cpar.ExStyle Or WS_EX_TRANSPARENT
            Return cpar
        End Get
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Using brush = New SolidBrush(Me.BackColor)
            e.Graphics.FillRectangle(brush, Me.ClientRectangle)
        End Using
        MyBase.OnPaint(e)
    End Sub

End Class



Public Class MetroGroupbox
    Inherits ContainerBase

    Private _Border As Boolean
    Private _BackColor As Color
    Private _BackColorGradient As Color
    Private _TitleColor As Color
    Private _TitleColorGradient As Color
    Private _BorderColor As Color
    Private _ForeColor As Color
    Private _Opacity As Integer
    Private HeaderColor, TextColor As Brush

    Sub New()

        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        'MyBase.LockWidth = 500
        MyBase.Size = New Size(200, 200)
        _BorderColor = Color.Black
        ControlMode = True
        Dock = DockStyle.Top
        'SetColor("Border", _BorderColor)
        _Border = True
        _ForeColor = Color.White
        Text = "Title"
        _BackColor = Color.FromArgb(255, 80, 80, 80)
        _BackColorGradient = Color.FromArgb(150, 64, 64, 64)
        _TitleColor = Color.FromArgb(255, 32, 32, 32)
        _TitleColorGradient = Color.FromArgb(255, 48, 48, 48)
    End Sub

    <Category("MetroGroupbox Properties")>
    Public Property [BackColor] As Color
        Get
            Return _BackColor
        End Get
        Set(ByVal value As Color)
            _BackColor = value

        End Set
    End Property
    <Category("MetroGroupbox Properties")>
    Public Property BackColorGradient As Color
        Get
            Return _BackColorGradient
        End Get
        Set(ByVal value As Color)
            _BackColorGradient = value

        End Set
    End Property

    <Category("MetroGroupbox Properties")>
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value

        End Set
    End Property

    <Category("MetroGroupbox Properties")>
    Public Property TitleColor As Color
        Get
            Return _TitleColor
        End Get
        Set(ByVal value As Color)
            _TitleColor = value

        End Set
    End Property
    <Category("MetroGroupbox Properties")>
    Public Property TitleColorGradient As Color
        Get
            Return _TitleColorGradient
        End Get
        Set(ByVal value As Color)
            _TitleColorGradient = value

        End Set
    End Property
    <Category("MetroGroupbox Properties")>
    Public Property ForeColors As Color
        Get
            Return _ForeColor
        End Get
        Set(ByVal value As Color)
            _ForeColor = value

        End Set
    End Property

    <Category("MetroGroupbox Properties")>
    Public Property Border As Boolean
        Get
            Return _Border
        End Get
        Set(ByVal value As Boolean)
            _Border = value

        End Set
    End Property

    <Browsable(False)>
    <Category("MetroGroupbox Properties")>
    Public Property Opacity As Integer
        Get
            Return _Opacity
        End Get
        Set(value As Integer)
            Dim v As Integer = value
            If v > 255 Then v = 255
            _Opacity = v
            Me.Invalidate()
        End Set
    End Property
    Protected Overrides Sub ColorHook()
        _BorderColor = Color.Black
        _ForeColor = Color.White
        _BackColor = Color.FromArgb(255, 80, 80, 80)
        _BackColorGradient = Color.FromArgb(150, 64, 64, 64)
        _TitleColor = Color.FromArgb(255, 32, 32, 32)
        _TitleColorGradient = Color.FromArgb(255, 48, 48, 48)
        _Opacity = 10

    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(_Opacity, _BackColor))
        ' Dim BackBg As New SolidBrush(Color.FromArgb(_Opacity, _BackColor))
        Dim BackBg As New LinearGradientBrush(New Rectangle(0, 0, Width, Height), _BackColor, _BackColorGradient, 90.0F)
        G.FillRectangle(BackBg, New Rectangle(0, 0, Width, Height))
        Dim TopBg As New LinearGradientBrush(New Rectangle(0, 0, Width, 25), _TitleColor, _TitleColorGradient, 90.0F)
        G.FillRectangle(TopBg, New Rectangle(0, 0, Width, 25))

        If _Border Then
            G.DrawRectangle(New Pen(_BorderColor), New Rectangle(0, 0, Width, 25))
            G.DrawRectangle(New Pen(_BorderColor), New Rectangle(0, 0, Width - 1, Height - 1))
        Else
        End If
        G.DrawString(Text, Font, New SolidBrush(_ForeColor), New Point(5, 6))

    End Sub

End Class


#Region "BASE"
Public MustInherit Class ContainerBase
    Inherits ContainerControl

#Region " Initialization "

    Protected G As Graphics, B As Bitmap

    Sub New()
        SetStyle(DirectCast(139270, ControlStyles), True)

        _ImageSize = Size.Empty
        Font = New Font("Verdana", 8S)

        MeasureBitmap = New Bitmap(1, 1)
        MeasureGraphics = Graphics.FromImage(MeasureBitmap)

        DrawRadialPath = New GraphicsPath

        InvalidateCustimization()
    End Sub

    Protected NotOverridable Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        If DoneCreation Then InitializeMessages()

        InvalidateCustimization()
        ColorHook()

        If Not _LockWidth = 0 Then Width = _LockWidth
        If Not _LockHeight = 0 Then Height = _LockHeight
        If Not _ControlMode Then MyBase.Dock = DockStyle.Fill

        Transparent = _Transparent
        If _Transparent AndAlso _BackColor Then BackColor = Color.Transparent

        MyBase.OnHandleCreated(e)
    End Sub

    Private DoneCreation As Boolean
    Protected NotOverridable Overrides Sub OnParentChanged(ByVal e As EventArgs)
        MyBase.OnParentChanged(e)

        If Parent Is Nothing Then Return
        _IsParentForm = TypeOf Parent Is Form

        If Not _ControlMode Then
            InitializeMessages()

            If _IsParentForm Then
                ParentForm.FormBorderStyle = _BorderStyle
                ParentForm.TransparencyKey = _TransparencyKey

                If Not DesignMode Then
                    AddHandler ParentForm.Shown, AddressOf FormShown
                End If
            End If

            Parent.BackColor = BackColor
        End If

        OnCreation()
        DoneCreation = True
        InvalidateTimer()
    End Sub

#End Region

    Private Sub DoAnimation(ByVal i As Boolean)
        OnAnimation()
        If i Then Invalidate()
    End Sub

    Protected NotOverridable Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Width = 0 OrElse Height = 0 Then Return

        If _Transparent AndAlso _ControlMode Then
            PaintHook()
            e.Graphics.DrawImage(B, 0, 0)
        Else
            G = e.Graphics
            PaintHook()
        End If
    End Sub

    Protected Overrides Sub OnHandleDestroyed(ByVal e As EventArgs)
        RemoveAnimationCallback(AddressOf DoAnimation)
        MyBase.OnHandleDestroyed(e)
    End Sub

    Private HasShown As Boolean
    Private Sub FormShown(ByVal sender As Object, ByVal e As EventArgs)
        If _ControlMode OrElse HasShown Then Return

        If _StartPosition = FormStartPosition.CenterParent OrElse _StartPosition = FormStartPosition.CenterScreen Then
            Dim SB As Rectangle = Screen.PrimaryScreen.Bounds
            Dim CB As Rectangle = ParentForm.Bounds
            ParentForm.Location = New Point(SB.Width \ 2 - CB.Width \ 2, SB.Height \ 2 - CB.Width \ 2)
        End If

        HasShown = True
    End Sub


#Region " Size Handling "

    Private Frame As Rectangle
    Protected NotOverridable Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If _Movable AndAlso Not _ControlMode Then
            Frame = New Rectangle(7, 7, Width - 14, _Header - 7)
        End If

        InvalidateBitmap()
        Invalidate()

        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overrides Sub SetBoundsCore(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal specified As BoundsSpecified)
        If Not _LockWidth = 0 Then width = _LockWidth
        If Not _LockHeight = 0 Then height = _LockHeight
        MyBase.SetBoundsCore(x, y, width, height, specified)
    End Sub

#End Region

#Region " State Handling "

    Protected State As MouseState
    Private Sub SetState(ByVal current As MouseState)
        State = current
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If Not (_IsParentForm AndAlso ParentForm.WindowState = FormWindowState.Maximized) Then
            If _Sizable AndAlso Not _ControlMode Then InvalidateMouse()
        End If

        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
        If Enabled Then SetState(MouseState.None) Else SetState(MouseState.Block)
        MyBase.OnEnabledChanged(e)
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        SetState(MouseState.Over)
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        SetState(MouseState.Over)
        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        SetState(MouseState.None)

        If GetChildAtPoint(PointToClient(MousePosition)) IsNot Nothing Then
            If _Sizable AndAlso Not _ControlMode Then
                Cursor = Cursors.Default
                Previous = 0
            End If
        End If

        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then SetState(MouseState.Down)

        If Not (_IsParentForm AndAlso ParentForm.WindowState = FormWindowState.Maximized OrElse _ControlMode) Then
            If _Movable AndAlso Frame.Contains(e.Location) Then
                Capture = False
                WM_LMBUTTONDOWN = True
                DefWndProc(Messages(0))
            ElseIf _Sizable AndAlso Not Previous = 0 Then
                Capture = False
                WM_LMBUTTONDOWN = True
                DefWndProc(Messages(Previous))
            End If
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Private WM_LMBUTTONDOWN As Boolean
    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        If WM_LMBUTTONDOWN AndAlso m.Msg = 513 Then
            WM_LMBUTTONDOWN = False

            SetState(MouseState.Over)
            If Not _SmartBounds Then Return

            If IsParentMdi Then
                CorrectBounds(New Rectangle(Point.Empty, Parent.Parent.Size))
            Else
                CorrectBounds(Screen.FromControl(Parent).WorkingArea)
            End If
        End If
    End Sub

    Private GetIndexPoint As Point
    Private B1, B2, B3, B4 As Boolean
    Private Function GetIndex() As Integer
        GetIndexPoint = PointToClient(MousePosition)
        B1 = GetIndexPoint.X < 7
        B2 = GetIndexPoint.X > Width - 7
        B3 = GetIndexPoint.Y < 7
        B4 = GetIndexPoint.Y > Height - 7

        If B1 AndAlso B3 Then Return 4
        If B1 AndAlso B4 Then Return 7
        If B2 AndAlso B3 Then Return 5
        If B2 AndAlso B4 Then Return 8
        If B1 Then Return 1
        If B2 Then Return 2
        If B3 Then Return 3
        If B4 Then Return 6
        Return 0
    End Function

    Private Current, Previous As Integer
    Private Sub InvalidateMouse()
        Current = GetIndex()
        If Current = Previous Then Return

        Previous = Current
        Select Case Previous
            Case 0
                Cursor = Cursors.Default
            Case 1, 2
                Cursor = Cursors.SizeWE
            Case 3, 6
                Cursor = Cursors.SizeNS
            Case 4, 8
                Cursor = Cursors.SizeNWSE
            Case 5, 7
                Cursor = Cursors.SizeNESW
        End Select
    End Sub

    Private Messages(8) As Message
    Private Sub InitializeMessages()
        Messages(0) = Message.Create(Parent.Handle, 161, New IntPtr(2), IntPtr.Zero)
        For I As Integer = 1 To 8
            Messages(I) = Message.Create(Parent.Handle, 161, New IntPtr(I + 9), IntPtr.Zero)
        Next
    End Sub

    Private Sub CorrectBounds(ByVal bounds As Rectangle)
        If Parent.Width > bounds.Width Then Parent.Width = bounds.Width
        If Parent.Height > bounds.Height Then Parent.Height = bounds.Height

        Dim X As Integer = Parent.Location.X
        Dim Y As Integer = Parent.Location.Y

        If X < bounds.X Then X = bounds.X
        If Y < bounds.Y Then Y = bounds.Y

        Dim Width As Integer = bounds.X + bounds.Width
        Dim Height As Integer = bounds.Y + bounds.Height

        If X + Parent.Width > Width Then X = Width - Parent.Width
        If Y + Parent.Height > Height Then Y = Height - Parent.Height

        Parent.Location = New Point(X, Y)
    End Sub

#End Region


#Region " Base Properties "

    Overrides Property Dock() As DockStyle
        Get
            Return MyBase.Dock
        End Get
        Set(ByVal value As DockStyle)
            If Not _ControlMode Then Return
            MyBase.Dock = value
        End Set
    End Property

    Private _BackColor As Boolean
    <Category("Misc")>
    Overrides Property BackColor() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            If value = MyBase.BackColor Then Return

            If Not IsHandleCreated AndAlso _ControlMode AndAlso value = Color.Transparent Then
                _BackColor = True
                Return
            End If

            MyBase.BackColor = value
            If Parent IsNot Nothing Then
                If Not _ControlMode Then Parent.BackColor = value
                ColorHook()
            End If
        End Set
    End Property

    Overrides Property MinimumSize() As Size
        Get
            Return MyBase.MinimumSize
        End Get
        Set(ByVal value As Size)
            MyBase.MinimumSize = value
            If Parent IsNot Nothing Then Parent.MinimumSize = value
        End Set
    End Property

    Overrides Property MaximumSize() As Size
        Get
            Return MyBase.MaximumSize
        End Get
        Set(ByVal value As Size)
            MyBase.MaximumSize = value
            If Parent IsNot Nothing Then Parent.MaximumSize = value
        End Set
    End Property

    Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            Invalidate()
        End Set
    End Property

    Overrides Property Font() As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            Invalidate()
        End Set
    End Property

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Overrides Property ForeColor() As Color
        Get
            Return Color.Empty
        End Get
        Set(ByVal value As Color)
        End Set
    End Property
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Overrides Property BackgroundImage() As Image
        Get
            Return Nothing
        End Get
        Set(ByVal value As Image)
        End Set
    End Property
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Overrides Property BackgroundImageLayout() As ImageLayout
        Get
            Return ImageLayout.None
        End Get
        Set(ByVal value As ImageLayout)
        End Set
    End Property

#End Region

#Region " Public Properties "

    Private _SmartBounds As Boolean = True
    Property SmartBounds() As Boolean
        Get
            Return _SmartBounds
        End Get
        Set(ByVal value As Boolean)
            _SmartBounds = value
        End Set
    End Property

    Private _Movable As Boolean = True
    Property Movable() As Boolean
        Get
            Return _Movable
        End Get
        Set(ByVal value As Boolean)
            _Movable = value
        End Set
    End Property

    Private _Sizable As Boolean = True
    Property Sizable() As Boolean
        Get
            Return _Sizable
        End Get
        Set(ByVal value As Boolean)
            _Sizable = value
        End Set
    End Property

    Private _TransparencyKey As Color
    Property TransparencyKey() As Color
        Get
            If _IsParentForm AndAlso Not _ControlMode Then Return ParentForm.TransparencyKey Else Return _TransparencyKey
        End Get
        Set(ByVal value As Color)
            If value = _TransparencyKey Then Return
            _TransparencyKey = value

            If _IsParentForm AndAlso Not _ControlMode Then
                ParentForm.TransparencyKey = value
                ColorHook()
            End If
        End Set
    End Property

    Private _BorderStyle As FormBorderStyle
    Property BorderStyle() As FormBorderStyle
        Get
            If _IsParentForm AndAlso Not _ControlMode Then Return ParentForm.FormBorderStyle Else Return _BorderStyle
        End Get
        Set(ByVal value As FormBorderStyle)
            _BorderStyle = value

            If _IsParentForm AndAlso Not _ControlMode Then
                ParentForm.FormBorderStyle = value

                If Not value = FormBorderStyle.None Then
                    Movable = False
                    Sizable = False
                End If
            End If
        End Set
    End Property

    Private _StartPosition As FormStartPosition
    Property StartPosition() As FormStartPosition
        Get
            If _IsParentForm AndAlso Not _ControlMode Then Return ParentForm.StartPosition Else Return _StartPosition
        End Get
        Set(ByVal value As FormStartPosition)
            _StartPosition = value

            If _IsParentForm AndAlso Not _ControlMode Then
                ParentForm.StartPosition = value
            End If
        End Set
    End Property

    Private _NoRounding As Boolean
    Property NoRounding() As Boolean
        Get
            Return _NoRounding
        End Get
        Set(ByVal v As Boolean)
            _NoRounding = v
            Invalidate()
        End Set
    End Property

    Private _Image As Image
    Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            If value Is Nothing Then _ImageSize = Size.Empty Else _ImageSize = value.Size

            _Image = value
            Invalidate()
        End Set
    End Property

    Private Items As New Dictionary(Of String, Color)
    Property Colors() As Bloom()
        Get
            Dim T As New List(Of Bloom)
            Dim E As Dictionary(Of String, Color).Enumerator = Items.GetEnumerator

            While E.MoveNext
                T.Add(New Bloom(E.Current.Key, E.Current.Value))
            End While

            Return T.ToArray
        End Get
        Set(ByVal value As Bloom())
            For Each B As Bloom In value
                If Items.ContainsKey(B.Name) Then Items(B.Name) = B.Value
            Next

            InvalidateCustimization()
            ColorHook()
            Invalidate()
        End Set
    End Property

    Private _Customization As String
    Property Customization() As String
        Get
            Return _Customization
        End Get
        Set(ByVal value As String)
            If value = _Customization Then Return

            Dim Data As Byte()
            Dim Items As Bloom() = Colors

            Try
                Data = Convert.FromBase64String(value)
                For I As Integer = 0 To Items.Length - 1
                    Items(I).Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4))
                Next
            Catch
                Return
            End Try

            _Customization = value

            Colors = Items
            ColorHook()
            Invalidate()
        End Set
    End Property

    Private _Transparent As Boolean
    Property Transparent() As Boolean
        Get
            Return _Transparent
        End Get
        Set(ByVal value As Boolean)
            _Transparent = value
            If Not (IsHandleCreated OrElse _ControlMode) Then Return

            If Not value AndAlso Not BackColor.A = 255 Then
                Throw New Exception("Unable to change value to false while a transparent BackColor is in use.")
            End If

            SetStyle(ControlStyles.Opaque, Not value)
            SetStyle(ControlStyles.SupportsTransparentBackColor, value)

            InvalidateBitmap()
            Invalidate()
        End Set
    End Property

#End Region

#Region " Private Properties "

    Private _ImageSize As Size
    Protected ReadOnly Property ImageSize() As Size
        Get
            Return _ImageSize
        End Get
    End Property

    Private _IsParentForm As Boolean
    Protected ReadOnly Property IsParentForm() As Boolean
        Get
            Return _IsParentForm
        End Get
    End Property

    Protected ReadOnly Property IsParentMdi() As Boolean
        Get
            If Parent Is Nothing Then Return False
            Return Parent.Parent IsNot Nothing
        End Get
    End Property

    Private _LockWidth As Integer
    Protected Property LockWidth() As Integer
        Get
            Return _LockWidth
        End Get
        Set(ByVal value As Integer)
            _LockWidth = value
            If Not LockWidth = 0 AndAlso IsHandleCreated Then Width = LockWidth
        End Set
    End Property

    Private _LockHeight As Integer
    Protected Property LockHeight() As Integer
        Get
            Return _LockHeight
        End Get
        Set(ByVal value As Integer)
            _LockHeight = value
            If Not LockHeight = 0 AndAlso IsHandleCreated Then Height = LockHeight
        End Set
    End Property

    Private _Header As Integer = 24
    Protected Property Header() As Integer
        Get
            Return _Header
        End Get
        Set(ByVal v As Integer)
            _Header = v

            If Not _ControlMode Then
                Frame = New Rectangle(7, 7, Width - 14, v - 7)
                Invalidate()
            End If
        End Set
    End Property

    Private _ControlMode As Boolean
    Protected Property ControlMode() As Boolean
        Get
            Return _ControlMode
        End Get
        Set(ByVal v As Boolean)
            _ControlMode = v

            Transparent = _Transparent
            If _Transparent AndAlso _BackColor Then BackColor = Color.Transparent

            InvalidateBitmap()
            Invalidate()
        End Set
    End Property

    Private _IsAnimated As Boolean
    Protected Property IsAnimated() As Boolean
        Get
            Return _IsAnimated
        End Get
        Set(ByVal value As Boolean)
            _IsAnimated = value
            InvalidateTimer()
        End Set
    End Property

#End Region


#Region " Property Helpers "

    Protected Function GetPen(ByVal name As String) As Pen
        Return New Pen(Items(name))
    End Function
    Protected Function GetPen(ByVal name As String, ByVal width As Single) As Pen
        Return New Pen(Items(name), width)
    End Function

    Protected Function GetBrush(ByVal name As String) As SolidBrush
        Return New SolidBrush(Items(name))
    End Function

    Protected Function GetColor(ByVal name As String) As Color
        Return Items(name)
    End Function

    Protected Sub SetColor(ByVal name As String, ByVal value As Color)
        If Items.ContainsKey(name) Then Items(name) = value Else Items.Add(name, value)
    End Sub
    Protected Sub SetColor(ByVal name As String, ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
        SetColor(name, Color.FromArgb(r, g, b))
    End Sub
    Protected Sub SetColor(ByVal name As String, ByVal a As Byte, ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
        SetColor(name, Color.FromArgb(a, r, g, b))
    End Sub
    Protected Sub SetColor(ByVal name As String, ByVal a As Byte, ByVal value As Color)
        SetColor(name, Color.FromArgb(a, value))
    End Sub

    Private Sub InvalidateBitmap()
        If _Transparent AndAlso _ControlMode Then
            If Width = 0 OrElse Height = 0 Then Return
            B = New Bitmap(Width, Height, PixelFormat.Format32bppPArgb)
            G = Graphics.FromImage(B)
        Else
            G = Nothing
            B = Nothing
        End If
    End Sub

    Private Sub InvalidateCustimization()
        Dim M As New MemoryStream(Items.Count * 4)

        For Each B As Bloom In Colors
            M.Write(BitConverter.GetBytes(B.Value.ToArgb), 0, 4)
        Next

        M.Close()
        _Customization = Convert.ToBase64String(M.ToArray)
    End Sub

    Private Sub InvalidateTimer()
        If DesignMode OrElse Not DoneCreation Then Return

        If _IsAnimated Then
            AddAnimationCallback(AddressOf DoAnimation)
        Else
            RemoveAnimationCallback(AddressOf DoAnimation)
        End If
    End Sub

#End Region


#Region " User Hooks "

    Protected MustOverride Sub ColorHook()
    Protected MustOverride Sub PaintHook()

    Protected Overridable Sub OnCreation()
    End Sub

    Protected Overridable Sub OnAnimation()
    End Sub

#End Region


#Region " Offset "

    Private OffsetReturnRectangle As Rectangle
    Protected Function Offset(ByVal r As Rectangle, ByVal amount As Integer) As Rectangle
        OffsetReturnRectangle = New Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2))
        Return OffsetReturnRectangle
    End Function

    Private OffsetReturnSize As Size
    Protected Function Offset(ByVal s As Size, ByVal amount As Integer) As Size
        OffsetReturnSize = New Size(s.Width + amount, s.Height + amount)
        Return OffsetReturnSize
    End Function

    Private OffsetReturnPoint As Point
    Protected Function Offset(ByVal p As Point, ByVal amount As Integer) As Point
        OffsetReturnPoint = New Point(p.X + amount, p.Y + amount)
        Return OffsetReturnPoint
    End Function

#End Region

#Region " Center "

    Private CenterReturn As Point

    Protected Function Center(ByVal p As Rectangle, ByVal c As Rectangle) As Point
        CenterReturn = New Point((p.Width \ 2 - c.Width \ 2) + p.X + c.X, (p.Height \ 2 - c.Height \ 2) + p.Y + c.Y)
        Return CenterReturn
    End Function
    Protected Function Center(ByVal p As Rectangle, ByVal c As Size) As Point
        CenterReturn = New Point((p.Width \ 2 - c.Width \ 2) + p.X, (p.Height \ 2 - c.Height \ 2) + p.Y)
        Return CenterReturn
    End Function

    Protected Function Center(ByVal child As Rectangle) As Point
        Return Center(Width, Height, child.Width, child.Height)
    End Function
    Protected Function Center(ByVal child As Size) As Point
        Return Center(Width, Height, child.Width, child.Height)
    End Function
    Protected Function Center(ByVal childWidth As Integer, ByVal childHeight As Integer) As Point
        Return Center(Width, Height, childWidth, childHeight)
    End Function

    Protected Function Center(ByVal p As Size, ByVal c As Size) As Point
        Return Center(p.Width, p.Height, c.Width, c.Height)
    End Function

    Protected Function Center(ByVal pWidth As Integer, ByVal pHeight As Integer, ByVal cWidth As Integer, ByVal cHeight As Integer) As Point
        CenterReturn = New Point(pWidth \ 2 - cWidth \ 2, pHeight \ 2 - cHeight \ 2)
        Return CenterReturn
    End Function

#End Region

#Region " Measure "

    Private MeasureBitmap As Bitmap
    Private MeasureGraphics As Graphics

    Protected Function Measure() As Size
        SyncLock MeasureGraphics
            Return MeasureGraphics.MeasureString(Text, Font, Width).ToSize
        End SyncLock
    End Function
    Protected Function Measure(ByVal text As String) As Size
        SyncLock MeasureGraphics
            Return MeasureGraphics.MeasureString(text, Font, Width).ToSize
        End SyncLock
    End Function

#End Region


#Region " DrawPixel "

    Private DrawPixelBrush As SolidBrush

    Protected Sub DrawPixel(ByVal c1 As Color, ByVal x As Integer, ByVal y As Integer)
        If _Transparent Then
            B.SetPixel(x, y, c1)
        Else
            DrawPixelBrush = New SolidBrush(c1)
            G.FillRectangle(DrawPixelBrush, x, y, 1, 1)
        End If
    End Sub

#End Region

#Region " DrawCorners "

    Private DrawCornersBrush As SolidBrush

    Protected Sub DrawCorners(ByVal c1 As Color, ByVal offset As Integer)
        DrawCorners(c1, 0, 0, Width, Height, offset)
    End Sub
    Protected Sub DrawCorners(ByVal c1 As Color, ByVal r1 As Rectangle, ByVal offset As Integer)
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset)
    End Sub
    Protected Sub DrawCorners(ByVal c1 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal offset As Integer)
        DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2))
    End Sub

    Protected Sub DrawCorners(ByVal c1 As Color)
        DrawCorners(c1, 0, 0, Width, Height)
    End Sub
    Protected Sub DrawCorners(ByVal c1 As Color, ByVal r1 As Rectangle)
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height)
    End Sub
    Protected Sub DrawCorners(ByVal c1 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        If _NoRounding Then Return

        If _Transparent Then
            B.SetPixel(x, y, c1)
            B.SetPixel(x + (width - 1), y, c1)
            B.SetPixel(x, y + (height - 1), c1)
            B.SetPixel(x + (width - 1), y + (height - 1), c1)
        Else
            DrawCornersBrush = New SolidBrush(c1)
            G.FillRectangle(DrawCornersBrush, x, y, 1, 1)
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1)
            G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1)
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1)
        End If
    End Sub

#End Region

#Region " DrawBorders "

    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal offset As Integer)
        DrawBorders(p1, 0, 0, Width, Height, offset)
    End Sub
    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal r As Rectangle, ByVal offset As Integer)
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset)
    End Sub
    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal offset As Integer)
        DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2))
    End Sub

    Protected Sub DrawBorders(ByVal p1 As Pen)
        DrawBorders(p1, 0, 0, Width, Height)
    End Sub
    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal r As Rectangle)
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height)
    End Sub
    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        G.DrawRectangle(p1, x, y, width - 1, height - 1)
    End Sub

#End Region

#Region " DrawText "

    Private DrawTextPoint As Point
    Private DrawTextSize As Size

    Protected Sub DrawText(ByVal b1 As Brush, ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        DrawText(b1, Text, a, x, y)
    End Sub
    Protected Sub DrawText(ByVal b1 As Brush, ByVal text As String, ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        If text.Length = 0 Then Return

        DrawTextSize = Measure(text)
        DrawTextPoint = New Point(Width \ 2 - DrawTextSize.Width \ 2, Header \ 2 - DrawTextSize.Height \ 2)

        Select Case a
            Case HorizontalAlignment.Left
                G.DrawString(text, Font, b1, x, DrawTextPoint.Y + y)
            Case HorizontalAlignment.Center
                G.DrawString(text, Font, b1, DrawTextPoint.X + x, DrawTextPoint.Y + y)
            Case HorizontalAlignment.Right
                G.DrawString(text, Font, b1, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y)
        End Select
    End Sub

    Protected Sub DrawText(ByVal b1 As Brush, ByVal p1 As Point)
        If Text.Length = 0 Then Return
        G.DrawString(Text, Font, b1, p1)
    End Sub
    Protected Sub DrawText(ByVal b1 As Brush, ByVal x As Integer, ByVal y As Integer)
        If Text.Length = 0 Then Return
        G.DrawString(Text, Font, b1, x, y)
    End Sub

#End Region

#Region " DrawImage "

    Private DrawImagePoint As Point

    Protected Sub DrawImage(ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        DrawImage(_Image, a, x, y)
    End Sub
    Protected Sub DrawImage(ByVal image As Image, ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        If image Is Nothing Then Return
        DrawImagePoint = New Point(Width \ 2 - image.Width \ 2, Header \ 2 - image.Height \ 2)

        Select Case a
            Case HorizontalAlignment.Left
                G.DrawImage(image, x, DrawImagePoint.Y + y, image.Width, image.Height)
            Case HorizontalAlignment.Center
                G.DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y, image.Width, image.Height)
            Case HorizontalAlignment.Right
                G.DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y, image.Width, image.Height)
        End Select
    End Sub

    Protected Sub DrawImage(ByVal p1 As Point)
        DrawImage(_Image, p1.X, p1.Y)
    End Sub
    Protected Sub DrawImage(ByVal x As Integer, ByVal y As Integer)
        DrawImage(_Image, x, y)
    End Sub

    Protected Sub DrawImage(ByVal image As Image, ByVal p1 As Point)
        DrawImage(image, p1.X, p1.Y)
    End Sub
    Protected Sub DrawImage(ByVal image As Image, ByVal x As Integer, ByVal y As Integer)
        If image Is Nothing Then Return
        G.DrawImage(image, x, y, image.Width, image.Height)
    End Sub

#End Region

#Region " DrawGradient "

    Private DrawGradientBrush As LinearGradientBrush
    Private DrawGradientRectangle As Rectangle

    Protected Sub DrawGradient(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        DrawGradientRectangle = New Rectangle(x, y, width, height)
        DrawGradient(blend, DrawGradientRectangle)
    End Sub
    Protected Sub DrawGradient(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        DrawGradientRectangle = New Rectangle(x, y, width, height)
        DrawGradient(blend, DrawGradientRectangle, angle)
    End Sub

    Protected Sub DrawGradient(ByVal blend As ColorBlend, ByVal r As Rectangle)
        DrawGradientBrush = New LinearGradientBrush(r, Color.Empty, Color.Empty, 90.0F)
        DrawGradientBrush.InterpolationColors = blend
        G.FillRectangle(DrawGradientBrush, r)
    End Sub
    Protected Sub DrawGradient(ByVal blend As ColorBlend, ByVal r As Rectangle, ByVal angle As Single)
        DrawGradientBrush = New LinearGradientBrush(r, Color.Empty, Color.Empty, angle)
        DrawGradientBrush.InterpolationColors = blend
        G.FillRectangle(DrawGradientBrush, r)
    End Sub


    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        DrawGradientRectangle = New Rectangle(x, y, width, height)
        DrawGradient(c1, c2, DrawGradientRectangle)
    End Sub
    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        DrawGradientRectangle = New Rectangle(x, y, width, height)
        DrawGradient(c1, c2, DrawGradientRectangle, angle)
    End Sub

    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal r As Rectangle)
        DrawGradientBrush = New LinearGradientBrush(r, c1, c2, 90.0F)
        G.FillRectangle(DrawGradientBrush, r)
    End Sub
    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal r As Rectangle, ByVal angle As Single)
        DrawGradientBrush = New LinearGradientBrush(r, c1, c2, angle)
        G.FillRectangle(DrawGradientBrush, r)
    End Sub

#End Region

#Region " DrawRadial "

    Private DrawRadialPath As GraphicsPath
    Private DrawRadialBrush1 As PathGradientBrush
    Private DrawRadialBrush2 As LinearGradientBrush
    Private DrawRadialRectangle As Rectangle

    Sub DrawRadial(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(blend, DrawRadialRectangle, width \ 2, height \ 2)
    End Sub
    Sub DrawRadial(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal center As Point)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(blend, DrawRadialRectangle, center.X, center.Y)
    End Sub
    Sub DrawRadial(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal cx As Integer, ByVal cy As Integer)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(blend, DrawRadialRectangle, cx, cy)
    End Sub

    Sub DrawRadial(ByVal blend As ColorBlend, ByVal r As Rectangle)
        DrawRadial(blend, r, r.Width \ 2, r.Height \ 2)
    End Sub
    Sub DrawRadial(ByVal blend As ColorBlend, ByVal r As Rectangle, ByVal center As Point)
        DrawRadial(blend, r, center.X, center.Y)
    End Sub
    Sub DrawRadial(ByVal blend As ColorBlend, ByVal r As Rectangle, ByVal cx As Integer, ByVal cy As Integer)
        DrawRadialPath.Reset()
        DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1)

        DrawRadialBrush1 = New PathGradientBrush(DrawRadialPath)
        DrawRadialBrush1.CenterPoint = New Point(r.X + cx, r.Y + cy)
        DrawRadialBrush1.InterpolationColors = blend

        If G.SmoothingMode = SmoothingMode.AntiAlias Then
            G.FillEllipse(DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3)
        Else
            G.FillEllipse(DrawRadialBrush1, r)
        End If
    End Sub


    Protected Sub DrawRadial(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(c1, c2, DrawGradientRectangle)
    End Sub
    Protected Sub DrawRadial(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(c1, c2, DrawGradientRectangle, angle)
    End Sub

    Protected Sub DrawRadial(ByVal c1 As Color, ByVal c2 As Color, ByVal r As Rectangle)
        DrawRadialBrush2 = New LinearGradientBrush(r, c1, c2, 90.0F)
        G.FillRectangle(DrawGradientBrush, r)
    End Sub
    Protected Sub DrawRadial(ByVal c1 As Color, ByVal c2 As Color, ByVal r As Rectangle, ByVal angle As Single)
        DrawRadialBrush2 = New LinearGradientBrush(r, c1, c2, angle)
        G.FillEllipse(DrawGradientBrush, r)
    End Sub

#End Region

#Region " CreateRound "

    Private CreateRoundPath As GraphicsPath
    Private CreateRoundRectangle As Rectangle

    Function CreateRound(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal slope As Integer) As GraphicsPath
        CreateRoundRectangle = New Rectangle(x, y, width, height)
        Return CreateRound(CreateRoundRectangle, slope)
    End Function

    Function CreateRound(ByVal r As Rectangle, ByVal slope As Integer) As GraphicsPath
        CreateRoundPath = New GraphicsPath(FillMode.Winding)
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F)
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F)
        CreateRoundPath.CloseFigure()
        Return CreateRoundPath
    End Function

#End Region

End Class

Public Class Bloom

    Private _Name As String
    Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Private _Value As Color
    Property Value() As Color
        Get
            Return _Value
        End Get
        Set(ByVal value As Color)
            _Value = value
        End Set
    End Property

    Sub New()
    End Sub

    Sub New(ByVal name As String, ByVal value As Color)
        _Name = name
        _Value = value
    End Sub
End Class

Module ThemeShare

#Region " Animation "

    Private Frames As Integer
    Private Invalidate As Boolean
    Public ThemeTimer As New PrecisionTimer

    Private Const FPS As Integer = 50 '1000 / 50 = 20 FPS
    Private Const Rate As Integer = 10

    Public Delegate Sub AnimationDelegate(ByVal invalidate As Boolean)

    Private Callbacks As New List(Of AnimationDelegate)

    Private Sub HandleCallbacks(ByVal state As IntPtr, ByVal reserve As Boolean)
        Invalidate = (Frames >= FPS)
        If Invalidate Then Frames = 0

        SyncLock Callbacks
            For I As Integer = 0 To Callbacks.Count - 1
                Callbacks(I).Invoke(Invalidate)
            Next
        End SyncLock

        Frames += Rate
    End Sub

    Private Sub InvalidateThemeTimer()
        If Callbacks.Count = 0 Then
            ThemeTimer.Delete()
        Else
            ThemeTimer.Create(0, Rate, AddressOf HandleCallbacks)
        End If
    End Sub

    Sub AddAnimationCallback(ByVal callback As AnimationDelegate)
        SyncLock Callbacks
            If Callbacks.Contains(callback) Then Return

            Callbacks.Add(callback)
            InvalidateThemeTimer()
        End SyncLock
    End Sub

    Sub RemoveAnimationCallback(ByVal callback As AnimationDelegate)
        SyncLock Callbacks
            If Not Callbacks.Contains(callback) Then Return

            Callbacks.Remove(callback)
            InvalidateThemeTimer()
        End SyncLock
    End Sub

#End Region

End Module

Public Class PrecisionTimer
    Implements IDisposable

    Private _Enabled As Boolean
    ReadOnly Property Enabled() As Boolean
        Get
            Return _Enabled
        End Get
    End Property

    Private Handle As IntPtr
    Private TimerCallback As TimerDelegate

    <DllImport("kernel32.dll", EntryPoint:="CreateTimerQueueTimer")>
    Private Shared Function CreateTimerQueueTimer(
    ByRef handle As IntPtr,
    ByVal queue As IntPtr,
    ByVal callback As TimerDelegate,
    ByVal state As IntPtr,
    ByVal dueTime As UInteger,
    ByVal period As UInteger,
    ByVal flags As UInteger) As Boolean
    End Function

    <DllImport("kernel32.dll", EntryPoint:="DeleteTimerQueueTimer")>
    Private Shared Function DeleteTimerQueueTimer(
    ByVal queue As IntPtr,
    ByVal handle As IntPtr,
    ByVal callback As IntPtr) As Boolean
    End Function

    Delegate Sub TimerDelegate(ByVal r1 As IntPtr, ByVal r2 As Boolean)

    Sub Create(ByVal dueTime As UInteger, ByVal period As UInteger, ByVal callback As TimerDelegate)
        If _Enabled Then Return

        TimerCallback = callback
        Dim Success As Boolean = CreateTimerQueueTimer(Handle, IntPtr.Zero, TimerCallback, IntPtr.Zero, dueTime, period, 0)

        If Not Success Then ThrowNewException("CreateTimerQueueTimer")
        _Enabled = Success
    End Sub

    Sub Delete()
        If Not _Enabled Then Return
        Dim Success As Boolean = DeleteTimerQueueTimer(IntPtr.Zero, Handle, IntPtr.Zero)

        If Not Success AndAlso Not Marshal.GetLastWin32Error = 997 Then
            ThrowNewException("DeleteTimerQueueTimer")
        End If

        _Enabled = Not Success
    End Sub

    Private Sub ThrowNewException(ByVal name As String)
        On Error Resume Next
        Throw New Exception(String.Format("{0} failed. Win32Error: {1}", name, Marshal.GetLastWin32Error))
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Delete()
    End Sub
End Class


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

    Public Sub DrawRoundedRectangle(ByVal Graphics As Graphics, ByVal Bounds As Rectangle, ByVal Radius As Integer, ByVal Outline As Pen, ByVal Fill As LinearGradientBrush)
        Dim Stroke As Integer = Convert.ToInt32(Math.Ceiling(Outline.Width))
        Bounds = Rectangle.Inflate(Bounds, -Stroke, -Stroke)
        Outline.EndCap = Outline.StartCap = LineCap.Round
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
            Graphics.FillPath(Fill, Path)
            Graphics.DrawPath(Outline, Path)
        End Using
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

#End Region