using System;
using System.Collections.Generic;
using System.Text;

namespace Sytner.Utilities.Domain
{
    public class ForecastData : BaseEntity<int>
    {
        public int WeatherStationId { get; set; }
        public decimal Temperature { get; set; }
        public DateTime Date { get; set; }
    }
}
