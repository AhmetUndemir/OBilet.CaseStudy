using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.BusinessData
{
	public class BusJourneyData
	{
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("partner-id")]
        public string PartnerId { get; set; }

        [JsonProperty("partner-name")]
        public string PartnerName { get; set; }

        [JsonProperty("origin-location")]
        public string OriginLocation { get; set; }

        [JsonProperty("journey")]
        public Journey Journey { get; set; }

        [JsonProperty("destination-location")]
        public string DestinationLocation { get; set; }

    }
}
