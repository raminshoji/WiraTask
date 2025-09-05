using Application.Weathers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IOpenWeatherApiClient
    {
        Task<WeatherResponse> GetWeatherResponseAsync(string cityName);
        Task<AirQualityResponse> GetAirQualityResponseAsync(double lat, double lon);
    }

}
