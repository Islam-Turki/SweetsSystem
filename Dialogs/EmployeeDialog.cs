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
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Xml.Linq;

    public partial class EmployeeDialog : BaseDialog
    {
        public EmployeeDialog()
        {
            InitializeComponent();
            TxName.KeyPress += ValidationHelper.LettersOnly;

            var dt = DatabaseHelper.ExecuteQuery("SELECT product_name FROM products");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                var p = new Product { Name = row["product_name"].ToString() ?? "" };
                ClbSkills.Items.Add(p);
            }
        }

        public List<string> SelectedSkills
        {
            get
            {
                var list = new List<string>();
                foreach (var item in ClbSkills.CheckedItems)
                {
                    if (item is Product p) list.Add(p.Name);
                }
                return list;
            }
        }

        public EmployeeDialog(Employee? e = null) : this()
        {
            if (e != null)
            {
                Text = "تعديل الموظف";

                TxName.Text = e.Name;

                CbRole.SelectedIndex =
                    e.Role == EmployeeRole.Cook ? 0 : 1;

                var dtSkills = DatabaseHelper.ExecuteQuery("SELECT product_name FROM products WHERE maker_phone = @p", new[] { new Microsoft.Data.SqlClient.SqlParameter("@p", e.Phone) });
                var skillNames = new List<string>();
                foreach (System.Data.DataRow r in dtSkills.Rows)
                    skillNames.Add(r["product_name"].ToString() ?? "");

                for (int i = 0; i < ClbSkills.Items.Count; i++)
                {
                    var prod = (Product)ClbSkills.Items[i];
                    ClbSkills.SetItemChecked(
                        i,
                        skillNames.Contains(prod.Name)
                    );
                }
            }
            else
            {
                Text = "إضافة موظف جديد";
            }
        }

        private void CbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClbSkills.Enabled = CbRole.SelectedIndex == 0;
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxName.Text) || TxName.Text.Any(char.IsDigit))
            {
                MessageBox.Show("الرجاء إدخال اسم الموظف بحروف فقط (بدون أرقام).", "تحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            base.BtnSave_Click(sender, e);
        }
    }
}
