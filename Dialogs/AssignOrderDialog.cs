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
    using sweetSystem.printerUrils;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class AssignOrderDialog : BaseDialog
    {
        private Order? _order;

        public AssignOrderDialog()
        {
            InitializeComponent();

            GridHelper.Style(_grid, readOnly: true, rtl: true);
        }

        public AssignOrderDialog(Order o) : this()
        {
            _order = o;

            Text = $"تكليف الطلب #{o.Id} - {o.CustomerName}";

            var packagers = MockData.Employees
                .Where(e => e.Role == EmployeeRole.Packager)
                .ToArray();
            string[] packagerNames = MockData.Employees
    .Where(e => e.Role == EmployeeRole.Packager)
    .Select(e => e.Name)
    .ToArray();

            CbPackager.Items.AddRange(packagerNames);

            if (o.Packager != null &&
                packagers.Contains(o.Packager))
            {
                CbPackager.SelectedItem = o.Packager;
            }
            else if (packagers.Length > 0)
            {
                CbPackager.SelectedIndex = 0;
            }

            foreach (var l in MockData.OrderItems.Where(oi => oi.OrderId == o.Id))
                _grid.Rows.Add(l.Product?.Name ?? "—", l.Quantity);

            //string text = paperBuilder.BuildOrderTicket(o);

            //MessageBox.Show(text, "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //RawPrinterHelper.PrintOut(text);
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            if (_order == null || CbPackager.SelectedIndex < 0) return;

            string selectedName = CbPackager.SelectedItem?.ToString() ?? "";
            var emp = MockData.Employees.FirstOrDefault(
                emp => emp.Role == EmployeeRole.Packager && emp.Name == selectedName);

            if (emp != null)
            {
                _order.Packager = emp;
                _order.PackagerId = emp.Id;
                _order.Status = OrderStatus.Assigned;

                // Print the order ticket
                string ticket = paperBuilder.BuildOrderTicket(_order);
                RawPrinterHelper.PrintOut(ticket);

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (_order == null) return;
            string ticket = paperBuilder.BuildOrderTicket(_order);
            MessageBox.Show(ticket, "معاينة الطباعة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CbPackager_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
