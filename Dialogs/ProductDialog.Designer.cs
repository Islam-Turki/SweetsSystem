namespace sweetSystem
{
    //partial class ProductDialog
    //{
    //    /// <summary>
    //    /// Required designer variable.
    //    /// </summary>
    //    private System.ComponentModel.IContainer components = null;

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null))
    //        {
    //            components.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    #region Windows Form Designer generated code

    //    /// <summary>
    //    /// Required method for Designer support - do not modify
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    private void InitializeComponent()
    //    {
    //        this.components = new System.ComponentModel.Container();
    //        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    //        this.ClientSize = new System.Drawing.Size(800, 450);
    //        this.Text = "ProductDialog";
    //    }

    //    #endregion
    //}
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Drawing;

    partial class ProductDialog
    {
        private IContainer components = null;

        internal TextBox TxName;
        internal TextBox TxCategory;
        internal TextBox TxRetail;
        internal TextBox TxWholesale;
        internal ComboBox TxUnit;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.TxName = new TextBox();
            this.TxCategory = new TextBox();
            this.TxRetail = new TextBox();
            this.TxWholesale = new TextBox();
            this.TxUnit = new ComboBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();

            this.SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = Theme.FontBodyB;
            label1.ForeColor = Theme.TextSecondary;
            label1.Location = new Point(16, 16);
            label1.Text = "اسم المنتج";

            // TxName
            TxName.BorderStyle = BorderStyle.FixedSingle;
            TxName.Font = Theme.FontBody;
            TxName.Location = new Point(16, 42);
            TxName.Size = new Size(368, 23);

            // label2
            label2.AutoSize = true;
            label2.Font = Theme.FontBodyB;
            label2.ForeColor = Theme.TextSecondary;
            label2.Location = new Point(16, 80);
            label2.Text = "الفئة";

            // TxCategory
            TxCategory.BorderStyle = BorderStyle.FixedSingle;
            TxCategory.Font = Theme.FontBody;
            TxCategory.Location = new Point(16, 106);
            TxCategory.Size = new Size(368, 23);

            // label3
            label3.AutoSize = true;
            label3.Font = Theme.FontBodyB;
            label3.ForeColor = Theme.TextSecondary;
            label3.Location = new Point(16, 144);
            label3.Text = "سعر القطاعي (د.ل)";

            // TxRetail
            TxRetail.BorderStyle = BorderStyle.FixedSingle;
            TxRetail.Font = Theme.FontBody;
            TxRetail.Location = new Point(16, 170);
            TxRetail.Size = new Size(368, 23);

            // label4
            label4.AutoSize = true;
            label4.Font = Theme.FontBodyB;
            label4.ForeColor = Theme.TextSecondary;
            label4.Location = new Point(16, 208);
            label4.Text = "سعر الجملة (د.ل)";

            // TxWholesale
            TxWholesale.BorderStyle = BorderStyle.FixedSingle;
            TxWholesale.Font = Theme.FontBody;
            TxWholesale.Location = new Point(16, 234);
            TxWholesale.Size = new Size(368, 23);

            // label5
            label5.AutoSize = true;
            label5.Font = Theme.FontBodyB;
            label5.ForeColor = Theme.TextSecondary;
            label5.Location = new Point(16, 272);
            label5.Text = "الوحدة";

            // TxUnit
            TxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            TxUnit.FlatStyle = FlatStyle.Flat;
            TxUnit.Font = Theme.FontBody;
            TxUnit.Items.AddRange(new object[]
            {
            "كيلوجرام",
            "قطعة",
            "علبة"
            });
            TxUnit.Location = new Point(16, 298);
            TxUnit.Size = new Size(368, 23);

            // Form
            this.ClientSize = new Size(400, 420);
            this.Controls.Add(TxUnit);
            this.Controls.Add(label5);
            this.Controls.Add(TxWholesale);
            this.Controls.Add(label4);
            this.Controls.Add(TxRetail);
            this.Controls.Add(label3);
            this.Controls.Add(TxCategory);
            this.Controls.Add(label2);
            this.Controls.Add(TxName);
            this.Controls.Add(label1);

            this.Name = "ProductDialog";
            this.Text = "إضافة منتج جديد";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}