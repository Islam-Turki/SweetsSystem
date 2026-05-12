using sweetSystem;
namespace sweetSystem.UserControls
{
    partial class DashboardControl
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
            cardRowPanel = new FlowLayoutPanel();
            _cOrders = new StatCard();
            _cPending = new StatCard();
            _cRevenue = new StatCard();
            _cClients = new StatCard();
            _btnToday = new FlatButton();
            _btnTomorrow = new FlatButton();
            bodyPanel = new Panel();
            _grid = new DataGridView();
            secLabel = new SectionHeader();
            headerPanel.SuspendLayout();
            cardRowPanel.SuspendLayout();
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
            h1Label.Dock = DockStyle.Right;
            h1Label.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            h1Label.ForeColor = Color.FromArgb(36, 36, 36);
            h1Label.Location = new Point(0, 0);
            h1Label.Name = "h1Label";
            h1Label.Padding = new Padding(0, 0, 16, 0);
            h1Label.Size = new Size(1146, 81);
            h1Label.TabIndex = 0;
            h1Label.Text = "📊  لوحة التحكم";
            h1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sepBar
            // 
            sepBar.BackColor = Color.FromArgb(100, 158, 100);
            sepBar.Dock = DockStyle.Bottom;
            sepBar.Location = new Point(0, 81);
            sepBar.Name = "sepBar";
            sepBar.Size = new Size(1146, 3);
            sepBar.TabIndex = 1;
            // 
            // cardRowPanel
            // 
            cardRowPanel.BackColor = Color.FromArgb(247, 246, 242);
            cardRowPanel.Controls.Add(_cOrders);
            cardRowPanel.Controls.Add(_cPending);
            cardRowPanel.Controls.Add(_cRevenue);
            cardRowPanel.Controls.Add(_cClients);
            cardRowPanel.Dock = DockStyle.Top;
            cardRowPanel.FlowDirection = FlowDirection.RightToLeft;
            cardRowPanel.Location = new Point(0, 84);
            cardRowPanel.Name = "cardRowPanel";
            cardRowPanel.Padding = new Padding(16, 11, 16, 0);
            cardRowPanel.RightToLeft = RightToLeft.No;
            cardRowPanel.Size = new Size(1146, 130);
            cardRowPanel.TabIndex = 2;
            cardRowPanel.WrapContents = false;
            // 
            // _cOrders
            // 
            _cOrders.AccentColor = Color.FromArgb(100, 158, 100);
            _cOrders.BackColor = Color.FromArgb(255, 255, 255);
            _cOrders.Location = new Point(909, 11);
            _cOrders.Margin = new Padding(0, 0, 10, 0);
            _cOrders.Name = "_cOrders";
            _cOrders.Size = new Size(195, 108);
            _cOrders.SubText = "نص فرعي";
            _cOrders.TabIndex = 0;
            _cOrders.Title = "العنوان";
            _cOrders.Value = "—";
            _cOrders.Paint += _cOrders_Paint;
            // 
            // _cPending
            // 
            _cPending.AccentColor = Color.FromArgb(100, 158, 100);
            _cPending.BackColor = Color.FromArgb(255, 255, 255);
            _cPending.Location = new Point(704, 11);
            _cPending.Margin = new Padding(0, 0, 10, 0);
            _cPending.Name = "_cPending";
            _cPending.Size = new Size(195, 108);
            _cPending.SubText = "نص فرعي";
            _cPending.TabIndex = 1;
            _cPending.Title = "العنوان";
            _cPending.Value = "—";
            // 
            // _cRevenue
            // 
            _cRevenue.AccentColor = Color.FromArgb(100, 158, 100);
            _cRevenue.BackColor = Color.FromArgb(255, 255, 255);
            _cRevenue.Location = new Point(499, 11);
            _cRevenue.Margin = new Padding(0, 0, 10, 0);
            _cRevenue.Name = "_cRevenue";
            _cRevenue.Size = new Size(195, 108);
            _cRevenue.SubText = "نص فرعي";
            _cRevenue.TabIndex = 2;
            _cRevenue.Title = "العنوان";
            _cRevenue.Value = "—";
            // 
            // _cClients
            // 
            _cClients.AccentColor = Color.FromArgb(100, 158, 100);
            _cClients.BackColor = Color.FromArgb(255, 255, 255);
            _cClients.Location = new Point(294, 11);
            _cClients.Margin = new Padding(0, 0, 10, 0);
            _cClients.Name = "_cClients";
            _cClients.Size = new Size(195, 108);
            _cClients.SubText = "نص فرعي";
            _cClients.TabIndex = 3;
            _cClients.Title = "العنوان";
            _cClients.Value = "—";
            // 
            // _btnToday
            // 
            _btnToday.BackColor = Color.FromArgb(53, 133, 142);
            _btnToday.FlatStyle = FlatStyle.Flat;
            _btnToday.Font = new Font("Cairo", 8F, FontStyle.Bold);
            _btnToday.ForeColor = Color.White;
            _btnToday.Location = new Point(16, 214);
            _btnToday.Margin = new Padding(3, 4, 3, 4);
            _btnToday.Name = "_btnToday";
            _btnToday.Radius = 6;
            _btnToday.Size = new Size(91, 35);
            _btnToday.TabIndex = 0;
            _btnToday.Text = "اليوم";
            _btnToday.UseVisualStyleBackColor = false;
            // 
            // _btnTomorrow
            // 
            _btnTomorrow.BackColor = Color.FromArgb(180, 180, 180);
            _btnTomorrow.FlatStyle = FlatStyle.Flat;
            _btnTomorrow.Font = new Font("Cairo", 8F, FontStyle.Bold);
            _btnTomorrow.ForeColor = Color.White;
            _btnTomorrow.Location = new Point(113, 214);
            _btnTomorrow.Margin = new Padding(3, 4, 3, 4);
            _btnTomorrow.Name = "_btnTomorrow";
            _btnTomorrow.Radius = 6;
            _btnTomorrow.Size = new Size(91, 35);
            _btnTomorrow.TabIndex = 1;
            _btnTomorrow.Text = "الغد";
            _btnTomorrow.UseVisualStyleBackColor = false;
            // 
            // bodyPanel
            // 
            bodyPanel.Controls.Add(_grid);
            bodyPanel.Dock = DockStyle.Fill;
            bodyPanel.Location = new Point(0, 255);
            bodyPanel.Name = "bodyPanel";
            bodyPanel.Padding = new Padding(16);
            bodyPanel.Size = new Size(1146, 293);
            bodyPanel.TabIndex = 4;
            // 
            // _grid
            // 
            _grid.AllowUserToResizeColumns = false;
            _grid.AllowUserToResizeRows = false;
            _grid.ColumnHeadersHeight = 29;
            _grid.Dock = DockStyle.Fill;
            _grid.Location = new Point(16, 16);
            _grid.Name = "_grid";
            _grid.RightToLeft = RightToLeft.No;
            _grid.RowHeadersWidth = 51;
            _grid.Size = new Size(1114, 261);
            _grid.TabIndex = 0;
            // 
            // secLabel
            // 
            secLabel.Dock = DockStyle.Top;
            secLabel.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            secLabel.ForeColor = Color.FromArgb(36, 36, 36);
            secLabel.Location = new Point(0, 214);
            secLabel.Name = "secLabel";
            secLabel.Padding = new Padding(0, 3, 5, 3);
            secLabel.RightToLeft = RightToLeft.No;
            secLabel.Size = new Size(1146, 41);
            secLabel.TabIndex = 3;
            secLabel.Text = "آخر الطلبات";
            secLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 246, 242);
            Controls.Add(_btnToday);
            Controls.Add(bodyPanel);
            Controls.Add(_btnTomorrow);
            Controls.Add(secLabel);
            Controls.Add(cardRowPanel);
            Controls.Add(headerPanel);
            Name = "DashboardControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1146, 548);
            headerPanel.ResumeLayout(false);
            cardRowPanel.ResumeLayout(false);
            bodyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label h1Label;
        private System.Windows.Forms.Panel sepBar;
        private System.Windows.Forms.FlowLayoutPanel cardRowPanel;
        private sweetSystem.StatCard _cOrders;
        private sweetSystem.StatCard _cPending;
        private sweetSystem.StatCard _cRevenue;
        private sweetSystem.StatCard _cClients;
        private sweetSystem.SectionHeader secLabel;
        private sweetSystem.FlatButton _btnToday;
        private sweetSystem.FlatButton _btnTomorrow;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.DataGridView _grid;
    }
}
