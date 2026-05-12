using sweetSystem;
namespace sweetSystem
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class AssignOrderDialog
    {
        private IContainer components = null;

        internal ComboBox CbPackager;
        internal DataGridView _grid;
        internal FlatButton btnPrint;

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
            CbPackager = new ComboBox();
            _grid = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            btnPrint = new FlatButton();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            bottomPanel.SuspendLayout();
            ((ISupportInitialize)_grid).BeginInit();
            SuspendLayout();
            // 
            // BtnSave
            // 
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnSave.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnSave.Location = new Point(18, 27);
            BtnSave.Margin = new Padding(3, 6, 3, 6);
            BtnSave.Size = new Size(149, 68);
            BtnSave.Text = "✔ حفظ وتكليف";
            // 
            // BtnCancel
            // 
            BtnCancel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnCancel.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnCancel.Location = new Point(178, 27);
            BtnCancel.Margin = new Padding(3, 6, 3, 6);
            BtnCancel.Size = new Size(126, 68);
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(btnPrint);
            bottomPanel.Location = new Point(0, 841);
            bottomPanel.Margin = new Padding(3, 6, 3, 6);
            bottomPanel.Size = new Size(457, 126);
            bottomPanel.Controls.SetChildIndex(btnPrint, 0);
            bottomPanel.Controls.SetChildIndex(BtnCancel, 0);
            bottomPanel.Controls.SetChildIndex(BtnSave, 0);
            // 
            // CbPackager
            // 
            CbPackager.DropDownStyle = ComboBoxStyle.DropDownList;
            CbPackager.FlatStyle = FlatStyle.Flat;
            CbPackager.Font = Theme.FontSmall;
            CbPackager.Location = new Point(18, 81);
            CbPackager.Margin = new Padding(3, 6, 3, 6);
            CbPackager.Name = "CbPackager";
            CbPackager.Size = new Size(420, 26);
            CbPackager.TabIndex = 3;
            CbPackager.SelectedIndexChanged += CbPackager_SelectedIndexChanged;
            // 
            // _grid
            // 
            _grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _grid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            _grid.Location = new Point(18, 205);
            _grid.Margin = new Padding(3, 6, 3, 6);
            _grid.Name = "_grid";
            _grid.RowHeadersWidth = 51;
            _grid.Size = new Size(421, 483);
            _grid.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = Theme.FontBodyB;
            label1.ForeColor = Color.FromArgb(107, 124, 128);
            label1.Location = new Point(18, 31);
            label1.Name = "label1";
            label1.Size = new Size(78, 18);
            label1.TabIndex = 4;
            label1.Text = "اختر موظف التعبئة";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = Theme.FontBodyB;
            label2.ForeColor = Color.FromArgb(107, 124, 128);
            label2.Location = new Point(18, 155);
            label2.Name = "label2";
            label2.Size = new Size(91, 18);
            label2.TabIndex = 2;
            label2.Text = "تفاصيل الطلب";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(70, 140, 180);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = Theme.FontBodyB;
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(320, 27);
            btnPrint.Margin = new Padding(3, 6, 3, 6);
            btnPrint.Name = "btnPrint";
            btnPrint.Radius = 6;
            btnPrint.Size = new Size(103, 68);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "🖨 طباعة";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += BtnPrint_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "المنتج";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "الكمية";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // AssignOrderDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 29F);
            ClientSize = new Size(457, 967);
            Controls.Add(_grid);
            Controls.Add(label2);
            Controls.Add(CbPackager);
            Controls.Add(label1);
            Margin = new Padding(3, 6, 3, 6);
            Name = "AssignOrderDialog";
            Text = "تكليف الطلب";
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(CbPackager, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(_grid, 0);
            Controls.SetChildIndex(bottomPanel, 0);
            bottomPanel.ResumeLayout(false);
            ((ISupportInitialize)_grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
