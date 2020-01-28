using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InventoryService.Service.ApiConsumer
{
    public class ClientAbstract<T> where T : class
    {
        private readonly HttpClient _client;
        private HttpResponseMessage _httpResponse;
        private string _url;
        private string _json;

        public ClientAbstract()
        {
            _client = new HttpClient();
        }

        public void SetUrl(string url)
        {
            _url = url;
        }
        public async Task<List<T>> GetAll()
        {
            _httpResponse = await _client.GetAsync(_url);
            _json = _httpResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<T>>(_json);
        }

        public async Task<HttpStatusCode> PostWithoutResponse(T model)
        {
            _httpResponse = await _client.PostAsJsonAsync(_url, model);
            return _httpResponse.StatusCode;
        }

        public async Task<byte[]> PostWithFile(T model)
        {
            _httpResponse = await _client.PostAsJsonAsync(_url, model);
            _json = _httpResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<byte[]>(_json);
        }

    }
}