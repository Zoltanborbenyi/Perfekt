using ProductPropertyKliensApp.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.Commerce.Accounts;
using System.Configuration;

namespace ProductPropertyKliensApp
{
    public partial class Login : Form
    {
        public Api proxy;


        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginButton.Text) || string.IsNullOrWhiteSpace(LoginButton.Text))
            {
                MessageBox.Show("Kérjük, töltse ki az összes mezőt.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string apiUrl = ConfigurationManager.AppSettings["apiurl"];
            string apiKey = LoginText.Text;
            proxy = new Api(apiUrl, apiKey);
            CategoryAPI catgoryAPI = new CategoryAPI();
            var response = catgoryAPI.getCategories(proxy);
            if (response.Errors.Any())
            {
                MessageBox.Show("Nem volt sikeres a belépés",
                                                        "Hiba",
                                                                             MessageBoxButtons.OK,
                                                                                                MessageBoxIcon.Error
                                                                                                               );
            }
            else{
                MessageBox.Show("Sikeres belépés",
                                                       "Siker",
                                                                            MessageBoxButtons.OK);

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
