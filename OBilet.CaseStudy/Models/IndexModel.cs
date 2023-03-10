using OBilet.Business;
using OBilet.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBilet.CaseStudy
{
	public class IndexModel
	{
		private readonly SessionManager _sessionManager;
		public string sessionId { get; set; }

		public IndexModel()
		{
			_sessionManager = new SessionManager();
		}

		public IndexModel Load()
		{
			var sessionInfo = _sessionManager.GetSession();
			CurrentSession.Set("sessionId", sessionInfo.Data.SessionId);
			CurrentSession.Set("deviceId", sessionInfo.Data.DeviceId);
			sessionId = CurrentSession.User.ToString();

			return this;
		}
	}
}