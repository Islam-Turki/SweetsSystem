namespace sweetSystem
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class OrderDialog
    {
        private IContainer components = null;

        internal ComboBox CbStatus;
        internal TextBox TxCustomer;

        private Label label1;
        private Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            CbStatus = new ComboBox();
            TxCustomer = new TextBox();
            label1 = new Label();
            label2 = new Label();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // BtnSave
            // 
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnSave.FlatAppearance.MouseOverBackColor = Color.Transparent;
            // 
            // BtnCancel
            // 
            BtnCancel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnCancel.FlatAppearance.MouseOverBackColor = Color.Transparent;
            // 
            // bottomPanel
            // 
            bottomPanel.Location = new Point(0, 185);
            // 
            // CbStatus
            // 
            CbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            CbStatus.FlatStyle = FlatStyle.Flat;
            CbStatus.Font = new Font("Cairo", 9F);
            CbStatus.FormattingEnabled = true;
            CbStatus.Items.AddRange(new object[] { "قيد الانتظار", "تم التكليف", "مكتمل" });
            CbStatus.Location = new Point(16, 113);
            CbStatus.Name = "CbStatus";
            CbStatus.Size = new Size(368, 37);
            CbStatus.TabIndex = 1;
            // 
            // TxCustomer
            // 
            TxCustomer.BackColor = Color.FromArgb(245, 247, 248);
            TxCustomer.BorderStyle = BorderStyle.FixedSingle;
            TxCustomer.Font = new Font("Cairo", 9F);
            TxCustomer.Location = new Point(16, 42);
            TxCustomer.Name = "TxCustomer";
            TxCustomer.ReadOnly = true;
            TxCustomer.Size = new Size(368, 36);
            TxCustomer.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cairo", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(107, 124, 128);
            label1.Location = new Point(16, 16);
            label1.Name = "label1";
            label1.Size = new Size(61, 29);
            label1.TabIndex = 10;
            label1.Text = "العميل";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cairo", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(107, 124, 128);
            label2.Location = new Point(16, 81);
            label2.Name = "label2";
            label2.Size = new Size(52, 29);
            label2.TabIndex = 11;
            label2.Text = "الحالة";
            // 
            // OrderDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 29F);
            ClientSize = new Size(400, 250);
            Controls.Add(CbStatus);
            Controls.Add(label2);
            Controls.Add(TxCustomer);
            Controls.Add(label1);
            Name = "OrderDialog";
            Text = "تعديل الطلب";
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(TxCustomer, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(CbStatus, 0);
            Controls.SetChildIndex(bottomPanel, 0);
            bottomPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}