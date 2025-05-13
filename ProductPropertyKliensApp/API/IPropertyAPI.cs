// ProductPropertyKliensApp.API/IPropertyAPI.cs
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using System.Collections.Generic;

namespace ProductPropertyKliensApp.API
{
    /// <summary>
    /// Abstraction over the concrete PropertyAPI so we can mock it in tests.
    /// </summary>
    public interface IPropertyAPI
    {
        List<ProductPropertyDTO> getAllProductProperty(Api proxy);
        bool createProperty(Api proxy, ProductPropertyDTO newProperty);
        bool deleteProperty(Api proxy, long propertyId);
        List<ProductPropertyDTO> GetPropertiesForProduct(Api proxy, string productId);
        bool createPropertyValueForProduct(Api proxy, long propertyId, string productId, string defaultValue);
    }
}