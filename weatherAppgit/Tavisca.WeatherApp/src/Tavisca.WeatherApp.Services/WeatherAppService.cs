using Tavisca.WeatherApp.Model.Interfaces;
using Tavisca.WeatherApp.Services.DataContracts;
using Tavisca.WeatherApp.Services.Translator;
using Tavisca.WeatherApp.Services.Validator;

namespace Tavisca.WeatherApp.Services
{
    public class WeatherAppService : IWeatherAppService
    {
        private readonly IWeatherApp weatherApp;
        public WeatherAppService()
        {
            weatherApp = new Core.WeatherApp();
        }

        public object GetReportByCityName(WeatherReportByCityNameRequest request)
        {
            Validation.EnsureValid(request, new WeatherReportByCityNameRequestValidator());

            var requestModel = request.ToModel();

            //Here we will call the core service
            var responseModel = weatherApp.GetWeatherReport(requestModel);

            //Convert back the model to data contract

            return responseModel.ToDataContractCity();
        }
            public object GetReportByCityId(WeatherReportByCityIdRequest request)
            {
                Validation.EnsureValid(request, new WeatherReportByCityIdRequestValidator());

                var requestModel = request.ToModel();

                //Here we will call the core service
                var responseModel = weatherApp.GetWeatherReport(requestModel);

            //Convert back the model to data contract


            return responseModel.ToDataContract();
        }
            public object GetReportByZipCode(WeatherReportByZipCodeRequest request)
            {
                Validation.EnsureValid(request, new WeatherReportByZipCodeRequestValidator());

                var requestModel = request.ToModel();

                //Here we will call the core service
                var responseModel = weatherApp.GetWeatherReport(requestModel);

            //Convert back the model to data contract


            return responseModel.ToDataContract();
        }
            public object GetReportByGeoCode(WeatherReportByGeoCodeRequest request)
            {
                Validation.EnsureValid(request, new WeatherReportByGeoCodeRequestValidator());

                var requestModel = request.ToModel();

                //Here we will call the core service
                var responseModel = weatherApp.GetWeatherReport(requestModel);

            //Convert back the model to data contract


            return responseModel.ToDataContract();
        }
    }
}
