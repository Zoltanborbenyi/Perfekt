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
            this.ProductTypeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProductButton
            // 
            this.ProductButton.Location = new System.Drawing.Point(3, 19);
            this.ProductButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ProductButton.Name = "ProductButton";
            this.ProductButton.Size = new System.Drawing.Size(402, 48);
            this.ProductButton.TabIndex = 0;
            this.ProductButton.Text = "Termékek";
            this.ProductButton.Click += new System.EventHandler(this.ProductButton_Click);
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.Location = new System.Drawing.Point(3, 69);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1237, 819);
            this.panelMain.TabIndex = 1;
            // 
            // Property
            // 
            this.Property.Location = new System.Drawing.Point(838, 19);
            this.Property.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Property.Name = "Property";
            this.Property.Size = new System.Drawing.Size(402, 48);
            this.Property.TabIndex = 2;
            this.Property.Text = "Termék Tulajdonságok";
            this.Property.Click += new System.EventHandler(this.Property_Click);
            // 
            // ProductTypeButton
            // 
            this.ProductTypeButton.Location = new System.Drawing.Point(421, 19);
            this.ProductTypeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ProductTypeButton.Name = "ProductTypeButton";
            this.ProductTypeButton.Size = new System.Drawing.Size(402, 48);
            this.ProductTypeButton.TabIndex = 3;
            this.ProductTypeButton.Text = "Termék Típusok";
            this.ProductTypeButton.Click += new System.EventHandler(this.ProductTypeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1243, 888);
            this.Controls.Add(this.Property);
            this.Controls.Add(this.ProductTypeButton);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.ProductButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ProductButton;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button Property;
        private System.Windows.Forms.Button ProductTypeButton;
    }
}

