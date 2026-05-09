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
            this.CbPackager = new ComboBox();
            this._grid = new DataGridView();
            this.label1 = new Label();
            this.label2 = new Label();
            this.btnPrint = new sweetSystem.FlatButton();

            ((ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = Theme.FontBodyB;
            label1.ForeColor = Theme.TextSecondary;
            label1.Location = new Point(16, 16);
            label1.Text = "اختر المعبّئ";

            // CbPackager
            CbPackager.DropDownStyle = ComboBoxStyle.DropDownList;
            CbPackager.FlatStyle = FlatStyle.Flat;
            CbPackager.Font = Theme.FontBody;
            CbPackager.Location = new Point(16, 42);
            CbPackager.Size = new Size(368, 23);

            // label2
            label2.AutoSize = true;
            label2.Font = Theme.FontBodyB;
            label2.ForeColor = Theme.TextSecondary;
            label2.Location = new Point(16, 80);
            label2.Text = "تفاصيل الطلب";

            // _grid
            _grid.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            _grid.Columns.AddRange(
                new DataGridViewColumn[]
                {
                new DataGridViewTextBoxColumn
                {
                    Name = "Product",
                    HeaderText = "المنتج",
                    FillWeight = 60
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Qty",
                    HeaderText = "الكمية",
                    FillWeight = 40
                }
                });

            _grid.Location = new Point(16, 106);
            _grid.Size = new Size(368, 250);

            // btnPrint
            btnPrint.BackColor = Theme.AccentBlue;
            btnPrint.Location = new Point(280, 14);
            btnPrint.Size = new Size(90, 35);
            btnPrint.Text = "🖨 طباعة";
            btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);

            // Form
            this.ClientSize = new Size(400, 500);

            this.Controls.Add(_grid);
            this.Controls.Add(label2);

            this.Controls.Add(CbPackager);
            this.Controls.Add(label1);

            this.Name = "AssignOrderDialog";
            this.Text = "تكليف الطلب";

            ((ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}