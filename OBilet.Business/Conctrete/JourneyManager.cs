using OBilet.BusinessData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Business
{
	public class JourneyManager : IJourneyService
	{
		public RequestManager _requestManager;

		public JourneyManager()
		{
			var baseURL = new BaseUrl
			{
				Auth = ConfigurationManager.AppSettings["APIKeyInfo"],
				Url = ConfigurationManager.AppSettings["APIURL"]
			};

			_requestManager = new RequestManager(baseURL);
		}
		public BusJourneyResponseModel GetBusJourneys(BusJourney busJourney)
		{
			return _requestManager.Post<BusJourneyResponseModel>(busJourney, "journey/getbusjourneys");
		}
	}
}
