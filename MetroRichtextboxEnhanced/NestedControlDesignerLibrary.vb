Imports System.ComponentModel

<Designer(GetType(NestedControlDesigner))>
Public Class NestedControlDesignerLibrary
	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.

	End Sub

	<
	Category("Appearance"),
	DefaultValue(GetType(String), "NestedControl")
	>
	Public Property Caption1() As String
		Get
			Return lblCaption.Text
		End Get
		Set(value As String)
			lblCaption.Text = value
		End Set
	End Property

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

End Class

Public Class NestedControlDesigner
	Inherits System.Windows.Forms.Design.ParentControlDesigner

	Public Overrides Sub Initialize(component As System.ComponentModel.IComponent)
		MyBase.Initialize(component)
		Dim content As Panel = DirectCast(Me.Control, NestedControlDesignerLibrary).WorkingArea
		EnableDesignMode(content, "WorkingArea")
		'If (Me.Control Is NestedControlDesignerLibrary) Then
		'this.EnableDesignMode(((TestControl)this.Control).WorkingArea, "WorkingArea");
		'End If
	End Sub
End Class