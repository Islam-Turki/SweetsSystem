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
            lblTitle = new Label();
            lblPendingCount = new Label();
            lblInfo = new Label();
            chkSelectAll = new CheckBox();
            ClbPackagers = new CheckedListBox();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // BtnSave
            // 
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnSave.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnSave.Text = "✔ تكليف تلقائي";
            // 
            // BtnCancel
            // 
            BtnCancel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnCancel.FlatAppearance.MouseOverBackColor = Color.Transparent;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 45, 47);
            lblTitle.Location = new Point(16, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(249, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📦 تكليف تلقائي للطلبات";
            // 
            // lblPendingCount
            // 
            lblPendingCount.AutoSize = true;
            lblPendingCount.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblPendingCount.ForeColor = Color.FromArgb(200, 160, 90);
            lblPendingCount.Location = new Point(16, 46);
            lblPendingCount.Name = "lblPendingCount";
            lblPendingCount.Size = new Size(0, 29);
            lblPendingCount.TabIndex = 1;
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Cairo", 8F);
            lblInfo.ForeColor = Color.FromArgb(107, 124, 128);
            lblInfo.Location = new Point(16, 72);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(368, 36);
            lblInfo.TabIndex = 2;
            lblInfo.Text = "اختر موظفي التعبئة المتاحين، سيتم توزيع الطلبات عليهم بالتساوي:";
            // 
            // chkSelectAll
            // 
            chkSelectAll.AutoSize = true;
            chkSelectAll.Checked = true;
            chkSelectAll.CheckState = CheckState.Checked;
            chkSelectAll.Font = new Font("Cairo", 9F, FontStyle.Bold);
            chkSelectAll.ForeColor = Color.FromArgb(53, 133, 142);
            chkSelectAll.Location = new Point(16, 112);
            chkSelectAll.Name = "chkSelectAll";
            chkSelectAll.Size = new Size(107, 33);
            chkSelectAll.TabIndex = 3;
            chkSelectAll.Text = "تحديد الكل";
            chkSelectAll.UseVisualStyleBackColor = true;
            chkSelectAll.CheckedChanged += ChkSelectAll_CheckedChanged;
            // 
            // ClbPackagers
            // 
            ClbPackagers.BackColor = Color.White;
            ClbPackagers.BorderStyle = BorderStyle.FixedSingle;
            ClbPackagers.CheckOnClick = true;
            ClbPackagers.Font = new Font("Cairo", 10F);
            ClbPackagers.FormattingEnabled = true;
            ClbPackagers.Location = new Point(16, 151);
            ClbPackagers.Name = "ClbPackagers";
            ClbPackagers.Size = new Size(368, 172);
            ClbPackagers.TabIndex = 4;
            // 
            // AutoAssignDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 29F);
            ClientSize = new Size(400, 420);
            Controls.Add(ClbPackagers);
            Controls.Add(chkSelectAll);
            Controls.Add(lblInfo);
            Controls.Add(lblPendingCount);
            Controls.Add(lblTitle);
            Name = "AutoAssignDialog";
            Text = "تكليف تلقائي";
            Controls.SetChildIndex(lblTitle, 0);
            Controls.SetChildIndex(lblPendingCount, 0);
            Controls.SetChildIndex(lblInfo, 0);
            Controls.SetChildIndex(chkSelectAll, 0);
            Controls.SetChildIndex(ClbPackagers, 0);
            Controls.SetChildIndex(bottomPanel, 0);
            bottomPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
