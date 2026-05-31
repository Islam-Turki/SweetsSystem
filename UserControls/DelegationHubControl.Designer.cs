using sweetSystem;
namespace sweetSystem.UserControls
{
    partial class DelegationHubControl
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
            _pendingGrid = new DataGridView();
            _packagerGrid = new DataGridView();
            _lblSel = new Label();
            rightHeader = new SectionHeader();
            leftHeader = new SectionHeader();
            headerPanel = new Panel();
            h1Label = new Label();
            sepBar = new Panel();
            topBar = new TableLayoutPanel();
            btnAuto = new FlatButton();
            btnManualAll = new FlatButton();
            bodyTable = new TableLayoutPanel();
            leftPanel = new TableLayoutPanel();
            rightPanel = new Panel();
            tabs = new FlowLayoutPanel();
            _btnToday = new FlatButton();
            _btnTomorrow = new FlatButton();
            ((System.ComponentModel.ISupportInitialize)_pendingGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_packagerGrid).BeginInit();
            headerPanel.SuspendLayout();
            topBar.SuspendLayout();
            bodyTable.SuspendLayout();
            leftPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            tabs.SuspendLayout();
            SuspendLayout();
            // 
            // _pendingGrid
            // 
            _pendingGrid.AllowUserToResizeColumns = false;
            _pendingGrid.AllowUserToResizeRows = false;
            _pendingGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _pendingGrid.Dock = DockStyle.Fill;
            _pendingGrid.Location = new Point(7, 64);
            _pendingGrid.Margin = new Padding(3, 2, 3, 2);
            _pendingGrid.Name = "_pendingGrid";
            _pendingGrid.RowHeadersWidth = 51;
            _pendingGrid.Size = new Size(669, 208);
            _pendingGrid.TabIndex = 5;
            _pendingGrid.CellClick += PendingGrid_CellClick;
            _pendingGrid.CellContentClick += _pendingGrid_CellContentClick;
            // 
            // _packagerGrid
            // 
            _packagerGrid.AllowUserToResizeColumns = false;
            _packagerGrid.AllowUserToResizeRows = false;
            _packagerGrid.ColumnHeadersHeight = 29;
            _packagerGrid.Dock = DockStyle.Fill;
            _packagerGrid.Location = new Point(3, 29);
            _packagerGrid.Margin = new Padding(3, 2, 3, 2);
            _packagerGrid.Name = "_packagerGrid";
            _packagerGrid.RowHeadersWidth = 51;
            _packagerGrid.Size = new Size(281, 213);
            _packagerGrid.TabIndex = 1;
            // 
            // _lblSel
            // 
            _lblSel.Dock = DockStyle.Bottom;
            _lblSel.Location = new Point(3, 252);
            _lblSel.Name = "_lblSel";
            _lblSel.Size = new Size(281, 20);
            _lblSel.TabIndex = 2;
            _lblSel.Text = "انقر على أي طلب من القائمة لتعيينه وطباعته.";
            _lblSel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // rightHeader
            // 
            rightHeader.Dock = DockStyle.Top;
            rightHeader.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            rightHeader.ForeColor = Color.FromArgb(31, 45, 47);
            rightHeader.Location = new Point(7, 34);
            rightHeader.Name = "rightHeader";
            rightHeader.Padding = new Padding(0, 0, 16, 0);
            rightHeader.Size = new Size(669, 30);
            rightHeader.TabIndex = 4;
            rightHeader.Text = "الطلبات المعلقة";
            rightHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // leftHeader
            // 
            leftHeader.Dock = DockStyle.Top;
            leftHeader.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            leftHeader.ForeColor = Color.FromArgb(31, 45, 47);
            leftHeader.Location = new Point(3, 0);
            leftHeader.Name = "leftHeader";
            leftHeader.Padding = new Padding(0, 0, 16, 0);
            leftHeader.Size = new Size(281, 27);
            leftHeader.TabIndex = 0;
            leftHeader.Text = "جدول التكليف";
            leftHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(255, 255, 255);
            headerPanel.Controls.Add(h1Label);
            headerPanel.Controls.Add(sepBar);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(3, 2, 3, 2);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1003, 63);
            headerPanel.TabIndex = 0;
            // 
            // h1Label
            // 
            h1Label.Dock = DockStyle.Fill;
            h1Label.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            h1Label.ForeColor = Color.FromArgb(36, 36, 36);
            h1Label.Location = new Point(0, 0);
            h1Label.Name = "h1Label";
            h1Label.Padding = new Padding(0, 0, 14, 0);
            h1Label.Size = new Size(1003, 61);
            h1Label.TabIndex = 0;
            h1Label.Text = "📦  مركز التوزيع";
            h1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sepBar
            // 
            sepBar.BackColor = Color.FromArgb(100, 158, 100);
            sepBar.Dock = DockStyle.Bottom;
            sepBar.Location = new Point(0, 61);
            sepBar.Margin = new Padding(3, 2, 3, 2);
            sepBar.Name = "sepBar";
            sepBar.Size = new Size(1003, 2);
            sepBar.TabIndex = 1;
            // 
            // topBar
            // 
            topBar.BackColor = Color.FromArgb(247, 246, 242);
            topBar.ColumnCount = 3;
            topBar.ColumnStyles.Add(new ColumnStyle());
            topBar.ColumnStyles.Add(new ColumnStyle());
            topBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            topBar.Controls.Add(btnAuto, 0, 0);
            topBar.Controls.Add(btnManualAll, 1, 0);
            topBar.Dock = DockStyle.Top;
            topBar.Location = new Point(0, 63);
            topBar.Margin = new Padding(3, 2, 3, 2);
            topBar.Name = "topBar";
            topBar.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            topBar.Size = new Size(1003, 42);
            topBar.TabIndex = 1;
            // 
            // btnAuto
            // 
            btnAuto.BackColor = Color.FromArgb(68, 125, 175);
            btnAuto.FlatStyle = FlatStyle.Flat;
            btnAuto.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnAuto.ForeColor = Color.White;
            btnAuto.Location = new Point(845, 8);
            btnAuto.Margin = new Padding(9, 8, 14, 0);
            btnAuto.Name = "btnAuto";
            btnAuto.Radius = 6;
            btnAuto.Size = new Size(149, 26);
            btnAuto.TabIndex = 0;
            btnAuto.Text = "🤖 التكليف التلقائي";
            btnAuto.UseVisualStyleBackColor = false;
            btnAuto.Click += BtnAuto_Click;
            // 
            // btnManualAll
            // 
            btnManualAll.BackColor = Color.FromArgb(190, 145, 75);
            btnManualAll.FlatStyle = FlatStyle.Flat;
            btnManualAll.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnManualAll.ForeColor = Color.White;
            btnManualAll.Location = new Point(673, 8);
            btnManualAll.Margin = new Padding(9, 8, 0, 0);
            btnManualAll.Name = "btnManualAll";
            btnManualAll.Radius = 6;
            btnManualAll.Size = new Size(149, 26);
            btnManualAll.TabIndex = 1;
            btnManualAll.Text = "✍ تكليف الكل يدوياً";
            btnManualAll.UseVisualStyleBackColor = false;
            btnManualAll.Click += BtnManualAll_Click;
            // 
            // bodyTable
            // 
            bodyTable.BackColor = Color.FromArgb(247, 246, 242);
            bodyTable.ColumnCount = 2;
            bodyTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            bodyTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            bodyTable.Controls.Add(leftPanel, 1, 0);
            bodyTable.Controls.Add(rightPanel, 0, 0);
            bodyTable.Dock = DockStyle.Fill;
            bodyTable.Location = new Point(0, 105);
            bodyTable.Margin = new Padding(3, 2, 3, 2);
            bodyTable.Name = "bodyTable";
            bodyTable.Padding = new Padding(14, 18, 14, 12);
            bodyTable.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            bodyTable.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            bodyTable.Size = new Size(1003, 306);
            bodyTable.TabIndex = 2;
            // 
            // leftPanel
            // 
            leftPanel.ColumnCount = 1;
            leftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftPanel.Controls.Add(leftHeader, 0, 0);
            leftPanel.Controls.Add(_packagerGrid, 0, 1);
            leftPanel.Controls.Add(_lblSel, 0, 2);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(17, 20);
            leftPanel.Margin = new Padding(3, 2, 3, 2);
            leftPanel.Name = "leftPanel";
            leftPanel.RowCount = 3;
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            leftPanel.Size = new Size(287, 272);
            leftPanel.TabIndex = 0;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.FromArgb(247, 246, 242);
            rightPanel.Controls.Add(_pendingGrid);
            rightPanel.Controls.Add(rightHeader);
            rightPanel.Controls.Add(tabs);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(310, 20);
            rightPanel.Margin = new Padding(3, 2, 3, 2);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(7, 0, 0, 0);
            rightPanel.Size = new Size(676, 272);
            rightPanel.TabIndex = 0;
            // 
            // tabs
            // 
            tabs.Controls.Add(_btnToday);
            tabs.Controls.Add(_btnTomorrow);
            tabs.Dock = DockStyle.Top;
            tabs.Location = new Point(7, 0);
            tabs.Margin = new Padding(3, 2, 3, 2);
            tabs.Name = "tabs";
            tabs.RightToLeft = RightToLeft.Yes;
            tabs.Size = new Size(669, 34);
            tabs.TabIndex = 3;
            // 
            // _btnToday
            // 
            _btnToday.BackColor = Color.FromArgb(53, 133, 142);
            _btnToday.FlatStyle = FlatStyle.Flat;
            _btnToday.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            _btnToday.ForeColor = Color.White;
            _btnToday.Location = new Point(547, 0);
            _btnToday.Margin = new Padding(0, 0, 7, 6);
            _btnToday.Name = "_btnToday";
            _btnToday.Radius = 6;
            _btnToday.Size = new Size(122, 27);
            _btnToday.TabIndex = 0;
            _btnToday.Text = "📅 طلبات اليوم";
            _btnToday.UseVisualStyleBackColor = false;
            _btnToday.Click += _btnToday_Click;
            // 
            // _btnTomorrow
            // 
            _btnTomorrow.BackColor = Color.FromArgb(53, 133, 142);
            _btnTomorrow.FlatStyle = FlatStyle.Flat;
            _btnTomorrow.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            _btnTomorrow.ForeColor = Color.White;
            _btnTomorrow.Location = new Point(418, 0);
            _btnTomorrow.Margin = new Padding(0, 0, 7, 6);
            _btnTomorrow.Name = "_btnTomorrow";
            _btnTomorrow.Radius = 6;
            _btnTomorrow.Size = new Size(122, 27);
            _btnTomorrow.TabIndex = 1;
            _btnTomorrow.Text = "📆 طلبات الغد";
            _btnTomorrow.UseVisualStyleBackColor = false;
            _btnTomorrow.Click += _btnTomorrow_Click;
            // 
            // DelegationHubControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 246, 242);
            Controls.Add(bodyTable);
            Controls.Add(topBar);
            Controls.Add(headerPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DelegationHubControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1003, 411);
            ((System.ComponentModel.ISupportInitialize)_pendingGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)_packagerGrid).EndInit();
            headerPanel.ResumeLayout(false);
            topBar.ResumeLayout(false);
            bodyTable.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            tabs.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label h1Label;
        private System.Windows.Forms.Panel sepBar;
        private System.Windows.Forms.TableLayoutPanel topBar;
        private sweetSystem.FlatButton btnAuto;
        private sweetSystem.FlatButton btnManualAll;
        private System.Windows.Forms.TableLayoutPanel bodyTable;
        private Panel rightPanel;
        private TableLayoutPanel leftPanel;
        private Label _lblSel;
        private sweetSystem.FlatButton _btnToday;
        private sweetSystem.FlatButton _btnTomorrow;
        private FlowLayoutPanel tabs;
        private DataGridView _pendingGrid = null!;
        private DataGridView _packagerGrid = null!;
        private sweetSystem.SectionHeader rightHeader;
        private sweetSystem.SectionHeader leftHeader;
    }
}
