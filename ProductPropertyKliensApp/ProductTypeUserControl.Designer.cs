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
            ((System.ComponentModel.ISupportInitialize)(this.productTypeBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchBoxForTypes
            // 
            this.SearchBoxForTypes.Location = new System.Drawing.Point(34, 46);
            this.SearchBoxForTypes.Name = "SearchBoxForTypes";
            this.SearchBoxForTypes.Size = new System.Drawing.Size(181, 20);
            this.SearchBoxForTypes.TabIndex = 0;
            this.SearchBoxForTypes.TextChanged += new System.EventHandler(this.SearchBoxForTypes_TextChanged_1);
            // 
            // ProductTypeBox
            // 
            this.ProductTypeBox.DataSource = this.productTypeBinding;
            this.ProductTypeBox.DisplayMember = "ProductTypeName";
            this.ProductTypeBox.FormattingEnabled = true;
            this.ProductTypeBox.Location = new System.Drawing.Point(35, 87);
            this.ProductTypeBox.Name = "ProductTypeBox";
            this.ProductTypeBox.Size = new System.Drawing.Size(179, 420);
            this.ProductTypeBox.TabIndex = 1;
            this.ProductTypeBox.SelectedIndexChanged += new System.EventHandler(this.ProductTypeBox_SelectedIndexChanged);
            // 
            // PropertyTypeLable
            // 
            this.PropertyTypeLable.AutoSize = true;
            this.PropertyTypeLable.Location = new System.Drawing.Point(35, 25);
            this.PropertyTypeLable.Name = "PropertyTypeLable";
            this.PropertyTypeLable.Size = new System.Drawing.Size(116, 13);
            this.PropertyTypeLable.TabIndex = 2;
            this.PropertyTypeLable.Text = "Termék típus keresése";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Termék tulajdonság keresése";
            // 
            // TypePropertyListBox
            // 
            this.TypePropertyListBox.DataSource = this.PropertyBinding;
            this.TypePropertyListBox.FormattingEnabled = true;
            this.TypePropertyListBox.Location = new System.Drawing.Point(373, 87);
            this.TypePropertyListBox.Name = "TypePropertyListBox";
            this.TypePropertyListBox.Size = new System.Drawing.Size(179, 420);
            this.TypePropertyListBox.TabIndex = 4;
            // 
            // TypePropertySearchBox
            // 
            this.TypePropertySearchBox.Location = new System.Drawing.Point(373, 46);
            this.TypePropertySearchBox.Name = "TypePropertySearchBox";
            this.TypePropertySearchBox.Size = new System.Drawing.Size(181, 20);
            this.TypePropertySearchBox.TabIndex = 3;
            this.TypePropertySearchBox.TextChanged += new System.EventHandler(this.TypePropertySearchBox_TextChanged);
            // 
            // NewTypeBox
            // 
            this.NewTypeBox.Location = new System.Drawing.Point(219, 103);
            this.NewTypeBox.Name = "NewTypeBox";
            this.NewTypeBox.Size = new System.Drawing.Size(147, 20);
            this.NewTypeBox.TabIndex = 6;
            // 
            // CreateNewType
            // 
            this.CreateNewType.Location = new System.Drawing.Point(220, 133);
            this.CreateNewType.Name = "CreateNewType";
            this.CreateNewType.Size = new System.Drawing.Size(146, 32);
            this.CreateNewType.TabIndex = 7;
            this.CreateNewType.Text = "Típus létrehozása";
            this.CreateNewType.UseVisualStyleBackColor = true;
            this.CreateNewType.Click += new System.EventHandler(this.CreateNewType_Click);
            // 
            // DeleteType
            // 
            this.DeleteType.Location = new System.Drawing.Point(220, 171);
            this.DeleteType.Name = "DeleteType";
            this.DeleteType.Size = new System.Drawing.Size(146, 32);
            this.DeleteType.TabIndex = 8;
            this.DeleteType.Text = "Típus törlése";
            this.DeleteType.UseVisualStyleBackColor = true;
            this.DeleteType.Click += new System.EventHandler(this.DeleteType_Click);
            // 
            // LinkBetweenTypeAndProperty
            // 
            this.LinkBetweenTypeAndProperty.Location = new System.Drawing.Point(220, 209);
            this.LinkBetweenTypeAndProperty.Name = "LinkBetweenTypeAndProperty";
            this.LinkBetweenTypeAndProperty.Size = new System.Drawing.Size(146, 45);
            this.LinkBetweenTypeAndProperty.TabIndex = 9;
            this.LinkBetweenTypeAndProperty.Text = "Típus és tulajdonság összekapcsolása";
            this.LinkBetweenTypeAndProperty.UseVisualStyleBackColor = true;
            this.LinkBetweenTypeAndProperty.Click += new System.EventHandler(this.LinkBetweenTypeAndProperty_Click);
            // 
            // DeleteLinkBetweenTypeAndProperty
            // 
            this.DeleteLinkBetweenTypeAndProperty.Location = new System.Drawing.Point(220, 260);
            this.DeleteLinkBetweenTypeAndProperty.Name = "DeleteLinkBetweenTypeAndProperty";
            this.DeleteLinkBetweenTypeAndProperty.Size = new System.Drawing.Size(146, 45);
            this.DeleteLinkBetweenTypeAndProperty.TabIndex = 10;
            this.DeleteLinkBetweenTypeAndProperty.Text = "Típus és tulajdonság kapcsolatának bontása";
            this.DeleteLinkBetweenTypeAndProperty.UseVisualStyleBackColor = true;
            this.DeleteLinkBetweenTypeAndProperty.Click += new System.EventHandler(this.DeleteLinkBetweenTypeAndProperty_Click_1);
            // 
            // PropertyNameBox
            // 
            this.PropertyNameBox.Location = new System.Drawing.Point(592, 144);
            this.PropertyNameBox.Name = "PropertyNameBox";
            this.PropertyNameBox.Size = new System.Drawing.Size(186, 20);
            this.PropertyNameBox.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // PropertyDefaultValueBox
            // 
            this.PropertyDefaultValueBox.Location = new System.Drawing.Point(592, 240);
            this.PropertyDefaultValueBox.Multiline = true;
            this.PropertyDefaultValueBox.Name = "PropertyDefaultValueBox";
            this.PropertyDefaultValueBox.Size = new System.Drawing.Size(186, 62);
            this.PropertyDefaultValueBox.TabIndex = 13;
            // 
            // PropertyDisplayNameBox
            // 
            this.PropertyDisplayNameBox.Location = new System.Drawing.Point(592, 194);
            this.PropertyDisplayNameBox.Name = "PropertyDisplayNameBox";
            this.PropertyDisplayNameBox.Size = new System.Drawing.Size(186, 20);
            this.PropertyDisplayNameBox.TabIndex = 14;
            // 
            // PropertyNameLib
            // 
            this.PropertyNameLib.AutoSize = true;
            this.PropertyNameLib.Location = new System.Drawing.Point(620, 128);
            this.PropertyNameLib.Name = "PropertyNameLib";
            this.PropertyNameLib.Size = new System.Drawing.Size(138, 13);
            this.PropertyNameLib.TabIndex = 15;
            this.PropertyNameLib.Text = "Tulajdonság technikai neve";
            // 
            // PropertyDispalyNameLib
            // 
            this.PropertyDispalyNameLib.AutoSize = true;
            this.PropertyDispalyNameLib.Location = new System.Drawing.Point(643, 178);
            this.PropertyDispalyNameLib.Name = "PropertyDispalyNameLib";
            this.PropertyDispalyNameLib.Size = new System.Drawing.Size(92, 13);
            this.PropertyDispalyNameLib.TabIndex = 16;
            this.PropertyDispalyNameLib.Text = "Tulajdonság neve";
            // 
            // PropertyDefaultValueLib
            // 
            this.PropertyDefaultValueLib.AutoSize = true;
            this.PropertyDefaultValueLib.Location = new System.Drawing.Point(661, 224);
            this.PropertyDefaultValueLib.Name = "PropertyDefaultValueLib";
            this.PropertyDefaultValueLib.Size = new System.Drawing.Size(55, 13);
            this.PropertyDefaultValueLib.TabIndex = 17;
            this.PropertyDefaultValueLib.Text = "Alap érték";
            // 
            // PropertyCreateButton
            // 
            this.PropertyCreateButton.Location = new System.Drawing.Point(614, 319);
            this.PropertyCreateButton.Name = "PropertyCreateButton";
            this.PropertyCreateButton.Size = new System.Drawing.Size(144, 35);
            this.PropertyCreateButton.TabIndex = 18;
            this.PropertyCreateButton.Text = "Tulajdonság Létrehozása";
            this.PropertyCreateButton.UseVisualStyleBackColor = true;
            this.PropertyCreateButton.Click += new System.EventHandler(this.PropertyCreateButton_Click);
            // 
            // NewTypeNameLib
            // 
            this.NewTypeNameLib.AutoSize = true;
            this.NewTypeNameLib.Location = new System.Drawing.Point(260, 87);
            this.NewTypeNameLib.Name = "NewTypeNameLib";
            this.NewTypeNameLib.Size = new System.Drawing.Size(65, 13);
            this.NewTypeNameLib.TabIndex = 19;
            this.NewTypeNameLib.Text = "Új típus név";
            // 
            // DeletePropertyBotton
            // 
            this.DeletePropertyBotton.Location = new System.Drawing.Point(614, 361);
            this.DeletePropertyBotton.Name = "DeletePropertyBotton";
            this.DeletePropertyBotton.Size = new System.Drawing.Size(144, 35);
            this.DeletePropertyBotton.TabIndex = 20;
            this.DeletePropertyBotton.Text = "Tulajdonság törlése";
            this.DeletePropertyBotton.UseVisualStyleBackColor = true;
            this.DeletePropertyBotton.Click += new System.EventHandler(this.DeletePropertyBotton_Click);
            // 
            // PropertyListOfTheTypeListBox
            // 
            this.PropertyListOfTheTypeListBox.FormattingEnabled = true;
            this.PropertyListOfTheTypeListBox.Location = new System.Drawing.Point(220, 321);
            this.PropertyListOfTheTypeListBox.Name = "PropertyListOfTheTypeListBox";
            this.PropertyListOfTheTypeListBox.Size = new System.Drawing.Size(146, 186);
            this.PropertyListOfTheTypeListBox.TabIndex = 21;
            // 
            // ProductTypeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "ProductTypeUserControl";
            this.Size = new System.Drawing.Size(819, 528);
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
    }
}
