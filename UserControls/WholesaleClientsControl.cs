using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem.UserControls
{
    public partial class WholesaleClientsControl : UserControl
    {
        public WholesaleClientsControl()
        {
            InitializeComponent();
            GridHelper.Style(_grid, readOnly: true, rtl: true);
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID",      HeaderText = "رقم العميل",            FillWeight = 6  });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name",    HeaderText = "الاسم التجاري", FillWeight = 30 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone",   HeaderText = "الهاتف",        FillWeight = 20 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Balance", HeaderText = "الرصيد المتبقي", FillWeight = 15 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status",  HeaderText = "الحالة",        FillWeight = 15 });
            
            var depCol = new DataGridViewButtonColumn { Name = "Deposit", HeaderText = "", Text = "💰 إيداع", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 100 };
            _grid.Columns.Add(depCol);
            
            GridHelper.AddActionColumns(_grid);
            _grid.CellContentClick += Grid_CellContentClick;
            LoadGrid();
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadGrid();

        public void LoadGrid()
        {
            _grid.Rows.Clear();
            var q = _txSearch.Text.Trim().ToLower();
            var f = _cbFilter.SelectedIndex;

            var list = MockData.WholesaleClients.Where(c =>
                (string.IsNullOrEmpty(q) || c.Name.ToLower().Contains(q) || c.Phone.Contains(q)) &&
                (f == 0 || (f == 1 && c.RemainingBalance > 0) || (f == 2 && c.RemainingBalance == 0)));

            foreach (var c in list)
            {
                string status = c.RemainingBalance == 0 ? "✅ مسدد" : "⚠ عليه رصيد";
                int i = _grid.Rows.Add(c.Id, c.Name, c.Phone, Theme.LYD(c.RemainingBalance), status);
                if (c.RemainingBalance > 0)
                    _grid.Rows[i].DefaultCellStyle.ForeColor = Theme.AccentRed;
            }

            decimal totalDebt = MockData.WholesaleClients.Sum(c => c.RemainingBalance);
            _lblTotalBal.Text = $"إجمالي الديون في السوق: {Theme.LYD(totalDebt)}";
        }

        private void Grid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = _grid.Columns[e.ColumnIndex].Name;
            if (col != "Edit" && col != "Delete" && col != "Deposit") return;

            int id = Convert.ToInt32(_grid.Rows[e.RowIndex].Cells["ID"].Value);
            var c  = MockData.WholesaleClients.First(x => x.Id == id);

            if (col == "Edit")
            {
                var dlg = new WholesaleClientDialog(c);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    c.Name = dlg.TxName.Text;
                    c.Phone = dlg.TxPhone.Text;
                    if (decimal.TryParse(dlg.TxBalance.Text, out var b)) c.RemainingBalance = b;
                    LoadGrid();
                }
            }
            else if (col == "Delete")
            {
                if (MessageBox.Show($"هل تريد بالتأكيد حذف العميل '{c.Name}'؟", "تأكيد الحذف",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { MockData.WholesaleClients.Remove(c); LoadGrid(); }
            }
            else if (col == "Deposit")
            {
                if (c.RemainingBalance <= 0)
                {
                    MessageBox.Show("هذا العميل ليس عليه ديون.", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var dlg = new DepositDialog(c);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    c.RemainingBalance -= dlg.Amount;
                    MessageBox.Show($"تم إيداع {Theme.LYD(dlg.Amount)} بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                }
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var dlg = new WholesaleClientDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                decimal.TryParse(dlg.TxBalance.Text, out var b);
                MockData.WholesaleClients.Add(new WholesaleClient
                {
                    Id = MockData.NextClientId(),
                    Name = string.IsNullOrWhiteSpace(dlg.TxName.Text) ? "عميل جديد" : dlg.TxName.Text,
                    Phone = dlg.TxPhone.Text,
                    RemainingBalance = b
                });
                LoadGrid();
            }
        }
    }
}
