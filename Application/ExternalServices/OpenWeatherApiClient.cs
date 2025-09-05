using Application.Common.Interfaces;
using Application.Weathers.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Writers;
using System.Net.Http.Json;

namespace Application.ExternalServices
{
    public class OpenWeatherApiClient : IOpenWeatherApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;
        public OpenWeatherApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiKey = _configuration["OpenWeatherMap:ApiKey"]!;
        }
        public async Task<WeatherResponse> GetWeatherResponseAsync(string cityName)
        {

            var baseUrl = _configuration["OpenWeatherMap:WeatherBaseUrl"];
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync<WeatherResponse>(
                $"{baseUrl}weather?q={cityName}&appid={_apiKey}&units=metric");
            return response!;
        }
        public async Task<AirQualityResponse> GetAirQualityResponseAsync(double lat, double lon)
        {
            var baseUrl = _configuration["OpenWeatherMap:AirQualityBaseUrl"];
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync<AirQualityResponse>(
                $"{baseUrl}air_pollution?lat={lat}&lon={lon}&appid={_apiKey}");
            return response!;
        }
    }
}
