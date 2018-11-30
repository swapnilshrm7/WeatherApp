using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tavisca.WeatherApp.Services;
using Tavisca.WeatherApp.Services.DataContracts;

namespace Tavisca.WeatherApp.Web.Controllers
{
    [Route("api/weather_report")]
    [ApiController]
    public class WeatherAppController : ControllerBase
    {
        private readonly IWeatherAppService weatherAppService;

        public WeatherAppController()
        {
            weatherAppService = new WeatherAppService();
        }

        [HttpPost]
        [Route("get_by_city_name")]
        public IActionResult GetReportByCityName([FromBody] WeatherReportByCityNameRequest request)
        {
            var response = weatherAppService.GetReportByCityName(request);

            return Ok(response);
        }
        [HttpPost]
        [Route("get_by_city_id")]
        public IActionResult GetReportByCityId([FromBody] WeatherReportByCityIdRequest request)
        {
            var response = weatherAppService.GetReportByCityId(request);

            return Ok(response);
        }
        [HttpPost]
        [Route("get_by_zip_code")]
        public IActionResult GetReportByZipCode([FromBody] WeatherReportByZipCodeRequest request)
        {
            var response = weatherAppService.GetReportByZipCode(request);

            return Ok(response);
        }
        [HttpPost]
        [Route("get_by_geo_code")]
        public IActionResult GetReportByGeoCode([FromBody] WeatherReportByGeoCodeRequest request)
        {
            var response = weatherAppService.GetReportByGeoCode(request);

            return Ok(response);
        }
    }
}
