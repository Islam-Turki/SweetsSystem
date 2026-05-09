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

    public partial class DepositDialog : BaseDialog
    {
        public decimal Amount => NumAmount.Value;

        public DepositDialog()
        {
            InitializeComponent();
        }

        public DepositDialog(WholesaleClient c) : this()
        {
            Text = $"إيداع للعميل {c.Name}";

            if (c.RemainingBalance > 0)
            {
                NumAmount.Maximum = c.RemainingBalance;
                NumAmount.Value = c.RemainingBalance;
            }
        }
    }
}
