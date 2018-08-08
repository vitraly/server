using System;

namespace API.Models
{
    public class WeatherModel
    {
        public int PositionId { get; } = 0;

        public string Weather { get; set; }

        public double Temperature { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
