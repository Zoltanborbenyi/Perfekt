using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using ProductPropertyKliensApp.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPropertyKliensApp.Services
{
    internal class PropertyServices
    {
        public List<ProductPropertyDTO> getPropertiesFromProducts(Api proxy, List<String> bvins, List<ProductPropertyDTO> properties)
        {
            getPropertiesFromProductsCall(proxy, bvins, properties);
            return properties;
        }

        private async void getPropertiesFromProductsCall(Api proxy, List<String> bvins, List<ProductPropertyDTO> properties)
        {
            PropertyAPI propertyAPI = new PropertyAPI();
            foreach (String bvin in bvins)
            {
                List<ProductPropertyDTO> propertiesFromApi = await Task.Run(() => propertyAPI.GetPropertiesForProduct(proxy, bvin));
                if (propertiesFromApi != null)
                {
                    foreach (ProductPropertyDTO property in propertiesFromApi)
                    {
                        if (!properties.Contains(property))
                        {
                            properties.Add(property);
                        }
                    }
                }
            }
        }
    }
}
