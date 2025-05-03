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

namespace ProductPropertyKliensApp
{
    public partial class ProductUserConrol : UserControl
    {
        private List<String> displayedColumns;
        private readonly Dictionary<string, string> propertyTranslations = new Dictionary<string, string>
{
    { "Bvin", "Azonosító" },
    { "Sku", "SKU" },
    { "ProductName", "Termék neve" },
    { "ProductTypeId", "Terméktípus" },
    { "CustomProperties", "Egyéni tulajdonságok" },
    { "ListPrice", "Listaár" },
    { "SitePrice", "Weboldali ár" },
    { "SitePriceOverrideText", "Weboldali ár felülírási szöveg" },
    { "SiteCost", "Weboldali költség" },
    { "MetaKeywords", "Meta kulcsszavak" },
    { "MetaDescription", "Meta leírás" },
    { "MetaTitle", "Meta cím" },
    { "TaxExempt", "Adómentes" },
    { "TaxSchedule", "Adótábla azonosító" },
    { "ShippingDetails", "Szállítási részletek" },
    { "ShippingMode", "Szállítási mód" },
    { "Status", "Állapot" },
    { "ImageFileSmall", "Kis képfájl" },
    { "ImageFileSmallAlternateText", "Kis kép alternatív szöveg" },
    { "ImageFileMedium", "Közepes képfájl" },
    { "ImageFileMediumAlternateText", "Közepes kép alternatív szöveg" },
    { "CreationDateUtc", "Létrehozás dátuma (UTC)" },
    { "MinimumQty", "Minimális mennyiség" },
    { "ShortDescription", "Rövid leírás" },
    { "LongDescription", "Hosszú leírás" },
    { "ManufacturerId", "Gyártó azonosító" },
    { "VendorId", "Szállító azonosító" },
    { "GiftWrapAllowed", "Ajándékcsomagolás engedélyezése" },
    { "GiftWrapPrice", "Ajándékcsomagolás ára" },
    { "Keywords", "Kulcsszavak" },
    { "PreContentColumnId", "Előtartalom oszlop azonosító" },
    { "PostContentColumnId", "Utótartalom oszlop azonosító" },
    { "UrlSlug", "URL slug" },
    { "InventoryMode", "Készlet mód" },
    { "IsAvailableForSale", "Eladásra elérhető" },
    { "Featured", "Kiemelt" },
    { "AllowReviews", "Vélemények engedélyezése" },
    { "Tabs", "Leírásfülek" },
    { "StoreId", "Áruház azonosító" },
    { "IsSearchable", "Kereshető" },
    { "ShippingCharge", "Szállítási díj" },
    { "AllowUpcharge", "Felár engedélyezése" },
    { "UpchargeAmount", "Felár összege" },
    { "UpchargeUnit", "Felár egysége" }
};

        private List<string> mandatoryDisplays;
        private Api proxy;

        public ProductUserConrol(Api proxyLocal)
        {
            proxy = proxyLocal;
            InitializeComponent();
        }

        private void ProductUserConrol_Load(object sender, EventArgs e)
        {
            mandatoryDisplays = new List<string>
    {
        "ProductName",
        "Sku",
        "Bvin",
        "SitePrice"
    };
            displayedColumns = new List<string> { };

            displayedColumns = displayedColumns
                         .Union(mandatoryDisplays)
                         .ToList();
            loadProducts();
        }

        private async void loadProducts()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                var productAPI = new ProductAPI();
                List<ProductDTO> product = await Task.Run(() => productAPI.getAllProduct(proxy));
                dataGridView1.DataSource = product.Where(p =>
            (p.ProductName?.ToLower().Contains(SearchBox.Text.ToLower()) ?? false) ||
            (p.Sku?.ToLower().Contains(SearchBox.Text.ToLower()) ?? false) ||
            (p.Bvin?.ToLower().Contains(SearchBox.Text.ToLower()) ?? false)
        ).ToList();
                ApplyColumnSettings();
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

        private void ApplyColumnSettings()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (propertyTranslations.TryGetValue(col.DataPropertyName, out var magyarFelirat))
                    col.HeaderText = magyarFelirat;

                col.Visible = displayedColumns.Contains(col.DataPropertyName);
            }
        }

        private void ColumnDisplay_Click(object sender, EventArgs e)
        {
            using (var dlg = new ColumnSelectorForm(propertyTranslations, displayedColumns, mandatoryDisplays))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    displayedColumns = dlg.SelectedKeys;
                    ApplyColumnSettings();
                }
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            loadProducts();
        }

        private void ProductTypePropertyChange_Click(object sender, EventArgs e)
        {
            var selectedProducts = dataGridView1.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => r.DataBoundItem as ProductDTO)
                .Where(p => p != null)
                .ToList();

            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("Nincs kiválasztott termék.", "Figyelem",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dlg = new ChangeProductPropertyRelation(
                                proxy,
                                selectedProducts,
                                displayedColumns,
                                propertyTranslations))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    loadProducts();
                }
            }
        }

    }
}
