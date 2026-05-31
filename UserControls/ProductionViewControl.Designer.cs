using sweetSystem;
namespace sweetSystem.UserControls
{
    partial class ProductionViewControl
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
            toolbar = new Panel();
            _lblDateBadge = new Label();
            _btnPrint = new FlatButton();
            _btnTomorrow = new FlatButton();
            _btnToday = new FlatButton();
            bodyPanel = new Panel();
            _grid = new DataGridView();
            headerPanel.SuspendLayout();
            toolbar.SuspendLayout();
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
            h1Label.Text = "🍳  عرض الإنتاج ";
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
            // toolbar
            // 
            toolbar.BackColor = Color.FromArgb(255, 255, 255);
            toolbar.Controls.Add(_lblDateBadge);
            toolbar.Controls.Add(_btnPrint);
            toolbar.Controls.Add(_btnTomorrow);
            toolbar.Controls.Add(_btnToday);
            toolbar.Dock = DockStyle.Top;
            toolbar.Location = new Point(0, 84);
            toolbar.Name = "toolbar";
            toolbar.Padding = new Padding(16, 8, 16, 8);
            toolbar.Size = new Size(1146, 55);
            toolbar.TabIndex = 1;
            toolbar.Resize += Toolbar_Resize;
            // 
            // _lblDateBadge
            // 
            _lblDateBadge.AutoSize = true;
            _lblDateBadge.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _lblDateBadge.ForeColor = Color.FromArgb(190, 145, 75);
            _lblDateBadge.Location = new Point(230, 15);
            _lblDateBadge.Name = "_lblDateBadge";
            _lblDateBadge.Size = new Size(0, 29);
            _lblDateBadge.TabIndex = 3;
            // 
            // _btnPrint
            // 
            _btnPrint.BackColor = Color.FromArgb(190, 145, 75);
            _btnPrint.FlatStyle = FlatStyle.Flat;
            _btnPrint.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _btnPrint.ForeColor = Color.White;
            _btnPrint.Location = new Point(8, 10);
            _btnPrint.Name = "_btnPrint";
            _btnPrint.Radius = 6;
            _btnPrint.Size = new Size(195, 34);
            _btnPrint.TabIndex = 2;
            _btnPrint.Text = "🖨 طباعة ورقة الإنتاج";
            _btnPrint.UseVisualStyleBackColor = false;
            // 
            // _btnTomorrow
            // 
            _btnTomorrow.BackColor = Color.FromArgb(108, 108, 98);
            _btnTomorrow.FlatStyle = FlatStyle.Flat;
            _btnTomorrow.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _btnTomorrow.ForeColor = Color.White;
            _btnTomorrow.Location = new Point(0, 10);
            _btnTomorrow.Name = "_btnTomorrow";
            _btnTomorrow.Radius = 6;
            _btnTomorrow.Size = new Size(100, 34);
            _btnTomorrow.TabIndex = 1;
            _btnTomorrow.Text = "📅 الغد";
            _btnTomorrow.UseVisualStyleBackColor = false;
            _btnTomorrow.Click += BtnTomorrow_Click;
            // 
            // _btnToday
            // 
            _btnToday.BackColor = Color.FromArgb(100, 158, 100);
            _btnToday.FlatStyle = FlatStyle.Flat;
            _btnToday.Font = new Font("Cairo", 9F, FontStyle.Bold);
            _btnToday.ForeColor = Color.White;
            _btnToday.Location = new Point(0, 10);
            _btnToday.Name = "_btnToday";
            _btnToday.Radius = 6;
            _btnToday.Size = new Size(100, 34);
            _btnToday.TabIndex = 0;
            _btnToday.Text = "📅 اليوم";
            _btnToday.UseVisualStyleBackColor = false;
            _btnToday.Click += BtnToday_Click;
            // 
            // bodyPanel
            // 
            bodyPanel.Controls.Add(_grid);
            bodyPanel.Dock = DockStyle.Fill;
            bodyPanel.Location = new Point(0, 139);
            bodyPanel.Name = "bodyPanel";
            bodyPanel.Padding = new Padding(16);
            bodyPanel.Size = new Size(1146, 409);
            bodyPanel.TabIndex = 2;
            // 
            // _grid
            // 
            _grid.AllowUserToResizeColumns = false;
            _grid.AllowUserToResizeRows = false;
            _grid.ColumnHeadersHeight = 29;
            _grid.Dock = DockStyle.Fill;
            _grid.Location = new Point(16, 16);
            _grid.Name = "_grid";
            _grid.RowHeadersWidth = 51;
            _grid.Size = new Size(1114, 377);
            _grid.TabIndex = 0;
            // 
            // ProductionViewControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 246, 242);
            Controls.Add(bodyPanel);
            Controls.Add(toolbar);
            Controls.Add(headerPanel);
            Name = "ProductionViewControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1146, 548);
            headerPanel.ResumeLayout(false);
            toolbar.ResumeLayout(false);
            toolbar.PerformLayout();
            bodyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label h1Label;
        private System.Windows.Forms.Panel sepBar;
        private System.Windows.Forms.Panel toolbar;
        private System.Windows.Forms.Label _lblDateBadge;
        private sweetSystem.FlatButton _btnPrint;
        private sweetSystem.FlatButton _btnTomorrow;
        private sweetSystem.FlatButton _btnToday;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.DataGridView _grid;
    }
}
