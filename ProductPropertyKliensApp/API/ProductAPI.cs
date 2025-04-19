using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Catalog;
using System.Windows.Forms;
using Hotcakes.Commerce.Catalog;

namespace ProductPropertyKliensApp
{
    internal class ProductAPI
    {

        public List<ProductDTO> getAllProduct(Api proxy) {
            try {
                ApiResponse<List<ProductDTO>> response = proxy.ProductsFindAll();
                if (response.Errors.Any())
                {
                    var msg = string.Join(Environment.NewLine, response.Errors.Select(e => e.Description));
                    MessageBox.Show(
                        msg,
                        "API hiba a termékek lekérésekor",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return null;
                }
                return response.Content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Hiba történt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }

        public ProductDTO getProductBySku(Api proxy, String Sku)
        {
            try
            {
                ApiResponse<ProductDTO> response = proxy.ProductsFindBySku(Sku); ;
                if (response.Errors.Any())
                {
                    return null;
                }
                return response.Content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Hiba történt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }

        public ProductDTO getProductByBvin(Api proxy, String bvin)
        {
            try
            {
                ApiResponse<ProductDTO> response = proxy.ProductsFind(bvin);
                if (response.Errors.Any())
                {
                    return null;
                }
                return response.Content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Hiba történt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }

        public Boolean createProduct(Api proxy, ProductDTO newProduct)
        {
            try
            {
                ApiResponse<ProductDTO> response = proxy.ProductsCreate(newProduct, null);
                if (response.Errors.Any())
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Hiba történt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }

        public Boolean deleteProduct(Api proxy, String productId)
        {
            try
            {
                ApiResponse<bool> response = proxy.ProductsDelete(productId);
                if (response.Errors.Any())
                {
                    var msg = string.Join(Environment.NewLine, response.Errors.Select(e => e.Description));
                    MessageBox.Show(
                        msg,
                        "API hiba",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Hiba történt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }

        public ProductDTO updateProduct(Api proxy, ProductDTO product)
        {
            try
            {
                ApiResponse<ProductDTO> response = proxy.ProductsUpdate(product);
                if (response.Errors.Any())
                {
                    var msg = string.Join(Environment.NewLine, response.Errors.Select(e => e.Description));
                    MessageBox.Show(
                        msg,
                        "API hiba",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return null;
                }
                return response.Content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Hiba történt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }

    }
}
