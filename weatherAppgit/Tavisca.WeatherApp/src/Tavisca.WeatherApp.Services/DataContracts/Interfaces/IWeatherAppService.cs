using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.WeatherApp.Services.DataContracts;

namespace Tavisca.WeatherApp.Services
{
    public interface IWeatherAppService
    {
        object GetReportByCityName(WeatherReportByCityNameRequest request);
        object GetReportByCityId(WeatherReportByCityIdRequest request);
        object GetReportByZipCode(WeatherReportByZipCodeRequest request);
        object GetReportByGeoCode(WeatherReportByGeoCodeRequest request);
    }
}
