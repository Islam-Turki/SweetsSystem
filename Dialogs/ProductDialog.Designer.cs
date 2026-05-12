using sweetSystem;
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
            BtnSave.Location = new Point(13, 12);
            BtnSave.Margin = new Padding(2, 3, 2, 3);
            BtnSave.Size = new Size(104, 31);
            // 
            // BtnCancel
            // 
            BtnCancel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnCancel.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnCancel.Location = new Point(125, 12);
            BtnCancel.Margin = new Padding(2, 3, 2, 3);
            BtnCancel.Size = new Size(88, 31);
            // 
            // bottomPanel
            // 
            bottomPanel.Location = new Point(0, 532);
            bottomPanel.Margin = new Padding(2, 3, 2, 3);
            bottomPanel.Size = new Size(324, 57);
            // 
            // TxName
            // 
            TxName.BorderStyle = BorderStyle.FixedSingle;
            TxName.Font = new Font("Cairo", 9F);
            TxName.Location = new Point(13, 56);
            TxName.Margin = new Padding(2, 3, 2, 3);
            TxName.Name = "TxName";
            TxName.Size = new Size(295, 36);
            TxName.TabIndex = 9;
            // 
            // TxCategory
            // 
            TxCategory.BorderStyle = BorderStyle.FixedSingle;
            TxCategory.Font = new Font("Cairo", 9F);
            TxCategory.Location = new Point(13, 127);
            TxCategory.Margin = new Padding(2, 3, 2, 3);
            TxCategory.Name = "TxCategory";
            TxCategory.Size = new Size(295, 36);
            TxCategory.TabIndex = 7;
            // 
            // TxRetail
            // 
            TxRetail.BorderStyle = BorderStyle.FixedSingle;
            TxRetail.Font = new Font("Cairo", 9F);
            TxRetail.Location = new Point(13, 198);
            TxRetail.Margin = new Padding(2, 3, 2, 3);
            TxRetail.Name = "TxRetail";
            TxRetail.Size = new Size(295, 36);
            TxRetail.TabIndex = 5;
            // 
            // TxWholesale
            // 
            TxWholesale.BorderStyle = BorderStyle.FixedSingle;
            TxWholesale.Font = new Font("Cairo", 9F);
            TxWholesale.Location = new Point(16, 269);
            TxWholesale.Margin = new Padding(2, 3, 2, 3);
            TxWholesale.Name = "TxWholesale";
            TxWholesale.Size = new Size(295, 36);
            TxWholesale.TabIndex = 3;
            // 
            // TxUnit
            // 
            TxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            TxUnit.FlatStyle = FlatStyle.Flat;
            TxUnit.Font = new Font("Cairo", 9F);
            TxUnit.Items.AddRange(new object[] { "كيلوجرام", "قطعة", "علبة" });
            TxUnit.Location = new Point(13, 340);
            TxUnit.Margin = new Padding(2, 3, 2, 3);
            TxUnit.Name = "TxUnit";
            TxUnit.Size = new Size(295, 37);
            TxUnit.TabIndex = 1;
            // 
            // picProductImage
            // 
            picProductImage.BorderStyle = BorderStyle.FixedSingle;
            picProductImage.Location = new Point(13, 420);
            picProductImage.Margin = new Padding(2, 3, 2, 3);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(96, 106);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabIndex = 12;
            picProductImage.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(13, 383);
            btnChooseImage.Margin = new Padding(2, 3, 2, 3);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(96, 31);
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
            label1.Location = new Point(13, 24);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(88, 29);
            label1.TabIndex = 10;
            label1.Text = "اسم المنتج";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cairo", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(107, 124, 128);
            label2.Location = new Point(13, 95);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(49, 29);
            label2.TabIndex = 8;
            label2.Text = "الفئة";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cairo", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(107, 124, 128);
            label3.Location = new Point(13, 166);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(141, 29);
            label3.TabIndex = 6;
            label3.Text = "سعر القطاعي (د.ل)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cairo", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(107, 124, 128);
            label4.Location = new Point(16, 237);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(126, 29);
            label4.TabIndex = 4;
            label4.Text = "سعر الجملة (د.ل)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Cairo", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(107, 124, 128);
            label5.Location = new Point(13, 308);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(59, 29);
            label5.TabIndex = 2;
            label5.Text = "الوحدة";
            // 
            // ProductDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 29F);
            ClientSize = new Size(324, 589);
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
            Margin = new Padding(2, 3, 2, 3);
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
