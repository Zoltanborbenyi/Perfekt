// unittestkliens/API/PropertyApiTests.cs
using System.Collections.Generic;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using ProductPropertyKliensApp.API;

namespace unittestkliens.API
{
    [TestFixture]
    public class PropertyApiTests
    {
        private Api _dummyProxy;
        private Mock<PropertyAPI> _mockApi;

        [SetUp]
        public void SetUp()
        {
            _dummyProxy = new Api("https://fake", "KEY");
            // Partial‐mock a Parameterless ctor; we'll supply proxy at call-site
            _mockApi = new Mock<PropertyAPI>() { CallBase = true };
        }

        [Test]
        public void getAllProductProperty_NoErrors_ReturnsContent()
        {
            var expected = new List<ProductPropertyDTO> { new ProductPropertyDTO() };
            var fakeResp = new ApiResponse<List<ProductPropertyDTO>> { Content = expected };

            _mockApi.Protected()
                    .Setup<ApiResponse<List<ProductPropertyDTO>>>(
                        "FetchAll",
                        ItExpr.IsAny<Api>()
                    )
                    .Returns(fakeResp);

            var result = _mockApi.Object.getAllProductProperty(_dummyProxy);
            Assert.That(result, Is.SameAs(expected));
        }

        [Test]
        public void getAllProductProperty_WithErrors_ReturnsNull()
        {
            var errorResp = new ApiResponse<List<ProductPropertyDTO>>();
            errorResp.Errors.Add(new ApiError("E", "err"));

            _mockApi.Protected()
                    .Setup<ApiResponse<List<ProductPropertyDTO>>>(
                        "FetchAll",
                        ItExpr.IsAny<Api>()
                    )
                    .Returns(errorResp);

            var result = _mockApi.Object.getAllProductProperty(_dummyProxy);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void createProperty_SetsDefaultsAndReturnsTrue_OnNoErrors()
        {
            var dto = new ProductPropertyDTO();
            var fakeResp = new ApiResponse<ProductPropertyDTO>();

            _mockApi.Protected()
                    .Setup<ApiResponse<ProductPropertyDTO>>(
                        "Create",
                        ItExpr.IsAny<Api>(),
                        ItExpr.Is<ProductPropertyDTO>(d => ReferenceEquals(d, dto))
                    )
                    .Returns(fakeResp);

            var ok = _mockApi.Object.createProperty(_dummyProxy, dto);
            Assert.That(ok, Is.True);
            Assert.That(dto.StoreId, Is.EqualTo(1));
            Assert.That(dto.DisplayOnSite, Is.True);
        }

        [Test]
        public void createProperty_ReturnsFalse_OnErrors()
        {
            var dto = new ProductPropertyDTO();
            var errorResp = new ApiResponse<ProductPropertyDTO>();
            errorResp.Errors.Add(new ApiError("E", "err"));

            _mockApi.Protected()
                    .Setup<ApiResponse<ProductPropertyDTO>>(
                        "Create",
                        ItExpr.IsAny<Api>(),
                        ItExpr.IsAny<ProductPropertyDTO>()
                    )
                    .Returns(errorResp);

            Assert.That(_mockApi.Object.createProperty(_dummyProxy, dto), Is.False);
        }

        [Test]
        public void deleteProperty_ReturnsTrue_OnNoErrors()
        {
            var fakeResp = new ApiResponse<bool>();

            _mockApi.Protected()
                    .Setup<ApiResponse<bool>>(
                        "Delete",
                        ItExpr.IsAny<Api>(),
                        ItExpr.Is<long>(id => id == 123L)
                    )
                    .Returns(fakeResp);

            Assert.That(_mockApi.Object.deleteProperty(_dummyProxy, 123), Is.True);
        }

        [Test]
        public void deleteProperty_ReturnsFalse_OnErrors()
        {
            var errorResp = new ApiResponse<bool>();
            errorResp.Errors.Add(new ApiError("E", "err"));

            _mockApi.Protected()
                    .Setup<ApiResponse<bool>>(
                        "Delete",
                        ItExpr.IsAny<Api>(),
                        ItExpr.IsAny<long>()
                    )
                    .Returns(errorResp);

            Assert.That(_mockApi.Object.deleteProperty(_dummyProxy, 456), Is.False);
        }

        [Test]
        public void GetPropertiesForProduct_NoErrors_ReturnsContent()
        {
            var expected = new List<ProductPropertyDTO>();
            var fakeResp = new ApiResponse<List<ProductPropertyDTO>> { Content = expected };

            _mockApi.Protected()
                    .Setup<ApiResponse<List<ProductPropertyDTO>>>(
                        "FetchForProduct",
                        ItExpr.IsAny<Api>(),
                        ItExpr.Is<string>(s => s == "X")
                    )
                    .Returns(fakeResp);

            var result = _mockApi.Object.GetPropertiesForProduct(_dummyProxy, "X");
            Assert.That(result, Is.SameAs(expected));
        }

        [Test]
        public void GetPropertiesForProduct_ReturnsNull_OnErrors()
        {
            var errorResp = new ApiResponse<List<ProductPropertyDTO>>();
            errorResp.Errors.Add(new ApiError("E", "err"));

            _mockApi.Protected()
                    .Setup<ApiResponse<List<ProductPropertyDTO>>>(
                        "FetchForProduct",
                        ItExpr.IsAny<Api>(),
                        ItExpr.IsAny<string>()
                    )
                    .Returns(errorResp);

            Assert.That(_mockApi.Object.GetPropertiesForProduct(_dummyProxy, "Y"), Is.Null);
        }

        [Test]
        public void createPropertyValueForProduct_ReturnsTrue_OnNoErrors()
        {
            var fakeResp = new ApiResponse<bool>();

            _mockApi.Protected()
                    .Setup<ApiResponse<bool>>(
                        "SetValue",
                        ItExpr.IsAny<Api>(),
                        ItExpr.Is<long>(l => l == 7L),
                        ItExpr.Is<string>(s => s == "p"),
                        ItExpr.Is<string>(s => s == "v"),
                        ItExpr.Is<int>(i => i == 0)
                    )
                    .Returns(fakeResp);

            Assert.That(
                _mockApi.Object.createPropertyValueForProduct(_dummyProxy, 7, "p", "v"),
                Is.True
            );
        }

        [Test]
        public void createPropertyValueForProduct_ReturnsFalse_OnErrors()
        {
            var errorResp = new ApiResponse<bool>();
            errorResp.Errors.Add(new ApiError("E", "err"));

            _mockApi.Protected()
                    .Setup<ApiResponse<bool>>(
                        "SetValue",
                        ItExpr.IsAny<Api>(),
                        ItExpr.IsAny<long>(),
                        ItExpr.IsAny<string>(),
                        ItExpr.IsAny<string>(),
                        ItExpr.IsAny<int>()
                    )
                    .Returns(errorResp);

            Assert.That(
                _mockApi.Object.createPropertyValueForProduct(_dummyProxy, 8, "q", "w"),
                Is.False
            );
        }
    }
}
