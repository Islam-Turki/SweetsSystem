namespace sweetSystem.UserControls
{
    partial class OrderEntryControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            // ── Top-level controls ──────────────────────────────────────────
            headerPanel     = new System.Windows.Forms.Panel();
            h1Label         = new System.Windows.Forms.Label();
            sepBar          = new System.Windows.Forms.Panel();
            bodyTable       = new System.Windows.Forms.TableLayoutPanel();

            // ── LEFT  (Cart side) ───────────────────────────────────────────
            leftPanel       = new System.Windows.Forms.Panel();
            // Order-type card (retail / wholesale toggle)
            typeCard        = new System.Windows.Forms.Panel();
            lblOrderType    = new System.Windows.Forms.Label();
            _rbRetail       = new System.Windows.Forms.RadioButton();
            _rbWholesale    = new System.Windows.Forms.RadioButton();
            // Customer panels (retail & wholesale)
            _retailPanel        = new System.Windows.Forms.Panel();
            lblCustomerName     = new System.Windows.Forms.Label();
            _txCustomer         = new System.Windows.Forms.TextBox();
            _txCustomerExtra    = new System.Windows.Forms.TextBox();
            _btnDeliveryRetail  = new sweetSystem.FlatButton();
            _lblDeliveryRetail  = new System.Windows.Forms.Label();
            _calRetail          = new System.Windows.Forms.MonthCalendar();
            _wholesalePanel     = new System.Windows.Forms.Panel();
            lblWholesaleClient  = new System.Windows.Forms.Label();
            _cbClient           = new System.Windows.Forms.ComboBox();
            _btnDeliveryWholesale = new sweetSystem.FlatButton();
            _lblDeliveryWholesale = new System.Windows.Forms.Label();
            _calWholesale       = new System.Windows.Forms.MonthCalendar();
            // Cart grid label
            lblCartTitle    = new System.Windows.Forms.Label();
            // Cart DataGridView
            _linesGrid      = new System.Windows.Forms.DataGridView();
            // Summary card
            sumCard         = new System.Windows.Forms.Panel();
            lblSummary      = new System.Windows.Forms.Label();
            sepBar1         = new System.Windows.Forms.Panel();
            lblSubTitle     = new System.Windows.Forms.Label();
            _lblSub         = new System.Windows.Forms.Label();
            _balanceRow     = new System.Windows.Forms.Panel();
            lblBalanceTitle = new System.Windows.Forms.Label();
            _lblBalance     = new System.Windows.Forms.Label();
            sepBar2         = new System.Windows.Forms.Panel();
            lblGrandTitle   = new System.Windows.Forms.Label();
            _lblGrand       = new System.Windows.Forms.Label();
            // Action buttons
            btnActFlow      = new System.Windows.Forms.FlowLayoutPanel();
            _btnSave        = new sweetSystem.FlatButton();
            _btnClear       = new sweetSystem.FlatButton();

            // ── RIGHT (Catalog side) ────────────────────────────────────────
            rightPanel      = new System.Windows.Forms.Panel();
            lblCatalogTitle = new System.Windows.Forms.Label();
            catalogSearch   = new System.Windows.Forms.TextBox();
            _catalogFlow    = new System.Windows.Forms.FlowLayoutPanel();

            // ── SuspendLayout ───────────────────────────────────────────────
            headerPanel.SuspendLayout();
            bodyTable.SuspendLayout();
            leftPanel.SuspendLayout();
            typeCard.SuspendLayout();
            _retailPanel.SuspendLayout();
            _wholesalePanel.SuspendLayout();
            sumCard.SuspendLayout();
            _balanceRow.SuspendLayout();
            btnActFlow.SuspendLayout();
            rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_linesGrid).BeginInit();
            SuspendLayout();

            // ══════════════════════════════════════════════════════════════════
            //  HEADER PANEL
            // ══════════════════════════════════════════════════════════════════
            headerPanel.BackColor = System.Drawing.Color.White;
            headerPanel.Dock      = System.Windows.Forms.DockStyle.Top;
            headerPanel.Height    = 84;
            headerPanel.Controls.Add(h1Label);
            headerPanel.Controls.Add(sepBar);

            h1Label.Dock      = System.Windows.Forms.DockStyle.Fill;
            h1Label.Font      = new System.Drawing.Font("Cairo", 16f, System.Drawing.FontStyle.Bold);
            h1Label.ForeColor = System.Drawing.Color.FromArgb(36, 36, 36);
            h1Label.Text      = "🛒  إدخال طلب جديد";
            h1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            h1Label.Padding   = new System.Windows.Forms.Padding(0, 0, 16, 0);

            sepBar.BackColor = System.Drawing.Color.FromArgb(53, 133, 142);
            sepBar.Dock      = System.Windows.Forms.DockStyle.Bottom;
            sepBar.Height    = 3;

            // ══════════════════════════════════════════════════════════════════
            //  BODY  TableLayoutPanel  (2 cols:  Left 42% | Right 58%)
            // ══════════════════════════════════════════════════════════════════
            bodyTable.BackColor   = System.Drawing.Color.FromArgb(247, 246, 242);
            bodyTable.Dock        = System.Windows.Forms.DockStyle.Fill;
            bodyTable.Padding     = new System.Windows.Forms.Padding(12, 16, 12, 12);
            bodyTable.ColumnCount = 2;
            bodyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42f));
            bodyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58f));
            bodyTable.RowCount    = 1;
            bodyTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
            bodyTable.Controls.Add(leftPanel,  0, 0);
            bodyTable.Controls.Add(rightPanel, 1, 0);

            // ══════════════════════════════════════════════════════════════════
            //  LEFT PANEL — Cart
            // ══════════════════════════════════════════════════════════════════
            leftPanel.Dock    = System.Windows.Forms.DockStyle.Fill;
            leftPanel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            leftPanel.Controls.Add(_linesGrid);
            leftPanel.Controls.Add(lblCartTitle);
            leftPanel.Controls.Add(typeCard);
            leftPanel.Controls.Add(_retailPanel);
            leftPanel.Controls.Add(_wholesalePanel);
            leftPanel.Controls.Add(sumCard);
            leftPanel.Controls.Add(btnActFlow);

            // ── Order-type card ──────────────────────────────────────────────
            typeCard.BackColor = System.Drawing.Color.White;
            typeCard.Dock      = System.Windows.Forms.DockStyle.Top;
            typeCard.Height    = 56;
            typeCard.Padding   = new System.Windows.Forms.Padding(10, 8, 10, 8);
            typeCard.Margin    = new System.Windows.Forms.Padding(0, 0, 0, 6);
            typeCard.Controls.Add(lblOrderType);
            typeCard.Controls.Add(_rbRetail);
            typeCard.Controls.Add(_rbWholesale);

            lblOrderType.Text      = "نوع الطلب:";
            lblOrderType.AutoSize  = true;
            lblOrderType.Location  = new System.Drawing.Point(10, 16);

            _rbRetail.Text         = "قطاعي";
            _rbRetail.Checked      = true;
            _rbRetail.AutoSize     = true;
            _rbRetail.Cursor       = System.Windows.Forms.Cursors.Hand;
            _rbRetail.RightToLeft  = System.Windows.Forms.RightToLeft.Yes;
            _rbRetail.Location     = new System.Drawing.Point(120, 14);
            _rbRetail.CheckedChanged += _rbType_CheckedChanged;

            _rbWholesale.Text      = "جملة";
            _rbWholesale.AutoSize  = true;
            _rbWholesale.Cursor    = System.Windows.Forms.Cursors.Hand;
            _rbWholesale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            _rbWholesale.Location  = new System.Drawing.Point(200, 14);
            _rbWholesale.CheckedChanged += _rbType_CheckedChanged;

            // ── Retail customer panel ────────────────────────────────────────
            _retailPanel.BackColor = System.Drawing.Color.FromArgb(247, 246, 242);
            _retailPanel.Dock      = System.Windows.Forms.DockStyle.Top;
            _retailPanel.Height    = 94;
            _retailPanel.Padding   = new System.Windows.Forms.Padding(10, 6, 10, 6);
            _retailPanel.Controls.Add(lblCustomerName);
            _retailPanel.Controls.Add(_txCustomer);
            _retailPanel.Controls.Add(_txCustomerExtra);
            _retailPanel.Controls.Add(_btnDeliveryRetail);
            _retailPanel.Controls.Add(_lblDeliveryRetail);
            _retailPanel.Controls.Add(_calRetail);

            lblCustomerName.Text     = "اسم العميل";
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new System.Drawing.Point(10, 6);

            _txCustomer.PlaceholderText = "أدخل اسم العميل";
            _txCustomer.BorderStyle     = System.Windows.Forms.BorderStyle.FixedSingle;
            _txCustomer.Location        = new System.Drawing.Point(10, 26);
            _txCustomer.Width           = 220;
            _txCustomer.TextChanged    += _txCustomer_TextChanged;

            _txCustomerExtra.PlaceholderText = "رقم الهاتف (اختياري)";
            _txCustomerExtra.BorderStyle     = System.Windows.Forms.BorderStyle.FixedSingle;
            _txCustomerExtra.Location        = new System.Drawing.Point(10, 58);
            _txCustomerExtra.Width           = 220;

            _btnDeliveryRetail.Text      = "📅 التسليم";
            _btnDeliveryRetail.BackColor = System.Drawing.Color.FromArgb(90, 150, 170);
            _btnDeliveryRetail.ForeColor = System.Drawing.Color.White;
            _btnDeliveryRetail.Font      = new System.Drawing.Font("Cairo", 8.5f, System.Drawing.FontStyle.Bold);
            _btnDeliveryRetail.Location  = new System.Drawing.Point(240, 26);
            _btnDeliveryRetail.Size      = new System.Drawing.Size(110, 28);
            _btnDeliveryRetail.Radius    = 6;

            _lblDeliveryRetail.Text     = "لم يحدد";
            _lblDeliveryRetail.AutoSize = true;
            _lblDeliveryRetail.Location = new System.Drawing.Point(240, 60);

            _calRetail.Visible          = false;
            _calRetail.MaxSelectionCount = 1;
            _calRetail.Location         = new System.Drawing.Point(10, 98);

            // ── Wholesale customer panel ─────────────────────────────────────
            _wholesalePanel.BackColor = System.Drawing.Color.FromArgb(247, 246, 242);
            _wholesalePanel.Dock      = System.Windows.Forms.DockStyle.Top;
            _wholesalePanel.Height    = 94;
            _wholesalePanel.Padding   = new System.Windows.Forms.Padding(10, 6, 10, 6);
            _wholesalePanel.Visible   = false;
            _wholesalePanel.Controls.Add(lblWholesaleClient);
            _wholesalePanel.Controls.Add(_cbClient);
            _wholesalePanel.Controls.Add(_btnDeliveryWholesale);
            _wholesalePanel.Controls.Add(_lblDeliveryWholesale);
            _wholesalePanel.Controls.Add(_calWholesale);

            lblWholesaleClient.Text     = "عميل الجملة";
            lblWholesaleClient.AutoSize = true;
            lblWholesaleClient.Location = new System.Drawing.Point(10, 6);

            _cbClient.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _cbClient.FlatStyle         = System.Windows.Forms.FlatStyle.Flat;
            _cbClient.Location          = new System.Drawing.Point(10, 26);
            _cbClient.Width             = 220;
            _cbClient.SelectedIndexChanged += _cbClient_SelectedIndexChanged;

            _btnDeliveryWholesale.Text      = "📅 التسليم";
            _btnDeliveryWholesale.BackColor = System.Drawing.Color.FromArgb(90, 150, 170);
            _btnDeliveryWholesale.ForeColor = System.Drawing.Color.White;
            _btnDeliveryWholesale.Font      = new System.Drawing.Font("Cairo", 8.5f, System.Drawing.FontStyle.Bold);
            _btnDeliveryWholesale.Location  = new System.Drawing.Point(240, 26);
            _btnDeliveryWholesale.Size      = new System.Drawing.Size(110, 28);
            _btnDeliveryWholesale.Radius    = 6;

            _lblDeliveryWholesale.Text     = "لم يحدد";
            _lblDeliveryWholesale.AutoSize = true;
            _lblDeliveryWholesale.Location = new System.Drawing.Point(240, 60);

            _calWholesale.Visible          = false;
            _calWholesale.MaxSelectionCount = 1;
            _calWholesale.Location         = new System.Drawing.Point(10, 98);

            // ── Cart title label ─────────────────────────────────────────────
            lblCartTitle.Text      = "🛒  سلة الطلب";
            lblCartTitle.AutoSize  = false;
            lblCartTitle.Dock      = System.Windows.Forms.DockStyle.Top;
            lblCartTitle.Height    = 30;
            lblCartTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblCartTitle.Font      = new System.Drawing.Font("Cairo", 11f, System.Drawing.FontStyle.Bold);
            lblCartTitle.ForeColor = System.Drawing.Color.FromArgb(31, 45, 47);
            lblCartTitle.Padding   = new System.Windows.Forms.Padding(4, 0, 0, 0);

            // ── Cart DataGridView ────────────────────────────────────────────
            _linesGrid.Dock        = System.Windows.Forms.DockStyle.Fill;
            _linesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // ── Summary card ─────────────────────────────────────────────────
            sumCard.BackColor = System.Drawing.Color.White;
            sumCard.Dock      = System.Windows.Forms.DockStyle.Bottom;
            sumCard.Height    = 192;
            sumCard.Padding   = new System.Windows.Forms.Padding(12, 8, 12, 8);
            sumCard.Controls.Add(lblSummary);
            sumCard.Controls.Add(sepBar1);
            sumCard.Controls.Add(lblSubTitle);
            sumCard.Controls.Add(_lblSub);
            sumCard.Controls.Add(_balanceRow);
            sumCard.Controls.Add(sepBar2);
            sumCard.Controls.Add(lblGrandTitle);
            sumCard.Controls.Add(_lblGrand);

            lblSummary.Text      = "ملخص الطلب";
            lblSummary.AutoSize  = true;
            lblSummary.Font      = new System.Drawing.Font("Cairo", 11f, System.Drawing.FontStyle.Bold);
            lblSummary.Location  = new System.Drawing.Point(12, 8);

            sepBar1.BackColor    = System.Drawing.Color.FromArgb(220, 220, 220);
            sepBar1.Location     = new System.Drawing.Point(12, 36);
            sepBar1.Height       = 1;
            sepBar1.Anchor       = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;

            lblSubTitle.Text     = "المجموع الفرعي:";
            lblSubTitle.AutoSize = true;
            lblSubTitle.Location = new System.Drawing.Point(12, 46);

            _lblSub.Text         = "0.00 د.ل";
            _lblSub.AutoSize     = true;
            _lblSub.Font         = new System.Drawing.Font("Cairo", 9f, System.Drawing.FontStyle.Bold);
            _lblSub.Location     = new System.Drawing.Point(200, 46);

            _balanceRow.BackColor = System.Drawing.Color.Transparent;
            _balanceRow.Location  = new System.Drawing.Point(12, 74);
            _balanceRow.Height    = 28;
            _balanceRow.Anchor    = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            _balanceRow.Visible   = false;
            _balanceRow.Controls.Add(lblBalanceTitle);
            _balanceRow.Controls.Add(_lblBalance);

            lblBalanceTitle.Text     = "الرصيد السابق:";
            lblBalanceTitle.AutoSize = true;
            lblBalanceTitle.ForeColor = System.Drawing.Color.FromArgb(210, 70, 70);
            lblBalanceTitle.Location = new System.Drawing.Point(0, 4);

            _lblBalance.Text      = "0.00 د.ل";
            _lblBalance.AutoSize  = true;
            _lblBalance.ForeColor = System.Drawing.Color.FromArgb(210, 70, 70);
            _lblBalance.Font      = new System.Drawing.Font("Cairo", 9f, System.Drawing.FontStyle.Bold);
            _lblBalance.Location  = new System.Drawing.Point(188, 4);

            sepBar2.BackColor    = System.Drawing.Color.FromArgb(220, 220, 220);
            sepBar2.Location     = new System.Drawing.Point(12, 110);
            sepBar2.Height       = 1;
            sepBar2.Anchor       = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;

            lblGrandTitle.Text      = "الإجمالي الكلي:";
            lblGrandTitle.AutoSize  = true;
            lblGrandTitle.ForeColor = System.Drawing.Color.FromArgb(30, 120, 80);
            lblGrandTitle.Font      = new System.Drawing.Font("Cairo", 10f, System.Drawing.FontStyle.Bold);
            lblGrandTitle.Location  = new System.Drawing.Point(12, 120);

            _lblGrand.Text      = "0.00 د.ل";
            _lblGrand.AutoSize  = true;
            _lblGrand.ForeColor = System.Drawing.Color.FromArgb(30, 120, 80);
            _lblGrand.Font      = new System.Drawing.Font("Cairo", 13f, System.Drawing.FontStyle.Bold);
            _lblGrand.Location  = new System.Drawing.Point(180, 116);

            // ── Action buttons flow ──────────────────────────────────────────
            btnActFlow.Dock          = System.Windows.Forms.DockStyle.Bottom;
            btnActFlow.Height        = 52;
            btnActFlow.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            btnActFlow.Padding       = new System.Windows.Forms.Padding(0, 8, 0, 0);
            btnActFlow.BackColor     = System.Drawing.Color.FromArgb(247, 246, 242);
            btnActFlow.Controls.Add(_btnSave);
            btnActFlow.Controls.Add(_btnClear);

            _btnSave.Text      = "✔  تأكيد الطلب";
            _btnSave.BackColor = System.Drawing.Color.FromArgb(43, 150, 90);
            _btnSave.ForeColor = System.Drawing.Color.White;
            _btnSave.Font      = new System.Drawing.Font("Cairo", 9.5f, System.Drawing.FontStyle.Bold);
            _btnSave.Size      = new System.Drawing.Size(170, 34);
            _btnSave.Radius    = 8;
            _btnSave.Margin    = new System.Windows.Forms.Padding(0, 0, 8, 0);
            _btnSave.Click    += BtnSave_Click;

            _btnClear.Text      = "✕  مسح";
            _btnClear.BackColor = System.Drawing.Color.FromArgb(150, 150, 150);
            _btnClear.ForeColor = System.Drawing.Color.White;
            _btnClear.Font      = new System.Drawing.Font("Cairo", 9.5f, System.Drawing.FontStyle.Bold);
            _btnClear.Size      = new System.Drawing.Size(100, 34);
            _btnClear.Radius    = 8;
            _btnClear.Click    += BtnClear_Click;

            // ══════════════════════════════════════════════════════════════════
            //  RIGHT PANEL — Catalog
            // ══════════════════════════════════════════════════════════════════
            rightPanel.Dock    = System.Windows.Forms.DockStyle.Fill;
            rightPanel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            rightPanel.Controls.Add(_catalogFlow);
            rightPanel.Controls.Add(catalogSearch);
            rightPanel.Controls.Add(lblCatalogTitle);

            // Catalog header label
            lblCatalogTitle.Text      = "🏪  المنتجات";
            lblCatalogTitle.AutoSize  = false;
            lblCatalogTitle.Dock      = System.Windows.Forms.DockStyle.Top;
            lblCatalogTitle.Height    = 30;
            lblCatalogTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblCatalogTitle.Font      = new System.Drawing.Font("Cairo", 11f, System.Drawing.FontStyle.Bold);
            lblCatalogTitle.ForeColor = System.Drawing.Color.FromArgb(31, 45, 47);
            lblCatalogTitle.Padding   = new System.Windows.Forms.Padding(4, 0, 0, 0);

            // Search box
            catalogSearch.Dock            = System.Windows.Forms.DockStyle.Top;
            catalogSearch.PlaceholderText = "🔍  ابحث عن منتج...";
            catalogSearch.BorderStyle     = System.Windows.Forms.BorderStyle.FixedSingle;
            catalogSearch.Font            = new System.Drawing.Font("Cairo", 9.5f);
            catalogSearch.Height          = 30;
            catalogSearch.Margin          = new System.Windows.Forms.Padding(0, 0, 0, 6);
            catalogSearch.TextChanged    += CatalogSearch_TextChanged;

            // Catalog FlowLayoutPanel
            _catalogFlow.Dock          = System.Windows.Forms.DockStyle.Fill;
            _catalogFlow.AutoScroll    = true;
            _catalogFlow.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            _catalogFlow.WrapContents  = true;
            _catalogFlow.Padding       = new System.Windows.Forms.Padding(4);
            _catalogFlow.BackColor     = System.Drawing.Color.FromArgb(247, 246, 242);

            // ══════════════════════════════════════════════════════════════════
            //  ROOT UserControl
            // ══════════════════════════════════════════════════════════════════
            AutoScaleDimensions = new System.Drawing.SizeF(8f, 20f);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            BackColor           = System.Drawing.Color.FromArgb(247, 246, 242);
            RightToLeft         = System.Windows.Forms.RightToLeft.Yes;
            Size                = new System.Drawing.Size(1200, 820);
            Controls.Add(bodyTable);
            Controls.Add(headerPanel);
            Name = "OrderEntryControl";

            // ── ResumeLayout ─────────────────────────────────────────────────
            headerPanel.ResumeLayout(false);
            bodyTable.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            typeCard.ResumeLayout(false);
            typeCard.PerformLayout();
            _retailPanel.ResumeLayout(false);
            _retailPanel.PerformLayout();
            _wholesalePanel.ResumeLayout(false);
            _wholesalePanel.PerformLayout();
            sumCard.ResumeLayout(false);
            sumCard.PerformLayout();
            _balanceRow.ResumeLayout(false);
            _balanceRow.PerformLayout();
            btnActFlow.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_linesGrid).EndInit();
            ResumeLayout(false);
        }
        #endregion

        // ── Field declarations ────────────────────────────────────────────────
        private System.Windows.Forms.Panel       headerPanel;
        private System.Windows.Forms.Label       h1Label;
        private System.Windows.Forms.Panel       sepBar;
        private System.Windows.Forms.TableLayoutPanel bodyTable;

        // Left (Cart)
        private System.Windows.Forms.Panel       leftPanel;
        private System.Windows.Forms.Panel       typeCard;
        private System.Windows.Forms.Label       lblOrderType;
        private System.Windows.Forms.RadioButton _rbRetail;
        private System.Windows.Forms.RadioButton _rbWholesale;

        private System.Windows.Forms.Panel       _retailPanel;
        private System.Windows.Forms.Label       lblCustomerName;
        private System.Windows.Forms.TextBox     _txCustomer;
        private System.Windows.Forms.TextBox     _txCustomerExtra;
        private sweetSystem.FlatButton           _btnDeliveryRetail;
        private System.Windows.Forms.Label       _lblDeliveryRetail;
        private System.Windows.Forms.MonthCalendar _calRetail;

        private System.Windows.Forms.Panel       _wholesalePanel;
        private System.Windows.Forms.Label       lblWholesaleClient;
        private System.Windows.Forms.ComboBox    _cbClient;
        private sweetSystem.FlatButton           _btnDeliveryWholesale;
        private System.Windows.Forms.Label       _lblDeliveryWholesale;
        private System.Windows.Forms.MonthCalendar _calWholesale;

        private System.Windows.Forms.Label       lblCartTitle;
        private System.Windows.Forms.DataGridView _linesGrid;

        private System.Windows.Forms.Panel       sumCard;
        private System.Windows.Forms.Label       lblSummary;
        private System.Windows.Forms.Panel       sepBar1;
        private System.Windows.Forms.Label       lblSubTitle;
        private System.Windows.Forms.Label       _lblSub;
        private System.Windows.Forms.Panel       _balanceRow;
        private System.Windows.Forms.Label       lblBalanceTitle;
        private System.Windows.Forms.Label       _lblBalance;
        private System.Windows.Forms.Panel       sepBar2;
        private System.Windows.Forms.Label       lblGrandTitle;
        private System.Windows.Forms.Label       _lblGrand;

        private System.Windows.Forms.FlowLayoutPanel btnActFlow;
        private sweetSystem.FlatButton               _btnSave;
        private sweetSystem.FlatButton               _btnClear;

        // Right (Catalog)
        private System.Windows.Forms.Panel           rightPanel;
        private System.Windows.Forms.Label           lblCatalogTitle;
        private System.Windows.Forms.TextBox         catalogSearch;
        private System.Windows.Forms.FlowLayoutPanel _catalogFlow;
    }
}