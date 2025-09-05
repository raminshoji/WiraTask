using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Weathers.Models;

namespace Application.Common.MappingProfiles
{
    public class AirQualityMappingProfile : Profile
    {
        public AirQualityMappingProfile()
        {
            CreateMap<AirQualityResponse, CityEnvironmentResponse>()
                .ForMember(dest => dest.AirQualityIndex, opt => opt.MapFrom(src => src.List[0].Main.Aqi))
                .ForMember(dest => dest.MajorPollutants, opt => opt.MapFrom(src => new Pollutants
                {
                    PM2_5 = src.List[0].Components.Pm2_5,
                    PM10 = src.List[0].Components.Pm10,
                    CarbonMonoxide = src.List[0].Components.Co,
                    NitrogenMonoxide = src.List[0].Components.No,
                    NitrogenDioxide = src.List[0].Components.No2,
                    Ozone = src.List[0].Components.O3,
                    SulphurDioxide = src.List[0].Components.So2,
                    Ammonia = src.List[0].Components.Nh3
                }));
        }
    }

}
