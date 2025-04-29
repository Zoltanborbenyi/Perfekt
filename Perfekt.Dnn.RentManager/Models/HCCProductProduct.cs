using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;
using System;
using System.Web.Caching;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.Models
{
	public class HCCProductProduct
	{
		public Product Product { get; set; }
		public HCCProduct HCC { get; set; }
	}
}