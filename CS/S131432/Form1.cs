using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace S131432
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            productsBindingSource.DataSource = GetProductsDataTable();
        }
        DataTable GetProductsDataTable()
        {
            DataTable table = new DataTable();
            table.TableName = "Products";
            table.Columns.Add(new DataColumn("ProductID", typeof(int)));
            table.Columns.Add(new DataColumn("ProductName", typeof(string)));
            table.Columns.Add(new DataColumn("SupplierID", typeof(int)));
            table.Columns.Add(new DataColumn("CategoryID", typeof(string)));
            table.Columns.Add(new DataColumn("QuantityPerUnit", typeof(int)));
            for(int i = 0; i < 20; i++)
            {
                int index = i + 1;
                table.Rows.Add(index, "Product " + index, index * 2, "Category " + i % 8, index % 7);
            }
            return table;
        }
        private void OnGridViewRowStyle(object sender, RowStyleEventArgs e)
        {
            GridView gView = (GridView)sender;
            if(!gView.IsValidRowHandle(e.RowHandle)) return;
            int parent = gView.GetParentRowHandle(e.RowHandle);
            if(gView.IsGroupRow(parent))
            {
                for(int i = 0; i < gView.GetChildRowCount(parent); i++)
                    if(gView.GetChildRowHandle(parent, i) == e.RowHandle)
                        e.Appearance.BackColor = i % 2 == 0 ? Color.AliceBlue : Color.AntiqueWhite;
            }
            else e.Appearance.BackColor = e.RowHandle % 2 == 0 ? Color.AliceBlue : Color.AntiqueWhite;
        }
    }
}