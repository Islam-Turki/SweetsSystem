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
            _btnDeliveryWholesale = new FlatButton();
            _lblDeliveryWholesale = new Label();
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
            _btnDeliveryRetail = new FlatButton();
            _lblDeliveryRetail = new Label();
            _calRetail = new MonthCalendar();
            typeCard = new Panel();
            lblOrderType = new Label();
            _rbRetail = new RadioButton();
            _rbWholesale = new RadioButton();
            leftPanel = new Panel();
            _linesGrid = new DataGridView();
            btnActFlow = new FlowLayoutPanel();
            _btnSave = new FlatButton();
            _btnClear = new FlatButton();
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
            _retailPanel.SuspendLayout();
            retailTable.SuspendLayout();
            _txCustomerWrap.SuspendLayout();
            _txCustomerExtraWrap.SuspendLayout();
            retailDateFlow.SuspendLayout();
            typeCard.SuspendLayout();
            leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_linesGrid).BeginInit();
            btnActFlow.SuspendLayout();
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
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1200, 84);
            headerPanel.TabIndex = 1;
            // 
            // h1Label
            // 
            h1Label.Dock = DockStyle.Fill;
            h1Label.Font = new Font("Cairo", 16F, FontStyle.Bold);
            h1Label.ForeColor = Color.FromArgb(36, 36, 36);
            h1Label.Location = new Point(0, 0);
            h1Label.Name = "h1Label";
            h1Label.Padding = new Padding(0, 0, 16, 0);
            h1Label.Size = new Size(1200, 81);
            h1Label.TabIndex = 0;
            h1Label.Text = "\U0001f6d2  إدخال طلب جديد";
            h1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sepBar
            // 
            sepBar.BackColor = Color.FromArgb(53, 133, 142);
            sepBar.Dock = DockStyle.Bottom;
            sepBar.Location = new Point(0, 81);
            sepBar.Name = "sepBar";
            sepBar.Size = new Size(1200, 3);
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
            bodyTable.Location = new Point(0, 84);
            bodyTable.Name = "bodyTable";
            bodyTable.Padding = new Padding(12, 16, 12, 12);
            bodyTable.RowCount = 1;
            bodyTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bodyTable.Size = new Size(1200, 736);
            bodyTable.TabIndex = 0;
            // 
            // infoPanel
            // 
            infoPanel.Controls.Add(sumCard);
            infoPanel.Controls.Add(_wholesalePanel);
            infoPanel.Controls.Add(_retailPanel);
            infoPanel.Controls.Add(typeCard);
            infoPanel.Dock = DockStyle.Fill;
            infoPanel.Location = new Point(897, 19);
            infoPanel.Name = "infoPanel";
            infoPanel.Padding = new Padding(0, 0, 10, 0);
            infoPanel.Size = new Size(288, 702);
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
            sumCard.Location = new Point(0, 510);
            sumCard.Name = "sumCard";
            sumCard.Padding = new Padding(12, 8, 12, 8);
            sumCard.Size = new Size(278, 192);
            sumCard.TabIndex = 5;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Cairo", 11F, FontStyle.Bold);
            lblSummary.Location = new Point(12, 8);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(125, 36);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "ملخص الطلب";
            // 
            // sepBar1
            // 
            sepBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sepBar1.BackColor = Color.FromArgb(220, 220, 220);
            sepBar1.Location = new Point(12, 36);
            sepBar1.Name = "sepBar1";
            sepBar1.Size = new Size(278, 1);
            sepBar1.TabIndex = 1;
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Location = new Point(12, 46);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(113, 20);
            lblSubTitle.TabIndex = 2;
            lblSubTitle.Text = "المجموع الفرعي:";
            // 
            // _lblSub
            // 
            _lblSub.AutoSize = true;
            _lblSub.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _lblSub.Location = new Point(200, 46);
            _lblSub.Name = "_lblSub";
            _lblSub.Size = new Size(66, 29);
            _lblSub.TabIndex = 3;
            _lblSub.Text = "0.00 د.ل";
            // 
            // _balanceRow
            // 
            _balanceRow.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _balanceRow.BackColor = Color.Transparent;
            _balanceRow.Controls.Add(lblBalanceTitle);
            _balanceRow.Controls.Add(_lblBalance);
            _balanceRow.Location = new Point(12, 74);
            _balanceRow.Name = "_balanceRow";
            _balanceRow.Size = new Size(278, 28);
            _balanceRow.TabIndex = 4;
            _balanceRow.Visible = false;
            // 
            // lblBalanceTitle
            // 
            lblBalanceTitle.AutoSize = true;
            lblBalanceTitle.ForeColor = Color.FromArgb(210, 70, 70);
            lblBalanceTitle.Location = new Point(0, 4);
            lblBalanceTitle.Name = "lblBalanceTitle";
            lblBalanceTitle.Size = new Size(100, 20);
            lblBalanceTitle.TabIndex = 0;
            lblBalanceTitle.Text = "الرصيد السابق:";
            // 
            // _lblBalance
            // 
            _lblBalance.AutoSize = true;
            _lblBalance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _lblBalance.ForeColor = Color.FromArgb(210, 70, 70);
            _lblBalance.Location = new Point(188, 4);
            _lblBalance.Name = "_lblBalance";
            _lblBalance.Size = new Size(66, 29);
            _lblBalance.TabIndex = 1;
            _lblBalance.Text = "0.00 د.ل";
            // 
            // sepBar2
            // 
            sepBar2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sepBar2.BackColor = Color.FromArgb(220, 220, 220);
            sepBar2.Location = new Point(12, 110);
            sepBar2.Name = "sepBar2";
            sepBar2.Size = new Size(278, 1);
            sepBar2.TabIndex = 5;
            // 
            // lblGrandTitle
            // 
            lblGrandTitle.AutoSize = true;
            lblGrandTitle.Font = new Font("Cairo", 10F, FontStyle.Bold);
            lblGrandTitle.ForeColor = Color.FromArgb(30, 120, 80);
            lblGrandTitle.Location = new Point(12, 120);
            lblGrandTitle.Name = "lblGrandTitle";
            lblGrandTitle.Size = new Size(133, 32);
            lblGrandTitle.TabIndex = 6;
            lblGrandTitle.Text = "الإجمالي الكلي:";
            // 
            // _lblGrand
            // 
            _lblGrand.AutoSize = true;
            _lblGrand.Font = new Font("Cairo", 13F, FontStyle.Bold);
            _lblGrand.ForeColor = Color.FromArgb(30, 120, 80);
            _lblGrand.Location = new Point(180, 116);
            _lblGrand.Name = "_lblGrand";
            _lblGrand.Size = new Size(98, 42);
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
            _wholesalePanel.Location = new Point(0, 385);
            _wholesalePanel.Name = "_wholesalePanel";
            _wholesalePanel.Padding = new Padding(15);
            _wholesalePanel.RightToLeft = RightToLeft.Yes;
            _wholesalePanel.Size = new Size(278, 329);
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
            wholesaleTable.Location = new Point(15, 15);
            wholesaleTable.Margin = new Padding(0);
            wholesaleTable.Name = "wholesaleTable";
            wholesaleTable.RightToLeft = RightToLeft.Yes;
            wholesaleTable.RowCount = 3;
            wholesaleTable.RowStyles.Add(new RowStyle());
            wholesaleTable.RowStyles.Add(new RowStyle());
            wholesaleTable.RowStyles.Add(new RowStyle());
            wholesaleTable.Size = new Size(248, 299);
            wholesaleTable.TabIndex = 0;
            // 
            // _cbClient
            // 
            _cbClient.Dock = DockStyle.Fill;
            _cbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbClient.FlatStyle = FlatStyle.Flat;
            _cbClient.Location = new Point(0, 28);
            _cbClient.Margin = new Padding(0, 0, 0, 12);
            _cbClient.Name = "_cbClient";
            _cbClient.Size = new Size(248, 28);
            _cbClient.TabIndex = 1;
            _cbClient.SelectedIndexChanged += _cbClient_SelectedIndexChanged;
            // 
            // wholesaleDateFlow
            // 
            wholesaleDateFlow.AutoSize = true;
            wholesaleDateFlow.Controls.Add(_btnDeliveryWholesale);
            wholesaleDateFlow.Controls.Add(_lblDeliveryWholesale);
            wholesaleDateFlow.Dock = DockStyle.Fill;
            wholesaleDateFlow.Location = new Point(0, 68);
            wholesaleDateFlow.Margin = new Padding(0);
            wholesaleDateFlow.Name = "wholesaleDateFlow";
            wholesaleDateFlow.RightToLeft = RightToLeft.Yes;
            wholesaleDateFlow.Size = new Size(248, 231);
            wholesaleDateFlow.TabIndex = 2;
            // 
            // _btnDeliveryWholesale
            // 
            _btnDeliveryWholesale.BackColor = Color.FromArgb(90, 150, 170);
            _btnDeliveryWholesale.FlatStyle = FlatStyle.Flat;
            _btnDeliveryWholesale.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            _btnDeliveryWholesale.ForeColor = Color.White;
            _btnDeliveryWholesale.Location = new Point(138, 0);
            _btnDeliveryWholesale.Margin = new Padding(0, 0, 10, 0);
            _btnDeliveryWholesale.Name = "_btnDeliveryWholesale";
            _btnDeliveryWholesale.Padding = new Padding(15);
            _btnDeliveryWholesale.Radius = 6;
            _btnDeliveryWholesale.Size = new Size(110, 35);
            _btnDeliveryWholesale.TabIndex = 0;
            _btnDeliveryWholesale.Text = "📅 التسليم";
            _btnDeliveryWholesale.UseVisualStyleBackColor = false;
            // 
            // _lblDeliveryWholesale
            // 
            _lblDeliveryWholesale.AutoSize = true;
            _lblDeliveryWholesale.Location = new Point(71, 5);
            _lblDeliveryWholesale.Margin = new Padding(0, 5, 0, 0);
            _lblDeliveryWholesale.Name = "_lblDeliveryWholesale";
            _lblDeliveryWholesale.Size = new Size(57, 20);
            _lblDeliveryWholesale.TabIndex = 1;
            _lblDeliveryWholesale.Text = "لم يحدد";
            // 
            // lblWholesaleClient
            // 
            lblWholesaleClient.AutoSize = true;
            lblWholesaleClient.Dock = DockStyle.Left;
            lblWholesaleClient.Location = new Point(162, 0);
            lblWholesaleClient.Margin = new Padding(0, 0, 0, 8);
            lblWholesaleClient.Name = "lblWholesaleClient";
            lblWholesaleClient.RightToLeft = RightToLeft.Yes;
            lblWholesaleClient.Size = new Size(86, 20);
            lblWholesaleClient.TabIndex = 0;
            lblWholesaleClient.Text = "عميل الجملة";
            lblWholesaleClient.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _calWholesale
            // 
            _calWholesale.Location = new Point(10, 98);
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
            _retailPanel.Location = new Point(0, 56);
            _retailPanel.Name = "_retailPanel";
            _retailPanel.Padding = new Padding(15);
            _retailPanel.RightToLeft = RightToLeft.Yes;
            _retailPanel.Size = new Size(278, 329);
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
            retailTable.Location = new Point(15, 15);
            retailTable.Margin = new Padding(0);
            retailTable.Name = "retailTable";
            retailTable.RightToLeft = RightToLeft.Yes;
            retailTable.RowCount = 4;
            retailTable.RowStyles.Add(new RowStyle());
            retailTable.RowStyles.Add(new RowStyle());
            retailTable.RowStyles.Add(new RowStyle());
            retailTable.RowStyles.Add(new RowStyle());
            retailTable.Size = new Size(248, 299);
            retailTable.TabIndex = 0;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Dock = DockStyle.Left;
            lblCustomerName.Location = new Point(156, 0);
            lblCustomerName.Margin = new Padding(0, 0, 0, 8);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.RightToLeft = RightToLeft.No;
            lblCustomerName.Size = new Size(92, 20);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "بيانات العميل";
            // 
            // _txCustomerWrap
            // 
            _txCustomerWrap.BackColor = Color.White;
            _txCustomerWrap.Controls.Add(_txCustomer);
            _txCustomerWrap.Cursor = Cursors.IBeam;
            _txCustomerWrap.Dock = DockStyle.Fill;
            _txCustomerWrap.Location = new Point(0, 28);
            _txCustomerWrap.Margin = new Padding(0, 0, 0, 8);
            _txCustomerWrap.Name = "_txCustomerWrap";
            _txCustomerWrap.Padding = new Padding(8);
            _txCustomerWrap.Size = new Size(248, 43);
            _txCustomerWrap.TabIndex = 1;
            // 
            // _txCustomer
            // 
            _txCustomer.BackColor = Color.White;
            _txCustomer.BorderStyle = BorderStyle.None;
            _txCustomer.Dock = DockStyle.Fill;
            _txCustomer.Location = new Point(8, 8);
            _txCustomer.Margin = new Padding(0);
            _txCustomer.Name = "_txCustomer";
            _txCustomer.PlaceholderText = "أدخل اسم العميل";
            _txCustomer.Size = new Size(232, 20);
            _txCustomer.TabIndex = 0;
            _txCustomer.TextChanged += _txCustomer_TextChanged;
            // 
            // _txCustomerExtraWrap
            // 
            _txCustomerExtraWrap.BackColor = Color.White;
            _txCustomerExtraWrap.Controls.Add(_txCustomerExtra);
            _txCustomerExtraWrap.Cursor = Cursors.IBeam;
            _txCustomerExtraWrap.Dock = DockStyle.Fill;
            _txCustomerExtraWrap.Location = new Point(0, 79);
            _txCustomerExtraWrap.Margin = new Padding(0, 0, 0, 12);
            _txCustomerExtraWrap.Name = "_txCustomerExtraWrap";
            _txCustomerExtraWrap.Padding = new Padding(8);
            _txCustomerExtraWrap.Size = new Size(248, 43);
            _txCustomerExtraWrap.TabIndex = 2;
            // 
            // _txCustomerExtra
            // 
            _txCustomerExtra.BackColor = Color.White;
            _txCustomerExtra.BorderStyle = BorderStyle.None;
            _txCustomerExtra.Dock = DockStyle.Fill;
            _txCustomerExtra.Location = new Point(8, 8);
            _txCustomerExtra.Margin = new Padding(0);
            _txCustomerExtra.Name = "_txCustomerExtra";
            _txCustomerExtra.PlaceholderText = "رقم الهاتف (اختياري)";
            _txCustomerExtra.Size = new Size(232, 20);
            _txCustomerExtra.TabIndex = 0;
            // 
            // retailDateFlow
            // 
            retailDateFlow.AutoSize = true;
            retailDateFlow.Controls.Add(_btnDeliveryRetail);
            retailDateFlow.Controls.Add(_lblDeliveryRetail);
            retailDateFlow.Dock = DockStyle.Fill;
            retailDateFlow.Location = new Point(0, 134);
            retailDateFlow.Margin = new Padding(0);
            retailDateFlow.Name = "retailDateFlow";
            retailDateFlow.RightToLeft = RightToLeft.Yes;
            retailDateFlow.Size = new Size(248, 165);
            retailDateFlow.TabIndex = 3;
            // 
            // _btnDeliveryRetail
            // 
            _btnDeliveryRetail.BackColor = Color.FromArgb(90, 150, 170);
            _btnDeliveryRetail.FlatStyle = FlatStyle.Flat;
            _btnDeliveryRetail.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            _btnDeliveryRetail.ForeColor = Color.White;
            _btnDeliveryRetail.Location = new Point(138, 0);
            _btnDeliveryRetail.Margin = new Padding(0, 0, 10, 0);
            _btnDeliveryRetail.Name = "_btnDeliveryRetail";
            _btnDeliveryRetail.Radius = 6;
            _btnDeliveryRetail.Size = new Size(110, 35);
            _btnDeliveryRetail.TabIndex = 0;
            _btnDeliveryRetail.Text = "📅 التسليم";
            _btnDeliveryRetail.UseVisualStyleBackColor = false;
            // 
            // _lblDeliveryRetail
            // 
            _lblDeliveryRetail.AutoSize = true;
            _lblDeliveryRetail.Location = new Point(71, 5);
            _lblDeliveryRetail.Margin = new Padding(0, 5, 0, 0);
            _lblDeliveryRetail.Name = "_lblDeliveryRetail";
            _lblDeliveryRetail.Size = new Size(57, 20);
            _lblDeliveryRetail.TabIndex = 1;
            _lblDeliveryRetail.Text = "لم يحدد";
            // 
            // _calRetail
            // 
            _calRetail.Location = new Point(10, 98);
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
            typeCard.Margin = new Padding(0, 0, 0, 6);
            typeCard.Name = "typeCard";
            typeCard.Padding = new Padding(10, 8, 10, 8);
            typeCard.RightToLeft = RightToLeft.Yes;
            typeCard.Size = new Size(278, 56);
            typeCard.TabIndex = 2;
            // 
            // lblOrderType
            // 
            lblOrderType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOrderType.AutoSize = true;
            lblOrderType.Location = new Point(189, 18);
            lblOrderType.Name = "lblOrderType";
            lblOrderType.Size = new Size(79, 20);
            lblOrderType.TabIndex = 0;
            lblOrderType.Text = "نوع الطلب:";
            // 
            // _rbRetail
            // 
            _rbRetail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _rbRetail.AutoSize = true;
            _rbRetail.Checked = true;
            _rbRetail.Cursor = Cursors.Hand;
            _rbRetail.Location = new Point(21, 16);
            _rbRetail.Name = "_rbRetail";
            _rbRetail.RightToLeft = RightToLeft.Yes;
            _rbRetail.Size = new Size(77, 24);
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
            _rbWholesale.Location = new Point(104, 16);
            _rbWholesale.Name = "_rbWholesale";
            _rbWholesale.RightToLeft = RightToLeft.Yes;
            _rbWholesale.Size = new Size(61, 24);
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
            leftPanel.Location = new Point(486, 19);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(10, 0, 10, 0);
            leftPanel.Size = new Size(405, 702);
            leftPanel.TabIndex = 1;
            // 
            // _linesGrid
            // 
            _linesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _linesGrid.Dock = DockStyle.Fill;
            _linesGrid.Location = new Point(10, 30);
            _linesGrid.Name = "_linesGrid";
            _linesGrid.RowHeadersWidth = 51;
            _linesGrid.Size = new Size(385, 620);
            _linesGrid.TabIndex = 0;
            // 
            // btnActFlow
            // 
            btnActFlow.BackColor = Color.FromArgb(247, 246, 242);
            btnActFlow.Controls.Add(_btnSave);
            btnActFlow.Controls.Add(_btnClear);
            btnActFlow.Dock = DockStyle.Bottom;
            btnActFlow.Location = new Point(10, 650);
            btnActFlow.Name = "btnActFlow";
            btnActFlow.Padding = new Padding(0, 8, 0, 0);
            btnActFlow.Size = new Size(385, 52);
            btnActFlow.TabIndex = 6;
            // 
            // _btnSave
            // 
            _btnSave.BackColor = Color.FromArgb(43, 150, 90);
            _btnSave.FlatStyle = FlatStyle.Flat;
            _btnSave.Font = new Font("Cairo", 9.5F, FontStyle.Bold);
            _btnSave.ForeColor = Color.White;
            _btnSave.Location = new Point(215, 8);
            _btnSave.Margin = new Padding(0, 0, 8, 0);
            _btnSave.Name = "_btnSave";
            _btnSave.Radius = 8;
            _btnSave.Size = new Size(170, 34);
            _btnSave.TabIndex = 0;
            _btnSave.Text = "✔  تأكيد الطلب";
            _btnSave.UseVisualStyleBackColor = false;
            _btnSave.Click += BtnSave_Click;
            // 
            // _btnClear
            // 
            _btnClear.BackColor = Color.FromArgb(150, 150, 150);
            _btnClear.FlatStyle = FlatStyle.Flat;
            _btnClear.Font = new Font("Cairo", 9.5F, FontStyle.Bold);
            _btnClear.ForeColor = Color.White;
            _btnClear.Location = new Point(104, 11);
            _btnClear.Name = "_btnClear";
            _btnClear.Radius = 8;
            _btnClear.Size = new Size(100, 34);
            _btnClear.TabIndex = 1;
            _btnClear.Text = "✕  مسح";
            _btnClear.UseVisualStyleBackColor = false;
            _btnClear.Click += BtnClear_Click;
            // 
            // lblCartTitle
            // 
            lblCartTitle.Dock = DockStyle.Top;
            lblCartTitle.Font = new Font("Cairo", 11F, FontStyle.Bold);
            lblCartTitle.ForeColor = Color.FromArgb(31, 45, 47);
            lblCartTitle.Location = new Point(10, 0);
            lblCartTitle.Name = "lblCartTitle";
            lblCartTitle.Padding = new Padding(4, 0, 0, 0);
            lblCartTitle.Size = new Size(385, 30);
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
            rightPanel.Location = new Point(15, 19);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(10, 0, 0, 0);
            rightPanel.Size = new Size(465, 702);
            rightPanel.TabIndex = 0;
            // 
            // _catalogFlow
            // 
            _catalogFlow.AutoScroll = true;
            _catalogFlow.BackColor = Color.FromArgb(247, 246, 242);
            _catalogFlow.Dock = DockStyle.Fill;
            _catalogFlow.Location = new Point(10, 67);
            _catalogFlow.Name = "_catalogFlow";
            _catalogFlow.Padding = new Padding(4);
            _catalogFlow.Size = new Size(455, 635);
            _catalogFlow.TabIndex = 0;
            // 
            // catalogSearch
            // 
            catalogSearch.BorderStyle = BorderStyle.FixedSingle;
            catalogSearch.Dock = DockStyle.Top;
            catalogSearch.Font = new Font("Cairo", 9.5F);
            catalogSearch.Location = new Point(10, 30);
            catalogSearch.Margin = new Padding(0, 0, 0, 6);
            catalogSearch.Name = "catalogSearch";
            catalogSearch.PlaceholderText = "🔍  ابحث عن منتج...";
            catalogSearch.Size = new Size(455, 37);
            catalogSearch.TabIndex = 1;
            catalogSearch.TextChanged += CatalogSearch_TextChanged;
            // 
            // lblCatalogTitle
            // 
            lblCatalogTitle.Dock = DockStyle.Top;
            lblCatalogTitle.Font = new Font("Cairo", 11F, FontStyle.Bold);
            lblCatalogTitle.ForeColor = Color.FromArgb(31, 45, 47);
            lblCatalogTitle.Location = new Point(10, 0);
            lblCatalogTitle.Name = "lblCatalogTitle";
            lblCatalogTitle.Padding = new Padding(4, 0, 0, 0);
            lblCatalogTitle.Size = new Size(455, 30);
            lblCatalogTitle.TabIndex = 2;
            lblCatalogTitle.Text = "🏪  المنتجات";
            lblCatalogTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderEntryControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 246, 242);
            Controls.Add(bodyTable);
            Controls.Add(headerPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "OrderEntryControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1200, 820);
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
            typeCard.ResumeLayout(false);
            typeCard.PerformLayout();
            leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_linesGrid).EndInit();
            btnActFlow.ResumeLayout(false);
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
        private System.Windows.Forms.MonthCalendar _calRetail;

        private System.Windows.Forms.Panel       _wholesalePanel;
        private System.Windows.Forms.TableLayoutPanel wholesaleTable;
        private System.Windows.Forms.Label       lblWholesaleClient;
        private System.Windows.Forms.ComboBox    _cbClient;
        private System.Windows.Forms.FlowLayoutPanel wholesaleDateFlow;
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
        private System.Windows.Forms.Label           lblCatalogTitle;
        private System.Windows.Forms.TextBox         catalogSearch;
        private System.Windows.Forms.FlowLayoutPanel _catalogFlow;
    }
}
