using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem.UserControls
{
    public partial class ProductionViewControl : UserControl
    {
        private DateTime _date = DateTime.Today;

        public ProductionViewControl()
        {
            InitializeComponent();
            GridHelper.Style(_grid, readOnly: true, rtl: true);
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Product",  HeaderText = "المنتج",           FillWeight = 28 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "الفئة",            FillWeight = 14 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalQty", HeaderText = "إجمالي الكمية",   FillWeight = 14 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Unit",     HeaderText = "الوحدة",           FillWeight = 8  });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cook",     HeaderText = "الطباخ المسؤول",  FillWeight = 22 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Orders",   HeaderText = "عدد الطلبات",     FillWeight = 10 });
        }

        private void Toolbar_Resize(object sender, EventArgs e)
        {
            _btnToday.Left    = toolbar.Width - 115;
            _btnTomorrow.Left = toolbar.Width - 225;
        }

        private void BtnToday_Click(object sender, EventArgs e)
        {
            _date = DateTime.Today;
            RefreshGrid();
        }

        private void BtnTomorrow_Click(object sender, EventArgs e)
        {
            _date = DateTime.Today.AddDays(1);
            RefreshGrid();
        }

        public void RefreshGrid()
        {
            bool isToday = _date.Date == DateTime.Today;
            _lblDateBadge.Text   = isToday ? $"اليوم — {_date:ddd dd/MM}" : $"الغد — {_date:ddd dd/MM}";
            _btnToday.BackColor    = isToday ? Theme.AccentGreen : Theme.TextSecondary;
            _btnTomorrow.BackColor = isToday ? Theme.TextSecondary : Theme.AccentGreen;

            var lines = MockData.Orders
                .Where(o => o.Date.Date == _date.Date)
                .SelectMany(o => o.Lines)
                .GroupBy(l => l.Product.Id)
                .Select(g => new
                {
                    Product    = g.First().Product,
                    TotalQty   = g.Sum(l => l.Quantity),
                    OrderCount = MockData.Orders.Count(o =>
                        o.Date.Date == _date.Date &&
                        o.Lines.Any(l => l.Product.Id == g.Key))
                })
                .OrderBy(x => x.Product.Category)
                .ThenBy(x => x.Product.Name);

            _grid.Rows.Clear();
            foreach (var item in lines)
            {
                var cook = MockData.GetCookForProduct(item.Product);
                int i = _grid.Rows.Add(
                    item.Product.Name,
                    item.Product.Category,
                    item.TotalQty,
                    item.Product.Unit,
                    cook?.Name ?? "⚠ غير معيّن",
                    item.OrderCount
                );
                if (cook == null)
                    _grid.Rows[i].DefaultCellStyle.ForeColor = Theme.AccentRed;
            }
        }
    }
}
