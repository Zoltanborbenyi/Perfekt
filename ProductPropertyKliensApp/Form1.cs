using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using ProductPropertyKliensApp;

namespace ProductPropertyKliensApp
{
    public partial class Form1 : Form
    {
        public Api proxy;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string apiUrl = ConfigurationManager.AppSettings["apiUrl"];
            string apiKey = ConfigurationManager.AppSettings["apiKey"];
            this.proxy = new Api(apiUrl, apiKey);
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            loadProductPage();
        }

        private void loadProductPage() {
            panelMain.Controls.Clear();
            var gridControl = new ProductUserConrol(proxy)
            {
                Dock = DockStyle.Fill
            };

            panelMain.Controls.Add(gridControl);
        }

        private void Property_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var gridControl = new ProductTypeUserControl(proxy)
            {
                Dock = DockStyle.Fill
            };
            

            panelMain.Controls.Add(gridControl);
        }

        private void ProductTypeButton_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var gridControl = new ProductTypeLinkUserControl(proxy)
            {
                Dock = DockStyle.Fill
            };


            panelMain.Controls.Add(gridControl);
        }
    }
}
