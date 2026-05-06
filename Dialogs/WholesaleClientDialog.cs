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

    public partial class WholesaleClientDialog : BaseDialog
    {
        public WholesaleClientDialog()
        {
            InitializeComponent();
        }

        public WholesaleClientDialog(WholesaleClient? c = null) : this()
        {
            if (c != null)
            {
                Text = "تعديل عميل جملة";

                TxName.Text = c.Name;
                TxPhone.Text = c.Phone;
                TxBalance.Text = c.RemainingBalance.ToString("N3");
            }
            else
            {
                Text = "إضافة عميل جملة";
            }
        }
    }
}
