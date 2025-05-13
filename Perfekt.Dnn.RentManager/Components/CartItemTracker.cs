using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Log.EventLog;
using Hotcakes.Commerce;
using Hotcakes.CommerceDTO.v1.Client;
using Perfekt.Dnn.Perfekt.Dnn.RentManager.API;
using Perfekt.Dnn.Perfekt.Dnn.RentManager.Components;
using Perfekt.Dnn.Perfekt.Dnn.RentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.Components
{
	public class CartItemTracker
	{
		public void TrackItemStatus(HotcakesApplication hccApp)
		{
			var draftItems = ItemManager.Instance.GetItems()
				.Where(i => i.Statusz == RentalStatus.Draft)
				.ToList();

			string apiUrl = "http://" + DotNetNuke.Entities.Portals.PortalSettings.Current.PortalAlias.HTTPAlias + "/";
			string apiKey = "1-ad530e8b-0299-4748-91c1-28109518270e";

			Api proxy = new Hotcakes.CommerceDTO.v1.Client.Api(apiUrl, apiKey);
			ProductAPI productAPI = new ProductAPI();

			var currentCart = hccApp.OrderServices.CurrentShoppingCart();

			foreach (var item in draftItems)
			{
				try
				{
					// 1. Benne van a jelenlegi kosárban?
					bool isInCart = currentCart.Items.Any(ci => ci.Id.ToString() == item.ElemId);
					if (isInCart)
					{
						AddDebugLog($"Item {item.ElemId} is still in the current cart. No changes.");
						return;
					}

					// 2. Benne van valamelyik leadott rendelésben?
					var matchingOrder = productAPI.FindOrder(proxy, item.KosarId);

					if (matchingOrder != null)
					{
						bool itemFound = matchingOrder.Items.Any(li => li.Id.ToString() == item.ElemId);
						if (itemFound)
						{
							UpdateRentalStatus(item.ProductId, item.ElemId);
							AddDebugLog($"Item {item.ElemId} found in completed order. Status updated to Completed.");
							return;
						}
					}

					// 3. Ha sehol nincs, töröljük
					DeleteRentalRecord(item.ProductId, item.ElemId);
					AddDebugLog($"Item {item.ElemId} not found in cart or completed orders. Deleted.");
				}
				catch (Exception ex)
				{
					AddDebugLog($"Error processing item {item.ElemId}: {ex.Message}");
				}
			}
		}

		private void UpdateRentalStatus(string productId, string lineItemId)
		{
			var rental = ItemManager.Instance.GetItems(productId)
				.FirstOrDefault(i => i.ElemId == lineItemId);

			if (rental != null)
			{
				rental.Statusz = RentalStatus.Completed;
				ItemManager.Instance.UpdateItem(rental);
			}
		}

		private void DeleteRentalRecord(string productId, string lineItemId)
		{
			var rental = ItemManager.Instance.GetItems(productId)
				.FirstOrDefault(i => i.ElemId == lineItemId);

			if (rental != null)
			{
				ItemManager.Instance.DeleteItem(rental.Id);
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
		public class RentalStatus
		{
			public const string Draft = "Draft";
			public const string Completed = "Completed";
		}
	}
}