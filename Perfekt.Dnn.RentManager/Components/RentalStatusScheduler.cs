using DotNetNuke.Services.Log.EventLog;
using DotNetNuke.Services.Scheduling;
using DotNetNuke.UI.UserControls;
using Hotcakes.Commerce;
using System;
using System.Linq;
using DotNetNuke.Entities.Users;
using DotNetNuke.Entities.Portals;
using static Perfekt.Dnn.Perfekt.Dnn.RentManager.Components.CartItemTracker;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.Components
{
	public class RentalStatusScheduler : SchedulerClient
	{
		public RentalStatusScheduler(ScheduleHistoryItem oItem) : base()
		{
			this.ScheduleHistoryItem = oItem;
		}

		public override void DoWork()
		{
			try
			{
				//Perform required items for logging
				this.Progressing();

				var hccApp = HotcakesApplication.Current;
				if (hccApp == null)
				{
					throw new NullReferenceException("HotcakesApplication.Current is null - commerce not initialized");
				}

				var cartItemTracker = new CartItemTracker(hccApp);
				cartItemTracker.TrackItemStatus();

				//Show success
				this.ScheduleHistoryItem.Succeeded = true;
			}
			catch (Exception ex)
			{
				this.ScheduleHistoryItem.Succeeded = false;
				this.ScheduleHistoryItem.AddLogNote("Exception= " + ex.ToString());
				this.Errored(ref ex);
				DotNetNuke.Services.Exceptions.Exceptions.LogException(ex);
			}
		}
	}
}