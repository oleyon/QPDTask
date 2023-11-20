using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QPDTask.Service.Configuration
{
    public class DadataHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly DadataConfig _dadataConfig;


        public DadataHttpClient(HttpClient httpClient, DadataConfig dadataSettings)
        {
            _httpClient = httpClient;
            _dadataConfig = dadataSettings;
            _httpClient.BaseAddress = new Uri("https://cleaner.dadata.ru/api/v1/clean/address/");
        }

        public async Task<HttpResponseMessage> PostDataAsync(string body)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Application-type", "application/json");
            _httpClient.DefaultRequestHeaders.Add("X-Secret", _dadataConfig.ApiSecret);
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Token " + _dadataConfig.ApiKey);

            var content = new StringContent(body, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("", content);
        }
    }
}
