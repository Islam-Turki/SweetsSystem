using sweetSystem;
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
            this.BackColor = Theme.Background;
            GridHelper.Style(_grid, readOnly: true, rtl: true);
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID",       HeaderText = "رقم الطلب",             FillWeight = 6  });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date",     HeaderText = "موعد التسليم", FillWeight = 12 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Customer", HeaderText = "العميل",        FillWeight = 25 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Type",     HeaderText = "النوع",         FillWeight = 10 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total",    HeaderText = "المجموع",       FillWeight = 12 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status",   HeaderText = "الحالة",        FillWeight = 15 });
            GridHelper.AddActionColumns(_grid);
            _grid.CellContentClick += Grid_CellContentClick;
            if (!this.DesignMode)
            {
                _cbFilter.SelectedIndex = 0;
                LoadGrid();
            }
        }

        private Order? GetOrderFromDb(int id)
        {
            string q = "SELECT * FROM [order] WHERE order_number = @id";
            var dt = DatabaseHelper.ExecuteQuery(q, new[] { new Microsoft.Data.SqlClient.SqlParameter("@id", id.ToString()) });
            if (dt.Rows.Count == 0) return null;
            var row = dt.Rows[0];
            
            var o = new Order
            {
                Id = Convert.ToInt32(row["order_number"]),
                OrderDate = Convert.ToDateTime(row["order_date"]),
                DeliveryDate = Convert.ToDateTime(row["delivery_date"]),
                CustomerName = row["customer_name"].ToString() ?? "",
                CustomerPhone = row["customer_phone"].ToString() ?? "",
                IsDelivery = Convert.ToBoolean(row["is_delivery"]),
                TotalPrice = Convert.ToDouble(row["total_price"])
            };
            
            var statusStr = row["status"].ToString();
            if (!string.IsNullOrEmpty(statusStr))
                o.Status = EnumHelper.FromString<OrderStatus>(statusStr);
                
            var payStr = row["payment_status"].ToString();
            if (!string.IsNullOrEmpty(payStr))
                o.PaymentStatus = EnumHelper.FromString<PaymentStatus>(payStr);

            if (row["customer_number"] != DBNull.Value && !string.IsNullOrEmpty(row["customer_number"].ToString()))
            {
                if (int.TryParse(row["customer_number"].ToString(), out int cid)) o.CustomerId = cid;
            }

            return o;
        }

        public void LoadGrid()
        {
            _grid.Rows.Clear();
            var q = _txSearch.Text.Trim().ToLower();
            var f = _cbFilter.SelectedIndex;

            string sql = @"
                SELECT order_number, order_date, customer_name, customer_number, total_price, status 
                FROM [order] 
                WHERE (@q = '' OR LOWER(customer_name) LIKE '%' + @q + '%' OR order_number = @q)";

            var parameters = new System.Collections.Generic.List<Microsoft.Data.SqlClient.SqlParameter>
            {
                new Microsoft.Data.SqlClient.SqlParameter("@q", q)
            };

            if (f > 0)
            {
                OrderStatus stat = (OrderStatus)(f - 1);
                sql += " AND status = @status";
                parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@status", EnumHelper.ToString(stat)));
            }

            sql += " ORDER BY CAST(order_number AS INT) DESC";

            var dt = DatabaseHelper.ExecuteQuery(sql, parameters.ToArray());

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

                int id = Convert.ToInt32(row["order_number"]);
                DateTime orderDate = Convert.ToDateTime(row["order_date"]);
                string custName = row["customer_name"].ToString() ?? "";
                string custNum = row["customer_number"] != DBNull.Value ? row["customer_number"].ToString() ?? "" : "";
                double total = Convert.ToDouble(row["total_price"]);

                int i = _grid.Rows.Add(
                    id, 
                    orderDate.ToString("dd/MM/yyyy"), 
                    custName,
                    !string.IsNullOrEmpty(custNum) ? "جملة" : "قطاعي", 
                    Theme.LYD(total), 
                    status switch {
                        OrderStatus.Pending => "معلق",
                        OrderStatus.InProduction => "قيد التجهيز",
                        OrderStatus.Completed => "جاهز",
                        OrderStatus.Delivered => "مسلّم",
                        OrderStatus.Assigned => "مكلّف",
                        _ => "غير معروف"
                    }
                );
                
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
            
            if (col == "Edit")
            {
                var o = GetOrderFromDb(id);
                if (o == null) return;
                
                if (this.FindForm() is MainForm mainForm)
                {
                    var ctrl = mainForm.Navigate(1) as OrderEntryControl;
                    ctrl?.LoadOrder(o);
                }
            }
            else
            {
                if (MessageBox.Show($"هل تريد بالتأكيد حذف الطلب #{id}؟", "تأكيد الحذف",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM order_items WHERE order_number = @id", new[] { new Microsoft.Data.SqlClient.SqlParameter("@id", id.ToString()) });
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM [order] WHERE order_number = @id", new[] { new Microsoft.Data.SqlClient.SqlParameter("@id", id.ToString()) });
                    LoadGrid(); 
                }
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (this.FindForm() is MainForm mainForm)
            {
                mainForm.Navigate(1);
            }
        }
    }
}
