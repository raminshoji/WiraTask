using Application.Common.Interfaces;
using Application.Services;
using Application.Weathers.Models;
using AutoMapper;
using Moq;

namespace WirTask.Tests
{
    public class WeatherServiceTests
    {
        private readonly Mock<IOpenWeatherApiClient> _clientMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly WeatherService _weatherService;
        public WeatherServiceTests()
        {
            _clientMock = new Mock<IOpenWeatherApiClient>();
            _mapperMock = new Mock<IMapper>();
            _weatherService = new WeatherService(_clientMock.Object, _mapperMock.Object);
        }
        [Fact]
        public async Task GetCityEnvironmentDataAsync_ShouldReturnMappedResponse()
        {
            // Arrange
            var cityName = "Tehran";

            var weatherResponse = new WeatherResponse
            {
                Coord = new Coord { Lat = 35.6892, Lon = 51.3890 },
                Main = new MainData { Temp = 25, Humidity = 40 },
                Wind = new Wind { Speed = 5 }
            };
            var airQualityResponse = new AirQualityResponse
            {
                List = new List<AirQualityData>
              {
                new AirQualityData
                {
                    Main = new MainInfo { Aqi = 2 },
                    Components = new Components
                    {
                        Pm2_5 = 10,
                        Pm10 = 20,
                        Co = 0.5,
                        No = 0.1,
                        No2 = 0.2,
                        O3 = 0.3,
                        So2 = 0.4,
                        Nh3 = 0.05
                    }
                }
              }
            };
            var mappedWeather = new CityEnvironmentResponse
            {
                Temperature = 25,
                Humidity = 40,
                WindSpeed = 5,
                Coordinates = new Coordinates { Latitude = 35.6892, Longitude = 51.3890 }
            };
            var mappedFull = mappedWeather;
            mappedFull.AirQualityIndex = 2;
            mappedFull.MajorPollutants = new Pollutants
            {
                PM2_5 = 10,
                PM10 = 20,
                CarbonMonoxide = 0.5,
                NitrogenMonoxide = 0.1,
                NitrogenDioxide = 0.2,
                Ozone = 0.3,
                SulphurDioxide = 0.4,
                Ammonia = 0.05
            };
            _clientMock.Setup(c => c.GetWeatherResponseAsync(cityName))
                .ReturnsAsync(weatherResponse);

            _clientMock.Setup(c => c.GetAirQualityResponseAsync(weatherResponse.Coord.Lat, weatherResponse.Coord.Lon))
                .ReturnsAsync(airQualityResponse);

            _mapperMock.Setup(m => m.Map<CityEnvironmentResponse>(weatherResponse))
                .Returns(mappedWeather);

            _mapperMock.Setup(m => m.Map(airQualityResponse, mappedWeather))
                .Returns(mappedFull);
     
            var result = await _weatherService.GetCityEnvironmentDataAsync(cityName);
            Assert.NotNull(result);
            Assert.Equal(cityName, result.City);
            Assert.Equal(25, result.Temperature);
            Assert.Equal(40, result.Humidity);
            Assert.Equal(5, result.WindSpeed);
            Assert.Equal(2, result.AirQualityIndex);
            Assert.Equal(10, result.MajorPollutants.PM2_5);
        }
        [Fact]
        public async Task GetCityEnvironmentDataAsync_WhenApiReturnsNull_ShouldReturnNull()
        {
            var city = "UnknownCity";
            _clientMock.Setup(x => x.GetWeatherResponseAsync(city))
                       .ReturnsAsync((WeatherResponse)null);
            _clientMock.Setup(x => x.GetAirQualityResponseAsync(It.IsAny<double>(), It.IsAny<double>()))
                       .ReturnsAsync((AirQualityResponse)null);
            var result = await _weatherService.GetCityEnvironmentDataAsync(city);
            Assert.Null(result);
        }

    }
}
