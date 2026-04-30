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
            leftPanel = new Panel();
            headerPanel.SuspendLayout();
            bodyTable.SuspendLayout();
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
            h1Label.TextAlign = ContentAlignment.MiddleRight;
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
            bodyTable.Size = new Size(1146, 464);
            bodyTable.TabIndex = 1;
            // 
            // rightPanel
            // 
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(521, 27);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(8, 0, 0, 0);
            rightPanel.Size = new Size(606, 418);
            rightPanel.TabIndex = 0;
            // 
            // leftPanel
            // 
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(19, 27);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(0, 0, 8, 0);
            leftPanel.Size = new Size(496, 418);
            leftPanel.TabIndex = 1;
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
            Size = new Size(1146, 548);
            headerPanel.ResumeLayout(false);
            bodyTable.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label h1Label;
        private System.Windows.Forms.Panel sepBar;
        private System.Windows.Forms.TableLayoutPanel bodyTable;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel leftPanel;
    }
}
