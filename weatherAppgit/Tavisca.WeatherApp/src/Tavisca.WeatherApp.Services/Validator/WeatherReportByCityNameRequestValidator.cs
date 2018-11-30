using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Platform.Common.Models;
using Tavisca.WeatherApp.Services.DataContracts;

namespace Tavisca.WeatherApp.Services.Validator
{
    public class WeatherReportByCityNameRequestValidator : AbstractValidator<WeatherReportByCityNameRequest>
    {
        public WeatherReportByCityNameRequestValidator()
        {
            RuleFor(x => x.CityName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MandatoryFieldMissing)
                .WithMessage(ErrorMessages.MandatoryFieldMissing("CityName"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidValueForInputType)
                .WithMessage(ErrorMessages.InvalidValueForInputType("CityName", "cityName", "string"));
        }
    }
}
