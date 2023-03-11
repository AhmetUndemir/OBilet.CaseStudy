using OBilet.Business;
using OBilet.BusinessData;
using OBilet.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OBilet.CaseStudy
{
	public class IndexModel
	{
		private readonly SessionManager _sessionManager;
		private readonly BusLocationManager _busLocationManager;
		public SelectList BusLocations { get; set; }
		public string sessionId { get; set; }
		public string deviceId { get; set; }

		public IndexModel()
		{
			_sessionManager = new SessionManager();
			_busLocationManager = new BusLocationManager();
		}

		public IndexModel Load()
		{
			if (string.IsNullOrEmpty(CurrentSession.Get("sessionId")) && string.IsNullOrEmpty(CurrentSession.Get("deviceId")))
			{
				var sessionInfo = _sessionManager.GetSession();
				CurrentSession.Set("sessionId", sessionInfo.Data.SessionId);
				CurrentSession.Set("deviceId", sessionInfo.Data.DeviceId);
				sessionId = CurrentSession.SessionInfo;
				deviceId = CurrentSession.DeviceInfo;
			}

			this.BusLocations = GetBusLocations();

			return this;
		}

		public SelectList GetBusLocations()
		{
			var DeviceSession = new DeviceSession()
			{
				DeviceId = CurrentSession.Get("deviceId"),
				SessionId = CurrentSession.Get("sessionId")
			};

			var busLocation = new BusLocation
			{
		 		DeviceSession = DeviceSession,
				Data = null,
				Date = DateTime.Now,
				Language = "tr-TR"
			};

			var busLocations = _busLocationManager.GetBusLocations(busLocation);

			return new SelectList(busLocations.Data, "Id", "Name");
		}
	}
}