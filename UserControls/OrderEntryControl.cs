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
        private readonly Dictionary<int, Panel> _cardMap = new();

        // ── Constructor ───────────────────────────────────────────────────────
        public OrderEntryControl()
        {
            InitializeComponent();
            ApplyTheme();
            SetupCalendarLogic();
            LoadCatalog();
            BindComboBoxes();
        }

        // ══════════════════════════════════════════════════════════════════════
        //  THEME & SETUP
        // ══════════════════════════════════════════════════════════════════════
        private void ApplyTheme()
        {
            // Header
            h1Label.Font = Theme.FontH1;
            h1Label.ForeColor = Theme.TextPrimary;

            // Customer panels
            lblOrderType.Font    = Theme.FontBodyB;
            _rbRetail.Font       = Theme.FontBody;
            _rbWholesale.Font    = Theme.FontBody;
            lblCustomerName.Font = Theme.FontBodyB;
            _txCustomer.Font     = Theme.FontBody;
            _txCustomerExtra.Font = Theme.FontBody;
            lblCustomer.Font = Theme.FontBodyB;
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

            // Catalog section label
            lblCatalogTitle.Font = Theme.FontH2;
            lblCatalogTitle.ForeColor = Theme.TextPrimary;

            // Add card borders for info sections
            AddCardBorder(typeCard);
            AddCardBorder(sumCard);

            // Style the cart DataGridView
            GridHelper.Style(_linesGrid, readOnly: true, rtl: true);
            _linesGrid.Columns.Clear();
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Product", HeaderText = "المنتج",   FillWeight = 38 });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qty",     HeaderText = "الكمية",   FillWeight = 12 });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price",   HeaderText = "السعر",    FillWeight = 20 });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total",   HeaderText = "الإجمالي", FillWeight = 20 });
            // Remove-row button column
            var removeCol = new DataGridViewButtonColumn
            {
                Name     = "Remove",
                HeaderText = "",
                Text     = "✕",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width    = 36,
                FillWeight = 10
            };
            _linesGrid.Columns.Add(removeCol);
            _linesGrid.CellClick += LinesGrid_CellClick;

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

            foreach (var c in MockData.Customers)
            {
                _cbClient.Items.Add(c);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        //  CATALOG — Build product cards
        // ══════════════════════════════════════════════════════════════════════
        private void LoadCatalog()
        {
            _catalogFlow.SuspendLayout(); // Prevents screen flickering while drawing
            _catalogFlow.Controls.Clear();
            _cardMap.Clear();

            foreach (var p in MockData.Products)
            {
                var card = BuildProductCard(p);
                _catalogFlow.Controls.Add(card);
                _cardMap[p.Id] = card;

                // Ensure the badge is restored if the item is already in the cart
                UpdateCardBadge(p);
            }

            _catalogFlow.ResumeLayout();
        }

        private Panel BuildProductCard(Product p)
        {
            const int CARD_W = 170;
            const int CARD_H = 200;

            var card = new Panel
            {
                Width     = CARD_W,
                Height    = CARD_H,
                Cursor    = Cursors.Hand,
                Margin    = new Padding(10),
                Tag       = p
            };

            // ── Image area ──────────────────────────────────────────────────
            var picBox = new PictureBox
            {
                Width    = CARD_W,
                Height   = 110,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(245, 239, 230),
                Cursor   = Cursors.Hand,
                Tag      = p
            };

            string imgPath = GetAbsoluteImagePath(p.ImagePath);
            if (File.Exists(imgPath))
            {
                try
                {
                    var bytes = File.ReadAllBytes(imgPath);
                    using var ms = new MemoryStream(bytes);
                    using var img = Image.FromStream(ms);
                    picBox.Image = new Bitmap(img);
                }
                catch
                {
                    picBox.Image = BuildPlaceholderImage(CARD_W, 110, p.Name);
                }
            }
            else
            {
                picBox.Image = BuildPlaceholderImage(CARD_W, 110, p.Name);
            }

            // ── Product name label ───────────────────────────────────────────
            var nameLabel = new Label
            {
                Text      = p.Name,
                AutoSize  = false,
                Width     = CARD_W - 12,
                Height    = 36,
                Left      = 6,
                Top       = 114,
                TextAlign = ContentAlignment.MiddleCenter,
                Font      = new Font("Cairo", 8.5f, FontStyle.Bold),
                ForeColor = Theme.TextPrimary,
                BackColor = Color.Transparent,
                Cursor    = Cursors.Hand,
                Tag       = p
            };

            // ── Price label ──────────────────────────────────────────────────
            var priceLabel = new Label
            {
                Text      = Theme.LYD(_rbWholesale.Checked ? p.WholesalePrice : p.Price),
                AutoSize  = false,
                Width     = CARD_W - 12,
                Height    = 20,
                Left      = 6,
                Top       = 150,
                TextAlign = ContentAlignment.MiddleCenter,
                Font      = new Font("Cairo", 8f),
                ForeColor = Theme.AccentGreen,
                BackColor = Color.Transparent,
                Cursor    = Cursors.Hand,
                Tag       = p,
                Name      = $"price_{p.Id}"
            };

            // ── Minus button (hidden until qty > 0) ─────────────────────────
            var minusBtn = new Label
            {
                Text      = "−",
                AutoSize  = false,
                Width     = 26,
                Height    = 26,
                Left      = 4,
                Top       = 4,
                TextAlign = ContentAlignment.MiddleCenter,
                Font      = new Font("Arial", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Theme.AccentRed,
                Cursor    = Cursors.Hand,
                Visible   = false,
                Tag       = p,
                Name      = $"minus_{p.Id}"
            };
            MakeRound(minusBtn, 13);

            // ── Quantity badge ───────────────────────────────────────────────
            var badge = new Label
            {
                Text      = "",
                AutoSize  = false,
                Width     = 26,
                Height    = 26,
                Left      = CARD_W - 30,
                Top       = 4,
                TextAlign = ContentAlignment.MiddleCenter,
                Font      = Theme.FontBadge,
                ForeColor = Color.White,
                BackColor = Theme.AccentGreen,
                Cursor    = Cursors.Hand,
                Visible   = false,
                Tag       = p,
                Name      = $"badge_{p.Id}"
            };
            MakeRound(badge, 13);

            // ── Add-to-cart area at bottom ───────────────────────────────────
            var addBtn = new Label
            {
                Text      = "+ أضف",
                AutoSize  = false,
                Width     = CARD_W,
                Height    = 28,
                Left      = 0,
                Top       = CARD_H - 28,
                TextAlign = ContentAlignment.MiddleCenter,
                Font      = new Font("Cairo", 8.5f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Theme.AccentGreen,
                Cursor    = Cursors.Hand,
                Tag       = p,
                Name      = $"add_{p.Id}"
            };

            card.Controls.AddRange(new Control[] { picBox, nameLabel, priceLabel, addBtn, badge, minusBtn });

            // ── Card painting (border + shadow effect) ───────────────────────
            bool hovered = false;
            card.Paint += (_, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                using var path = RoundedPanel.RoundRect(rect, 10);
                // Fill
                using (var br = new SolidBrush(Color.White)) e.Graphics.FillPath(br, path);
                // Border
                Color borderColor = hovered ? Theme.AccentGreen : Theme.SurfaceBorder;
                using var pen = new Pen(borderColor, hovered ? 2f : 1f);
                e.Graphics.DrawPath(pen, path);
            };
            card.MouseEnter += (_, _) => { hovered = true;  card.Invalidate(); };
            card.MouseLeave += (_, _) => { hovered = false; card.Invalidate(); };

            // ── Clip card to rounded rect ────────────────────────────────────
            card.Resize += (_, _) => ClipToRounded(card, 10);
            ClipToRounded(card, 10);

            // ── Wire click events ────────────────────────────────────────────
            void OnAddClick(object? _, EventArgs __) => AddToCart(p);
            card.Click        += OnAddClick;
            picBox.Click      += OnAddClick;
            nameLabel.Click   += OnAddClick;
            priceLabel.Click  += OnAddClick;
            addBtn.Click      += OnAddClick;
            badge.Click       += OnAddClick;

            void OnMinusClick(object? _, EventArgs __) => RemoveFromCart(p);
            minusBtn.Click    += OnMinusClick;

            return card;
        }

        // ── Helpers for card visuals ─────────────────────────────────────────
        private static Image BuildPlaceholderImage(int w, int h, string productName)
        {
            var bmp = new Bitmap(w, h);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(245, 239, 230));
            string emoji = "🍰";
            using var font = new Font("Segoe UI Emoji", 28f);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(emoji, font, Brushes.Gray, new RectangleF(0, 0, w, h - 16), sf);
            using var smallFont = new Font("Cairo", 6.5f);
            g.DrawString(productName, smallFont, new SolidBrush(Color.FromArgb(180, 140, 100)),
                new RectangleF(2, h - 18, w - 4, 16), sf);
            return bmp;
        }

        private static void MakeRound(Control c, int radius)
        {
            c.Region = new Region(RoundedPanel.RoundRect(new Rectangle(0, 0, c.Width, c.Height), radius));
        }

        private static void ClipToRounded(Control c, int radius)
        {
            c.Region = new Region(RoundedPanel.RoundRect(new Rectangle(0, 0, c.Width, c.Height), radius));
        }

        private static string GetAbsoluteImagePath(string relative)
        {
            if (string.IsNullOrWhiteSpace(relative)) return "";
            string baseDir = AppDomain.CurrentDomain.BaseDirectory ?? Application.StartupPath;
            // ensure images folder exists
            string imagesDir = Path.Combine(baseDir, "Images", "Products");
            if (!Directory.Exists(imagesDir)) Directory.CreateDirectory(imagesDir);
            return Path.Combine(baseDir, relative);
        }

        // ══════════════════════════════════════════════════════════════════════
        //  CART LOGIC
        // ══════════════════════════════════════════════════════════════════════
        private void AddToCart(Product p)
        {
            bool ws    = _rbWholesale.Checked;
            double pr = ws ? p.WholesalePrice : p.Price;
            var ex = _cart.FirstOrDefault(l => l.Product.Id == p.Id);

            if (ex != null) ex.Quantity++;
            else _cart.Add(new OrderItem { Product = p, ProductId = p.Id, Quantity = 1, TotalPrice = pr });

            RefreshCart();
            UpdateCardBadge(p);
        }

        private void RemoveFromCart(Product p)
        {
            var ex = _cart.FirstOrDefault(l => l.Product.Id == p.Id);
            if (ex == null) return;

            ex.Quantity--;
            if (ex.Quantity <= 0) _cart.Remove(ex);

            RefreshCart();
            UpdateCardBadge(p);
        }

        private void LinesGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (_linesGrid.Columns[e.ColumnIndex].Name != "Remove") return;
            if (e.RowIndex >= _cart.Count) return;

            var line = _cart[e.RowIndex];
            _cart.RemoveAt(e.RowIndex);
            RefreshCart();
            UpdateCardBadge(line.Product);
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
            double sub  = _cart.Sum(l => l.TotalPrice);
            double prev = ws && _cbClient.SelectedItem is Customer wc ? wc.Balance : 0;

            _lblSub.Text     = Theme.LYD(sub);
            _lblBalance.Text = Theme.LYD(prev);
            _lblGrand.Text   = Theme.LYD(sub + prev);
        }

        private void UpdateCardBadge(Product p)
        {
            if (!_cardMap.TryGetValue(p.Id, out var card)) return;

            Label? badge   = card.Controls.Find($"badge_{p.Id}",   false).FirstOrDefault() as Label;
            Label? minusLbl = card.Controls.Find($"minus_{p.Id}",  false).FirstOrDefault() as Label;

            var qty = _cart.FirstOrDefault(l => l.Product.Id == p.Id)?.Quantity ?? 0;

            if (badge != null)
            {
                badge.Text    = qty > 0 ? qty.ToString() : "";
                badge.Visible = qty > 0;
            }
            if (minusLbl != null)
            {
                minusLbl.Visible = qty > 0;
            }
        }

        // Refresh all price labels when order type switches
        private void RefreshCatalogPrices()
        {
            bool ws = _rbWholesale.Checked;
            foreach (var p in MockData.Products)
            {
                if (!_cardMap.TryGetValue(p.Id, out var card)) continue;
                Label? lbl = card.Controls.Find($"price_{p.Id}", false).FirstOrDefault() as Label;
                if (lbl != null)
                    lbl.Text = Theme.LYD(ws ? p.WholesalePrice : p.Price);
            }
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
            RefreshCatalogPrices();
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

            // Reset all badges
            foreach (var p in MockData.Products) UpdateCardBadge(p);
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

            var order = new Order
            {
                Id              = MockData.NextOrderId(),
                OrderDate       = DateTime.Today,
                CustomerName    = ws ? "" : customer,
                Customer = ws ? _cbClient.SelectedItem as Customer : null,
                CustomerId = ws ? (_cbClient.SelectedItem as Customer)?.Id : null,
                Status = OrderStatus.Pending
            };

            // Compute total and add order items
            double total = 0;
            foreach (var l in _cart)
            {
                double unitPrice = ws ? l.Product.WholesalePrice : l.Product.Price;
                var oi = new OrderItem
                {
                    OrderId  = order.Id,
                    ProductId = l.Product.Id,
                    Product  = l.Product,
                    Quantity = l.Quantity,
                    TotalPrice = unitPrice * l.Quantity,
                    Order    = order
                };
                MockData.OrderItems.Add(oi);
                total += oi.TotalPrice;
            }
            order.TotalPrice = total;

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
        //  CATALOG SEARCH
        // ══════════════════════════════════════════════════════════════════════
        private void CatalogSearch_TextChanged(object? sender, EventArgs e)
        {
            string query = catalogSearch.Text.Trim();
            _catalogFlow.SuspendLayout();

            foreach (Control ctrl in _catalogFlow.Controls)
            {
                if (ctrl.Tag is Product p)
                    ctrl.Visible = string.IsNullOrWhiteSpace(query) ||
                                   p.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                   p.Category.ToString().Contains(query, StringComparison.OrdinalIgnoreCase);
            }

            _catalogFlow.ResumeLayout(true);
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
                LoadCatalog();
                BindComboBoxes();
            }
        }

    }
}
