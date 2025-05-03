using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Catalog;
using System.Web.Services.Description;
using DotNetNuke.Services.Social.Messaging.Internal.Views;
using DotNetNuke.Services.Exceptions;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.API
{
	internal class ProductAPI
	{
		public ProductDTO GetProductByProductId(Api proxy, string ProductId)
		{
			try
			{
				if (proxy == null)
				{
					Exceptions.LogException(new ArgumentNullException(nameof(proxy)));
					return null;
				}

				if (string.IsNullOrWhiteSpace(ProductId))
				{
					Exceptions.LogException(new ArgumentException("ProductId cannot be null or empty", nameof(ProductId)));
					return null;
				}

				ApiResponse<ProductDTO> response = proxy.ProductsFindBySku(ProductId);

				if (response.Errors.Any())
				{
					Exceptions.LogException(new Exception($"API returned errors for ProductId {ProductId}: {string.Join(", ", response.Errors)}"));
					return null;
				}

				return response.Content;
			}
			catch (Exception ex)
			{
				Exceptions.LogException(new Exception($"Error retrieving product with ProductId {ProductId}", ex));
				return null;
			}
		}
	}
}