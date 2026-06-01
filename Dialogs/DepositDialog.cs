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
        private double _maxDebt;

        public double Amount 
        {
            get 
            {
                if (decimal.TryParse(NumAmount.Text, out decimal val))
                {
                    return (double)val;
                }
                return (double)NumAmount.Value;
            }
        }

        public DepositDialog()
        {
            InitializeComponent();
        }

        public DepositDialog(Customer c) : this()
        {
            Text = $"إيداع للعميل {c.Name}";

            // Capture the actual debt value correctly (checking both properties just in case)
            _maxDebt = Math.Max(c.Balance, c.OpeningBalance);

            if (_maxDebt > 0)
            {
                NumAmount.Maximum = (decimal)_maxDebt;
                // Safely set the initial value without exceeding the maximum
                NumAmount.Value = Math.Min(100.0m, (decimal)_maxDebt);
            }
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            // Validation: Prevent depositing more than the current debt
            if (Amount > _maxDebt)
            {
                MessageBox.Show("لا يمكن إيداع مبلغ أكبر من إجمالي الرصيد المدين للعميل.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Abort immediately so base.BtnSave_Click doesn't return DialogResult.OK
            }
            
            base.BtnSave_Click(sender, e);
        }
    }
}
