using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Business
{
	public class RequestManager : IRequestService
	{
		private readonly BaseUrl _baseUrl;
		public RequestManager(BaseUrl baseUrl)
		{
			_baseUrl = baseUrl;
		}
		public T Post<T>(object model, string methodUrl)
		{
			var client = new RestClient(string.Format("{0}/{1}", _baseUrl.Url, methodUrl));
			client.Timeout = -1;
			var request = new RestRequest(Method.POST);
			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Authorization", _baseUrl.Auth);
			var jsonConvert = JsonConvert.SerializeObject(model);
			request.AddParameter("application/json", jsonConvert, ParameterType.RequestBody);
			var returnContent = client.Execute(request);

			if (returnContent.StatusCode != HttpStatusCode.OK)
			{
				throw new InvalidOperationException("İşlem Başarısız!");
			}

			var response = JsonConvert.DeserializeObject<T>(returnContent.Content);

			return response;
		}
	}
}
