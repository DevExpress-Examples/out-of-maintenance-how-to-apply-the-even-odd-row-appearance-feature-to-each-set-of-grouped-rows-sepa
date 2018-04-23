using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace S131432 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.nwindDataSet.Products);

        }

        private void OnGridViewRowStyle(object sender, RowStyleEventArgs e) {
            GridView gView = (GridView)sender;
            if (!gView.IsValidRowHandle(e.RowHandle)) return;
            int parent = gView.GetParentRowHandle(e.RowHandle);
            if (gView.IsGroupRow(parent)) {
                for (int i = 0; i < gView.GetChildRowCount(parent); i++)
                    if (gView.GetChildRowHandle(parent, i) == e.RowHandle)
                        e.Appearance.BackColor = i % 2 == 0 ? Color.AliceBlue : Color.AntiqueWhite;
            } else e.Appearance.BackColor = e.RowHandle % 2 == 0 ? Color.AliceBlue : Color.AntiqueWhite;
        }
    }
}