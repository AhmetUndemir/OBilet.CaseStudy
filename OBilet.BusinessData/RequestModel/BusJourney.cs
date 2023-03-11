using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.BusinessData
{
    public class BusJourney : BaseModelRequest
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
