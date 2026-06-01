using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sweetSystem
{
    using sweetSystem.printerUrils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class AutoAssignDialog : BaseDialog
    {
        private readonly List<Order> _pendingOrders;
        private readonly List<Employee> _packagers;

        /// <summary>
        /// After the dialog closes with OK, this contains the assignment results.
        /// </summary>
        public List<(Order Order, Employee Packager)> Assignments { get; } = new();

        public AutoAssignDialog()
        {
            InitializeComponent();
            _pendingOrders = new List<Order>();
            _packagers = new List<Employee>();
        }

        /// <summary>
        /// Creates the dialog pre-loaded with the pending orders for the given date.
        /// </summary>
        public AutoAssignDialog(DateTime targetDate) : this()
        {
            _pendingOrders = new List<Order>();
            string sqlOrders = @"
                SELECT order_number, customer_number, CAST(order_date AS DATE) as odate, delivery_date, is_delivery, payment_status, total_price, status, notes
                FROM [order] 
                WHERE CAST(order_date AS DATE) = @date AND status = @status";
            
            var dtOrders = DatabaseHelper.ExecuteQuery(sqlOrders, new[] {
                new Microsoft.Data.SqlClient.SqlParameter("@date", targetDate.Date),
                new Microsoft.Data.SqlClient.SqlParameter("@status", EnumHelper.ToString(OrderStatus.Pending))
            });

            foreach (System.Data.DataRow row in dtOrders.Rows)
            {
                var o = new Order
                {
                    Id = Convert.ToInt32(row["order_number"].ToString()),
                    OrderDate = Convert.ToDateTime(row["odate"]),
                    IsDelivery = Convert.ToBoolean(row["is_delivery"]),
                    TotalPrice = Convert.ToDouble(row["total_price"]),
                    PaidAmount = 0, // Fallback since paid_amount is removed from DB
                    Status = OrderStatus.Pending,
                    Notes = row["notes"]?.ToString()
                };
                
                if (row["delivery_date"] != DBNull.Value) o.DeliveryDate = Convert.ToDateTime(row["delivery_date"]);
                try { o.PaymentStatus = EnumHelper.FromString<PaymentStatus>(row["payment_status"].ToString() ?? ""); } catch {}

                if (row["customer_number"] != DBNull.Value)
                {
                    string custNum = row["customer_number"].ToString() ?? "";
                    try { o.CustomerId = Convert.ToInt32(custNum); } catch { }

                    var dtCust = DatabaseHelper.ExecuteQuery("SELECT name, phone FROM customer WHERE customer_number = @cn", new[] { new Microsoft.Data.SqlClient.SqlParameter("@cn", custNum) });
                    if (dtCust.Rows.Count > 0)
                    {
                        o.CustomerName = dtCust.Rows[0]["name"].ToString() ?? "";
                        o.CustomerPhone = dtCust.Rows[0]["phone"].ToString() ?? "";
                    }
                }

                _pendingOrders.Add(o);
            }

            _packagers = new List<Employee>();
            var dtPackagers = DatabaseHelper.ExecuteQuery("SELECT phone, name, is_available FROM employee WHERE role = 'packager'");
            foreach (System.Data.DataRow row in dtPackagers.Rows)
            {
                _packagers.Add(new Employee
                {
                    Phone = row["phone"].ToString() ?? "",
                    Name = row["name"].ToString() ?? "",
                    Role = EmployeeRole.Packager,
                    IsAvailable = Convert.ToBoolean(row["is_available"])
                });
            }

            string dayLabel = targetDate.Date == DateTime.Today ? "اليوم" : "الغد";
            lblPendingCount.Text = $"⏳ {_pendingOrders.Count} طلب معلق — {dayLabel} ({targetDate:dd/MM})";

            ClbPackagers.Items.Clear();
            for (int i = 0; i < _packagers.Count; i++)
            {
                var p = _packagers[i];
                int currentLoad = 0;
                var dtLoad = DatabaseHelper.ExecuteQuery("SELECT COUNT(*) FROM [order] WHERE CAST(order_date AS DATE) = @date AND packager_phone = @pp", new[] {
                    new Microsoft.Data.SqlClient.SqlParameter("@date", targetDate.Date),
                    new Microsoft.Data.SqlClient.SqlParameter("@pp", p.Phone)
                });
                if (dtLoad.Rows.Count > 0)
                    currentLoad = Convert.ToInt32(dtLoad.Rows[0][0]);

                string display = $"{p.Name}   —   الحمل الحالي: {currentLoad} طلبات";
                ClbPackagers.Items.Add(display);

                ClbPackagers.SetItemChecked(i, p.IsAvailable);
            }
        }

        private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool check = chkSelectAll.Checked;
            for (int i = 0; i < ClbPackagers.Items.Count; i++)
                ClbPackagers.SetItemChecked(i, check);
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            // Get selected packagers
            var selectedPackagers = new List<Employee>();
            for (int i = 0; i < ClbPackagers.Items.Count; i++)
            {
                if (ClbPackagers.GetItemChecked(i))
                    selectedPackagers.Add(_packagers[i]);
            }

            if (selectedPackagers.Count == 0)
            {
                MessageBox.Show("يرجى اختيار معبّئ واحد على الأقل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_pendingOrders.Count == 0)
            {
                MessageBox.Show("لا توجد طلبات معلقة.", "معلومة",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Assignments.Clear();
            for (int i = 0; i < _pendingOrders.Count; i++)
            {
                var order = _pendingOrders[i];
                var packager = selectedPackagers[i % selectedPackagers.Count];

                order.Packager = packager;
                order.Status = OrderStatus.Assigned;

                DatabaseHelper.ExecuteNonQuery("UPDATE [order] SET packager_phone = @pp, status = @s WHERE order_number = @on", new[] {
                    new Microsoft.Data.SqlClient.SqlParameter("@pp", packager.Phone),
                    new Microsoft.Data.SqlClient.SqlParameter("@s", EnumHelper.ToString(OrderStatus.Assigned)),
                    new Microsoft.Data.SqlClient.SqlParameter("@on", order.Id.ToString())
                });

                Assignments.Add((order, packager));

                string ticket = paperBuilder.BuildOrderTicket(order);
                RawPrinterHelper.PrintOut(ticket);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
