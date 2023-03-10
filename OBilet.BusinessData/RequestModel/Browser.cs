using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.BusinessData
{
	public class Browser
	{
		[JsonProperty("name")]
		public string name { get; set; }
		[JsonProperty("version")]
		public string version { get; set; }
	}
}
