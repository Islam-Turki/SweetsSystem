namespace sweetSystem.UserControls
{
    partial class WholesaleClientsControl
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
            topBar = new TableLayoutPanel();
            _txSearch = new TextBox();
            _cbFilter = new ComboBox();
            spacer = new Panel();
            btnAdd = new FlatButton();
            sumBar = new Panel();
            _lblTotalBal = new Label();
            bodyPanel = new Panel();
            _grid = new DataGridView();
            headerPanel.SuspendLayout();
            topBar.SuspendLayout();
            sumBar.SuspendLayout();
            bodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
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
            headerPanel.Size = new Size(586, 84);
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
            h1Label.Size = new Size(586, 82);
            h1Label.TabIndex = 0;
            h1Label.Text = "🏪  عملاء الجملة";
            h1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sepBar
            // 
            sepBar.BackColor = Color.FromArgb(100, 158, 100);
            sepBar.Dock = DockStyle.Bottom;
            sepBar.Location = new Point(0, 82);
            sepBar.Name = "sepBar";
            sepBar.Size = new Size(586, 2);
            sepBar.TabIndex = 1;
            // 
            // topBar
            // 
            topBar.BackColor = Color.FromArgb(247, 246, 242);
            topBar.ColumnCount = 4;
            topBar.ColumnStyles.Add(new ColumnStyle());
            topBar.ColumnStyles.Add(new ColumnStyle());
            topBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            topBar.ColumnStyles.Add(new ColumnStyle());
            topBar.Controls.Add(_txSearch, 0, 0);
            topBar.Controls.Add(_cbFilter, 1, 0);
            topBar.Controls.Add(spacer, 2, 0);
            topBar.Controls.Add(btnAdd, 3, 0);
            topBar.Dock = DockStyle.Top;
            topBar.Location = new Point(0, 84);
            topBar.Name = "topBar";
            topBar.RowCount = 1;
            topBar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            topBar.Size = new Size(586, 60);
            topBar.TabIndex = 1;
            // 
            // _txSearch
            // 
            _txSearch.Font = new Font("Cairo", 9F);
            _txSearch.Location = new Point(320, 12);
            _txSearch.Margin = new Padding(16, 12, 0, 0);
            _txSearch.Name = "_txSearch";
            _txSearch.PlaceholderText = "🔍 بحث باسم العميل أو الهاتف...";
            _txSearch.Size = new Size(250, 36);
            _txSearch.TabIndex = 0;
            // 
            // _cbFilter
            // 
            _cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbFilter.FlatStyle = FlatStyle.Flat;
            _cbFilter.Font = new Font("Cairo", 9F);
            _cbFilter.Items.AddRange(new object[] { "الكل", "مدين (عليه رصيد)", "خالص (لا يوجد رصيد)" });
            _cbFilter.Location = new Point(160, 12);
            _cbFilter.Margin = new Padding(10, 12, 0, 0);
            _cbFilter.Name = "_cbFilter";
            _cbFilter.Size = new Size(150, 37);
            _cbFilter.TabIndex = 1;
            _cbFilter.SelectedIndexChanged += CbFilter_SelectedIndexChanged;
            // 
            // spacer
            // 
            spacer.Dock = DockStyle.Fill;
            spacer.Location = new Point(179, 3);
            spacer.Name = "spacer";
            spacer.Size = new Size(1, 54);
            spacer.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(100, 158, 100);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Cairo", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(16, 10);
            btnAdd.Margin = new Padding(0, 10, 16, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Radius = 6;
            btnAdd.Size = new Size(160, 34);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "＋ إضافة عميل جملة";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // sumBar
            // 
            sumBar.BackColor = Color.FromArgb(255, 255, 255);
            sumBar.Controls.Add(_lblTotalBal);
            sumBar.Dock = DockStyle.Top;
            sumBar.Location = new Point(0, 144);
            sumBar.Name = "sumBar";
            sumBar.Padding = new Padding(16, 0, 16, 0);
            sumBar.Size = new Size(586, 45);
            sumBar.TabIndex = 2;
            // 
            // _lblTotalBal
            // 
            _lblTotalBal.Dock = DockStyle.Fill;
            _lblTotalBal.Font = new Font("Cairo", 11F, FontStyle.Bold);
            _lblTotalBal.ForeColor = Color.FromArgb(196, 68, 68);
            _lblTotalBal.Location = new Point(16, 0);
            _lblTotalBal.Name = "_lblTotalBal";
            _lblTotalBal.Size = new Size(554, 45);
            _lblTotalBal.TabIndex = 0;
            _lblTotalBal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bodyPanel
            // 
            bodyPanel.Controls.Add(_grid);
            bodyPanel.Dock = DockStyle.Fill;
            bodyPanel.Location = new Point(0, 189);
            bodyPanel.Name = "bodyPanel";
            bodyPanel.Padding = new Padding(16, 8, 16, 16);
            bodyPanel.Size = new Size(586, 329);
            bodyPanel.TabIndex = 3;
            // 
            // _grid
            // 
            _grid.ColumnHeadersHeight = 29;
            _grid.Dock = DockStyle.Fill;
            _grid.Location = new Point(16, 8);
            _grid.Name = "_grid";
            _grid.RowHeadersWidth = 51;
            _grid.Size = new Size(554, 305);
            _grid.TabIndex = 0;
            // 
            // WholesaleClientsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 246, 242);
            Controls.Add(bodyPanel);
            Controls.Add(sumBar);
            Controls.Add(topBar);
            Controls.Add(headerPanel);
            Name = "WholesaleClientsControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(586, 518);
            headerPanel.ResumeLayout(false);
            topBar.ResumeLayout(false);
            topBar.PerformLayout();
            sumBar.ResumeLayout(false);
            bodyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label h1Label;
        private System.Windows.Forms.Panel sepBar;
        private System.Windows.Forms.TableLayoutPanel topBar;
        private System.Windows.Forms.TextBox _txSearch;
        private System.Windows.Forms.ComboBox _cbFilter;
        private System.Windows.Forms.Panel spacer;
        private sweetSystem.FlatButton btnAdd;
        private System.Windows.Forms.Panel sumBar;
        private System.Windows.Forms.Label _lblTotalBal;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.DataGridView _grid;
    }
}
