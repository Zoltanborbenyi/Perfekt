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
    public class PropertyAPI : IPropertyAPI
    {
        #region Protected overridable wrappers
        protected virtual ApiResponse<List<ProductPropertyDTO>> FetchAll(Api proxy)
            => proxy.ProductPropertiesFindAll();

        protected virtual ApiResponse<ProductPropertyDTO> Create(Api proxy, ProductPropertyDTO dto)
            => proxy.ProductPropertiesCreate(dto);

        protected virtual ApiResponse<bool> Delete(Api proxy, long propertyId)
            => proxy.ProductPropertiesDelete(propertyId);

        protected virtual ApiResponse<List<ProductPropertyDTO>> FetchForProduct(Api proxy, string productId)
            => proxy.ProductPropertiesForProduct(productId);

        protected virtual ApiResponse<bool> SetValue(
            Api proxy,
            long propertyId,
            string productId,
            string defaultValue,
            int choiceId)
            => proxy.ProductPropertiesSetValueForProduct(propertyId, productId, defaultValue, choiceId);
        #endregion

        public List<ProductPropertyDTO> getAllProductProperty(Api proxy)
        {
            try
            {
                var response = FetchAll(proxy);
                if (response.Errors.Any())
                {
                    var msg = string.Join(Environment.NewLine, response.Errors.Select(e => e.Description));
                    MessageBox.Show(msg, "API hiba a termékek lekérésekor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return response.Content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba történt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool createProperty(Api proxy, ProductPropertyDTO newProperty)
        {
            try
            {
                newProperty.StoreId = 1;
                newProperty.DisplayOnSite = true;
                var response = Create(proxy, newProperty);
                if (response.Errors.Any())
                {
                    var msg = string.Join(Environment.NewLine, response.Errors.Select(e => e.Description));
                    MessageBox.Show(msg, "API hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba történt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool deleteProperty(Api proxy, long propertyId)
        {
            try
            {
                var response = Delete(proxy, propertyId);
                if (response.Errors.Any())
                {
                    var msg = string.Join(Environment.NewLine, response.Errors.Select(e => e.Description));
                    MessageBox.Show(msg, "API hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba történt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<ProductPropertyDTO> GetPropertiesForProduct(Api proxy, string productId)
        {
            try
            {
                var response = FetchForProduct(proxy, productId);
                if (response.Errors.Any())
                {
                    return null;
                }
                return response.Content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba történt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool createPropertyValueForProduct(Api proxy, long propertyId, string productId, string defaultValue)
        {
            try
            {
                const int choiceId = 0;
                var response = SetValue(proxy, propertyId, productId, defaultValue, choiceId);
                if (response.Errors.Any())
                {
                    var msg = string.Join(Environment.NewLine, response.Errors.Select(e => e.Description));
                    MessageBox.Show(msg, "API hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba történt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
    

