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
            headerPanel = new Panel();
            h1Label = new Label();
            sepBar = new Panel();
            topBar = new TableLayoutPanel();
            btnAuto = new FlatButton();
            btnManualAll = new FlatButton();
            bodyTable = new TableLayoutPanel();
            rightPanel = new Panel();
            leftPanel = new Panel();
            headerPanel.SuspendLayout();
            topBar.SuspendLayout();
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
            h1Label.Text = "📦  مركز التوزيع";
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
            topBar.ColumnCount = 3;
            topBar.ColumnStyles.Add(new ColumnStyle());
            topBar.ColumnStyles.Add(new ColumnStyle());
            topBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            topBar.Controls.Add(btnAuto, 0, 0);
            topBar.Controls.Add(btnManualAll, 1, 0);
            topBar.Dock = DockStyle.Top;
            topBar.Location = new Point(0, 84);
            topBar.Name = "topBar";
            topBar.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            topBar.Size = new Size(1146, 56);
            topBar.TabIndex = 1;
            // 
            // btnAuto
            // 
            btnAuto.BackColor = Color.FromArgb(68, 125, 175);
            btnAuto.FlatStyle = FlatStyle.Flat;
            btnAuto.Font = new Font("Cairo", 9F, FontStyle.Bold);
            btnAuto.ForeColor = Color.White;
            btnAuto.Location = new Point(966, 10);
            btnAuto.Margin = new Padding(10, 10, 16, 0);
            btnAuto.Name = "btnAuto";
            btnAuto.Radius = 6;
            btnAuto.Size = new Size(170, 34);
            btnAuto.TabIndex = 0;
            btnAuto.Text = "🤖 التكليف التلقائي";
            btnAuto.UseVisualStyleBackColor = false;
            btnAuto.Click += BtnAuto_Click;
            // 
            // btnManualAll
            // 
            btnManualAll.BackColor = Color.FromArgb(190, 145, 75);
            btnManualAll.FlatStyle = FlatStyle.Flat;
            btnManualAll.Font = new Font("Cairo", 9F, FontStyle.Bold);
            btnManualAll.ForeColor = Color.White;
            btnManualAll.Location = new Point(770, 10);
            btnManualAll.Margin = new Padding(10, 10, 0, 0);
            btnManualAll.Name = "btnManualAll";
            btnManualAll.Radius = 6;
            btnManualAll.Size = new Size(170, 34);
            btnManualAll.TabIndex = 1;
            btnManualAll.Text = "✍ تكليف الكل يدوياً";
            btnManualAll.UseVisualStyleBackColor = false;
            btnManualAll.Click += BtnManualAll_Click;
            // 
            // bodyTable
            // 
            bodyTable.BackColor = Color.FromArgb(247, 246, 242);
            bodyTable.ColumnCount = 2;
            bodyTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            bodyTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            bodyTable.Controls.Add(rightPanel, 0, 0);
            bodyTable.Controls.Add(leftPanel, 1, 0);
            bodyTable.Dock = DockStyle.Fill;
            bodyTable.Location = new Point(0, 140);
            bodyTable.Name = "bodyTable";
            bodyTable.Padding = new Padding(16, 24, 16, 16);
            bodyTable.RowCount = 1;
            bodyTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bodyTable.Size = new Size(1146, 408);
            bodyTable.TabIndex = 2;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.FromArgb(247, 246, 242);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(465, 27);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(8, 0, 0, 0);
            rightPanel.Size = new Size(662, 362);
            rightPanel.TabIndex = 0;
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(247, 246, 242);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(19, 27);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(8);
            leftPanel.Size = new Size(440, 362);
            leftPanel.TabIndex = 1;
            // 
            // DelegationHubControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 246, 242);
            Controls.Add(bodyTable);
            Controls.Add(topBar);
            Controls.Add(headerPanel);
            Name = "DelegationHubControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1146, 548);
            headerPanel.ResumeLayout(false);
            topBar.ResumeLayout(false);
            bodyTable.ResumeLayout(false);
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
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel leftPanel;
    }
}
