using sweetSystem;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using sweetSystem.printerUrils;

namespace sweetSystem.UserControls
{
    public partial class CustomersControl : UserControl
    {
        public CustomersControl()
        {
            InitializeComponent();
            this.BackColor = Theme.Background;
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
            if (!this.DesignMode)
            {
                _cbFilter.SelectedIndex = 0;
                LoadGrid();
            }
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadGrid();

        public void LoadGrid()
        {
            _grid.Rows.Clear();
            var q = _txSearch.Text.Trim().ToLower();
            var f = _cbFilter.SelectedIndex;

            string sql = @"
                SELECT customer_number, name, phone, balance
                FROM customer
                WHERE (@q = '' OR LOWER(name) LIKE '%' + @q + '%' OR phone LIKE '%' + @q + '%')";

            var parameters = new System.Collections.Generic.List<Microsoft.Data.SqlClient.SqlParameter>
            {
                new Microsoft.Data.SqlClient.SqlParameter("@q", q)
            };

            if (f == 1) sql += " AND balance > 0";
            if (f == 2) sql += " AND balance <= 0";

            var dt = DatabaseHelper.ExecuteQuery(sql, parameters.ToArray());

            double totalDebt = 0;
            foreach (System.Data.DataRow row in dt.Rows)
            {
                string id = row["customer_number"].ToString() ?? "";
                string name = row["name"].ToString() ?? "";
                string phone = row["phone"].ToString() ?? "";
                double balance = Convert.ToDouble(row["balance"]);

                if (balance > 0) totalDebt += balance;

                string status = balance <= 0 ? "✅ مسدد" : "⚠ عليه رصيد";
                int i = _grid.Rows.Add(id, name, phone, Theme.LYD(balance), status);
                if (balance > 0)
                    _grid.Rows[i].DefaultCellStyle.ForeColor = Theme.AccentRed;
            }

            _lblTotalBal.Text = $"إجمالي الديون في السوق: {Theme.LYD(totalDebt)}";
        }

        private void Grid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = _grid.Columns[e.ColumnIndex].Name;
            if (col != "Edit" && col != "Delete" && col != "Deposit") return;

            string customerNum = _grid.Rows[e.RowIndex].Cells["ID"].Value?.ToString() ?? "";
            
            var dt = DatabaseHelper.ExecuteQuery("SELECT customer_number, name, phone, balance FROM customer WHERE customer_number = @cn", new[] { new Microsoft.Data.SqlClient.SqlParameter("@cn", customerNum) });
            if (dt.Rows.Count == 0) return;
            var row = dt.Rows[0];
            var c = new Customer
            {
                Number = customerNum,
                Name = row["name"].ToString() ?? "",
                Phone = row["phone"].ToString() ?? "",
                OpeningBalance = Convert.ToDouble(row["balance"])
            };

            if (col == "Edit")
            {
                var dlg = new CustomerDialog(c);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    string newName = dlg.TxName.Text;
                    string phone = dlg.TxPhone.Text;
                    double.TryParse(dlg.TxBalance.Text, out var b);

                    DatabaseHelper.ExecuteNonQuery("UPDATE customer SET name = @n, phone = @p, balance = @b WHERE customer_number = @cn", new[] {
                        new Microsoft.Data.SqlClient.SqlParameter("@n", newName),
                        new Microsoft.Data.SqlClient.SqlParameter("@p", phone),
                        new Microsoft.Data.SqlClient.SqlParameter("@b", b),
                        new Microsoft.Data.SqlClient.SqlParameter("@cn", customerNum)
                    });
                    LoadGrid();
                }
            }
            else if (col == "Delete")
            {
                if (MessageBox.Show($"هل تريد بالتأكيد حذف العميل '{c.Name}'؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    try { DatabaseHelper.ExecuteNonQuery("DELETE FROM customer WHERE customer_number = @cn", new[] { new Microsoft.Data.SqlClient.SqlParameter("@cn", customerNum) }); LoadGrid(); } 
                    catch { MessageBox.Show("لا يمكن حذف العميل لوجود طلبات أو معاملات مرتبطة به.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else if (col == "Deposit")
            {
                if (c.OpeningBalance <= 0)
                {
                    MessageBox.Show("هذا العميل ليس عليه ديون.", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var dlg = new DepositDialog(c);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    double amount = dlg.Amount;
                    
                    // Use BeginInvoke to prevent DataGridView re-entrancy issues when clearing rows inside CellContentClick
                    this.BeginInvoke(new Action(() => 
                    {
                        try 
                        {
                            double balanceBefore = c.OpeningBalance;

                            // 1. Database Operations
                            DatabaseHelper.ExecuteNonQuery("INSERT INTO payment_transaction (id, customer_number, amount, payment_date, notes) VALUES (NEWID(), @cn, @amt, @dt, @notes)", new[] {
                                new Microsoft.Data.SqlClient.SqlParameter("@cn", customerNum),
                                new Microsoft.Data.SqlClient.SqlParameter("@amt", amount),
                                new Microsoft.Data.SqlClient.SqlParameter("@dt", DateTime.Now),
                                new Microsoft.Data.SqlClient.SqlParameter("@notes", "إيداع يدوي")
                            });

                            DatabaseHelper.ExecuteNonQuery("UPDATE customer SET balance = balance - @amt WHERE customer_number = @cn", new[] {
                                new Microsoft.Data.SqlClient.SqlParameter("@amt", amount),
                                new Microsoft.Data.SqlClient.SqlParameter("@cn", customerNum)
                            });

                            // 2. IMMEDIATE UI Refresh
                            LoadGrid();

                            // 3. Success Message
                            MessageBox.Show($"تم إيداع {Theme.LYD(amount)} بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 4. Print Receipt (wrapped in try-catch to prevent print errors from breaking the UI)
                            try 
                            {
                                double balanceAfter = balanceBefore - amount;
                                string receipt = paperBuilder.BuildDepositReceipt(c.Name, balanceBefore, amount, balanceAfter);
                                RawPrinterHelper.PrintOut(receipt);
                            } 
                            catch { /* Ignore printer errors */ }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("حدث خطأ أثناء حفظ الإيداع: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }));
                }
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var dlg = new CustomerDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                double.TryParse(dlg.TxBalance.Text, out var b);
                string newName = string.IsNullOrWhiteSpace(dlg.TxName.Text) ? "عميل جديد" : dlg.TxName.Text;
                string newPhone = dlg.TxPhone.Text;
                
                string newNum = "1";
                try {
                    var maxDt = DatabaseHelper.ExecuteQuery("SELECT ISNULL(MAX(CAST(customer_number AS INT)), 0) + 1 FROM customer");
                    newNum = maxDt.Rows[0][0].ToString() ?? "1";
                } catch {
                    newNum = DateTime.Now.Ticks.ToString().Substring(0, 8);
                }

                try
                {
                    DatabaseHelper.ExecuteNonQuery("INSERT INTO customer (customer_number, name, phone, balance) VALUES (@cn, @n, @p, @b)", new[] {
                        new Microsoft.Data.SqlClient.SqlParameter("@cn", newNum),
                        new Microsoft.Data.SqlClient.SqlParameter("@n", newName),
                        new Microsoft.Data.SqlClient.SqlParameter("@p", newPhone),
                        new Microsoft.Data.SqlClient.SqlParameter("@b", b)
                    });
                    LoadGrid();
                }
                catch (Exception)
                {
                    MessageBox.Show("حدث خطأ أثناء إضافة العميل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
