using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace SeleniumDemoblaze.Requests
{
    public class ApiRequest
    {
        private static HttpClient _httpClient = new HttpClient();
        protected static string Post(string path, object data)
        {
            var endpoint = Configuration.BaseEndpoint + path;
            var newPostJson = JsonConvert.SerializeObject(data);
            var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");
            return _httpClient.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
        }

    }
}
