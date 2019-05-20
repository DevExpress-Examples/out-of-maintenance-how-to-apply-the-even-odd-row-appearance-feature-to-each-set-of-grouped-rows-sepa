Imports DevExpress.XtraGrid.Views.Grid
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Namespace S131432
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			productsBindingSource.DataSource = GetProductsDataTable()
		End Sub
		Private Function GetProductsDataTable() As DataTable
			Dim table As New DataTable()
			table.TableName = "Products"
			table.Columns.Add(New DataColumn("ProductID", GetType(Integer)))
			table.Columns.Add(New DataColumn("ProductName", GetType(String)))
			table.Columns.Add(New DataColumn("SupplierID", GetType(Integer)))
			table.Columns.Add(New DataColumn("CategoryID", GetType(String)))
			table.Columns.Add(New DataColumn("QuantityPerUnit", GetType(Integer)))
			For i As Integer = 0 To 19
				Dim index As Integer = i + 1
				table.Rows.Add(index, "Product " & index, index * 2, "Category " & i Mod 8, index Mod 7)
			Next i
			Return table
		End Function
		Private Sub OnGridViewRowStyle(ByVal sender As Object, ByVal e As RowStyleEventArgs) Handles gridView1.RowStyle
			Dim gView As GridView = DirectCast(sender, GridView)
			If Not gView.IsValidRowHandle(e.RowHandle) Then
				Return
			End If
'INSTANT VB NOTE: The variable parent was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim parent_Renamed As Integer = gView.GetParentRowHandle(e.RowHandle)
			If gView.IsGroupRow(parent_Renamed) Then
				Dim i As Integer = 0
				Do While i < gView.GetChildRowCount(parent_Renamed)
					If gView.GetChildRowHandle(parent_Renamed, i) = e.RowHandle Then
						e.Appearance.BackColor = If(i Mod 2 = 0, Color.AliceBlue, Color.AntiqueWhite)
					End If
					i += 1
				Loop
			Else
				e.Appearance.BackColor = If(e.RowHandle Mod 2 = 0, Color.AliceBlue, Color.AntiqueWhite)
			End If
		End Sub
	End Class
End Namespace