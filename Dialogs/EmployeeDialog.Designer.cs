using sweetSystem;
namespace sweetSystem
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class EmployeeDialog
    {
        private IContainer components = null;

        internal TextBox TxName;
        internal ComboBox CbRole;
        internal CheckedListBox ClbSkills;

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
            this.CbRole = new ComboBox();
            this.ClbSkills = new CheckedListBox();

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
            label1.Text = "الاسم الكامل";

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
            label2.Size = new Size(64, 15);
            label2.TabIndex = 11;
            label2.Text = "الدور الوظيفي";

            // CbRole
            CbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            CbRole.FlatStyle = FlatStyle.Flat;
            CbRole.Font = Theme.FontBody;
            CbRole.FormattingEnabled = true;

            CbRole.Items.AddRange(new object[]
            {
            "طباخ",
            "معبّئ"
            });

            CbRole.Location = new Point(16, 106);
            CbRole.Name = "CbRole";
            CbRole.Size = new Size(368, 23);
            CbRole.TabIndex = 1;
            CbRole.SelectedIndex = 0;

            CbRole.SelectedIndexChanged +=
                new System.EventHandler(this.CbRole_SelectedIndexChanged);

            // label3
            label3.AutoSize = true;
            label3.Font = Theme.FontBodyB;
            label3.ForeColor = Theme.TextSecondary;
            label3.Location = new Point(16, 144);
            label3.Name = "label3";
            label3.Size = new Size(155, 15);
            label3.TabIndex = 12;
            label3.Text = "مهارات الطبخ (للطباخين فقط)";

            // ClbSkills
            ClbSkills.BorderStyle = BorderStyle.FixedSingle;
            ClbSkills.CheckOnClick = true;
            ClbSkills.Font = Theme.FontBody;
            ClbSkills.FormattingEnabled = true;
            ClbSkills.Location = new Point(16, 170);
            ClbSkills.Name = "ClbSkills";
            ClbSkills.Size = new Size(368, 160);
            ClbSkills.TabIndex = 2;

            // EmployeeDialog
            this.ClientSize = new Size(400, 450);

            this.Controls.Add(ClbSkills);
            this.Controls.Add(label3);

            this.Controls.Add(CbRole);
            this.Controls.Add(label2);

            this.Controls.Add(TxName);
            this.Controls.Add(label1);

            this.Name = "EmployeeDialog";
            this.Text = "إضافة موظف جديد";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
