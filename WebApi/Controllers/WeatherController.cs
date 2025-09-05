using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Weathers.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherservice;

        public WeatherController(IWeatherService weatherservice)
        {
            _weatherservice = weatherservice;
        }

        [HttpGet("{cityName}")]
        public async Task<ActionResult<CityEnvironmentResponse>> GetCityData(string cityName)
        {
            var result = await _weatherservice.GetCityEnvironmentDataAsync(cityName);
            return Ok(result);
        }
    }
}
