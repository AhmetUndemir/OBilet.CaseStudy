using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.BusinessData
{
	public class BusJourneyResponseModel : BaseResponseModel
	{
		[JsonProperty("data")]
		public List<BusJourneyData> Data { get; set; }
	}
}
