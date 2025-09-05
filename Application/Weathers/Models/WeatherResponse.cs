using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Weathers.Models;

namespace Application.Weathers.Models
{
    public class WeatherResponse
    {
        public Coord Coord { get; set; }
        public MainData Main { get; set; }
        public Wind Wind { get; set; }
    }

    public class Coord
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class MainData
    {
        public double Temp { get; set; }
        public int Humidity { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
    }
}
