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
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            btnPrint = new FlatButton();
            bottomPanel.SuspendLayout();
            ((ISupportInitialize)_grid).BeginInit();
            SuspendLayout();
            // 
            // BtnSave
            // 
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnSave.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnSave.Text = "✔ حفظ وتكليف";
            // 
            // BtnCancel
            // 
            BtnCancel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnCancel.FlatAppearance.MouseOverBackColor = Color.Transparent;
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(btnPrint);
            bottomPanel.Location = new Point(0, 435);
            bottomPanel.Controls.SetChildIndex(btnPrint, 0);
            bottomPanel.Controls.SetChildIndex(BtnCancel, 0);
            bottomPanel.Controls.SetChildIndex(BtnSave, 0);
            // 
            // CbPackager
            // 
            CbPackager.DropDownStyle = ComboBoxStyle.DropDownList;
            CbPackager.FlatStyle = FlatStyle.Flat;
            CbPackager.Font = new Font("Microsoft Sans Serif", 9F);
            CbPackager.Location = new Point(16, 42);
            CbPackager.Name = "CbPackager";
            CbPackager.Size = new Size(368, 23);
            CbPackager.TabIndex = 3;
            CbPackager.SelectedIndexChanged += CbPackager_SelectedIndexChanged;
            // 
            // _grid
            // 
            _grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _grid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            _grid.Location = new Point(16, 106);
            _grid.Name = "_grid";
            _grid.Size = new Size(368, 250);
            _grid.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(107, 124, 128);
            label1.Location = new Point(16, 16);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 4;
            label1.Text = "اختر المعبّئ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(107, 124, 128);
            label2.Location = new Point(16, 80);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 2;
            label2.Text = "تفاصيل الطلب";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(70, 140, 180);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(280, 14);
            btnPrint.Name = "btnPrint";
            btnPrint.Radius = 6;
            btnPrint.Size = new Size(90, 35);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "🖨 طباعة";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += BtnPrint_Click;
            // 
            // AssignOrderDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(400, 500);
            Controls.Add(_grid);
            Controls.Add(label2);
            Controls.Add(CbPackager);
            Controls.Add(label1);
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
