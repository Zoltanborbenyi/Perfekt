using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Catalog;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace ProductPropertyKliensApp.API
{
    internal class PropertyAPI
    {
        public List<ProductPropertyDTO> getAllProductProperty(Api proxy)
        {
            try
            {
                ApiResponse<List<ProductPropertyDTO>> response = proxy.ProductPropertiesFindAll();
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

        public Boolean createProperty(Api proxy, ProductPropertyDTO newProperty)
        {
            try
            {
                newProperty.StoreId = 1;
                newProperty.DisplayOnSite = true;
                ApiResponse<ProductPropertyDTO> response = proxy.ProductPropertiesCreate(newProperty);
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

        public Boolean deleteProperty(Api proxy, long propertyId)
        {
            try
            {
                ApiResponse<bool> response = proxy.ProductPropertiesDelete(propertyId);
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

        public List<ProductPropertyDTO> GetPropertiesForProduct(Api proxy, string productId)
        {
            try
            {
                ApiResponse<List<ProductPropertyDTO>> response = proxy.ProductPropertiesForProduct(productId);
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

        public List<ProductPropertyDTO> GetPropertiesForType(string typeId)
        {
            return null;
        }

        public Boolean createPropertyValueForProduct(Api proxy, long propertyId, String productId, String defaultValue)
        {
            try
            {
                int choiceId = 0;
                ApiResponse<bool> response = proxy.ProductPropertiesSetValueForProduct(propertyId, productId, defaultValue, choiceId);
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

    }
}
    

