using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem.Dialogs
{
    public partial class ChooseProductsDialog : Form
    {
        private readonly bool _isWholesale;
        private readonly List<OrderLine> _cart;
        private readonly Dictionary<int, Panel> _cardMap = new();

        public List<OrderLine> SelectedItems => _cart.ToList();

        public ChooseProductsDialog(bool isWholesale, IEnumerable<OrderLine> existingCart)
        {
            InitializeComponent();
            _isWholesale = isWholesale;
            
            // Deep copy the cart so we don't mutate the original until Confirm is clicked
            _cart = existingCart.Select(l => new OrderLine 
            { 
                Product = l.Product, 
                Quantity = l.Quantity, 
                UnitPrice = l.UnitPrice 
            }).ToList();

            ApplyTheme();
            LoadCatalog();
            UpdateSelectionSummary();
        }

        private void ApplyTheme()
        {
            this.BackColor = Theme.Background;
            headerPanel.BackColor = Theme.Surface;
            lblTitle.Font = Theme.FontH1;
            lblTitle.ForeColor = Theme.TextPrimary;
            sepBar.BackColor = Theme.AccentGreen;
            
            searchPanel.BackColor = Theme.Background;
            catalogSearch.Font = Theme.FontBody;
            
            bodyPanel.BackColor = Theme.Background;
            _catalogFlow.BackColor = Theme.Background;
            
            footerPanel.BackColor = Theme.Surface;
            btnConfirm.BackColor = Theme.AccentGreen;
            btnConfirm.Font = Theme.FontBodyB;
            btnConfirm.ForeColor = Theme.TextOnAccent;
            
            btnCancel.BackColor = Theme.TextSecondary;
            btnCancel.Font = Theme.FontBodyB;
            btnCancel.ForeColor = Theme.TextOnAccent;

            _lblSelectionCount.Font = Theme.FontBodyB;
            _lblSelectionCount.ForeColor = Theme.TextPrimary;
        }

        private void UpdateSelectionSummary()
        {
            int totalProducts = _cart.Count;
            int totalQty = _cart.Sum(c => c.Quantity);
            _lblSelectionCount.Text = $"تم اختيار {totalProducts} منتجات (إجمالي القطع: {totalQty})";
        }

        private void LoadCatalog()
        {
            _catalogFlow.SuspendLayout();
            _catalogFlow.Controls.Clear();
            _cardMap.Clear();

            foreach (var p in MockData.Products)
            {
                var card = BuildProductCard(p);
                _catalogFlow.Controls.Add(card);
                _cardMap[p.Id] = card;

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

            // Image area
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

            // Product name label
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

            // Price label
            var priceLabel = new Label
            {
                Text      = Theme.LYD(_isWholesale ? p.WholesalePrice : p.RetailPrice),
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

            // Minus button
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

            // Quantity badge
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

            // Add-to-cart area
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

            // Card painting
            bool hovered = false;
            bool flashed = false;
            card.Paint += (_, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                using var path = RoundedPanel.RoundRect(rect, 10);
                
                Color fill = flashed ? Theme.AccentGold : Color.White;
                using (var br = new SolidBrush(fill)) e.Graphics.FillPath(br, path);
                
                Color borderColor = hovered ? Theme.AccentGreen : Theme.SurfaceBorder;
                using var pen = new Pen(borderColor, hovered ? 2f : 1f);
                e.Graphics.DrawPath(pen, path);
            };
            card.MouseEnter += (_, _) => { hovered = true;  card.Invalidate(); };
            card.MouseLeave += (_, _) => { hovered = false; card.Invalidate(); };

            // Clip
            card.Resize += (_, _) => ClipToRounded(card, 10);
            ClipToRounded(card, 10);

            // Events
            void OnAddClick(object? _, EventArgs __)
            {
                AddToCart(p);
                flashed = true;
                card.Invalidate();
                var t = new System.Windows.Forms.Timer { Interval = 150 };
                t.Tick += (s, ev) => { flashed = false; card.Invalidate(); t.Stop(); t.Dispose(); };
                t.Start();
            }
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

        private void AddToCart(Product p)
        {
            decimal pr = _isWholesale ? p.WholesalePrice : p.RetailPrice;
            var ex = _cart.FirstOrDefault(l => l.Product.Id == p.Id);

            if (ex != null) ex.Quantity++;
            else _cart.Add(new OrderLine { Product = p, Quantity = 1, UnitPrice = pr });

            UpdateCardBadge(p);
            UpdateSelectionSummary();
        }

        private void RemoveFromCart(Product p)
        {
            var ex = _cart.FirstOrDefault(l => l.Product.Id == p.Id);
            if (ex == null) return;

            ex.Quantity--;
            if (ex.Quantity <= 0) _cart.Remove(ex);

            UpdateCardBadge(p);
            UpdateSelectionSummary();
        }

        private void UpdateCardBadge(Product p)
        {
            if (!_cardMap.TryGetValue(p.Id, out var card)) return;

            Label? badge   = card.Controls.Find($"badge_{p.Id}",   false).FirstOrDefault() as Label;
            Label? minusLbl = card.Controls.Find($"minus_{p.Id}",  false).FirstOrDefault() as Label;

            int qty = _cart.FirstOrDefault(l => l.Product.Id == p.Id)?.Quantity ?? 0;

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

        private void CatalogSearch_TextChanged(object? sender, EventArgs e)
        {
            string query = catalogSearch.Text.Trim();
            _catalogFlow.SuspendLayout();

            foreach (Control ctrl in _catalogFlow.Controls)
            {
                if (ctrl.Tag is Product p)
                    ctrl.Visible = string.IsNullOrWhiteSpace(query) ||
                                   p.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                   p.Category.Contains(query, StringComparison.OrdinalIgnoreCase);
            }

            _catalogFlow.ResumeLayout(true);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Helpers
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
            string imagesDir = Path.Combine(baseDir, "Images", "Products");
            if (!Directory.Exists(imagesDir)) Directory.CreateDirectory(imagesDir);
            return Path.Combine(baseDir, relative);
        }
    }
}
