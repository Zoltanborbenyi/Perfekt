using System.Linq;
using System.Collections.Generic;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using Moq;
using NUnit.Framework;
using ProductPropertyKliensApp.API;
using ProductPropertyKliensApp.Services;
using Pose;

namespace unittestkliens.Services
{
    [TestFixture]
    public class PropertyServicesTests
    {

        private Api _dummyProxy;

        [SetUp]
        public void SetUp()
        {
            _dummyProxy = new Api("https://example.com", "FAKEKEY");
        }

        [Test]
        [TestCase(new[] { "A", "B", "C" }, 3)]
        [TestCase(new string[0], 0)]
        [TestCase(new[] { "A" }, 1)]
        public void GetPropertiesFromProducts_RemovesDuplicatesAndHandlesEmpty(
            string[] bvins,
            int expectedCount)
        {
            // Arrange
            var mockApi = new Mock<IPropertyAPI>();
            mockApi.Setup(x => x.GetPropertiesForProduct(_dummyProxy, "A"))
                   .Returns(new List<ProductPropertyDTO> {
                       new ProductPropertyDTO { PropertyName = "Size" }
                   });
            mockApi.Setup(x => x.GetPropertiesForProduct(_dummyProxy, "B"))
                   .Returns(new List<ProductPropertyDTO> {
                       new ProductPropertyDTO { PropertyName = "Color" },
                       new ProductPropertyDTO { PropertyName = "Size" }
                   });
            mockApi.Setup(x => x.GetPropertiesForProduct(
                                _dummyProxy,
                                It.Is<string>(s => s != "A" && s != "B")))
                   .Returns(new List<ProductPropertyDTO>());

            var service = new PropertyServices(mockApi.Object);

            // Act
            var result = service.GetPropertiesFromProducts(
                _dummyProxy,
                bvins.ToList());

            // Assert count
            Assert.That(result.Count, NUnit.Framework.Is.EqualTo(expectedCount),
                        $"Expected {expectedCount} unique properties");

            // If you want to assert the exact contents when expectedCount==2:
            if (expectedCount == 2)
            {
                Assert.That(
                    result.Select(p => p.PropertyName),
                    NUnit.Framework.Is.EquivalentTo(new[] { "Size", "Color" }),
                    "Expected exactly Size and Color once each"
                );
            }
        }
        public void GetPropertiesFromProducts_HandlesEmptyInput()
        {
            var results = new List<ProductPropertyDTO>();
            var svc = new ProductPropertyKliensApp.Services.PropertyServices();

            PoseContext.Isolate(() =>
            {
                
                results=svc.GetPropertiesFromProducts(
                    _dummyProxy,
                    new List<string>()
                   
                );
            });

            Assert.That(results.Count, NUnit.Framework.Is.EqualTo(0), "Expected no properties for empty input");
        }
    }
}