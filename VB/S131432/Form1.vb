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
            Dim table As DataTable = New DataTable()
            table.TableName = "Products"
            table.Columns.Add(New DataColumn("ProductID", GetType(Integer)))
            table.Columns.Add(New DataColumn("ProductName", GetType(String)))
            table.Columns.Add(New DataColumn("SupplierID", GetType(Integer)))
            table.Columns.Add(New DataColumn("CategoryID", GetType(String)))
            table.Columns.Add(New DataColumn("QuantityPerUnit", GetType(Integer)))
            For i As Integer = 0 To 20 - 1
                Dim index As Integer = i + 1
                table.Rows.Add(index, "Product " & index, index * 2, "Category " & i Mod 8, index Mod 7)
            Next
            Return table
        End Function

        Private Sub OnGridViewRowStyle(ByVal sender As Object, ByVal e As RowStyleEventArgs) Handles gridView1.RowStyle
            Dim gView As GridView = CType(sender, GridView)
            If Not gView.IsValidRowHandle(e.RowHandle) Then Return
            Dim parent As Integer = gView.GetParentRowHandle(e.RowHandle)
            If gView.IsGroupRow(parent) Then
                For i As Integer = 0 To gView.GetChildRowCount(parent) - 1
                    If gView.GetChildRowHandle(parent, i) = e.RowHandle Then e.Appearance.BackColor = If(i Mod 2 = 0, Color.AliceBlue, Color.AntiqueWhite)
                Next
            Else
                e.Appearance.BackColor = If(e.RowHandle Mod 2 = 0, Color.AliceBlue, Color.AntiqueWhite)
            End If
        End Sub
    End Class
End Namespace
