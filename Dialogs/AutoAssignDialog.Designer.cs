using sweetSystem;
namespace sweetSystem
{
    partial class AutoAssignDialog
    {
        private System.ComponentModel.IContainer components = null;

        internal System.Windows.Forms.CheckedListBox ClbPackagers;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Label lblPendingCount;
        internal System.Windows.Forms.Label lblInfo;
        internal System.Windows.Forms.CheckBox chkSelectAll;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPendingCount = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.ClbPackagers = new System.Windows.Forms.CheckedListBox();

            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // BtnSave
            // 
            this.BtnSave.Text = "✔ تكليف تلقائي";

            // 
            // bottomPanel
            // 
            this.bottomPanel.Location = new System.Drawing.Point(0, 355);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.TextPrimary;
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📦 تكليف تلقائي للطلبات";

            // 
            // lblPendingCount
            // 
            this.lblPendingCount.AutoSize = true;
            this.lblPendingCount.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblPendingCount.ForeColor = Theme.AccentGold;
            this.lblPendingCount.Location = new System.Drawing.Point(16, 46);
            this.lblPendingCount.Name = "lblPendingCount";
            this.lblPendingCount.Size = new System.Drawing.Size(200, 22);
            this.lblPendingCount.TabIndex = 1;
            this.lblPendingCount.Text = "";

            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = false;
            this.lblInfo.Font = Theme.FontSmall;
            this.lblInfo.ForeColor = Theme.TextSecondary;
            this.lblInfo.Location = new System.Drawing.Point(16, 72);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(368, 36);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "اختر موظفي التعبئة المتاحين، سيتم توزيع الطلبات عليهم بالتساوي:";

            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Checked = true;
            this.chkSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectAll.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.chkSelectAll.ForeColor = Theme.AccentGreen;
            this.chkSelectAll.Location = new System.Drawing.Point(16, 112);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(120, 26);
            this.chkSelectAll.TabIndex = 3;
            this.chkSelectAll.Text = "تحديد الكل";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.ChkSelectAll_CheckedChanged);

            // 
            // ClbPackagers
            // 
            this.ClbPackagers.BackColor = System.Drawing.Color.White;
            this.ClbPackagers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ClbPackagers.CheckOnClick = true;
            this.ClbPackagers.Font = new System.Drawing.Font("Cairo", 10F);
            this.ClbPackagers.FormattingEnabled = true;
            this.ClbPackagers.Location = new System.Drawing.Point(16, 142);
            this.ClbPackagers.Name = "ClbPackagers";
            this.ClbPackagers.Size = new System.Drawing.Size(368, 196);
            this.ClbPackagers.TabIndex = 4;

            // 
            // AutoAssignDialog
            // 
            this.ClientSize = new System.Drawing.Size(400, 420);
            this.Controls.Add(this.ClbPackagers);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblPendingCount);
            this.Controls.Add(this.lblTitle);
            this.Name = "AutoAssignDialog";
            this.Text = "تكليف تلقائي";

            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
