using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Weathers.Models;

namespace Application.Common.MappingProfiles
{
    public class WeatherMappingProfile : Profile
    {
        public WeatherMappingProfile()
        {
            CreateMap<WeatherResponse, CityEnvironmentResponse>()           
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.Main.Temp))
                .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Main.Humidity))
                .ForMember(dest => dest.WindSpeed, opt => opt.MapFrom(src => src.Wind.Speed))
                .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => new Coordinates
                {
                    Latitude = src.Coord.Lat,
                    Longitude = src.Coord.Lon
                }));
        }
    }
}
