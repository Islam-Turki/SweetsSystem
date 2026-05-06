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
            this.CbStatus = new ComboBox();
            this.TxCustomer = new TextBox();

            this.label1 = new Label();
            this.label2 = new Label();

            this.SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = Theme.FontBodyB;
            label1.ForeColor = Theme.TextSecondary;
            label1.Location = new Point(16, 16);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 10;
            label1.Text = "العميل";

            // TxCustomer
            TxCustomer.BackColor = Theme.Background;
            TxCustomer.BorderStyle = BorderStyle.FixedSingle;
            TxCustomer.Font = Theme.FontBody;
            TxCustomer.Location = new Point(16, 42);
            TxCustomer.Name = "TxCustomer";
            TxCustomer.ReadOnly = true;
            TxCustomer.Size = new Size(368, 23);
            TxCustomer.TabIndex = 0;

            // label2
            label2.AutoSize = true;
            label2.Font = Theme.FontBodyB;
            label2.ForeColor = Theme.TextSecondary;
            label2.Location = new Point(16, 80);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 11;
            label2.Text = "الحالة";

            // CbStatus
            CbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            CbStatus.FlatStyle = FlatStyle.Flat;
            CbStatus.Font = Theme.FontBody;
            CbStatus.FormattingEnabled = true;

            CbStatus.Items.AddRange(new object[]
            {
            "قيد الانتظار",
            "تم التكليف",
            "مكتمل"
            });

            CbStatus.Location = new Point(16, 106);
            CbStatus.Name = "CbStatus";
            CbStatus.Size = new Size(368, 23);
            CbStatus.TabIndex = 1;

            // OrderDialog
            this.ClientSize = new Size(400, 250);

            this.Controls.Add(CbStatus);
            this.Controls.Add(label2);

            this.Controls.Add(TxCustomer);
            this.Controls.Add(label1);

            this.Name = "OrderDialog";
            this.Text = "تعديل الطلب";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}