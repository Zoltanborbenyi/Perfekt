using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
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

namespace ProductPropertyKliensApp
{
    public partial class ProductTypeUserControl : UserControl
    {
        private Api proxy;

        public ProductTypeUserControl(Api proxyLocal)
        {
            InitializeComponent();
            proxy = proxyLocal;
        }

        private async void ProductTypeUserControl_Load(object sender, EventArgs e)
        {
            loadProductTypes();
            loadProductTypeProperties();
            await loadPropertyListOfTypeAsync();
        }

        private async void loadProductTypes()
        {
            try
            {
                var typesApi = new ProductTypesAPI();
                List<ProductTypeDTO> types = await Task.Run(() => typesApi.getAllProductType(proxy));
                productTypeBinding.DataSource = types.Where(p =>
            (p.ProductTypeName?.ToLower().Contains(SearchBoxForTypes.Text.ToLower()) ?? false)
        ).ToList();
                ProductTypeBox.DisplayMember = nameof(ProductTypeDTO.ProductTypeName);
                ProductTypeBox.ValueMember = nameof(ProductTypeDTO.Bvin);
                ProductTypeBox.DataSource = productTypeBinding;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a típusok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void loadProductTypeProperties()
        {
            try
            {
                var propertiesApi = new PropertyAPI();
                List<ProductPropertyDTO> properties = await Task.Run(() => propertiesApi.getAllProductProperty(proxy));
                PropertyBinding.DataSource = properties.Where(p =>
            (p.PropertyName?.ToLower().Contains(TypePropertySearchBox.Text.ToLower()) ?? false)
        ).ToList();
                TypePropertyListBox.DisplayMember = nameof(ProductPropertyDTO.PropertyName);
                TypePropertyListBox.ValueMember = nameof(ProductPropertyDTO.Id);
                TypePropertyListBox.DataSource = PropertyBinding;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a tulajdonságok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchBoxForTypes_TextChanged_1(object sender, EventArgs e)
        {
            loadProductTypes();
        }

        private void TypePropertySearchBox_TextChanged(object sender, EventArgs e)
        {
            loadProductTypeProperties();
        }

        private void CreateNewType_Click(object sender, EventArgs e)
        {
            try {
                if (!NewTypeBox.Text.Equals(""))
                {
                    ProductTypesAPI typeApi = new ProductTypesAPI();
                    ProductTypeDTO newType = new ProductTypeDTO();
                    newType.ProductTypeName = NewTypeBox.Text;
                    typeApi.createProductType(proxy, newType);
                    loadProductTypes();
                }
                else {
                    MessageBox.Show($"Nem lehet üres a típus neve", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a típus létrehozásakor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteType_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductTypeBox.SelectedItem is ProductTypeDTO selectedType)
                {
                    ProductTypesAPI typeApi = new ProductTypesAPI();
                    typeApi.deleteProductType(proxy, selectedType.Bvin);
                    loadProductTypes();
                }
                else
                {
                    MessageBox.Show($"Nincs kiválasztott típus", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a típus törlésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkBetweenTypeAndProperty_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductTypeBox.SelectedItem is ProductTypeDTO selectedType && TypePropertyListBox.SelectedItem is ProductPropertyDTO selectedProperty)
                {
                    ProductTypesAPI typeApi = new ProductTypesAPI();
                    typeApi.linkProductTypeToProperty(proxy, selectedType.Bvin, selectedProperty.Id);
                    loadProductTypes();
                }
                else
                {
                    MessageBox.Show($"Nincs kiválasztott típus", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a kapcsolat teremtésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DeleteLinkBetweenTypeAndProperty_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (ProductTypeBox.SelectedItem is ProductTypeDTO selectedType && TypePropertyListBox.SelectedItem is ProductPropertyDTO selectedProperty)
                {
                    ProductTypesAPI typeApi = new ProductTypesAPI();
                    typeApi.deleteLinkProductTypeToProperty(proxy, selectedType.Bvin, selectedProperty.Id);
                    loadProductTypes();
                }
                else
                {
                    MessageBox.Show($"Nincs kiválasztott típus", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a kapcsolat törlésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PropertyCreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PropertyNameBox.Text.Equals("") && !PropertyDisplayNameBox.Text.Equals(""))
                {
                    PropertyAPI propertyApi = new PropertyAPI();
                    ProductPropertyDTO newProperty = new ProductPropertyDTO();
                    newProperty.PropertyName = PropertyNameBox.Text;
                    newProperty.DisplayName = PropertyDisplayNameBox.Text;
                    newProperty.DefaultValue = PropertyDefaultValueBox.Text;
                    newProperty.StoreId = 1;
                    newProperty.DisplayOnSite = true;
                    newProperty.CultureCode = "hu-HU";
                    propertyApi.createProperty(proxy, newProperty);
                    loadProductTypeProperties();
                }
                else
                {
                    MessageBox.Show($"Nem lettek megefelelően megadva a nevek", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a tulajdonság létrehozásakor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeletePropertyBotton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TypePropertyListBox.SelectedItem is ProductPropertyDTO selectedProperty)
                {
                    PropertyAPI propertyApi = new PropertyAPI();
                    propertyApi.deleteProperty(proxy, selectedProperty.Id);
                    loadProductTypeProperties();
                }
                else
                {
                    MessageBox.Show($"Nincs kiválasztva tulajdonság", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a tulajdonság törlésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task loadPropertyListOfTypeAsync() {
            try
            {
                if (ProductTypeBox.SelectedItem is ProductTypeDTO selectedType) {
                    var propertiesApi = new PropertyAPI();
                    List<ProductPropertyDTO> properties = await Task.Run(() => propertiesApi.GetPropertiesForType(selectedType.Bvin));
                    PropertyListOfTheTypeListBox.DataSource = properties;
                    PropertyListOfTheTypeListBox.DisplayMember = nameof(ProductPropertyDTO.PropertyName);
                    PropertyListOfTheTypeListBox.ValueMember = nameof(ProductPropertyDTO.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a tulajdonságok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ProductTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            await loadPropertyListOfTypeAsync();
        }
    }
}
