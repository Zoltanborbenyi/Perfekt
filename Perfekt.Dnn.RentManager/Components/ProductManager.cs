<<<<<<< HEAD
﻿/*
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

using DotNetNuke.Common.Controls;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Perfekt.Dnn.Perfekt.Dnn.RentManager.Models;
using System.Collections.Generic;
using System.IO;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.Components
{
	internal interface IProductManager
	{
		//Product GetHccProductBySku(string ProductId);
		void CreateProduct(Product t);
		//void DeleteItem(int itemId, int moduleId);
		//void DeleteItem(Item t);
		IEnumerable<Product> GetProducts();
		Product GetProduct(int Id);
		void UpdateProduct(Product t);
	}

	internal class ProductManager : ServiceLocator<IProductManager, ProductManager>, IProductManager
	{
		//public Product GetHccProductBySku(string ProductId)
		//{
		//	var ctx = DataProvider.Instance().ExecuteReader(
		//		"SELECT p.SKU, p.ImageFileMedium, t.ProductId, t.ProductName, t.LongDescription " +
		//		"FROM hcc_Product p " +
		//		"LEFT JOIN hcc_ProductTranslations t ON p.bvin = t.ProductId " +
		//		"WHERE p.SKU = @ProductId",
		//		new System.Data.SqlClient.SqlParameter("@ProductId", ProductId));

		//	using (ctx)
		//	{
		//		if (ctx.Read())
		//		{
		//			return new Product
		//			{
		//				bvin = ctx["ProductId"].ToString(),
		//				ImageFileMedium = Path.Combine(
		//							@"~\Portals\0\Hotcakes\Data\products",
		//							ctx["ProductId"].ToString(),
		//							ctx["ImageFileMedium"].ToString()),
		//				ProductName = ctx["ProductName"].ToString(),
		//				LongDescription = ctx["LongDescription"].ToString()
		//			};
		//		}
		//	}
		//	return null;
		//}
		public void CreateProduct(Product t)
		{
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Product>();
				rep.Insert(t);
			}
		}

		//public void DeleteItem(int itemId, int moduleId)
		//{
		//	var t = GetItem(itemId, moduleId);
		//	DeleteItem(t);
		//}

		//public void DeleteItem(Item t)
		//{
		//	using (IDataContext ctx = DataContext.Instance())
		//	{
		//		var rep = ctx.GetRepository<Item>();
		//		rep.Delete(t);
		//	}
		//}

		public IEnumerable<Product> GetProducts()
		{
			IEnumerable<Product> t;
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Product>();
				t = rep.Get();
			}
			return t;
		}

		public Product GetProduct(int Id)
		{
			Product t;
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Product>();
				t = rep.GetById(Id);
			}
			return t;
		}

		public void UpdateProduct(Product t)
		{
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Product>();
				rep.Update(t);
			}
		}

		protected override System.Func<IProductManager> GetFactory()
		{
			return () => new ProductManager();
		}
	}
}
=======
﻿/*
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

using DotNetNuke.Data;
using DotNetNuke.Framework;
using Perfekt.Dnn.Perfekt.Dnn.RentManager.Models;
using System.Collections.Generic;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.Components
{
	internal interface IProductManager
	{
		void CreateProduct(Product t);
		IEnumerable<Product> GetProducts();
		Product GetProduct(int Id);
		void UpdateProduct(Product t);
	}

	internal class ProductManager : ServiceLocator<IProductManager, ProductManager>, IProductManager
	{
		public void CreateProduct(Product t)
		{
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Product>();
				rep.Insert(t);
			}
		}

		public IEnumerable<Product> GetProducts()
		{
			IEnumerable<Product> t;
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Product>();
				t = rep.Get();
			}
			return t;
		}

		public Product GetProduct(int Id)
		{
			Product t;
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Product>();
				t = rep.GetById(Id);
			}
			return t;
		}

		public void UpdateProduct(Product t)
		{
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Product>();
				rep.Update(t);
			}
		}

		protected override System.Func<IProductManager> GetFactory()
		{
			return () => new ProductManager();
		}
	}
}
>>>>>>> 31121639048c6006417ddf5cbecf01d93a108438
