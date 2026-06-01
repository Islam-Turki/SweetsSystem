using sweetSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem.UserControls
{
    public partial class OrderEntryControl : UserControl
    {
        // ── State ─────────────────────────────────────────────────────────────
        private readonly List<OrderItem> _cart = new();
        // productId → card panel (so we can update badges)
                private Order? _editingOrder;

        // ── Constructor ───────────────────────────────────────────────────────
        public OrderEntryControl()
        {
            InitializeComponent();
            ApplyTheme();
            SetupCalendarLogic();
            BindComboBoxes();

            _txCustomer.KeyPress += ValidationHelper.LettersOnly;
            _txCustomerExtra.KeyPress += ValidationHelper.NumbersOnly;
        }

        // ══════════════════════════════════════════════════════════════════════
        //  THEME & SETUP
        // ══════════════════════════════════════════════════════════════════════
        private void ApplyTheme()
        {
            this.BackColor = Theme.Background;
            // Header
            h1Label.Font = Theme.FontH1;
            h1Label.ForeColor = Theme.TextPrimary;

            // Customer panels
            lblOrderType.Font = Theme.FontBodyB;
            _rbRetail.Font = Theme.FontBody;
            _rbWholesale.Font = Theme.FontBody;
            lblCustomerName.Font = Theme.FontBodyB;
            _txCustomer.Font = Theme.FontBody;
            _txCustomerExtra.Font = Theme.FontBody;
            //lblCustomer.Font = Theme.FontBodyB;
            _cbClient.Font = Theme.FontBody;
            _chkIsDeliveryRetail.Font = Theme.FontBody;
            _chkIsDeliveryWholesale.Font = Theme.FontBody;
            _txPaidRetail.Font = Theme.FontBody;
            _txPaidWholesale.Font = Theme.FontBody;
            lblPaidRetail.Font = Theme.FontBodyB;
            lblPaidWholesale.Font = Theme.FontBodyB;

            AttachInputWrapperEvents(_txPaidRetailWrap, _txPaidRetail);
            AttachInputWrapperEvents(_txPaidWholesaleWrap, _txPaidWholesale);
            _txPaidRetail.KeyPress += ValidationHelper.DecimalsOnly;
            _txPaidWholesale.KeyPress += ValidationHelper.DecimalsOnly;

            // Summary card
            lblSummary.Font = Theme.FontH2;
            lblSubTitle.Font = Theme.FontBodyB;
            _lblSub.Font = Theme.FontBodyB;
            lblBalanceTitle.Font = Theme.FontBodyB;
            _lblBalance.Font = Theme.FontBodyB;
            lblGrandTitle.Font = Theme.FontBodyB;

            // Cart section label
            lblCartTitle.Font = Theme.FontH2;
            lblCartTitle.ForeColor = Theme.TextPrimary;

            
            // Add card borders for info sections
            AddCardBorder(typeCard);
            AddCardBorder(sumCard);

            // Style the cart DataGridView
            GridHelper.Style(_linesGrid, readOnly: false, rtl: true);
            _linesGrid.Columns.Clear();
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Product", HeaderText = "المنتج", FillWeight = 38, ReadOnly = true });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qty", HeaderText = "الكمية", FillWeight = 12 });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "السعر", FillWeight = 20, ReadOnly = true });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "الإجمالي", FillWeight = 20, ReadOnly = true });
            // Remove-row button column
            var removeCol = new DataGridViewButtonColumn
            {
                Name = "Remove",
                HeaderText = "",
                Text = "✕",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 36,
                FillWeight = 10
            };
            _linesGrid.Columns.Add(removeCol);
            _linesGrid.CellClick += LinesGrid_CellClick;
            _linesGrid.CellValidating += LinesGrid_CellValidating;
            _linesGrid.CellValueChanged += LinesGrid_CellValueChanged;

            if (_txCustomerWrap != null && _txCustomer != null)
                AttachInputWrapperEvents(_txCustomerWrap, _txCustomer);
            if (_txCustomerExtraWrap != null && _txCustomerExtra != null)
                AttachInputWrapperEvents(_txCustomerExtraWrap, _txCustomerExtra);

            // Action Buttons
            _btnSave.BackColor = Theme.AccentGold;
            _btnSave.ForeColor = Theme.TextOnAccent;
            _btnClear.BackColor = Theme.AccentRed;
            _btnClear.ForeColor = Theme.TextOnAccent;
        }

        private void AttachInputWrapperEvents(Panel wrap, TextBox tx, int radius = 8)
        {
            Color normalBorder = Color.FromArgb(200, 200, 200);
            Color focusBorder = Color.FromArgb(53, 133, 142);
            bool focused = false;

            void ApplyRegion() =>
                wrap.Region = new Region(
                    RoundedPanel.RoundRect(new Rectangle(0, 0, wrap.Width, wrap.Height), radius));

            wrap.Resize += (_, _) => ApplyRegion();
            wrap.HandleCreated += (_, _) => ApplyRegion();

            wrap.Paint += (_, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var r = new Rectangle(0, 0, wrap.Width - 1, wrap.Height - 1);
                using var path = RoundedPanel.RoundRect(r, radius);
                using var pen = new Pen(focused ? focusBorder : normalBorder, focused ? 2f : 1.5f);
                e.Graphics.DrawPath(pen, path);
            };

            tx.Enter += (_, _) => { focused = true; wrap.Invalidate(); };
            tx.Leave += (_, _) => { focused = false; wrap.Invalidate(); };
            wrap.Click += (_, _) => tx.Focus();
        }

        private void BindComboBoxes()
        {
            // Clear the list first so we don't get duplicates when refreshing!
            _cbClient.Items.Clear();

            _cbClient.DisplayMember = "Name";
            _cbClient.ValueMember = "Number";

            var dt = DatabaseHelper.ExecuteQuery("SELECT customer_number, name, balance FROM customer");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                _cbClient.Items.Add(new Customer { 
                    Number = row["customer_number"].ToString(), 
                    Name = row["name"].ToString(),
                    OpeningBalance = Convert.ToDouble(row["balance"])
                });
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        //  CART LOGIC
        // ══════════════════════════════════════════════════════════════════════
        
        private void _btnSelectProducts_Click(object sender, EventArgs e)
        {
            try
            {
                using var dlg = new sweetSystem.Dialogs.ChooseProductsDialog(_rbWholesale.Checked);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (var item in dlg.SelectedItems)
                    {
                        var ex = _cart.FirstOrDefault(x => x.ProductId == item.ProductId);
                        if (ex != null) ex.Quantity += item.Quantity;
                        else _cart.Add(item);
                    }
                    RefreshCart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinesGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (_linesGrid.Columns[e.ColumnIndex].Name != "Remove") return;
            if (e.RowIndex >= _cart.Count) return;

            var line = _cart[e.RowIndex];
            _cart.RemoveAt(e.RowIndex);
            RefreshCart();
                    }

        private void LinesGrid_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || e.RowIndex >= _cart.Count) return;
            if (_linesGrid.Columns[e.ColumnIndex].Name == "Qty")
            {
                if (!int.TryParse(e.FormattedValue?.ToString(), out int qty) || qty < 1)
                {
                    e.Cancel = true;
                    _linesGrid.Rows[e.RowIndex].ErrorText = "الكمية يجب أن تكون رقم صحيح أكبر من الصفر";
                }
                else
                {
                    _linesGrid.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
        }

        private void LinesGrid_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || e.RowIndex >= _cart.Count) return;
            if (_linesGrid.Columns[e.ColumnIndex].Name == "Qty")
            {
                var row = _linesGrid.Rows[e.RowIndex];
                if (row.Cells["Qty"].Value == null) return;
                
                if (int.TryParse(row.Cells["Qty"].Value.ToString(), out int newQty) && newQty >= 1)
                {
                    var line = _cart[e.RowIndex];
                    line.Quantity = newQty;
                    double unitPrice = _rbWholesale.Checked ? line.Product.WholesalePrice : line.Product.Price;
                    line.TotalPrice = newQty * unitPrice;
                    row.Cells["Total"].Value = Theme.LYD(line.TotalPrice);
                    RecalcTotals();
                }
            }
        }

        private void RefreshCart()
        {
            bool ws = _rbWholesale.Checked;

            _linesGrid.Rows.Clear();
            foreach (var l in _cart)
            {
                double unitPrice = ws ? l.Product.WholesalePrice : l.Product.Price;
                l.TotalPrice = unitPrice * l.Quantity;
                _linesGrid.Rows.Add(l.Product.Name, l.Quantity,
                    Theme.LYD(unitPrice), Theme.LYD(l.TotalPrice), "✕");
            }

            RecalcTotals();
        }

        private void RecalcTotals()
        {
            bool ws = _rbWholesale.Checked;
            double sub = _cart.Sum(l => l.TotalPrice);
            double prev = ws && _cbClient.SelectedItem is Customer wc ? wc.OpeningBalance : 0;

            _lblSub.Text = Theme.LYD(sub);
            _lblBalance.Text = Theme.LYD(prev);
            _lblGrand.Text = Theme.LYD(sub + prev);
        }


        //  UI EVENTS
        //  
        // ══════════════════════════════════════════════════════════════════════
        private void _rbType_CheckedChanged(object? sender, EventArgs e)
        {
            bool ws = _rbWholesale.Checked;
            _retailPanel.Visible = !ws;
            _wholesalePanel.Visible = ws;
            lblBalanceTitle.Visible = ws;
            _lblBalance.Visible = ws;
                        RefreshCart();
        }

        private void _cbClient_SelectedIndexChanged(object? sender, EventArgs e) => RecalcTotals();
        private void _txCustomer_TextChanged(object? sender, EventArgs e) => RecalcTotals();

        private void BtnClear_Click(object? s, EventArgs e)
        {
            _editingOrder = null;
            h1Label.Text = "🛒  إدخال طلب جديد";
            _cart.Clear();
            _linesGrid.Rows.Clear();
            _txCustomer.Text = "";
            _txCustomerExtra.Text = "";
            _cbClient.SelectedIndex = -1;
            _rbRetail.Checked = true;
            _chkIsDeliveryRetail.Checked = false;
            _chkIsDeliveryWholesale.Checked = false;
            _lblDeliveryRetail.Text = "لم يحدد";
            _lblDeliveryWholesale.Text = "لم يحدد";
            _txPaidRetail.Text = "0";
            _txPaidWholesale.Text = "0";
            RecalcTotals();

        }

        private void BtnSave_Click(object? s, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("السلة فارغة، يرجى إضافة منتجات.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ws = _rbWholesale.Checked;
            string customer = ws ? (_cbClient.SelectedItem as Customer)?.Name ?? "" : _txCustomer.Text.Trim();

            if (string.IsNullOrWhiteSpace(customer))
            {
                MessageBox.Show("يرجى إدخال اسم العميل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ws && _txCustomer.Text.Any(char.IsDigit))
            {
                MessageBox.Show("الرجاء إدخال اسم العميل بحروف فقط (بدون أرقام).", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ws && !string.IsNullOrWhiteSpace(_txCustomerExtra.Text) && !_txCustomerExtra.Text.All(char.IsDigit))
            {
                MessageBox.Show("الرجاء إدخال رقم الهاتف كأرقام فقط.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nextId = _editingOrder?.Id ?? 0;
            if (_editingOrder == null)
            {
                var dtMax = DatabaseHelper.ExecuteQuery("SELECT ISNULL(MAX(CAST(order_number AS INT)), 0) + 1 FROM [order]");
                nextId = Convert.ToInt32(dtMax.Rows[0][0]);
            }

            var order = _editingOrder ?? new Order { Id = nextId };

            order.OrderDate = DateTime.Today;
            order.CustomerName = customer;
            order.CustomerPhone = ws ? "" : _txCustomerExtra.Text.Trim();
            order.Customer = ws ? _cbClient.SelectedItem as Customer : null;
            order.IsDelivery = ws ? _chkIsDeliveryWholesale.Checked : _chkIsDeliveryRetail.Checked;
            if (_editingOrder == null) order.Status = OrderStatus.Pending;

            string dateStr = ws ? _lblDeliveryWholesale.Text : _lblDeliveryRetail.Text;
            if (DateTime.TryParseExact(dateStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dDate))
                order.DeliveryDate = dDate;
            else
                order.DeliveryDate = DateTime.Today;

            double paid = 0;
            double.TryParse(ws ? _txPaidWholesale.Text : _txPaidRetail.Text, out paid);
            order.PaidAmount = paid;

            double total = 0;
            foreach (var l in _cart)
            {
                double unitPrice = ws ? l.Product.WholesalePrice : l.Product.Price;
                total += unitPrice * l.Quantity;
            }
            order.TotalPrice = total;

            if (order.PaidAmount >= order.TotalPrice) order.PaymentStatus = PaymentStatus.Paid;
            else if (order.PaidAmount > 0) order.PaymentStatus = PaymentStatus.Partial;
            else order.PaymentStatus = PaymentStatus.None;

            if (_editingOrder == null)
            {
                string insertQuery = @"
                    INSERT INTO [order] (order_number, customer_number, order_date, delivery_date, customer_name, customer_phone, is_delivery, payment_status, total_price, status)
                    VALUES (@order_number, @customer_number, @order_date, @delivery_date, @customer_name, @customer_phone, @is_delivery, @payment_status, @total_price, @status)";
                DatabaseHelper.ExecuteNonQuery(insertQuery, new[] {
                    new Microsoft.Data.SqlClient.SqlParameter("@order_number", order.Id.ToString()),
                    new Microsoft.Data.SqlClient.SqlParameter("@customer_number", ws && order.Customer != null ? order.Customer.Number : (object)DBNull.Value),
                    new Microsoft.Data.SqlClient.SqlParameter("@order_date", order.OrderDate),
                    new Microsoft.Data.SqlClient.SqlParameter("@delivery_date", order.DeliveryDate),
                    new Microsoft.Data.SqlClient.SqlParameter("@customer_name", order.CustomerName),
                    new Microsoft.Data.SqlClient.SqlParameter("@customer_phone", order.CustomerPhone),
                    new Microsoft.Data.SqlClient.SqlParameter("@is_delivery", order.IsDelivery),
                    new Microsoft.Data.SqlClient.SqlParameter("@payment_status", EnumHelper.ToString(order.PaymentStatus)),
                    new Microsoft.Data.SqlClient.SqlParameter("@total_price", order.TotalPrice),
                    new Microsoft.Data.SqlClient.SqlParameter("@status", EnumHelper.ToString(order.Status))
                });
                MessageBox.Show($"تم حفظ الطلب #{order.Id} بنجاح!", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string updateQuery = @"
                    UPDATE [order] SET 
                        customer_number = @customer_number, delivery_date = @delivery_date, customer_name = @customer_name, 
                        customer_phone = @customer_phone, is_delivery = @is_delivery, payment_status = @payment_status, 
                        total_price = @total_price, status = @status
                    WHERE order_number = @order_number";
                DatabaseHelper.ExecuteNonQuery(updateQuery, new[] {
                    new Microsoft.Data.SqlClient.SqlParameter("@order_number", order.Id.ToString()),
                    new Microsoft.Data.SqlClient.SqlParameter("@customer_number", ws && order.Customer != null ? order.Customer.Number : (object)DBNull.Value),
                    new Microsoft.Data.SqlClient.SqlParameter("@delivery_date", order.DeliveryDate),
                    new Microsoft.Data.SqlClient.SqlParameter("@customer_name", order.CustomerName),
                    new Microsoft.Data.SqlClient.SqlParameter("@customer_phone", order.CustomerPhone),
                    new Microsoft.Data.SqlClient.SqlParameter("@is_delivery", order.IsDelivery),
                    new Microsoft.Data.SqlClient.SqlParameter("@payment_status", EnumHelper.ToString(order.PaymentStatus)),
                    new Microsoft.Data.SqlClient.SqlParameter("@total_price", order.TotalPrice),
                    new Microsoft.Data.SqlClient.SqlParameter("@status", EnumHelper.ToString(order.Status))
                });
                DatabaseHelper.ExecuteNonQuery("DELETE FROM order_items WHERE order_number = @id", new[] { new Microsoft.Data.SqlClient.SqlParameter("@id", order.Id.ToString()) });
                MessageBox.Show($"تم تحديث الطلب #{order.Id} بنجاح!", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            foreach (var l in _cart)
            {
                double unitPrice = ws ? l.Product.WholesalePrice : l.Product.Price;
                l.TotalPrice = unitPrice * l.Quantity;
                
                string insertItemQuery = @"
                    INSERT INTO order_items (order_number, product_name, quantity, total_price)
                    VALUES (@order_number, @product_name, @quantity, @total_price)";
                DatabaseHelper.ExecuteNonQuery(insertItemQuery, new[] {
                    new Microsoft.Data.SqlClient.SqlParameter("@order_number", order.Id.ToString()),
                    new Microsoft.Data.SqlClient.SqlParameter("@product_name", l.Product.Name),
                    new Microsoft.Data.SqlClient.SqlParameter("@quantity", l.Quantity),
                    new Microsoft.Data.SqlClient.SqlParameter("@total_price", l.TotalPrice)
                });
            }

            BtnClear_Click(null, EventArgs.Empty);
        }

        // (Layout logic moved to Designer)

        // ══════════════════════════════════════════════════════════════════════
        //  CALENDAR LOGIC
        // ══════════════════════════════════════════════════════════════════════
        private void SetupCalendarLogic()
        {
            ConfigurePopupCalendar(_btnDeliveryRetail, _calRetail, _lblDeliveryRetail);
            ConfigurePopupCalendar(_btnDeliveryWholesale, _calWholesale, _lblDeliveryWholesale);
        }

        /// <summary>
        /// Wires a delivery trigger to show/hide a MonthCalendar as a floating
        /// popup anchored directly below the trigger, independent of panel nesting.
        /// 
        /// Strategy:
        ///   1. Re-parent the calendar to THIS UserControl so it is never clipped
        ///      by an intermediate panel and sits on top of everything.
        ///   2. Use PointToScreen / PointToClient to translate the trigger's
        ///      bottom-left corner into coordinates relative to THIS control.
        ///   3. Call BringToFront() every time the calendar is made visible.
        /// </summary>
        private void ConfigurePopupCalendar(
            Control trigger, MonthCalendar cal, Label displayLabel)
        {
            ArgumentNullException.ThrowIfNull(trigger);
            ArgumentNullException.ThrowIfNull(cal);
            ArgumentNullException.ThrowIfNull(displayLabel);

            // Re-parent the calendar to the root UserControl once
            cal.Visible = false;
            if (cal.Parent != this)
            {
                cal.Parent?.Controls.Remove(cal);
                this.Controls.Add(cal);
            }

            trigger.Click += (_, _) =>
            {
                if (trigger is CheckBox { Checked: false })
                {
                    cal.Visible = false;
                    return;
                }

                if (cal.Visible)
                {
                    cal.Visible = false;
                    return;
                }

                // Compute position: screen coords of trigger's bottom-left corner
                // then translate to THIS control's client coords.
                Point screenPt = trigger.PointToScreen(new Point(0, trigger.Height));
                Point clientPt = this.PointToClient(screenPt);

                // Keep the calendar fully on-screen horizontally
                int calX = Math.Max(0,
                    Math.Min(clientPt.X, this.ClientSize.Width - cal.Width));
                int calY = clientPt.Y + 4;   // 4 px gap below the button

                cal.Location = new Point(calX, calY);
                cal.Visible = true;
                cal.BringToFront();
            };

            cal.DateSelected += (_, e) =>
            {
                displayLabel.Text = e.Start.ToString("dd/MM/yyyy");
                cal.Visible = false;
            };

            // Clicking anywhere outside the calendar hides it
            this.MouseDown += (_, me) =>
            {
                if (cal.Visible && !cal.Bounds.Contains(me.Location))
                    cal.Visible = false;
            };
        }

        // ══════════════════════════════════════════════════════════════════════
        //  HELPERS
        // ══════════════════════════════════════════════════════════════════════
        private void AddCardBorder(Panel p)
        {
            p.Paint += (_, e) =>
            {
                using var pen = new Pen(Theme.SurfaceBorder, 1f);
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, p.Width - 1, p.Height - 1));
            };
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            // When the screen is shown, reload the data from the Database
            if (this.Visible)
            {
                BindComboBoxes();
            }
        }

        public void LoadOrder(Order o)
        {
            BtnClear_Click(null, EventArgs.Empty);
            _editingOrder = o;
            h1Label.Text = $"📝 تعديل الطلب #{o.Id}";

            bool ws = o.CustomerId != null;
            if (ws)
            {
                _rbWholesale.Checked = true;
                foreach(Customer item in _cbClient.Items)
                {
                    if(item.Id == o.CustomerId || item.Number == o.CustomerId?.ToString()) { 
                        _cbClient.SelectedItem = item; break; 
                    }
                }
                _chkIsDeliveryWholesale.Checked = o.IsDelivery;
                _lblDeliveryWholesale.Text = o.DeliveryDate.ToString("dd/MM/yyyy");
            }
            else
            {
                _rbRetail.Checked = true;
                _txCustomer.Text = o.CustomerName;
                _txCustomerExtra.Text = o.CustomerPhone;
                _chkIsDeliveryRetail.Checked = o.IsDelivery;
                _lblDeliveryRetail.Text = o.DeliveryDate.ToString("dd/MM/yyyy");
                _txPaidRetail.Text = o.PaidAmount.ToString();
            }

            _cart.Clear();
            var dtItems = DatabaseHelper.ExecuteQuery("SELECT product_name, quantity, total_price FROM order_items WHERE order_number = @id", new[] { new Microsoft.Data.SqlClient.SqlParameter("@id", o.Id.ToString()) });
            
            foreach (System.Data.DataRow row in dtItems.Rows)
            {
                var pName = row["product_name"].ToString() ?? "";
                
                var dtProd = DatabaseHelper.ExecuteQuery("SELECT price, unit, category FROM products WHERE product_name = @pn", new[] { new Microsoft.Data.SqlClient.SqlParameter("@pn", pName) });
                if (dtProd.Rows.Count > 0)
                {
                    var pr = dtProd.Rows[0];
                    var prod = new Product { 
                        Name = pName, 
                        Price = Convert.ToDouble(pr["price"]), 
                        WholesalePrice = Convert.ToDouble(pr["price"]),
                        Unit = EnumHelper.FromString<ProductUnit>(pr["unit"].ToString() ?? "piece"),
                        Category = EnumHelper.FromString<ProductCategory>(pr["category"].ToString() ?? "other")
                    };
                    
                    _cart.Add(new OrderItem
                    {
                        Product = prod,
                        ProductId = 0,
                        Quantity = Convert.ToDouble(row["quantity"]),
                        TotalPrice = Convert.ToDouble(row["total_price"])
                    });
                }
            }

            if (ws)
            {
                _txPaidWholesale.Text = o.PaidAmount.ToString();
            }

            RefreshCart();
        }


    }
}
