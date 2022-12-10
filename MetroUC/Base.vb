Imports System.Drawing.Drawing2D

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
    Public DEFAULT_GROUPBOX_TITLE_HEIGHT As Integer = 50
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
    Public EnabledResize As Boolean = True

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
        If e.Button = Windows.Forms.MouseButtons.Left And EnabledResize Then
            mMouseDown = True
        End If
    End Sub

    Private Sub mControl_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseUp
        mMouseDown = False
    End Sub

    Private Sub mControl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseMove
        If Not EnabledResize Then
            Return
        End If
        Dim c As Control = CType(sender, Control)
        Dim g As Graphics = c.CreateGraphics
        Select Case mEdge
            Case EdgeEnum.TopLeft
                mOutlineDrawn = True
            Case EdgeEnum.Left
                mOutlineDrawn = True
            Case EdgeEnum.Right
                mOutlineDrawn = True
            Case EdgeEnum.Top
                mOutlineDrawn = True
            Case EdgeEnum.Bottom
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

Public Module DrawHelpers

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
                Graphics.DrawPath(Outline, Path)
            End Using
        Else
            Graphics.DrawRectangle(Outline, Bounds)
        End If
    End Sub
End Module
