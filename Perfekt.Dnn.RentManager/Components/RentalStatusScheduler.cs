using DotNetNuke.Services.Log.EventLog;
using DotNetNuke.Services.Scheduling;
using DotNetNuke.UI.UserControls;
using Hotcakes.Commerce;
using System;
using System.Linq;
using DotNetNuke.Entities.Users;

namespace Perfekt.Dnn.Perfekt.Dnn.RentManager.Components
{
	public class RentalStatusScheduler : SchedulerClient
	{
		public RentalStatusScheduler(ScheduleHistoryItem item) : base()
		{
			ScheduleHistoryItem = item;
		}

		public override void DoWork()
		{
			try
			{
				var HccApp = HotcakesApplication.Current;

				CartItemTracker cartItemTracker = new CartItemTracker();
				cartItemTracker.TrackItemStatus(HccApp);				

				ScheduleHistoryItem.Succeeded = true;
				AddDebugLog("RentalStatusScheduler completed successfully.");
			}
			catch (Exception ex)
			{
				ScheduleHistoryItem.Succeeded = false;
				AddDebugLog($"RentalStatusScheduler failed: {ex.Message}");
			}
		}
		private void AddDebugLog(string message)
		{
			var logInfo = new LogInfo
			{
				LogTypeKey = EventLogController.EventLogType.ADMIN_ALERT.ToString(),
				BypassBuffering = true,
				LogUserName = "Debug"
			};

			logInfo.AddProperty("Debug", message);
			LogController.Instance.AddLog(logInfo);
		}
	}
}