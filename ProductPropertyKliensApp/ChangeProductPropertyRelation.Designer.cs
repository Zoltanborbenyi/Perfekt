namespace ProductPropertyKliensApp
{
    partial class ChangeProductPropertyRelation
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UpdateProductPropertyBox = new System.Windows.Forms.Button();
            this.TypePropertySearchBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.DeleteButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(299, 447);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kiválasztott termékek";
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.bindingSource1;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(332, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(185, 446);
            this.listBox1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(546, 38);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 57);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(614, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tulajdonság Értéke";
            // 
            // UpdateProductPropertyBox
            // 
            this.UpdateProductPropertyBox.Location = new System.Drawing.Point(547, 104);
            this.UpdateProductPropertyBox.Name = "UpdateProductPropertyBox";
            this.UpdateProductPropertyBox.Size = new System.Drawing.Size(117, 30);
            this.UpdateProductPropertyBox.TabIndex = 5;
            this.UpdateProductPropertyBox.Text = "Mentés";
            this.UpdateProductPropertyBox.UseVisualStyleBackColor = true;
            this.UpdateProductPropertyBox.Click += new System.EventHandler(this.UpdateProductPropertyBox_Click);
            // 
            // TypePropertySearchBox
            // 
            this.TypePropertySearchBox.Location = new System.Drawing.Point(331, 11);
            this.TypePropertySearchBox.Name = "TypePropertySearchBox";
            this.TypePropertySearchBox.Size = new System.Drawing.Size(185, 20);
            this.TypePropertySearchBox.TabIndex = 6;
            this.TypePropertySearchBox.TextChanged += new System.EventHandler(this.TypePropertySearchBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(607, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Jelenleg alkalmazottak";
            // 
            // listBox2
            // 
            this.listBox2.DataSource = this.bindingSource2;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(546, 224);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(234, 212);
            this.listBox2.TabIndex = 9;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(664, 104);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(117, 30);
            this.DeleteButton.TabIndex = 10;
            this.DeleteButton.Text = "Törlés";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 440);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "A termékek típusainak megegyzőnek kell lenniük";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(606, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "Mentés";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(546, 143);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(235, 57);
            this.textBox2.TabIndex = 13;
            // 
            // ChangeProductPropertyRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 493);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TypePropertySearchBox);
            this.Controls.Add(this.UpdateProductPropertyBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ChangeProductPropertyRelation";
            this.Text = "ChangeProductPropertyRelation";
            this.Load += new System.EventHandler(this.ChangeProductPropertyRelation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UpdateProductPropertyBox;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox TypePropertySearchBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.Button DeleteButton;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
    }
}