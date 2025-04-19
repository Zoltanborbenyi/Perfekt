using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Catalog;
using ProductPropertyKliensApp.API;
using ProductPropertyKliensApp.DTO;

namespace ProductPropertyKliensApp.Services
{
    internal class ProductServices
    {
        public List<long> getPropertyIdsFromProducts(Api proxy, List<String> bvins) {
            List<long> propertyIds = new List<long>();
            getPropertyIdsFromProducts(proxy, bvins, propertyIds);
            return propertyIds;
        }

        private async void getPropertyIdsFromProducts(Api proxy, List<String> bvins, List<long> propertyIds) {
            PropertyAPI propertyAPI = new PropertyAPI();
            foreach (String bvin in bvins)
            {
                List<ProductPropertyDTO> properties = await Task.Run(() => propertyAPI.GetPropertiesForProduct(proxy, bvin));
                if(properties != null){
                    foreach (ProductPropertyDTO property in properties)
                    {
                        if (!propertyIds.Contains(property.Id))
                        {
                            propertyIds.Add(property.Id);
                        }
                    }
                }
            }
        }

        public List<ProductClientDTO> getProductsWithTypeNames(Api proxy)
        {
            List < ProductClientDTO > products = new List<ProductClientDTO>();
            ProductAPI productAPI = new ProductAPI();
            List<ProductDTO> productsCall = productAPI.getAllProduct(proxy);
            ProductTypesAPI typesApi = new ProductTypesAPI();
            List<ProductTypeDTO> typesCall = typesApi.getAllProductType(proxy);

            foreach (ProductDTO product in productsCall)
            {
                ProductClientDTO productClient = new ProductClientDTO();
                productClient.Azonosító = product.Bvin;
                productClient.Sku = product.Sku;
                productClient.TermékNév = product.ProductName;
                var type = typesCall.FirstOrDefault(t => t.Bvin == product.ProductTypeId);
                if (type != null)
                {
                    productClient.TípusAzonosító = type.Bvin.ToString();
                    productClient.TípusNév = type.ProductTypeName;
                }
                products.Add(productClient);
            }
        
        
            return products;
        }

    }
}
