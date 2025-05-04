// ProductPropertyKliensApp.Services/PropertyServices.cs
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using ProductPropertyKliensApp.API;
using System.Collections.Generic;

namespace ProductPropertyKliensApp.Services
{
    public class PropertyServices
    {
        private readonly IPropertyAPI _propertyApi;

        /// <summary>
        /// In production this defaults to the real PropertyAPI,
        /// in tests you can pass a Mock<IPropertyAPI>.
        /// </summary>
        public PropertyServices(IPropertyAPI propertyApi = null)
        {
            _propertyApi = propertyApi ?? new PropertyAPI();
        }

        public List<ProductPropertyDTO> GetPropertiesFromProducts(
            Api proxy,
            List<string> bvins)
        {
            var properties = new List<ProductPropertyDTO>();

            foreach (var bvin in bvins)
            {
                var props = _propertyApi.GetPropertiesForProduct(proxy, bvin);
                if (props == null) continue;
                foreach (var p in props)
                {
                    if (!properties.Contains(p))
                        properties.Add(p);
                }
            }

            return properties;
        }
    }
}