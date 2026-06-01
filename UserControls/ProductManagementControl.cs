using sweetSystem;
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
            this.BackColor = Theme.Background;
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

            string sql = @"
                SELECT 
                    ROW_NUMBER() OVER(ORDER BY product_name) as RowNum,
                    product_name, category, price, unit
                FROM products 
                WHERE (@q = '' OR LOWER(product_name) LIKE '%' + @q + '%')";

            var parameters = new System.Collections.Generic.List<Microsoft.Data.SqlClient.SqlParameter>
            {
                new Microsoft.Data.SqlClient.SqlParameter("@q", q)
            };

            if (f != "الكل")
            {
                if (Enum.TryParse<ProductCategory>(f, out var enumCat))
                {
                    sql += " AND category = @cat";
                    parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@cat", EnumHelper.ToString(enumCat)));
                }
            }

            var dt = DatabaseHelper.ExecuteQuery(sql, parameters.ToArray());

            foreach (System.Data.DataRow row in dt.Rows)
            {
                int rowNum = Convert.ToInt32(row["RowNum"]);
                string name = row["product_name"].ToString() ?? "";
                
                string catStr = row["category"].ToString() ?? "";
                var catEnum = ProductCategory.Other;
                try { catEnum = EnumHelper.FromString<ProductCategory>(catStr); } catch {}

                double price = Convert.ToDouble(row["price"]);
                double wsPrice = price; // Fallback since wholesale_price is removed
                
                string unitStr = row["unit"].ToString() ?? "";
                var unitEnum = ProductUnit.Piece;
                try { unitEnum = EnumHelper.FromString<ProductUnit>(unitStr); } catch {}

                _grid.Rows.Add(rowNum, name, catEnum.ToString(), Theme.LYD(price), Theme.LYD(wsPrice), unitEnum.ToString());
            }
        }

        private void Grid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = _grid.Columns[e.ColumnIndex].Name;
            if (col != "Edit" && col != "Delete") return;

            var cellValue = _grid.Rows[e.RowIndex].Cells["Name"].Value;
            if (cellValue == null) return;
            string productName = cellValue.ToString() ?? "";

            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM products WHERE product_name = @pn", new[] { new Microsoft.Data.SqlClient.SqlParameter("@pn", productName) });
            if (dt.Rows.Count == 0) return;

            var row = dt.Rows[0];
            var p = new Product
            {
                Id = Math.Abs(productName.GetHashCode()),
                Name = productName,
                Price = Convert.ToDouble(row["price"]),
                WholesalePrice = Convert.ToDouble(row["price"])
            };
            try { p.Category = EnumHelper.FromString<ProductCategory>(row["category"].ToString() ?? ""); } catch {}
            try { p.Unit = EnumHelper.FromString<ProductUnit>(row["unit"].ToString() ?? ""); } catch {}
            
            try 
            { 
                if (row.Table.Columns.Contains("picture_url") && row["picture_url"] != DBNull.Value) 
                    p.ImagePath = row["picture_url"].ToString(); 
            } 
            catch {}

            if (col == "Edit")
            {
                var dlg = new ProductDialog(p);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    string oldName = productName;
                    string newName = dlg.TxName.Text;
                    var catEnum = Enum.TryParse<ProductCategory>(dlg.TxCategory.Text, out var c) ? c : ProductCategory.Other;
                    var unitEnum = Enum.TryParse<ProductUnit>(dlg.TxUnit.Text, out var u) ? u : ProductUnit.Piece;
                    double.TryParse(dlg.TxRetail.Text, out var r);
                    double.TryParse(dlg.TxWholesale.Text, out var w);

                    string imgPath = p.ImagePath ?? "";
                    if (!string.IsNullOrWhiteSpace(dlg.SelectedImageRelativePath))
                        imgPath = RenameProductImage(dlg.SelectedImageRelativePath, Math.Abs(newName.GetHashCode()));

                    string sql = @"
                        UPDATE products SET 
                            product_name = @new_name, 
                            category = @cat, 
                            price = @price, 
                            unit = @unit
                        WHERE product_name = @old_name";

                    try
                    {
                        DatabaseHelper.ExecuteNonQuery(sql, new[] {
                            new Microsoft.Data.SqlClient.SqlParameter("@new_name", newName),
                            new Microsoft.Data.SqlClient.SqlParameter("@cat", EnumHelper.ToString(catEnum)),
                            new Microsoft.Data.SqlClient.SqlParameter("@price", r),
                            new Microsoft.Data.SqlClient.SqlParameter("@unit", EnumHelper.ToString(unitEnum)),
                            new Microsoft.Data.SqlClient.SqlParameter("@old_name", oldName)
                        });

                        try { DatabaseHelper.ExecuteNonQuery("UPDATE products SET picture_url = @img WHERE product_name = @new_name", new[] { new Microsoft.Data.SqlClient.SqlParameter("@img", imgPath), new Microsoft.Data.SqlClient.SqlParameter("@new_name", newName) }); } catch {}
                        
                        LoadGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("حدث خطأ أثناء التحديث، تأكد من عدم تكرار اسم المنتج. " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (MessageBox.Show($"هل تريد بالتأكيد حذف '{productName}'؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DatabaseHelper.ExecuteNonQuery("DELETE FROM products WHERE product_name = @pn", new[] { new Microsoft.Data.SqlClient.SqlParameter("@pn", productName) });
                        LoadGrid();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("لا يمكن حذف المنتج لأنه مرتبط بطلبات سابقة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var dlg = new ProductDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                double.TryParse(dlg.TxRetail.Text, out var r);
                double.TryParse(dlg.TxWholesale.Text, out var w);

                string newName = dlg.TxName.Text;
                int newId = Math.Abs(newName.GetHashCode());
                string imgPath = RenameProductImage(dlg.SelectedImageRelativePath, newId);

                var catEnum = Enum.TryParse<ProductCategory>(dlg.TxCategory.Text, out var c2) ? c2 : ProductCategory.Other;
                var unitEnum = Enum.TryParse<ProductUnit>(dlg.TxUnit.Text, out var u2) ? u2 : ProductUnit.Piece;

                string sql = @"
                    INSERT INTO products (product_name, category, price, unit)
                    VALUES (@name, @cat, @price, @unit)";
                
                try
                {
                    DatabaseHelper.ExecuteNonQuery(sql, new[] {
                        new Microsoft.Data.SqlClient.SqlParameter("@name", newName),
                        new Microsoft.Data.SqlClient.SqlParameter("@cat", EnumHelper.ToString(catEnum)),
                        new Microsoft.Data.SqlClient.SqlParameter("@price", r),
                        new Microsoft.Data.SqlClient.SqlParameter("@unit", EnumHelper.ToString(unitEnum))
                    });

                    try { DatabaseHelper.ExecuteNonQuery("UPDATE products SET picture_url = @img WHERE product_name = @name", new[] { new Microsoft.Data.SqlClient.SqlParameter("@img", imgPath), new Microsoft.Data.SqlClient.SqlParameter("@name", newName) }); } catch {}
                    
                    LoadGrid();
                }
                catch (Exception)
                {
                    MessageBox.Show("يوجد منتج بنفس الاسم مسبقاً، يرجى اختيار اسم مختلف.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
