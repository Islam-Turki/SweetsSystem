using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace sweetSystem.UserControls
{
    public partial class ProductManagementControl : UserControl
    {
        public ProductManagementControl()
        {
            InitializeComponent();
            GridHelper.Style(_grid, readOnly: true, rtl: true);

            // Standard columns
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "رقم المنتج", FillWeight = 6 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "المنتج", FillWeight = 30 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "الفئة", FillWeight = 15 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Retail", HeaderText = "قطاعي", FillWeight = 12 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Wholesale", HeaderText = "جملة", FillWeight = 12 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Unit", HeaderText = "الوحدة", FillWeight = 10 });

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

            // Null check on cell value to prevent dereference errors
            var cellValue = _grid.Rows[e.RowIndex].Cells["ID"].Value;
            if (cellValue == null) return;

            int id = Convert.ToInt32(cellValue);
            var p = MockData.Products.FirstOrDefault(x => x.Id == id);
            if (p == null) return;

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

                    // Pass dlg.SelectedImageRelativePath safely
                    if (!string.IsNullOrWhiteSpace(dlg.SelectedImageRelativePath))
                        p.ImagePath = RenameProductImage(dlg.SelectedImageRelativePath, p.Id);

                    LoadGrid();
                }
            }
            else
            {
                if (MessageBox.Show($"هل تريد بالتأكيد حذف '{p.Name}'؟", "تأكيد الحذف",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MockData.Products.Remove(p);
                    LoadGrid();
                }
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var dlg = new ProductDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                decimal.TryParse(dlg.TxRetail.Text, out var r);
                decimal.TryParse(dlg.TxWholesale.Text, out var w);

                int newId = MockData.NextProductId();

                // Use the new safety check in RenameProductImage
                string imgPath = RenameProductImage(dlg.SelectedImageRelativePath, newId);

                MockData.Products.Add(new Product
                {
                    Id = newId,
                    Name = dlg.TxName.Text,
                    Category = string.IsNullOrWhiteSpace(dlg.TxCategory.Text) ? "عام" : dlg.TxCategory.Text,
                    RetailPrice = r,
                    WholesalePrice = w,
                    Unit = string.IsNullOrWhiteSpace(dlg.TxUnit.Text) ? "قطعة" : dlg.TxUnit.Text,
                    ImagePath = imgPath
                });
                LoadGrid();
            }
        }

        public string RenameProductImage(string? relativePath, int productId)
        {
            // Use base directory for deterministic pathing
            string baseDir = AppDomain.CurrentDomain.BaseDirectory ?? Application.StartupPath;
            string imagesDir = Path.Combine(baseDir, "Images", "Products");
            if (!Directory.Exists(imagesDir)) Directory.CreateDirectory(imagesDir);

            if (string.IsNullOrWhiteSpace(relativePath))
            {
                // no image chosen — return empty string (UI will use placeholder)
                return string.Empty;
            }

            try
            {
                string absSource = Path.Combine(baseDir, relativePath);
                if (!File.Exists(absSource)) return string.Empty;

                string ext = Path.GetExtension(absSource) ?? ".jpg";
                string newName = $"{productId}{ext}";
                string absDest = Path.Combine(imagesDir, newName);

                // If same path, return relative
                if (string.Equals(absSource, absDest, StringComparison.OrdinalIgnoreCase))
                    return Path.Combine("Images", "Products", newName);

                if (File.Exists(absDest)) File.Delete(absDest);
                File.Copy(absSource, absDest);
                File.Delete(absSource);

                return Path.Combine("Images", "Products", newName);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}