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
    using System.Windows.Forms;
    using System.Xml.Linq;

    public partial class CustomerDialog : BaseDialog
    {
        public CustomerDialog()
        {
            InitializeComponent();
            TxName.KeyPress += ValidationHelper.LettersOnly;
            TxPhone.KeyPress += ValidationHelper.NumbersOnly;
            TxBalance.KeyPress += ValidationHelper.DecimalsOnly;
        }

        public CustomerDialog(Customer? c = null) : this()
        {
            if (c != null)
            {
                Text = "تعديل عميل جملة";

                TxName.Text = c.Name;
                TxPhone.Text = c.Phone;
                TxBalance.Text = c.OpeningBalance.ToString("N3");
            }
            else
            {
                Text = "إضافة عميل جملة";
            }
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxName.Text) || TxName.Text.Any(char.IsDigit))
            {
                MessageBox.Show("الرجاء إدخال اسم العميل بحروف فقط (بدون أرقام).", "تحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(TxPhone.Text) && !TxPhone.Text.All(char.IsDigit))
            {
                MessageBox.Show("الرجاء إدخال رقم الهاتف كأرقام فقط.", "تحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TxBalance.Text) || !decimal.TryParse(TxBalance.Text, out _))
            {
                MessageBox.Show("الرجاء إدخال الرصيد كأرقام صحيحة.", "تحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            base.BtnSave_Click(sender, e);
        }
    }
}
