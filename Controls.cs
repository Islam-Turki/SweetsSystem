using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace sweetSystem
{
    // ── Rounded Panel ─────────────────────────────────────────────────────────
    public class RoundedPanel : Panel
    {
        public int    Radius      { get; set; } = Theme.CornerRadius;
        public Color  BorderColor { get; set; } = Theme.SurfaceBorder;

        protected override void OnPaintBackground(PaintEventArgs e) { /* suppress flicker */ }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using var path = RoundRect(rect, Radius);
            using (var br = new SolidBrush(BackColor)) e.Graphics.FillPath(br, path);
            if (BorderColor != Color.Transparent)
            {
                using var pen = new Pen(BorderColor, 1f);
                e.Graphics.DrawPath(pen, path);
            }
            // Let children paint normally
            foreach (Control c in Controls)
            {
                if (!c.Visible) continue;
                var bmp = new System.Drawing.Bitmap(c.Width, c.Height);
                c.DrawToBitmap(bmp, new Rectangle(0, 0, c.Width, c.Height));
            }
        }

        public static GraphicsPath RoundRect(Rectangle r, int rad)
        {
            int d = Math.Max(1, rad * 2);
            var p = new GraphicsPath();
            p.AddArc(r.X,          r.Y,           d, d, 180, 90);
            p.AddArc(r.Right - d,  r.Y,           d, d, 270, 90);
            p.AddArc(r.Right - d,  r.Bottom - d,  d, d,   0, 90);
            p.AddArc(r.X,          r.Bottom - d,  d, d,  90, 90);
            p.CloseFigure();
            return p;
        }
    }

    // ── Flat Rounded Button ───────────────────────────────────────────────────
    public class FlatButton : Button
    {
        public int Radius { get; set; } = 6;

        public FlatButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            BackColor = Theme.AccentGreen;
            ForeColor = Color.White;
            Font      = Theme.FontBodyB;
            Cursor    = Cursors.Hand;
            Height    = Theme.ButtonHeight;
            UseVisualStyleBackColor = false;
        }

        private bool _hover, _pressed;
        protected override void OnMouseEnter(EventArgs e) { _hover   = true;  Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hover   = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { _pressed = true;  Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp  (MouseEventArgs e) { _pressed = false; Invalidate(); base.OnMouseUp(e);   }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color bg = _pressed ? Shift(BackColor, -25) : _hover ? Shift(BackColor, 18) : BackColor;
            using var path = RoundedPanel.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Radius);
            using (var br = new SolidBrush(bg)) g.FillPath(br, path);
            var sf = new StringFormat
            {
                Alignment     = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags   = StringFormatFlags.NoWrap
            };
            using var tf = new SolidBrush(ForeColor);
            g.DrawString(Text, Font, tf, new RectangleF(0, 0, Width, Height), sf);
        }

        private static Color Shift(Color c, int d) =>
            Color.FromArgb(
                Math.Clamp(c.R + d, 0, 255),
                Math.Clamp(c.G + d, 0, 255),
                Math.Clamp(c.B + d, 0, 255));
    }

    // ── Grid Styler ───────────────────────────────────────────────────────────
    public static class GridHelper
    {
        public static void Style(DataGridView g, bool readOnly = true, bool rtl = true)
        {
            g.RightToLeft                               = rtl ? RightToLeft.Yes : RightToLeft.No;
            g.BorderStyle                               = BorderStyle.None;
            g.BackgroundColor                           = Theme.Surface;
            g.GridColor                                 = Theme.SurfaceBorder;
            g.CellBorderStyle                           = DataGridViewCellBorderStyle.SingleHorizontal;
            g.ColumnHeadersBorderStyle                  = DataGridViewHeaderBorderStyle.None;
            g.EnableHeadersVisualStyles                 = false;
            g.ColumnHeadersDefaultCellStyle.BackColor   = Theme.AccentGreen;
            g.ColumnHeadersDefaultCellStyle.ForeColor   = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font        = Theme.FontBodyB;
            g.ColumnHeadersDefaultCellStyle.Alignment   = rtl
                ? DataGridViewContentAlignment.MiddleRight
                : DataGridViewContentAlignment.MiddleLeft;
            g.ColumnHeadersHeight                       = 36;
            g.DefaultCellStyle.Font                     = Theme.FontBody;
            g.DefaultCellStyle.BackColor                = Theme.Surface;
            g.DefaultCellStyle.ForeColor                = Theme.TextPrimary;
            g.DefaultCellStyle.Alignment                = rtl
                ? DataGridViewContentAlignment.MiddleRight
                : DataGridViewContentAlignment.MiddleLeft;
            g.DefaultCellStyle.SelectionBackColor       = Color.FromArgb(198, 228, 198);
            g.DefaultCellStyle.SelectionForeColor       = Theme.TextPrimary;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 250, 246);
            g.RowTemplate.Height                        = Theme.GridRowHeight;
            g.AllowUserToAddRows                        = false;
            g.AllowUserToDeleteRows                     = false;
            g.ReadOnly                                  = readOnly;
            g.SelectionMode                             = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode                       = DataGridViewAutoSizeColumnsMode.Fill;
            g.RowHeadersVisible                         = false;
            g.MultiSelect                               = false;
            g.ScrollBars                                = ScrollBars.Vertical;
        }

        public static void AddActionColumns(DataGridView g)
        {
            var edit = new DataGridViewButtonColumn { Name = "Edit", HeaderText = "", Text = "✏ تعديل", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 70 };
            var del = new DataGridViewButtonColumn { Name = "Delete", HeaderText = "", Text = "🗑 حذف", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 70 };
            
            g.Columns.Add(edit);
            g.Columns.Add(del);

            g.CellPainting -= ActionCellPainting;
            g.CellPainting += ActionCellPainting;
        }

        private static void ActionCellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var g = (DataGridView)sender!;
            string colName = g.Columns[e.ColumnIndex].Name;
            
            if (colName == "Edit" || colName == "Delete" || colName == "Deposit")
            {
                e.PaintBackground(e.CellBounds, true);
                
                Color bg = colName == "Edit" ? Theme.AccentBlue : colName == "Delete" ? Theme.AccentRed : Theme.AccentGold;
                var rect = e.CellBounds;
                rect.Inflate(-6, -6); // padding for the button

                using var path = RoundedPanel.RoundRect(rect, 6);
                using var br = new SolidBrush(bg);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(br, path);
                
                string text = colName == "Edit" ? "✏ تعديل" : colName == "Delete" ? "🗑 حذف" : "💰 إيداع";
                using var font = new Font(Theme.FontBody.FontFamily, 9f, FontStyle.Bold);
                using var textBr = new SolidBrush(Color.White);
                
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(text, font, textBr, rect, sf);
                
                e.Handled = true;
            }
        }
    }

    // ── Stat Card ─────────────────────────────────────────────────────────────
    public class StatCard : Panel
    {
        private readonly Label _titleLbl, _valueLbl, _subLbl;
        private Color _accentColor = Theme.AccentGreen;

        public string Title { get => _titleLbl.Text; set => _titleLbl.Text = value; }
        public string Value { get => _valueLbl.Text; set => _valueLbl.Text = value; }
        public string SubText { get => _subLbl.Text; set => _subLbl.Text = value; }
        public Color AccentColor { get => _accentColor; set { _accentColor = value; Invalidate(); } }

        public StatCard() : this("العنوان", "—", "نص فرعي", Theme.AccentGreen) { }

        public StatCard(string title, string value, string sub, Color accent)
        {
            Width     = 195; Height    = 95;
            BackColor = Theme.Surface;
            _accentColor = accent;

            Paint += (_, e) =>
            {
                using var pen = new Pen(Theme.SurfaceBorder, 1f);
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, Width - 1, Height - 1));
                using var br = new SolidBrush(_accentColor);
                e.Graphics.FillRectangle(br, new Rectangle(0, 8, 4, Height - 16));
            };

            _titleLbl = new Label { Text = title, Font = Theme.FontSmall, ForeColor = Theme.TextSecondary, AutoSize = true, Left = 14, Top = 10, RightToLeft = RightToLeft.No };
            _valueLbl = new Label { Text = value, Font = Theme.FontH2,    ForeColor = Theme.TextPrimary,   AutoSize = true, Left = 14, Top = 30, RightToLeft = RightToLeft.No };
            _subLbl   = new Label { Text = sub,   Font = Theme.FontSmall, ForeColor = Theme.TextSecondary, AutoSize = true, Left = 14, Top = 66, RightToLeft = RightToLeft.No };
            Controls.AddRange(new Control[] { _titleLbl, _valueLbl, _subLbl });
        }

        public void Update(string value, string sub = "")
        {
            _valueLbl.Text = value;
            if (sub.Length > 0) _subLbl.Text = sub;
        }
    }

    // ── Section Header ────────────────────────────────────────────────────────
    public class SectionHeader : Label
    {
        public SectionHeader() : this("عنوان القسم") { }

        public SectionHeader(string text)
        {
            Text      = text;
            Font      = Theme.FontH2;
            ForeColor = Theme.TextPrimary;
            AutoSize  = false;
            Height    = 28;
            Dock      = DockStyle.Top;
            TextAlign = ContentAlignment.MiddleRight;
            Padding   = new Padding(0, 2, 4, 2);
        }
    }

    // ── Sidebar Nav Button (custom-drawn, hover-stable) ───────────────────────
    public class NavButton : Control
    {
        private bool _active;
        private bool _hover;

        public bool Active
        {
            get => _active;
            set { if (_active == value) return; _active = value; Invalidate(); }
        }

        public string Icon { get; set; } = "";

        public NavButton(string text, string icon = "")
        {
            Text     = text;
            Icon     = icon;
            Width    = Theme.SidebarWidth;
            Height   = 46;
            Font     = Theme.FontNav;
            Cursor   = Cursors.Hand;
            SetStyle(ControlStyles.AllPaintingInWmPaint  |
                     ControlStyles.UserPaint             |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
        }

        protected override void OnMouseEnter(EventArgs e) { _hover = true;  Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hover = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnClick(EventArgs e)      { base.OnClick(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode  = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Background
            Color bg = _active ? Theme.SidebarActive
                     : _hover  ? Theme.SidebarHover
                     : Color.Transparent;

            if (bg != Color.Transparent)
            {
                var rect = new Rectangle(6, 3, Width - 12, Height - 6);
                using var path = RoundedPanel.RoundRect(rect, 6);
                using var br   = new SolidBrush(bg);
                g.FillPath(br, path);
            }

            // Active indicator bar (left side — right in RTL visually)
            if (_active)
            {
                using var br = new SolidBrush(Color.White);
                g.FillRectangle(br, new Rectangle(Width - 5, 12, 3, Height - 24));
            }

            // Text + icon  (right-to-left: icon on right, text flows right)
            Color fc    = _active ? Color.FromArgb(30, 46, 33) : Theme.TextOnDark;
            string label = $"{Text}  {Icon}";
            var sf = new StringFormat
            {
                Alignment     = StringAlignment.Far,      // right-aligned for Arabic
                LineAlignment = StringAlignment.Center,
                FormatFlags   = StringFormatFlags.NoWrap | StringFormatFlags.DirectionRightToLeft
            };
            using var tf = new SolidBrush(fc);
            g.DrawString(label, Font, tf, new RectangleF(6, 0, Width - 14, Height), sf);
        }
    }
}
