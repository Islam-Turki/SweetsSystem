using sweetSystem;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using sweetSystem.printerUrils;

namespace sweetSystem.UserControls
{
    public partial class ProductionViewControl : UserControl
    {
        private DateTime _date = DateTime.Today;

        public ProductionViewControl()
        {
            InitializeComponent();
            this.BackColor = Theme.Background;
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

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (_grid.Rows.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات للطباعة", "طباعة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var items = new System.Collections.Generic.List<(string ProductName, string Unit, double TotalQuantity)>();

            foreach (DataGridViewRow row in _grid.Rows)
            {
                if (row.IsNewRow) continue;

                string name = row.Cells["Product"].Value?.ToString() ?? "—";
                double qty  = Convert.ToDouble(row.Cells["TotalQty"].Value ?? 0);

                string unitRaw    = row.Cells["Unit"].Value?.ToString() ?? "";
                string unitArabic = unitRaw;
                if (Enum.TryParse<ProductUnit>(unitRaw, out var unitEnum))
                    unitArabic = unitEnum.ToArabicString();

                items.Add((name, unitArabic, qty));
            }

            string slip = paperBuilder.BuildDailyProductionSlip(_date, items);
            RawPrinterHelper.PrintOut(slip);
        }

        public void RefreshGrid()
        {
            bool isToday = _date.Date == DateTime.Today;
            _lblDateBadge.Text   = isToday ? $"اليوم — {_date:ddd dd/MM}" : $"الغد — {_date:ddd dd/MM}";
            _btnToday.BackColor    = isToday ? Theme.AccentGold : Theme.SurfaceBorder;
            _btnToday.ForeColor    = isToday ? Color.White : Theme.TextPrimary;
            _btnTomorrow.BackColor = isToday ? Theme.SurfaceBorder : Theme.AccentGold;
            _btnTomorrow.ForeColor = isToday ? Theme.TextPrimary : Color.White;

            string sql = @"
                SELECT 
                    p.product_name AS Product,
                    p.category AS Category,
                    SUM(oi.quantity) AS TotalQty,
                    p.unit AS Unit,
                    e.name AS Cook,
                    COUNT(DISTINCT oi.order_number) AS OrderCount
                FROM order_items oi
                JOIN [order] o ON oi.order_number = o.order_number
                JOIN products p ON oi.product_name = p.product_name
                LEFT JOIN employee e ON p.maker_phone = e.phone
                WHERE CAST(o.order_date AS DATE) = @date
                GROUP BY p.product_name, p.category, p.unit, e.name
                ORDER BY p.category, p.product_name";

            var dt = DatabaseHelper.ExecuteQuery(sql, new[] {
                new Microsoft.Data.SqlClient.SqlParameter("@date", _date.Date)
            });

            _grid.Rows.Clear();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                string pName = row["Product"].ToString() ?? "—";
                
                string pCatStr = row["Category"].ToString() ?? "";
                var pCat = ProductCategory.Other;
                try { pCat = EnumHelper.FromString<ProductCategory>(pCatStr); } catch {}
                
                double tQty = Convert.ToDouble(row["TotalQty"]);
                
                string pUnitStr = row["Unit"].ToString() ?? "";
                var pUnit = ProductUnit.Piece;
                try { pUnit = EnumHelper.FromString<ProductUnit>(pUnitStr); } catch {}

                string cookName = row["Cook"] != DBNull.Value && !string.IsNullOrEmpty(row["Cook"].ToString()) ? row["Cook"].ToString()! : "⚠ غير معيّن";
                int oCount = Convert.ToInt32(row["OrderCount"]);

                int i = _grid.Rows.Add(
                    pName,
                    pCat.ToString(),
                    tQty,
                    pUnit.ToString(),
                    cookName,
                    oCount
                );
                
                if (cookName == "⚠ غير معيّن")
                    _grid.Rows[i].DefaultCellStyle.ForeColor = Theme.AccentRed;
            }
        }
    }
}
