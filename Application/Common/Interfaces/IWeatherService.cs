using Application.Weathers.Models;

namespace Application.Common.Interfaces
{
    public interface IWeatherService
    {
        Task<CityEnvironmentResponse> GetCityEnvironmentDataAsync(string cityName);
    }
}
