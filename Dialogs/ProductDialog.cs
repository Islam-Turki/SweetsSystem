using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace sweetSystem
{
    //public partial class ProductDialog : Form
    //{
    //    public ProductDialog()
    //    {
    //        InitializeComponent();
    //    }
    //}
public partial class ProductDialog : BaseDialog
    {
        public ProductDialog()
        {
            InitializeComponent();
        }

        public string? SelectedImageRelativePath { get; set; }

        public ProductDialog(Product? p = null) : this()
        {
            if (p != null)
            {
                Text = "تعديل بيانات المنتج";

                TxName.Text = p.Name;
                TxCategory.Text = p.Category;
                TxRetail.Text = p.RetailPrice.ToString("N3");
                TxWholesale.Text = p.WholesalePrice.ToString("N3");

                if (!string.IsNullOrEmpty(p.Unit))
                {
                    if (TxUnit.Items.Contains(p.Unit))
                        TxUnit.SelectedItem = p.Unit;
                    else
                    {
                        TxUnit.Items.Add(p.Unit);
                        TxUnit.SelectedItem = p.Unit;
                    }
                }
            }
            else
            {
                Text = "إضافة منتج جديد";
            }
        }
    }
}
