namespace sweetSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _sidebar = new Panel();
            btnWholesale = new NavButton();
            btnHR = new NavButton();
            btnProdMgmt = new NavButton();
            btnProdView = new NavButton();
            breakLine = new Panel();
            btnOrderMgmt = new NavButton();
            btnDelegation = new NavButton();
            btnOrderEntry = new NavButton();
            btnDashboard = new NavButton();
            sep = new Panel();
            navLabel = new Label();
            logoPanel = new Panel();
            appSub = new Label();
            appName = new Label();
            cake = new Label();
            footer = new Panel();
            footerLabel = new Label();
            _contentArea = new Panel();
            _sidebar.SuspendLayout();
            logoPanel.SuspendLayout();
            footer.SuspendLayout();
            SuspendLayout();
            // 
            // _sidebar
            // 
            _sidebar.BackColor = Color.FromArgb(53, 133, 142);
            _sidebar.Controls.Add(btnWholesale);
            _sidebar.Controls.Add(btnHR);
            _sidebar.Controls.Add(btnProdMgmt);
            _sidebar.Controls.Add(btnProdView);
            _sidebar.Controls.Add(breakLine);
            _sidebar.Controls.Add(btnOrderMgmt);
            _sidebar.Controls.Add(btnDelegation);
            _sidebar.Controls.Add(btnOrderEntry);
            _sidebar.Controls.Add(btnDashboard);
            _sidebar.Controls.Add(sep);
            _sidebar.Controls.Add(navLabel);
            _sidebar.Controls.Add(logoPanel);
            _sidebar.Controls.Add(footer);
            _sidebar.Dock = DockStyle.Left;
            _sidebar.Location = new Point(0, 0);
            _sidebar.Margin = new Padding(4, 5, 4, 5);
            _sidebar.Name = "_sidebar";
            _sidebar.Size = new Size(347, 1055);
            _sidebar.TabIndex = 0;
            // 
            // btnWholesale
            // 
            btnWholesale.Active = false;
            btnWholesale.Dock = DockStyle.Top;
            btnWholesale.Font = new Font("Cairo", 9F, FontStyle.Bold);
            btnWholesale.ForeColor = Color.FromArgb(245, 239, 230);
            btnWholesale.Icon = "🏪";
            btnWholesale.Location = new Point(0, 712);
            btnWholesale.Margin = new Padding(4, 5, 4, 5);
            btnWholesale.Name = "btnWholesale";
            btnWholesale.Size = new Size(347, 71);
            btnWholesale.TabIndex = 11;
            btnWholesale.Text = "عملاء الجملة";
            btnWholesale.TextAlignment = ContentAlignment.MiddleRight;
            btnWholesale.Click += btnWholesale_Click;
            // 
            // btnHR
            // 
            btnHR.Active = false;
            btnHR.Dock = DockStyle.Top;
            btnHR.Font = new Font("Cairo", 9F, FontStyle.Bold);
            btnHR.ForeColor = Color.FromArgb(245, 239, 230);
            btnHR.Icon = "👥";
            btnHR.Location = new Point(0, 641);
            btnHR.Margin = new Padding(4, 5, 4, 5);
            btnHR.Name = "btnHR";
            btnHR.Size = new Size(347, 71);
            btnHR.TabIndex = 10;
            btnHR.Text = "الموارد البشرية";
            btnHR.TextAlignment = ContentAlignment.MiddleRight;
            btnHR.Click += btnHR_Click;
            // 
            // btnProdMgmt
            // 
            btnProdMgmt.Active = false;
            btnProdMgmt.Dock = DockStyle.Top;
            btnProdMgmt.Font = new Font("Cairo", 9F, FontStyle.Bold);
            btnProdMgmt.ForeColor = Color.FromArgb(245, 239, 230);
            btnProdMgmt.Icon = "🍬";
            btnProdMgmt.Location = new Point(0, 570);
            btnProdMgmt.Margin = new Padding(4, 5, 4, 5);
            btnProdMgmt.Name = "btnProdMgmt";
            btnProdMgmt.Size = new Size(347, 71);
            btnProdMgmt.TabIndex = 9;
            btnProdMgmt.Text = "إدارة المنتجات";
            btnProdMgmt.TextAlignment = ContentAlignment.MiddleRight;
            btnProdMgmt.Click += btnProdMgmt_Click;
            // 
            // btnProdView
            // 
            btnProdView.Active = false;
            btnProdView.Dock = DockStyle.Top;
            btnProdView.Font = new Font("Cairo", 9F, FontStyle.Bold);
            btnProdView.ForeColor = Color.FromArgb(245, 239, 230);
            btnProdView.Icon = "🍳";
            btnProdView.Location = new Point(0, 499);
            btnProdView.Margin = new Padding(4, 5, 4, 5);
            btnProdView.Name = "btnProdView";
            btnProdView.Size = new Size(347, 71);
            btnProdView.TabIndex = 8;
            btnProdView.Text = "عرض الإنتاج";
            btnProdView.TextAlignment = ContentAlignment.MiddleRight;
            btnProdView.Click += btnProdView_Click;
            // 
            // breakLine
            // 
            breakLine.BackColor = Color.FromArgb(150, 195, 150);
            breakLine.Dock = DockStyle.Top;
            breakLine.Location = new Point(0, 497);
            breakLine.Margin = new Padding(4, 5, 4, 5);
            breakLine.Name = "breakLine";
            breakLine.Size = new Size(347, 2);
            breakLine.TabIndex = 7;
            // 
            // btnOrderMgmt
            // 
            btnOrderMgmt.Active = false;
            btnOrderMgmt.Dock = DockStyle.Top;
            btnOrderMgmt.Font = new Font("Cairo", 9F, FontStyle.Bold);
            btnOrderMgmt.ForeColor = Color.FromArgb(245, 239, 230);
            btnOrderMgmt.Icon = "📋";
            btnOrderMgmt.Location = new Point(0, 426);
            btnOrderMgmt.Margin = new Padding(4, 5, 4, 5);
            btnOrderMgmt.Name = "btnOrderMgmt";
            btnOrderMgmt.Size = new Size(347, 71);
            btnOrderMgmt.TabIndex = 6;
            btnOrderMgmt.Text = "إدارة الطلبات";
            btnOrderMgmt.TextAlignment = ContentAlignment.MiddleRight;
            btnOrderMgmt.Click += btnOrderMgmt_Click;
            // 
            // btnDelegation
            // 
            btnDelegation.Active = false;
            btnDelegation.Dock = DockStyle.Top;
            btnDelegation.Font = new Font("Cairo", 9F, FontStyle.Bold);
            btnDelegation.ForeColor = Color.FromArgb(245, 239, 230);
            btnDelegation.Icon = "📦";
            btnDelegation.Location = new Point(0, 355);
            btnDelegation.Margin = new Padding(4, 5, 4, 5);
            btnDelegation.Name = "btnDelegation";
            btnDelegation.Size = new Size(347, 71);
            btnDelegation.TabIndex = 5;
            btnDelegation.Text = "مركز التوزيع";
            btnDelegation.TextAlignment = ContentAlignment.MiddleRight;
            btnDelegation.Click += btnDelegation_Click;
            // 
            // btnOrderEntry
            // 
            btnOrderEntry.Active = false;
            btnOrderEntry.Dock = DockStyle.Top;
            btnOrderEntry.Font = new Font("Cairo", 9F, FontStyle.Bold);
            btnOrderEntry.ForeColor = Color.FromArgb(245, 239, 230);
            btnOrderEntry.Icon = "\U0001f6d2";
            btnOrderEntry.Location = new Point(0, 284);
            btnOrderEntry.Margin = new Padding(4, 5, 4, 5);
            btnOrderEntry.Name = "btnOrderEntry";
            btnOrderEntry.Size = new Size(347, 71);
            btnOrderEntry.TabIndex = 4;
            btnOrderEntry.Text = "إدخال الطلبات";
            btnOrderEntry.TextAlignment = ContentAlignment.MiddleRight;
            btnOrderEntry.Click += btnOrderEntry_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Active = false;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.Font = new Font("Cairo", 9F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.FromArgb(245, 239, 230);
            btnDashboard.Icon = "📊";
            btnDashboard.Location = new Point(0, 213);
            btnDashboard.Margin = new Padding(4, 5, 4, 5);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(347, 71);
            btnDashboard.TabIndex = 3;
            btnDashboard.Text = "لوحة التحكم";
            btnDashboard.TextAlignment = ContentAlignment.MiddleRight;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // sep
            // 
            sep.BackColor = Color.FromArgb(150, 195, 150);
            sep.Dock = DockStyle.Top;
            sep.Location = new Point(0, 211);
            sep.Margin = new Padding(4, 5, 4, 5);
            sep.Name = "sep";
            sep.Size = new Size(347, 2);
            sep.TabIndex = 2;
            // 
            // navLabel
            // 
            navLabel.BackColor = Color.FromArgb(53, 133, 142);
            navLabel.Dock = DockStyle.Top;
            navLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            navLabel.ForeColor = Color.FromArgb(245, 239, 230);
            navLabel.Location = new Point(0, 165);
            navLabel.Margin = new Padding(4, 0, 4, 0);
            navLabel.Name = "navLabel";
            navLabel.Size = new Size(347, 46);
            navLabel.TabIndex = 1;
            navLabel.Text = "القائمة الرئيسية";
            navLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // logoPanel
            // 
            logoPanel.BackColor = Color.FromArgb(53, 133, 142);
            logoPanel.Controls.Add(appSub);
            logoPanel.Controls.Add(appName);
            logoPanel.Controls.Add(cake);
            logoPanel.Dock = DockStyle.Top;
            logoPanel.Location = new Point(0, 0);
            logoPanel.Margin = new Padding(4, 5, 4, 5);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(347, 165);
            logoPanel.TabIndex = 0;
            // 
            // appSub
            // 
            appSub.AutoSize = true;
            appSub.Font = new Font("Segoe UI", 8F);
            appSub.ForeColor = Color.FromArgb(245, 239, 230);
            appSub.Location = new Point(202, 67);
            appSub.Margin = new Padding(4, 0, 4, 0);
            appSub.Name = "appSub";
            appSub.Size = new Size(132, 19);
            appSub.TabIndex = 2;
            appSub.Text = "نظام الإدارة المتكامل";
            // 
            // appName
            // 
            appName.AutoSize = true;
            appName.Font = new Font("Cairo", 11F, FontStyle.Bold);
            appName.ForeColor = Color.White;
            appName.Location = new Point(204, 28);
            appName.Margin = new Padding(4, 0, 4, 0);
            appName.Name = "appName";
            appName.Size = new Size(130, 36);
            appName.TabIndex = 1;
            appName.Text = "محل الحلويات";
            // 
            // cake
            // 
            cake.AutoSize = true;
            cake.Font = new Font("Segoe UI Emoji", 26F);
            cake.ForeColor = Color.White;
            cake.Location = new Point(16, 28);
            cake.Margin = new Padding(4, 0, 4, 0);
            cake.Name = "cake";
            cake.Size = new Size(85, 58);
            cake.TabIndex = 0;
            cake.Text = "🍰";
            // 
            // footer
            // 
            footer.BackColor = Color.FromArgb(22, 34, 25);
            footer.Controls.Add(footerLabel);
            footer.Dock = DockStyle.Bottom;
            footer.Location = new Point(0, 993);
            footer.Margin = new Padding(4, 5, 4, 5);
            footer.Name = "footer";
            footer.Size = new Size(347, 62);
            footer.TabIndex = 0;
            // 
            // footerLabel
            // 
            footerLabel.BackColor = Color.FromArgb(53, 133, 142);
            footerLabel.Dock = DockStyle.Fill;
            footerLabel.Font = new Font("Segoe UI", 9F);
            footerLabel.ForeColor = Color.FromArgb(245, 239, 230);
            footerLabel.Location = new Point(0, 0);
            footerLabel.Margin = new Padding(4, 0, 4, 0);
            footerLabel.Name = "footerLabel";
            footerLabel.Size = new Size(347, 62);
            footerLabel.TabIndex = 0;
            footerLabel.Text = "© 2026  نظام محل الحلويات v1.0";
            footerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _contentArea
            // 
            _contentArea.Dock = DockStyle.Fill;
            _contentArea.Location = new Point(347, 0);
            _contentArea.Margin = new Padding(4, 5, 4, 5);
            _contentArea.Name = "_contentArea";
            _contentArea.Size = new Size(1386, 1055);
            _contentArea.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1733, 1055);
            Controls.Add(_contentArea);
            Controls.Add(_sidebar);
            DoubleBuffered = true;
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1394, 975);
            Name = "MainForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "نظام إدارة محل الحلويات";
            _sidebar.ResumeLayout(false);
            logoPanel.ResumeLayout(false);
            logoPanel.PerformLayout();
            footer.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _sidebar;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label cake;
        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.Label appSub;
        private System.Windows.Forms.Label navLabel;
        private System.Windows.Forms.Panel sep;
        private sweetSystem.NavButton btnDashboard;
        private sweetSystem.NavButton btnOrderEntry;
        private sweetSystem.NavButton btnDelegation;
        private sweetSystem.NavButton btnOrderMgmt;
        private System.Windows.Forms.Panel breakLine;
        private sweetSystem.NavButton btnProdView;
        private sweetSystem.NavButton btnProdMgmt;
        private sweetSystem.NavButton btnHR;
        private sweetSystem.NavButton btnWholesale;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Label footerLabel;
        private System.Windows.Forms.Panel _contentArea;
    }
}
