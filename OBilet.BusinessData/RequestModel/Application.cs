using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.BusinessData
{
    public class Application
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("equipment-id")]
        public string EquipmentId { get; set; }
    }
}
