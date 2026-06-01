using sweetSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem.Dialogs
{
    public partial class ChooseProductsDialog : BaseDialog
    {
        public List<OrderItem> SelectedItems { get; } = new List<OrderItem>();
        private readonly Dictionary<int, Panel> _cardMap = new();
        private readonly bool _isWholesale;

        public ChooseProductsDialog(bool isWholesale) : base("اختيار المنتجات", 600)
        {
            InitializeComponent();
            _isWholesale = isWholesale;
            this.Width = 800;
            
            if (BtnSave != null) BtnSave.Text = "✔ تأكيد الإضافة";
            if (_lblSelectionCount != null) _lblSelectionCount.ForeColor = Theme.TextPrimary;
            
            this.Load += ChooseProductsDialog_Load;
        }

        private void ChooseProductsDialog_Load(object? sender, EventArgs e)
        {
            LoadCatalog();
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
                                   p.Category.ToString().Contains(query, StringComparison.OrdinalIgnoreCase);
            }

            _catalogFlow.ResumeLayout(true);
        }

        private void LoadCatalog()
        {
            try
            {
                _catalogFlow.SuspendLayout(); 
                _catalogFlow.Controls.Clear();
                _cardMap.Clear();

                var dt = DatabaseHelper.ExecuteQuery("SELECT product_name, category, price, unit, picture_url FROM products");
                
                if (dt == null || dt.Rows.Count == 0)
                {
                    var lblEmpty = new Label
                    {
                        Text = "لا توجد منتجات مسجلة في النظام حالياً",
                        Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                        ForeColor = Theme.TextSecondary,
                        AutoSize = true,
                        Margin = new Padding(20)
                    };
                    _catalogFlow.Controls.Add(lblEmpty);
                    _catalogFlow.ResumeLayout(true);
                    return;
                }

                var products = new List<Product>();
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    string name = row["product_name"].ToString() ?? "";
                    
                    var p = new Product
                    {
                        Id = Math.Abs(name.GetHashCode()),
                        Name = name,
                        Price = Convert.ToDouble(row["price"]),
                        WholesalePrice = Convert.ToDouble(row["price"])
                    };

                    try { p.Category = EnumHelper.FromString<ProductCategory>(row["category"].ToString() ?? ""); } catch {}
                    try { p.Unit = EnumHelper.FromString<ProductUnit>(row["unit"].ToString() ?? ""); } catch {}
                    try 
                    { 
                        if (row.Table.Columns.Contains("picture_url") && row["picture_url"] != DBNull.Value) 
                            p.ImagePath = row["picture_url"].ToString(); 
                    } catch {}

                    products.Add(p);
                }

                foreach (var p in products)
                {
                    var card = BuildProductCard(p);
                    _catalogFlow.Controls.Add(card);
                    _cardMap[p.Id] = card;
                    UpdateCardBadge(p);
                }

                _catalogFlow.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading catalog: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _catalogFlow.ResumeLayout(true);
            }
        }

        private Panel BuildProductCard(Product p)
        {
            const int CARD_W = 170;
            const int CARD_H = 200;

            var card = new Panel
            {
                Width = CARD_W,
                Height = CARD_H,
                Cursor = Cursors.Hand,
                Margin = new Padding(10),
                Tag = p
            };

            var picBox = new PictureBox
            {
                Width = CARD_W,
                Height = 110,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(245, 239, 230),
                Cursor = Cursors.Hand,
                Tag = p
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

            var nameLabel = new Label
            {
                Text = p.Name,
                AutoSize = false,
                Width = CARD_W - 12,
                Height = 36,
                Left = 6,
                Top = 114,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Cairo", 8.5f, FontStyle.Bold),
                ForeColor = Theme.TextPrimary,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Tag = p
            };

            var priceLabel = new Label
            {
                Text = Theme.LYD(_isWholesale ? p.WholesalePrice : p.Price),
                AutoSize = false,
                Width = CARD_W - 12,
                Height = 20,
                Left = 6,
                Top = 150,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Cairo", 8f),
                ForeColor = Theme.AccentGreen,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Tag = p,
                Name = $"price_{p.Id}"
            };

            var minusBtn = new Label
            {
                Text = "−",
                AutoSize = false,
                Width = 26,
                Height = 26,
                Left = 4,
                Top = 4,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Theme.AccentRed,
                Cursor = Cursors.Hand,
                Visible = false,
                Tag = p,
                Name = $"minus_{p.Id}"
            };
            MakeRound(minusBtn, 13);

            var badge = new Label
            {
                Text = "",
                AutoSize = false,
                Width = 26,
                Height = 26,
                Left = CARD_W - 30,
                Top = 4,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = Theme.FontBadge,
                ForeColor = Color.White,
                BackColor = Theme.AccentGreen,
                Cursor = Cursors.Hand,
                Visible = false,
                Tag = p,
                Name = $"badge_{p.Id}"
            };
            MakeRound(badge, 13);

            var addBtn = new Label
            {
                Text = "+ أضف",
                AutoSize = false,
                Width = CARD_W,
                Height = 28,
                Left = 0,
                Top = CARD_H - 28,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Cairo", 8.5f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Theme.AccentGreen,
                Cursor = Cursors.Hand,
                Tag = p,
                Name = $"add_{p.Id}"
            };

            card.Controls.AddRange(new Control[] { picBox, nameLabel, priceLabel, addBtn, badge, minusBtn });

            bool hovered = false;
            card.Paint += (_, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                using var path = RoundedPanel.RoundRect(rect, 10);
                using (var br = new SolidBrush(Color.White)) e.Graphics.FillPath(br, path);
                Color borderColor = hovered ? Theme.AccentGreen : Theme.SurfaceBorder;
                using var pen = new Pen(borderColor, hovered ? 2f : 1f);
                e.Graphics.DrawPath(pen, path);
            };
            card.MouseEnter += (_, _) => { hovered = true; card.Invalidate(); };
            card.MouseLeave += (_, _) => { hovered = false; card.Invalidate(); };

            card.Resize += (_, _) => ClipToRounded(card, 10);
            ClipToRounded(card, 10);

            async void OnAddClick(object? sender, EventArgs args) 
            {
                AddToCart(p);
                var oldColor = card.BackColor;
                card.BackColor = Theme.AccentGold;
                await System.Threading.Tasks.Task.Delay(150);
                card.BackColor = oldColor;
            }
            card.Click += OnAddClick;
            picBox.Click += OnAddClick;
            nameLabel.Click += OnAddClick;
            priceLabel.Click += OnAddClick;
            addBtn.Click += OnAddClick;
            badge.Click += OnAddClick;

            void OnMinusClick(object? sender, EventArgs args) => RemoveFromCart(p);
            minusBtn.Click += OnMinusClick;

            return card;
        }

        private static Image BuildPlaceholderImage(int w, int h, string productName)
        {
            int safeWidth = w > 0 ? w : 100;
            int safeHeight = h > 0 ? h : 100;
            string textToDraw = string.IsNullOrWhiteSpace(productName) ? "بدون اسم" : productName;
            var bmp = new Bitmap(safeWidth, safeHeight);

            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(245, 239, 230));

            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString("🍰", Theme.FontH1, Brushes.Gray, new RectangleF(0, 0, safeWidth, safeHeight - 16), sf);
            using var brush = new SolidBrush(Color.FromArgb(180, 140, 100));
            g.DrawString(textToDraw, Theme.FontSmall, brush, new RectangleF(2, safeHeight - 18, safeWidth - 4, 16), sf);
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

        private void AddToCart(Product p)
        {
            double pr = _isWholesale ? p.WholesalePrice : p.Price;
            var ex = SelectedItems.FirstOrDefault(l => l.Product.Id == p.Id);

            if (ex != null) ex.Quantity++;
            else SelectedItems.Add(new OrderItem { Product = p, ProductId = p.Id, Quantity = 1, TotalPrice = pr });

            UpdateCardBadge(p);
            UpdateSelectionCount();
        }

        private void RemoveFromCart(Product p)
        {
            var ex = SelectedItems.FirstOrDefault(l => l.Product.Id == p.Id);
            if (ex == null) return;

            ex.Quantity--;
            if (ex.Quantity <= 0) SelectedItems.Remove(ex);

            UpdateCardBadge(p);
            UpdateSelectionCount();
        }

        private void UpdateSelectionCount()
        {
            double count = SelectedItems.Sum(x => x.Quantity);
            if (_lblSelectionCount != null)
                _lblSelectionCount.Text = $"تم اختيار {count} منتجات";
        }

        private void UpdateCardBadge(Product p)
        {
            if (!_cardMap.TryGetValue(p.Id, out var card)) return;

            Label? badge = card.Controls.Find($"badge_{p.Id}", false).FirstOrDefault() as Label;
            Label? minusLbl = card.Controls.Find($"minus_{p.Id}", false).FirstOrDefault() as Label;

            var qty = SelectedItems.FirstOrDefault(l => l.Product.Id == p.Id)?.Quantity ?? 0;

            if (badge != null)
            {
                badge.Text = qty > 0 ? qty.ToString() : "";
                badge.Visible = qty > 0;
            }
            if (minusLbl != null)
            {
                minusLbl.Visible = qty > 0;
            }
        }
    }
}
