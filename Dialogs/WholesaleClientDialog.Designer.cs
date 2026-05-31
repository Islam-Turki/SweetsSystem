using sweetSystem;
namespace sweetSystem
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class CustomerDialog
    {
        private IContainer components = null;

        internal TextBox TxName;
        internal TextBox TxPhone;
        internal TextBox TxBalance;

        private Label label1;
        private Label label2;
        private Label label3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.TxName = new TextBox();
            this.TxPhone = new TextBox();
            this.TxBalance = new TextBox();

            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();

            this.SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = Theme.FontBodyB;
            label1.ForeColor = Theme.TextSecondary;
            label1.Location = new Point(16, 16);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 10;
            label1.Text = "الاسم التجاري";

            // TxName
            TxName.BorderStyle = BorderStyle.FixedSingle;
            TxName.Font = Theme.FontBody;
            TxName.Location = new Point(16, 42);
            TxName.Name = "TxName";
            TxName.Size = new Size(368, 23);
            TxName.TabIndex = 0;

            // label2
            label2.AutoSize = true;
            label2.Font = Theme.FontBodyB;
            label2.ForeColor = Theme.TextSecondary;
            label2.Location = new Point(16, 80);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 11;
            label2.Text = "رقم الهاتف";

            // TxPhone
            TxPhone.BorderStyle = BorderStyle.FixedSingle;
            TxPhone.Font = Theme.FontBody;
            TxPhone.Location = new Point(16, 106);
            TxPhone.Name = "TxPhone";
            TxPhone.Size = new Size(368, 23);
            TxPhone.TabIndex = 1;

            // label3
            label3.AutoSize = true;
            label3.Font = Theme.FontBodyB;
            label3.ForeColor = Theme.TextSecondary;
            label3.Location = new Point(16, 144);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 12;
            label3.Text = "الرصيد المتبقي (د.ل)";

            // TxBalance
            TxBalance.BorderStyle = BorderStyle.FixedSingle;
            TxBalance.Font = Theme.FontBody;
            TxBalance.Location = new Point(16, 170);
            TxBalance.Name = "TxBalance";
            TxBalance.Size = new Size(368, 23);
            TxBalance.TabIndex = 2;

            // CustomerDialog
            this.ClientSize = new Size(400, 300);

            this.Controls.Add(TxBalance);
            this.Controls.Add(label3);

            this.Controls.Add(TxPhone);
            this.Controls.Add(label2);

            this.Controls.Add(TxName);
            this.Controls.Add(label1);

            this.Name = "CustomerDialog";
            this.Text = "إضافة عميل جملة";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
