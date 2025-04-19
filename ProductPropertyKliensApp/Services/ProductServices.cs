using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Catalog;
using ProductPropertyKliensApp.API;

namespace ProductPropertyKliensApp.Services
{
    internal class ProductServices
    {
        public List<long> getPropertyIdsFromProducts(Api proxy, List<String> bvins) {
            List<long> propertyIds = new List<long>();
            getPropertiesFromProducts(proxy, bvins, propertyIds);
            return propertyIds;
        }

        private async void getPropertiesFromProducts(Api proxy, List<String> bvins, List<long> propertyIds) {
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
    }
}
