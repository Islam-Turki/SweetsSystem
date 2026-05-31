using sweetSystem;
namespace sweetSystem.UserControls
{
    partial class EmployeeHRControl
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
            bodyPanel = new Panel();
            _grid = new DataGridView();
            headerPanel.SuspendLayout();
            topBar.SuspendLayout();
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
            h1Label.Text = "👥  الموارد البشرية";
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
            topBar.Size = new Size(1146, 60);
            topBar.TabIndex = 1;
            // 
            // _txSearch
            // 
            _txSearch.Font = new Font("Cairo", 9F);
            _txSearch.Location = new Point(880, 12);
            _txSearch.Margin = new Padding(16, 12, 0, 0);
            _txSearch.Name = "_txSearch";
            _txSearch.PlaceholderText = "🔍 بحث بالاسم...";
            _txSearch.Size = new Size(250, 36);
            _txSearch.TabIndex = 0;
            // 
            // _cbFilter
            // 
            _cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbFilter.FlatStyle = FlatStyle.Flat;
            _cbFilter.Font = new Font("Cairo", 9F);
            _cbFilter.Items.AddRange(new object[] { "الكل", "طباخ", "معبّئ" });
            _cbFilter.Location = new Point(720, 12);
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
            spacer.Size = new Size(538, 54);
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
            btnAdd.Text = "＋ إضافة موظف جديد";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // bodyPanel
            // 
            bodyPanel.Controls.Add(_grid);
            bodyPanel.Dock = DockStyle.Fill;
            bodyPanel.Location = new Point(0, 144);
            bodyPanel.Name = "bodyPanel";
            bodyPanel.Padding = new Padding(16, 8, 16, 16);
            bodyPanel.Size = new Size(1146, 404);
            bodyPanel.TabIndex = 2;
            // 
            // _grid
            // 
            _grid.AllowUserToOrderColumns = true;
            _grid.AllowUserToResizeColumns = false;
            _grid.AllowUserToResizeRows = false;
            _grid.ColumnHeadersHeight = 29;
            _grid.Dock = DockStyle.Fill;
            _grid.Location = new Point(16, 8);
            _grid.Name = "_grid";
            _grid.RowHeadersWidth = 51;
            _grid.Size = new Size(1114, 380);
            _grid.TabIndex = 0;
            // 
            // EmployeeHRControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 246, 242);
            Controls.Add(bodyPanel);
            Controls.Add(topBar);
            Controls.Add(headerPanel);
            Name = "EmployeeHRControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1146, 548);
            headerPanel.ResumeLayout(false);
            topBar.ResumeLayout(false);
            topBar.PerformLayout();
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
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.DataGridView _grid;
    }
}
