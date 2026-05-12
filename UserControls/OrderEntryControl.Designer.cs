using sweetSystem;
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
            headerPanel = new Panel();
            h1Label = new Label();
            sepBar = new Panel();
            bodyTable = new TableLayoutPanel();
            infoPanel = new Panel();
            sumCard = new Panel();
            lblSummary = new Label();
            sepBar1 = new Panel();
            lblSubTitle = new Label();
            _lblSub = new Label();
            _balanceRow = new Panel();
            lblBalanceTitle = new Label();
            _lblBalance = new Label();
            sepBar2 = new Panel();
            lblGrandTitle = new Label();
            _lblGrand = new Label();
            _wholesalePanel = new Panel();
            wholesaleTable = new TableLayoutPanel();
            _cbClient = new ComboBox();
            wholesaleDateFlow = new FlowLayoutPanel();
            _chkIsDeliveryWholesale = new CheckBox();
            _lblDeliveryWholesale = new Label();
            lblPaidWholesale = new Label();
            _txPaidWholesaleWrap = new Panel();
            _txPaidWholesale = new TextBox();
            lblWholesaleClient = new Label();
            _calWholesale = new MonthCalendar();
            _retailPanel = new Panel();
            retailTable = new TableLayoutPanel();
            lblCustomerName = new Label();
            _txCustomerWrap = new Panel();
            _txCustomer = new TextBox();
            _txCustomerExtraWrap = new Panel();
            _txCustomerExtra = new TextBox();
            retailDateFlow = new FlowLayoutPanel();
            _chkIsDeliveryRetail = new CheckBox();
            _lblDeliveryRetail = new Label();
            lblPaidRetail = new Label();
            _txPaidRetailWrap = new Panel();
            _txPaidRetail = new TextBox();
            _calRetail = new MonthCalendar();
            typeCard = new Panel();
            lblOrderType = new Label();
            _rbRetail = new RadioButton();
            _rbWholesale = new RadioButton();
            leftPanel = new Panel();
            _linesGrid = new DataGridView();
            btnActFlow = new FlowLayoutPanel();
            lblCartTitle = new Label();
            rightPanel = new Panel();
            _catalogFlow = new FlowLayoutPanel();
            catalogSearch = new TextBox();
            lblCatalogTitle = new Label();
            headerPanel.SuspendLayout();
            bodyTable.SuspendLayout();
            infoPanel.SuspendLayout();
            sumCard.SuspendLayout();
            _balanceRow.SuspendLayout();
            _wholesalePanel.SuspendLayout();
            wholesaleTable.SuspendLayout();
            wholesaleDateFlow.SuspendLayout();
            _txPaidWholesaleWrap.SuspendLayout();
            _retailPanel.SuspendLayout();
            retailTable.SuspendLayout();
            _txCustomerWrap.SuspendLayout();
            _txCustomerExtraWrap.SuspendLayout();
            retailDateFlow.SuspendLayout();
            _txPaidRetailWrap.SuspendLayout();
            typeCard.SuspendLayout();
            leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_linesGrid).BeginInit();
            rightPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(h1Label);
            headerPanel.Controls.Add(sepBar);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(3, 2, 3, 2);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1050, 63);
            headerPanel.TabIndex = 1;
            // 
            // h1Label
            // 
            h1Label.Dock = DockStyle.Fill;
            h1Label.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            h1Label.ForeColor = Color.FromArgb(36, 36, 36);
            h1Label.Location = new Point(0, 0);
            h1Label.Name = "h1Label";
            h1Label.Padding = new Padding(0, 0, 14, 0);
            h1Label.Size = new Size(1050, 61);
            h1Label.TabIndex = 0;
            h1Label.Text = "\U0001f6d2  إدخال طلب جديد";
            h1Label.TextAlign = ContentAlignment.MiddleLeft;
            h1Label.Click += h1Label_Click;
            // 
            // sepBar
            // 
            sepBar.BackColor = Color.FromArgb(53, 133, 142);
            sepBar.Dock = DockStyle.Bottom;
            sepBar.Location = new Point(0, 61);
            sepBar.Margin = new Padding(3, 2, 3, 2);
            sepBar.Name = "sepBar";
            sepBar.Size = new Size(1050, 2);
            sepBar.TabIndex = 1;
            // 
            // bodyTable
            // 
            bodyTable.BackColor = Color.FromArgb(247, 246, 242);
            bodyTable.ColumnCount = 3;
            bodyTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            bodyTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            bodyTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            bodyTable.Controls.Add(infoPanel, 0, 0);
            bodyTable.Controls.Add(leftPanel, 1, 0);
            bodyTable.Controls.Add(rightPanel, 2, 0);
            bodyTable.Dock = DockStyle.Fill;
            bodyTable.Location = new Point(0, 63);
            bodyTable.Margin = new Padding(3, 2, 3, 2);
            bodyTable.Name = "bodyTable";
            bodyTable.Padding = new Padding(10, 12, 10, 9);
            bodyTable.RowCount = 1;
            bodyTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bodyTable.Size = new Size(1050, 552);
            bodyTable.TabIndex = 0;
            // 
            // infoPanel
            // 
            infoPanel.Controls.Add(sumCard);
            infoPanel.Controls.Add(_wholesalePanel);
            infoPanel.Controls.Add(_retailPanel);
            infoPanel.Controls.Add(typeCard);
            infoPanel.Dock = DockStyle.Fill;
            infoPanel.Location = new Point(786, 14);
            infoPanel.Margin = new Padding(3, 2, 3, 2);
            infoPanel.Name = "infoPanel";
            infoPanel.Padding = new Padding(0, 0, 9, 0);
            infoPanel.Size = new Size(251, 527);
            infoPanel.TabIndex = 2;
            // 
            // sumCard
            // 
            sumCard.BackColor = Color.White;
            sumCard.Controls.Add(lblSummary);
            sumCard.Controls.Add(sepBar1);
            sumCard.Controls.Add(lblSubTitle);
            sumCard.Controls.Add(_lblSub);
            sumCard.Controls.Add(_balanceRow);
            sumCard.Controls.Add(sepBar2);
            sumCard.Controls.Add(lblGrandTitle);
            sumCard.Controls.Add(_lblGrand);
            sumCard.Dock = DockStyle.Bottom;
            sumCard.Location = new Point(0, 383);
            sumCard.Margin = new Padding(3, 2, 3, 2);
            sumCard.Name = "sumCard";
            sumCard.Padding = new Padding(10, 6, 10, 6);
            sumCard.Size = new Size(242, 144);
            sumCard.TabIndex = 5;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            lblSummary.Location = new Point(10, 6);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(85, 18);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "ملخص الطلب";
            // 
            // sepBar1
            // 
            sepBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sepBar1.BackColor = Color.FromArgb(220, 220, 220);
            sepBar1.Location = new Point(10, 27);
            sepBar1.Margin = new Padding(3, 2, 3, 2);
            sepBar1.Name = "sepBar1";
            sepBar1.Size = new Size(242, 1);
            sepBar1.TabIndex = 1;
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Location = new Point(10, 34);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(88, 15);
            lblSubTitle.TabIndex = 2;
            lblSubTitle.Text = "المجموع الفرعي:";
            // 
            // _lblSub
            // 
            _lblSub.AutoSize = true;
            _lblSub.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            _lblSub.Location = new Point(175, 34);
            _lblSub.Name = "_lblSub";
            _lblSub.Size = new Size(55, 15);
            _lblSub.TabIndex = 3;
            _lblSub.Text = "0.00 د.ل";
            // 
            // _balanceRow
            // 
            _balanceRow.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _balanceRow.BackColor = Color.Transparent;
            _balanceRow.Controls.Add(lblBalanceTitle);
            _balanceRow.Controls.Add(_lblBalance);
            _balanceRow.Location = new Point(10, 56);
            _balanceRow.Margin = new Padding(3, 2, 3, 2);
            _balanceRow.Name = "_balanceRow";
            _balanceRow.Size = new Size(242, 21);
            _balanceRow.TabIndex = 4;
            _balanceRow.Visible = false;
            // 
            // lblBalanceTitle
            // 
            lblBalanceTitle.AutoSize = true;
            lblBalanceTitle.ForeColor = Color.FromArgb(210, 70, 70);
            lblBalanceTitle.Location = new Point(0, 3);
            lblBalanceTitle.Name = "lblBalanceTitle";
            lblBalanceTitle.Size = new Size(79, 15);
            lblBalanceTitle.TabIndex = 0;
            lblBalanceTitle.Text = "الرصيد السابق:";
            // 
            // _lblBalance
            // 
            _lblBalance.AutoSize = true;
            _lblBalance.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            _lblBalance.ForeColor = Color.FromArgb(210, 70, 70);
            _lblBalance.Location = new Point(164, 3);
            _lblBalance.Name = "_lblBalance";
            _lblBalance.Size = new Size(55, 15);
            _lblBalance.TabIndex = 1;
            _lblBalance.Text = "0.00 د.ل";
            // 
            // sepBar2
            // 
            sepBar2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sepBar2.BackColor = Color.FromArgb(220, 220, 220);
            sepBar2.Location = new Point(10, 82);
            sepBar2.Margin = new Padding(3, 2, 3, 2);
            sepBar2.Name = "sepBar2";
            sepBar2.Size = new Size(242, 1);
            sepBar2.TabIndex = 5;
            // 
            // lblGrandTitle
            // 
            lblGrandTitle.AutoSize = true;
            lblGrandTitle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblGrandTitle.ForeColor = Color.FromArgb(30, 120, 80);
            lblGrandTitle.Location = new Point(10, 90);
            lblGrandTitle.Name = "lblGrandTitle";
            lblGrandTitle.Size = new Size(91, 17);
            lblGrandTitle.TabIndex = 6;
            lblGrandTitle.Text = "الإجمالي الكلي:";
            // 
            // _lblGrand
            // 
            _lblGrand.AutoSize = true;
            _lblGrand.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            _lblGrand.ForeColor = Color.FromArgb(30, 120, 80);
            _lblGrand.Location = new Point(158, 87);
            _lblGrand.Name = "_lblGrand";
            _lblGrand.Size = new Size(78, 22);
            _lblGrand.TabIndex = 7;
            _lblGrand.Text = "0.00 د.ل";
            // 
            // _wholesalePanel
            // 
            _wholesalePanel.AutoSize = true;
            _wholesalePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _wholesalePanel.BackColor = Color.FromArgb(247, 246, 242);
            _wholesalePanel.Controls.Add(wholesaleTable);
            _wholesalePanel.Controls.Add(_calWholesale);
            _wholesalePanel.Dock = DockStyle.Top;
            _wholesalePanel.Location = new Point(0, 296);
            _wholesalePanel.Margin = new Padding(3, 2, 3, 2);
            _wholesalePanel.Name = "_wholesalePanel";
            _wholesalePanel.Padding = new Padding(13, 11, 13, 11);
            _wholesalePanel.RightToLeft = RightToLeft.Yes;
            _wholesalePanel.Size = new Size(242, 254);
            _wholesalePanel.TabIndex = 4;
            _wholesalePanel.Visible = false;
            // 
            // wholesaleTable
            // 
            wholesaleTable.AutoSize = true;
            wholesaleTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            wholesaleTable.ColumnCount = 1;
            wholesaleTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            wholesaleTable.Controls.Add(_cbClient, 0, 1);
            wholesaleTable.Controls.Add(wholesaleDateFlow, 0, 2);
            wholesaleTable.Controls.Add(lblWholesaleClient, 0, 0);
            wholesaleTable.Dock = DockStyle.Fill;
            wholesaleTable.Location = new Point(13, 11);
            wholesaleTable.Margin = new Padding(0);
            wholesaleTable.Name = "wholesaleTable";
            wholesaleTable.RightToLeft = RightToLeft.Yes;
            wholesaleTable.RowCount = 3;
            wholesaleTable.RowStyles.Add(new RowStyle());
            wholesaleTable.RowStyles.Add(new RowStyle());
            wholesaleTable.RowStyles.Add(new RowStyle());
            wholesaleTable.Size = new Size(216, 232);
            wholesaleTable.TabIndex = 0;
            // 
            // _cbClient
            // 
            _cbClient.Dock = DockStyle.Fill;
            _cbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbClient.FlatStyle = FlatStyle.Flat;
            _cbClient.Location = new Point(0, 21);
            _cbClient.Margin = new Padding(0, 0, 0, 9);
            _cbClient.Name = "_cbClient";
            _cbClient.Size = new Size(216, 23);
            _cbClient.TabIndex = 1;
            _cbClient.SelectedIndexChanged += _cbClient_SelectedIndexChanged;
            // 
            // wholesaleDateFlow
            // 
            wholesaleDateFlow.AutoSize = true;
            wholesaleDateFlow.Controls.Add(_chkIsDeliveryWholesale);
            wholesaleDateFlow.Controls.Add(_lblDeliveryWholesale);
            wholesaleDateFlow.Controls.Add(lblPaidWholesale);
            wholesaleDateFlow.Controls.Add(_txPaidWholesaleWrap);
            wholesaleDateFlow.Dock = DockStyle.Fill;
            wholesaleDateFlow.Location = new Point(0, 53);
            wholesaleDateFlow.Margin = new Padding(0);
            wholesaleDateFlow.Name = "wholesaleDateFlow";
            wholesaleDateFlow.RightToLeft = RightToLeft.Yes;
            wholesaleDateFlow.Size = new Size(216, 179);
            wholesaleDateFlow.TabIndex = 2;
            // 
            // _chkIsDeliveryWholesale
            // 
            _chkIsDeliveryWholesale.AutoSize = true;
            _chkIsDeliveryWholesale.Location = new Point(128, 4);
            _chkIsDeliveryWholesale.Margin = new Padding(0, 4, 9, 0);
            _chkIsDeliveryWholesale.Name = "_chkIsDeliveryWholesale";
            _chkIsDeliveryWholesale.Size = new Size(88, 19);
            _chkIsDeliveryWholesale.TabIndex = 2;
            _chkIsDeliveryWholesale.Text = "طلب توصيل";
            _chkIsDeliveryWholesale.UseVisualStyleBackColor = true;
            // 
            // _lblDeliveryWholesale
            // 
            _lblDeliveryWholesale.AutoSize = true;
            _lblDeliveryWholesale.Location = new Point(75, 4);
            _lblDeliveryWholesale.Margin = new Padding(0, 4, 0, 0);
            _lblDeliveryWholesale.Name = "_lblDeliveryWholesale";
            _lblDeliveryWholesale.Size = new Size(44, 15);
            _lblDeliveryWholesale.TabIndex = 1;
            _lblDeliveryWholesale.Text = "لم يحدد";
            // 
            // lblPaidWholesale
            // 
            lblPaidWholesale.AutoSize = true;
            lblPaidWholesale.Location = new Point(26, 8);
            lblPaidWholesale.Margin = new Padding(0, 8, 5, 0);
            lblPaidWholesale.Name = "lblPaidWholesale";
            lblPaidWholesale.Size = new Size(49, 15);
            lblPaidWholesale.TabIndex = 3;
            lblPaidWholesale.Text = "المدفوع:";
            // 
            // _txPaidWholesaleWrap
            // 
            _txPaidWholesaleWrap.BackColor = Color.White;
            _txPaidWholesaleWrap.Controls.Add(_txPaidWholesale);
            _txPaidWholesaleWrap.Location = new Point(113, 26);
            _txPaidWholesaleWrap.Name = "_txPaidWholesaleWrap";
            _txPaidWholesaleWrap.Padding = new Padding(8, 4, 8, 4);
            _txPaidWholesaleWrap.Size = new Size(100, 30);
            _txPaidWholesaleWrap.TabIndex = 4;
            // 
            // _txPaidWholesale
            // 
            _txPaidWholesale.BorderStyle = BorderStyle.None;
            _txPaidWholesale.Dock = DockStyle.Fill;
            _txPaidWholesale.Location = new Point(8, 4);
            _txPaidWholesale.Name = "_txPaidWholesale";
            _txPaidWholesale.Size = new Size(84, 16);
            _txPaidWholesale.TabIndex = 0;
            _txPaidWholesale.Text = "0";
            // 
            // lblWholesaleClient
            // 
            lblWholesaleClient.AutoSize = true;
            lblWholesaleClient.Dock = DockStyle.Left;
            lblWholesaleClient.Location = new Point(149, 0);
            lblWholesaleClient.Margin = new Padding(0, 0, 0, 6);
            lblWholesaleClient.Name = "lblWholesaleClient";
            lblWholesaleClient.RightToLeft = RightToLeft.Yes;
            lblWholesaleClient.Size = new Size(67, 15);
            lblWholesaleClient.TabIndex = 0;
            lblWholesaleClient.Text = "عميل الجملة";
            lblWholesaleClient.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _calWholesale
            // 
            _calWholesale.Location = new Point(9, 74);
            _calWholesale.Margin = new Padding(8, 7, 8, 7);
            _calWholesale.MaxSelectionCount = 1;
            _calWholesale.Name = "_calWholesale";
            _calWholesale.TabIndex = 4;
            _calWholesale.Visible = false;
            // 
            // _retailPanel
            // 
            _retailPanel.AutoSize = true;
            _retailPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _retailPanel.BackColor = Color.FromArgb(247, 246, 242);
            _retailPanel.Controls.Add(retailTable);
            _retailPanel.Controls.Add(_calRetail);
            _retailPanel.Dock = DockStyle.Top;
            _retailPanel.Location = new Point(0, 42);
            _retailPanel.Margin = new Padding(3, 2, 3, 2);
            _retailPanel.Name = "_retailPanel";
            _retailPanel.Padding = new Padding(13, 11, 13, 11);
            _retailPanel.RightToLeft = RightToLeft.Yes;
            _retailPanel.Size = new Size(242, 254);
            _retailPanel.TabIndex = 3;
            // 
            // retailTable
            // 
            retailTable.AutoSize = true;
            retailTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            retailTable.ColumnCount = 1;
            retailTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            retailTable.Controls.Add(lblCustomerName, 0, 0);
            retailTable.Controls.Add(_txCustomerWrap, 0, 1);
            retailTable.Controls.Add(_txCustomerExtraWrap, 0, 2);
            retailTable.Controls.Add(retailDateFlow, 0, 3);
            retailTable.Dock = DockStyle.Fill;
            retailTable.Location = new Point(13, 11);
            retailTable.Margin = new Padding(0);
            retailTable.Name = "retailTable";
            retailTable.RightToLeft = RightToLeft.Yes;
            retailTable.RowCount = 4;
            retailTable.RowStyles.Add(new RowStyle());
            retailTable.RowStyles.Add(new RowStyle());
            retailTable.RowStyles.Add(new RowStyle());
            retailTable.RowStyles.Add(new RowStyle());
            retailTable.Size = new Size(216, 232);
            retailTable.TabIndex = 0;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Dock = DockStyle.Left;
            lblCustomerName.Location = new Point(144, 0);
            lblCustomerName.Margin = new Padding(0, 0, 0, 6);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.RightToLeft = RightToLeft.No;
            lblCustomerName.Size = new Size(72, 15);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "بيانات العميل";
            // 
            // _txCustomerWrap
            // 
            _txCustomerWrap.BackColor = Color.White;
            _txCustomerWrap.Controls.Add(_txCustomer);
            _txCustomerWrap.Cursor = Cursors.IBeam;
            _txCustomerWrap.Dock = DockStyle.Fill;
            _txCustomerWrap.Location = new Point(0, 21);
            _txCustomerWrap.Margin = new Padding(0, 0, 0, 6);
            _txCustomerWrap.Name = "_txCustomerWrap";
            _txCustomerWrap.Padding = new Padding(7, 6, 7, 6);
            _txCustomerWrap.Size = new Size(216, 32);
            _txCustomerWrap.TabIndex = 1;
            // 
            // _txCustomer
            // 
            _txCustomer.BackColor = Color.White;
            _txCustomer.BorderStyle = BorderStyle.None;
            _txCustomer.Dock = DockStyle.Fill;
            _txCustomer.Location = new Point(7, 6);
            _txCustomer.Margin = new Padding(0);
            _txCustomer.Name = "_txCustomer";
            _txCustomer.PlaceholderText = "أدخل اسم العميل";
            _txCustomer.Size = new Size(202, 16);
            _txCustomer.TabIndex = 0;
            _txCustomer.TextChanged += _txCustomer_TextChanged;
            // 
            // _txCustomerExtraWrap
            // 
            _txCustomerExtraWrap.BackColor = Color.White;
            _txCustomerExtraWrap.Controls.Add(_txCustomerExtra);
            _txCustomerExtraWrap.Cursor = Cursors.IBeam;
            _txCustomerExtraWrap.Dock = DockStyle.Fill;
            _txCustomerExtraWrap.Location = new Point(0, 59);
            _txCustomerExtraWrap.Margin = new Padding(0, 0, 0, 9);
            _txCustomerExtraWrap.Name = "_txCustomerExtraWrap";
            _txCustomerExtraWrap.Padding = new Padding(7, 6, 7, 6);
            _txCustomerExtraWrap.Size = new Size(216, 32);
            _txCustomerExtraWrap.TabIndex = 2;
            // 
            // _txCustomerExtra
            // 
            _txCustomerExtra.BackColor = Color.White;
            _txCustomerExtra.BorderStyle = BorderStyle.None;
            _txCustomerExtra.Dock = DockStyle.Fill;
            _txCustomerExtra.Location = new Point(7, 6);
            _txCustomerExtra.Margin = new Padding(0);
            _txCustomerExtra.Name = "_txCustomerExtra";
            _txCustomerExtra.PlaceholderText = "رقم الهاتف (اختياري)";
            _txCustomerExtra.Size = new Size(202, 16);
            _txCustomerExtra.TabIndex = 0;
            // 
            // retailDateFlow
            // 
            retailDateFlow.AutoSize = true;
            retailDateFlow.Controls.Add(_chkIsDeliveryRetail);
            retailDateFlow.Controls.Add(_lblDeliveryRetail);
            retailDateFlow.Controls.Add(lblPaidRetail);
            retailDateFlow.Controls.Add(_txPaidRetailWrap);
            retailDateFlow.Dock = DockStyle.Fill;
            retailDateFlow.Location = new Point(0, 100);
            retailDateFlow.Margin = new Padding(0);
            retailDateFlow.Name = "retailDateFlow";
            retailDateFlow.RightToLeft = RightToLeft.Yes;
            retailDateFlow.Size = new Size(216, 132);
            retailDateFlow.TabIndex = 3;
            // 
            // _chkIsDeliveryRetail
            // 
            _chkIsDeliveryRetail.AutoSize = true;
            _chkIsDeliveryRetail.Location = new Point(128, 4);
            _chkIsDeliveryRetail.Margin = new Padding(0, 4, 9, 0);
            _chkIsDeliveryRetail.Name = "_chkIsDeliveryRetail";
            _chkIsDeliveryRetail.Size = new Size(88, 19);
            _chkIsDeliveryRetail.TabIndex = 2;
            _chkIsDeliveryRetail.Text = "طلب توصيل";
            _chkIsDeliveryRetail.UseVisualStyleBackColor = true;
            // 
            // _lblDeliveryRetail
            // 
            _lblDeliveryRetail.AutoSize = true;
            _lblDeliveryRetail.Location = new Point(75, 4);
            _lblDeliveryRetail.Margin = new Padding(0, 4, 0, 0);
            _lblDeliveryRetail.Name = "_lblDeliveryRetail";
            _lblDeliveryRetail.Size = new Size(44, 15);
            _lblDeliveryRetail.TabIndex = 1;
            _lblDeliveryRetail.Text = "لم يحدد";
            // 
            // lblPaidRetail
            // 
            lblPaidRetail.AutoSize = true;
            lblPaidRetail.Location = new Point(26, 8);
            lblPaidRetail.Margin = new Padding(0, 8, 5, 0);
            lblPaidRetail.Name = "lblPaidRetail";
            lblPaidRetail.Size = new Size(49, 15);
            lblPaidRetail.TabIndex = 3;
            lblPaidRetail.Text = "المدفوع:";
            // 
            // _txPaidRetailWrap
            // 
            _txPaidRetailWrap.BackColor = Color.White;
            _txPaidRetailWrap.Controls.Add(_txPaidRetail);
            _txPaidRetailWrap.Location = new Point(113, 26);
            _txPaidRetailWrap.Name = "_txPaidRetailWrap";
            _txPaidRetailWrap.Padding = new Padding(8, 4, 8, 4);
            _txPaidRetailWrap.Size = new Size(100, 30);
            _txPaidRetailWrap.TabIndex = 4;
            // 
            // _txPaidRetail
            // 
            _txPaidRetail.BorderStyle = BorderStyle.None;
            _txPaidRetail.Dock = DockStyle.Fill;
            _txPaidRetail.Location = new Point(8, 4);
            _txPaidRetail.Name = "_txPaidRetail";
            _txPaidRetail.Size = new Size(84, 16);
            _txPaidRetail.TabIndex = 0;
            _txPaidRetail.Text = "0";
            // 
            // _calRetail
            // 
            _calRetail.Location = new Point(9, 74);
            _calRetail.Margin = new Padding(8, 7, 8, 7);
            _calRetail.MaxSelectionCount = 1;
            _calRetail.Name = "_calRetail";
            _calRetail.TabIndex = 5;
            _calRetail.Visible = false;
            // 
            // typeCard
            // 
            typeCard.BackColor = Color.White;
            typeCard.Controls.Add(lblOrderType);
            typeCard.Controls.Add(_rbRetail);
            typeCard.Controls.Add(_rbWholesale);
            typeCard.Dock = DockStyle.Top;
            typeCard.Location = new Point(0, 0);
            typeCard.Margin = new Padding(0, 0, 0, 4);
            typeCard.Name = "typeCard";
            typeCard.Padding = new Padding(9, 6, 9, 6);
            typeCard.RightToLeft = RightToLeft.Yes;
            typeCard.Size = new Size(242, 42);
            typeCard.TabIndex = 2;
            // 
            // lblOrderType
            // 
            lblOrderType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOrderType.AutoSize = true;
            lblOrderType.Location = new Point(165, 14);
            lblOrderType.Name = "lblOrderType";
            lblOrderType.Size = new Size(62, 15);
            lblOrderType.TabIndex = 0;
            lblOrderType.Text = "نوع الطلب:";
            // 
            // _rbRetail
            // 
            _rbRetail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _rbRetail.AutoSize = true;
            _rbRetail.Checked = true;
            _rbRetail.Cursor = Cursors.Hand;
            _rbRetail.Location = new Point(24, 12);
            _rbRetail.Margin = new Padding(3, 2, 3, 2);
            _rbRetail.Name = "_rbRetail";
            _rbRetail.RightToLeft = RightToLeft.Yes;
            _rbRetail.Size = new Size(61, 19);
            _rbRetail.TabIndex = 1;
            _rbRetail.TabStop = true;
            _rbRetail.Text = "قطاعي";
            _rbRetail.CheckedChanged += _rbType_CheckedChanged;
            // 
            // _rbWholesale
            // 
            _rbWholesale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _rbWholesale.AutoSize = true;
            _rbWholesale.Cursor = Cursors.Hand;
            _rbWholesale.Location = new Point(95, 12);
            _rbWholesale.Margin = new Padding(3, 2, 3, 2);
            _rbWholesale.Name = "_rbWholesale";
            _rbWholesale.RightToLeft = RightToLeft.Yes;
            _rbWholesale.Size = new Size(49, 19);
            _rbWholesale.TabIndex = 2;
            _rbWholesale.Text = "جملة";
            _rbWholesale.CheckedChanged += _rbType_CheckedChanged;
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(_linesGrid);
            leftPanel.Controls.Add(btnActFlow);
            leftPanel.Controls.Add(lblCartTitle);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(426, 14);
            leftPanel.Margin = new Padding(3, 2, 3, 2);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(9, 0, 9, 0);
            leftPanel.Size = new Size(354, 527);
            leftPanel.TabIndex = 1;
            // 
            // _linesGrid
            // 
            _linesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _linesGrid.Dock = DockStyle.Fill;
            _linesGrid.Location = new Point(9, 22);
            _linesGrid.Margin = new Padding(3, 2, 3, 2);
            _linesGrid.Name = "_linesGrid";
            _linesGrid.RowHeadersWidth = 51;
            _linesGrid.Size = new Size(336, 466);
            _linesGrid.TabIndex = 0;
            // 
            // btnActFlow
            // 
            btnActFlow.BackColor = Color.FromArgb(247, 246, 242);
            btnActFlow.Dock = DockStyle.Bottom;
            btnActFlow.Location = new Point(9, 488);
            btnActFlow.Margin = new Padding(3, 2, 3, 2);
            btnActFlow.Name = "btnActFlow";
            btnActFlow.Padding = new Padding(0, 6, 0, 0);
            btnActFlow.Size = new Size(336, 39);
            btnActFlow.TabIndex = 6;
            // 
            // lblCartTitle
            // 
            lblCartTitle.Dock = DockStyle.Top;
            lblCartTitle.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            lblCartTitle.ForeColor = Color.FromArgb(31, 45, 47);
            lblCartTitle.Location = new Point(9, 0);
            lblCartTitle.Name = "lblCartTitle";
            lblCartTitle.Padding = new Padding(4, 0, 0, 0);
            lblCartTitle.Size = new Size(336, 22);
            lblCartTitle.TabIndex = 1;
            lblCartTitle.Text = "\U0001f6d2  سلة الطلب";
            lblCartTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(_catalogFlow);
            rightPanel.Controls.Add(catalogSearch);
            rightPanel.Controls.Add(lblCatalogTitle);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(13, 14);
            rightPanel.Margin = new Padding(3, 2, 3, 2);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(9, 0, 0, 0);
            rightPanel.Size = new Size(407, 527);
            rightPanel.TabIndex = 0;
            // 
            // _catalogFlow
            // 
            _catalogFlow.AutoScroll = true;
            _catalogFlow.BackColor = Color.FromArgb(247, 246, 242);
            _catalogFlow.Dock = DockStyle.Fill;
            _catalogFlow.Location = new Point(9, 44);
            _catalogFlow.Margin = new Padding(3, 2, 3, 2);
            _catalogFlow.Name = "_catalogFlow";
            _catalogFlow.Padding = new Padding(4, 3, 4, 3);
            _catalogFlow.Size = new Size(398, 483);
            _catalogFlow.TabIndex = 0;
            // 
            // catalogSearch
            // 
            catalogSearch.BorderStyle = BorderStyle.FixedSingle;
            catalogSearch.Dock = DockStyle.Top;
            catalogSearch.Font = new Font("Microsoft Sans Serif", 9.5F);
            catalogSearch.Location = new Point(9, 22);
            catalogSearch.Margin = new Padding(0, 0, 0, 4);
            catalogSearch.Name = "catalogSearch";
            catalogSearch.PlaceholderText = "🔍  ابحث عن منتج...";
            catalogSearch.Size = new Size(398, 22);
            catalogSearch.TabIndex = 1;
            catalogSearch.TextChanged += CatalogSearch_TextChanged;
            // 
            // lblCatalogTitle
            // 
            lblCatalogTitle.Dock = DockStyle.Top;
            lblCatalogTitle.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            lblCatalogTitle.ForeColor = Color.FromArgb(31, 45, 47);
            lblCatalogTitle.Location = new Point(9, 0);
            lblCatalogTitle.Name = "lblCatalogTitle";
            lblCatalogTitle.Padding = new Padding(4, 0, 0, 0);
            lblCatalogTitle.Size = new Size(398, 22);
            lblCatalogTitle.TabIndex = 2;
            lblCatalogTitle.Text = "🏪  المنتجات";
            lblCatalogTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderEntryControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 246, 242);
            Controls.Add(bodyTable);
            Controls.Add(headerPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "OrderEntryControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1050, 615);
            headerPanel.ResumeLayout(false);
            bodyTable.ResumeLayout(false);
            infoPanel.ResumeLayout(false);
            infoPanel.PerformLayout();
            sumCard.ResumeLayout(false);
            sumCard.PerformLayout();
            _balanceRow.ResumeLayout(false);
            _balanceRow.PerformLayout();
            _wholesalePanel.ResumeLayout(false);
            _wholesalePanel.PerformLayout();
            wholesaleTable.ResumeLayout(false);
            wholesaleTable.PerformLayout();
            wholesaleDateFlow.ResumeLayout(false);
            wholesaleDateFlow.PerformLayout();
            _txPaidWholesaleWrap.ResumeLayout(false);
            _txPaidWholesaleWrap.PerformLayout();
            _retailPanel.ResumeLayout(false);
            _retailPanel.PerformLayout();
            retailTable.ResumeLayout(false);
            retailTable.PerformLayout();
            _txCustomerWrap.ResumeLayout(false);
            _txCustomerWrap.PerformLayout();
            _txCustomerExtraWrap.ResumeLayout(false);
            _txCustomerExtraWrap.PerformLayout();
            retailDateFlow.ResumeLayout(false);
            retailDateFlow.PerformLayout();
            _txPaidRetailWrap.ResumeLayout(false);
            _txPaidRetailWrap.PerformLayout();
            typeCard.ResumeLayout(false);
            typeCard.PerformLayout();
            leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_linesGrid).EndInit();
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        // ── Field declarations ────────────────────────────────────────────────
        private System.Windows.Forms.Panel       headerPanel;
        private System.Windows.Forms.Label       h1Label;
        private System.Windows.Forms.Panel       sepBar;
        private System.Windows.Forms.TableLayoutPanel bodyTable;

        // Layout Panels
        private System.Windows.Forms.Panel       rightPanel;
        private System.Windows.Forms.Panel       leftPanel;
        private System.Windows.Forms.Panel       infoPanel;
        private System.Windows.Forms.Panel       typeCard;
        private System.Windows.Forms.Label       lblOrderType;
        private System.Windows.Forms.RadioButton _rbRetail;
        private System.Windows.Forms.RadioButton _rbWholesale;

        private System.Windows.Forms.Panel       _retailPanel;
        private System.Windows.Forms.TableLayoutPanel retailTable;
        private System.Windows.Forms.Label       lblCustomerName;
        private System.Windows.Forms.Panel       _txCustomerWrap;
        private System.Windows.Forms.TextBox     _txCustomer;
        private System.Windows.Forms.Panel       _txCustomerExtraWrap;
        private System.Windows.Forms.TextBox     _txCustomerExtra;
        private System.Windows.Forms.FlowLayoutPanel retailDateFlow;
        private sweetSystem.FlatButton           _btnDeliveryRetail;
        private System.Windows.Forms.Label       _lblDeliveryRetail;
        private System.Windows.Forms.CheckBox     _chkIsDeliveryRetail;
        private System.Windows.Forms.TextBox      _txPaidRetail;
        private System.Windows.Forms.Panel        _txPaidRetailWrap;
        private System.Windows.Forms.Label        lblPaidRetail;
        private System.Windows.Forms.MonthCalendar _calRetail;

        private System.Windows.Forms.Panel       _wholesalePanel;
        private System.Windows.Forms.TableLayoutPanel wholesaleTable;
        private System.Windows.Forms.Label       lblWholesaleClient;
        private System.Windows.Forms.ComboBox    _cbClient;
        private System.Windows.Forms.FlowLayoutPanel wholesaleDateFlow;
        private sweetSystem.FlatButton           _btnDeliveryWholesale;
        private System.Windows.Forms.Label       _lblDeliveryWholesale;
        private System.Windows.Forms.CheckBox     _chkIsDeliveryWholesale;
        private System.Windows.Forms.TextBox      _txPaidWholesale;
        private System.Windows.Forms.Panel        _txPaidWholesaleWrap;
        private System.Windows.Forms.Label        lblPaidWholesale;
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
        private System.Windows.Forms.Label           lblCatalogTitle;
        private System.Windows.Forms.TextBox         catalogSearch;
        private System.Windows.Forms.FlowLayoutPanel _catalogFlow;
    }
}
