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
using DotNetNuke.Services.Log.EventLog;
using System.Threading.Tasks;
using Hotcakes.CommerceDTO.v1.Orders;
using Hotcakes.Commerce.Orders;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.API
{
	internal class ProductAPI
	{
		public ProductDTO GetProductByProductId(Api proxy, string ProductId)
		{
			try
			{
				ApiResponse<ProductDTO> response = proxy.ProductsFindBySku(ProductId);

				if (response.Errors.Any())
				{
					AddDebugLog($"API returned errors for ProductId {ProductId}: {string.Join(", ", response.Errors)}");
					return null;
				}

				return response.Content;
			}
			catch (Exception ex)
			{
				AddDebugLog($"Error retrieving product with ProductId {ProductId}\n{ex.Message}");
				return null;
			}
		}
		public ProductDTO CreateProduct(Api proxy, ProductDTO newProduct)
		{
			try
			{
				ApiResponse<ProductDTO> response = proxy.ProductsCreate(newProduct, null);
				if (response.Errors.Any())
				{
					return null;
				}
				AddDebugLog($"Termék sikeresen létrehozva. BVIN: {response.Content.Bvin}");
				return response.Content;
			}
			catch (Exception ex)
			{
				AddDebugLog(ex.Message);
				return null;
			}
		}
		public OrderDTO FindOrder(Api proxy, string orderId)
		{
			try
			{
				ApiResponse<OrderDTO> response = proxy.OrdersFind(orderId);
				if (response.Errors.Any())
				{
					return null;
				}
				AddDebugLog($"Rendelések sikeresen lekérve");
				return response.Content;
			}
			catch (Exception ex)
			{
				AddDebugLog(ex.Message);
				return null;
			}
		}

		private void AddDebugLog(string message)
		{
			var logInfo = new LogInfo
			{
				LogTypeKey = EventLogController.EventLogType.ADMIN_ALERT.ToString(),
				BypassBuffering = true,
				LogUserName = "Debug"
			};

			logInfo.AddProperty("Debug", message);
			LogController.Instance.AddLog(logInfo);
		}
	}
}