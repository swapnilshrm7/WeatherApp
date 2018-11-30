using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.WeatherApp.Model.Models;
using service = Tavisca.WeatherApp.Service;

namespace Tavisca.WeatherApp.Services.Translator
{
    public static class WeatherReportResponseTranslator
    {
        public static WeatherReportResponse ToDataContractCity(this WeatherReportResponseModel responseModel)
        {
            return new WeatherReportResponse
            {
                Id = responseModel.Id,
                Name = responseModel.Name,
                Coordinates = TranslateToGeoCode(responseModel.Coordinates.Latitude, responseModel.Coordinates.Longitude),
                Weather = TranslateToWeather(responseModel.Weather[0].Type, responseModel.Weather[0].Description),
                Main = TranslateToMain(responseModel.Main.Temp, responseModel.Main.Pressure, responseModel.Main.Humidity, responseModel.Main.MinTemperature, responseModel.Main.MaxTemperature),
                Wind = TranslateToWind(responseModel.Wind.Speed,responseModel.Wind.Degree),
                TimeSpan = responseModel.TimeSpan,
                AdditionalInfo = TranslateToAdditionalInfo(responseModel.AdditionalInfo.CountryCode,responseModel.AdditionalInfo.Sunrise,responseModel.AdditionalInfo.Sunset,responseModel.AdditionalInfo.Cloudiness,responseModel.AdditionalInfo.Visibility),
            };
        }
        public static WeatherReportResponse ToDataContract(this WeatherReportResponseModel responseModel)
        {
            return new WeatherReportResponse
            {
                Id = responseModel.Id,
                Name = responseModel.Name,
                Coordinates = TranslateToGeoCode(responseModel.Coordinates.Latitude, responseModel.Coordinates.Longitude),
                Weather = TranslateToWeather(responseModel.Weather[0].Type, responseModel.Weather[0].Description),
                Main = TranslateToMain(responseModel.Main.Temp, responseModel.Main.Pressure, responseModel.Main.Humidity, responseModel.Main.MinTemperature, responseModel.Main.MaxTemperature),
                Wind = TranslateToWind(responseModel.Wind.Speed, responseModel.Wind.Degree),
                AdditionalInfo = TranslateToAdditionalInfo(responseModel.AdditionalInfo.CountryCode, responseModel.AdditionalInfo.Sunrise, responseModel.AdditionalInfo.Sunset, responseModel.AdditionalInfo.Cloudiness, responseModel.AdditionalInfo.Visibility),
            };
        }
        public static service.GeoCode TranslateToGeoCode(string Lat,string Lon)
        {
            service.GeoCode points = new service.GeoCode();
            points.Latitude = Lat;
            points.Longitude = Lon;
            return points;
        }
        public static List<service.Weather> TranslateToWeather(string type,string desc)
        {
            service.Weather data = new service.Weather();
            List<service.Weather> weather = new List<service.Weather>();
            data.Description = desc;
            data.Type = type;
            weather.Add(data);
            return weather;
        }
        public static service.Main TranslateToMain(double temp, Decimal pressure, Decimal humidity,double MinTemperature, double MaxTemperature)
        {
            service.Main main = new service.Main();
            main.Temp = temp;
            main.Pressure = pressure;
            main.Humidity = humidity;
            main.MinTemperature = MinTemperature;
            main.MaxTemperature = MaxTemperature;
            return main;
        }
        public static service.Wind TranslateToWind(double speed,decimal degree)
        {
            service.Wind wind = new service.Wind();
            wind.Speed = speed;
            wind.Degree = degree;
            return wind;
        }
        public static service.AdditionalInfo TranslateToAdditionalInfo(string countryCode, string sunrise, string sunset, decimal cloudiness, int visibility)
        {
            service.AdditionalInfo additionalInfo = new service.AdditionalInfo();
            additionalInfo.CountryCode = countryCode;
            additionalInfo.Sunrise = sunrise;
            additionalInfo.Sunset = sunset;
            additionalInfo.Cloudiness = cloudiness;
            additionalInfo.Visibility = visibility;
            return additionalInfo;
        }
    }
}