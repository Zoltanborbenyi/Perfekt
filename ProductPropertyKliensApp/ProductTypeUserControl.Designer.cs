namespace ProductPropertyKliensApp
{
    partial class ProductTypeUserControl
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
            this.components = new System.ComponentModel.Container();
            this.SearchBoxForTypes = new System.Windows.Forms.TextBox();
            this.ProductTypeBox = new System.Windows.Forms.ListBox();
            this.productTypeBinding = new System.Windows.Forms.BindingSource(this.components);
            this.PropertyTypeLable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TypePropertyListBox = new System.Windows.Forms.ListBox();
            this.PropertyBinding = new System.Windows.Forms.BindingSource(this.components);
            this.TypePropertySearchBox = new System.Windows.Forms.TextBox();
            this.NewTypeBox = new System.Windows.Forms.TextBox();
            this.CreateNewType = new System.Windows.Forms.Button();
            this.DeleteType = new System.Windows.Forms.Button();
            this.LinkBetweenTypeAndProperty = new System.Windows.Forms.Button();
            this.DeleteLinkBetweenTypeAndProperty = new System.Windows.Forms.Button();
            this.PropertyNameBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PropertyDefaultValueBox = new System.Windows.Forms.TextBox();
            this.PropertyDisplayNameBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.PropertyNameLib = new System.Windows.Forms.Label();
            this.PropertyDispalyNameLib = new System.Windows.Forms.Label();
            this.PropertyDefaultValueLib = new System.Windows.Forms.Label();
            this.PropertyCreateButton = new System.Windows.Forms.Button();
            this.NewTypeNameLib = new System.Windows.Forms.Label();
            this.DeletePropertyBotton = new System.Windows.Forms.Button();
            this.PropertyListOfTheTypeListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productTypeBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchBoxForTypes
            // 
            this.SearchBoxForTypes.Font = new System.Drawing.Font("Arial", 10F);
            this.SearchBoxForTypes.Location = new System.Drawing.Point(8, 39);
            this.SearchBoxForTypes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchBoxForTypes.Name = "SearchBoxForTypes";
            this.SearchBoxForTypes.Size = new System.Drawing.Size(296, 30);
            this.SearchBoxForTypes.TabIndex = 0;
            this.SearchBoxForTypes.TextChanged += new System.EventHandler(this.SearchBoxForTypes_TextChanged_1);
            // 
            // ProductTypeBox
            // 
            this.ProductTypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ProductTypeBox.DataSource = this.productTypeBinding;
            this.ProductTypeBox.DisplayMember = "ProductTypeName";
            this.ProductTypeBox.Font = new System.Drawing.Font("Arial", 10F);
            this.ProductTypeBox.FormattingEnabled = true;
            this.ProductTypeBox.ItemHeight = 23;
            this.ProductTypeBox.Location = new System.Drawing.Point(8, 89);
            this.ProductTypeBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ProductTypeBox.Name = "ProductTypeBox";
            this.ProductTypeBox.Size = new System.Drawing.Size(296, 717);
            this.ProductTypeBox.TabIndex = 1;
            this.ProductTypeBox.SelectedIndexChanged += new System.EventHandler(this.ProductTypeBox_SelectedIndexChanged);
            // 
            // PropertyTypeLable
            // 
            this.PropertyTypeLable.AutoSize = true;
            this.PropertyTypeLable.Font = new System.Drawing.Font("Arial", 10F);
            this.PropertyTypeLable.Location = new System.Drawing.Point(4, 15);
            this.PropertyTypeLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PropertyTypeLable.Name = "PropertyTypeLable";
            this.PropertyTypeLable.Size = new System.Drawing.Size(211, 23);
            this.PropertyTypeLable.TabIndex = 2;
            this.PropertyTypeLable.Text = "Termék típus keresése";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.Location = new System.Drawing.Point(571, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Termék tulajdonság keresése";
            // 
            // TypePropertyListBox
            // 
            this.TypePropertyListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TypePropertyListBox.DataSource = this.PropertyBinding;
            this.TypePropertyListBox.Font = new System.Drawing.Font("Arial", 10F);
            this.TypePropertyListBox.FormattingEnabled = true;
            this.TypePropertyListBox.ItemHeight = 23;
            this.TypePropertyListBox.Location = new System.Drawing.Point(575, 89);
            this.TypePropertyListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TypePropertyListBox.Name = "TypePropertyListBox";
            this.TypePropertyListBox.Size = new System.Drawing.Size(296, 717);
            this.TypePropertyListBox.TabIndex = 4;
            // 
            // TypePropertySearchBox
            // 
            this.TypePropertySearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TypePropertySearchBox.Font = new System.Drawing.Font("Arial", 10F);
            this.TypePropertySearchBox.Location = new System.Drawing.Point(572, 39);
            this.TypePropertySearchBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TypePropertySearchBox.Name = "TypePropertySearchBox";
            this.TypePropertySearchBox.Size = new System.Drawing.Size(299, 30);
            this.TypePropertySearchBox.TabIndex = 3;
            this.TypePropertySearchBox.TextChanged += new System.EventHandler(this.TypePropertySearchBox_TextChanged);
            // 
            // NewTypeBox
            // 
            this.NewTypeBox.Font = new System.Drawing.Font("Arial", 10F);
            this.NewTypeBox.Location = new System.Drawing.Point(328, 39);
            this.NewTypeBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NewTypeBox.Name = "NewTypeBox";
            this.NewTypeBox.Size = new System.Drawing.Size(219, 30);
            this.NewTypeBox.TabIndex = 6;
            // 
            // CreateNewType
            // 
            this.CreateNewType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateNewType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.CreateNewType.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.CreateNewType.Location = new System.Drawing.Point(330, 470);
            this.CreateNewType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreateNewType.Name = "CreateNewType";
            this.CreateNewType.Size = new System.Drawing.Size(219, 62);
            this.CreateNewType.TabIndex = 7;
            this.CreateNewType.Text = "Típus létrehozása";
            this.CreateNewType.UseVisualStyleBackColor = false;
            this.CreateNewType.Click += new System.EventHandler(this.CreateNewType_Click);
            // 
            // DeleteType
            // 
            this.DeleteType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.DeleteType.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.DeleteType.Location = new System.Drawing.Point(330, 542);
            this.DeleteType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeleteType.Name = "DeleteType";
            this.DeleteType.Size = new System.Drawing.Size(219, 62);
            this.DeleteType.TabIndex = 8;
            this.DeleteType.Text = "Típus törlése";
            this.DeleteType.UseVisualStyleBackColor = false;
            this.DeleteType.Click += new System.EventHandler(this.DeleteType_Click);
            // 
            // LinkBetweenTypeAndProperty
            // 
            this.LinkBetweenTypeAndProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LinkBetweenTypeAndProperty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.LinkBetweenTypeAndProperty.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkBetweenTypeAndProperty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.LinkBetweenTypeAndProperty.Location = new System.Drawing.Point(329, 616);
            this.LinkBetweenTypeAndProperty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LinkBetweenTypeAndProperty.Name = "LinkBetweenTypeAndProperty";
            this.LinkBetweenTypeAndProperty.Size = new System.Drawing.Size(219, 86);
            this.LinkBetweenTypeAndProperty.TabIndex = 9;
            this.LinkBetweenTypeAndProperty.Text = "Típus és tulajdonság összekapcsolása";
            this.LinkBetweenTypeAndProperty.UseVisualStyleBackColor = false;
            this.LinkBetweenTypeAndProperty.Click += new System.EventHandler(this.LinkBetweenTypeAndProperty_Click);
            // 
            // DeleteLinkBetweenTypeAndProperty
            // 
            this.DeleteLinkBetweenTypeAndProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteLinkBetweenTypeAndProperty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.DeleteLinkBetweenTypeAndProperty.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteLinkBetweenTypeAndProperty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.DeleteLinkBetweenTypeAndProperty.Location = new System.Drawing.Point(328, 713);
            this.DeleteLinkBetweenTypeAndProperty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeleteLinkBetweenTypeAndProperty.Name = "DeleteLinkBetweenTypeAndProperty";
            this.DeleteLinkBetweenTypeAndProperty.Size = new System.Drawing.Size(219, 86);
            this.DeleteLinkBetweenTypeAndProperty.TabIndex = 10;
            this.DeleteLinkBetweenTypeAndProperty.Text = "Típus és tulajdonság kapcsolatának bontása";
            this.DeleteLinkBetweenTypeAndProperty.UseVisualStyleBackColor = false;
            this.DeleteLinkBetweenTypeAndProperty.Click += new System.EventHandler(this.DeleteLinkBetweenTypeAndProperty_Click_1);
            // 
            // PropertyNameBox
            // 
            this.PropertyNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyNameBox.Font = new System.Drawing.Font("Arial", 10F);
            this.PropertyNameBox.Location = new System.Drawing.Point(908, 201);
            this.PropertyNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PropertyNameBox.Name = "PropertyNameBox";
            this.PropertyNameBox.Size = new System.Drawing.Size(277, 30);
            this.PropertyNameBox.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // PropertyDefaultValueBox
            // 
            this.PropertyDefaultValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyDefaultValueBox.Font = new System.Drawing.Font("Arial", 10F);
            this.PropertyDefaultValueBox.Location = new System.Drawing.Point(908, 349);
            this.PropertyDefaultValueBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PropertyDefaultValueBox.Multiline = true;
            this.PropertyDefaultValueBox.Name = "PropertyDefaultValueBox";
            this.PropertyDefaultValueBox.Size = new System.Drawing.Size(277, 93);
            this.PropertyDefaultValueBox.TabIndex = 13;
            // 
            // PropertyDisplayNameBox
            // 
            this.PropertyDisplayNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyDisplayNameBox.Font = new System.Drawing.Font("Arial", 10F);
            this.PropertyDisplayNameBox.Location = new System.Drawing.Point(908, 279);
            this.PropertyDisplayNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PropertyDisplayNameBox.Name = "PropertyDisplayNameBox";
            this.PropertyDisplayNameBox.Size = new System.Drawing.Size(277, 30);
            this.PropertyDisplayNameBox.TabIndex = 14;
            // 
            // PropertyNameLib
            // 
            this.PropertyNameLib.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyNameLib.AutoSize = true;
            this.PropertyNameLib.Font = new System.Drawing.Font("Arial", 10F);
            this.PropertyNameLib.Location = new System.Drawing.Point(907, 178);
            this.PropertyNameLib.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PropertyNameLib.Name = "PropertyNameLib";
            this.PropertyNameLib.Size = new System.Drawing.Size(243, 23);
            this.PropertyNameLib.TabIndex = 15;
            this.PropertyNameLib.Text = "Tulajdonság technikai neve";
            // 
            // PropertyDispalyNameLib
            // 
            this.PropertyDispalyNameLib.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyDispalyNameLib.AutoSize = true;
            this.PropertyDispalyNameLib.Font = new System.Drawing.Font("Arial", 10F);
            this.PropertyDispalyNameLib.Location = new System.Drawing.Point(908, 255);
            this.PropertyDispalyNameLib.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PropertyDispalyNameLib.Name = "PropertyDispalyNameLib";
            this.PropertyDispalyNameLib.Size = new System.Drawing.Size(161, 23);
            this.PropertyDispalyNameLib.TabIndex = 16;
            this.PropertyDispalyNameLib.Text = "Tulajdonság neve";
            // 
            // PropertyDefaultValueLib
            // 
            this.PropertyDefaultValueLib.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyDefaultValueLib.AutoSize = true;
            this.PropertyDefaultValueLib.Font = new System.Drawing.Font("Arial", 10F);
            this.PropertyDefaultValueLib.Location = new System.Drawing.Point(908, 325);
            this.PropertyDefaultValueLib.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PropertyDefaultValueLib.Name = "PropertyDefaultValueLib";
            this.PropertyDefaultValueLib.Size = new System.Drawing.Size(100, 23);
            this.PropertyDefaultValueLib.TabIndex = 17;
            this.PropertyDefaultValueLib.Text = "Alap érték";
            // 
            // PropertyCreateButton
            // 
            this.PropertyCreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyCreateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.PropertyCreateButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertyCreateButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.PropertyCreateButton.Location = new System.Drawing.Point(908, 453);
            this.PropertyCreateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PropertyCreateButton.Name = "PropertyCreateButton";
            this.PropertyCreateButton.Size = new System.Drawing.Size(277, 70);
            this.PropertyCreateButton.TabIndex = 18;
            this.PropertyCreateButton.Text = "Tulajdonság Létrehozása";
            this.PropertyCreateButton.UseVisualStyleBackColor = false;
            this.PropertyCreateButton.Click += new System.EventHandler(this.PropertyCreateButton_Click);
            // 
            // NewTypeNameLib
            // 
            this.NewTypeNameLib.AutoSize = true;
            this.NewTypeNameLib.Font = new System.Drawing.Font("Arial", 10F);
            this.NewTypeNameLib.Location = new System.Drawing.Point(328, 17);
            this.NewTypeNameLib.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NewTypeNameLib.Name = "NewTypeNameLib";
            this.NewTypeNameLib.Size = new System.Drawing.Size(113, 23);
            this.NewTypeNameLib.TabIndex = 19;
            this.NewTypeNameLib.Text = "Új típus név";
            // 
            // DeletePropertyBotton
            // 
            this.DeletePropertyBotton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeletePropertyBotton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.DeletePropertyBotton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeletePropertyBotton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.DeletePropertyBotton.Location = new System.Drawing.Point(908, 532);
            this.DeletePropertyBotton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeletePropertyBotton.Name = "DeletePropertyBotton";
            this.DeletePropertyBotton.Size = new System.Drawing.Size(277, 70);
            this.DeletePropertyBotton.TabIndex = 20;
            this.DeletePropertyBotton.Text = "Tulajdonság törlése";
            this.DeletePropertyBotton.UseVisualStyleBackColor = false;
            this.DeletePropertyBotton.Click += new System.EventHandler(this.DeletePropertyBotton_Click);
            // 
            // PropertyListOfTheTypeListBox
            // 
            this.PropertyListOfTheTypeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PropertyListOfTheTypeListBox.Font = new System.Drawing.Font("Arial", 10F);
            this.PropertyListOfTheTypeListBox.FormattingEnabled = true;
            this.PropertyListOfTheTypeListBox.ItemHeight = 23;
            this.PropertyListOfTheTypeListBox.Location = new System.Drawing.Point(331, 111);
            this.PropertyListOfTheTypeListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PropertyListOfTheTypeListBox.Name = "PropertyListOfTheTypeListBox";
            this.PropertyListOfTheTypeListBox.Size = new System.Drawing.Size(219, 349);
            this.PropertyListOfTheTypeListBox.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.Location = new System.Drawing.Point(327, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 23);
            this.label2.TabIndex = 22;
            this.label2.Text = "Jelenleg összekötött";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ProductTypeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PropertyListOfTheTypeListBox);
            this.Controls.Add(this.DeletePropertyBotton);
            this.Controls.Add(this.NewTypeNameLib);
            this.Controls.Add(this.PropertyCreateButton);
            this.Controls.Add(this.PropertyDefaultValueLib);
            this.Controls.Add(this.PropertyDispalyNameLib);
            this.Controls.Add(this.PropertyNameLib);
            this.Controls.Add(this.PropertyDisplayNameBox);
            this.Controls.Add(this.PropertyDefaultValueBox);
            this.Controls.Add(this.PropertyNameBox);
            this.Controls.Add(this.DeleteLinkBetweenTypeAndProperty);
            this.Controls.Add(this.LinkBetweenTypeAndProperty);
            this.Controls.Add(this.DeleteType);
            this.Controls.Add(this.CreateNewType);
            this.Controls.Add(this.NewTypeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TypePropertyListBox);
            this.Controls.Add(this.TypePropertySearchBox);
            this.Controls.Add(this.PropertyTypeLable);
            this.Controls.Add(this.ProductTypeBox);
            this.Controls.Add(this.SearchBoxForTypes);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "ProductTypeUserControl";
            this.Size = new System.Drawing.Size(1228, 812);
            this.Load += new System.EventHandler(this.ProductTypeUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productTypeBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchBoxForTypes;
        private System.Windows.Forms.ListBox ProductTypeBox;
        private System.Windows.Forms.BindingSource productTypeBinding;
        private System.Windows.Forms.Label PropertyTypeLable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox TypePropertyListBox;
        private System.Windows.Forms.TextBox TypePropertySearchBox;
        private System.Windows.Forms.BindingSource PropertyBinding;
        private System.Windows.Forms.TextBox NewTypeBox;
        private System.Windows.Forms.Button CreateNewType;
        private System.Windows.Forms.Button DeleteType;
        private System.Windows.Forms.Button LinkBetweenTypeAndProperty;
        private System.Windows.Forms.Button DeleteLinkBetweenTypeAndProperty;
        private System.Windows.Forms.TextBox PropertyNameBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox PropertyDefaultValueBox;
        private System.Windows.Forms.TextBox PropertyDisplayNameBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label PropertyNameLib;
        private System.Windows.Forms.Label PropertyDispalyNameLib;
        private System.Windows.Forms.Label PropertyDefaultValueLib;
        private System.Windows.Forms.Button PropertyCreateButton;
        private System.Windows.Forms.Label NewTypeNameLib;
        private System.Windows.Forms.Button DeletePropertyBotton;
        private System.Windows.Forms.ListBox PropertyListOfTheTypeListBox;
        private System.Windows.Forms.Label label2;
    }
}
