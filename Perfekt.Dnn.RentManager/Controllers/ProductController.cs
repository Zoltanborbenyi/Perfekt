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
	public class ProductController : DnnController
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
		public ActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public ActionResult GetProducts()
		{

			ProductManager.Instance.GetProducts();
			return RedirectToDefaultRoute();
		}
	}
}
