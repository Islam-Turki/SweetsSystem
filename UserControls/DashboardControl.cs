using sweetSystem;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem.UserControls
{
    public partial class DashboardControl : UserControl
    {
        private DateTime _selectedDate = DateTime.Today;

        public DashboardControl()
        {
            InitializeComponent();

            // Apply Theme colors
            this.BackColor = Theme.Background;
            headerPanel.BackColor = Theme.Surface;
            h1Label.ForeColor = Theme.TextPrimary;
            secLabel.ForeColor = Theme.TextPrimary;
            sepBar.BackColor = Theme.AccentGold;

            cardRowPanel.BackColor = Theme.Background;
            bodyPanel.BackColor = Theme.Background;

            _btnToday.ForeColor = Theme.TextOnAccent;
            _btnTomorrow.ForeColor = Theme.TextOnAccent;

            loadCards();
            GridHelper.Style(_grid, readOnly: true, rtl: true);
            // Ensure header alignment is applied and set headers to left-aligned
            _grid.EnableHeadersVisualStyles = false;
            _grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            SetupGridColumns();

            _btnToday.Click += (s, e) => { _selectedDate = DateTime.Today; RefreshData(); };
            _btnTomorrow.Click += (s, e) => { _selectedDate = DateTime.Today.AddDays(1); RefreshData(); };
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
            string qToday = "SELECT COUNT(*) FROM [order] WHERE CAST(order_date AS DATE) = CAST(@date AS DATE)";
            int todayCount = Convert.ToInt32(DatabaseHelper.ExecuteQuery(qToday, new[] { new Microsoft.Data.SqlClient.SqlParameter("@date", today) }).Rows[0][0]);
            _cOrders.Update(todayCount.ToString());
            _cOrders.SubText = "تم إدخالها اليوم";

            // 2. Pending Orders (All orders still pending)
            string qPending = "SELECT COUNT(*) FROM [order] WHERE status = @status";
            int pendingCount = Convert.ToInt32(DatabaseHelper.ExecuteQuery(qPending, new[] { new Microsoft.Data.SqlClient.SqlParameter("@status", EnumHelper.ToString(OrderStatus.Pending)) }).Rows[0][0]);
            _cPending.Update(pendingCount.ToString());
            _cPending.SubText = "بانتظار التجهيز";

            // 3. Delivery Orders (All orders marked for delivery)
            string qDelivery = "SELECT COUNT(*) FROM [order] WHERE is_delivery = 1";
            int deliveryCount = Convert.ToInt32(DatabaseHelper.ExecuteQuery(qDelivery).Rows[0][0]);
            _cRevenue.Update(deliveryCount.ToString());
            _cRevenue.SubText = "إجمالي طلبات التوصيل";

            // 4. Tomorrow's Orders (Scheduled for delivery tomorrow)
            string qTomorrow = "SELECT COUNT(*) FROM [order] WHERE CAST(delivery_date AS DATE) = CAST(@date AS DATE)";
            int tomorrowCount = Convert.ToInt32(DatabaseHelper.ExecuteQuery(qTomorrow, new[] { new Microsoft.Data.SqlClient.SqlParameter("@date", tomorrow) }).Rows[0][0]);
            _cClients.Update(tomorrowCount.ToString());
            _cClients.SubText = "موعد تسليمها غداً";

            // Update section title based on selection
            if (_selectedDate.Date == today)
            {
                secLabel.Text = "طلبات التسليم اليوم";
                _btnToday.BackColor = Theme.AccentGold;
                _btnTomorrow.BackColor = Theme.SurfaceBorder;
                _btnTomorrow.ForeColor = Theme.TextPrimary;
            }
            else
            {
                secLabel.Text = "طلبات التسليم غداً";
                _btnToday.BackColor = Theme.SurfaceBorder;
                _btnToday.ForeColor = Theme.TextPrimary;
                _btnTomorrow.BackColor = Theme.AccentGold;
            }

            _grid.Rows.Clear();
            string qDeliveries = @"
                SELECT o.order_number, o.customer_number, o.customer_name, 
                       ISNULL(SUM(oi.quantity), 0) as total_items, 
                       o.total_price, o.status, o.delivery_date
                FROM [order] o
                LEFT JOIN order_items oi ON o.order_number = oi.order_number
                WHERE CAST(o.delivery_date AS DATE) = CAST(@date AS DATE)
                GROUP BY o.order_number, o.customer_number, o.customer_name, o.total_price, o.status, o.delivery_date
                ORDER BY o.order_number DESC";
            var dt = DatabaseHelper.ExecuteQuery(qDeliveries, new[] { new Microsoft.Data.SqlClient.SqlParameter("@date", _selectedDate.Date) });

            foreach (System.Data.DataRow row in dt.Rows)
            {
                var statusStr = row["status"].ToString() ?? "";
                OrderStatus status;
                try { status = EnumHelper.FromString<OrderStatus>(statusStr); } catch { status = OrderStatus.Pending; }
                
                Color rowBg = status switch
                {
                    OrderStatus.Assigned => Color.FromArgb(228, 244, 228),
                    OrderStatus.Completed => Color.FromArgb(220, 238, 255),
                    _ => Theme.Surface
                };

                int i = _grid.Rows.Add(
                    row["order_number"].ToString(),
                    row["customer_number"] != DBNull.Value && !string.IsNullOrEmpty(row["customer_number"].ToString()) ? "جملة" : "قطاعي",
                    row["customer_name"].ToString(),
                    Convert.ToDouble(row["total_items"]),
                    Theme.LYD(Convert.ToDouble(row["total_price"])),
                    status switch {
                        OrderStatus.Pending => "معلق",
                        OrderStatus.InProduction => "قيد التجهيز",
                        OrderStatus.Completed => "جاهز",
                        OrderStatus.Delivered => "مسلّم",
                        OrderStatus.Assigned => "مكلّف",
                        _ => "غير معروف"
                    },
                    Convert.ToDateTime(row["delivery_date"]).ToString("dd/MM/yyyy"));
                
                _grid.Rows[i].DefaultCellStyle.BackColor = rowBg;
            }
        }

        private void _cOrders_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
