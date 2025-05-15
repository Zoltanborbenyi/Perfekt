/*
' Copyright (c) 2025 Perfekt
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Collections;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using Perfekt.Dnn.Perfekt.Dnn.RentManager.Components;
using Perfekt.Dnn.Perfekt.Dnn.RentManager.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using Hotcakes.Commerce;
using Hotcakes.Commerce.Catalog;
using Hotcakes.Commerce.Data;
using Hotcakes.Commerce.Orders;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using Hotcakes.Commerce.Marketing.PromotionQualifications;
using DotNetNuke.Services.Log.EventLog;
using System.ComponentModel.Design;
using Hotcakes.CommerceDTO.v1.Catalog;
using Perfekt.Dnn.Perfekt.Dnn.RentManager.API;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.Commerce.Utilities;
using Hotcakes.CommerceDTO.v1;
using System.IO;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.Controllers
{
	[DnnHandleError]
	public class ItemController : DnnController
	{
		//public ActionResult Delete(int itemId)
		//{
		//	ItemManager.Instance.DeleteItem(itemId, ModuleContext.ModuleId);
		//	return RedirectToDefaultRoute();
		//}

		public ActionResult Edit(int Id = -1)
		{
			var item = (Id == -1)
				 ? new Item { }
				 : ItemManager.Instance.GetItem(Id);

			return View(item);
		}

		[HttpPost]
		[DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
		public ActionResult Edit(Item item)
		{
			if (item.Id == -1)
			{
				ItemManager.Instance.CreateItem(item);
			}

			return RedirectToDefaultRoute();
		}

		//[ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
		public ActionResult Index(string ProductId)
		{
			// Retrieve the DefaultView setting
			var defaultView = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("Perfekt.Dnn.RentManager_DefaultView", "Index");

			// Redirect to the appropriate action based on the setting
			if (defaultView.Equals("Additem", StringComparison.OrdinalIgnoreCase))
			{
				return RedirectToAction("Additem");
			}
			else 
			{
				var items = ItemManager.Instance.GetItems(ProductId);
				return View(items);
			}
		}
		public ActionResult Additem()
		{
			return View(new Item());
		}
		public ActionResult Allitem()
		{
			var items = ItemManager.Instance.GetItems();
			return View(items);
		}

		[HttpPost]
		public ActionResult AddItem(Item model)
		{
			DateTime kezdoDatum = DateTime.Parse(Request.Form["KezdoDatum"]);
			DateTime vegDatum = DateTime.Parse(Request.Form["VegDatum"]);
			string productId = Request.Form["ProductId"].ToString();
			int napokSzama = int.Parse(Request.Form["NapokSzama"]);
			string nev = $"{Request.Form["ProductName"].ToString()} BÉRLÉSE {kezdoDatum:yyyy-MM-dd} - {vegDatum:yyyy-MM-dd}";
			int osszeg = int.Parse(Request.Form["Osszeg"]);
			string kep = Request.Form["ImageFileMedium"].ToString();
			string bvin = Request.Form["Bvin"].ToString();
			string berloId = User.UserID.ToString();

			string imagePath = Path.Combine("C:\\DNN", "Portals", "0", "Hotcakes", "Data", "products", bvin, "medium", kep);
			byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

			var letezoFoglalasok = ItemManager.Instance.GetItems(model.ProductId);

			if (VanIdoUtkozes(kezdoDatum, vegDatum, letezoFoglalasok, berloId))
			{
				return View("Additem", model); // vagy redirect vissza hibaüzenettel
			}

			var newProduct = Letrehozas(osszeg,nev,kep,imageBytes);

			AddDebugLog(newProduct.Bvin.ToString());

			if (newProduct.Bvin == null)
			{
				AddDebugLog("Hiba történt a termék létrehozásakor");
				return View("Additem",model);
			}

			Dictionary<string, string> id = KosarbaRakas((newProduct.Bvin).ToUpper(), nev);
			if (id == null)
			{
				AddDebugLog("Hiba történt a kosárhoz adáskor");
				return View("Additem", model);
			}

			RendelesMentes(model, productId, kezdoDatum, vegDatum, napokSzama, id["ElemId"], id["KosarId"],osszeg,berloId,newProduct.Bvin);

			//meghívjuk a kosarat és belelépünk, hogy lássuk a betett elemet
			string kosarUrl = "http://" + DotNetNuke.Entities.Portals.PortalSettings.Current.PortalAlias.HTTPAlias + "/kosar/";

			return Redirect(Url.Content(kosarUrl));
		}

		public Dictionary<string, string> KosarbaRakas(string bvin, string nev)
		{
			AddDebugLog("KosarbaRakas method started");

			if (string.IsNullOrEmpty(bvin))
			{
				AddDebugLog($"Hiba: Hiányzó vagy érvénytelen adat. bvin: {bvin}");
				return null;
			}

			var HccApp = HotcakesApplication.Current;
			AddDebugLog($"HotcakesApplication.Current: {(HccApp != null ? "nem null" : "null")}");

			if (HccApp == null)
			{
				AddDebugLog("Hiba: HotcakesApplication is null");
				return null;
			}

			AddDebugLog($"HccApp.OrderServices: {(HccApp.OrderServices != null ? "nem null" : "null")}");

			if (HccApp.OrderServices == null)
			{
				AddDebugLog("Hiba: OrderServices is null");
				return null;
			}

			Order order = HccApp.OrderServices.CurrentShoppingCart();

			if (order == null)
			{
				order = HccApp.OrderServices.EnsureShoppingCart();
			}

			var lineItem = new LineItem
			{
				ProductId = bvin,
				ProductName = nev,
				Quantity = 1
			};

			HccApp.AddToOrderAndSave(order, lineItem);

			string lineItemId = lineItem.Id.ToString();

			return new Dictionary<string, string>
				{
					{ "KosarId", order.bvin },
					{ "ElemId", lineItemId }
				};
		}
		public ActionResult RendelesMentes(Item model, string productId, DateTime kezdoDatum, DateTime vegDatum, int napokSzama, string elemId, string kosarId, int osszeg, string berloId,string bvin)
		{
			model.Bvin = bvin;
			model.ProductId = productId;
			model.KezdoDatum = kezdoDatum;
			model.VegDatum = vegDatum;
			model.NapokSzama = napokSzama;
			model.Osszeg = osszeg;
			model.Berlo = User.Username.ToString();
			model.BerloId = berloId;
			model.Statusz = "Draft";
			model.ElemId = elemId;
			model.KosarId = kosarId;

			ItemManager.Instance.CreateItem(model);
			return null;
		}
		public bool VanIdoUtkozes(DateTime ujKezdo, DateTime ujVeg, IEnumerable<Item> letezoFoglalasok, string berloId)
		{
			foreach (var foglalas in letezoFoglalasok)
			{
				if (foglalas.Statusz == "Completed")
				{
					if (ujKezdo.Date <= foglalas.VegDatum.Date && ujVeg.Date >= foglalas.KezdoDatum.Date)
					{
						// Ütközik
						ViewBag.VanUtkozes = true;
						return true;
					}
				}

				if (foglalas.BerloId == berloId)
				{
					if (ujKezdo.Date <= foglalas.VegDatum.Date && ujVeg.Date >= foglalas.KezdoDatum.Date)
					{
						// Ütközik
						ViewBag.VanFelhasznalo = true;
						return true;
					}
				}
			}

			// Nincs ütközés
			ViewBag.VanUtkozes = false;
			ViewBag.VanFelhasznalo = false;
			return false;
		}

		public ProductDTO Letrehozas(int osszeg, string nev, string kep, byte[] imageBytes)
		{
			var portalSettings = DotNetNuke.Entities.Portals.PortalSettings.Current;

			string apiUrl = "http://" + DotNetNuke.Entities.Portals.PortalSettings.Current.PortalAlias.HTTPAlias + "/";
			string apiKey = "1-ad530e8b-0299-4748-91c1-28109518270e";

			Api proxy = new Hotcakes.CommerceDTO.v1.Client.Api(apiUrl, apiKey);

			ProductAPI productAPI = new ProductAPI();

			string sku = Guid.NewGuid().ToString().Substring(0, 8);
			string kepNev = kep;

			var productDTO = new ProductDTO
			{
				ProductName = nev,
				SitePrice = osszeg,
				ListPrice = osszeg,
				StoreId = 0,
				Sku = sku,
				ImageFileMedium = kepNev,
				ImageFileSmall = kepNev,
				IsSearchable = false,
			};

			productAPI.CreateProduct(proxy, productDTO);

			var result = productAPI.GetProductByProductId(proxy, sku);
			if (result != null && !string.IsNullOrEmpty(result.Bvin))
			{

				string productsBasePath = Path.Combine("C:\\DNN", "Portals", "0", "Hotcakes", "Data", "products", result.Bvin);
				Directory.CreateDirectory(productsBasePath);
				Directory.CreateDirectory(Path.Combine(productsBasePath, "medium"));
				Directory.CreateDirectory(Path.Combine(productsBasePath, "small"));

				// mentés minden méretre
				System.IO.File.WriteAllBytes(Path.Combine(productsBasePath, "medium", kepNev), imageBytes);
				System.IO.File.WriteAllBytes(Path.Combine(productsBasePath, "small", kepNev), imageBytes);
				System.IO.File.WriteAllBytes(Path.Combine(productsBasePath, kepNev), imageBytes);

				AddDebugLog($"Képek sikeresen lementve a {result.Bvin} alá");
			}
			else
			{
				AddDebugLog("Hiba történt a termék létrehozása közben.");
			}

			AddDebugLog($"Termék sikeresen létrehozva és képekkel frissítve. BVIN: {result.Bvin}");
			return result;
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
