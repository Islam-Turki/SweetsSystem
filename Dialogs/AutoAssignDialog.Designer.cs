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
            BtnSave.Location = new Point(20, 16);
            BtnSave.Margin = new Padding(4, 3, 4, 3);
            BtnSave.Size = new Size(162, 40);
            BtnSave.Text = "✔ تكليف تلقائي";
            // 
            // BtnCancel
            // 
            BtnCancel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnCancel.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnCancel.Location = new Point(195, 16);
            BtnCancel.Margin = new Padding(4, 3, 4, 3);
            BtnCancel.Size = new Size(138, 40);
            // 
            // bottomPanel
            // 
            bottomPanel.Location = new Point(0, 404);
            bottomPanel.Margin = new Padding(4, 3, 4, 3);
            bottomPanel.Size = new Size(500, 74);
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 14);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(299, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📦 تكليف تلقائي للطلبات";
            // 
            // lblPendingCount
            // 
            lblPendingCount.AutoSize = true;
            lblPendingCount.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblPendingCount.Location = new Point(20, 52);
            lblPendingCount.Margin = new Padding(4, 0, 4, 0);
            lblPendingCount.Name = "lblPendingCount";
            lblPendingCount.Size = new Size(0, 33);
            lblPendingCount.TabIndex = 1;
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Cairo", 8F);
            lblInfo.Location = new Point(20, 82);
            lblInfo.Margin = new Padding(4, 0, 4, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(460, 41);
            lblInfo.TabIndex = 2;
            lblInfo.Text = "اختر موظفي التعبئة المتاحين، سيتم توزيع الطلبات عليهم بالتساوي:";
            // 
            // chkSelectAll
            // 
            chkSelectAll.AutoSize = true;
            chkSelectAll.Checked = true;
            chkSelectAll.CheckState = CheckState.Checked;
            chkSelectAll.Font = new Font("Cairo", 9F, FontStyle.Bold);
            chkSelectAll.Location = new Point(20, 127);
            chkSelectAll.Margin = new Padding(4, 3, 4, 3);
            chkSelectAll.Name = "chkSelectAll";
            chkSelectAll.Size = new Size(127, 37);
            chkSelectAll.TabIndex = 3;
            chkSelectAll.Text = "تحديد الكل";
            chkSelectAll.UseVisualStyleBackColor = true;
            chkSelectAll.CheckedChanged += ChkSelectAll_CheckedChanged;
            // 
            // ClbPackagers
            // 
            ClbPackagers.BorderStyle = BorderStyle.FixedSingle;
            ClbPackagers.CheckOnClick = true;
            ClbPackagers.Font = new Font("Cairo", 10F);
            ClbPackagers.FormattingEnabled = true;
            ClbPackagers.Location = new Point(20, 172);
            ClbPackagers.Margin = new Padding(4, 3, 4, 3);
            ClbPackagers.Name = "ClbPackagers";
            ClbPackagers.Size = new Size(460, 170);
            ClbPackagers.TabIndex = 4;
            // 
            // AutoAssignDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 33F);
            ClientSize = new Size(500, 478);
            Controls.Add(ClbPackagers);
            Controls.Add(chkSelectAll);
            Controls.Add(lblInfo);
            Controls.Add(lblPendingCount);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 3, 4, 3);
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
