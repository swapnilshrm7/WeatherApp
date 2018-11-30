using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.WeatherApp.Model.Models;

namespace Tavisca.WeatherApp.Services.DataContracts
{
    public class WeatherReportByGeoCodeRequest
    {
        public GeoCode GeoCode { get; set; }
    }
}
