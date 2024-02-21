using System;
using System.Collections.Generic;
using System.Text;

namespace Sytner.Utilities.Domain
{
    public class WeatherStations : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
