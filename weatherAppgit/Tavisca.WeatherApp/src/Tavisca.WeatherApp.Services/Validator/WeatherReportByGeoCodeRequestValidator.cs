using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Validators;
using Tavisca.Platform.Common.Models;
using Tavisca.WeatherApp.Model.Models;
using Tavisca.WeatherApp.Services.DataContracts;

namespace Tavisca.WeatherApp.Services.Validator
{
    internal class WeatherReportByGeoCodeRequestValidator : AbstractValidator<WeatherReportByGeoCodeRequest>
    {
        public WeatherReportByGeoCodeRequestValidator()
        {
            RuleFor(x => x.GeoCode.Latitude)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MandatoryFieldMissing)
                .WithMessage(ErrorMessages.MandatoryFieldMissing("Latitude"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidValueForInputType)
                .WithMessage(ErrorMessages.InvalidValueForInputType("GeoCode", "latitude", "string"));
            ;

            RuleFor(x => x.GeoCode.Longitude)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull()
               .WithErrorCode(FaultCodes.MandatoryFieldMissing)
               .WithMessage(ErrorMessages.MandatoryFieldMissing("Longitude"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidValueForInputType)
                .WithMessage(ErrorMessages.InvalidValueForInputType("GeoCode", "longitude", "string")); ;
        }
    }
}
