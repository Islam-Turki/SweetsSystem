using sweetSystem;
namespace sweetSystem.Dialogs
{
    partial class ChooseProductsDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            _catalogFlow = new FlowLayoutPanel();
            catalogSearch = new TextBox();
            _lblSelectionCount = new Label();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // BtnSave
            // 
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnSave.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnSave.Location = new Point(23, 31);
            BtnSave.Margin = new Padding(4, 7, 4, 7);
            BtnSave.Size = new Size(186, 77);
            // 
            // BtnCancel
            // 
            BtnCancel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnCancel.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnCancel.Location = new Point(223, 31);
            BtnCancel.Margin = new Padding(4, 7, 4, 7);
            BtnCancel.Size = new Size(157, 77);
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(_lblSelectionCount);
            bottomPanel.Location = new Point(0, 442);
            bottomPanel.Margin = new Padding(4, 7, 4, 7);
            bottomPanel.Size = new Size(1120, 143);
            bottomPanel.Controls.SetChildIndex(_lblSelectionCount, 0);
            bottomPanel.Controls.SetChildIndex(BtnCancel, 0);
            bottomPanel.Controls.SetChildIndex(BtnSave, 0);
            // 
            // _catalogFlow
            // 
            _catalogFlow.AutoScroll = true;
            _catalogFlow.Dock = DockStyle.Fill;
            _catalogFlow.Location = new Point(0, 35);
            _catalogFlow.Margin = new Padding(4, 7, 4, 7);
            _catalogFlow.Name = "_catalogFlow";
            _catalogFlow.Padding = new Padding(9, 11, 9, 11);
            _catalogFlow.Size = new Size(1120, 550);
            _catalogFlow.TabIndex = 0;
            // 
            // catalogSearch
            // 
            catalogSearch.BorderStyle = BorderStyle.FixedSingle;
            catalogSearch.Dock = DockStyle.Top;
            catalogSearch.Font = new Font("Microsoft Sans Serif", 12F);
            catalogSearch.Location = new Point(0, 0);
            catalogSearch.Margin = new Padding(4, 7, 4, 7);
            catalogSearch.Name = "catalogSearch";
            catalogSearch.PlaceholderText = "🔍 ابحث عن منتج...";
            catalogSearch.Size = new Size(1120, 35);
            catalogSearch.TabIndex = 1;
            catalogSearch.TextChanged += CatalogSearch_TextChanged;
            // 
            // _lblSelectionCount
            // 
            _lblSelectionCount.AutoSize = true;
            _lblSelectionCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            _lblSelectionCount.Location = new Point(429, 44);
            _lblSelectionCount.Margin = new Padding(4, 0, 4, 0);
            _lblSelectionCount.Name = "_lblSelectionCount";
            _lblSelectionCount.Size = new Size(166, 28);
            _lblSelectionCount.TabIndex = 2;
            _lblSelectionCount.Text = "تم اختيار 0 منتجات";
            // 
            // ChooseProductsDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 33F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 585);
            Controls.Add(_catalogFlow);
            Controls.Add(catalogSearch);
            Margin = new Padding(4, 7, 4, 7);
            Name = "ChooseProductsDialog";
            Text = "اختيار المنتجات";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(catalogSearch, 0);
            Controls.SetChildIndex(_catalogFlow, 0);
            Controls.SetChildIndex(bottomPanel, 0);
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.FlowLayoutPanel _catalogFlow;
        private System.Windows.Forms.TextBox catalogSearch;
        private System.Windows.Forms.Label _lblSelectionCount;
    }
}
