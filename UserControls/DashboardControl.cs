using sweetSystem;
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

            loadCards();
            GridHelper.Style(_grid, readOnly: true, rtl: true);
            // Ensure header alignment is applied and set headers to left-aligned
            _grid.EnableHeadersVisualStyles = false;
            _grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            SetupGridColumns();
        }

        public void loadCards()
        {

            _cOrders.Title = "طلبات اليوم"; _cOrders.SubText = "إجمالي"; _cOrders.AccentColor = Theme.AccentGreen;
            _cPending.Title = "قيد الانتظار"; _cPending.SubText = "بانتظار التعبئة"; _cPending.AccentColor = Theme.AccentGold;
            _cRevenue.Title = "طلبيات التوصيل"; _cRevenue.SubText = "طلبية"; _cRevenue.AccentColor = Theme.AccentBlue;
            _cClients.Title = "طلبيات الغد"; _cClients.SubText = " طلبية"; _cClients.AccentColor = Theme.AccentRed;
        }

        private void SetupGridColumns()
        {
            _grid.Columns.Clear();
            _grid.Columns.Add(MakeCol("ID", "رقم الطلب", 35, false));
            _grid.Columns.Add(MakeCol("Type", "النوع", 80, false));
            _grid.Columns.Add(MakeCol("Customer", "العميل", 160, true));
            _grid.Columns.Add(MakeCol("Items", "الكميات", 80, true));
            _grid.Columns.Add(MakeCol("Total", "المجموع", 100, false));
            _grid.Columns.Add(MakeCol("Status", "الحالة", 110, false));
            _grid.Columns.Add(MakeCol("Date", "موعد التسليم", 90, true));
        }

        private static DataGridViewTextBoxColumn MakeCol(string name, string header, int w, bool fill)
        {
            var c = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                FillWeight = w,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            };

            if (!fill) c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            return c;
        }

        public void RefreshData()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            // 1. Today's Orders (Created today)
            int todayCount = MockData.Orders.Count(o => o.OrderDate.Date == today);
            _cOrders.Update(todayCount.ToString());
            _cOrders.SubText = "تم إدخالها اليوم";

            // 2. Pending Orders (All orders still pending)
            int pendingCount = MockData.Orders.Count(o => o.Status == OrderStatus.Pending);
            _cPending.Update(pendingCount.ToString());
            _cPending.SubText = "بانتظار التجهيز";

            // 3. Delivery Orders (All orders marked for delivery)
            int deliveryCount = MockData.Orders.Count(o => o.IsDelivery);
            _cRevenue.Update(deliveryCount.ToString());
            _cRevenue.SubText = "إجمالي طلبات التوصيل";

            // 4. Tomorrow's Orders (Scheduled for delivery tomorrow)
            int tomorrowCount = MockData.Orders.Count(o => o.DeliveryDate.Date == tomorrow);
            _cClients.Update(tomorrowCount.ToString());
            _cClients.SubText = "موعد تسليمها غداً";

            _grid.Rows.Clear();
            foreach (var o in MockData.Orders.OrderByDescending(x => x.Id).Take(25))
            {
                Color rowBg = o.Status switch
                {
                    OrderStatus.Assigned => Color.FromArgb(228, 244, 228),
                    OrderStatus.Completed => Color.FromArgb(220, 238, 255),
                    _ => Theme.Surface
                };
                var orderItems = MockData.OrderItems.Where(oi => oi.OrderId == o.Id);
                int i = _grid.Rows.Add(
                    o.Id,
                    o.CustomerId != null ? "جملة" : "قطاعي",
                    o.CustomerName,
                    orderItems.Sum(l => l.Quantity),
                    Theme.LYD(o.TotalPrice),
                    MockData.OrderStatusAr(o.Status),
                    o.OrderDate.ToString("dd/MM"));
                _grid.Rows[i].DefaultCellStyle.BackColor = rowBg;
            }
        }

        private void _cOrders_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
