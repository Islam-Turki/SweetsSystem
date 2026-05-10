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
    internal PictureBox picProductImage;
    internal Button btnChooseImage;

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
            TxName = new TextBox();
            TxCategory = new TextBox();
            TxRetail = new TextBox();
            TxWholesale = new TextBox();
            TxUnit = new ComboBox();
            picProductImage = new PictureBox();
            btnChooseImage = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            bottomPanel.SuspendLayout();
            ((ISupportInitialize)picProductImage).BeginInit();
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
            bottomPanel.Location = new Point(0, 499);
            bottomPanel.Size = new Size(405, 65);
            // 
            // TxName
            // 
            TxName.BorderStyle = BorderStyle.FixedSingle;
            TxName.Font = new Font("Cairo", 9F);
            TxName.Location = new Point(16, 42);
            TxName.Name = "TxName";
            TxName.Size = new Size(368, 41);
            TxName.TabIndex = 9;
            // 
            // TxCategory
            // 
            TxCategory.BorderStyle = BorderStyle.FixedSingle;
            TxCategory.Font = new Font("Cairo", 9F);
            TxCategory.Location = new Point(16, 106);
            TxCategory.Name = "TxCategory";
            TxCategory.Size = new Size(368, 41);
            TxCategory.TabIndex = 7;
            // 
            // TxRetail
            // 
            TxRetail.BorderStyle = BorderStyle.FixedSingle;
            TxRetail.Font = new Font("Cairo", 9F);
            TxRetail.Location = new Point(16, 170);
            TxRetail.Name = "TxRetail";
            TxRetail.Size = new Size(368, 41);
            TxRetail.TabIndex = 5;
            // 
            // TxWholesale
            // 
            TxWholesale.BorderStyle = BorderStyle.FixedSingle;
            TxWholesale.Font = new Font("Cairo", 9F);
            TxWholesale.Location = new Point(16, 234);
            TxWholesale.Name = "TxWholesale";
            TxWholesale.Size = new Size(368, 41);
            TxWholesale.TabIndex = 3;
            // 
            // TxUnit
            // 
            TxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            TxUnit.FlatStyle = FlatStyle.Flat;
            TxUnit.Font = new Font("Cairo", 9F);
            TxUnit.Items.AddRange(new object[] { "كيلوجرام", "قطعة", "علبة" });
            TxUnit.Location = new Point(16, 298);
            TxUnit.Name = "TxUnit";
            TxUnit.Size = new Size(368, 41);
            TxUnit.TabIndex = 1;
            // 
            // picProductImage
            // 
            picProductImage.BorderStyle = BorderStyle.FixedSingle;
            picProductImage.Location = new Point(16, 352);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(120, 120);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabIndex = 12;
            picProductImage.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(152, 388);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(120, 35);
            btnChooseImage.TabIndex = 13;
            btnChooseImage.Text = "اختر صورة";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += BtnChooseImage_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cairo", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(107, 124, 128);
            label1.Location = new Point(16, 16);
            label1.Name = "label1";
            label1.Size = new Size(103, 33);
            label1.TabIndex = 10;
            label1.Text = "اسم المنتج";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cairo", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(107, 124, 128);
            label2.Location = new Point(16, 80);
            label2.Name = "label2";
            label2.Size = new Size(58, 33);
            label2.TabIndex = 8;
            label2.Text = "الفئة";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cairo", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(107, 124, 128);
            label3.Location = new Point(16, 144);
            label3.Name = "label3";
            label3.Size = new Size(167, 33);
            label3.TabIndex = 6;
            label3.Text = "سعر القطاعي (د.ل)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cairo", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(107, 124, 128);
            label4.Location = new Point(16, 208);
            label4.Name = "label4";
            label4.Size = new Size(150, 33);
            label4.TabIndex = 4;
            label4.Text = "سعر الجملة (د.ل)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Cairo", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(107, 124, 128);
            label5.Location = new Point(16, 272);
            label5.Name = "label5";
            label5.Size = new Size(69, 33);
            label5.TabIndex = 2;
            label5.Text = "الوحدة";
            // 
            // ProductDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 33F);
            ClientSize = new Size(405, 564);
            Controls.Add(TxUnit);
            Controls.Add(label5);
            Controls.Add(TxWholesale);
            Controls.Add(label4);
            Controls.Add(TxRetail);
            Controls.Add(label3);
            Controls.Add(TxCategory);
            Controls.Add(label2);
            Controls.Add(TxName);
            Controls.Add(label1);
            Controls.Add(picProductImage);
            Controls.Add(btnChooseImage);
            Name = "ProductDialog";
            Text = "إضافة منتج جديد";
            Controls.SetChildIndex(btnChooseImage, 0);
            Controls.SetChildIndex(picProductImage, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(TxName, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(TxCategory, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(TxRetail, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(TxWholesale, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(TxUnit, 0);
            Controls.SetChildIndex(bottomPanel, 0);
            bottomPanel.ResumeLayout(false);
            ((ISupportInitialize)picProductImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}