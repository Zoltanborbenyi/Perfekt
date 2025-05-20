<<<<<<< HEAD
﻿using DotNetNuke.Common.Utilities;
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
=======
﻿using DotNetNuke.Common.Utilities;
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
>>>>>>> 31121639048c6006417ddf5cbecf01d93a108438
}