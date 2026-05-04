using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem.UserControls
{
    public partial class OrderManagementControl : UserControl
    {
        public OrderManagementControl()
        {
            InitializeComponent();
            GridHelper.Style(_grid, readOnly: true, rtl: true);
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID",       HeaderText = "رقم الطلب",             FillWeight = 6  });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date",     HeaderText = "موعد التسليم", FillWeight = 12 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Customer", HeaderText = "العميل",        FillWeight = 25 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Type",     HeaderText = "النوع",         FillWeight = 10 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total",    HeaderText = "المجموع",       FillWeight = 12 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status",   HeaderText = "الحالة",        FillWeight = 15 });
            GridHelper.AddActionColumns(_grid);
            _grid.CellContentClick += Grid_CellContentClick;
            LoadGrid();
        }

        public void LoadGrid()
        {
            _grid.Rows.Clear();
            var q = _txSearch.Text.Trim().ToLower();
            var f = _cbFilter.SelectedIndex;
            var list = MockData.Orders
                .Where(o =>
                    (string.IsNullOrEmpty(q) || o.DisplayCustomer.ToLower().Contains(q) || o.Id.ToString() == q) &&
                    (f == 0 || (int)o.Status == f - 1))
                .OrderByDescending(o => o.Id);
            foreach (var o in list)
            {
                Color rowBg = o.Status switch
                {
                    OrderStatus.Assigned  => Color.FromArgb(228, 244, 228),
                    OrderStatus.Completed => Color.FromArgb(220, 238, 255),
                    _                     => Theme.Surface
                };
                int i = _grid.Rows.Add(o.Id, o.Date.ToString("dd/MM/yyyy"), o.DisplayCustomer,
                    MockData.OrderTypeAr(o.Type), Theme.LYD(o.Subtotal), MockData.OrderStatusAr(o.Status));
                _grid.Rows[i].DefaultCellStyle.BackColor = rowBg;
            }
        }

        private void CbFilter_SelectedIndexChanged(object? sender, EventArgs e) => LoadGrid();

        private void Grid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = _grid.Columns[e.ColumnIndex].Name;
            if (col != "Edit" && col != "Delete") return;
            int id = Convert.ToInt32(_grid.Rows[e.RowIndex].Cells["ID"].Value);
            var o  = MockData.Orders.First(x => x.Id == id);
            if (col == "Edit")
            {
                var dlg = new OrderDialog(o);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    o.Status = (OrderStatus)dlg.CbStatus.SelectedIndex;
                    LoadGrid();
                }
            }
            else
            {
                if (MessageBox.Show($"هل تريد بالتأكيد حذف الطلب #{o.Id}؟", "تأكيد الحذف",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { MockData.Orders.Remove(o); LoadGrid(); }
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e) =>
            MessageBox.Show("لإضافة طلب جديد، يرجى استخدام شاشة 'إدخال الطلبات' من القائمة الجانبية.",
                "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
