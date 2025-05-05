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
using System;
using System.Web.Caching;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.Models
{
	[TableName("RentManager_Products")]
	//setup the primary key for table
	[PrimaryKey("ProductId", AutoIncrement = false)]
	//configure caching using PetaPoco
	[Cacheable("Products", CacheItemPriority.Default, 20)]
	//scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
	[Scope("ModuleId")]
	public class Product
	{
		public string ProductId { get; set; }
		public decimal BerlesDij {  get; set; }
		public string bvin { get; set; }
		public string ImageFileMedium { get; set; }
		public string ProductName { get; set; }
		public int ModuleId { get; set; }
	}
}
