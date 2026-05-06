using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace sweetSystem.UserControls
{
    public partial class OrderEntryControl : UserControl
    {
        private readonly List<OrderLine> _lines = new();

        public OrderEntryControl()
        {
            InitializeComponent();
            SetupCalendarLogic();
            ApplyThemeAndData(); // We apply data binding and dynamic styles here instead of BuildContent
        }

        private void ApplyThemeAndData()
        {
            // 1. Apply Dynamic Themes (WinForms Designer struggles with static Theme references)
            lblOrderType.Font = Theme.FontBodyB;
            _rbRetail.Font = Theme.FontBody;
            _rbWholesale.Font = Theme.FontBody;
            lblCustomerName.Font = Theme.FontBodyB;
            _txCustomer.Font = Theme.FontBody;
            _txCustomerExtra.Font = Theme.FontBody;
            _lblDeliveryRetail.Font = Theme.FontBody;
            lblWholesaleClient.Font = Theme.FontBodyB;
            _cbClient.Font = Theme.FontBody;
            _lblDeliveryWholesale.Font = Theme.FontBody;
            lblProduct.Font = Theme.FontBodyB;
            _cbProduct.Font = Theme.FontBody;
            lblQty.Font = Theme.FontBody;
            _numQty.Font = Theme.FontBody;
            lblSummary.Font = Theme.FontH2;
            lblSubTitle.Font = Theme.FontBodyB;
            _lblSub.Font = Theme.FontBodyB;
            lblBalanceTitle.Font = Theme.FontBodyB;
            _lblBalance.Font = Theme.FontBodyB;
            lblGrandTitle.Font = Theme.FontBodyB;

            // Apply card paint events for the borders
            AddCardBorder(typeCard);
            AddCardBorder(pickerCard);
            AddCardBorder(sumCard);

            // 2. Setup DataGridView
            GridHelper.Style(_linesGrid, readOnly: true, rtl: true);
            _linesGrid.Columns.Clear();
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Product", HeaderText = "المنتج", FillWeight = 40 });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qty", HeaderText = "الكمية", FillWeight = 10 });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "السعر", FillWeight = 18 });
            _linesGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "الإجمالي", FillWeight = 18 });

            // 3. Bind Data
            foreach (var c in MockData.WholesaleClients) _cbClient.Items.Add(c);
            foreach (var p in MockData.Products) _cbProduct.Items.Add(p);
            if (_cbProduct.Items.Count > 0) _cbProduct.SelectedIndex = 0;

            // 4. Hook up remaining events not tied in Designer
            _btnDeliveryRetail.Click += (_, _) => _calRetail.Visible = !_calRetail.Visible;
            _calRetail.DateSelected += (_, e) => { _lblDeliveryRetail.Text = e.Start.ToShortDateString(); _calRetail.Visible = false; };

            _btnDeliveryWholesale.Click += (_, _) => _calWholesale.Visible = !_calWholesale.Visible;
            _calWholesale.DateSelected += (_, e) => { _lblDeliveryWholesale.Text = e.Start.ToShortDateString(); _calWholesale.Visible = false; };
        }

        private void AddCardBorder(Panel p)
        {
            p.Paint += (_, e) =>
            {
                using var pen = new System.Drawing.Pen(Theme.SurfaceBorder, 1f);
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, p.Width - 1, p.Height - 1));
            };
        }

        private void _rbType_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCustomerUI();
        }

        private void ToggleCustomerUI()
        {
            bool ws = _rbWholesale.Checked;
            _retailPanel.Visible = !ws;
            _wholesalePanel.Visible = ws;
            _balanceRow.Visible = ws;
            RefreshGrid();
            RecalcTotals();
        }

        private void BtnAdd_Click(object? s, EventArgs e)
        {
            if (_cbProduct.SelectedItem is not Product p) return;
            bool ws = _rbWholesale.Checked;
            decimal price = ws ? p.WholesalePrice : p.RetailPrice;
            int qty = (int)_numQty.Value;
            var ex = _lines.FirstOrDefault(l => l.Product.Id == p.Id);

            if (ex != null) ex.Quantity += qty;
            else _lines.Add(new OrderLine { Product = p, Quantity = qty, UnitPrice = price });

            RefreshGrid();
            RecalcTotals();
        }

        private void BtnRemove_Click(object? s, EventArgs e)
        {
            if (_linesGrid.CurrentRow == null || _linesGrid.RowCount == 0) return;
            int idx = _linesGrid.CurrentRow.Index;
            if (idx >= 0 && idx < _lines.Count)
            {
                _lines.RemoveAt(idx);
                RefreshGrid();
                RecalcTotals();
            }
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
            bool ws = _rbWholesale.Checked;
            decimal sub = _lines.Sum(l => l.LineTotal);
            decimal prev = ws && _cbClient.SelectedItem is WholesaleClient wc ? wc.RemainingBalance : 0m;

            _lblSub.Text = Theme.LYD(sub);
            _lblBalance.Text = Theme.LYD(prev);
            _lblGrand.Text = Theme.LYD(sub + prev);
        }

        private void _cbClient_SelectedIndexChanged(object sender, EventArgs e) => RecalcTotals();

        private void _txCustomer_TextChanged(object sender, EventArgs e) => RecalcTotals();

        private void BtnClear_Click(object? s, EventArgs e)
        {
            _lines.Clear();
            _linesGrid.Rows.Clear();
            _txCustomer.Text = "";
            _txCustomerExtra.Text = "";
            _cbClient.SelectedIndex = -1;
            _rbRetail.Checked = true;
            RecalcTotals();
        }
        private void SetupCalendarLogic()
        {
            // Toggle Retail Calendar
            _btnDeliveryRetail.Click += (s, e) =>
            {
                _calRetail.Visible = !_calRetail.Visible;
                _calRetail.BringToFront();
            };

            _calRetail.DateSelected += (s, e) =>
            {
                _lblDeliveryRetail.Text = e.Start.ToShortDateString();
                _calRetail.Visible = false;
            };

            // Toggle Wholesale Calendar
            _btnDeliveryWholesale.Click += (s, e) =>
            {
                _calWholesale.Visible = !_calWholesale.Visible;
                _calWholesale.BringToFront();
            };

            _calWholesale.DateSelected += (s, e) =>
            {
                _lblDeliveryWholesale.Text = e.Start.ToShortDateString();
                _calWholesale.Visible = false;
            };
        }

        private void pickerCard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}