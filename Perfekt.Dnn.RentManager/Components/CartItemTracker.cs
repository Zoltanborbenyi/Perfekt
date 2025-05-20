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
using System.Web.Mvc;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.Components
{
	public class CartItemTracker
	{
		private readonly HotcakesApplication hccApp;
		private readonly Api proxy;
		private readonly ProductAPI productAPI;

		public CartItemTracker(HotcakesApplication _hccApp)
		{
			hccApp = _hccApp;

			productAPI = new ProductAPI();

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
			var currentDraftItems = ItemManager.Instance.GetItems()
				.Where(i => i.Statusz == RentalStatus.Draft)
				.ToList();

			foreach (var item in currentDraftItems)
			{
				try
				{
					var freshItem = ItemManager.Instance.GetItem(item.Bvin);
					if (freshItem.Statusz != RentalStatus.Draft)
					{
						AddDebugLog($"Item {item.ElemId} is no longer in Draft status (current: {freshItem.Statusz}). Skipping.");
						continue;
					}

					ProcessDraftItem(freshItem);
				}
				catch (Exception ex)
				{
					AddDebugLog($"Error processing item {item.ElemId}: {ex.Message}");
				}
			}
		}

		private void ProcessDraftItem(Item item)
		{
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
				var allDraftItems = ItemManager.Instance.GetItems()
									.Where(i => i.Statusz == RentalStatus.Draft && i.Bvin != item.Bvin) // Kizárjuk az aktuális elemet
									.ToList();

				foreach (var foglalas in allDraftItems)
				{
					if (foglalas.ProductName == item.ProductName)
					{
						var otherOrder = productAPI.FindOrder(proxy, foglalas.KosarId);

						if (item.KezdoDatum.Date <= foglalas.VegDatum.Date && item.VegDatum.Date >= foglalas.KezdoDatum.Date)
						{
							if (matchingOrder.LastUpdatedUtc < otherOrder.LastUpdatedUtc)
							{
								// Ütközik
								UpdateRentalStatus(foglalas.ProductId, foglalas.ElemId, false);
								productAPI.DeleteProduct(proxy, foglalas.Bvin);
							}

							if (matchingOrder.LastUpdatedUtc > otherOrder.LastUpdatedUtc)
							{
								if (otherOrder.IsPlaced)
								{
									UpdateRentalStatus(item.ProductId, item.ElemId, false);
									productAPI.DeleteProduct(proxy, item.Bvin);
									return;
								}
								else
								{
									UpdateRentalStatus(foglalas.ProductId, foglalas.ElemId, false);
									productAPI.DeleteProduct(proxy, foglalas.Bvin);
								}
							}
						}
					}
				}

				UpdateRentalStatus(item.ProductId, item.ElemId, true);
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

		private void UpdateRentalStatus(string productId, string lineItemId, bool elsoE)
		{
			var rental = ItemManager.Instance.GetItems(productId)
				.FirstOrDefault(i => i.ElemId == lineItemId);

			if (rental != null)
			{
				if (elsoE)
				{
					rental.Statusz = RentalStatus.Completed;
					ItemManager.Instance.UpdateItem(rental);
				}
				else
				{
					rental.Statusz = RentalStatus.Canceled;
					ItemManager.Instance.UpdateItem(rental);
				}

			}
		}

		private void DeleteRentalRecord(string productId, string lineItemId)
		{
			var rental = ItemManager.Instance.GetItems(productId)
				.FirstOrDefault(i => i.ElemId == lineItemId);

			if (rental != null)
			{
				ItemManager.Instance.DeleteItem(rental.Bvin);
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
			public const string Canceled = "Canceled";
		}
	}
}