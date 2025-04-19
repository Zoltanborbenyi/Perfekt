namespace ProductPropertyKliensApp
{
    partial class ProductUserConrol
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ColumnDisplay = new System.Windows.Forms.Button();
            this.ProductTypePropertyChange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ColumnDisplay
            // 
            this.ColumnDisplay.Location = new System.Drawing.Point(16, 24);
            this.ColumnDisplay.Name = "ColumnDisplay";
            this.ColumnDisplay.Size = new System.Drawing.Size(139, 53);
            this.ColumnDisplay.TabIndex = 2;
            this.ColumnDisplay.Text = "Oszlopok megjelenése";
            this.ColumnDisplay.UseVisualStyleBackColor = true;
            this.ColumnDisplay.Click += new System.EventHandler(this.ColumnDisplay_Click);
            // 
            // ProductTypePropertyChange
            // 
            this.ProductTypePropertyChange.Location = new System.Drawing.Point(660, 24);
            this.ProductTypePropertyChange.Name = "ProductTypePropertyChange";
            this.ProductTypePropertyChange.Size = new System.Drawing.Size(139, 56);
            this.ProductTypePropertyChange.TabIndex = 7;
            this.ProductTypePropertyChange.Text = "Termék(ek) tulajdonságainak módosítása";
            this.ProductTypePropertyChange.UseVisualStyleBackColor = true;
            this.ProductTypePropertyChange.Click += new System.EventHandler(this.ProductTypePropertyChange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Keress Sku, Azonosító vagy Név alapján";
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(233, 57);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(344, 20);
            this.SearchBox.TabIndex = 5;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(783, 424);
            this.dataGridView1.TabIndex = 8;
            // 
            // ProductUserConrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ProductTypePropertyChange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.ColumnDisplay);
            this.Name = "ProductUserConrol";
            this.Size = new System.Drawing.Size(819, 528);
            this.Load += new System.EventHandler(this.ProductUserConrol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ColumnDisplay;
        private System.Windows.Forms.Button ProductTypePropertyChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
