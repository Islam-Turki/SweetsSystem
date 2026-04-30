using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem.UserControls
{
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();

            _cOrders.Title = "طلبات اليوم"; _cOrders.SubText = "إجمالي"; _cOrders.AccentColor = Theme.AccentGreen;
            _cPending.Title = "قيد الانتظار"; _cPending.SubText = "بانتظار التعبئة"; _cPending.AccentColor = Theme.AccentGold;
            _cRevenue.Title = "إيرادات اليوم"; _cRevenue.SubText = "د.ل"; _cRevenue.AccentColor = Theme.AccentBlue;
            _cClients.Title = "عملاء الجملة"; _cClients.SubText = "حسابات نشطة"; _cClients.AccentColor = Theme.AccentRed;

            GridHelper.Style(_grid, readOnly: true, rtl: true);
            // Ensure header alignment is applied and set headers to left-aligned
            _grid.EnableHeadersVisualStyles = false;
            _grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            SetupGridColumns();
        }

        private void SetupGridColumns()
        {
            _grid.Columns.Clear();
            _grid.Columns.Add(MakeCol("ID",       "رقم الطلب",              35,  false));
            _grid.Columns.Add(MakeCol("Type",     "النوع",          80,  false));
            _grid.Columns.Add(MakeCol("Customer", "العميل",         160, true));
            _grid.Columns.Add(MakeCol("Items",    "الكميات",        80,  true));
            _grid.Columns.Add(MakeCol("Total",    "المجموع",        100, false));
            _grid.Columns.Add(MakeCol("Status",   "الحالة",         110, false));
            _grid.Columns.Add(MakeCol("Date",     "موعد التسليم",   90,  true));
        }

        private static DataGridViewTextBoxColumn MakeCol(string name, string header, int w, bool fill)
        {
            var c = new DataGridViewTextBoxColumn
            {
                Name       = name,
                HeaderText = header,
                FillWeight = w,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            };
            
            if (!fill) c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            return c;
        }

        public void RefreshData()
        {
            var today = MockData.Orders.Where(o => o.Date.Date == DateTime.Today).ToList();
            _cOrders.Update(today.Count.ToString());
            _cPending.Update(today.Count(o => o.Status == OrderStatus.Pending).ToString());
            _cRevenue.Update(Theme.LYD(today.Sum(o => o.Subtotal)));
            _cClients.Update(MockData.WholesaleClients.Count.ToString());

            _grid.Rows.Clear();
            foreach (var o in MockData.Orders.OrderByDescending(x => x.Id).Take(25))
            {
                Color rowBg = o.Status switch
                {
                    OrderStatus.Assigned  => Color.FromArgb(228, 244, 228),
                    OrderStatus.Completed => Color.FromArgb(220, 238, 255),
                    _                     => Theme.Surface
                };
                int i = _grid.Rows.Add(
                    o.Id,
                    MockData.OrderTypeAr(o.Type),
                    o.DisplayCustomer,
                    o.Lines.Sum(l => l.Quantity),
                    Theme.LYD(o.Subtotal),
                    MockData.OrderStatusAr(o.Status),
                    o.Date.ToString("dd/MM"));
                _grid.Rows[i].DefaultCellStyle.BackColor = rowBg;
            }
        }
    }
}
