using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem.UserControls
{
    public partial class DelegationHubControl : UserControl
    {
        private DataGridView _pendingGrid = null!, _packagerGrid = null!;
        private Label        _lblSel = null!;
        private FlatButton   _btnToday = null!, _btnTomorrow = null!;
        private bool         _showTodayOrders = true;

        public DelegationHubControl()
        {
            InitializeComponent();
            BuildContent();
        }

        private void BuildContent()
        {
            // ── Right col: tabs + pending orders grid
            var rightHeader = new SectionHeader("الطلبات المعلقة");
            var tabs = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 45, RightToLeft = RightToLeft.Yes };
            _btnToday    = new FlatButton { Text = "📅 طلبات اليوم", Width = 140, Margin = new Padding(0, 0, 8, 8) };
            _btnTomorrow = new FlatButton { Text = "📆 طلبات الغد",  Width = 140, Margin = new Padding(0, 0, 8, 8), BackColor = Theme.Surface, ForeColor = Theme.TextPrimary };
            _btnToday.Click    += (_, _) => { _showTodayOrders = true;  SetTabStyle(true);  LoadData(); };
            _btnTomorrow.Click += (_, _) => { _showTodayOrders = false; SetTabStyle(false); LoadData(); };
            tabs.Controls.Add(_btnToday);
            tabs.Controls.Add(_btnTomorrow);

            _pendingGrid = new DataGridView { Dock = DockStyle.Fill };
            GridHelper.Style(_pendingGrid, readOnly: true, rtl: true);
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID",       HeaderText = "#",         FillWeight = 6  });
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Customer", HeaderText = "العميل",    FillWeight = 32 });
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Type",     HeaderText = "النوع",     FillWeight = 14 });
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Items",    HeaderText = "الكميات",   FillWeight = 12 });
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total",    HeaderText = "الإجمالي",  FillWeight = 16 });
            _pendingGrid.CellClick += PendingGrid_CellClick;

            rightPanel.Controls.Add(_pendingGrid);
            rightPanel.Controls.Add(tabs);
            rightPanel.Controls.Add(rightHeader);
            _pendingGrid.BringToFront();

            // ── Left col: packager board + status label
            left_Controls_Add_PackagerGrid();
        }

        private void left_Controls_Add_PackagerGrid()
        {
            leftPanel.Controls.Add(new SectionHeader("حمل المعبّئين — اليوم"));

            _packagerGrid = new DataGridView { Dock = DockStyle.Fill };
            GridHelper.Style(_packagerGrid, readOnly: true, rtl: true);
            _packagerGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Packager", HeaderText = "المعبّئ",  FillWeight = 45 });
            _packagerGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Count",    HeaderText = "الطلبات",  FillWeight = 30 });
            leftPanel.Controls.Add(_packagerGrid);

            _lblSel = new Label
            {
                Text = "انقر على أي طلب من القائمة لتعيينه وطباعته.",
                Dock = DockStyle.Bottom, Height = 26,
                Font = Theme.FontBody, ForeColor = Theme.TextSecondary,
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(0, 0, 4, 0)
            };
            leftPanel.Controls.Add(_lblSel);
        }

        private void SetTabStyle(bool todayActive)
        {
            _btnToday.BackColor    = todayActive  ? Theme.AccentGreen : Theme.Surface;
            _btnToday.ForeColor    = todayActive  ? Color.White : Theme.TextPrimary;
            _btnTomorrow.BackColor = !todayActive ? Theme.AccentGreen : Theme.Surface;
            _btnTomorrow.ForeColor = !todayActive ? Color.White : Theme.TextPrimary;
        }

        public void LoadData()
        {
            _pendingGrid.Rows.Clear();
            DateTime targetDate = _showTodayOrders ? DateTime.Today : DateTime.Today.AddDays(1);
            foreach (var o in MockData.Orders.Where(o => o.Date.Date == targetDate && o.Status == OrderStatus.Pending))
                _pendingGrid.Rows.Add(o.Id, o.DisplayCustomer, MockData.OrderTypeAr(o.Type), o.Lines.Sum(l => l.Quantity), Theme.LYD(o.Subtotal));

            _packagerGrid.Rows.Clear();
            foreach (var p in MockData.Employees.Where(e => e.Role == EmployeeRole.Packager))
            {
                int cnt = MockData.Orders.Count(o => o.Date.Date == DateTime.Today && o.AssignedPackager?.Id == p.Id);
                string load = cnt <= 2 ? "🟢 خفيف" : cnt <= 5 ? "🟡 متوسط" : "🔴 ثقيل";
                _packagerGrid.Rows.Add(p.Name, $"{cnt} طلبات", load);
            }
        }

        private void PendingGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!int.TryParse(_pendingGrid.Rows[e.RowIndex].Cells["ID"].Value?.ToString(), out int id)) return;
            var order = MockData.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return;
            using var dlg = new AssignOrderDialog(order);
            if (dlg.ShowDialog(this) == DialogResult.OK) LoadData();
        }

        private void BtnAuto_Click(object? sender, EventArgs e)
            => MessageBox.Show("وظيفة التكليف التلقائي قيد التطوير.", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void BtnManualAll_Click(object? sender, EventArgs e)
            => MessageBox.Show("وظيفة تكليف الكل يدوياً قيد التطوير.", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
