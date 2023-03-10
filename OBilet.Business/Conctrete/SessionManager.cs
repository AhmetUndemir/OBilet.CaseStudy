using OBilet.BusinessData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Business
{
	public class SessionManager : ISessionService
	{
		public RequestManager _requestManager;

		public SessionManager()
		{
			var baseURL = new BaseUrl
			{
				Auth = ConfigurationManager.AppSettings["APIKeyInfo"],
				Url = ConfigurationManager.AppSettings["APIURL"]
			};
			_requestManager = new RequestManager(baseURL);
		}
		public SessionResponseModel GetSession()
		{
			var Connection = new Connection() { IpAddress = "165.114.41.21", Port = "5117" };
			var Type = 1;
			var Browser = new Browser { name = "Chrome", version = "47.0.0.12" };
			var sessionData = new Session()
			{
				Connection = Connection,
				Browser = Browser,
				Type = Type
			};
			return _requestManager.Post<SessionResponseModel>(sessionData, "client/getsession");
		}
	}
}
