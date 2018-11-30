using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.WeatherApp.Model.Models;
using Tavisca.WeatherApp.OpenWeatherAdapter.Model;
using model = Tavisca.WeatherApp.Model.Models;

namespace Tavisca.WeatherApp.OpenWeatherAdapter
{
    public static class WeatherReportResponseTranslator
    {
        public static WeatherReportResponseModel ToModel(this OpenWeatherResponse responseObj)
        {
            return new WeatherReportResponseModel
            {
                Id = responseObj.id,
                Name = responseObj.name,
                Coordinates = TranslateToGeoCode(responseObj.coord.lat.ToString(), responseObj.coord.lon.ToString()),
                Weather = TranslateToWeather(responseObj.weather[0].main, responseObj.weather[0].description),
                Main = TranslateToMain(responseObj.main.temp, responseObj.main.pressure, responseObj.main.humidity, responseObj.main.temp_min, responseObj.main.temp_max),
                Wind = TranslateToWind(responseObj.wind.speed, responseObj.wind.deg),
                AdditionalInfo = TranslateToAdditionalInfo(responseObj.sys.country, responseObj.sys.sunrise.ToString(), responseObj.sys.sunset.ToString(), Convert.ToDecimal(responseObj.sys.message), responseObj.sys.type),
            };
        }
        public static model.GeoCode TranslateToGeoCode(string Lat, string Lon)
        {
            model.GeoCode points = new model.GeoCode();
            points.Latitude = Lat;
            points.Longitude = Lon;
            return points;
        }
        public static List<model.Weather> TranslateToWeather(string type, string desc)
        {
            model.Weather data = new model.Weather();
            List<model.Weather> weather = new List<model.Weather>();
            data.Description = desc;
            data.Type = type;
            weather.Add(data);
            return weather;
        }
        public static model.Main TranslateToMain(double temp, Decimal pressure, Decimal humidity, double MinTemperature, double MaxTemperature)
        {
            model.Main main = new model.Main();
            main.Temp = temp;
            main.Pressure = pressure;
            main.Humidity = humidity;
            main.MinTemperature = MinTemperature;
            main.MaxTemperature = MaxTemperature;
            return main;
        }
        public static model.Wind TranslateToWind(double speed, decimal degree)
        {
            model.Wind wind = new model.Wind();
            wind.Speed = speed;
            wind.Degree = degree;
            return wind;
        }
        public static model.AdditionalInfo TranslateToAdditionalInfo(string countryCode, string sunrise, string sunset, decimal cloudiness, int visibility)
        {
            model.AdditionalInfo additionalInfo = new model.AdditionalInfo();
            additionalInfo.CountryCode = countryCode;
            additionalInfo.Sunrise = sunrise;
            additionalInfo.Sunset = sunset;
            additionalInfo.Cloudiness = cloudiness;
            additionalInfo.Visibility = visibility;
            return additionalInfo;
        }
    }
}
