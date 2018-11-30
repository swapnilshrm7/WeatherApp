using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.WeatherApp.Model.Interfaces;
using Adapter = Tavisca.WeatherApp.OpenWeatherAdapter;

namespace Tavisca.WeatherApp.Plugins.Factory
{
    public static class WeatherAdapterFactory
    {
        public static IWeatherAdapter GetInstance(string stratergy)
        {
            switch (stratergy.ToLower().Trim())
            {
                case "openweather":
                    var appSettings = new Adapter.OpenWeatherAppSvcSettings
                    {
                        Url = "http://api.openweathermap.org/data/2.5/weather",
                        ApiKey = "445e770e8989d0f18a96123c160d3fe8"
                    };

                    return new Adapter.OpenWeatherAdapter(appSettings);

                case "mock":
                default:
                    throw new NotImplementedException("Adapter for this instance is not implemented");
            }
        }
    }
}