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
    using System;
    using System.Windows.Forms;

    public partial class DepositDialog : BaseDialog
    {
        public double Amount => (double)NumAmount.Value;

        public DepositDialog()
        {
            InitializeComponent();
        }

        public DepositDialog(Customer c) : this()
        {
            Text = $"إيداع للعميل {c.Name}";

            if (c.Balance > 0)
            {
                NumAmount.Maximum = (decimal)c.Balance;
                NumAmount.Value = 100.0m;
            }
        }
    }
}
