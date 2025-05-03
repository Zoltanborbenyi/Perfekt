using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using ProductPropertyKliensApp.API;
using ProductPropertyKliensApp.DTO;
using ProductPropertyKliensApp.Services;

namespace ProductPropertyKliensApp
{
    public partial class ProductTypeLinkUserControl : UserControl
    {
        private Api proxy;

        public ProductTypeLinkUserControl(Api proxyLocal)
        {
            this.proxy = proxyLocal;
            InitializeComponent();
        }

        private async void ProductTypeLinkUserControl_Load(object sender, EventArgs e)
        {
            loadProductTypes();
            await loadProducts();
        }

        private async void loadProductTypes()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                var typesApi = new ProductTypesAPI();
                List<ProductTypeDTO> types = await Task.Run(() => typesApi.getAllProductType(proxy));
                listBox1.DataSource = types.Where(p =>
            (p.ProductTypeName?.ToLower().Contains(textBox2.Text.ToLower()) ?? false)
        ).ToList();
                listBox1.DisplayMember = nameof(ProductTypeDTO.ProductTypeName);
                listBox1.ValueMember = nameof(ProductTypeDTO.Bvin);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a típusok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async Task loadProducts()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ProductServices productServices = new ProductServices();
                List<ProductClientDTO> products = await Task.Run(() => productServices.getProductsWithTypeNames(proxy));
                dataGridView1.DataSource = products.Where(p =>
            (p.TermékNév?.ToLower().Contains(textBox1.Text.ToLower()) ?? false) ||
            (p.Sku?.ToLower().Contains(textBox1.Text.ToLower()) ?? false) ||
            (p.Azonosító?.ToLower().Contains(textBox1.Text.ToLower()) ?? false)
        ).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a termékek betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            await loadProducts();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            loadProductTypes();
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && listBox1.SelectedItem is ProductTypeDTO selectedType)
            {
                List<ProductClientDTO> selectedProducts = new List<ProductClientDTO>();

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.DataBoundItem is ProductClientDTO product)
                    {
                        selectedProducts.Add(product);
                    }
                }

                foreach (ProductClientDTO selectedProduct in selectedProducts)
                {
                    ProductAPI productApi = new ProductAPI();
                    ProductDTO updateProduct = productApi.getProductByBvin(proxy, selectedProduct.Azonosító);
                    if (updateProduct != null)
                    {
                        if (!(updateProduct.ProductTypeId == selectedType.Bvin))
                        {
                            updateProduct.ProductTypeId = selectedType.Bvin;
                            var response = productApi.updateProduct(proxy, updateProduct);
                            if (response == null)
                            {
                                MessageBox.Show($"Hiba történt a(z) {selectedProduct.TermékNév} termék mentésekor.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"A(z) {selectedProduct.TermékNév} termék nem található.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    }
                await loadProducts();
            }
            }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            var dlg = MessageBox.Show(
                "Biztos törölni szeretné az összes kapcsolatot a típusok és a kiválasztott tulajdonság között?",
                "Megerősítés",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );
            if (dlg != DialogResult.OK)
                return;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                List<ProductClientDTO> selectedProducts = new List<ProductClientDTO>();

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.DataBoundItem is ProductClientDTO product)
                    {
                        selectedProducts.Add(product);
                    }
                }

                foreach (ProductClientDTO selectedProduct in selectedProducts)
                {
                    ProductAPI productApi = new ProductAPI();
                    ProductDTO updateProduct = productApi.getProductByBvin(proxy, selectedProduct.Azonosító);
                    if (updateProduct != null)
                    {
                        updateProduct.ProductTypeId = "";
                        var response = productApi.updateProduct(proxy, updateProduct);
                        if (response == null)
                        {
                            MessageBox.Show($"Hiba történt a(z) {selectedProduct.TermékNév} termék mentésekor.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"A(z) {selectedProduct.TermékNév} termék nem található.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                await loadProducts();
            }
        }
    }
    }
