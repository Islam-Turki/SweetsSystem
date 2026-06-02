using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace sweetSystem
{
    public static class PdfReportGenerator
    {
        static PdfReportGenerator()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        private static string GetTempPdfPath(string prefix)
        {
            return Path.Combine(Path.GetTempPath(), $"{prefix}_{Guid.NewGuid():N}.pdf");
        }

        private static void OpenPdf(string path)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("عذرًا، لم نتمكن من فتح ملف الـ PDF. تأكد من وجود برنامج لفتح ملفات PDF.\n" + ex.Message, "خطأ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public static void GenerateOrderAssignmentPdf(string orderNumber)
        {
            // 1. Fetch Order Data
            string orderQuery = @"
                SELECT o.*, 
                       ISNULL(e.name, o.cook) as assigned_employee_name 
                FROM [order] o
                LEFT JOIN employee e ON o.packager_phone = e.phone
                WHERE o.order_number = @orderNum";
            var orderParams = new[] { new Microsoft.Data.SqlClient.SqlParameter("@orderNum", orderNumber) };
            var dtOrder = DatabaseHelper.ExecuteQuery(orderQuery, orderParams);

            if (dtOrder.Rows.Count == 0) return;
            var orderRow = dtOrder.Rows[0];

            string customerName = orderRow["customer_name"]?.ToString() ?? "غير محدد";
            string deliveryDate = Convert.ToDateTime(orderRow["delivery_date"]).ToString("yyyy-MM-dd");
            string employeeName = orderRow["assigned_employee_name"]?.ToString();
            if (string.IsNullOrWhiteSpace(employeeName)) employeeName = "غير محدد";
            string notes = orderRow["notes"]?.ToString() ?? "";

            // 2. Fetch Order Items
            string itemsQuery = "SELECT product_name, quantity FROM order_items WHERE order_number = @orderNum";
            var dtItems = DatabaseHelper.ExecuteQuery(itemsQuery, orderParams);

            string pdfPath = GetTempPdfPath("OrderTicket");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A5);
                    page.Margin(20);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(12));
                    page.ContentFromRightToLeft();

                    page.Header().Text("تذكرة تكليف طلب").SemiBold().FontSize(20).FontColor(Colors.Blue.Darken2).AlignCenter();

                    page.Content().PaddingVertical(10).Column(col =>
                    {
                        col.Item().Text($"رقم الطلب: {orderNumber}").Bold();
                        col.Item().Text($"العميل: {customerName}");
                        col.Item().Text($"تاريخ التسليم: {deliveryDate}");
                        col.Item().Text($"الموظف المكلف: {employeeName}").FontColor(Colors.Green.Darken2).Bold();
                        if (!string.IsNullOrWhiteSpace(notes))
                            col.Item().Text($"ملاحظات: {notes}");

                        col.Item().PaddingTop(15).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                        col.Item().PaddingTop(10).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3); // Product
                                columns.RelativeColumn(1); // Quantity
                            });

                            table.Header(header =>
                            {
                                header.Cell().BorderBottom(1).Padding(5).Text("المنتج").Bold();
                                header.Cell().BorderBottom(1).Padding(5).Text("الكمية").Bold();
                            });

                            foreach (DataRow itemRow in dtItems.Rows)
                            {
                                table.Cell().Padding(5).Text(itemRow["product_name"]?.ToString());
                                table.Cell().Padding(5).Text(itemRow["quantity"]?.ToString());
                            }
                        });
                    });
                });
            })
            .GeneratePdf(pdfPath);

            OpenPdf(pdfPath);
        }

        public static void GenerateAutoAssignReport(DateTime deliveryDate)
        {
            string q = @"
                SELECT o.order_number, o.customer_name, 
                       ISNULL(e.name, ISNULL(o.cook, 'غير محدد')) as employee_name,
                       (SELECT ISNULL(SUM(quantity), 0) FROM order_items oi WHERE oi.order_number = o.order_number) as total_items
                FROM [order] o
                LEFT JOIN employee e ON o.packager_phone = e.phone
                WHERE CAST(o.delivery_date AS DATE) = CAST(@Date AS DATE)
                  AND ( (o.packager_phone IS NOT NULL AND o.packager_phone <> '') 
                        OR (o.cook IS NOT NULL AND o.cook <> '') )
                ORDER BY employee_name, o.order_number DESC";

            var dt = DatabaseHelper.ExecuteQuery(q, new[] { new Microsoft.Data.SqlClient.SqlParameter("@Date", deliveryDate) });

            if (dt.Rows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("لا توجد طلبات مكلفة في هذا التاريخ.", "تنبيه", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            string pdfPath = GetTempPdfPath("BatchAssign");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(11));
                    page.ContentFromRightToLeft();

                    page.Header().Column(hc =>
                    {
                        hc.Item().Text("تقرير التكليفات اليومية").SemiBold().FontSize(22).FontColor(Colors.Blue.Darken2).AlignCenter();
                        hc.Item().Text($"تاريخ التسليم: {deliveryDate:yyyy-MM-dd}").FontSize(14).AlignCenter();
                        hc.Item().PaddingBottom(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                    });

                    page.Content().Column(col =>
                    {
                        var groups = dt.AsEnumerable().GroupBy(r => r["employee_name"].ToString()!);
                        foreach (var g in groups)
                        {
                            col.Item().PaddingTop(15).Text($"الموظف: {g.Key}").FontSize(16).Bold().FontColor(Colors.Green.Darken2);
                            
                            col.Item().PaddingTop(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1); // Order ID
                                    columns.RelativeColumn(3); // Customer
                                    columns.RelativeColumn(1); // Total Items
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("رقم الطلب").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("العميل").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("إجمالي القطع").Bold();
                                });

                                foreach (var row in g)
                                {
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten4).Padding(5).Text(row["order_number"]?.ToString());
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten4).Padding(5).Text(row["customer_name"]?.ToString());
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten4).Padding(5).Text(row["total_items"]?.ToString());
                                }
                            });
                        }
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("صفحة ");
                        x.CurrentPageNumber();
                        x.Span(" من ");
                        x.TotalPages();
                    });
                });
            })
            .GeneratePdf(pdfPath);

            OpenPdf(pdfPath);
        }

        public static void GenerateDailyProductionSheet(DateTime productionDate)
        {
            string query = @"
                SELECT p.product_name, p.unit, SUM(oi.quantity) as total_qty 
                FROM order_items oi 
                INNER JOIN [order] o ON oi.order_number = o.order_number 
                INNER JOIN products p ON oi.product_name = p.product_name 
                WHERE CAST(o.delivery_date AS DATE) = CAST(@Date AS DATE)
                  AND o.status NOT IN ('Delivered', 'Completed')
                GROUP BY p.product_name, p.unit
                ORDER BY p.product_name";

            var dt = DatabaseHelper.ExecuteQuery(query, new[] { new Microsoft.Data.SqlClient.SqlParameter("@Date", productionDate) });

            string pdfPath = GetTempPdfPath("ProductionSheet");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(12));
                    page.ContentFromRightToLeft();

                    page.Header().Column(hc =>
                    {
                        hc.Item().Text("ورقة الإنتاج اليومية").SemiBold().FontSize(24).FontColor(Colors.Blue.Darken2).AlignCenter();
                        hc.Item().Text($"تاريخ الإنتاج / التسليم: {productionDate:yyyy-MM-dd}").FontSize(14).AlignCenter();
                        hc.Item().PaddingBottom(15).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                    });

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(3); // Product Name
                            columns.RelativeColumn(1); // Quantity
                            columns.RelativeColumn(1); // Unit
                            columns.RelativeColumn(2); // Notes/Check
                        });

                        table.Header(header =>
                        {
                            header.Cell().Background(Colors.Grey.Lighten2).Border(1).BorderColor(Colors.Grey.Medium).Padding(5).AlignCenter().Text("المنتج").Bold();
                            header.Cell().Background(Colors.Grey.Lighten2).Border(1).BorderColor(Colors.Grey.Medium).Padding(5).AlignCenter().Text("الكمية المطلوبة").Bold();
                            header.Cell().Background(Colors.Grey.Lighten2).Border(1).BorderColor(Colors.Grey.Medium).Padding(5).AlignCenter().Text("الوحدة").Bold();
                            header.Cell().Background(Colors.Grey.Lighten2).Border(1).BorderColor(Colors.Grey.Medium).Padding(5).AlignCenter().Text("ملاحظات / تم").Bold();
                        });

                        if (dt.Rows.Count == 0)
                        {
                            table.Cell().ColumnSpan(4).Padding(20).AlignCenter().Text("لا توجد منتجات مطلوبة لهذا اليوم.").FontSize(14);
                        }
                        else
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                table.Cell().Border(1).BorderColor(Colors.Grey.Medium).Padding(5).Text(row["product_name"]?.ToString());
                                table.Cell().Border(1).BorderColor(Colors.Grey.Medium).Padding(5).AlignCenter().Text(row["total_qty"]?.ToString()).Bold();
                                
                                // Attempt to gracefully translate Enum representations if stored as strings
                                string unitVal = row["unit"]?.ToString() == "Kg" || row["unit"]?.ToString() == "0" ? "كجم" : "قطعة";
                                table.Cell().Border(1).BorderColor(Colors.Grey.Medium).Padding(5).AlignCenter().Text(unitVal);
                                
                                table.Cell().Border(1).BorderColor(Colors.Grey.Medium).Padding(5).Text(""); // Empty for checks
                            }
                        }
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("صفحة ");
                        x.CurrentPageNumber();
                        x.Span(" من ");
                        x.TotalPages();
                    });
                });
            })
            .GeneratePdf(pdfPath);

            OpenPdf(pdfPath);
        }
    }
}
