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

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;
using Hotcakes.Commerce.Marketing.PromotionQualifications;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Caching;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.Models
{
	[TableName("RentManager_Items")]
	//setup the primary key for table
	[PrimaryKey("Id", AutoIncrement = true)]
	//configure caching using PetaPoco
	[Cacheable("Items", CacheItemPriority.Default, 20)]
	//scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
	[Scope("ModuleId")]
	public class Item
	{
		public int Id { get; set; } = -1;
		public string Bvin { get; set; }
		public string ProductId { get; set; }
		public DateTime KezdoDatum { get; set; }
		public DateTime VegDatum { get; set; }
		public int NapokSzama { get; set; }
		public int Osszeg { get; set; }
		public string Berlo { get; set; }
		public string BerloId { get; set; }
		public string Statusz { get; set; }
		public string ElemId { get; set; }
		public string KosarId { get; set; }
		public int ModuleId { get; set; }
	}
}
