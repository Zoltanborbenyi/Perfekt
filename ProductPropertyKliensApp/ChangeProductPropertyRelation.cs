using Hotcakes.CommerceDTO.v1.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotcakes.CommerceDTO.v1.Client;
using ProductPropertyKliensApp.API;
using ProductPropertyKliensApp.Services;
using Hotcakes.Commerce.Catalog;

namespace ProductPropertyKliensApp
{
    public partial class ChangeProductPropertyRelation : Form
    {
        List<ProductDTO> selectedProduct;
        private List<String> displayedColumns;
        private readonly Dictionary<string, string> propertyTranslations;
        private Api proxy;
        private List<long> propertyIds;
        private bool isTypeHomogen;

        public ChangeProductPropertyRelation(Api proxy, List<ProductDTO> productesProductLocal, List<String> displayedColumnsLocal, Dictionary<string, string> propertyTranslationsLocal)
        {
            this.proxy = proxy;
            this.selectedProduct = productesProductLocal;
            this.displayedColumns = displayedColumnsLocal;
            this.propertyTranslations = propertyTranslationsLocal;
            this.isTypeHomogen = selectedProduct
                .Select(p => p.ProductTypeId)
                .Distinct()
                .Count() == 1;
            InitializeComponent();
        }

        private async void ChangeProductPropertyRelation_Load(object sender, EventArgs e)
        {
            if (!isTypeHomogen) {
                textBox2.Text = "A kiválasztott termékek nem azonos típusúak, így a tulajdonságok nem azonosak. Kérjük válasszon ki azonos típussal rendelkező termékeket a listából!";
                textBox2.Enabled = false;
                button1.Enabled = false;
            }
            loadProducts();
            await loadSetProperties();
            await loadProperties();
        }

        private async Task loadPropertyIds()
        {
            try
            {
                ProductServices productServices = new ProductServices();
                propertyIds = await Task.Run(() => productServices.getPropertyIdsFromProducts(proxy, selectedProduct.Select(p => p.Bvin).ToList()));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a tulajdonság id-k betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task loadProperties() {
            try
            {
                await loadPropertyIds();
                PropertyAPI propertiesApi = new PropertyAPI();
                List<ProductPropertyDTO> properties = await Task.Run(() => propertiesApi.getAllProductProperty(proxy));
                bindingSource1.DataSource = properties.Where(p =>
            (p.PropertyName?.ToLower().Contains(TypePropertySearchBox.Text.ToLower()) ?? false) && !propertyIds.Contains(p.Id)
        ).ToList();
                listBox1.DisplayMember = nameof(ProductPropertyDTO.PropertyName);
                listBox1.ValueMember = nameof(ProductPropertyDTO.Id);
                listBox1.DataSource = bindingSource1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a tulajdonságok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task loadSetProperties()
        {
            try {
                await loadPropertyIds();
                PropertyAPI propertiesApi = new PropertyAPI();
                List<ProductPropertyDTO> properties = await Task.Run(() => propertiesApi.getAllProductProperty(proxy));
                
                this.Enabled = false;

                await Task.Delay(TimeSpan.FromSeconds(1));

                this.Enabled = true;
                var propertySet = properties.Where(p => propertyIds.Contains(p.Id)).ToList();
                listBox2.DataSource =propertySet;
                listBox2.DisplayMember = nameof(ProductPropertyDTO.PropertyName);
                listBox2.ValueMember = nameof(ProductPropertyDTO.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a tulajdonságok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void loadProducts()
        {
            try
            {
                dataGridView1.DataSource = selectedProduct;
                ApplyColumnSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a termékek betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyColumnSettings()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (propertyTranslations.TryGetValue(col.DataPropertyName, out var magyarFelirat))
                    col.HeaderText = magyarFelirat;

                col.Visible = displayedColumns.Contains(col.DataPropertyName);
            }
        }

        private async void TypePropertySearchBox_TextChanged(object sender, EventArgs e)
        {
            await loadProperties();
        }

        private async void UpdateProductPropertyBox_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is ProductPropertyDTO selectedProperty && !textBox1.Text.Equals("")) {
                try
                {
                    PropertyAPI propertiesApi = new PropertyAPI();
                    ProductTypesAPI productTypesApi = new ProductTypesAPI();
                    List<ProductDTO> productTypes = new List<ProductDTO>();
                    foreach (ProductDTO product in selectedProduct) {
                        if (!productTypes.Contains(product)){
                            bool properties = await Task.Run(() => productTypesApi.linkProductTypeToProperty(proxy, product.ProductTypeId, selectedProperty.Id));
                        }
                    }
                    foreach (ProductDTO product in selectedProduct) {
                        bool properties = await Task.Run(() => propertiesApi.createPropertyValueForProduct(proxy, selectedProperty.Id, product.Bvin, textBox1.Text));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba történt az Érték felvétele közben: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                loadProducts();
                await loadSetProperties();
                await loadProperties();
            }
            else{
                MessageBox.Show($"Nincs kiválasztva tulajdonság", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            ProductPropertyDTO selectedProperty = listBox2.SelectedItem as ProductPropertyDTO;
            if (selectedProperty == null)
            {
                MessageBox.Show("Nincs kiválasztva tulajdonság",
                                "Hiba",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            var dlg = MessageBox.Show(
                "Biztos törölni szeretné az összes kapcsolatot a típusok és a kiválasztott tulajdonság között?",
                "Megerősítés",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );
            if (dlg != DialogResult.OK)
                return;

            int totalCount = 0;
            int successCount = 0;

            try
            {
                var productTypesApi = new ProductTypesAPI();

                var uniqueTypeIds = selectedProduct
                    .Select(p => p.ProductTypeId)
                    .Distinct();

                foreach (var typeId in uniqueTypeIds)
                {
                    totalCount++;

                    bool deleted = await Task.Run(() =>
                        productTypesApi.deleteLinkProductTypeToProperty(proxy, typeId, selectedProperty.Id)
                    );

                    if (deleted)
                        successCount++;
                }

                MessageBox.Show(
                    $"Siker aránya: {successCount}/{totalCount}",
                    "Válasz",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Hiba történt a link(ek) törlése közben: {ex.Message}",
                    "Hiba",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error

                );

            }
            await loadSetProperties();

            
            await loadProperties();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ProductPropertyDTO selectedProperty = listBox2.SelectedItem as ProductPropertyDTO;
            if (selectedProperty == null && textBox2.Text.Equals(""))
            {
                MessageBox.Show("Nincs kiválasztva tulajdonság vagy nincs megadva érték",
                                "Hiba",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            var dlg = MessageBox.Show(
                "Biztos végbe akarja vinni a módosításokat?",
                "Megerősítés",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );
            if (dlg != DialogResult.OK)
                return;

            int totalCount = 0;
            int successCount = 0;

            try
            {
                PropertyAPI propertiesApi = new PropertyAPI();

                var uniqueTypeIds = selectedProduct
                    .Select(p => p.ProductTypeId)
                    .Distinct();

                foreach (ProductDTO product in selectedProduct)
                {
                    totalCount++;
                    bool properties = await Task.Run(() => propertiesApi.createPropertyValueForProduct(proxy, selectedProperty.Id, product.Bvin, textBox2.Text));
                    if (properties)
                        successCount++;
                }



                MessageBox.Show(
                    $"Siker aránya: {successCount}/{totalCount}",
                    "Válasz",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Hiba történt a link(ek) törlése közben: {ex.Message}",
                    "Hiba",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            await loadSetProperties();


            await loadProperties();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}