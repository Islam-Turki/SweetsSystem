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
            sumTable = new TableLayoutPanel();
            lblSubTitle = new Label();
            _lblSub = new Label();
            lblBalanceTitle = new Label();
            _lblBalance = new Label();
            lblGrandTitle = new Label();
            _lblGrand = new Label();
            _wholesalePanel = new Panel();
            wholesaleTable = new TableLayoutPanel();
            lblWholesaleClient = new Label();
            _cbClient = new ComboBox();
            lblPaidWholesale = new Label();
            _txPaidWholesaleWrap = new Panel();
            _txPaidWholesale = new TextBox();
            wholesaleDateFlow = new FlowLayoutPanel();
            _chkIsDeliveryWholesale = new CheckBox();
            _btnDeliveryWholesale = new FlatButton();
            _lblDeliveryWholesale = new Label();
            _calWholesale = new MonthCalendar();
            _retailPanel = new Panel();
            retailTable = new TableLayoutPanel();
            lblCustomerName = new Label();
            _txCustomerWrap = new Panel();
            _txCustomer = new TextBox();
            lblCustomerPhone = new Label();
            _txCustomerExtraWrap = new Panel();
            _txCustomerExtra = new TextBox();
            lblPaidRetail = new Label();
            _txPaidRetailWrap = new Panel();
            _txPaidRetail = new TextBox();
            retailDateFlow = new FlowLayoutPanel();
            _chkIsDeliveryRetail = new CheckBox();
            _btnDeliveryRetail = new FlatButton();
            _lblDeliveryRetail = new Label();
            _calRetail = new MonthCalendar();
            typeCard = new Panel();
            typeFlow = new FlowLayoutPanel();
            _rbRetail = new RadioButton();
            _rbWholesale = new RadioButton();
            lblOrderType = new Label();
            leftPanel = new Panel();
            _linesGrid = new DataGridView();
            _btnSelectProducts = new FlatButton();
            btnActFlow = new FlowLayoutPanel();
            lblCartTitle = new Label();
            headerPanel.SuspendLayout();
            bodyTable.SuspendLayout();
            infoPanel.SuspendLayout();
            sumCard.SuspendLayout();
            sumTable.SuspendLayout();
            _wholesalePanel.SuspendLayout();
            wholesaleTable.SuspendLayout();
            _txPaidWholesaleWrap.SuspendLayout();
            wholesaleDateFlow.SuspendLayout();
            _retailPanel.SuspendLayout();
            retailTable.SuspendLayout();
            _txCustomerWrap.SuspendLayout();
            _txCustomerExtraWrap.SuspendLayout();
            _txPaidRetailWrap.SuspendLayout();
            retailDateFlow.SuspendLayout();
            typeCard.SuspendLayout();
            typeFlow.SuspendLayout();
            leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_linesGrid).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(h1Label);
            headerPanel.Controls.Add(sepBar);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(4, 3, 4, 3);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1500, 105);
            headerPanel.TabIndex = 1;
            // 
            // h1Label
            // 
            h1Label.Dock = DockStyle.Fill;
            h1Label.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            h1Label.Location = new Point(0, 0);
            h1Label.Margin = new Padding(4, 0, 4, 0);
            h1Label.Name = "h1Label";
            h1Label.Padding = new Padding(0, 0, 20, 0);
            h1Label.Size = new Size(1500, 102);
            h1Label.TabIndex = 0;
            h1Label.Text = "\U0001f6d2  إدخال طلب جديد";
            h1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sepBar
            // 
            sepBar.Dock = DockStyle.Bottom;
            sepBar.Location = new Point(0, 102);
            sepBar.Margin = new Padding(4, 3, 4, 3);
            sepBar.Name = "sepBar";
            sepBar.Size = new Size(1500, 3);
            sepBar.TabIndex = 1;
            // 
            // bodyTable
            // 
            bodyTable.ColumnCount = 2;
            bodyTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            bodyTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            bodyTable.Controls.Add(infoPanel, 0, 0);
            bodyTable.Controls.Add(leftPanel, 1, 0);
            bodyTable.Dock = DockStyle.Fill;
            bodyTable.Location = new Point(0, 105);
            bodyTable.Margin = new Padding(4, 3, 4, 3);
            bodyTable.Name = "bodyTable";
            bodyTable.Padding = new Padding(14, 20, 14, 15);
            bodyTable.RowCount = 1;
            bodyTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bodyTable.Size = new Size(1500, 920);
            bodyTable.TabIndex = 0;
            // 
            // infoPanel
            // 
            infoPanel.Controls.Add(sumCard);
            infoPanel.Controls.Add(_wholesalePanel);
            infoPanel.Controls.Add(_retailPanel);
            infoPanel.Controls.Add(typeCard);
            infoPanel.Dock = DockStyle.Fill;
            infoPanel.Location = new Point(902, 23);
            infoPanel.Margin = new Padding(4, 3, 4, 3);
            infoPanel.Name = "infoPanel";
            infoPanel.Padding = new Padding(0, 0, 13, 0);
            infoPanel.Size = new Size(580, 879);
            infoPanel.TabIndex = 2;
            // 
            // sumCard
            // 
            sumCard.Controls.Add(lblSummary);
            sumCard.Controls.Add(sepBar1);
            sumCard.Controls.Add(sumTable);
            sumCard.Dock = DockStyle.Bottom;
            sumCard.Location = new Point(0, 639);
            sumCard.Name = "sumCard";
            sumCard.Padding = new Padding(14, 10, 14, 10);
            sumCard.Size = new Size(567, 240);
            sumCard.TabIndex = 5;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            lblSummary.Location = new Point(14, 10);
            lblSummary.Margin = new Padding(4, 0, 4, 0);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(122, 26);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "ملخص الطلب";
            // 
            // sepBar1
            // 
            sepBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sepBar1.Location = new Point(14, 45);
            sepBar1.Margin = new Padding(4, 3, 4, 3);
            sepBar1.Name = "sepBar1";
            sepBar1.Size = new Size(567, 2);
            sepBar1.TabIndex = 1;
            // 
            // sumTable
            // 
            sumTable.ColumnCount = 2;
            sumTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            sumTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            sumTable.Controls.Add(lblSubTitle, 0, 0);
            sumTable.Controls.Add(_lblSub, 1, 0);
            sumTable.Controls.Add(lblBalanceTitle, 0, 1);
            sumTable.Controls.Add(_lblBalance, 1, 1);
            sumTable.Controls.Add(lblGrandTitle, 0, 2);
            sumTable.Controls.Add(_lblGrand, 1, 2);
            sumTable.Dock = DockStyle.Bottom;
            sumTable.Location = new Point(14, 90);
            sumTable.Name = "sumTable";
            sumTable.RightToLeft = RightToLeft.Yes;
            sumTable.RowCount = 3;
            sumTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            sumTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            sumTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            sumTable.Size = new Size(539, 140);
            sumTable.TabIndex = 10;
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Dock = DockStyle.Fill;
            lblSubTitle.Location = new Point(272, 0);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(264, 40);
            lblSubTitle.TabIndex = 2;
            lblSubTitle.Text = "المجموع الفرعي:";
            lblSubTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _lblSub
            // 
            _lblSub.AutoSize = true;
            _lblSub.Dock = DockStyle.Fill;
            _lblSub.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblSub.Location = new Point(3, 0);
            _lblSub.Name = "_lblSub";
            _lblSub.Size = new Size(263, 40);
            _lblSub.TabIndex = 3;
            _lblSub.Text = "0.00 د.ل";
            _lblSub.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBalanceTitle
            // 
            lblBalanceTitle.AutoSize = true;
            lblBalanceTitle.Dock = DockStyle.Fill;
            lblBalanceTitle.Location = new Point(272, 40);
            lblBalanceTitle.Name = "lblBalanceTitle";
            lblBalanceTitle.Size = new Size(264, 40);
            lblBalanceTitle.TabIndex = 0;
            lblBalanceTitle.Text = "الرصيد السابق:";
            lblBalanceTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _lblBalance
            // 
            _lblBalance.AutoSize = true;
            _lblBalance.Dock = DockStyle.Fill;
            _lblBalance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblBalance.Location = new Point(3, 40);
            _lblBalance.Name = "_lblBalance";
            _lblBalance.Size = new Size(263, 40);
            _lblBalance.TabIndex = 1;
            _lblBalance.Text = "0.00 د.ل";
            _lblBalance.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGrandTitle
            // 
            lblGrandTitle.AutoSize = true;
            lblGrandTitle.Dock = DockStyle.Fill;
            lblGrandTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGrandTitle.Location = new Point(272, 80);
            lblGrandTitle.Name = "lblGrandTitle";
            lblGrandTitle.Size = new Size(264, 60);
            lblGrandTitle.TabIndex = 6;
            lblGrandTitle.Text = "الإجمالي الكلي:";
            lblGrandTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _lblGrand
            // 
            _lblGrand.AutoSize = true;
            _lblGrand.Dock = DockStyle.Fill;
            _lblGrand.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            _lblGrand.Location = new Point(3, 80);
            _lblGrand.Name = "_lblGrand";
            _lblGrand.Size = new Size(263, 60);
            _lblGrand.TabIndex = 7;
            _lblGrand.Text = "0.00 د.ل";
            _lblGrand.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _wholesalePanel
            // 
            _wholesalePanel.AutoSize = true;
            _wholesalePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _wholesalePanel.Controls.Add(wholesaleTable);
            _wholesalePanel.Controls.Add(_calWholesale);
            _wholesalePanel.Dock = DockStyle.Top;
            _wholesalePanel.Location = new Point(0, 473);
            _wholesalePanel.Name = "_wholesalePanel";
            _wholesalePanel.Padding = new Padding(19, 18, 19, 18);
            _wholesalePanel.RightToLeft = RightToLeft.Yes;
            _wholesalePanel.Size = new Size(567, 403);
            _wholesalePanel.TabIndex = 4;
            _wholesalePanel.Visible = false;
            // 
            // wholesaleTable
            // 
            wholesaleTable.AutoSize = true;
            wholesaleTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            wholesaleTable.ColumnCount = 2;
            wholesaleTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            wholesaleTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            wholesaleTable.Controls.Add(lblWholesaleClient, 0, 0);
            wholesaleTable.Controls.Add(_cbClient, 1, 0);
            wholesaleTable.Controls.Add(lblPaidWholesale, 0, 1);
            wholesaleTable.Controls.Add(_txPaidWholesaleWrap, 1, 1);
            wholesaleTable.Controls.Add(wholesaleDateFlow, 0, 2);
            wholesaleTable.Dock = DockStyle.Fill;
            wholesaleTable.Location = new Point(19, 18);
            wholesaleTable.Name = "wholesaleTable";
            wholesaleTable.RightToLeft = RightToLeft.Yes;
            wholesaleTable.RowCount = 3;
            wholesaleTable.RowStyles.Add(new RowStyle());
            wholesaleTable.RowStyles.Add(new RowStyle());
            wholesaleTable.RowStyles.Add(new RowStyle());
            wholesaleTable.Size = new Size(529, 367);
            wholesaleTable.TabIndex = 0;
            // 
            // lblWholesaleClient
            // 
            lblWholesaleClient.AutoSize = true;
            lblWholesaleClient.Dock = DockStyle.Fill;
            lblWholesaleClient.Location = new Point(347, 0);
            lblWholesaleClient.Name = "lblWholesaleClient";
            lblWholesaleClient.Size = new Size(179, 39);
            lblWholesaleClient.TabIndex = 0;
            lblWholesaleClient.Text = "عميل الجملة:";
            lblWholesaleClient.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _cbClient
            // 
            _cbClient.Dock = DockStyle.Fill;
            _cbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbClient.FlatStyle = FlatStyle.Flat;
            _cbClient.Location = new Point(3, 3);
            _cbClient.Name = "_cbClient";
            _cbClient.Size = new Size(338, 33);
            _cbClient.TabIndex = 1;
            _cbClient.SelectedIndexChanged += _cbClient_SelectedIndexChanged;
            // 
            // lblPaidWholesale
            // 
            lblPaidWholesale.AutoSize = true;
            lblPaidWholesale.Dock = DockStyle.Fill;
            lblPaidWholesale.Location = new Point(347, 39);
            lblPaidWholesale.Name = "lblPaidWholesale";
            lblPaidWholesale.Size = new Size(179, 56);
            lblPaidWholesale.TabIndex = 2;
            lblPaidWholesale.Text = "المدفوع:";
            lblPaidWholesale.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _txPaidWholesaleWrap
            // 
            _txPaidWholesaleWrap.Controls.Add(_txPaidWholesale);
            _txPaidWholesaleWrap.Dock = DockStyle.Fill;
            _txPaidWholesaleWrap.Location = new Point(3, 42);
            _txPaidWholesaleWrap.Name = "_txPaidWholesaleWrap";
            _txPaidWholesaleWrap.Padding = new Padding(11, 7, 11, 7);
            _txPaidWholesaleWrap.Size = new Size(338, 50);
            _txPaidWholesaleWrap.TabIndex = 3;
            // 
            // _txPaidWholesale
            // 
            _txPaidWholesale.BorderStyle = BorderStyle.None;
            _txPaidWholesale.Dock = DockStyle.Fill;
            _txPaidWholesale.Location = new Point(11, 7);
            _txPaidWholesale.Name = "_txPaidWholesale";
            _txPaidWholesale.Size = new Size(316, 24);
            _txPaidWholesale.TabIndex = 0;
            _txPaidWholesale.Text = "0";
            // 
            // wholesaleDateFlow
            // 
            wholesaleDateFlow.AutoSize = true;
            wholesaleTable.SetColumnSpan(wholesaleDateFlow, 2);
            wholesaleDateFlow.Controls.Add(_chkIsDeliveryWholesale);
            wholesaleDateFlow.Controls.Add(_btnDeliveryWholesale);
            wholesaleDateFlow.Controls.Add(_lblDeliveryWholesale);
            wholesaleDateFlow.Dock = DockStyle.Fill;
            wholesaleDateFlow.FlowDirection = FlowDirection.RightToLeft;
            wholesaleDateFlow.Location = new Point(3, 98);
            wholesaleDateFlow.Name = "wholesaleDateFlow";
            wholesaleDateFlow.RightToLeft = RightToLeft.Yes;
            wholesaleDateFlow.Size = new Size(523, 266);
            wholesaleDateFlow.TabIndex = 4;
            // 
            // _chkIsDeliveryWholesale
            // 
            _chkIsDeliveryWholesale.AutoSize = true;
            _chkIsDeliveryWholesale.Location = new Point(13, 10);
            _chkIsDeliveryWholesale.Margin = new Padding(0, 10, 13, 0);
            _chkIsDeliveryWholesale.Name = "_chkIsDeliveryWholesale";
            _chkIsDeliveryWholesale.Size = new Size(132, 29);
            _chkIsDeliveryWholesale.TabIndex = 0;
            _chkIsDeliveryWholesale.Text = "طلب توصيل";
            _chkIsDeliveryWholesale.UseVisualStyleBackColor = true;
            // 
            // _btnDeliveryWholesale
            // 
            _btnDeliveryWholesale.BackColor = Color.FromArgb(147, 197, 114);
            _btnDeliveryWholesale.Cursor = Cursors.Hand;
            _btnDeliveryWholesale.FlatAppearance.BorderSize = 0;
            _btnDeliveryWholesale.FlatStyle = FlatStyle.Flat;
            _btnDeliveryWholesale.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _btnDeliveryWholesale.ForeColor = Color.White;
            _btnDeliveryWholesale.Location = new Point(145, 0);
            _btnDeliveryWholesale.Margin = new Padding(10, 0, 0, 0);
            _btnDeliveryWholesale.Name = "_btnDeliveryWholesale";
            _btnDeliveryWholesale.Radius = 6;
            _btnDeliveryWholesale.Size = new Size(104, 50);
            _btnDeliveryWholesale.TabIndex = 1;
            _btnDeliveryWholesale.Text = "التاريخ";
            _btnDeliveryWholesale.UseVisualStyleBackColor = false;
            // 
            // _lblDeliveryWholesale
            // 
            _lblDeliveryWholesale.AutoSize = true;
            _lblDeliveryWholesale.Location = new Point(259, 12);
            _lblDeliveryWholesale.Margin = new Padding(10, 12, 0, 0);
            _lblDeliveryWholesale.Name = "_lblDeliveryWholesale";
            _lblDeliveryWholesale.Size = new Size(69, 25);
            _lblDeliveryWholesale.TabIndex = 2;
            _lblDeliveryWholesale.Text = "لم يحدد";
            // 
            // _calWholesale
            // 
            _calWholesale.Location = new Point(13, 123);
            _calWholesale.Name = "_calWholesale";
            _calWholesale.TabIndex = 4;
            _calWholesale.Visible = false;
            // 
            // _retailPanel
            // 
            _retailPanel.AutoSize = true;
            _retailPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _retailPanel.Controls.Add(retailTable);
            _retailPanel.Controls.Add(_calRetail);
            _retailPanel.Dock = DockStyle.Top;
            _retailPanel.Location = new Point(0, 70);
            _retailPanel.Name = "_retailPanel";
            _retailPanel.Padding = new Padding(19, 18, 19, 18);
            _retailPanel.RightToLeft = RightToLeft.Yes;
            _retailPanel.Size = new Size(567, 403);
            _retailPanel.TabIndex = 3;
            // 
            // retailTable
            // 
            retailTable.AutoSize = true;
            retailTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            retailTable.ColumnCount = 2;
            retailTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            retailTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            retailTable.Controls.Add(lblCustomerName, 0, 0);
            retailTable.Controls.Add(_txCustomerWrap, 1, 0);
            retailTable.Controls.Add(lblCustomerPhone, 0, 1);
            retailTable.Controls.Add(_txCustomerExtraWrap, 1, 1);
            retailTable.Controls.Add(lblPaidRetail, 0, 2);
            retailTable.Controls.Add(_txPaidRetailWrap, 1, 2);
            retailTable.Controls.Add(retailDateFlow, 0, 3);
            retailTable.Dock = DockStyle.Fill;
            retailTable.Location = new Point(19, 18);
            retailTable.Name = "retailTable";
            retailTable.RightToLeft = RightToLeft.Yes;
            retailTable.RowCount = 4;
            retailTable.RowStyles.Add(new RowStyle());
            retailTable.RowStyles.Add(new RowStyle());
            retailTable.RowStyles.Add(new RowStyle());
            retailTable.RowStyles.Add(new RowStyle());
            retailTable.Size = new Size(529, 367);
            retailTable.TabIndex = 0;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Dock = DockStyle.Fill;
            lblCustomerName.Location = new Point(347, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(179, 53);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "اسم العميل:";
            lblCustomerName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _txCustomerWrap
            // 
            _txCustomerWrap.Controls.Add(_txCustomer);
            _txCustomerWrap.Cursor = Cursors.IBeam;
            _txCustomerWrap.Dock = DockStyle.Fill;
            _txCustomerWrap.Location = new Point(3, 3);
            _txCustomerWrap.Name = "_txCustomerWrap";
            _txCustomerWrap.Padding = new Padding(10);
            _txCustomerWrap.Size = new Size(338, 47);
            _txCustomerWrap.TabIndex = 1;
            // 
            // _txCustomer
            // 
            _txCustomer.BorderStyle = BorderStyle.None;
            _txCustomer.Dock = DockStyle.Fill;
            _txCustomer.Location = new Point(10, 10);
            _txCustomer.Name = "_txCustomer";
            _txCustomer.PlaceholderText = "أدخل اسم العميل";
            _txCustomer.Size = new Size(318, 24);
            _txCustomer.TabIndex = 0;
            _txCustomer.TextChanged += _txCustomer_TextChanged;
            // 
            // lblCustomerPhone
            // 
            lblCustomerPhone.AutoSize = true;
            lblCustomerPhone.Dock = DockStyle.Fill;
            lblCustomerPhone.Location = new Point(347, 53);
            lblCustomerPhone.Name = "lblCustomerPhone";
            lblCustomerPhone.Size = new Size(179, 53);
            lblCustomerPhone.TabIndex = 2;
            lblCustomerPhone.Text = "رقم الهاتف:";
            lblCustomerPhone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _txCustomerExtraWrap
            // 
            _txCustomerExtraWrap.Controls.Add(_txCustomerExtra);
            _txCustomerExtraWrap.Cursor = Cursors.IBeam;
            _txCustomerExtraWrap.Dock = DockStyle.Fill;
            _txCustomerExtraWrap.Location = new Point(3, 56);
            _txCustomerExtraWrap.Name = "_txCustomerExtraWrap";
            _txCustomerExtraWrap.Padding = new Padding(10);
            _txCustomerExtraWrap.Size = new Size(338, 47);
            _txCustomerExtraWrap.TabIndex = 3;
            // 
            // _txCustomerExtra
            // 
            _txCustomerExtra.BorderStyle = BorderStyle.None;
            _txCustomerExtra.Dock = DockStyle.Fill;
            _txCustomerExtra.Location = new Point(10, 10);
            _txCustomerExtra.Name = "_txCustomerExtra";
            _txCustomerExtra.PlaceholderText = "رقم الهاتف (اختياري)";
            _txCustomerExtra.Size = new Size(318, 24);
            _txCustomerExtra.TabIndex = 0;
            // 
            // lblPaidRetail
            // 
            lblPaidRetail.AutoSize = true;
            lblPaidRetail.Dock = DockStyle.Fill;
            lblPaidRetail.Location = new Point(347, 106);
            lblPaidRetail.Name = "lblPaidRetail";
            lblPaidRetail.Size = new Size(179, 56);
            lblPaidRetail.TabIndex = 4;
            lblPaidRetail.Text = "المدفوع:";
            lblPaidRetail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _txPaidRetailWrap
            // 
            _txPaidRetailWrap.Controls.Add(_txPaidRetail);
            _txPaidRetailWrap.Dock = DockStyle.Fill;
            _txPaidRetailWrap.Location = new Point(3, 109);
            _txPaidRetailWrap.Name = "_txPaidRetailWrap";
            _txPaidRetailWrap.Padding = new Padding(11, 7, 11, 7);
            _txPaidRetailWrap.Size = new Size(338, 50);
            _txPaidRetailWrap.TabIndex = 5;
            // 
            // _txPaidRetail
            // 
            _txPaidRetail.BorderStyle = BorderStyle.None;
            _txPaidRetail.Dock = DockStyle.Fill;
            _txPaidRetail.Location = new Point(11, 7);
            _txPaidRetail.Name = "_txPaidRetail";
            _txPaidRetail.Size = new Size(316, 24);
            _txPaidRetail.TabIndex = 0;
            _txPaidRetail.Text = "0";
            // 
            // retailDateFlow
            // 
            retailDateFlow.AutoSize = true;
            retailTable.SetColumnSpan(retailDateFlow, 2);
            retailDateFlow.Controls.Add(_chkIsDeliveryRetail);
            retailDateFlow.Controls.Add(_btnDeliveryRetail);
            retailDateFlow.Controls.Add(_lblDeliveryRetail);
            retailDateFlow.Dock = DockStyle.Fill;
            retailDateFlow.FlowDirection = FlowDirection.RightToLeft;
            retailDateFlow.Location = new Point(3, 165);
            retailDateFlow.Name = "retailDateFlow";
            retailDateFlow.RightToLeft = RightToLeft.Yes;
            retailDateFlow.Size = new Size(523, 199);
            retailDateFlow.TabIndex = 6;
            // 
            // _chkIsDeliveryRetail
            // 
            _chkIsDeliveryRetail.AutoSize = true;
            _chkIsDeliveryRetail.Location = new Point(13, 10);
            _chkIsDeliveryRetail.Margin = new Padding(0, 10, 13, 0);
            _chkIsDeliveryRetail.Name = "_chkIsDeliveryRetail";
            _chkIsDeliveryRetail.Size = new Size(132, 29);
            _chkIsDeliveryRetail.TabIndex = 0;
            _chkIsDeliveryRetail.Text = "طلب توصيل";
            _chkIsDeliveryRetail.UseVisualStyleBackColor = true;
            // 
            // _btnDeliveryRetail
            // 
            _btnDeliveryRetail.BackColor = Color.FromArgb(147, 197, 114);
            _btnDeliveryRetail.Cursor = Cursors.Hand;
            _btnDeliveryRetail.FlatAppearance.BorderSize = 0;
            _btnDeliveryRetail.FlatStyle = FlatStyle.Flat;
            _btnDeliveryRetail.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _btnDeliveryRetail.ForeColor = Color.White;
            _btnDeliveryRetail.Location = new Point(145, 0);
            _btnDeliveryRetail.Margin = new Padding(10, 0, 0, 0);
            _btnDeliveryRetail.Name = "_btnDeliveryRetail";
            _btnDeliveryRetail.Radius = 6;
            _btnDeliveryRetail.Size = new Size(104, 50);
            _btnDeliveryRetail.TabIndex = 1;
            _btnDeliveryRetail.Text = "التاريخ";
            _btnDeliveryRetail.UseVisualStyleBackColor = false;
            // 
            // _lblDeliveryRetail
            // 
            _lblDeliveryRetail.AutoSize = true;
            _lblDeliveryRetail.Location = new Point(259, 12);
            _lblDeliveryRetail.Margin = new Padding(10, 12, 0, 0);
            _lblDeliveryRetail.Name = "_lblDeliveryRetail";
            _lblDeliveryRetail.Size = new Size(69, 25);
            _lblDeliveryRetail.TabIndex = 2;
            _lblDeliveryRetail.Text = "لم يحدد";
            // 
            // _calRetail
            // 
            _calRetail.Location = new Point(13, 123);
            _calRetail.Name = "_calRetail";
            _calRetail.TabIndex = 5;
            _calRetail.Visible = false;
            // 
            // typeCard
            // 
            typeCard.Controls.Add(typeFlow);
            typeCard.Controls.Add(lblOrderType);
            typeCard.Dock = DockStyle.Top;
            typeCard.Location = new Point(0, 0);
            typeCard.Margin = new Padding(0, 0, 0, 7);
            typeCard.Name = "typeCard";
            typeCard.Padding = new Padding(13, 10, 13, 10);
            typeCard.RightToLeft = RightToLeft.Yes;
            typeCard.Size = new Size(567, 70);
            typeCard.TabIndex = 2;
            // 
            // typeFlow
            // 
            typeFlow.Controls.Add(_rbRetail);
            typeFlow.Controls.Add(_rbWholesale);
            typeFlow.Dock = DockStyle.Fill;
            typeFlow.FlowDirection = FlowDirection.RightToLeft;
            typeFlow.Location = new Point(13, 10);
            typeFlow.Name = "typeFlow";
            typeFlow.Size = new Size(445, 50);
            typeFlow.TabIndex = 1;
            // 
            // _rbRetail
            // 
            _rbRetail.AutoSize = true;
            _rbRetail.Checked = true;
            _rbRetail.Cursor = Cursors.Hand;
            _rbRetail.Location = new Point(350, 3);
            _rbRetail.Name = "_rbRetail";
            _rbRetail.RightToLeft = RightToLeft.Yes;
            _rbRetail.Size = new Size(92, 29);
            _rbRetail.TabIndex = 1;
            _rbRetail.TabStop = true;
            _rbRetail.Text = "قطاعي";
            _rbRetail.CheckedChanged += _rbType_CheckedChanged;
            // 
            // _rbWholesale
            // 
            _rbWholesale.AutoSize = true;
            _rbWholesale.Cursor = Cursors.Hand;
            _rbWholesale.Location = new Point(250, 3);
            _rbWholesale.Name = "_rbWholesale";
            _rbWholesale.RightToLeft = RightToLeft.Yes;
            _rbWholesale.Size = new Size(74, 29);
            _rbWholesale.TabIndex = 2;
            _rbWholesale.Text = "جملة";
            _rbWholesale.CheckedChanged += _rbType_CheckedChanged;
            // 
            // lblOrderType
            // 
            lblOrderType.AutoSize = true;
            lblOrderType.Dock = DockStyle.Right;
            lblOrderType.Location = new Point(458, 10);
            lblOrderType.Name = "lblOrderType";
            lblOrderType.Size = new Size(96, 25);
            lblOrderType.TabIndex = 0;
            lblOrderType.Text = "نوع الطلب:";
            lblOrderType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(_linesGrid);
            leftPanel.Controls.Add(_btnSelectProducts);
            leftPanel.Controls.Add(btnActFlow);
            leftPanel.Controls.Add(lblCartTitle);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(18, 23);
            leftPanel.Margin = new Padding(4, 3, 4, 3);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(13, 0, 13, 0);
            leftPanel.Size = new Size(876, 879);
            leftPanel.TabIndex = 1;
            // 
            // _linesGrid
            // 
            _linesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _linesGrid.Dock = DockStyle.Fill;
            _linesGrid.Location = new Point(13, 82);
            _linesGrid.Margin = new Padding(4, 3, 4, 3);
            _linesGrid.Name = "_linesGrid";
            _linesGrid.RowHeadersWidth = 51;
            _linesGrid.Size = new Size(850, 732);
            _linesGrid.TabIndex = 0;
            // 
            // _btnSelectProducts
            // 
            _btnSelectProducts.BackColor = Color.FromArgb(210, 150, 75);
            _btnSelectProducts.Cursor = Cursors.Hand;
            _btnSelectProducts.Dock = DockStyle.Top;
            _btnSelectProducts.FlatAppearance.BorderSize = 0;
            _btnSelectProducts.FlatStyle = FlatStyle.Flat;
            _btnSelectProducts.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _btnSelectProducts.ForeColor = Color.White;
            _btnSelectProducts.Location = new Point(13, 37);
            _btnSelectProducts.Margin = new Padding(0, 0, 0, 10);
            _btnSelectProducts.Name = "_btnSelectProducts";
            _btnSelectProducts.Radius = 6;
            _btnSelectProducts.Size = new Size(850, 45);
            _btnSelectProducts.TabIndex = 1;
            _btnSelectProducts.Text = "اختيار المنتجات";
            _btnSelectProducts.UseVisualStyleBackColor = false;
            _btnSelectProducts.Click += _btnSelectProducts_Click;
            // 
            // btnActFlow
            // 
            btnActFlow.Dock = DockStyle.Bottom;
            btnActFlow.Location = new Point(13, 814);
            btnActFlow.Margin = new Padding(4, 3, 4, 3);
            btnActFlow.Name = "btnActFlow";
            btnActFlow.Padding = new Padding(0, 10, 0, 0);
            btnActFlow.Size = new Size(850, 65);
            btnActFlow.TabIndex = 6;
            // 
            // lblCartTitle
            // 
            lblCartTitle.Dock = DockStyle.Top;
            lblCartTitle.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            lblCartTitle.Location = new Point(13, 0);
            lblCartTitle.Margin = new Padding(4, 0, 4, 0);
            lblCartTitle.Name = "lblCartTitle";
            lblCartTitle.Padding = new Padding(6, 0, 0, 0);
            lblCartTitle.Size = new Size(850, 37);
            lblCartTitle.TabIndex = 1;
            lblCartTitle.Text = "\U0001f6d2  سلة الطلب";
            lblCartTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderEntryControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bodyTable);
            Controls.Add(headerPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "OrderEntryControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1500, 1025);
            headerPanel.ResumeLayout(false);
            bodyTable.ResumeLayout(false);
            infoPanel.ResumeLayout(false);
            infoPanel.PerformLayout();
            sumCard.ResumeLayout(false);
            sumCard.PerformLayout();
            sumTable.ResumeLayout(false);
            sumTable.PerformLayout();
            _wholesalePanel.ResumeLayout(false);
            _wholesalePanel.PerformLayout();
            wholesaleTable.ResumeLayout(false);
            wholesaleTable.PerformLayout();
            _txPaidWholesaleWrap.ResumeLayout(false);
            _txPaidWholesaleWrap.PerformLayout();
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
            _txPaidRetailWrap.ResumeLayout(false);
            _txPaidRetailWrap.PerformLayout();
            retailDateFlow.ResumeLayout(false);
            retailDateFlow.PerformLayout();
            typeCard.ResumeLayout(false);
            typeCard.PerformLayout();
            typeFlow.ResumeLayout(false);
            typeFlow.PerformLayout();
            leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_linesGrid).EndInit();
            ResumeLayout(false);
        }
        #endregion

        // ── Field declarations ────────────────────────────────────────────────
        private System.Windows.Forms.Panel       headerPanel;
        private System.Windows.Forms.Label       h1Label;
        private System.Windows.Forms.Panel       sepBar;
        private System.Windows.Forms.TableLayoutPanel bodyTable;

        // Layout Panels
        private System.Windows.Forms.Panel       leftPanel;
        private System.Windows.Forms.Panel       infoPanel;
        private System.Windows.Forms.Panel       typeCard;
        private System.Windows.Forms.FlowLayoutPanel typeFlow;
        private System.Windows.Forms.Label       lblOrderType;
        private System.Windows.Forms.RadioButton _rbRetail;
        private System.Windows.Forms.RadioButton _rbWholesale;

        private System.Windows.Forms.Panel       _retailPanel;
        private System.Windows.Forms.TableLayoutPanel retailTable;
        private System.Windows.Forms.Label       lblCustomerName;
        private System.Windows.Forms.Label       lblCustomerPhone;
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
        private System.Windows.Forms.TableLayoutPanel sumTable;
        private System.Windows.Forms.Label       lblSummary;
        private System.Windows.Forms.Panel       sepBar1;
        private System.Windows.Forms.Label       lblSubTitle;
        private System.Windows.Forms.Label       _lblSub;
                private System.Windows.Forms.Label       lblBalanceTitle;
        private System.Windows.Forms.Label       _lblBalance;
                private System.Windows.Forms.Label       lblGrandTitle;
        private System.Windows.Forms.Label       _lblGrand;

        private System.Windows.Forms.FlowLayoutPanel btnActFlow;

        private sweetSystem.FlatButton _btnSelectProducts;
    }
}
