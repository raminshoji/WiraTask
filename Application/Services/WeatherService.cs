using Application.Common.Interfaces;
using Application.ExternalServices;
using Application.Weathers.Models;
using AutoMapper;

namespace Application.Services
{
    public class WeatherService(IOpenWeatherApiClient client, IMapper mapper) : IWeatherService
    {
        private readonly IOpenWeatherApiClient _client = client;
        private readonly IMapper _mapper = mapper;

        private async Task<AirQualityResponse> GetAirQualityAsync(double lat, double lon)
        {
            try
            {
                return await _client.GetAirQualityResponseAsync(lat, lon);
            }
            catch (Exception)
            {
                throw new Exception("Error getting Air Quality");
            }
        }

        public async Task<CityEnvironmentResponse> GetCityEnvironmentDataAsync(string cityName)
        {
            try
            {
                var weatherData = await GetWeatherAsync(cityName);
                if (weatherData == null) return null;
                var airQualityData = await GetAirQualityAsync(weatherData.Coord.Lat, weatherData.Coord.Lon);
                var result = _mapper.Map<CityEnvironmentResponse>(weatherData);
                if (airQualityData != null)
                    result = _mapper.Map(airQualityData, result);
                result.City = cityName;
                return result; ;
            }
            catch (Exception)
            {
                throw new Exception("Error getting environment data for city");
            }
        }

        private async Task<WeatherResponse> GetWeatherAsync(string cityName)
        {
            try
            {
                return await _client.GetWeatherResponseAsync(cityName);
            }
            catch (Exception)
            {

                throw new Exception("Error getting weather data");
            }
        }
    }
}
