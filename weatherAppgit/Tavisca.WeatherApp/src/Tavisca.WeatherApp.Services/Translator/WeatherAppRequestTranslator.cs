using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.WeatherApp.Model.Models;
using Tavisca.WeatherApp.Services.DataContracts;

namespace Tavisca.WeatherApp.Services
{
    public static class WeatherAppRequestTranslator 
    {
        public static WeatherReportRequestModel ToModel(this WeatherReportByCityNameRequest request)
        {
            return new WeatherReportRequestModel
            {
                CityName = request.CityName
            };
        }

        public static WeatherReportRequestModel ToModel(this WeatherReportByCityIdRequest request)
        {
            return new WeatherReportRequestModel
            {
                CityId = request.CityId
            };
        }
        public static WeatherReportRequestModel ToModel(this WeatherReportByGeoCodeRequest request)
        {
            return new WeatherReportRequestModel
            {
                GeoCode = new GeoCode
                {
                    Latitude = request.GeoCode?.Latitude,
                    Longitude = request.GeoCode?.Longitude
                }
            };
        }

        public static WeatherReportRequestModel ToModel(this WeatherReportByZipCodeRequest request)
        {
            return new WeatherReportRequestModel
            {
                ZipCode = request.ZipCode
            };
        }
    }
}
