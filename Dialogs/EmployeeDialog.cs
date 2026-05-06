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

            foreach (var prod in MockData.Products)
                ClbSkills.Items.Add(prod);
        }

        public EmployeeDialog(Employee? e = null) : this()
        {
            if (e != null)
            {
                Text = "تعديل الموظف";

                TxName.Text = e.Name;

                CbRole.SelectedIndex =
                    e.Role == EmployeeRole.Cook ? 0 : 1;

                for (int i = 0; i < ClbSkills.Items.Count; i++)
                {
                    ClbSkills.SetItemChecked(
                        i,
                        e.SkillProductIds.Contains(
                            ((Product)ClbSkills.Items[i]).Id
                        )
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
    }
}
