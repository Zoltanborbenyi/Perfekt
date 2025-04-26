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

		//public ActionResult Edit(int Id = -1)
		//{
		//	var item = (Id == -1)
		//		 ? new Item { }
		//		 : ItemManager.Instance.GetItem(Id);

		//	return View(item);
		//}


		[HttpPost]
		[DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
		public ActionResult Edit(Item item, string id, DateTime kezdet, DateTime veg)
		{
			if (item.Id == -1)
			{
				item.ProductId = id;
				item.KezdoDatum = kezdet;
				item.VegDatum = veg;

				ItemManager.Instance.CreateItem(item);
			}

			return RedirectToDefaultRoute();

			//if (item.ItemId == -1)
			//{
			//	item.CreatedByUserId = User.UserID;
			//	item.CreatedOnDate = DateTime.UtcNow;
			//	item.LastModifiedByUserId = User.UserID;
			//	item.LastModifiedOnDate = DateTime.UtcNow;

			//	ItemManager.Instance.CreateItem(item);
			//}
			//else
			//{
			//	var existingItem = ItemManager.Instance.GetItem(item.ItemId, item.ModuleId);
			//	existingItem.LastModifiedByUserId = User.UserID;
			//	existingItem.LastModifiedOnDate = DateTime.UtcNow;
			//	existingItem.ItemName = item.ItemName;
			//	existingItem.ItemDescription = item.ItemDescription;
			//	existingItem.AssignedUserId = item.AssignedUserId;

			//	ItemManager.Instance.UpdateItem(existingItem);
			//}
		}

		//[ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]

		public ActionResult Index()
		{
			// Retrieve the DefaultView setting
			var defaultView = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("Perfekt.Dnn.Perfekt.Dnn.RentManager", "Index");

			// Redirect to the appropriate action based on the setting
			if (defaultView == "Additem")
			{
				return RedirectToAction("Additem");
			}
			else
			{
				Product p = new Product();
				var items = ItemManager.Instance.GetItems(p.Id);
				return View(items);
			}
		}
		public ActionResult Additem()
		{
			return View(new Item());
		}

		[HttpPost]
		public ActionResult AddItem(Item t)
		{
			ItemManager.Instance.CreateItem(t);
			return RedirectToDefaultRoute();
		}
	}
	//public class ItemController : DnnController
	//{

	//	public ActionResult Delete(int itemId)
	//	{
	//		ItemManager.Instance.DeleteItem(itemId, ModuleContext.ModuleId);
	//		return RedirectToDefaultRoute();
	//	}

	//	public ActionResult Edit(int itemId = -1)
	//	{
	//		DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

	//		var userlist = UserController.GetUsers(PortalSettings.PortalId);
	//		var users = from user in userlist.Cast<UserInfo>().ToList()
	//					select new SelectListItem { Text = user.DisplayName, Value = user.UserID.ToString() };

	//		ViewBag.Users = users;

	//		var item = (itemId == -1)
	//			 ? new Item { ModuleId = ModuleContext.ModuleId }
	//			 : ItemManager.Instance.GetItem(itemId, ModuleContext.ModuleId);

	//		return View(item);
	//	}

	//	[HttpPost]
	//	[DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
	//	public ActionResult Edit(Item item,string id, DateTime kezd, DateTime veg)
	//	{
	//		if (item.Id == -1)
	//		{
	//			item.ProductId = id;
	//			item.KezdoDatum = kezd;
	//			item.VegDatum = veg;

	//			ItemManager.Instance.CreateItem(item);
	//		}

	//		return RedirectToDefaultRoute();
	//	}

	//	[ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
	//	public ActionResult Index()
	//	{
	//		var items = ItemManager.Instance.GetItems(ModuleContext.ModuleId);
	//		return View(items);
	//	}
	//}
}
