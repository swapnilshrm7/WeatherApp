using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Platform.Common.Models;
using Tavisca.WeatherApp.Model.Models;
using Tavisca.WeatherApp.Services.DataContracts;

namespace Tavisca.WeatherApp.Services.Validator
{
    class WeatherReportByCityIdRequestValidator : AbstractValidator<WeatherReportByCityIdRequest>
    {
        public WeatherReportByCityIdRequestValidator()
        {
            RuleFor(x => x.CityId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MandatoryFieldMissing)
                .WithMessage(ErrorMessages.MandatoryFieldMissing("CityName"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidValueForInputType)
                .WithMessage(ErrorMessages.InvalidValueForInputType("CityId", "cityId", "string"));
        }
    }
}
