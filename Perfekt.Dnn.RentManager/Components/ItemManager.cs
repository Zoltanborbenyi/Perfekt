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

using DotNetNuke.Data;
using DotNetNuke.Framework;
using Perfekt.Dnn.Perfekt.Dnn.RentManager.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.Components
{
	internal interface IItemManager
	{
		void CreateItem(Item t);
		void DeleteItem(int itemId);
		void DeleteItem(Item t);
		IEnumerable<Item> GetItems(string ProductId);
		IEnumerable<Item> GetItems();
		Item GetItem(int Id);
		void UpdateItem(Item t);
	}

	internal class ItemManager : ServiceLocator<IItemManager, ItemManager>, IItemManager
	{
		public void CreateItem(Item t)
		{
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Item>();
				rep.Insert(t);
			}
		}

		public void DeleteItem(int itemId)
		{
			var t = GetItem(itemId);
			DeleteItem(t);
		}

		public void DeleteItem(Item t)
		{
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Item>();
				rep.Delete(t);
			}
		}

		public IEnumerable<Item> GetItems(string ProductId)
		{
			IEnumerable<Item> t;
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Item>();

				if (!string.IsNullOrEmpty(ProductId))
				{
					// Szűrés ProductId alapján
					return rep.Find("WHERE ProductId = @0", ProductId);
				}
				t = rep.Get();
			}
			return t;
		}

		public IEnumerable<Item> GetItems()
		{
			IEnumerable<Item> t;
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Item>();
				t = rep.Get();
			}
			return t;
		}

		public Item GetItem(int Id)
		{
			Item t;
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Item>();
				t = rep.GetById(Id);
			}
			return t;
		}

		public void UpdateItem(Item t)
		{
			using (IDataContext ctx = DataContext.Instance())
			{
				var rep = ctx.GetRepository<Item>();
				rep.Update(t);
			}
		}

		protected override System.Func<IItemManager> GetFactory()
		{
			return () => new ItemManager();
		}
	}
}
