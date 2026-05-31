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
        private readonly List<OrderLine> _cart = new();

        // ── Constructor ───────────────────────────────────────────────────────
        public OrderEntryControl()
        {
            InitializeComponent();
            ApplyTheme();
            SetupCalendarLogic();
            BindComboBoxes();
            
            _btnSelectProducts.Click += BtnSelectProducts_Click;
        }

        // ══════════════════════════════════════════════════════════════════════
        //  THEME & SETUP
        // ══════════════════════════════════════════════════════════════════════
        private void ApplyTheme()
        {
            this.BackColor = Theme.Background;
            
            // Header
            headerPanel.BackColor = Theme.Surface;
            h1Label.Font = Theme.FontH1;
            h1Label.ForeColor = Theme.TextPrimary;
            sepBar.BackColor = Theme.AccentGreen;

            // Panels
            bodyTable.BackColor = Theme.Background;
            infoPanel.BackColor = Theme.Background;
            leftPanel.BackColor = Theme.Background;
            
            _retailPanel.BackColor = Theme.Background;
            _wholesalePanel.BackColor = Theme.Background;
            btnActFlow.BackColor = Theme.Background;

            // Customer panels
            lblOrderType.Font    = Theme.FontBodyB;
            _rbRetail.Font       = Theme.FontBody;
            _rbWholesale.Font    = Theme.FontBody;
            lblCustomerName.Font = Theme.FontBodyB;
            _txCustomer.Font     = Theme.FontBody;
            _txCustomerExtra.Font = Theme.FontBody;
            lblWholesaleClient.Font = Theme.FontBodyB;
            _cbClient.Font       = Theme.FontBody;

            // Summary card
            lblSummary.Font      = Theme.FontH2;
            lblSubTitle.Font     = Theme.FontBodyB;
            _lblSub.Font         = Theme.FontBodyB;
            lblBalanceTitle.Font = Theme.FontBodyB;
            _lblBalance.Font     = Theme.FontBodyB;
            lblGrandTitle.Font   = Theme.FontBodyB;

            // Cart section label
            lblCartTitle.Font    = Theme.FontH2;
            lblCartTitle.ForeColor = Theme.TextPrimary;

            // Buttons
            _btnSave.BackColor = Theme.AccentGreen;
            _btnSave.Font = Theme.FontBodyB;
            _btnSave.ForeColor = Theme.TextOnAccent;
            
            _btnClear.BackColor = Theme.TextSecondary;
            _btnClear.Font = Theme.FontBodyB;
            _btnClear.ForeColor = Theme.TextOnAccent;
            
            _btnDeliveryRetail.BackColor = Theme.AccentBlue;
            _btnDeliveryRetail.Font = Theme.FontBodyB;
            _btnDeliveryRetail.ForeColor = Theme.TextOnAccent;
            
            _btnDeliveryWholesale.BackColor = Theme.AccentBlue;
            _btnDeliveryWholesale.Font = Theme.FontBodyB;
            _btnDeliveryWholesale.ForeColor = Theme.TextOnAccent;

            // Add card borders for info sections
            AddCardBorder(typeCard);
            AddCardBorder(sumCard);

            // Style the cart DataGridView
            GridHelper.Style(_linesGrid, readOnly: false, rtl: true);
            _linesGrid.Columns.Clear();
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Product", HeaderText = "المنتج",   FillWeight = 38, ReadOnly = true });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qty",     HeaderText = "الكمية",   FillWeight = 12, ReadOnly = false });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price",   HeaderText = "السعر",    FillWeight = 20, ReadOnly = true });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total",   HeaderText = "الإجمالي", FillWeight = 20, ReadOnly = true });
            // Remove-row button column
            var removeCol = new DataGridViewButtonColumn
            {
                Name     = "Remove",
                HeaderText = "",
                Text     = "✕",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width    = 36,
                FillWeight = 10,
                ReadOnly = true
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
            Color focusBorder  = Color.FromArgb(53, 133, 142);
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
                using var pen  = new Pen(focused ? focusBorder : normalBorder, focused ? 2f : 1.5f);
                e.Graphics.DrawPath(pen, path);
            };

            tx.Enter += (_, _) => { focused = true;  wrap.Invalidate(); };
            tx.Leave += (_, _) => { focused = false; wrap.Invalidate(); };
            wrap.Click += (_, _) => tx.Focus();
        }

        private void BindComboBoxes()
        {
            // Clear the list first so we don't get duplicates when refreshing!
            _cbClient.Items.Clear();

            foreach (var c in MockData.WholesaleClients)
            {
                _cbClient.Items.Add(c);
            }
        }



        // ══════════════════════════════════════════════════════════════════════
        //  CART LOGIC
        // ══════════════════════════════════════════════════════════════════════
        private void BtnSelectProducts_Click(object? sender, EventArgs e)
        {
            using var dlg = new Dialogs.ChooseProductsDialog(_rbWholesale.Checked, _cart);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _cart.Clear();
                _cart.AddRange(dlg.SelectedItems);
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
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (_linesGrid.Columns[e.ColumnIndex].Name != "Qty") return;

            // Ensure the value is a valid integer >= 1
            if (!int.TryParse(e.FormattedValue?.ToString(), out int newQty) || newQty < 1)
            {
                e.Cancel = true;
                _linesGrid.Rows[e.RowIndex].ErrorText = "يرجى إدخال رقم صحيح أكبر من الصفر";
            }
            else
            {
                _linesGrid.Rows[e.RowIndex].ErrorText = ""; // Clear any previous error
            }
        }

        private void LinesGrid_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (_linesGrid.Columns[e.ColumnIndex].Name != "Qty") return;
            if (e.RowIndex >= _cart.Count) return;

            var cellVal = _linesGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (int.TryParse(cellVal?.ToString(), out int newQty) && newQty >= 1)
            {
                var line = _cart[e.RowIndex];
                line.Quantity = newQty;
                _linesGrid.Rows[e.RowIndex].Cells["Total"].Value = Theme.LYD(line.LineTotal);
                RecalcTotals();
            }
        }

        private void RefreshCart()
        {
            bool ws = _rbWholesale.Checked;

            _linesGrid.Rows.Clear();
            foreach (var l in _cart)
            {
                l.UnitPrice = ws ? l.Product.WholesalePrice : l.Product.RetailPrice;
                _linesGrid.Rows.Add(l.Product.Name, l.Quantity,
                    Theme.LYD(l.UnitPrice), Theme.LYD(l.LineTotal), "✕");
            }

            RecalcTotals();
        }

        private void RecalcTotals()
        {
            bool ws = _rbWholesale.Checked;
            decimal sub  = _cart.Sum(l => l.LineTotal);
            decimal prev = ws && _cbClient.SelectedItem is WholesaleClient wc ? wc.RemainingBalance : 0m;

            _lblSub.Text     = Theme.LYD(sub);
            _lblBalance.Text = Theme.LYD(prev);
            _lblGrand.Text   = Theme.LYD(sub + prev);
        }



        // ══════════════════════════════════════════════════════════════════════
        //  UI EVENTS
        // ══════════════════════════════════════════════════════════════════════
        private void _rbType_CheckedChanged(object? sender, EventArgs e)
        {
            bool ws = _rbWholesale.Checked;
            _retailPanel.Visible    = !ws;
            _wholesalePanel.Visible = ws;
            _balanceRow.Visible     = ws;
            RefreshCart();
        }

        private void _cbClient_SelectedIndexChanged(object? sender, EventArgs e) => RecalcTotals();
        private void _txCustomer_TextChanged(object? sender, EventArgs e)         => RecalcTotals();

        private void BtnClear_Click(object? s, EventArgs e)
        {
            _cart.Clear();
            _linesGrid.Rows.Clear();
            _txCustomer.Text    = "";
            _txCustomerExtra.Text = "";
            _cbClient.SelectedIndex = -1;
            _rbRetail.Checked   = true;
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
                ? (_cbClient.SelectedItem as WholesaleClient)?.Name ?? ""
                : _txCustomer.Text.Trim();

            if (string.IsNullOrWhiteSpace(customer))
            {
                MessageBox.Show("يرجى إدخال اسم العميل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var order = new Order
            {
                Id              = MockData.NextOrderId(),
                Date            = DateTime.Today,
                Type            = ws ? OrderType.Wholesale : OrderType.Retail,
                CustomerName    = ws ? "" : customer,
                WholesaleClient = ws ? _cbClient.SelectedItem as WholesaleClient : null,
                Lines           = _cart.Select(l => new OrderLine
                {
                    Product  = l.Product,
                    Quantity = l.Quantity,
                    UnitPrice = l.UnitPrice
                }).ToList(),
                Status = OrderStatus.Pending
            };

            MockData.Orders.Add(order);

            MessageBox.Show($"تم حفظ الطلب #{order.Id} بنجاح!", "تم",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnClear_Click(null, EventArgs.Empty);
        }

        // (Layout logic moved to Designer)

        // ══════════════════════════════════════════════════════════════════════
        //  CALENDAR LOGIC
        // ══════════════════════════════════════════════════════════════════════
        private void SetupCalendarLogic()
        {
            ConfigurePopupCalendar(_btnDeliveryRetail,   _calRetail,   _lblDeliveryRetail);
            ConfigurePopupCalendar(_btnDeliveryWholesale, _calWholesale, _lblDeliveryWholesale);
        }

        /// <summary>
        /// Wires a delivery button to show/hide a MonthCalendar as a floating
        /// popup anchored directly below the button, independent of panel nesting.
        /// 
        /// Strategy:
        ///   1. Re-parent the calendar to THIS UserControl so it is never clipped
        ///      by an intermediate panel and sits on top of everything.
        ///   2. Use PointToScreen / PointToClient to translate the button's
        ///      bottom-left corner into coordinates relative to THIS control.
        ///   3. Call BringToFront() every time the calendar is made visible.
        /// </summary>
        private void ConfigurePopupCalendar(
            Control btn, MonthCalendar cal, Label displayLabel)
        {
            // Re-parent the calendar to the root UserControl once
            cal.Visible = false;
            if (cal.Parent != this)
            {
                cal.Parent?.Controls.Remove(cal);
                this.Controls.Add(cal);
            }

            btn.Click += (_, _) =>
            {
                if (cal.Visible)
                {
                    cal.Visible = false;
                    return;
                }

                // Compute position: screen coords of button's bottom-left corner
                // then translate to THIS control's client coords.
                Point screenPt = btn.PointToScreen(new Point(0, btn.Height));
                Point clientPt = this.PointToClient(screenPt);

                // Keep the calendar fully on-screen horizontally
                int calX = Math.Max(0,
                    Math.Min(clientPt.X, this.ClientSize.Width - cal.Width));
                int calY = clientPt.Y + 4;   // 4 px gap below the button

                cal.Location = new Point(calX, calY);
                cal.Visible  = true;
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

    }
}