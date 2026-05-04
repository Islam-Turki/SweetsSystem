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
            rightPanel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            typeCard = new Panel();
            _rbWholesale = new RadioButton();
            _rbRetail = new RadioButton();
            lblOrderType = new Label();
            _retailPanel = new Panel();
            _calRetail = new MonthCalendar();
            _lblDeliveryRetail = new Label();
            _btnDeliveryRetail = new FlatButton();
            _txCustomerExtra = new TextBox();
            _txCustomer = new TextBox();
            lblCustomerName = new Label();
            _wholesalePanel = new Panel();
            _calWholesale = new MonthCalendar();
            _lblDeliveryWholesale = new Label();
            _btnDeliveryWholesale = new FlatButton();
            _cbClient = new ComboBox();
            lblWholesaleClient = new Label();
            pickerCard = new Panel();
            _btnRemove = new FlatButton();
            _btnAdd = new FlatButton();
            _numQty = new NumericUpDown();
            lblQty = new Label();
            _cbProduct = new ComboBox();
            lblProduct = new Label();
            gridCard = new Panel();
            _linesGrid = new DataGridView();
            leftPanel = new Panel();
            btnFlow = new FlowLayoutPanel();
            _btnSave = new FlatButton();
            _btnClear = new FlatButton();
            sumCard = new Panel();
            _lblGrand = new Label();
            lblGrandTitle = new Label();
            sepBar2 = new Panel();
            _balanceRow = new Panel();
            _lblBalance = new Label();
            lblBalanceTitle = new Label();
            _lblSub = new Label();
            lblSubTitle = new Label();
            sepBar1 = new Panel();
            lblSummary = new Label();
            headerPanel.SuspendLayout();
            bodyTable.SuspendLayout();
            rightPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            typeCard.SuspendLayout();
            _retailPanel.SuspendLayout();
            _wholesalePanel.SuspendLayout();
            pickerCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_numQty).BeginInit();
            gridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_linesGrid).BeginInit();
            leftPanel.SuspendLayout();
            btnFlow.SuspendLayout();
            sumCard.SuspendLayout();
            _balanceRow.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(255, 255, 255);
            headerPanel.Controls.Add(h1Label);
            headerPanel.Controls.Add(sepBar);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1146, 84);
            headerPanel.TabIndex = 0;
            // 
            // h1Label
            // 
            h1Label.Dock = DockStyle.Fill;
            h1Label.Font = new Font("Cairo", 16F, FontStyle.Bold);
            h1Label.ForeColor = Color.FromArgb(36, 36, 36);
            h1Label.Location = new Point(0, 0);
            h1Label.Name = "h1Label";
            h1Label.Padding = new Padding(0, 0, 16, 0);
            h1Label.Size = new Size(1146, 82);
            h1Label.TabIndex = 0;
            h1Label.Text = "\U0001f6d2  إدخال طلب جديد";
            h1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sepBar
            // 
            sepBar.BackColor = Color.FromArgb(100, 158, 100);
            sepBar.Dock = DockStyle.Bottom;
            sepBar.Location = new Point(0, 82);
            sepBar.Name = "sepBar";
            sepBar.Size = new Size(1146, 2);
            sepBar.TabIndex = 1;
            // 
            // bodyTable
            // 
            bodyTable.BackColor = Color.FromArgb(247, 246, 242);
            bodyTable.ColumnCount = 2;
            bodyTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            bodyTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            bodyTable.Controls.Add(rightPanel, 0, 0);
            bodyTable.Controls.Add(leftPanel, 1, 0);
            bodyTable.Dock = DockStyle.Fill;
            bodyTable.Location = new Point(0, 84);
            bodyTable.Name = "bodyTable";
            bodyTable.Padding = new Padding(16, 24, 16, 16);
            bodyTable.RowCount = 1;
            bodyTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bodyTable.Size = new Size(1146, 1094);
            bodyTable.TabIndex = 1;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(tableLayoutPanel1);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(521, 27);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(8, 0, 0, 0);
            rightPanel.Size = new Size(606, 1048);
            rightPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(typeCard, 0, 0);
            tableLayoutPanel1.Controls.Add(_retailPanel, 0, 1);
            tableLayoutPanel1.Controls.Add(_wholesalePanel, 0, 1);
            tableLayoutPanel1.Controls.Add(pickerCard, 0, 2);
            tableLayoutPanel1.Controls.Add(gridCard, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(8, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(598, 1048);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // typeCard
            // 
            typeCard.BackColor = Color.White;
            typeCard.Controls.Add(_rbWholesale);
            typeCard.Controls.Add(_rbRetail);
            typeCard.Controls.Add(lblOrderType);
            typeCard.Dock = DockStyle.Fill;
            typeCard.Location = new Point(3, 3);
            typeCard.Name = "typeCard";
            typeCard.Padding = new Padding(8, 4, 8, 4);
            typeCard.Size = new Size(592, 64);
            typeCard.TabIndex = 0;
            // 
            // _rbWholesale
            // 
            _rbWholesale.AutoSize = true;
            _rbWholesale.Cursor = Cursors.Hand;
            _rbWholesale.Location = new Point(520, 27);
            _rbWholesale.Name = "_rbWholesale";
            _rbWholesale.RightToLeft = RightToLeft.Yes;
            _rbWholesale.Size = new Size(61, 24);
            _rbWholesale.TabIndex = 2;
            _rbWholesale.Text = "جملة";
            _rbWholesale.UseVisualStyleBackColor = true;
            _rbWholesale.CheckedChanged += _rbType_CheckedChanged;
            // 
            // _rbRetail
            // 
            _rbRetail.AutoSize = true;
            _rbRetail.Checked = true;
            _rbRetail.Cursor = Cursors.Hand;
            _rbRetail.Location = new Point(437, 27);
            _rbRetail.Name = "_rbRetail";
            _rbRetail.RightToLeft = RightToLeft.Yes;
            _rbRetail.Size = new Size(77, 24);
            _rbRetail.TabIndex = 1;
            _rbRetail.TabStop = true;
            _rbRetail.Text = "قطاعي";
            _rbRetail.UseVisualStyleBackColor = true;
            _rbRetail.CheckedChanged += _rbType_CheckedChanged;
            // 
            // lblOrderType
            // 
            lblOrderType.AutoSize = true;
            lblOrderType.Location = new Point(502, 4);
            lblOrderType.Name = "lblOrderType";
            lblOrderType.RightToLeft = RightToLeft.Yes;
            lblOrderType.Size = new Size(79, 20);
            lblOrderType.TabIndex = 0;
            lblOrderType.Text = "نوع الطلب:";
            // 
            // _retailPanel
            // 
            _retailPanel.BackColor = Color.FromArgb(247, 246, 242);
            _retailPanel.Controls.Add(_calRetail);
            _retailPanel.Controls.Add(_lblDeliveryRetail);
            _retailPanel.Controls.Add(_btnDeliveryRetail);
            _retailPanel.Controls.Add(_txCustomerExtra);
            _retailPanel.Controls.Add(_txCustomer);
            _retailPanel.Controls.Add(lblCustomerName);
            _retailPanel.Dock = DockStyle.Fill;
            _retailPanel.Location = new Point(3, 183);
            _retailPanel.Name = "_retailPanel";
            _retailPanel.Size = new Size(592, 104);
            _retailPanel.TabIndex = 1;
            // 
            // _calRetail
            // 
            _calRetail.Location = new Point(13, 65);
            _calRetail.MaxSelectionCount = 1;
            _calRetail.Name = "_calRetail";
            _calRetail.TabIndex = 5;
            _calRetail.Visible = false;
            // 
            // _lblDeliveryRetail
            // 
            _lblDeliveryRetail.AutoSize = true;
            _lblDeliveryRetail.Location = new Point(71, 32);
            _lblDeliveryRetail.Name = "_lblDeliveryRetail";
            _lblDeliveryRetail.Size = new Size(57, 20);
            _lblDeliveryRetail.TabIndex = 4;
            _lblDeliveryRetail.Text = "لم يحدد";
            // 
            // _btnDeliveryRetail
            // 
            _btnDeliveryRetail.BackColor = Color.LightGray;
            _btnDeliveryRetail.FlatStyle = FlatStyle.Flat;
            _btnDeliveryRetail.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _btnDeliveryRetail.ForeColor = Color.White;
            _btnDeliveryRetail.Location = new Point(135, 29);
            _btnDeliveryRetail.Name = "_btnDeliveryRetail";
            _btnDeliveryRetail.Radius = 6;
            _btnDeliveryRetail.Size = new Size(140, 30);
            _btnDeliveryRetail.TabIndex = 3;
            _btnDeliveryRetail.Text = "موعد التسليم";
            _btnDeliveryRetail.UseVisualStyleBackColor = false;
            // 
            // _txCustomerExtra
            // 
            _txCustomerExtra.BorderStyle = BorderStyle.FixedSingle;
            _txCustomerExtra.Location = new Point(281, 65);
            _txCustomerExtra.Name = "_txCustomerExtra";
            _txCustomerExtra.PlaceholderText = "رقم الهاتف";
            _txCustomerExtra.Size = new Size(300, 27);
            _txCustomerExtra.TabIndex = 2;
            // 
            // _txCustomer
            // 
            _txCustomer.BorderStyle = BorderStyle.FixedSingle;
            _txCustomer.Location = new Point(281, 32);
            _txCustomer.Name = "_txCustomer";
            _txCustomer.PlaceholderText = "أدخل اسم العميل";
            _txCustomer.Size = new Size(300, 27);
            _txCustomer.TabIndex = 1;
            _txCustomer.TextChanged += _txCustomer_TextChanged;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(500, 9);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(81, 20);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "اسم العميل";
            // 
            // _wholesalePanel
            // 
            _wholesalePanel.BackColor = Color.FromArgb(247, 246, 242);
            _wholesalePanel.Controls.Add(_calWholesale);
            _wholesalePanel.Controls.Add(_lblDeliveryWholesale);
            _wholesalePanel.Controls.Add(_btnDeliveryWholesale);
            _wholesalePanel.Controls.Add(_cbClient);
            _wholesalePanel.Controls.Add(lblWholesaleClient);
            _wholesalePanel.Dock = DockStyle.Fill;
            _wholesalePanel.Location = new Point(3, 73);
            _wholesalePanel.Name = "_wholesalePanel";
            _wholesalePanel.Size = new Size(592, 104);
            _wholesalePanel.TabIndex = 2;
            _wholesalePanel.Visible = false;
            // 
            // _calWholesale
            // 
            _calWholesale.Location = new Point(13, 74);
            _calWholesale.MaxSelectionCount = 1;
            _calWholesale.Name = "_calWholesale";
            _calWholesale.TabIndex = 4;
            _calWholesale.Visible = false;
            // 
            // _lblDeliveryWholesale
            // 
            _lblDeliveryWholesale.AutoSize = true;
            _lblDeliveryWholesale.Location = new Point(71, 32);
            _lblDeliveryWholesale.Name = "_lblDeliveryWholesale";
            _lblDeliveryWholesale.Size = new Size(57, 20);
            _lblDeliveryWholesale.TabIndex = 3;
            _lblDeliveryWholesale.Text = "لم يحدد";
            // 
            // _btnDeliveryWholesale
            // 
            _btnDeliveryWholesale.BackColor = Color.LightGray;
            _btnDeliveryWholesale.FlatStyle = FlatStyle.Flat;
            _btnDeliveryWholesale.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _btnDeliveryWholesale.ForeColor = Color.White;
            _btnDeliveryWholesale.Location = new Point(135, 32);
            _btnDeliveryWholesale.Name = "_btnDeliveryWholesale";
            _btnDeliveryWholesale.Radius = 6;
            _btnDeliveryWholesale.Size = new Size(140, 30);
            _btnDeliveryWholesale.TabIndex = 2;
            _btnDeliveryWholesale.Text = "موعد التسليم";
            _btnDeliveryWholesale.UseVisualStyleBackColor = false;
            // 
            // _cbClient
            // 
            _cbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbClient.FlatStyle = FlatStyle.Flat;
            _cbClient.FormattingEnabled = true;
            _cbClient.Location = new Point(281, 34);
            _cbClient.Name = "_cbClient";
            _cbClient.Size = new Size(300, 28);
            _cbClient.TabIndex = 1;
            _cbClient.SelectedIndexChanged += _cbClient_SelectedIndexChanged;
            // 
            // lblWholesaleClient
            // 
            lblWholesaleClient.AutoSize = true;
            lblWholesaleClient.Location = new Point(495, 11);
            lblWholesaleClient.Name = "lblWholesaleClient";
            lblWholesaleClient.Size = new Size(86, 20);
            lblWholesaleClient.TabIndex = 0;
            lblWholesaleClient.Text = "عميل الجملة";
            // 
            // pickerCard
            // 
            pickerCard.BackColor = Color.White;
            pickerCard.Controls.Add(_btnRemove);
            pickerCard.Controls.Add(_btnAdd);
            pickerCard.Controls.Add(_numQty);
            pickerCard.Controls.Add(lblQty);
            pickerCard.Controls.Add(_cbProduct);
            pickerCard.Controls.Add(lblProduct);
            pickerCard.Dock = DockStyle.Fill;
            pickerCard.Location = new Point(3, 293);
            pickerCard.Name = "pickerCard";
            pickerCard.Padding = new Padding(8, 4, 8, 4);
            pickerCard.Size = new Size(592, 732);
            pickerCard.TabIndex = 3;
            // 
            // _btnRemove
            // 
            _btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemove.BackColor = Color.IndianRed;
            _btnRemove.FlatStyle = FlatStyle.Flat;
            _btnRemove.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _btnRemove.ForeColor = Color.White;
            _btnRemove.Location = new Point(137, 522);
            _btnRemove.Name = "_btnRemove";
            _btnRemove.Radius = 6;
            _btnRemove.Size = new Size(95, 30);
            _btnRemove.TabIndex = 5;
            _btnRemove.Text = "✕ حذف";
            _btnRemove.UseVisualStyleBackColor = false;
            _btnRemove.Click += BtnRemove_Click;
            // 
            // _btnAdd
            // 
            _btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAdd.BackColor = Color.LightGray;
            _btnAdd.FlatStyle = FlatStyle.Flat;
            _btnAdd.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _btnAdd.ForeColor = Color.White;
            _btnAdd.Location = new Point(11, 522);
            _btnAdd.Name = "_btnAdd";
            _btnAdd.Radius = 6;
            _btnAdd.Size = new Size(120, 30);
            _btnAdd.TabIndex = 4;
            _btnAdd.Text = "＋ إضافة";
            _btnAdd.UseVisualStyleBackColor = false;
            _btnAdd.Click += BtnAdd_Click;
            // 
            // _numQty
            // 
            _numQty.BorderStyle = BorderStyle.FixedSingle;
            _numQty.Dock = DockStyle.Right;
            _numQty.Location = new Point(35, 4);
            _numQty.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            _numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _numQty.Name = "_numQty";
            _numQty.Size = new Size(189, 27);
            _numQty.TabIndex = 3;
            _numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Dock = DockStyle.Right;
            lblQty.Location = new Point(224, 4);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(51, 20);
            lblQty.TabIndex = 2;
            lblQty.Text = "الكمية:";
            // 
            // _cbProduct
            // 
            _cbProduct.Dock = DockStyle.Right;
            _cbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbProduct.FlatStyle = FlatStyle.Flat;
            _cbProduct.FormattingEnabled = true;
            _cbProduct.Location = new Point(275, 4);
            _cbProduct.Name = "_cbProduct";
            _cbProduct.Size = new Size(240, 28);
            _cbProduct.TabIndex = 1;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Dock = DockStyle.Right;
            lblProduct.Location = new Point(515, 4);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(69, 20);
            lblProduct.TabIndex = 0;
            lblProduct.Text = "اختر منتجاً";
            // 
            // gridCard
            // 
            gridCard.BackColor = Color.FromArgb(247, 246, 242);
            gridCard.Controls.Add(_linesGrid);
            gridCard.Dock = DockStyle.Fill;
            gridCard.Location = new Point(3, 1031);
            gridCard.Name = "gridCard";
            gridCard.Size = new Size(592, 14);
            gridCard.TabIndex = 4;
            // 
            // _linesGrid
            // 
            _linesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _linesGrid.Dock = DockStyle.Fill;
            _linesGrid.Location = new Point(0, 0);
            _linesGrid.Name = "_linesGrid";
            _linesGrid.RowHeadersWidth = 51;
            _linesGrid.Size = new Size(592, 14);
            _linesGrid.TabIndex = 0;
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(btnFlow);
            leftPanel.Controls.Add(sumCard);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(19, 27);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(0, 0, 8, 0);
            leftPanel.Size = new Size(496, 1048);
            leftPanel.TabIndex = 1;
            // 
            // btnFlow
            // 
            btnFlow.BackColor = Color.FromArgb(247, 246, 242);
            btnFlow.Controls.Add(_btnSave);
            btnFlow.Controls.Add(_btnClear);
            btnFlow.Dock = DockStyle.Top;
            btnFlow.FlowDirection = FlowDirection.RightToLeft;
            btnFlow.Location = new Point(0, 280);
            btnFlow.Name = "btnFlow";
            btnFlow.Padding = new Padding(0, 8, 0, 0);
            btnFlow.Size = new Size(488, 52);
            btnFlow.TabIndex = 1;
            // 
            // _btnSave
            // 
            _btnSave.BackColor = Color.MediumSeaGreen;
            _btnSave.FlatStyle = FlatStyle.Flat;
            _btnSave.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _btnSave.ForeColor = Color.White;
            _btnSave.Location = new Point(3, 11);
            _btnSave.Margin = new Padding(6, 3, 3, 3);
            _btnSave.Name = "_btnSave";
            _btnSave.Radius = 6;
            _btnSave.Size = new Size(150, 30);
            _btnSave.TabIndex = 0;
            _btnSave.Text = "✔  حفظ الطلب";
            _btnSave.UseVisualStyleBackColor = false;
            // 
            // _btnClear
            // 
            _btnClear.BackColor = Color.Gray;
            _btnClear.FlatStyle = FlatStyle.Flat;
            _btnClear.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _btnClear.ForeColor = Color.White;
            _btnClear.Location = new Point(162, 11);
            _btnClear.Name = "_btnClear";
            _btnClear.Radius = 6;
            _btnClear.Size = new Size(90, 30);
            _btnClear.TabIndex = 1;
            _btnClear.Text = "✕  مسح";
            _btnClear.UseVisualStyleBackColor = false;
            _btnClear.Click += BtnClear_Click;
            // 
            // sumCard
            // 
            sumCard.BackColor = Color.White;
            sumCard.Controls.Add(_lblGrand);
            sumCard.Controls.Add(lblGrandTitle);
            sumCard.Controls.Add(sepBar2);
            sumCard.Controls.Add(_balanceRow);
            sumCard.Controls.Add(_lblSub);
            sumCard.Controls.Add(lblSubTitle);
            sumCard.Controls.Add(sepBar1);
            sumCard.Controls.Add(lblSummary);
            sumCard.Dock = DockStyle.Top;
            sumCard.Location = new Point(0, 0);
            sumCard.Name = "sumCard";
            sumCard.Padding = new Padding(8, 4, 8, 4);
            sumCard.Size = new Size(488, 280);
            sumCard.TabIndex = 0;
            // 
            // _lblGrand
            // 
            _lblGrand.AutoSize = true;
            _lblGrand.Font = new Font("Tahoma", 13F, FontStyle.Bold);
            _lblGrand.ForeColor = Color.ForestGreen;
            _lblGrand.Location = new Point(180, 136);
            _lblGrand.Name = "_lblGrand";
            _lblGrand.Size = new Size(61, 27);
            _lblGrand.TabIndex = 7;
            _lblGrand.Text = "0.00";
            // 
            // lblGrandTitle
            // 
            lblGrandTitle.AutoSize = true;
            lblGrandTitle.ForeColor = Color.ForestGreen;
            lblGrandTitle.Location = new Point(12, 140);
            lblGrandTitle.Name = "lblGrandTitle";
            lblGrandTitle.Size = new Size(104, 20);
            lblGrandTitle.TabIndex = 6;
            lblGrandTitle.Text = "الإجمالي الكلي:";
            // 
            // sepBar2
            // 
            sepBar2.BackColor = Color.LightGray;
            sepBar2.Location = new Point(12, 126);
            sepBar2.Name = "sepBar2";
            sepBar2.Size = new Size(270, 1);
            sepBar2.TabIndex = 5;
            // 
            // _balanceRow
            // 
            _balanceRow.BackColor = Color.Transparent;
            _balanceRow.Controls.Add(_lblBalance);
            _balanceRow.Controls.Add(lblBalanceTitle);
            _balanceRow.Location = new Point(12, 86);
            _balanceRow.Name = "_balanceRow";
            _balanceRow.Size = new Size(280, 30);
            _balanceRow.TabIndex = 4;
            _balanceRow.Visible = false;
            // 
            // _lblBalance
            // 
            _lblBalance.AutoSize = true;
            _lblBalance.ForeColor = Color.IndianRed;
            _lblBalance.Location = new Point(158, 5);
            _lblBalance.Name = "_lblBalance";
            _lblBalance.Size = new Size(36, 20);
            _lblBalance.TabIndex = 1;
            _lblBalance.Text = "0.00";
            // 
            // lblBalanceTitle
            // 
            lblBalanceTitle.AutoSize = true;
            lblBalanceTitle.ForeColor = Color.IndianRed;
            lblBalanceTitle.Location = new Point(0, 5);
            lblBalanceTitle.Name = "lblBalanceTitle";
            lblBalanceTitle.Size = new Size(100, 20);
            lblBalanceTitle.TabIndex = 0;
            lblBalanceTitle.Text = "الرصيد السابق:";
            // 
            // _lblSub
            // 
            _lblSub.AutoSize = true;
            _lblSub.Location = new Point(180, 54);
            _lblSub.Name = "_lblSub";
            _lblSub.Size = new Size(36, 20);
            _lblSub.TabIndex = 3;
            _lblSub.Text = "0.00";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Location = new Point(12, 54);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(113, 20);
            lblSubTitle.TabIndex = 2;
            lblSubTitle.Text = "المجموع الفرعي:";
            // 
            // sepBar1
            // 
            sepBar1.BackColor = Color.LightGray;
            sepBar1.Location = new Point(12, 40);
            sepBar1.Name = "sepBar1";
            sepBar1.Size = new Size(270, 1);
            sepBar1.TabIndex = 1;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSummary.Location = new Point(12, 12);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(130, 28);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "ملخص الطلب";
            // 
            // OrderEntryControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 246, 242);
            Controls.Add(bodyTable);
            Controls.Add(headerPanel);
            Name = "OrderEntryControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1146, 1178);
            headerPanel.ResumeLayout(false);
            bodyTable.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            typeCard.ResumeLayout(false);
            typeCard.PerformLayout();
            _retailPanel.ResumeLayout(false);
            _retailPanel.PerformLayout();
            _wholesalePanel.ResumeLayout(false);
            _wholesalePanel.PerformLayout();
            pickerCard.ResumeLayout(false);
            pickerCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_numQty).EndInit();
            gridCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_linesGrid).EndInit();
            leftPanel.ResumeLayout(false);
            btnFlow.ResumeLayout(false);
            sumCard.ResumeLayout(false);
            sumCard.PerformLayout();
            _balanceRow.ResumeLayout(false);
            _balanceRow.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label h1Label;
        private System.Windows.Forms.Panel sepBar;
        private System.Windows.Forms.TableLayoutPanel bodyTable;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel leftPanel;

        // Added standard controls previously inside BuildContent
        private System.Windows.Forms.Panel gridCard;
        private System.Windows.Forms.DataGridView _linesGrid;
        private System.Windows.Forms.Panel pickerCard;
        private sweetSystem.FlatButton _btnRemove;
        private sweetSystem.FlatButton _btnAdd;
        private System.Windows.Forms.NumericUpDown _numQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.ComboBox _cbProduct;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Panel _wholesalePanel;
        private System.Windows.Forms.MonthCalendar _calWholesale;
        private System.Windows.Forms.Label _lblDeliveryWholesale;
        private sweetSystem.FlatButton _btnDeliveryWholesale;
        private System.Windows.Forms.ComboBox _cbClient;
        private System.Windows.Forms.Label lblWholesaleClient;
        private System.Windows.Forms.Panel _retailPanel;
        private System.Windows.Forms.MonthCalendar _calRetail;
        private System.Windows.Forms.Label _lblDeliveryRetail;
        private sweetSystem.FlatButton _btnDeliveryRetail;
        private System.Windows.Forms.TextBox _txCustomerExtra;
        private System.Windows.Forms.TextBox _txCustomer;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Panel typeCard;
        private System.Windows.Forms.RadioButton _rbWholesale;
        private System.Windows.Forms.RadioButton _rbRetail;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.FlowLayoutPanel btnFlow;
        private sweetSystem.FlatButton _btnSave;
        private sweetSystem.FlatButton _btnClear;
        private System.Windows.Forms.Panel sumCard;
        private System.Windows.Forms.Label _lblGrand;
        private System.Windows.Forms.Label lblGrandTitle;
        private System.Windows.Forms.Panel sepBar2;
        private System.Windows.Forms.Panel _balanceRow;
        private System.Windows.Forms.Label _lblBalance;
        private System.Windows.Forms.Label lblBalanceTitle;
        private System.Windows.Forms.Label _lblSub;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Panel sepBar1;
        private System.Windows.Forms.Label lblSummary;
        private TableLayoutPanel tableLayoutPanel1;
    }
}