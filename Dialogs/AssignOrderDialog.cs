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
            string orderNumber = o.Id.ToString();
            Text = $"تكليف الطلب #{orderNumber} - {o.CustomerName}";

            var dtPackagers = DatabaseHelper.ExecuteQuery("SELECT phone, name FROM employee WHERE role = 'packager'");
            var packagerNames = new System.Collections.Generic.List<string>();
            foreach (System.Data.DataRow r in dtPackagers.Rows)
                packagerNames.Add(r["name"].ToString() ?? "");

            CbPackager.Items.AddRange(packagerNames.ToArray());

            if (o.Packager != null && packagerNames.Contains(o.Packager.Name))
            {
                CbPackager.SelectedItem = o.Packager.Name;
            }
            else if (packagerNames.Count > 0)
            {
                CbPackager.SelectedIndex = 0;
            }

            var itemsDt = DatabaseHelper.ExecuteQuery("SELECT product_name, quantity FROM order_items WHERE order_number = @on", new[] { new Microsoft.Data.SqlClient.SqlParameter("@on", orderNumber) });
            foreach(System.Data.DataRow row in itemsDt.Rows)
            {
                _grid.Rows.Add(row["product_name"].ToString() ?? "—", row["quantity"].ToString() ?? "0");
            }
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            if (_order == null || CbPackager.SelectedIndex < 0) return;

            string selectedName = CbPackager.SelectedItem?.ToString() ?? "";
            
            var dt = DatabaseHelper.ExecuteQuery("SELECT phone FROM employee WHERE role = 'packager' AND name = @n", new[] { new Microsoft.Data.SqlClient.SqlParameter("@n", selectedName) });
            
            if (dt.Rows.Count > 0)
            {
                string packagerPhone = dt.Rows[0]["phone"].ToString() ?? "";
                string orderNumber = _order.Id.ToString();

                DatabaseHelper.ExecuteNonQuery("UPDATE [order] SET packager_phone = @pp, status = @s WHERE order_number = @on", new[] {
                    new Microsoft.Data.SqlClient.SqlParameter("@pp", packagerPhone),
                    new Microsoft.Data.SqlClient.SqlParameter("@s", EnumHelper.ToString(OrderStatus.Assigned)),
                    new Microsoft.Data.SqlClient.SqlParameter("@on", orderNumber)
                });

                _order.Packager = new Employee { Name = selectedName, Phone = packagerPhone, Role = EmployeeRole.Packager };
                _order.Status = OrderStatus.Assigned;

                try
                {
                    PdfReportGenerator.GenerateOrderAssignmentPdf(_order.Id.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء إنشاء ملف الـ PDF:\n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (_order == null) return;
            
            try
            {
                PdfReportGenerator.GenerateOrderAssignmentPdf(_order.Id.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء إنشاء ملف الـ PDF:\n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbPackager_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
