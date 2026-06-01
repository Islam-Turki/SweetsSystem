using sweetSystem;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem.UserControls
{
    public partial class EmployeeHRControl : UserControl
    {
        public EmployeeHRControl()
        {
            InitializeComponent();
            this.BackColor = Theme.Background;
            GridHelper.Style(_grid, readOnly: true, rtl: true);
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID",     HeaderText = "رقم الموظف",       FillWeight = 6  });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name",   HeaderText = "الاسم",   FillWeight = 25 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Role",   HeaderText = "الدور",   FillWeight = 15 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Skills", HeaderText = "المهارات", FillWeight = 40 });
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
                SELECT e.phone, e.name, e.role,
                       (SELECT STRING_AGG(CAST(product_name AS NVARCHAR(MAX)), N'، ') FROM products p WHERE p.maker_phone = e.phone) as skills
                FROM employee e
                WHERE (@q = '' OR e.name LIKE '%' + @q + '%')";

            if (f != "الكل")
            {
                if (f == "طباخ") sql += " AND e.role = 'cook'";
                else if (f == "موظف تعبئة") sql += " AND e.role = 'packager'";
            }

            var dt = DatabaseHelper.ExecuteQuery(sql, new[] { new Microsoft.Data.SqlClient.SqlParameter("@q", q) });

            foreach (System.Data.DataRow row in dt.Rows)
            {
                string roleStr = row["role"].ToString() ?? "";
                EmployeeRole role = roleStr == "cook" ? EmployeeRole.Cook : EmployeeRole.Packager;
                
                string skills = role == EmployeeRole.Cook ? (row["skills"].ToString() ?? "") : "—";
                if (string.IsNullOrWhiteSpace(skills) && role == EmployeeRole.Cook) skills = "—";

                string roleAr = role == EmployeeRole.Cook ? "طباخ" : "تعبئة وتغليف";
                int i = _grid.Rows.Add(row["phone"].ToString(), row["name"].ToString(), roleAr, skills);
                _grid.Rows[i].DefaultCellStyle.BackColor = role == EmployeeRole.Cook
                    ? Color.FromArgb(245, 252, 245) : Color.FromArgb(245, 248, 255);
            }
        }

        private void Grid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = _grid.Columns[e.ColumnIndex].Name;
            if (col != "Edit" && col != "Delete") return;

            string phone = _grid.Rows[e.RowIndex].Cells["ID"].Value?.ToString() ?? "";
            string currentName = _grid.Rows[e.RowIndex].Cells["Name"].Value?.ToString() ?? "";

            if (col == "Edit")
            {
                var emp = new Employee { 
                    Phone = phone, 
                    Name = currentName, 
                    Role = _grid.Rows[e.RowIndex].Cells["Role"].Value?.ToString() == "طباخ" ? EmployeeRole.Cook : EmployeeRole.Packager
                };

                var dlg = new EmployeeDialog(emp);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    string newName = dlg.TxName.Text;
                    string newRole = dlg.CbRole.SelectedIndex == 0 ? "cook" : "packager";

                    DatabaseHelper.ExecuteNonQuery("UPDATE employee SET name = @name, role = @role WHERE phone = @phone", new[] {
                        new Microsoft.Data.SqlClient.SqlParameter("@name", newName),
                        new Microsoft.Data.SqlClient.SqlParameter("@role", newRole),
                        new Microsoft.Data.SqlClient.SqlParameter("@phone", phone)
                    });

                    if (newRole == "cook")
                    {
                        DatabaseHelper.ExecuteNonQuery("UPDATE products SET maker_phone = NULL WHERE maker_phone = @phone", new[] { new Microsoft.Data.SqlClient.SqlParameter("@phone", phone) });
                        foreach (var skill in dlg.SelectedSkills)
                        {
                            DatabaseHelper.ExecuteNonQuery("UPDATE products SET maker_phone = @phone WHERE product_name = @pn", new[] {
                                new Microsoft.Data.SqlClient.SqlParameter("@phone", phone),
                                new Microsoft.Data.SqlClient.SqlParameter("@pn", skill)
                            });
                        }
                    }

                    LoadGrid();
                }
            }
            else
            {
                if (MessageBox.Show($"هل تريد بالتأكيد حذف الموظف '{currentName}'؟", "تأكيد الحذف",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM employee WHERE phone = @phone", new[] { new Microsoft.Data.SqlClient.SqlParameter("@phone", phone) });
                    LoadGrid(); 
                }
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var dlg = new EmployeeDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                string name = string.IsNullOrWhiteSpace(dlg.TxName.Text) ? "موظف جديد" : dlg.TxName.Text;
                string role = dlg.CbRole.SelectedIndex == 0 ? "cook" : "packager";
                
                // Generate a dummy phone for now since EmployeeDialog lacks a phone field
                string newPhone = "09" + new Random().Next(10000000, 99999999).ToString();

                string q = "INSERT INTO employee (phone, name, role, is_available) VALUES (@phone, @name, @role, 1)";
                DatabaseHelper.ExecuteNonQuery(q, new[] {
                    new Microsoft.Data.SqlClient.SqlParameter("@phone", newPhone),
                    new Microsoft.Data.SqlClient.SqlParameter("@name", name),
                    new Microsoft.Data.SqlClient.SqlParameter("@role", role)
                });

                if (role == "cook")
                {
                    foreach (var skill in dlg.SelectedSkills)
                    {
                        DatabaseHelper.ExecuteNonQuery("UPDATE products SET maker_phone = @phone WHERE product_name = @pn", new[] {
                            new Microsoft.Data.SqlClient.SqlParameter("@phone", newPhone),
                            new Microsoft.Data.SqlClient.SqlParameter("@pn", skill)
                        });
                    }
                }

                LoadGrid();
            }
        }
    }
}
