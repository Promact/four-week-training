using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynAwaitWeatherForcasting
{
    public class WeatherData
    {
        public MainData? Main { get; set; }
        public WeatherDescription[]? Weather { get; set; }
    }
}
