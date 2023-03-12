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
		public int originId { get; set; }
		public int destinationId { get; set; }
		public DateTime date { get; set; }


		public string originlocation { get; set; }
		public string originlocationid { get; set; }
		public string destinationlocation { get; set; }
		public string destinationlocationid { get; set; }
		public string departure { get; set; }

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

			if(!string.IsNullOrEmpty(CurrentSession.Get("originlocation")) && !string.IsNullOrEmpty(CurrentSession.Get("destinationlocation")) && !string.IsNullOrEmpty(CurrentSession.Get("departure")))
			{
				this.originlocation = CurrentSession.Get("originlocation");
				this.originlocationid = CurrentSession.Get("originlocationid");
				this.destinationlocation = CurrentSession.Get("destinationlocation");
				this.destinationlocationid = CurrentSession.Get("destinationlocationid");
				this.departure = CurrentSession.Get("departure");
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