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
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class AssignOrderDialog : BaseDialog
    {
        private Order _order;

        public AssignOrderDialog()
        {
            InitializeComponent();

            GridHelper.Style(_grid, readOnly: true, rtl: true);

            bottomPanel.Controls.Add(btnPrint);
            BtnSave.Text = "✔ حفظ وتكليف";
        }

        public AssignOrderDialog(Order o) : this()
        {
            _order = o;

            Text = $"تكليف الطلب #{o.Id} - {o.DisplayCustomer}";

            var packagers = MockData.Employees
                .Where(e => e.Role == EmployeeRole.Packager)
                .ToArray();

            CbPackager.Items.AddRange(packagers);

            if (o.AssignedPackager != null &&
                packagers.Contains(o.AssignedPackager))
            {
                CbPackager.SelectedItem = o.AssignedPackager;
            }
            else if (packagers.Length > 0)
            {
                CbPackager.SelectedIndex = 0;
            }

            foreach (var l in o.Lines)
                _grid.Rows.Add(l.Product.Name, l.Quantity);
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            if (CbPackager.SelectedItem is Employee emp && _order != null)
            {
                _order.AssignedPackager = emp;
                _order.Status = OrderStatus.Assigned;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("جاري الطباعة...", "طباعة",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
