using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.BusinessData
{
	public class BaseResponseModel
	{
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("user-message")]
        public string UserMessage { get; set; }
        [JsonProperty("api-request-id")]
        public int? ApiRequestId { get; set; }
        [JsonProperty("controller")]
        public string Controller { get; set; }
        [JsonProperty("client-request-id")]
        public int? ClientRequestId { get; set; }
    }
}
