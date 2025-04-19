namespace ProductPropertyKliensApp
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProductButton = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.Property = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProductButton
            // 
            this.ProductButton.Location = new System.Drawing.Point(2, 12);
            this.ProductButton.Name = "ProductButton";
            this.ProductButton.Size = new System.Drawing.Size(134, 31);
            this.ProductButton.TabIndex = 0;
            this.ProductButton.Text = "Termékek";
            this.ProductButton.Click += new System.EventHandler(this.ProductButton_Click);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(2, 45);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(819, 528);
            this.panelMain.TabIndex = 1;
            // 
            // Property
            // 
            this.Property.Location = new System.Drawing.Point(142, 12);
            this.Property.Name = "Property";
            this.Property.Size = new System.Drawing.Size(134, 31);
            this.Property.TabIndex = 2;
            this.Property.Text = "Termék Tulajdonságok";
            this.Property.Click += new System.EventHandler(this.Property_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 577);
            this.Controls.Add(this.Property);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.ProductButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ProductButton;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button Property;
    }
}

