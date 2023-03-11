using OBilet.Business.Abstract;
using OBilet.BusinessData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Business
{
	public class BusLocationManager : IBusLocationService
	{
		public RequestManager _requestManager;
		public BusLocationManager()
		{
			var baseURL = new BaseUrl
			{
				Auth = ConfigurationManager.AppSettings["APIKeyInfo"],
				Url = ConfigurationManager.AppSettings["APIURL"]
			};
			_requestManager = new RequestManager(baseURL);
		}
		public BusLocationResponseModel GetBusLocations(BusLocation data)
		{
			var DeviceSession = new DeviceSession()
			{
				DeviceId = data.DeviceSession.DeviceId,
				SessionId = data.DeviceSession.SessionId
			};

			data = new BusLocation
			{
				DeviceSession =DeviceSession,
				Data = data.Data,
				Date = data.Date,
				Language = data.Language
			};
			return _requestManager.Post<BusLocationResponseModel>(data, "location/getbuslocations");
		}
	}
}
