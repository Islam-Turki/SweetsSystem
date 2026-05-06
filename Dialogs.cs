using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sweetSystem
{
    //public partial class BaseDialog : Form
    //{
    //    private IContainer components = null;
    //    public FlatButton BtnSave;
    //    public FlatButton BtnCancel;
    //    protected Panel bottomPanel;

    //    public BaseDialog()
    //    {
    //        InitializeComponent();
    //    }

    //    public BaseDialog(string title, int h = 420) : this()
    //    {
    //        Text = title;
    //        ClientSize = new Size(400, h);
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null)) components.Dispose();
    //        base.Dispose(disposing);
    //    }

    //    private void InitializeComponent()
    //    {
    //        this.BtnSave = new sweetSystem.FlatButton();
    //        this.BtnCancel = new sweetSystem.FlatButton();
    //        this.bottomPanel = new System.Windows.Forms.Panel();
    //        this.bottomPanel.SuspendLayout();
    //        this.SuspendLayout();
    //        // 
    //        // bottomPanel
    //        // 
    //        this.bottomPanel.BackColor = Theme.Background;
    //        this.bottomPanel.Controls.Add(this.BtnSave);
    //        this.bottomPanel.Controls.Add(this.BtnCancel);
    //        this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
    //        this.bottomPanel.Location = new System.Drawing.Point(0, 355);
    //        this.bottomPanel.Name = "bottomPanel";
    //        this.bottomPanel.Size = new System.Drawing.Size(400, 65);
    //        this.bottomPanel.TabIndex = 0;
    //        this.bottomPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BottomPanel_Paint);
    //        // 
    //        // BtnSave
    //        // 
    //        this.BtnSave.BackColor = Theme.AccentGreen;
    //        this.BtnSave.Location = new System.Drawing.Point(16, 14);
    //        this.BtnSave.Name = "BtnSave";
    //        this.BtnSave.Size = new System.Drawing.Size(130, 35);
    //        this.BtnSave.TabIndex = 0;
    //        this.BtnSave.Text = "✔ حفظ";
    //        this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
    //        // 
    //        // BtnCancel
    //        // 
    //        this.BtnCancel.BackColor = Theme.TextSecondary;
    //        this.BtnCancel.Location = new System.Drawing.Point(156, 14);
    //        this.BtnCancel.Name = "BtnCancel";
    //        this.BtnCancel.Size = new System.Drawing.Size(110, 35);
    //        this.BtnCancel.TabIndex = 1;
    //        this.BtnCancel.Text = "✕ إلغاء";
    //        this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
    //        // 
    //        // BaseDialog
    //        // 
    //        this.BackColor = Theme.Surface;
    //        this.ClientSize = new System.Drawing.Size(400, 420);
    //        this.Controls.Add(this.bottomPanel);
    //        this.Font = Theme.FontBody;
    //        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
    //        this.MaximizeBox = false;
    //        this.MinimizeBox = false;
    //        this.Name = "BaseDialog";
    //        this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
    //        this.RightToLeftLayout = true;
    //        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
    //        this.Text = "Base Dialog";
    //        this.bottomPanel.ResumeLayout(false);
    //        this.ResumeLayout(false);
    //    }

    //    private void BottomPanel_Paint(object sender, PaintEventArgs e)
    //    {
    //        e.Graphics.DrawLine(System.Drawing.Pens.LightGray, 0, 0, bottomPanel.Width, 0);
    //    }

    //    protected virtual void BtnSave_Click(object sender, EventArgs e)
    //    {
    //        DialogResult = DialogResult.OK;
    //        Close();
    //    }

    //    protected virtual void BtnCancel_Click(object sender, EventArgs e)
    //    {
    //        DialogResult = DialogResult.Cancel;
    //        Close();
    //    }

    //    protected void AddField(string label, Control c, int y)
    //    {
    //        Controls.Add(new Label { Text = label, Left = 16, Top = y, AutoSize = true, Font = Theme.FontBodyB, ForeColor = Theme.TextSecondary });
    //        c.Left = 16; c.Top = y + 26; c.Width = ClientSize.Width - 32; c.Font = Theme.FontBody;
    //        if (c is TextBox tx) tx.BorderStyle = BorderStyle.FixedSingle;
    //        Controls.Add(c);
    //    }
    //}

    //public partial class ProductDialog : BaseDialog
    //{
    //    private IContainer components = null;
    //    public TextBox TxName;
    //    public TextBox TxCategory;
    //    public TextBox TxRetail;
    //    public TextBox TxWholesale;
    //    public ComboBox TxUnit;
    //    private Label label1;
    //    private Label label2;
    //    private Label label3;
    //    private Label label4;
    //    private Label label5;

    //    public ProductDialog()
    //    {
    //        InitializeComponent();
    //    }

    //    public ProductDialog(Product? p = null) : this()
    //    {
    //        if (p != null)
    //        {
    //            Text = "تعديل بيانات المنتج";
    //            TxName.Text = p.Name; TxCategory.Text = p.Category;
    //            TxRetail.Text = p.RetailPrice.ToString("N3");
    //            TxWholesale.Text = p.WholesalePrice.ToString("N3");
    //            if (!string.IsNullOrEmpty(p.Unit))
    //            {
    //                if (TxUnit.Items.Contains(p.Unit)) TxUnit.SelectedItem = p.Unit;
    //                else { TxUnit.Items.Add(p.Unit); TxUnit.SelectedItem = p.Unit; }
    //            }
    //        }
    //        else
    //        {
    //            Text = "إضافة منتج جديد";
    //        }
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null)) components.Dispose();
    //        base.Dispose(disposing);
    //    }

    //    private void InitializeComponent()
    //    {
    //        this.TxName = new System.Windows.Forms.TextBox();
    //        this.TxCategory = new System.Windows.Forms.TextBox();
    //        this.TxRetail = new System.Windows.Forms.TextBox();
    //        this.TxWholesale = new System.Windows.Forms.TextBox();
    //        this.TxUnit = new System.Windows.Forms.ComboBox();
    //        this.label1 = new System.Windows.Forms.Label();
    //        this.label2 = new System.Windows.Forms.Label();
    //        this.label3 = new System.Windows.Forms.Label();
    //        this.label4 = new System.Windows.Forms.Label();
    //        this.label5 = new System.Windows.Forms.Label();
    //        this.SuspendLayout();
    //        // label1
    //        this.label1.AutoSize = true;
    //        this.label1.Font = Theme.FontBodyB;
    //        this.label1.ForeColor = Theme.TextSecondary;
    //        this.label1.Location = new System.Drawing.Point(16, 16);
    //        this.label1.Name = "label1";
    //        this.label1.Size = new System.Drawing.Size(65, 15);
    //        this.label1.TabIndex = 10;
    //        this.label1.Text = "اسم المنتج";
    //        // TxName
    //        this.TxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.TxName.Font = Theme.FontBody;
    //        this.TxName.Location = new System.Drawing.Point(16, 42);
    //        this.TxName.Name = "TxName";
    //        this.TxName.Size = new System.Drawing.Size(368, 23);
    //        this.TxName.TabIndex = 0;
    //        // label2
    //        this.label2.AutoSize = true;
    //        this.label2.Font = Theme.FontBodyB;
    //        this.label2.ForeColor = Theme.TextSecondary;
    //        this.label2.Location = new System.Drawing.Point(16, 80);
    //        this.label2.Name = "label2";
    //        this.label2.Size = new System.Drawing.Size(31, 15);
    //        this.label2.TabIndex = 11;
    //        this.label2.Text = "الفئة";
    //        // TxCategory
    //        this.TxCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.TxCategory.Font = Theme.FontBody;
    //        this.TxCategory.Location = new System.Drawing.Point(16, 106);
    //        this.TxCategory.Name = "TxCategory";
    //        this.TxCategory.Size = new System.Drawing.Size(368, 23);
    //        this.TxCategory.TabIndex = 1;
    //        // label3
    //        this.label3.AutoSize = true;
    //        this.label3.Font = Theme.FontBodyB;
    //        this.label3.ForeColor = Theme.TextSecondary;
    //        this.label3.Location = new System.Drawing.Point(16, 144);
    //        this.label3.Name = "label3";
    //        this.label3.Size = new System.Drawing.Size(89, 15);
    //        this.label3.TabIndex = 12;
    //        this.label3.Text = "سعر القطاعي (د.ل)";
    //        // TxRetail
    //        this.TxRetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.TxRetail.Font = Theme.FontBody;
    //        this.TxRetail.Location = new System.Drawing.Point(16, 170);
    //        this.TxRetail.Name = "TxRetail";
    //        this.TxRetail.Size = new System.Drawing.Size(368, 23);
    //        this.TxRetail.TabIndex = 2;
    //        // label4
    //        this.label4.AutoSize = true;
    //        this.label4.Font = Theme.FontBodyB;
    //        this.label4.ForeColor = Theme.TextSecondary;
    //        this.label4.Location = new System.Drawing.Point(16, 208);
    //        this.label4.Name = "label4";
    //        this.label4.Size = new System.Drawing.Size(84, 15);
    //        this.label4.TabIndex = 13;
    //        this.label4.Text = "سعر الجملة (د.ل)";
    //        // TxWholesale
    //        this.TxWholesale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.TxWholesale.Font = Theme.FontBody;
    //        this.TxWholesale.Location = new System.Drawing.Point(16, 234);
    //        this.TxWholesale.Name = "TxWholesale";
    //        this.TxWholesale.Size = new System.Drawing.Size(368, 23);
    //        this.TxWholesale.TabIndex = 3;
    //        // label5
    //        this.label5.AutoSize = true;
    //        this.label5.Font = Theme.FontBodyB;
    //        this.label5.ForeColor = Theme.TextSecondary;
    //        this.label5.Location = new System.Drawing.Point(16, 272);
    //        this.label5.Name = "label5";
    //        this.label5.Size = new System.Drawing.Size(39, 15);
    //        this.label5.TabIndex = 14;
    //        this.label5.Text = "الوحدة";
    //        // TxUnit
    //        this.TxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    //        this.TxUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    //        this.TxUnit.Font = Theme.FontBody;
    //        this.TxUnit.FormattingEnabled = true;
    //        this.TxUnit.Items.AddRange(new object[] {
    //        "كيلوجرام",
    //        "قطعة",
    //        "علبة"});
    //        this.TxUnit.Location = new System.Drawing.Point(16, 298);
    //        this.TxUnit.Name = "TxUnit";
    //        this.TxUnit.Size = new System.Drawing.Size(368, 23);
    //        this.TxUnit.TabIndex = 4;
    //        // ProductDialog
    //        this.ClientSize = new System.Drawing.Size(400, 420);
    //        this.Controls.Add(this.TxUnit);
    //        this.Controls.Add(this.label5);
    //        this.Controls.Add(this.TxWholesale);
    //        this.Controls.Add(this.label4);
    //        this.Controls.Add(this.TxRetail);
    //        this.Controls.Add(this.label3);
    //        this.Controls.Add(this.TxCategory);
    //        this.Controls.Add(this.label2);
    //        this.Controls.Add(this.TxName);
    //        this.Controls.Add(this.label1);
    //        this.Name = "ProductDialog";
    //        this.Text = "إضافة منتج جديد";
    //        this.ResumeLayout(false);
    //        this.PerformLayout();
    //    }
    //}

    //public partial class EmployeeDialog : BaseDialog
    //{
    //    private IContainer components = null;
    //    public TextBox TxName;
    //    public ComboBox CbRole;
    //    public CheckedListBox ClbSkills;
    //    private Label label1;
    //    private Label label2;
    //    private Label label3;

    //    public EmployeeDialog()
    //    {
    //        InitializeComponent();
    //        foreach (var prod in MockData.Products) ClbSkills.Items.Add(prod);
    //    }

    //    public EmployeeDialog(Employee? e = null) : this()
    //    {
    //        if (e != null)
    //        {
    //            Text = "تعديل الموظف";
    //            TxName.Text = e.Name;
    //            CbRole.SelectedIndex = e.Role == EmployeeRole.Cook ? 0 : 1;
    //            for (int i = 0; i < ClbSkills.Items.Count; i++)
    //                ClbSkills.SetItemChecked(i, e.SkillProductIds.Contains(((Product)ClbSkills.Items[i]).Id));
    //        }
    //        else
    //        {
    //            Text = "إضافة موظف جديد";
    //        }
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null)) components.Dispose();
    //        base.Dispose(disposing);
    //    }

    //    private void InitializeComponent()
    //    {
    //        this.TxName = new System.Windows.Forms.TextBox();
    //        this.CbRole = new System.Windows.Forms.ComboBox();
    //        this.ClbSkills = new System.Windows.Forms.CheckedListBox();
    //        this.label1 = new System.Windows.Forms.Label();
    //        this.label2 = new System.Windows.Forms.Label();
    //        this.label3 = new System.Windows.Forms.Label();
    //        this.SuspendLayout();
    //        // label1
    //        this.label1.AutoSize = true;
    //        this.label1.Font = Theme.FontBodyB;
    //        this.label1.ForeColor = Theme.TextSecondary;
    //        this.label1.Location = new System.Drawing.Point(16, 16);
    //        this.label1.Name = "label1";
    //        this.label1.Size = new System.Drawing.Size(65, 15);
    //        this.label1.TabIndex = 10;
    //        this.label1.Text = "الاسم الكامل";
    //        // TxName
    //        this.TxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.TxName.Font = Theme.FontBody;
    //        this.TxName.Location = new System.Drawing.Point(16, 42);
    //        this.TxName.Name = "TxName";
    //        this.TxName.Size = new System.Drawing.Size(368, 23);
    //        this.TxName.TabIndex = 0;
    //        // label2
    //        this.label2.AutoSize = true;
    //        this.label2.Font = Theme.FontBodyB;
    //        this.label2.ForeColor = Theme.TextSecondary;
    //        this.label2.Location = new System.Drawing.Point(16, 80);
    //        this.label2.Name = "label2";
    //        this.label2.Size = new System.Drawing.Size(64, 15);
    //        this.label2.TabIndex = 11;
    //        this.label2.Text = "الدور الوظيفي";
    //        // CbRole
    //        this.CbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    //        this.CbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    //        this.CbRole.Font = Theme.FontBody;
    //        this.CbRole.FormattingEnabled = true;
    //        this.CbRole.Items.AddRange(new object[] {
    //        "طباخ",
    //        "معبّئ"});
    //        this.CbRole.Location = new System.Drawing.Point(16, 106);
    //        this.CbRole.Name = "CbRole";
    //        this.CbRole.Size = new System.Drawing.Size(368, 23);
    //        this.CbRole.TabIndex = 1;
    //        this.CbRole.SelectedIndex = 0;
    //        this.CbRole.SelectedIndexChanged += new System.EventHandler(this.CbRole_SelectedIndexChanged);
    //        // label3
    //        this.label3.AutoSize = true;
    //        this.label3.Font = Theme.FontBodyB;
    //        this.label3.ForeColor = Theme.TextSecondary;
    //        this.label3.Location = new System.Drawing.Point(16, 144);
    //        this.label3.Name = "label3";
    //        this.label3.Size = new System.Drawing.Size(155, 15);
    //        this.label3.TabIndex = 12;
    //        this.label3.Text = "مهارات الطبخ (للطباخين فقط)";
    //        // ClbSkills
    //        this.ClbSkills.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.ClbSkills.CheckOnClick = true;
    //        this.ClbSkills.Font = Theme.FontBody;
    //        this.ClbSkills.FormattingEnabled = true;
    //        this.ClbSkills.Location = new System.Drawing.Point(16, 170);
    //        this.ClbSkills.Name = "ClbSkills";
    //        this.ClbSkills.Size = new System.Drawing.Size(368, 160);
    //        this.ClbSkills.TabIndex = 2;
    //        // EmployeeDialog
    //        this.ClientSize = new System.Drawing.Size(400, 450);
    //        this.Controls.Add(this.ClbSkills);
    //        this.Controls.Add(this.label3);
    //        this.Controls.Add(this.CbRole);
    //        this.Controls.Add(this.label2);
    //        this.Controls.Add(this.TxName);
    //        this.Controls.Add(this.label1);
    //        this.Name = "EmployeeDialog";
    //        this.Text = "إضافة موظف جديد";
    //        this.ResumeLayout(false);
    //        this.PerformLayout();
    //    }

    //    private void CbRole_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        ClbSkills.Enabled = CbRole.SelectedIndex == 0;
    //    }
    //}

    //public partial class WholesaleClientDialog : BaseDialog
    //{
    //    private IContainer components = null;
    //    public TextBox TxName;
    //    public TextBox TxPhone;
    //    public TextBox TxBalance;
    //    private Label label1;
    //    private Label label2;
    //    private Label label3;

    //    public WholesaleClientDialog()
    //    {
    //        InitializeComponent();
    //    }

    //    public WholesaleClientDialog(WholesaleClient? c = null) : this()
    //    {
    //        if (c != null)
    //        {
    //            Text = "تعديل عميل جملة";
    //            TxName.Text = c.Name; TxPhone.Text = c.Phone;
    //            TxBalance.Text = c.RemainingBalance.ToString("N3");
    //        }
    //        else
    //        {
    //            Text = "إضافة عميل جملة";
    //        }
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null)) components.Dispose();
    //        base.Dispose(disposing);
    //    }

    //    private void InitializeComponent()
    //    {
    //        this.TxName = new System.Windows.Forms.TextBox();
    //        this.TxPhone = new System.Windows.Forms.TextBox();
    //        this.TxBalance = new System.Windows.Forms.TextBox();
    //        this.label1 = new System.Windows.Forms.Label();
    //        this.label2 = new System.Windows.Forms.Label();
    //        this.label3 = new System.Windows.Forms.Label();
    //        this.SuspendLayout();
    //        // label1
    //        this.label1.AutoSize = true;
    //        this.label1.Font = Theme.FontBodyB;
    //        this.label1.ForeColor = Theme.TextSecondary;
    //        this.label1.Location = new System.Drawing.Point(16, 16);
    //        this.label1.Name = "label1";
    //        this.label1.Size = new System.Drawing.Size(65, 15);
    //        this.label1.TabIndex = 10;
    //        this.label1.Text = "الاسم التجاري";
    //        // TxName
    //        this.TxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.TxName.Font = Theme.FontBody;
    //        this.TxName.Location = new System.Drawing.Point(16, 42);
    //        this.TxName.Name = "TxName";
    //        this.TxName.Size = new System.Drawing.Size(368, 23);
    //        this.TxName.TabIndex = 0;
    //        // label2
    //        this.label2.AutoSize = true;
    //        this.label2.Font = Theme.FontBodyB;
    //        this.label2.ForeColor = Theme.TextSecondary;
    //        this.label2.Location = new System.Drawing.Point(16, 80);
    //        this.label2.Name = "label2";
    //        this.label2.Size = new System.Drawing.Size(60, 15);
    //        this.label2.TabIndex = 11;
    //        this.label2.Text = "رقم الهاتف";
    //        // TxPhone
    //        this.TxPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.TxPhone.Font = Theme.FontBody;
    //        this.TxPhone.Location = new System.Drawing.Point(16, 106);
    //        this.TxPhone.Name = "TxPhone";
    //        this.TxPhone.Size = new System.Drawing.Size(368, 23);
    //        this.TxPhone.TabIndex = 1;
    //        // label3
    //        this.label3.AutoSize = true;
    //        this.label3.Font = Theme.FontBodyB;
    //        this.label3.ForeColor = Theme.TextSecondary;
    //        this.label3.Location = new System.Drawing.Point(16, 144);
    //        this.label3.Name = "label3";
    //        this.label3.Size = new System.Drawing.Size(95, 15);
    //        this.label3.TabIndex = 12;
    //        this.label3.Text = "الرصيد المتبقي (د.ل)";
    //        // TxBalance
    //        this.TxBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.TxBalance.Font = Theme.FontBody;
    //        this.TxBalance.Location = new System.Drawing.Point(16, 170);
    //        this.TxBalance.Name = "TxBalance";
    //        this.TxBalance.Size = new System.Drawing.Size(368, 23);
    //        this.TxBalance.TabIndex = 2;
    //        // WholesaleClientDialog
    //        this.ClientSize = new System.Drawing.Size(400, 300);
    //        this.Controls.Add(this.TxBalance);
    //        this.Controls.Add(this.label3);
    //        this.Controls.Add(this.TxPhone);
    //        this.Controls.Add(this.label2);
    //        this.Controls.Add(this.TxName);
    //        this.Controls.Add(this.label1);
    //        this.Name = "WholesaleClientDialog";
    //        this.Text = "إضافة عميل جملة";
    //        this.ResumeLayout(false);
    //        this.PerformLayout();
    //    }
    //}

    //public partial class OrderDialog : BaseDialog
    //{
    //    private IContainer components = null;
    //    public ComboBox CbStatus;
    //    public TextBox TxCustomer;
    //    private Label label1;
    //    private Label label2;

    //    public OrderDialog()
    //    {
    //        InitializeComponent();
    //    }

    //    public OrderDialog(Order o) : this()
    //    {
    //        Text = $"تعديل الطلب #{o.Id}";
    //        TxCustomer.Text = o.DisplayCustomer;
    //        CbStatus.SelectedIndex = (int)o.Status;
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null)) components.Dispose();
    //        base.Dispose(disposing);
    //    }

    //    private void InitializeComponent()
    //    {
    //        this.CbStatus = new System.Windows.Forms.ComboBox();
    //        this.TxCustomer = new System.Windows.Forms.TextBox();
    //        this.label1 = new System.Windows.Forms.Label();
    //        this.label2 = new System.Windows.Forms.Label();
    //        this.SuspendLayout();
    //        // label1
    //        this.label1.AutoSize = true;
    //        this.label1.Font = Theme.FontBodyB;
    //        this.label1.ForeColor = Theme.TextSecondary;
    //        this.label1.Location = new System.Drawing.Point(16, 16);
    //        this.label1.Name = "label1";
    //        this.label1.Size = new System.Drawing.Size(41, 15);
    //        this.label1.TabIndex = 10;
    //        this.label1.Text = "العميل";
    //        // TxCustomer
    //        this.TxCustomer.BackColor = Theme.Background;
    //        this.TxCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.TxCustomer.Font = Theme.FontBody;
    //        this.TxCustomer.Location = new System.Drawing.Point(16, 42);
    //        this.TxCustomer.Name = "TxCustomer";
    //        this.TxCustomer.ReadOnly = true;
    //        this.TxCustomer.Size = new System.Drawing.Size(368, 23);
    //        this.TxCustomer.TabIndex = 0;
    //        // label2
    //        this.label2.AutoSize = true;
    //        this.label2.Font = Theme.FontBodyB;
    //        this.label2.ForeColor = Theme.TextSecondary;
    //        this.label2.Location = new System.Drawing.Point(16, 80);
    //        this.label2.Name = "label2";
    //        this.label2.Size = new System.Drawing.Size(34, 15);
    //        this.label2.TabIndex = 11;
    //        this.label2.Text = "الحالة";
    //        // CbStatus
    //        this.CbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    //        this.CbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    //        this.CbStatus.Font = Theme.FontBody;
    //        this.CbStatus.FormattingEnabled = true;
    //        this.CbStatus.Items.AddRange(new object[] {
    //        "قيد الانتظار",
    //        "تم التكليف",
    //        "مكتمل"});
    //        this.CbStatus.Location = new System.Drawing.Point(16, 106);
    //        this.CbStatus.Name = "CbStatus";
    //        this.CbStatus.Size = new System.Drawing.Size(368, 23);
    //        this.CbStatus.TabIndex = 1;
    //        // OrderDialog
    //        this.ClientSize = new System.Drawing.Size(400, 250);
    //        this.Controls.Add(this.CbStatus);
    //        this.Controls.Add(this.label2);
    //        this.Controls.Add(this.TxCustomer);
    //        this.Controls.Add(this.label1);
    //        this.Name = "OrderDialog";
    //        this.Text = "تعديل الطلب";
    //        this.ResumeLayout(false);
    //        this.PerformLayout();
    //    }
    //}

    //public partial class AssignOrderDialog : BaseDialog
    //{
    //    private IContainer components = null;
    //    public ComboBox CbPackager;
    //    private DataGridView _grid;
    //    private Label label1;
    //    private Label label2;
    //    private FlatButton btnPrint;
    //    private Order _order;

    //    public AssignOrderDialog()
    //    {
    //        InitializeComponent();
    //        GridHelper.Style(_grid, readOnly: true, rtl: true);
    //        bottomPanel.Controls.Add(btnPrint);
    //        BtnSave.Text = "✔ حفظ وتكليف";
    //    }

    //    public AssignOrderDialog(Order o) : this()
    //    {
    //        _order = o;
    //        Text = $"تكليف الطلب #{o.Id} - {o.DisplayCustomer}";
            
    //        var packagers = MockData.Employees.Where(e => e.Role == EmployeeRole.Packager).ToArray();
    //        CbPackager.Items.AddRange(packagers);
    //        if (o.AssignedPackager != null && packagers.Contains(o.AssignedPackager))
    //            CbPackager.SelectedItem = o.AssignedPackager;
    //        else if (packagers.Length > 0)
    //            CbPackager.SelectedIndex = 0;

    //        foreach (var l in o.Lines) _grid.Rows.Add(l.Product.Name, l.Quantity);
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null)) components.Dispose();
    //        base.Dispose(disposing);
    //    }

    //    private void InitializeComponent()
    //    {
    //        this.CbPackager = new System.Windows.Forms.ComboBox();
    //        this._grid = new System.Windows.Forms.DataGridView();
    //        this.label1 = new System.Windows.Forms.Label();
    //        this.label2 = new System.Windows.Forms.Label();
    //        this.btnPrint = new sweetSystem.FlatButton();
    //        ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
    //        this.SuspendLayout();
    //        // label1
    //        this.label1.AutoSize = true;
    //        this.label1.Font = Theme.FontBodyB;
    //        this.label1.ForeColor = Theme.TextSecondary;
    //        this.label1.Location = new System.Drawing.Point(16, 16);
    //        this.label1.Name = "label1";
    //        this.label1.Size = new System.Drawing.Size(65, 15);
    //        this.label1.TabIndex = 10;
    //        this.label1.Text = "اختر المعبّئ";
    //        // CbPackager
    //        this.CbPackager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    //        this.CbPackager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    //        this.CbPackager.Font = Theme.FontBody;
    //        this.CbPackager.FormattingEnabled = true;
    //        this.CbPackager.Location = new System.Drawing.Point(16, 42);
    //        this.CbPackager.Name = "CbPackager";
    //        this.CbPackager.Size = new System.Drawing.Size(368, 23);
    //        this.CbPackager.TabIndex = 0;
    //        // label2
    //        this.label2.AutoSize = true;
    //        this.label2.Font = Theme.FontBodyB;
    //        this.label2.ForeColor = Theme.TextSecondary;
    //        this.label2.Location = new System.Drawing.Point(16, 80);
    //        this.label2.Name = "label2";
    //        this.label2.Size = new System.Drawing.Size(69, 15);
    //        this.label2.TabIndex = 11;
    //        this.label2.Text = "تفاصيل الطلب";
    //        // _grid
    //        this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    //        this._grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
    //        new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Product", HeaderText = "المنتج", FillWeight = 60 },
    //        new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Qty", HeaderText = "الكمية", FillWeight = 40 }});
    //        this._grid.Location = new System.Drawing.Point(16, 106);
    //        this._grid.Name = "_grid";
    //        this._grid.Size = new System.Drawing.Size(368, 250);
    //        this._grid.TabIndex = 1;
    //        // btnPrint
    //        this.btnPrint.BackColor = Theme.AccentBlue;
    //        this.btnPrint.Location = new System.Drawing.Point(280, 14);
    //        this.btnPrint.Name = "btnPrint";
    //        this.btnPrint.Size = new System.Drawing.Size(90, 35);
    //        this.btnPrint.TabIndex = 2;
    //        this.btnPrint.Text = "🖨 طباعة";
    //        this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
    //        // AssignOrderDialog
    //        this.ClientSize = new System.Drawing.Size(400, 500);
    //        this.Controls.Add(this._grid);
    //        this.Controls.Add(this.label2);
    //        this.Controls.Add(this.CbPackager);
    //        this.Controls.Add(this.label1);
    //        this.Name = "AssignOrderDialog";
    //        this.Text = "تكليف الطلب";
    //        ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
    //        this.ResumeLayout(false);
    //        this.PerformLayout();
    //    }

    //    protected override void BtnSave_Click(object sender, EventArgs e)
    //    {
    //        if (CbPackager.SelectedItem is Employee emp && _order != null)
    //        {
    //            _order.AssignedPackager = emp;
    //            _order.Status = OrderStatus.Assigned;
    //            DialogResult = DialogResult.OK;
    //            Close();
    //        }
    //    }

    //    private void BtnPrint_Click(object sender, EventArgs e)
    //    {
    //        MessageBox.Show("جاري الطباعة...", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //    }
    //}

    //public partial class DepositDialog : BaseDialog
    //{
    //    private IContainer components = null;
    //    public NumericUpDown NumAmount;
    //    private Label label1;

    //    public decimal Amount => NumAmount.Value;

    //    public DepositDialog()
    //    {
    //        InitializeComponent();
    //    }

    //    public DepositDialog(WholesaleClient c) : this()
    //    {
    //        Text = $"إيداع للعميل {c.Name}";
    //        if (c.RemainingBalance > 0)
    //        {
    //            NumAmount.Maximum = c.RemainingBalance;
    //            NumAmount.Value = c.RemainingBalance;
    //        }
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null)) components.Dispose();
    //        base.Dispose(disposing);
    //    }

    //    private void InitializeComponent()
    //    {
    //        this.NumAmount = new System.Windows.Forms.NumericUpDown();
    //        this.label1 = new System.Windows.Forms.Label();
    //        ((System.ComponentModel.ISupportInitialize)(this.NumAmount)).BeginInit();
    //        this.SuspendLayout();
    //        // label1
    //        this.label1.AutoSize = true;
    //        this.label1.Font = Theme.FontBodyB;
    //        this.label1.ForeColor = Theme.TextSecondary;
    //        this.label1.Location = new System.Drawing.Point(16, 16);
    //        this.label1.Name = "label1";
    //        this.label1.Size = new System.Drawing.Size(126, 15);
    //        this.label1.TabIndex = 10;
    //        this.label1.Text = "المبلغ المراد إيداعه (د.ل)";
    //        // NumAmount
    //        this.NumAmount.DecimalPlaces = 3;
    //        this.NumAmount.Font = Theme.FontBody;
    //        this.NumAmount.Location = new System.Drawing.Point(16, 42);
    //        this.NumAmount.Maximum = new decimal(new int[] {
    //        999999,
    //        0,
    //        0,
    //        0});
    //        this.NumAmount.Minimum = new decimal(new int[] {
    //        1,
    //        0,
    //        0,
    //        0});
    //        this.NumAmount.Name = "NumAmount";
    //        this.NumAmount.Size = new System.Drawing.Size(368, 23);
    //        this.NumAmount.TabIndex = 0;
    //        this.NumAmount.Value = new decimal(new int[] {
    //        1,
    //        0,
    //        0,
    //        0});
    //        // DepositDialog
    //        this.ClientSize = new System.Drawing.Size(400, 220);
    //        this.Controls.Add(this.NumAmount);
    //        this.Controls.Add(this.label1);
    //        this.Name = "DepositDialog";
    //        this.Text = "إيداع";
    //        ((System.ComponentModel.ISupportInitialize)(this.NumAmount)).EndInit();
    //        this.ResumeLayout(false);
    //        this.PerformLayout();
    //    }
    //}
}
