Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Namespace S131432
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'nwindDataSet.Products' table. You can move, or remove it, as needed.
			Me.productsTableAdapter.Fill(Me.nwindDataSet.Products)

		End Sub

		Private Sub OnGridViewRowStyle(ByVal sender As Object, ByVal e As RowStyleEventArgs) Handles gridView1.RowStyle
			Dim gView As GridView = CType(sender, GridView)
			If (Not gView.IsValidRowHandle(e.RowHandle)) Then
				Return
			End If
			Dim parent As Integer = gView.GetParentRowHandle(e.RowHandle)
			If gView.IsGroupRow(parent) Then
				For i As Integer = 0 To gView.GetChildRowCount(parent) - 1
					If gView.GetChildRowHandle(parent, i) = e.RowHandle Then
						If i Mod 2 = 0 Then
							e.Appearance.BackColor = Color.AliceBlue
						Else
							e.Appearance.BackColor = Color.AntiqueWhite
						End If
					End If
				Next i
			Else
				If e.RowHandle Mod 2 = 0 Then
					e.Appearance.BackColor = Color.AliceBlue
				Else
					e.Appearance.BackColor = Color.AntiqueWhite
				End If
			End If
		End Sub
	End Class
End Namespace