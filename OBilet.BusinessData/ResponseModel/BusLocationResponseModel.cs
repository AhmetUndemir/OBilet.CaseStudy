using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.BusinessData
{
	public class BusLocationResponseModel : BaseResponseModel
	{
		[JsonProperty("data")]
		public List<BusLocationData> Data { get; set; }
	}
}
