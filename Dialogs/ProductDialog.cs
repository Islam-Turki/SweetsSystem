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
using System.IO;

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

        private readonly string[] _imageFilters = new[] { ".jpg", ".jpeg", ".png" };

        private const string ImagesFolderRelative = "Images\\Products"; // will store under Application.ExecutablePath\Images\Products

        private void BtnChooseImage_Click(object? sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.Filter = "Images|*.jpg;*.jpeg;*.png";
            dlg.Multiselect = false;
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                // copy selected file to a temp file under Images\Products\tmp_{ticks}{ext}
                string exeDir = AppDomain.CurrentDomain.BaseDirectory;
                if (string.IsNullOrEmpty(exeDir)) return;

                string imagesDir = Path.Combine(exeDir, ImagesFolderRelative);
                if (!Directory.Exists(imagesDir)) Directory.CreateDirectory(imagesDir);

                string ext = System.IO.Path.GetExtension(dlg.FileName);
                if (!_imageFilters.Contains(ext.ToLowerInvariant()))
                {
                    MessageBox.Show("يرجى اختيار صورة بصيغة صحيحة (.jpg, .jpeg, .png)", "نوع ملف غير مدعوم", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tempName = $"tmp_{DateTime.Now.Ticks}{ext}";
                string destAbs = System.IO.Path.Combine(imagesDir, tempName);
                System.IO.File.Copy(dlg.FileName, destAbs, overwrite: true);

                SelectedImageRelativePath = Path.Combine(ImagesFolderRelative, tempName);
                // display using non-locking load
                try
                {
                    var bytes = File.ReadAllBytes(destAbs);
                    using var ms = new MemoryStream(bytes);
                    using var img = Image.FromStream(ms);
                    picProductImage.Image = new Bitmap(img);
                }
                catch { picProductImage.Image = null; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل في نسخ الصورة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

                // load image preview
                if (!string.IsNullOrWhiteSpace(p.ImagePath))
                {
                    string exeDir = AppDomain.CurrentDomain.BaseDirectory;
                    if (!string.IsNullOrEmpty(exeDir))
                    {
                        string abs = Path.Combine(exeDir, p.ImagePath);
                        if (File.Exists(abs))
                        {
                            try
                            {
                                var bytes = File.ReadAllBytes(abs);
                                using var ms = new MemoryStream(bytes);
                                using var img = Image.FromStream(ms);
                                picProductImage.Image = new Bitmap(img);
                            }
                            catch { picProductImage.Image = null; }
                        }
                    }
                }
            }
            else
            {
                Text = "إضافة منتج جديد";
                // set placeholder image if available
                picProductImage.Image = null;
            }
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            // validate simple fields
            if (string.IsNullOrWhiteSpace(TxName.Text))
            {
                MessageBox.Show("الرجاء إدخال اسم المنتج.", "تحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // If no image selected, set placeholder relative path (empty means no image)
            if (string.IsNullOrWhiteSpace(SelectedImageRelativePath))
            {
                // leave empty string so other code can decide to use placeholder
                SelectedImageRelativePath = "";
            }

            base.BtnSave_Click(sender, e);
        }
    }
}
