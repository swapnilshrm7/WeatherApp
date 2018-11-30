using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.WeatherApp.Model.Models
{
    public class AdditionalInfo
    {
        public string CountryCode { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public decimal Cloudiness { get; set; }
        public int Visibility { get; set; }
    }
}
