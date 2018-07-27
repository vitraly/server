using System;

namespace API.Models
{
    public class WeatherModel
    {
        public string Weather { get; set; }

        public double Temperature { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
