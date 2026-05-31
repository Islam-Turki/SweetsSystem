using sweetSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sweetSystem
{

public partial class BaseDialog : Form
    {
        public BaseDialog()
        {
            InitializeComponent();
        }

        public BaseDialog(string title, int h = 420) : this()
        {
            Text = title;
            ClientSize = new Size(400, h);
        }

        protected virtual void BtnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        protected virtual void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BottomPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.LightGray, 0, 0, bottomPanel.Width, 0);
        }

        protected void AddField(string label, Control c, int y)
        {
            Controls.Add(new Label
            {
                Text = label,
                Left = 16,
                Top = y,
                AutoSize = true,
                Font = Theme.FontBodyB,
                ForeColor = Theme.TextSecondary
            });

            c.Left = 16;
            c.Top = y + 26;
            c.Width = ClientSize.Width - 32;
            c.Font = Theme.FontBody;

            if (c is TextBox tx)
                tx.BorderStyle = BorderStyle.FixedSingle;

            Controls.Add(c);
        }
    }
}
