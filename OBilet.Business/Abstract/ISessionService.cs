using OBilet.BusinessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Business
{
	public interface ISessionService
	{
		SessionResponseModel GetSession();
	}
}
