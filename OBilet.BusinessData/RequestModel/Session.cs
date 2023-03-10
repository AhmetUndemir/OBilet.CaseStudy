using Newtonsoft.Json;
using OBilet.BusinessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.BusinessData
{
	public class Session
	{
		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("connection")]
		public Connection Connection { get; set; }

		[JsonProperty("browser")]
		public Browser Browser { get; set; }
	}
}
