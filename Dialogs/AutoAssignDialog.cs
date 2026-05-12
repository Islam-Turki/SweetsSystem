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
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class AutoAssignDialog : BaseDialog
    {
        private readonly List<Order> _pendingOrders;
        private readonly List<Employee> _packagers;

        /// <summary>
        /// After the dialog closes with OK, this contains the assignment results.
        /// </summary>
        public List<(Order Order, Employee Packager)> Assignments { get; } = new();

        public AutoAssignDialog()
        {
            InitializeComponent();
            _pendingOrders = new List<Order>();
            _packagers = new List<Employee>();
        }

        /// <summary>
        /// Creates the dialog pre-loaded with the pending orders for the given date.
        /// </summary>
        public AutoAssignDialog(DateTime targetDate) : this()
        {
            // Get pending orders for the target date
            _pendingOrders = MockData.Orders
                .Where(o => o.OrderDate.Date == targetDate.Date && o.Status == OrderStatus.Pending)
                .ToList();

            // Get all packager employees
            _packagers = MockData.Employees
                .Where(e => e.Role == EmployeeRole.Packager)
                .ToList();

            // Show pending count
            string dayLabel = targetDate.Date == DateTime.Today ? "اليوم" : "الغد";
            lblPendingCount.Text = $"⏳ {_pendingOrders.Count} طلب معلق — {dayLabel} ({targetDate:dd/MM})";

            // Populate the packagers checklist
            ClbPackagers.Items.Clear();
            for (int i = 0; i < _packagers.Count; i++)
            {
                var p = _packagers[i];
                int currentLoad = MockData.Orders.Count(
                    o => o.OrderDate.Date == targetDate.Date && o.PackagerId == p.Id);
                string display = $"{p.Name}   —   الحمل الحالي: {currentLoad} طلبات";
                ClbPackagers.Items.Add(display);

                // Check available ones by default
                ClbPackagers.SetItemChecked(i, p.IsAvailable);
            }
        }

        private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool check = chkSelectAll.Checked;
            for (int i = 0; i < ClbPackagers.Items.Count; i++)
                ClbPackagers.SetItemChecked(i, check);
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            // Get selected packagers
            var selectedPackagers = new List<Employee>();
            for (int i = 0; i < ClbPackagers.Items.Count; i++)
            {
                if (ClbPackagers.GetItemChecked(i))
                    selectedPackagers.Add(_packagers[i]);
            }

            if (selectedPackagers.Count == 0)
            {
                MessageBox.Show("يرجى اختيار معبّئ واحد على الأقل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_pendingOrders.Count == 0)
            {
                MessageBox.Show("لا توجد طلبات معلقة.", "معلومة",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Round-robin assignment
            Assignments.Clear();
            for (int i = 0; i < _pendingOrders.Count; i++)
            {
                var order = _pendingOrders[i];
                var packager = selectedPackagers[i % selectedPackagers.Count];

                order.Packager = packager;
                order.PackagerId = packager.Id;
                order.Status = OrderStatus.Assigned;

                Assignments.Add((order, packager));

                // Print the order ticket
                string ticket = paperBuilder.BuildOrderTicket(order);
                RawPrinterHelper.PrintOut(ticket);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
