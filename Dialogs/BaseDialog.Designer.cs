using sweetSystem;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

namespace sweetSystem
{
    partial class BaseDialog
    {
        private IContainer components = null;

        protected FlatButton BtnSave;
        protected FlatButton BtnCancel;
        protected Panel bottomPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.BtnSave = new sweetSystem.FlatButton();
            this.BtnCancel = new sweetSystem.FlatButton();
            this.bottomPanel = new Panel();

            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();

            // bottomPanel
            bottomPanel.BackColor = Theme.Background;
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 355);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(400, 65);
            bottomPanel.TabIndex = 0;
            bottomPanel.Paint += new PaintEventHandler(this.BottomPanel_Paint);

            // BtnSave
            BtnSave.BackColor = Theme.AccentGreen;
            BtnSave.Location = new Point(16, 14);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(130, 35);
            BtnSave.TabIndex = 0;
            BtnSave.Text = "✔ حفظ";
            BtnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // BtnCancel
            BtnCancel.BackColor = Theme.TextSecondary;
            BtnCancel.Location = new Point(156, 14);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(110, 35);
            BtnCancel.TabIndex = 1;
            BtnCancel.Text = "✕ إلغاء";
            BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // Add buttons to panel
            bottomPanel.Controls.Add(BtnSave);
            bottomPanel.Controls.Add(BtnCancel);

            // BaseDialog
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Theme.Surface;
            this.ClientSize = new Size(400, 420);
            this.Controls.Add(bottomPanel);
            this.Font = Theme.FontBody;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseDialog";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Base Dialog";

            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
