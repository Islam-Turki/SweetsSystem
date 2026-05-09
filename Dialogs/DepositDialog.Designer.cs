namespace sweetSystem
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class DepositDialog
    {
        private IContainer components = null;

        internal NumericUpDown NumAmount;

        private Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.NumAmount = new NumericUpDown();
            this.label1 = new Label();

            ((ISupportInitialize)(this.NumAmount)).BeginInit();
            this.SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = Theme.FontBodyB;
            label1.ForeColor = Theme.TextSecondary;
            label1.Location = new Point(16, 16);
            label1.Text = "المبلغ المراد إيداعه (د.ل)";

            // NumAmount
            NumAmount.DecimalPlaces = 3;
            NumAmount.Font = Theme.FontBody;
            NumAmount.Location = new Point(16, 42);
            NumAmount.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            NumAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumAmount.Name = "NumAmount";
            NumAmount.Size = new Size(368, 23);
            NumAmount.TabIndex = 0;
            NumAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // DepositDialog
            this.ClientSize = new Size(400, 220);

            this.Controls.Add(NumAmount);
            this.Controls.Add(label1);

            this.Name = "DepositDialog";
            this.Text = "إيداع";

            ((ISupportInitialize)(this.NumAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}