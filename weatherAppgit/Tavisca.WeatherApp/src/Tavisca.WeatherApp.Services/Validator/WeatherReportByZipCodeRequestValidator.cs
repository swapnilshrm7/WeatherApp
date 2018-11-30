using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Platform.Common.Models;
using Tavisca.WeatherApp.Services.DataContracts;

namespace Tavisca.WeatherApp.Services.Validator
{
    class WeatherReportByZipCodeRequestValidator : AbstractValidator<WeatherReportByZipCodeRequest>
    {
        public WeatherReportByZipCodeRequestValidator()
        {
            RuleFor(x => x.ZipCode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MandatoryFieldMissing)
                .WithMessage(ErrorMessages.MandatoryFieldMissing("ZipCode"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidValueForInputType)
                .WithMessage(ErrorMessages.InvalidValueForInputType("ZipCode", "zipCode", "string"));
        }
    }
}
