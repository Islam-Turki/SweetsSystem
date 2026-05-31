namespace sweetSystem.Dialogs
{
    partial class ChooseProductsDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.sepBar = new System.Windows.Forms.Panel();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this._catalogFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.catalogSearch = new System.Windows.Forms.TextBox();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.btnConfirm = new sweetSystem.FlatButton();
            this.btnCancel = new sweetSystem.FlatButton();
            this._lblSelectionCount = new System.Windows.Forms.Label();
            
            this.headerPanel.SuspendLayout();
            this.bodyPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.sepBar);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(900, 70);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(36, 36, 36);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblTitle.Size = new System.Drawing.Size(900, 68);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🏪 اختيار المنتجات";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sepBar
            // 
            this.sepBar.BackColor = System.Drawing.Color.FromArgb(53, 133, 142);
            this.sepBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sepBar.Location = new System.Drawing.Point(0, 68);
            this.sepBar.Name = "sepBar";
            this.sepBar.Size = new System.Drawing.Size(900, 2);
            this.sepBar.TabIndex = 1;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.catalogSearch);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 70);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(16, 16, 16, 8);
            this.searchPanel.Size = new System.Drawing.Size(900, 60);
            this.searchPanel.TabIndex = 1;
            // 
            // catalogSearch
            // 
            this.catalogSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.catalogSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catalogSearch.Font = new System.Drawing.Font("Cairo", 10F);
            this.catalogSearch.Location = new System.Drawing.Point(16, 16);
            this.catalogSearch.Name = "catalogSearch";
            this.catalogSearch.PlaceholderText = "🔍 ابحث عن منتج...";
            this.catalogSearch.Size = new System.Drawing.Size(868, 39);
            this.catalogSearch.TabIndex = 0;
            this.catalogSearch.TextChanged += new System.EventHandler(this.CatalogSearch_TextChanged);
            // 
            // bodyPanel
            // 
            this.bodyPanel.Controls.Add(this._catalogFlow);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(0, 130);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Padding = new System.Windows.Forms.Padding(16, 8, 16, 16);
            this.bodyPanel.Size = new System.Drawing.Size(900, 470);
            this.bodyPanel.TabIndex = 2;
            // 
            // _catalogFlow
            // 
            this._catalogFlow.AutoScroll = true;
            this._catalogFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this._catalogFlow.Location = new System.Drawing.Point(16, 8);
            this._catalogFlow.Name = "_catalogFlow";
            this._catalogFlow.Size = new System.Drawing.Size(868, 446);
            this._catalogFlow.TabIndex = 0;
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.White;
            this.footerPanel.Controls.Add(this._lblSelectionCount);
            this.footerPanel.Controls.Add(this.btnCancel);
            this.footerPanel.Controls.Add(this.btnConfirm);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 600);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(900, 80);
            this.footerPanel.TabIndex = 3;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(43, 150, 90);
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(16, 16);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Radius = 8;
            this.btnConfirm.Size = new System.Drawing.Size(200, 48);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "✔ تأكيد الاختيار";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(230, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 8;
            this.btnCancel.Size = new System.Drawing.Size(120, 48);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // _lblSelectionCount
            // 
            this._lblSelectionCount.AutoSize = true;
            this._lblSelectionCount.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this._lblSelectionCount.ForeColor = System.Drawing.Color.FromArgb(36, 36, 36);
            this._lblSelectionCount.Location = new System.Drawing.Point(370, 24);
            this._lblSelectionCount.Name = "_lblSelectionCount";
            this._lblSelectionCount.Size = new System.Drawing.Size(160, 32);
            this._lblSelectionCount.TabIndex = 2;
            this._lblSelectionCount.Text = "تم اختيار 0 منتجات";
            // 
            // ChooseProductsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(247, 246, 242);
            this.ClientSize = new System.Drawing.Size(900, 680);
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.footerPanel);
            this.Font = new System.Drawing.Font("Cairo", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseProductsDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "اختيار المنتجات";
            
            this.headerPanel.ResumeLayout(false);
            this.bodyPanel.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel sepBar;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.FlowLayoutPanel _catalogFlow;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox catalogSearch;
        private System.Windows.Forms.Panel footerPanel;
        private sweetSystem.FlatButton btnConfirm;
        private sweetSystem.FlatButton btnCancel;
        private System.Windows.Forms.Label _lblSelectionCount;
    }
}
