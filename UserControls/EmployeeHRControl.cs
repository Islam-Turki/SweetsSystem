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

            var list = MockData.Employees.Where(e =>
                (string.IsNullOrEmpty(q) || e.Name.ToLower().Contains(q)) &&
                (f == "الكل" || MockData.RoleAr(e.Role) == f));

            foreach (var emp in list)
            {
                string skills = emp.Role == EmployeeRole.Cook
                    ? string.Join("، ", MockData.Products.Where(p => p.MakerId == emp.Id).Select(p => p.Name))
                    : "—";
                int i = _grid.Rows.Add(emp.Id, emp.Name, MockData.RoleAr(emp.Role), skills);
                _grid.Rows[i].DefaultCellStyle.BackColor = emp.Role == EmployeeRole.Cook
                    ? Color.FromArgb(245, 252, 245) : Color.FromArgb(245, 248, 255);
            }
        }

        private void Grid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = _grid.Columns[e.ColumnIndex].Name;
            if (col != "Edit" && col != "Delete") return;

            int id  = Convert.ToInt32(_grid.Rows[e.RowIndex].Cells["ID"].Value);
            var emp = MockData.Employees.First(x => x.Id == id);

            if (col == "Edit")
            {
                var dlg = new EmployeeDialog(emp);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    emp.Name = dlg.TxName.Text;
                    emp.Role = dlg.CbRole.SelectedIndex == 0 ? EmployeeRole.Cook : EmployeeRole.Packager;
                    // SkillProductIds removed — skills are now tracked via Product.MakerId
                    LoadGrid();
                }
            }
            else
            {
                if (MessageBox.Show($"هل تريد بالتأكيد حذف الموظف '{emp.Name}'؟", "تأكيد الحذف",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { MockData.Employees.Remove(emp); LoadGrid(); }
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var dlg = new EmployeeDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                MockData.Employees.Add(new Employee
                {
                    Id = MockData.NextEmployeeId(),
                    Name = string.IsNullOrWhiteSpace(dlg.TxName.Text) ? "موظف جديد" : dlg.TxName.Text,
                    Role = dlg.CbRole.SelectedIndex == 0 ? EmployeeRole.Cook : EmployeeRole.Packager,
                    // SkillProductIds removed — skills are now tracked via Product.MakerId
                });
                LoadGrid();
            }
        }
    }
}
