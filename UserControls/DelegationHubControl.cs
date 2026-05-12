using sweetSystem;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem.UserControls
{
    public partial class DelegationHubControl : UserControl
    {

        public DelegationHubControl()
        {
            InitializeComponent();
            ConfigureGrids(); // Set up columns and styling
            LoadData();
            SetTabStyle(true);
        }
        private void BuildContent()
        {
            // ── Right col: tabs + pending orders grid
            var rightHeader = new SectionHeader("الطلبات المعلقة");
            rightHeader.Dock = DockStyle.Top;
            rightHeader.RightToLeft = RightToLeft.No;
            rightHeader.Height = 40;
            rightHeader.Padding = new Padding(0, 0, 18, 0);

            _pendingGrid = new DataGridView { Dock = DockStyle.Fill };
            GridHelper.Style(_pendingGrid, readOnly: true, rtl: true);
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "رقم الطلب", FillWeight = 6 });
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Customer", HeaderText = "العميل", FillWeight = 32 });
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Type", HeaderText = "النوع", FillWeight = 14 });
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Items", HeaderText = "الكميات", FillWeight = 12 });
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "الإجمالي", FillWeight = 16 });
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
            var leftHeader = new SectionHeader("حمل المعبّئين");
            leftHeader.Dock = DockStyle.Top;
            // make leftHeader right to left aligned
            leftHeader.RightToLeft = RightToLeft.No;
            leftHeader.Height = 40;
            leftHeader.Padding = new Padding(0, 0, 18, 0);
            leftPanel.Controls.Add(leftHeader);

            _packagerGrid = new DataGridView { Dock = DockStyle.Fill };
            GridHelper.Style(_packagerGrid, readOnly: true, rtl: true);
            _packagerGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Packager", HeaderText = "الموظف المكلف", FillWeight = 45 });
            _packagerGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Count", HeaderText = "الطلبات", FillWeight = 30 });
            leftPanel.Controls.Add(_packagerGrid);

            _lblSel = new Label
            {
                Text = "انقر على أي طلب من القائمة لتعيينه وطباعته.",
                Dock = DockStyle.Bottom,
                Height = 26,
                Font = Theme.FontBody,
                ForeColor = Theme.TextSecondary,
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(0, 0, 4, 0)
            };
            leftPanel.Controls.Add(_lblSel);
        }

        public void LoadData()
        {
            _pendingGrid.Rows.Clear();
            DateTime targetDate = _showTodayOrders ? DateTime.Today : DateTime.Today.AddDays(1);
            foreach (var o in MockData.Orders.Where(o => o.OrderDate.Date == targetDate && o.Status == OrderStatus.Pending))
            {
                var items = MockData.OrderItems.Where(oi => oi.OrderId == o.Id);
                _pendingGrid.Rows.Add(o.Id, o.CustomerName, o.CustomerId != null ? "جملة" : "قطاعي", items.Sum(l => l.Quantity), Theme.LYD(o.TotalPrice));
            }

            _packagerGrid.Rows.Clear();
            foreach (var p in MockData.Employees.Where(e => e.Role == EmployeeRole.Packager))
            {
                int cnt = MockData.Orders.Count(o => o.OrderDate.Date == DateTime.Today && o.Packager?.Id == p.Id);
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
        {
            DateTime targetDate = _showTodayOrders ? DateTime.Today : DateTime.Today.AddDays(1);

            using var dlg = new AutoAssignDialog(targetDate);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();

                if (dlg.Assignments.Count > 0)
                    MessageBox.Show(
                        $"تم تكليف {dlg.Assignments.Count} طلب تلقائياً وطباعة الفواتير.",
                        "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnManualAll_Click(object? sender, EventArgs e)
        {
            DateTime targetDate = _showTodayOrders ? DateTime.Today : DateTime.Today.AddDays(1);
            var pendingOrders = MockData.Orders
                .Where(o => o.OrderDate.Date == targetDate && o.Status == OrderStatus.Pending)
                .ToList();

            if (pendingOrders.Count == 0)
            {
                MessageBox.Show("لا توجد طلبات معلقة لتكليفها.", "معلومة",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int assigned = 0;
            foreach (var order in pendingOrders)
            {
                using var dlg = new AssignOrderDialog(order);
                var result = dlg.ShowDialog(this);

                if (result == DialogResult.OK)
                    assigned++;
                else
                    break; // user cancelled — stop the loop
            }

            LoadData();

            if (assigned > 0)
                MessageBox.Show($"تم تكليف {assigned} من أصل {pendingOrders.Count} طلب بنجاح.",
                    "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void _btnToday_Click(object sender, EventArgs e)
        {
            _showTodayOrders = true;
            SetTabStyle(true);
             LoadData(); // (Make sure you have a LoadData method, or comment this out for now)
        }

        private void _btnTomorrow_Click(object sender, EventArgs e)
        {
            _showTodayOrders = false;
            SetTabStyle(false);
             LoadData();
        }
        private void SetTabStyle(bool todayActive)
        {
            _btnToday.BackColor = todayActive ? Theme.AccentGreen : Theme.Surface;
            _btnToday.ForeColor = todayActive ? Color.White : Theme.TextPrimary;

            _btnTomorrow.BackColor = !todayActive ? Theme.AccentGreen : Theme.Surface;
            _btnTomorrow.ForeColor = !todayActive ? Color.White : Theme.TextPrimary;
        }
        private bool _showTodayOrders = true;

        private void ConfigureGrids()
        {
            // Style the Grids (Using your GridHelper)
            GridHelper.Style(_pendingGrid, readOnly: true, rtl: true);
            GridHelper.Style(_packagerGrid, readOnly: true, rtl: true);

            // Define Pending Grid Columns
            _pendingGrid.Columns.Clear();
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "رقم الطلب", FillWeight = 6 });
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Customer", HeaderText = "العميل", FillWeight = 32 });
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Type", HeaderText = "النوع", FillWeight = 14 });
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Items", HeaderText = "الكميات", FillWeight = 12 });
            _pendingGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "الإجمالي", FillWeight = 16 });

            // Define Packager Grid Columns
            _packagerGrid.Columns.Clear();
            _packagerGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Packager", HeaderText = "الموظف المكلف", FillWeight = 45 });
            _packagerGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Count", HeaderText = "الطلبات", FillWeight = 30 });
            _packagerGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Load", HeaderText = "الحمل", FillWeight = 25 });
        }

        private void _pendingGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
