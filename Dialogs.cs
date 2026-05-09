using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem
{
    public class BaseDialog : Form
    {
        public FlatButton BtnSave { get; }
        public FlatButton BtnCancel { get; }

        public BaseDialog(string title, int h = 420)
        {
            Text = title;
            ClientSize = new Size(400, h);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            BackColor = Theme.Surface;
            Font = Theme.FontBody;

            var bottom = new Panel { Dock = DockStyle.Bottom, Height = 65, BackColor = Theme.Background };
            bottom.Paint += (s, e) => { e.Graphics.DrawLine(System.Drawing.Pens.LightGray, 0, 0, bottom.Width, 0); };

            BtnSave = new FlatButton { Text = "✔ حفظ", BackColor = Theme.AccentGreen, Left = 16, Top = 14, Width = 130 };
            BtnCancel = new FlatButton { Text = "✕ إلغاء", BackColor = Theme.TextSecondary, Left = 156, Top = 14, Width = 110 };
            BtnSave.Click += (_, _) => { DialogResult = DialogResult.OK; Close(); };
            BtnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };

            bottom.Controls.AddRange(new Control[] { BtnSave, BtnCancel });
            Controls.Add(bottom);
        }

        protected void AddField(string label, Control c, int y)
        {
            Controls.Add(new Label { Text = label, Left = 16, Top = y, AutoSize = true, Font = Theme.FontBodyB, ForeColor = Theme.TextSecondary });
            c.Left = 16; c.Top = y + 26; c.Width = ClientSize.Width - 32; c.Font = Theme.FontBody;
            if (c is TextBox tx) tx.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(c);
        }

        private void InitializeComponent()
        {

        }
    }

    public class ProductDialog : BaseDialog
    {
        public TextBox  TxName     = new();
        public TextBox  TxCategory = new();
        public TextBox  TxRetail   = new();
        public TextBox  TxWholesale = new();
        public ComboBox TxUnit     = new() { FlatStyle = FlatStyle.Flat, DropDownStyle = ComboBoxStyle.DropDownList };

        /// <summary>Relative path to the chosen image (e.g. "Images\3.png"). Empty if none.</summary>
        public string SelectedImageRelativePath { get; private set; } = "";

        private readonly PictureBox _preview;
        private string _tempImageSource = ""; // absolute path user picked

        public ProductDialog(Product? p = null)
            : base(p == null ? "إضافة منتج جديد" : "تعديل بيانات المنتج", 560)
        {
            // ── Standard fields ──────────────────────────────────────────────
            int y = 16;
            AddField("اسم المنتج",          TxName,      y); y += 64;
            AddField("الفئة",               TxCategory,  y); y += 64;
            AddField("سعر القطاعي (د.ل)",   TxRetail,    y); y += 64;
            AddField("سعر الجملة (د.ل)",    TxWholesale, y); y += 64;

            TxUnit.Items.AddRange(new object[] { "كيلوجرام", "قطعة", "علبة" });
            if (TxUnit.Items.Count > 0) TxUnit.SelectedIndex = 0;
            AddField("الوحدة", TxUnit, y); y += 64;

            // ── Image section ─────────────────────────────────────────────────
            Controls.Add(new Label
            {
                Text      = "صورة المنتج",
                Left      = 16, Top = y,
                AutoSize  = true,
                Font      = Theme.FontBodyB,
                ForeColor = Theme.TextSecondary
            });
            y += 22;

            // Preview box
            _preview = new PictureBox
            {
                Left      = 16, Top = y,
                Width     = 120, Height = 90,
                SizeMode  = PictureBoxSizeMode.Zoom,
                BackColor = Theme.Background,
                BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(_preview);

            // Upload button
            var btnUpload = new FlatButton
            {
                Text      = "📁 رفع صورة",
                Left      = 146, Top = y + 20,
                Width     = 130, Height = 34,
                BackColor = Theme.AccentBlue,
                ForeColor = Color.White,
                Font      = Theme.FontBodyB,
                Radius    = 6
            };
            btnUpload.Click += BtnUpload_Click;
            Controls.Add(btnUpload);

            // Clear image button
            var btnClear = new FlatButton
            {
                Text      = "✕ حذف الصورة",
                Left      = 146, Top = y + 60,
                Width     = 130, Height = 28,
                BackColor = Theme.TextSecondary,
                ForeColor = Color.White,
                Font      = Theme.FontBody,
                Radius    = 6
            };
            btnClear.Click += (_, _) =>
            {
                _tempImageSource             = "";
                SelectedImageRelativePath    = "";
                _preview.Image               = null;
                _preview.BackColor           = Theme.Background;
            };
            Controls.Add(btnClear);

            // ── Populate if editing ──────────────────────────────────────────
            if (p != null)
            {
                TxName.Text      = p.Name;
                TxCategory.Text  = p.Category;
                TxRetail.Text    = p.RetailPrice.ToString("N3");
                TxWholesale.Text = p.WholesalePrice.ToString("N3");

                if (!string.IsNullOrEmpty(p.Unit))
                {
                    if (TxUnit.Items.Contains(p.Unit)) TxUnit.SelectedItem = p.Unit;
                    else { TxUnit.Items.Add(p.Unit); TxUnit.SelectedItem = p.Unit; }
                }

                // Load existing image into preview
                if (!string.IsNullOrWhiteSpace(p.ImagePath))
                {
                    SelectedImageRelativePath = p.ImagePath;
                    string abs = GetAbsPath(p.ImagePath);
                    if (System.IO.File.Exists(abs))
                    {
                        try { _preview.Image = Image.FromFile(abs); }
                        catch { /* ignore corrupt image */ }
                    }
                }
            }

            // ── Override Save to copy the image file before closing ──────────
            BtnSave.Click -= DefaultSave;   // remove default close handler
            BtnSave.Click += ImageAwareSave;
        }

        // ── Event handlers ────────────────────────────────────────────────────
        private void BtnUpload_Click(object? sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title  = "اختر صورة المنتج",
                Filter = "ملفات الصور|*.jpg;*.jpeg;*.png;*.bmp;*.webp|الكل|*.*"
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            _tempImageSource = dlg.FileName;
            try
            {
                _preview.Image     = Image.FromFile(_tempImageSource);
                _preview.BackColor = Color.White;
            }
            catch
            {
                MessageBox.Show("تعذّر تحميل الصورة، تحقق من صيغة الملف.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _tempImageSource = "";
            }
        }

        private void DefaultSave(object? s, EventArgs e) { }   // placeholder — never bound

        private void ImageAwareSave(object? s, EventArgs e)
        {
            // Copy image to Images\ folder if a new one was picked
            if (!string.IsNullOrWhiteSpace(_tempImageSource) &&
                System.IO.File.Exists(_tempImageSource))
            {
                try
                {
                    string imagesDir = System.IO.Path.Combine(
                        System.IO.Path.GetDirectoryName(Application.ExecutablePath) ?? "",
                        "Images");
                    System.IO.Directory.CreateDirectory(imagesDir);

                    string ext      = System.IO.Path.GetExtension(_tempImageSource);
                    // Use a temp name; the caller should rename to ProductId after save
                    string fileName = $"product_new{ext}";
                    string destPath = System.IO.Path.Combine(imagesDir, fileName);
                    System.IO.File.Copy(_tempImageSource, destPath, overwrite: true);

                    SelectedImageRelativePath = System.IO.Path.Combine("Images", fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"لم يتمكن من حفظ الصورة:\n{ex.Message}", "تحذير",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private static string GetAbsPath(string relative)
        {
            string? dir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            return dir != null ? System.IO.Path.Combine(dir, relative) : relative;
        }
    }

    public class EmployeeDialog : BaseDialog
    {
        public TextBox TxName = new();
        public ComboBox CbRole = new() { FlatStyle = FlatStyle.Flat, DropDownStyle = ComboBoxStyle.DropDownList };
        public CheckedListBox ClbSkills = new() { BorderStyle = BorderStyle.FixedSingle, CheckOnClick = true };
        
        public EmployeeDialog(Employee? e = null) : base(e == null ? "إضافة موظف جديد" : "تعديل الموظف", 450)
        {
            CbRole.Items.AddRange(new[] { "طباخ", "معبّئ" });
            CbRole.SelectedIndex = 0;
            
            int y = 16;
            AddField("الاسم الكامل", TxName, y); y += 64;
            AddField("الدور الوظيفي", CbRole, y); y += 64;
            
            foreach (var prod in MockData.Products) ClbSkills.Items.Add(prod);
            ClbSkills.Height = 160;
            AddField("مهارات الطبخ (للطباخين فقط)", ClbSkills, y);
            
            CbRole.SelectedIndexChanged += (_, _) => ClbSkills.Enabled = CbRole.SelectedIndex == 0;
            
            if (e != null)
            {
                TxName.Text = e.Name;
                CbRole.SelectedIndex = e.Role == EmployeeRole.Cook ? 0 : 1;
                for (int i = 0; i < ClbSkills.Items.Count; i++)
                    ClbSkills.SetItemChecked(i, e.SkillProductIds.Contains(((Product)ClbSkills.Items[i]).Id));
            }
        }
    }

    public class WholesaleClientDialog : BaseDialog
    {
        public TextBox TxName = new(), TxPhone = new(), TxBalance = new();
        
        public WholesaleClientDialog(WholesaleClient? c = null) : base(c == null ? "إضافة عميل جملة" : "تعديل عميل جملة", 300)
        {
            int y = 16;
            AddField("الاسم التجاري", TxName, y); y += 64;
            AddField("رقم الهاتف", TxPhone, y); y += 64;
            AddField("الرصيد المتبقي (د.ل)", TxBalance, y);
            
            if (c != null)
            {
                TxName.Text = c.Name; TxPhone.Text = c.Phone;
                TxBalance.Text = c.RemainingBalance.ToString("N3");
            }
        }
    }

    public class OrderDialog : BaseDialog
    {
        public ComboBox CbStatus = new() { FlatStyle = FlatStyle.Flat, DropDownStyle = ComboBoxStyle.DropDownList };
        public TextBox TxCustomer = new() { ReadOnly = true, BackColor = Theme.Background };
        
        public OrderDialog(Order o) : base($"تعديل الطلب #{o.Id}", 250)
        {
            CbStatus.Items.AddRange(new[] { "قيد الانتظار", "تم التكليف", "مكتمل" });
            int y = 16;
            AddField("العميل", TxCustomer, y); y += 64;
            AddField("الحالة", CbStatus, y);
            
            TxCustomer.Text = o.DisplayCustomer;
            CbStatus.SelectedIndex = (int)o.Status;
        }
    }

    public class AssignOrderDialog : BaseDialog
    {
        public ComboBox CbPackager = new() { FlatStyle = FlatStyle.Flat, DropDownStyle = ComboBoxStyle.DropDownList };
        private DataGridView _grid = new();
        private Order _order;
        
        public AssignOrderDialog(Order o) : base($"تكليف الطلب #{o.Id} - {o.DisplayCustomer}", 500)
        {
            _order = o;
            int y = 16;
            
            var packagers = MockData.Employees.Where(e => e.Role == EmployeeRole.Packager).ToArray();
            CbPackager.Items.AddRange(packagers);
            if (o.AssignedPackager != null && packagers.Contains(o.AssignedPackager))
                CbPackager.SelectedItem = o.AssignedPackager;
            else if (packagers.Length > 0)
                CbPackager.SelectedIndex = 0;
            
            AddField("اختر المعبّئ", CbPackager, y); y += 64;
            
            Controls.Add(new Label { Text = "تفاصيل الطلب", Left = 16, Top = y, AutoSize = true, Font = Theme.FontBodyB, ForeColor = Theme.TextSecondary });
            y += 26;
            
            _grid.Left = 16; _grid.Top = y; _grid.Width = ClientSize.Width - 32; _grid.Height = 250;
            GridHelper.Style(_grid, readOnly: true, rtl: true);
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Product", HeaderText = "المنتج", FillWeight = 60 });
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qty", HeaderText = "الكمية", FillWeight = 40 });
            foreach (var l in o.Lines) _grid.Rows.Add(l.Product.Name, l.Quantity);
            Controls.Add(_grid);
            
            BtnSave.Text = "✔ حفظ وتكليف";
            BtnSave.Click += (_, _) => 
            {
                if (CbPackager.SelectedItem is Employee emp)
                {
                    _order.AssignedPackager = emp;
                    _order.Status = OrderStatus.Assigned;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            };
            
            var btnPrint = new FlatButton { Text = "🖨 طباعة", BackColor = Theme.AccentBlue, Left = 280, Top = 14, Width = 90 };
            btnPrint.Click += (_, _) => MessageBox.Show("جاري الطباعة...", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            var bottom = Controls.OfType<Panel>().Last();
            bottom.Controls.Add(btnPrint);
        }
    }

    public class DepositDialog : BaseDialog
    {
        public NumericUpDown NumAmount = new() { Minimum = 1, Maximum = 999999, DecimalPlaces = 3 };
        public decimal Amount => NumAmount.Value;
        
        public DepositDialog(WholesaleClient c) : base($"إيداع للعميل {c.Name}", 220)
        {
            int y = 16;
            AddField("المبلغ المراد إيداعه (د.ل)", NumAmount, y);
            
            if (c.RemainingBalance > 0)
            {
                NumAmount.Maximum = c.RemainingBalance;
                NumAmount.Value = c.RemainingBalance;
            }
            
            BtnSave.Click += (_, _) => { DialogResult = DialogResult.OK; Close(); };
        }
    }
}
