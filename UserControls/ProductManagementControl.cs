using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem.UserControls
{
    public partial class ProductManagementControl : UserControl
    {
        public ProductManagementControl()
        {
            InitializeComponent();
            GridHelper.Style(_grid, readOnly: true, rtl: true);
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID",        HeaderText = "#",       FillWeight = 6  });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name",      HeaderText = "المنتج",  FillWeight = 30 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category",  HeaderText = "الفئة",   FillWeight = 15 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Retail",    HeaderText = "قطاعي",   FillWeight = 12 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Wholesale", HeaderText = "جملة",    FillWeight = 12 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Unit",      HeaderText = "الوحدة",  FillWeight = 10 });
            GridHelper.AddActionColumns(_grid);
            _grid.CellContentClick += Grid_CellContentClick;
            LoadGrid();
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadGrid();

        public void LoadGrid()
        {
            _grid.Rows.Clear();
            var q = _txSearch.Text.Trim().ToLower();
            var f = _cbFilter.SelectedItem?.ToString() ?? "الكل";

            var list = MockData.Products.Where(p =>
                (string.IsNullOrEmpty(q) || p.Name.ToLower().Contains(q)) &&
                (f == "الكل" || p.Category == f));

            foreach (var p in list)
                _grid.Rows.Add(p.Id, p.Name, p.Category, Theme.LYD(p.RetailPrice), Theme.LYD(p.WholesalePrice), p.Unit);
        }

        private void Grid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = _grid.Columns[e.ColumnIndex].Name;
            if (col != "Edit" && col != "Delete") return;

            int id = Convert.ToInt32(_grid.Rows[e.RowIndex].Cells["ID"].Value);
            var p  = MockData.Products.First(x => x.Id == id);

            if (col == "Edit")
            {
                var dlg = new ProductDialog(p);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    p.Name = dlg.TxName.Text;
                    p.Category = string.IsNullOrWhiteSpace(dlg.TxCategory.Text) ? "عام" : dlg.TxCategory.Text;
                    if (decimal.TryParse(dlg.TxRetail.Text, out var r)) p.RetailPrice = r;
                    if (decimal.TryParse(dlg.TxWholesale.Text, out var w)) p.WholesalePrice = w;
                    p.Unit = dlg.TxUnit.Text;
                    LoadGrid();
                }
            }
            else
            {
                if (MessageBox.Show($"هل تريد بالتأكيد حذف '{p.Name}'؟", "تأكيد الحذف",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { MockData.Products.Remove(p); LoadGrid(); }
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var dlg = new ProductDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                decimal.TryParse(dlg.TxRetail.Text, out var r);
                decimal.TryParse(dlg.TxWholesale.Text, out var w);
                MockData.Products.Add(new Product
                {
                    Id = MockData.NextProductId(),
                    Name = dlg.TxName.Text,
                    Category = string.IsNullOrWhiteSpace(dlg.TxCategory.Text) ? "عام" : dlg.TxCategory.Text,
                    RetailPrice = r, WholesalePrice = w,
                    Unit = string.IsNullOrWhiteSpace(dlg.TxUnit.Text) ? "قطعة" : dlg.TxUnit.Text
                });
                LoadGrid();
            }
        }
    }
}
