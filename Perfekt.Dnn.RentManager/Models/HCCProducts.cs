using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;
using System;
using System.Web.Caching;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.Models
{
	[TableName("hcc_Product")]
	public class HCCProduct
	{
		[ColumnName("bvin")]
		public string Id { get; set; } 

		public string RewriteURL { get; set; }
	}
}