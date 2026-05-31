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
            this._catalogFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.catalogSearch = new System.Windows.Forms.TextBox();
            this._lblSelectionCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _catalogFlow
            // 
            this._catalogFlow.AutoScroll = true;
            this._catalogFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this._catalogFlow.Location = new System.Drawing.Point(0, 29);
            this._catalogFlow.Name = "_catalogFlow";
            this._catalogFlow.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this._catalogFlow.Size = new System.Drawing.Size(784, 532);
            this._catalogFlow.TabIndex = 0;
            // 
            // catalogSearch
            // 
            this.catalogSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.catalogSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.catalogSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.catalogSearch.Location = new System.Drawing.Point(0, 0);
            this.catalogSearch.Name = "catalogSearch";
            this.catalogSearch.PlaceholderText = "🔍 ابحث عن منتج...";
            this.catalogSearch.Size = new System.Drawing.Size(784, 29);
            this.catalogSearch.TabIndex = 1;
            this.catalogSearch.TextChanged += new System.EventHandler(this.CatalogSearch_TextChanged);
            // 
            // _lblSelectionCount
            // 
            this._lblSelectionCount.AutoSize = true;
            this._lblSelectionCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._lblSelectionCount.Location = new System.Drawing.Point(300, 20);
            this._lblSelectionCount.Name = "_lblSelectionCount";
            this._lblSelectionCount.Size = new System.Drawing.Size(150, 20);
            this._lblSelectionCount.TabIndex = 2;
            this._lblSelectionCount.Text = "تم اختيار 0 منتجات";
            this.bottomPanel.Controls.Add(this._lblSelectionCount);
            // 
            // ChooseProductsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this._catalogFlow);
            this.Controls.Add(this.catalogSearch);
            this.Name = "ChooseProductsDialog";
            this.Text = "اختيار المنتجات";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.FlowLayoutPanel _catalogFlow;
        private System.Windows.Forms.TextBox catalogSearch;
        private System.Windows.Forms.Label _lblSelectionCount;
    }
}
