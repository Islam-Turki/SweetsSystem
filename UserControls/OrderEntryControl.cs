using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem.UserControls
{
    public partial class OrderEntryControl : UserControl
    {
        private RadioButton   _rbRetail = null!, _rbWholesale = null!;
        private Panel         _retailPanel = null!, _wholesalePanel = null!;
        private TextBox       _txCustomer = null!, _txCustomerExtra = null!;
        private ComboBox      _cbClient = null!;
        private DataGridView  _linesGrid = null!;
        private Label         _lblSub = null!, _lblBalance = null!, _lblGrand = null!;
        private ComboBox      _cbProduct = null!;
        private NumericUpDown _numQty = null!;
        private FlatButton    _btnAdd = null!, _btnRemove = null!, _btnSave = null!, _btnClear = null!;
        private FlatButton    _btnDeliveryRetail = null!, _btnDeliveryWholesale = null!;
        private Label         _lblDeliveryRetail = null!, _lblDeliveryWholesale = null!;
        private MonthCalendar _calRetail = null!, _calWholesale = null!;
        private Panel         _balanceRow = null!;
        private readonly List<OrderLine> _lines = new();

        public OrderEntryControl()
        {
            InitializeComponent();
            BuildContent();
        }

        private void BuildContent()
        {
            // ── Right column: order type + product picker + lines grid
            var typeCard = MakeCard(60);
            typeCard.Controls.Add(new Label { Text = "نوع الطلب:", Font = Theme.FontBodyB, ForeColor = Theme.TextSecondary, AutoSize = true, Left = 8, Top = 6 });
            _rbRetail    = new RadioButton { Text = "قطاعي", Font = Theme.FontBody, Checked = true, AutoSize = true, Left = 8,   Top = 30, Cursor = Cursors.Hand, RightToLeft = RightToLeft.Yes };
            _rbWholesale = new RadioButton { Text = "جملة",  Font = Theme.FontBody,                 AutoSize = true, Left = 100, Top = 30, Cursor = Cursors.Hand, RightToLeft = RightToLeft.Yes };
            _rbRetail.CheckedChanged    += (_, _) => ToggleCustomerUI();
            _rbWholesale.CheckedChanged += (_, _) => ToggleCustomerUI();
            typeCard.Controls.AddRange(new Control[] { _rbRetail, _rbWholesale });
            rightPanel.Controls.Add(typeCard);

            _retailPanel = new Panel { Height = 140, Dock = DockStyle.Top, BackColor = Theme.Background };
            _retailPanel.Controls.Add(new Label { Text = "اسم العميل", Font = Theme.FontBodyB, ForeColor = Theme.TextSecondary, AutoSize = true, Left = 0, Top = 2 });
            _txCustomer = new TextBox { Left = 0, Top = 22, Width = 300, Font = Theme.FontBody, BorderStyle = BorderStyle.FixedSingle, PlaceholderText = "أدخل اسم العميل" };
            _txCustomer.TextChanged += (_, _) => RecalcTotals();
            _txCustomerExtra = new TextBox { Left = 0, Top = 52, Width = 300, Font = Theme.FontBody, BorderStyle = BorderStyle.FixedSingle, PlaceholderText = "رقم الهاتف" };
            _btnDeliveryRetail = new FlatButton { Left = 0, Top = 84, Width = 140, Height = 30, Text = "موعد التسليم" };
            _lblDeliveryRetail = new Label { Left = 148, Top = 90, AutoSize = true, Text = "لم يحدد", Font = Theme.FontBody, ForeColor = Theme.TextSecondary };
            _calRetail = new MonthCalendar { Left = 0, Top = 120, Visible = false, MaxSelectionCount = 1 };
            _btnDeliveryRetail.Click += (_, _) => _calRetail.Visible = !_calRetail.Visible;
            _calRetail.DateSelected  += (_, e) => { _lblDeliveryRetail.Text = e.Start.ToShortDateString(); _calRetail.Visible = false; };
            _retailPanel.Controls.AddRange(new Control[] { _txCustomer, _txCustomerExtra, _btnDeliveryRetail, _lblDeliveryRetail, _calRetail });
            rightPanel.Controls.Add(_retailPanel);

            _wholesalePanel = new Panel { Height = 140, Dock = DockStyle.Top, BackColor = Theme.Background, Visible = false };
            _wholesalePanel.Controls.Add(new Label { Text = "عميل الجملة", Font = Theme.FontBodyB, ForeColor = Theme.TextSecondary, AutoSize = true, Left = 0, Top = 2 });
            _cbClient = new ComboBox { Left = 0, Top = 22, Width = 300, Font = Theme.FontBody, FlatStyle = FlatStyle.Flat, DropDownStyle = ComboBoxStyle.DropDownList };
            foreach (var c in MockData.WholesaleClients) _cbClient.Items.Add(c);
            _cbClient.SelectedIndexChanged += (_, _) => RecalcTotals();
            _wholesalePanel.Controls.Add(_cbClient);
            _btnDeliveryWholesale = new FlatButton { Left = 0, Top = 56, Width = 140, Height = 30, Text = "موعد التسليم" };
            _lblDeliveryWholesale = new Label { Left = 148, Top = 62, AutoSize = true, Text = "لم يحدد", Font = Theme.FontBody, ForeColor = Theme.TextSecondary };
            _calWholesale = new MonthCalendar { Left = 0, Top = 92, Visible = false, MaxSelectionCount = 1 };
            _btnDeliveryWholesale.Click += (_, _) => _calWholesale.Visible = !_calWholesale.Visible;
            _calWholesale.DateSelected  += (_, e) => { _lblDeliveryWholesale.Text = e.Start.ToShortDateString(); _calWholesale.Visible = false; };
            _wholesalePanel.Controls.AddRange(new Control[] { _btnDeliveryWholesale, _lblDeliveryWholesale, _calWholesale });
            rightPanel.Controls.Add(_wholesalePanel);

            var pickerCard = MakeCard(110);
            pickerCard.Controls.Add(new Label { Text = "اختر منتجاً", Font = Theme.FontBodyB, ForeColor = Theme.TextSecondary, AutoSize = true, Left = 8, Top = 6 });
            _cbProduct = new ComboBox { Left = 8, Top = 26, Width = 240, Font = Theme.FontBody, FlatStyle = FlatStyle.Flat, DropDownStyle = ComboBoxStyle.DropDownList };
            foreach (var p in MockData.Products) _cbProduct.Items.Add(p);
            if (_cbProduct.Items.Count > 0) _cbProduct.SelectedIndex = 0;
            pickerCard.Controls.Add(_cbProduct);
            pickerCard.Controls.Add(new Label { Text = "الكمية:", Font = Theme.FontBody, ForeColor = Theme.TextSecondary, AutoSize = true, Left = 256, Top = 30 });
            _numQty = new NumericUpDown { Left = 308, Top = 26, Width = 65, Minimum = 1, Maximum = 9999, Value = 1, Font = Theme.FontBody, BorderStyle = BorderStyle.FixedSingle };
            pickerCard.Controls.Add(_numQty);
            _btnAdd    = new FlatButton { Text = "＋ إضافة", Left = 8,   Top = 68, Width = 120, Height = 30 };
            _btnRemove = new FlatButton { Text = "✕ حذف",    Left = 138, Top = 68, Width = 95,  Height = 30, BackColor = Theme.AccentRed };
            _btnAdd.Click    += BtnAdd_Click;
            _btnRemove.Click += BtnRemove_Click;
            pickerCard.Controls.AddRange(new Control[] { _btnAdd, _btnRemove });
            rightPanel.Controls.Add(pickerCard);

            var gridCard = new Panel { Dock = DockStyle.Fill, BackColor = Theme.Background };
            _linesGrid = new DataGridView { Dock = DockStyle.Fill };
            GridHelper.Style(_linesGrid, readOnly: true, rtl: true);
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Product", HeaderText = "المنتج",   FillWeight = 40 });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qty",     HeaderText = "الكمية",   FillWeight = 10 });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price",   HeaderText = "السعر",    FillWeight = 18 });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total",   HeaderText = "الإجمالي", FillWeight = 18 });
            gridCard.Controls.Add(_linesGrid);
            rightPanel.Controls.Add(gridCard);

            // ── Left column: summary card + action buttons
            var sumCard = MakeCard(280);
            sumCard.Dock = DockStyle.Top;
            sumCard.Controls.Add(new Label { Text = "ملخص الطلب", Font = Theme.FontH2, ForeColor = Theme.TextPrimary, AutoSize = true, Left = 12, Top = 12 });
            sumCard.Controls.Add(new Panel { Left = 12, Top = 40, Width = 270, Height = 1, BackColor = Theme.SurfaceBorder });
            sumCard.Controls.Add(new Label { Text = "المجموع الفرعي:", Font = Theme.FontBodyB, ForeColor = Theme.TextSecondary, AutoSize = true, Left = 12, Top = 54 });
            _lblSub = new Label { Text = Theme.LYD(0), Font = Theme.FontBodyB, ForeColor = Theme.TextPrimary, AutoSize = true, Left = 180, Top = 54 };
            sumCard.Controls.Add(_lblSub);
            _balanceRow = new Panel { Left = 12, Top = 86, Width = 280, Height = 30, BackColor = Color.Transparent, Visible = false };
            _balanceRow.Controls.Add(new Label { Text = "الرصيد السابق:", Font = Theme.FontBodyB, ForeColor = Theme.AccentRed, AutoSize = true, Left = 0, Top = 5 });
            _lblBalance = new Label { Text = Theme.LYD(0), Font = Theme.FontBodyB, ForeColor = Theme.AccentRed, AutoSize = true, Left = 158, Top = 5 };
            _balanceRow.Controls.Add(_lblBalance);
            sumCard.Controls.Add(_balanceRow);
            sumCard.Controls.Add(new Panel { Left = 12, Top = 126, Width = 270, Height = 1, BackColor = Theme.SurfaceBorder });
            sumCard.Controls.Add(new Label { Text = "الإجمالي الكلي:", Font = Theme.FontBodyB, ForeColor = Theme.AccentGreen, AutoSize = true, Left = 12, Top = 140 });
            _lblGrand = new Label { Text = Theme.LYD(0), Font = new Font("Tahoma", 13f, FontStyle.Bold), ForeColor = Theme.AccentGreen, AutoSize = true, Left = 180, Top = 136 };
            sumCard.Controls.Add(_lblGrand);
            leftPanel.Controls.Add(sumCard);

            var btnFlow = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 52, BackColor = Theme.Background, FlowDirection = FlowDirection.RightToLeft, Padding = new Padding(0, 8, 0, 0) };
            _btnSave  = new FlatButton { Text = "✔  حفظ الطلب", Width = 150, BackColor = Theme.AccentGreen, Margin = new Padding(6, 0, 0, 0) };
            _btnClear = new FlatButton { Text = "✕  مسح",        Width = 90,  BackColor = Theme.TextSecondary };
            _btnClear.Click += BtnClear_Click;
            btnFlow.Controls.AddRange(new Control[] { _btnSave, _btnClear });
            leftPanel.Controls.Add(btnFlow);
        }

        private static Panel MakeCard(int h)
        {
            var p = new Panel { Height = h, Dock = DockStyle.Top, BackColor = Theme.Surface, Padding = new Padding(8, 4, 8, 4) };
            p.Paint += (_, e) => { using var pen = new System.Drawing.Pen(Theme.SurfaceBorder, 1f); e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, p.Width - 1, p.Height - 1)); };
            return p;
        }

        private void ToggleCustomerUI()
        {
            bool ws = _rbWholesale.Checked;
            _retailPanel.Visible    = !ws;
            _wholesalePanel.Visible = ws;
            _balanceRow.Visible     = ws;
            RefreshGrid();
            RecalcTotals();
        }

        private void BtnAdd_Click(object? s, EventArgs e)
        {
            if (_cbProduct.SelectedItem is not Product p) return;
            bool ws    = _rbWholesale.Checked;
            decimal price = ws ? p.WholesalePrice : p.RetailPrice;
            int qty       = (int)_numQty.Value;
            var ex = _lines.FirstOrDefault(l => l.Product.Id == p.Id);
            if (ex != null) ex.Quantity += qty;
            else _lines.Add(new OrderLine { Product = p, Quantity = qty, UnitPrice = price });
            RefreshGrid(); RecalcTotals();
        }

        private void BtnRemove_Click(object? s, EventArgs e)
        {
            if (_linesGrid.CurrentRow == null || _linesGrid.RowCount == 0) return;
            int idx = _linesGrid.CurrentRow.Index;
            if (idx >= 0 && idx < _lines.Count) { _lines.RemoveAt(idx); RefreshGrid(); RecalcTotals(); }
        }

        private void RefreshGrid()
        {
            _linesGrid.Rows.Clear();
            bool ws = _rbWholesale.Checked;
            foreach (var l in _lines)
            {
                l.UnitPrice = ws ? l.Product.WholesalePrice : l.Product.RetailPrice;
                _linesGrid.Rows.Add(l.Product.Name, l.Quantity, Theme.LYD(l.UnitPrice), Theme.LYD(l.LineTotal));
            }
        }

        private void RecalcTotals()
        {
            bool ws      = _rbWholesale.Checked;
            decimal sub  = _lines.Sum(l => l.LineTotal);
            decimal prev = ws && _cbClient.SelectedItem is WholesaleClient wc ? wc.RemainingBalance : 0m;
            _lblSub.Text     = Theme.LYD(sub);
            _lblBalance.Text = Theme.LYD(prev);
            _lblGrand.Text   = Theme.LYD(sub + prev);
        }

        private void BtnClear_Click(object? s, EventArgs e)
        {
            _lines.Clear(); _linesGrid.Rows.Clear();
            _txCustomer.Text = ""; _txCustomerExtra.Text = ""; _cbClient.SelectedIndex = -1;
            _rbRetail.Checked = true; RecalcTotals();
        }
    }
}
