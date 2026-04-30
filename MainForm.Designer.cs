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
            this._sidebar = new System.Windows.Forms.Panel();
            this.footer = new System.Windows.Forms.Panel();
            this.footerLabel = new System.Windows.Forms.Label();
            this.btnWholesale = new sweetSystem.NavButton("عملاء الجملة", "🏪");
            this.btnHR = new sweetSystem.NavButton("الموارد البشرية", "👥");
            this.btnProdMgmt = new sweetSystem.NavButton("إدارة المنتجات", "🍬");
            this.btnProdView = new sweetSystem.NavButton("عرض الإنتاج", "🍳");
            this.breakLine = new System.Windows.Forms.Panel();
            this.btnOrderMgmt = new sweetSystem.NavButton("إدارة الطلبات", "📋");
            this.btnDelegation = new sweetSystem.NavButton("مركز التوزيع", "📦");
            this.btnOrderEntry = new sweetSystem.NavButton("إدخال الطلبات", "🛒");
            this.btnDashboard = new sweetSystem.NavButton("لوحة التحكم", "📊");
            this.sep = new System.Windows.Forms.Panel();
            this.navLabel = new System.Windows.Forms.Label();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.appSub = new System.Windows.Forms.Label();
            this.appName = new System.Windows.Forms.Label();
            this.cake = new System.Windows.Forms.Label();
            this._contentArea = new System.Windows.Forms.Panel();
            this._sidebar.SuspendLayout();
            this.footer.SuspendLayout();
            this.logoPanel.SuspendLayout();
            this._contentArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // _sidebar
            // 
            this._sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this._sidebar.Controls.Add(this.btnWholesale);
            this._sidebar.Controls.Add(this.btnHR);
            this._sidebar.Controls.Add(this.btnProdMgmt);
            this._sidebar.Controls.Add(this.btnProdView);
            this._sidebar.Controls.Add(this.breakLine);
            this._sidebar.Controls.Add(this.btnOrderMgmt);
            this._sidebar.Controls.Add(this.btnDelegation);
            this._sidebar.Controls.Add(this.btnOrderEntry);
            this._sidebar.Controls.Add(this.btnDashboard);
            this._sidebar.Controls.Add(this.sep);
            this._sidebar.Controls.Add(this.navLabel);
            this._sidebar.Controls.Add(this.logoPanel);
            this._sidebar.Controls.Add(this.footer);
            this._sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this._sidebar.Location = new System.Drawing.Point(0, 0);
            this._sidebar.Name = "_sidebar";
            this._sidebar.Size = new System.Drawing.Size(260, 800);
            this._sidebar.TabIndex = 0;
            // 
            // footer
            // 
            this.footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(25)))));
            this.footer.Controls.Add(this.footerLabel);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 760);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(260, 40);
            this.footer.TabIndex = 0;
            // 
            // footerLabel
            // 
            this.footerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footerLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.footerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(130)))), ((int)(((byte)(90)))));
            this.footerLabel.Location = new System.Drawing.Point(0, 0);
            this.footerLabel.Name = "footerLabel";
            this.footerLabel.Size = new System.Drawing.Size(260, 40);
            this.footerLabel.TabIndex = 0;
            this.footerLabel.Text = "© 2026  نظام محل الحلويات v1.0";
            this.footerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnWholesale
            // 
            this.btnWholesale.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWholesale.Location = new System.Drawing.Point(0, 461);
            this.btnWholesale.Name = "btnWholesale";
            this.btnWholesale.Size = new System.Drawing.Size(260, 46);
            this.btnWholesale.TabIndex = 11;
            this.btnWholesale.Click += new System.EventHandler(this.btnWholesale_Click);
            // 
            // btnHR
            // 
            this.btnHR.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHR.Location = new System.Drawing.Point(0, 415);
            this.btnHR.Name = "btnHR";
            this.btnHR.Size = new System.Drawing.Size(260, 46);
            this.btnHR.TabIndex = 10;
            this.btnHR.Click += new System.EventHandler(this.btnHR_Click);
            // 
            // btnProdMgmt
            // 
            this.btnProdMgmt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProdMgmt.Location = new System.Drawing.Point(0, 369);
            this.btnProdMgmt.Name = "btnProdMgmt";
            this.btnProdMgmt.Size = new System.Drawing.Size(260, 46);
            this.btnProdMgmt.TabIndex = 9;
            this.btnProdMgmt.Click += new System.EventHandler(this.btnProdMgmt_Click);
            // 
            // btnProdView
            // 
            this.btnProdView.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProdView.Location = new System.Drawing.Point(0, 323);
            this.btnProdView.Name = "btnProdView";
            this.btnProdView.Size = new System.Drawing.Size(260, 46);
            this.btnProdView.TabIndex = 8;
            this.btnProdView.Click += new System.EventHandler(this.btnProdView_Click);
            // 
            // breakLine
            // 
            this.breakLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(80)))), ((int)(((byte)(58)))));
            this.breakLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.breakLine.Location = new System.Drawing.Point(0, 322);
            this.breakLine.Name = "breakLine";
            this.breakLine.Size = new System.Drawing.Size(260, 1);
            this.breakLine.TabIndex = 7;
            // 
            // btnOrderMgmt
            // 
            this.btnOrderMgmt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrderMgmt.Location = new System.Drawing.Point(0, 276);
            this.btnOrderMgmt.Name = "btnOrderMgmt";
            this.btnOrderMgmt.Size = new System.Drawing.Size(260, 46);
            this.btnOrderMgmt.TabIndex = 6;
            this.btnOrderMgmt.Click += new System.EventHandler(this.btnOrderMgmt_Click);
            // 
            // btnDelegation
            // 
            this.btnDelegation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelegation.Location = new System.Drawing.Point(0, 230);
            this.btnDelegation.Name = "btnDelegation";
            this.btnDelegation.Size = new System.Drawing.Size(260, 46);
            this.btnDelegation.TabIndex = 5;
            this.btnDelegation.Click += new System.EventHandler(this.btnDelegation_Click);
            // 
            // btnOrderEntry
            // 
            this.btnOrderEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrderEntry.Location = new System.Drawing.Point(0, 184);
            this.btnOrderEntry.Name = "btnOrderEntry";
            this.btnOrderEntry.Size = new System.Drawing.Size(260, 46);
            this.btnOrderEntry.TabIndex = 4;
            this.btnOrderEntry.Click += new System.EventHandler(this.btnOrderEntry_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.Location = new System.Drawing.Point(0, 138);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(260, 46);
            this.btnDashboard.TabIndex = 3;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // sep
            // 
            this.sep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(80)))), ((int)(((byte)(58)))));
            this.sep.Dock = System.Windows.Forms.DockStyle.Top;
            this.sep.Location = new System.Drawing.Point(0, 137);
            this.sep.Name = "sep";
            this.sep.Size = new System.Drawing.Size(260, 1);
            this.sep.TabIndex = 2;
            // 
            // navLabel
            // 
            this.navLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.navLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.navLabel.Location = new System.Drawing.Point(0, 107);
            this.navLabel.Name = "navLabel";
            this.navLabel.Size = new System.Drawing.Size(260, 30);
            this.navLabel.TabIndex = 1;
            this.navLabel.Text = "القائمة الرئيسية";
            this.navLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logoPanel
            // 
            this.logoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(32)))));
            this.logoPanel.Controls.Add(this.appSub);
            this.logoPanel.Controls.Add(this.appName);
            this.logoPanel.Controls.Add(this.cake);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(260, 107);
            this.logoPanel.TabIndex = 0;
            // 
            // appSub
            // 
            this.appSub.AutoSize = true;
            this.appSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.appSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(195)))), ((int)(((byte)(150)))));
            this.appSub.Location = new System.Drawing.Point(62, 54);
            this.appSub.Name = "appSub";
            this.appSub.Size = new System.Drawing.Size(107, 13);
            this.appSub.TabIndex = 2;
            this.appSub.Text = "نظام الإدارة المتكامل";
            // 
            // appName
            // 
            this.appName.AutoSize = true;
            this.appName.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            this.appName.ForeColor = System.Drawing.Color.White;
            this.appName.Location = new System.Drawing.Point(62, 26);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(102, 29);
            this.appName.TabIndex = 1;
            this.appName.Text = "محل الحلويات";
            // 
            // cake
            // 
            this.cake.AutoSize = true;
            this.cake.Font = new System.Drawing.Font("Segoe UI Emoji", 26F);
            this.cake.ForeColor = System.Drawing.Color.White;
            this.cake.Location = new System.Drawing.Point(12, 18);
            this.cake.Name = "cake";
            this.cake.Size = new System.Drawing.Size(56, 47);
            this.cake.TabIndex = 0;
            this.cake.Text = "🍰";
            // 
            // _contentArea
            // 
            this._contentArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this._contentArea.Location = new System.Drawing.Point(260, 0);
            this._contentArea.Name = "_contentArea";
            this._contentArea.Size = new System.Drawing.Size(1040, 800);
            this._contentArea.TabIndex = 1;
            // 

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this._contentArea);
            this.Controls.Add(this._sidebar);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1050, 650);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظام إدارة محل الحلويات";
            this._sidebar.ResumeLayout(false);
            this.footer.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            this.logoPanel.PerformLayout();
            this._contentArea.ResumeLayout(false);
            this.ResumeLayout(false);

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
