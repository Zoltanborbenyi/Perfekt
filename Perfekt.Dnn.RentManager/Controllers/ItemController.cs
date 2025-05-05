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
using System.Collections.Generic;

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

		[HttpPost]
		public ActionResult AddItem(Item model)
		{
			DateTime kezdoDatum = DateTime.Parse(Request.Form["KezdoDatum"]);
			DateTime vegDatum = DateTime.Parse(Request.Form["VegDatum"]);

			model.ProductId = Request.Form["ProductId"].ToString();
			model.KezdoDatum = kezdoDatum;
			model.VegDatum = vegDatum;
			model.NapokSzama = int.Parse(Request.Form["NapokSzama"]);
			model.Osszeg = int.Parse(Request.Form["Osszeg"]);
			model.Berlo = User.UserID.ToString();

			var letezoFoglalasok = ItemManager.Instance.GetItems(model.ProductId);

			if (VanIdoUtkozes(kezdoDatum, vegDatum, letezoFoglalasok))
			{
				return View(); // vagy redirect vissza hibaüzenettel
			}

			ItemManager.Instance.CreateItem(model);

			return Redirect(Url.Content($"/kosar?AddSku={model.ProductId}&AddSkuQty={model.NapokSzama}&CouponCode=BERLES{model.ProductId}"));
		}

		public bool VanIdoUtkozes(DateTime ujKezdo, DateTime ujVeg, IEnumerable<Item> letezoFoglalasok)
		{
			foreach (var foglalas in letezoFoglalasok)
			{
				if (ujKezdo <= foglalas.VegDatum && ujVeg >= foglalas.KezdoDatum)
				{
					// Ütközik
					return true;
				}
			}

			// Nincs ütközés
			return false;
		}
	}
}
