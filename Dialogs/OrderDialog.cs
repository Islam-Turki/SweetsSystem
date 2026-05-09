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

    public partial class OrderDialog : BaseDialog
    {
        public OrderDialog()
        {
            InitializeComponent();
        }

        public OrderDialog(Order o) : this()
        {
            Text = $"تعديل الطلب #{o.Id}";

            TxCustomer.Text = o.DisplayCustomer;
            CbStatus.SelectedIndex = (int)o.Status;
        }
    }
}
