using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Weathers.Models;

namespace Application.Weathers.Models
{
    public class CityEnvironmentResponse
    {
        public string City { get; set; }
        public double Temperature { get; set; } 
        public int Humidity { get; set; } 
        public double WindSpeed { get; set; } 
        public int AirQualityIndex { get; set; } 
        public Pollutants MajorPollutants { get; set; }
        public Coordinates Coordinates { get; set; }
    }

    public class Pollutants
    {
        public double PM2_5 { get; set; }
        public double PM10 { get; set; }
        public double CarbonMonoxide { get; set; }
        public double NitrogenMonoxide { get; set; }
        public double NitrogenDioxide { get; set; }
        public double Ozone { get; set; }
        public double SulphurDioxide { get; set; }
        public double Ammonia { get; set; }
    }

    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
