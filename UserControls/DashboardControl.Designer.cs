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
            headerPanel.Margin = new Padding(3, 2, 3, 2);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1003, 63);
            headerPanel.TabIndex = 0;
            // 
            // h1Label
            // 
            h1Label.Dock = DockStyle.Right;
            h1Label.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            h1Label.ForeColor = Color.FromArgb(36, 36, 36);
            h1Label.Location = new Point(0, 0);
            h1Label.Name = "h1Label";
            h1Label.Padding = new Padding(0, 0, 14, 0);
            h1Label.Size = new Size(1003, 61);
            h1Label.TabIndex = 0;
            h1Label.Text = "📊  لوحة التحكم";
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
            // cardRowPanel
            // 
            cardRowPanel.BackColor = Color.FromArgb(247, 246, 242);
            cardRowPanel.Controls.Add(_cOrders);
            cardRowPanel.Controls.Add(_cPending);
            cardRowPanel.Controls.Add(_cRevenue);
            cardRowPanel.Controls.Add(_cClients);
            cardRowPanel.Dock = DockStyle.Top;
            cardRowPanel.FlowDirection = FlowDirection.RightToLeft;
            cardRowPanel.Location = new Point(0, 63);
            cardRowPanel.Margin = new Padding(3, 2, 3, 2);
            cardRowPanel.Name = "cardRowPanel";
            cardRowPanel.Padding = new Padding(14, 8, 14, 0);
            cardRowPanel.RightToLeft = RightToLeft.No;
            cardRowPanel.Size = new Size(1003, 84);
            cardRowPanel.TabIndex = 2;
            cardRowPanel.WrapContents = false;
            // 
            // _cOrders
            // 
            _cOrders.AccentColor = Color.FromArgb(100, 158, 100);
            _cOrders.BackColor = Color.FromArgb(255, 255, 255);
            _cOrders.Location = new Point(795, 8);
            _cOrders.Margin = new Padding(0, 0, 9, 0);
            _cOrders.Name = "_cOrders";
            _cOrders.Size = new Size(171, 71);
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
            _cPending.Location = new Point(615, 8);
            _cPending.Margin = new Padding(0, 0, 9, 0);
            _cPending.Name = "_cPending";
            _cPending.Size = new Size(171, 71);
            _cPending.SubText = "نص فرعي";
            _cPending.TabIndex = 1;
            _cPending.Title = "العنوان";
            _cPending.Value = "—";
            // 
            // _cRevenue
            // 
            _cRevenue.AccentColor = Color.FromArgb(100, 158, 100);
            _cRevenue.BackColor = Color.FromArgb(255, 255, 255);
            _cRevenue.Location = new Point(435, 8);
            _cRevenue.Margin = new Padding(0, 0, 9, 0);
            _cRevenue.Name = "_cRevenue";
            _cRevenue.Size = new Size(171, 71);
            _cRevenue.SubText = "نص فرعي";
            _cRevenue.TabIndex = 2;
            _cRevenue.Title = "العنوان";
            _cRevenue.Value = "—";
            // 
            // _cClients
            // 
            _cClients.AccentColor = Color.FromArgb(100, 158, 100);
            _cClients.BackColor = Color.FromArgb(255, 255, 255);
            _cClients.Location = new Point(255, 8);
            _cClients.Margin = new Padding(0, 0, 9, 0);
            _cClients.Name = "_cClients";
            _cClients.Size = new Size(171, 71);
            _cClients.SubText = "نص فرعي";
            _cClients.TabIndex = 3;
            _cClients.Title = "العنوان";
            _cClients.Value = "—";
            // 
            // bodyPanel
            // 
            bodyPanel.Controls.Add(_grid);
            bodyPanel.Dock = DockStyle.Fill;
            bodyPanel.Location = new Point(0, 178);
            bodyPanel.Margin = new Padding(3, 2, 3, 2);
            bodyPanel.Name = "bodyPanel";
            bodyPanel.Padding = new Padding(14, 12, 14, 12);
            bodyPanel.Size = new Size(1003, 233);
            bodyPanel.TabIndex = 4;
            // 
            // _grid
            // 
            _grid.AllowUserToResizeColumns = false;
            _grid.AllowUserToResizeRows = false;
            _grid.ColumnHeadersHeight = 29;
            _grid.Dock = DockStyle.Fill;
            _grid.Location = new Point(14, 12);
            _grid.Margin = new Padding(3, 2, 3, 2);
            _grid.Name = "_grid";
            _grid.RightToLeft = RightToLeft.No;
            _grid.RowHeadersWidth = 51;
            _grid.Size = new Size(975, 209);
            _grid.TabIndex = 0;
            // 
            // secLabel
            // 
            secLabel.Dock = DockStyle.Top;
            secLabel.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            secLabel.ForeColor = Color.FromArgb(36, 36, 36);
            secLabel.Location = new Point(0, 147);
            secLabel.Name = "secLabel";
            secLabel.Padding = new Padding(0, 2, 4, 2);
            secLabel.RightToLeft = RightToLeft.No;
            secLabel.Size = new Size(1003, 31);
            secLabel.TabIndex = 3;
            secLabel.Text = "آخر الطلبات";
            secLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 246, 242);
            Controls.Add(bodyPanel);
            Controls.Add(secLabel);
            Controls.Add(cardRowPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DashboardControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1003, 411);
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
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.DataGridView _grid;
    }
}
