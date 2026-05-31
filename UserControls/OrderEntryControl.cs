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
            _cbClient.ValueMember = "Id";

            foreach (var c in MockData.Customers)
            {
                _cbClient.Items.Add(c);
            }

            //foreach (var c in MockData.Customers)
            //{
            //    _cbClient.Items.Add(c);
            //}
        }

        // ══════════════════════════════════════════════════════════════════════
        //  CART LOGIC
        // ══════════════════════════════════════════════════════════════════════
        
        private void _btnSelectProducts_Click(object sender, EventArgs e)
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
            double prev = ws && _cbClient.SelectedItem is Customer wc ? wc.Balance : 0;

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
                MessageBox.Show("السلة فارغة، يرجى إضافة منتجات.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ws = _rbWholesale.Checked;
            string customer = ws
                ? (_cbClient.SelectedItem as Customer)?.Name ?? ""
                : _txCustomer.Text.Trim();

            if (string.IsNullOrWhiteSpace(customer))
            {
                MessageBox.Show("يرجى إدخال اسم العميل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ws && _txCustomer.Text.Any(char.IsDigit))
            {
                MessageBox.Show("الرجاء إدخال اسم العميل بحروف فقط (بدون أرقام).", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ws && !string.IsNullOrWhiteSpace(_txCustomerExtra.Text) && !_txCustomerExtra.Text.All(char.IsDigit))
            {
                MessageBox.Show("الرجاء إدخال رقم الهاتف كأرقام فقط.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var order = _editingOrder ?? new Order { Id = MockData.NextOrderId() };

            order.OrderDate = DateTime.Today;
            order.CustomerName = customer;
            order.CustomerPhone = ws ? "" : _txCustomerExtra.Text.Trim();
            order.Customer = ws ? _cbClient.SelectedItem as Customer : null;
            order.CustomerId = ws ? (_cbClient.SelectedItem as Customer)?.Id : null;
            order.IsDelivery = ws ? _chkIsDeliveryWholesale.Checked : _chkIsDeliveryRetail.Checked;
            order.Status = order.Status; // Keep existing status if editing
            if (_editingOrder == null) order.Status = OrderStatus.Pending;


            // Parse delivery date if specified
            string dateStr = ws ? _lblDeliveryWholesale.Text : _lblDeliveryRetail.Text;
            if (DateTime.TryParseExact(dateStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dDate))
            {
                order.DeliveryDate = dDate;
            }
            else
            {
                order.DeliveryDate = DateTime.Today; // Fallback
            }

            // Payment logic
            double paid = 0;
            double.TryParse(ws ? _txPaidWholesale.Text : _txPaidRetail.Text, out paid);
            order.PaidAmount = paid;

            // If editing, clear old items first and REVERT balance change
            if (_editingOrder != null)
            {
                var oldItems = MockData.OrderItems.Where(x => x.OrderId == order.Id).ToList();
                foreach (var item in oldItems) MockData.OrderItems.Remove(item);
            }

            // Compute total and add order items
            double total = 0;
            foreach (var l in _cart)
            {
                double unitPrice = ws ? l.Product.WholesalePrice : l.Product.Price;
                var oi = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = l.Product.Id,
                    Product = l.Product,
                    Quantity = l.Quantity,
                    TotalPrice = unitPrice * l.Quantity,
                    Order = order
                };
                MockData.OrderItems.Add(oi);
                total += oi.TotalPrice;
            }
            order.TotalPrice = total;

            // Finalize payment status
            if (order.PaidAmount >= order.TotalPrice) order.PaymentStatus = PaymentStatus.Paid;
            else if (order.PaidAmount > 0) order.PaymentStatus = PaymentStatus.Partial;
            else order.PaymentStatus = PaymentStatus.None;

            if (_editingOrder == null)
            {
                MockData.Orders.Add(order);
                MessageBox.Show($"تم حفظ الطلب #{order.Id} بنجاح!", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"تم تحديث الطلب #{order.Id} بنجاح!", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            // When the screen is shown, reload the data from MockData
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
                _cbClient.SelectedItem = MockData.Customers.FirstOrDefault(c => c.Id == o.CustomerId);
                _chkIsDeliveryWholesale.Checked = o.IsDelivery;
                _lblDeliveryWholesale.Text = o.DeliveryDate.ToString("dd/MM/yyyy");
            }
            else
            {
                _rbRetail.Checked = true;
                _txCustomer.Text = o.CustomerName;
                // Note: Phone isn't explicitly in Order model but we use CustomerPhone
                _txCustomerExtra.Text = o.CustomerPhone;
                _chkIsDeliveryRetail.Checked = o.IsDelivery;
                _lblDeliveryRetail.Text = o.DeliveryDate.ToString("dd/MM/yyyy");
                _txPaidRetail.Text = o.PaidAmount.ToString();
            }

            // Load items
            _cart.Clear();
            var items = MockData.OrderItems.Where(i => i.OrderId == o.Id);
            foreach (var i in items)
            {
                _cart.Add(new OrderItem
                {
                    Product = i.Product,
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    TotalPrice = i.TotalPrice
                });
            }

            if (ws)
            {
                _txPaidWholesale.Text = o.PaidAmount.ToString();
            }

            RefreshCart();
        }


    }
}
