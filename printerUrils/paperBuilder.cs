using System;
using System.Collections.Generic;
using System.Text;


namespace sweetSystem.printerUrils
{
    public static class paperBuilder
    {
        // ── Constants ────────────────────────────────────────────
        private const int PaperWidth = 39;
        private const char Separator = '_';
        private const char ThickSeparator = '_';

        // ── Helpers ──────────────────────────────────────────────

        /// <summary>
        /// Right-aligns Arabic text within the paper width.
        /// </summary>
        private static string R(string text)
        {
            if (text.Length >= PaperWidth)
                return text;
            return text.PadLeft(PaperWidth);
        }

        /// <summary>
        /// Centers text within the paper width.
        /// </summary>
        private static string C(string text)
        {
            if (text.Length >= PaperWidth)
                return text;
            int totalPadding = PaperWidth - text.Length;
            int leftPad = totalPadding / 2 + text.Length;
            return text.PadLeft(leftPad);
        }

        /// <summary>
        /// Produces a full-width separator line.
        /// </summary>
        private static string Line(char ch = '_')
            => new string(ch, PaperWidth);

        /// <summary>
        /// Formats a product line: name right, quantity+unit left.
        /// Since Arabic is RTL: quantity on left, name on right.
        /// e.g.  "كغ 2.5                               بقلاوة"
        /// </summary>
        private static string ProductLine(string name, double quantity, string unit)
        {
            // In RTL: right side = product name, left side = qty + unit
            string qtyStr = $"{unit} {quantity:0.##}";
            int nameWidth = PaperWidth - qtyStr.Length - 2;

            // Truncate name if too long
            if (name.Length > nameWidth)
                name = name.Substring(0, nameWidth);

            // Name padded to fill space, qty on the left
            string namePart = name.PadRight(nameWidth);
            return $"{namePart}  {qtyStr}";
        }

        private static string PaymentStatusArabic(PaymentStatus status)
            => status switch
            {
                PaymentStatus.None    => "لم يتم الدفع",
                PaymentStatus.Partial => "دفع جزئي",
                PaymentStatus.Paid    => "تم الدفع",
                _                    => ""
            };

        // ═══════════════════════════════════════════════════════════
        // SLIP 1 — Order Ticket
        // ═══════════════════════════════════════════════════════════

        /// <summary>
        /// Builds the order ticket slip string for thermal printing.
        /// </summary>
        /// <param name="order">
        ///   The order object. Must have OrderItems, Packager, 
        ///   and PaidAmount populated.
        /// </param>
        public static string BuildOrderTicket(Order order)
        {
            var sb = new StringBuilder();

            // ── Header ────────────────────────────────────────────
            sb.AppendLine(C("فاتورة طلب"));
            sb.AppendLine(Line(ThickSeparator));

            // Customer name and phone
            sb.AppendLine(R(order.CustomerPhone)+("       ")+ order.CustomerName );
            //sb.AppendLine(R(order.CustomerName));

            sb.AppendLine(Line());
            sb.AppendLine(Line());

            // ── Product List ──────────────────────────────────────
            sb.AppendLine(R("الكمية                          الصنف"));
            sb.AppendLine(Line());
            List<OrderItem> orderItems = MockData.OrderItems
    .Where(o => o.OrderId == order.Id)
    .ToList();
            foreach (var item in orderItems)
            {
                string unit = item.Product?.Unit.ToArabicString() 
                              ?? "";
                string name = item.Product?.Name ?? "—";
                sb.AppendLine(ProductLine(name, item.Quantity, unit));
            }

            sb.AppendLine(Line(ThickSeparator));

            // ── Total ─────────────────────────────────────────────
            string totalLine = $"{order.TotalPrice:0.00} د.ل";
            sb.AppendLine(R($"المجموع: {totalLine}"));

            // ── Payment Status ────────────────────────────────────
            sb.AppendLine(R($"الدفع: {PaymentStatusArabic(order.PaymentStatus)}"));

            if (order.PaymentStatus != PaymentStatus.Paid)
            {
                double remaining = order.TotalPrice - order.PaidAmount;
                sb.AppendLine(R($"المتبقي: {remaining:0.00} د.ل"));
            }

            sb.AppendLine(Line());

            // ── Packager ──────────────────────────────────────────
            string packagerName = order.Packager?.Name ?? "غير محدد";
            sb.AppendLine(R($"المعبّأ: {packagerName}"));

            // ── Delivery ──────────────────────────────────────────
            string deliveryLine = order.IsDelivery
                ? "توصيل"
                : "استلام من المحل";
            sb.AppendLine(R($"نوع الاستلام: {deliveryLine}"));

            sb.AppendLine(Line(ThickSeparator));
            Console.WriteLine(sb);
            

            return sb.ToString();
        }

        // ═══════════════════════════════════════════════════════════
        // SLIP 2 — Daily Production Summary (manager/kitchen)
        // ═══════════════════════════════════════════════════════════

        /// <summary>
        /// Builds the daily production summary slip.
        /// Lists all products needed across all orders 
        /// due on the specified date.
        /// </summary>
        /// <param name="date">The delivery date.</param>
        /// <param name="items">
        ///   Aggregated list of 
        ///   (ProductName, Unit arabic string, TotalQuantity).
        ///   Aggregation is done at the service layer.
        /// </param>
        public static string BuildDailyProductionSlip(
            DateTime date,
            List<(string ProductName, string Unit, double TotalQuantity)> items)
        {
            var sb = new StringBuilder();

            // ── Header ────────────────────────────────────────────
            sb.AppendLine(C("قائمة الإنتاج اليومي"));
            sb.AppendLine(Line(ThickSeparator));
            sb.AppendLine(R($"تاريخ التسليم: {date:yyyy/MM/dd}"));
            sb.AppendLine(Line());

            // ── Column header ─────────────────────────────────────
            sb.AppendLine(R("الكمية                          الصنف"));
            sb.AppendLine(Line());

            // ── Product Lines ─────────────────────────────────────
            foreach (var (name, unit, qty) in items)
                sb.AppendLine(ProductLine(name, qty, unit));

            sb.AppendLine(Line(ThickSeparator));

            // ── Footer ────────────────────────────────────────────
            sb.AppendLine(R($"طُبع: {DateTime.Now:yyyy/MM/dd  HH:mm}"));

            return sb.ToString();
        }

        // ═══════════════════════════════════════════════════════════
        // SLIP 3 — Cook's Slip
        // ═══════════════════════════════════════════════════════════

        /// <summary>
        /// Builds a production slip addressed to a specific cook,
        /// listing what they need to prepare for the given date.
        /// </summary>
        /// <param name="cook">The employee (role = cook).</param>
        /// <param name="date">The delivery date.</param>
        /// <param name="items">
        ///   Aggregated list of 
        ///   (ProductName, Unit arabic string, TotalQuantity)
        ///   for this cook's products due on this date.
        ///   Aggregation is done at the service layer.
        /// </param>
        public static string BuildCookSlip(
            Employee cook,
            DateTime date,
            List<(string ProductName, string Unit, double TotalQuantity)> items)
        {
            var sb = new StringBuilder();

            // ── Header ────────────────────────────────────────────
            sb.AppendLine(C("تذكرة الطباخ"));
            sb.AppendLine(Line(ThickSeparator));
            sb.AppendLine(R($"الاسم: {cook.Name}"));
            sb.AppendLine(R($"تاريخ التسليم: {date:yyyy/MM/dd}"));
            sb.AppendLine(Line());

            // ── Column header ─────────────────────────────────────
            sb.AppendLine(R("الكمية                          الصنف"));
            sb.AppendLine(Line());

            // ── Product Lines ─────────────────────────────────────
            foreach (var (name, unit, qty) in items)
                sb.AppendLine(ProductLine(name, qty, unit));

            sb.AppendLine(Line(ThickSeparator));

            // ── Footer ────────────────────────────────────────────
            sb.AppendLine(R($"طُبع: {DateTime.Now:yyyy/MM/dd  HH:mm}"));

            return sb.ToString();
        }

        // ═══════════════════════════════════════════════════════════
        // SLIP 4 — Deposit Receipt (wholesale client)
        // ═══════════════════════════════════════════════════════════

        /// <summary>
        /// Builds a deposit receipt slip for a wholesale customer.
        /// Shows balance before, deposit amount, and balance after.
        /// </summary>
        /// <param name="customerName">Name of the wholesale customer.</param>
        /// <param name="balanceBefore">The customer's balance before the deposit.</param>
        /// <param name="depositAmount">The amount deposited.</param>
        /// <param name="balanceAfter">The customer's balance after the deposit.</param>
        public static string BuildDepositReceipt(
            string customerName,
            double balanceBefore,
            double depositAmount,
            double balanceAfter)
        {
            var sb = new StringBuilder();

            // ── Header ────────────────────────────────────────────
            sb.AppendLine(C("إيصال إيداع"));
            sb.AppendLine(Line(ThickSeparator));

            // ── Customer ──────────────────────────────────────────
            sb.AppendLine(R($"العميل: {customerName}"));
            sb.AppendLine(Line());

            // ── Amounts ───────────────────────────────────────────
            sb.AppendLine(R($"الرصيد قبل الإيداع: {balanceBefore:0.00} د.ل"));
            sb.AppendLine(R($"المبلغ المودع: {depositAmount:0.00} د.ل"));
            sb.AppendLine(Line());
            sb.AppendLine(R($"الرصيد بعد الإيداع: {balanceAfter:0.00} د.ل"));

            sb.AppendLine(Line(ThickSeparator));

            // ── Footer ────────────────────────────────────────────
            sb.AppendLine(R($"طُبع: {DateTime.Now:yyyy/MM/dd  HH:mm}"));

            return sb.ToString();
        }
    }

    // ── Extension: unit enum to Arabic string ─────────────────────
    public static class ProductUnitExtensions
    {
        public static string ToArabicString(this ProductUnit unit)
            => unit switch
            {
                ProductUnit.Kg    => "كغ",
                ProductUnit.Piece => "قطعة",
                _                 => ""
            };
    }
}
