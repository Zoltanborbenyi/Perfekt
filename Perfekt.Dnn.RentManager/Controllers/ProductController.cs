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
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Catalog;
using System.Configuration;
using Perfekt.Dnn.Perfekt.Dnn.RentManager.API;
using System.Xml.Linq;
using Hotcakes.Commerce.Catalog;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.Controllers
{
	[DnnHandleError]
	public class ProductController : DnnController
	{

		Api proxy;

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

		//[HttpPost]
		//[DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
		//public ActionResult Edit(Item item)
		//{
		//	if (item.Id == -1)
		//	{
		//		ItemManager.Instance.CreateItem(item);
		//	}

		//	return RedirectToDefaultRoute();
		//}

		//[ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
		public ActionResult Index()
		{
			var products = GetProductsWithHccData();
			//var products = ProductManager.Instance.GetProducts();
			return View(products);
		}

		public IEnumerable<Perfekt.Dnn.RentManager.Models.Product> GetProductsWithHccData()
		{
			try
			{
				string apiUrl = "http://" + DotNetNuke.Entities.Portals.PortalSettings.Current.PortalAlias.HTTPAlias + "/";
				string apiKey = "1-ad530e8b-0299-4748-91c1-28109518270e";

				proxy = new Hotcakes.CommerceDTO.v1.Client.Api(apiUrl, apiKey);

				ProductAPI productAPI = new ProductAPI();

				var products = ProductManager.Instance.GetProducts();

				foreach (var product in products)
				{
					ProductDTO productDTO = productAPI.GetProductByProductId(proxy, product.ProductId);

					if (productDTO == null)
						continue;

					if (string.IsNullOrEmpty(product.Bvin))
					{
						product.ProductName = productDTO.ProductName;
						product.Bvin = productDTO.Bvin;
						product.ImageFileMedium = productDTO.ImageFileMedium;
						product.LongDescription = productDTO.LongDescription;
					}
				}

				return products;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
