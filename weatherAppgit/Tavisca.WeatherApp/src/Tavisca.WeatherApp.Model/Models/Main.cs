using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.WeatherApp.Model.Models
{
    public class Main
    {
        public double Temp { get; set; }
        public Decimal Pressure { get; set; }
        public Decimal Humidity { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
    }
}
