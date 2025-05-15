using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Portals.Internal;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Log.EventLog;
using DotNetNuke.UI.UserControls;
using Hotcakes.Commerce;
using Hotcakes.Commerce.Orders;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Orders;
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
		private readonly HotcakesApplication hccApp;
		private readonly Api proxy;

		public CartItemTracker(HotcakesApplication _hccApp)
		{
			hccApp = _hccApp;

			// Például a CartItemTracker konstruktorában vagy más metódusban:
			int portalId = 0; // állítsd be, vagy vedd át paraméterként, ha tudod

			var aliasController = new PortalAliasController();
			var aliases = aliasController.GetPortalAliasesByPortalId(portalId);

			var firstAlias = aliases.FirstOrDefault();
			string portalAlias = firstAlias?.HTTPAlias;

			string apiUrl = "http://" + portalAlias + "/";
			string apiKey = "1-ad530e8b-0299-4748-91c1-28109518270e";

			proxy = new Hotcakes.CommerceDTO.v1.Client.Api(apiUrl, apiKey);
		}

		public void TrackItemStatus()
		{
			var draftItems = ItemManager.Instance.GetItems()
				.Where(i => i.Statusz == RentalStatus.Draft)
				.ToList();

			foreach (var item in draftItems)
			{
				try
				{
					ProcessDraftItem(item);
				}
				catch (Exception ex)
				{
					AddDebugLog($"Error processing item {item.ElemId}: {ex.Message}");
				}
			}
		}

		private void ProcessDraftItem(Item item)
		{
			ProductAPI productAPI = new ProductAPI();

			var matchingOrder = productAPI.FindOrder(proxy, item.KosarId);

			if (matchingOrder != null && !matchingOrder.IsPlaced)
			{
				AddDebugLog($"Processing item {item.ElemId} (Product: {item.ProductId})");

				// 1. Check if still in current cart
				if (IsCurrentCart(item.KosarId,item.BerloId,productAPI) && IsInOrder(item, matchingOrder))
				{
					AddDebugLog($"Item {item.ElemId} still in current cart");
					return;
				}
			}

			// 2. Check if in completed order
			if (matchingOrder != null && IsInOrder(item, matchingOrder) && matchingOrder.IsPlaced == true)
			{
				UpdateRentalStatus(item.ProductId, item.ElemId);
				productAPI.DeleteProduct(proxy, item.Bvin);
				AddDebugLog($"Item {item.ElemId} found in completed order. Status updated.");
				return;
			}

			// 3. If not found anywhere, delete
			DeleteRentalRecord(item.ProductId, item.ElemId);
			productAPI.DeleteProduct(proxy, item.Bvin);
			AddDebugLog($"Item {item.ElemId} not found in cart or orders. Deleted.");
		}

		private bool IsCurrentCart(string kosarId, string userId, ProductAPI productAPI)
		{
			// Lekérjük az adott user kosarait, amik még nincsenek leadva
			var kosarak = productAPI.FindOrders(proxy);

			if (!kosarak.Any())
				return false;

			// Megkeressük a legfrissebbet
			var legfrissebbKosar = kosarak
				.Where(k => k.UserID == userId)
				.OrderByDescending(k => k.LastUpdatedUtc)
				.FirstOrDefault();

			return legfrissebbKosar != null && legfrissebbKosar.bvin == kosarId;
		}


		private bool IsInOrder(Item item, OrderDTO order)
		{
			return order.Items.Any(li => li.Id.ToString() == item.ElemId);
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