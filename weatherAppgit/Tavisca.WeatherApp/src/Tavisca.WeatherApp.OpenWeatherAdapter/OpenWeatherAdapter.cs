using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Platform.Common.Models;
using Tavisca.WeatherApp.Model.Interfaces;
using Tavisca.WeatherApp.Model.Models;
using Tavisca.WeatherApp.OpenWeatherAdapter.Model;

namespace Tavisca.WeatherApp.OpenWeatherAdapter
{
    public class OpenWeatherAdapter : WeatherReportBase, IWeatherAdapter
    {
        private readonly OpenWeatherAppSvcSettings _settings;

        public OpenWeatherAdapter(OpenWeatherAppSvcSettings settings)
        {
            _settings = settings;
        }

        public WeatherReportResponseModel GetWeatherReport(WeatherReportRequestModel requestModel)
        {
            if (_settings == null)
                throw new BaseApplicationException(ErrorMessages.MandatoryFieldMissing("OpenWeatherSvcSettings"), FaultCodes.MandatoryFieldMissing);

            var url = GenerateUrl(requestModel);

            var responseObj = Execute<OpenWeatherResponse>(url);

            return responseObj.ToModel();
        }

        private string GenerateUrl(WeatherReportRequestModel requestModel)
        {
            if (requestModel.CityName != null)
                return $"{_settings.Url}?q={requestModel.CityName}&APPID={_settings.ApiKey}";
            else if (requestModel.GeoCode != null)
                return $"{_settings.Url}?lat={requestModel.GeoCode.Latitude}&lon={requestModel.GeoCode.Longitude}&APPID={_settings.ApiKey}";
            else if (requestModel.ZipCode != null)
                return $"{_settings.Url}?zip={requestModel.ZipCode}&APPID={_settings.ApiKey}";
            else if (requestModel.CityId != null)
                return $"{_settings.Url}?id={requestModel.CityId}&APPID={_settings.ApiKey}";
            else
                return null;
        }
    }
}
