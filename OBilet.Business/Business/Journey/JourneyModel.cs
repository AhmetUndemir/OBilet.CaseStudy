using Newtonsoft.Json;
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
	public class JourneyModel
	{
		private readonly JourneyManager _journeyManager;
		private readonly SessionManager _sessionManager;
		private readonly LoggerManager _loggerManager;
		public string sessionId { get; set; }
		public string deviceId { get; set; }
		public int originId { get; set; }
		public int destinationId { get; set; }
		public DateTime date { get; set; }
		public List<BusJourneyData> busJourneyDatas { get; set; } = new List<BusJourneyData>();
		public string originLocation { get; set; }
		public string destinationLocation { get; set; }
		public DateTime departureDate { get; set; }
		public JourneyModel()
		{
			_journeyManager = new JourneyManager();
			_sessionManager = new SessionManager();
			_loggerManager = new LoggerManager("JourneyModel");
		}

		public JourneyModel Load()
		{
			if (string.IsNullOrEmpty(CurrentSession.Get("sessionId")) && string.IsNullOrEmpty(CurrentSession.Get("deviceId")))
			{
				var sessionInfo = _sessionManager.GetSession();
				CurrentSession.Set("sessionId", sessionInfo.Data.SessionId);
				CurrentSession.Set("deviceId", sessionInfo.Data.DeviceId);
				sessionId = CurrentSession.SessionInfo;
				deviceId = CurrentSession.DeviceInfo;
				_loggerManager.Info(string.Format("Session Info: {0} Device Info: {1}", sessionId, deviceId));
			}
			this.busJourneyDatas.AddRange(GetBusJourneys());
			if (this.busJourneyDatas.Any())
			{
				this.originLocation = busJourneyDatas.Select(a => a.OriginLocation).FirstOrDefault();
				this.destinationLocation = busJourneyDatas.Select(a => a.DestinationLocation).FirstOrDefault();
				this.departureDate = busJourneyDatas.Select(a => a.Journey.Departure).FirstOrDefault();
				CurrentSession.Set("originlocation", this.originLocation);
				CurrentSession.Set("originlocationid", this.originId.ToString());
				CurrentSession.Set("destinationlocation", this.destinationLocation);
				CurrentSession.Set("destinationlocationid", this.destinationId.ToString());
				CurrentSession.Set("departure", this.departureDate.ToString());

				_loggerManager.Info(string.Format("originlocation: {0}", this.originLocation));
				_loggerManager.Info(string.Format("originlocationid: {0}", this.originId));
				_loggerManager.Info(string.Format("destinationlocation: {0}", this.destinationLocation));
				_loggerManager.Info(string.Format("destinationlocationid: {0}", this.destinationId));
				_loggerManager.Info(string.Format("departure: {0}", this.departureDate));
			}
			return this;
		}

		public List<BusJourneyData> GetBusJourneys()
		{
			var DeviceSession = new DeviceSession()
			{
				DeviceId = CurrentSession.Get("deviceId"),
				SessionId = CurrentSession.Get("sessionId")
			};

			var busLocation = new BusJourney
			{
				DeviceSession = DeviceSession,
				Data = new Data() { OriginId = this.originId, DestinationId = this.destinationId, DepartureDate = this.date },
				Date = DateTime.Now,
				Language = "tr-TR"
			};

			var busLocations = _journeyManager.GetBusJourneys(busLocation);
			if (busLocations.Data == null || !busLocations.Data.Any())
			{
				busLocations.Data = new List<BusJourneyData>();
			}

			_loggerManager.Info(string.Format("Seferler: {0}", JsonConvert.SerializeObject(busLocations.Data)));
			return busLocations.Data;
		}

	}
}