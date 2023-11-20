using Microsoft.Extensions.Logging;
using QPDTask.Service.Configuration;
using QPDTask.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QPDTask.Service
{
    public class DadataService : IDadataService
    {
        private readonly DadataHttpClient _dadataHttpClient;
        private readonly ILogger<DadataService> _logger;

        public DadataService(DadataHttpClient dadataHttpClient, ILogger<DadataService> logger)
        {
            _dadataHttpClient = dadataHttpClient;
            _logger = logger;
        }

        public async Task<CleanAddressModel?> CleanAddressAsync(RawAddressModel rawAddressModel)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    Converters = { new RawAddressModelConverter() },
                };

                var jsonRequest = JsonSerializer.Serialize(rawAddressModel, options);
                await Console.Out.WriteLineAsync(jsonRequest);
                var response = await _dadataHttpClient.PostDataAsync(jsonRequest);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var cleanAddressModel = JsonSerializer.Deserialize<List<CleanAddressModel>>(jsonResponse).First();

                    return cleanAddressModel;
                }
                else
                {
                    var errorMessage = $"Dadata API request failed with status code {response.StatusCode}";
                    _logger.Log(LogLevel.Warning, errorMessage);
                    return null;
                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                return null;
            }
        }
    }
}
