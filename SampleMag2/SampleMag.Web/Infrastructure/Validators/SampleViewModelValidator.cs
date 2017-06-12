using FluentValidation;
using SampleMag.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMag.Web.Infrastructure.Validators
{
    public class SampleViewModelValidator : AbstractValidator<SampleViewModel>
    {
        public SampleViewModelValidator()
        {
            RuleFor(Sample => Sample.GenreId).GreaterThan(0)
                .WithMessage("Select a Genre");

            RuleFor(Sample => Sample.Producer).NotEmpty().Length(1, 50)
                .WithMessage("Select a producer");

            RuleFor(Sample => Sample.Text).NotEmpty()
                .WithMessage("Select a description");

            RuleFor(Sample => Sample.Rating).InclusiveBetween((byte)0, (byte)5)
                .WithMessage("Rating must be less than or equal to 5");

            RuleFor(Sample => Sample.TrailerURI).NotEmpty().Must(ValidTrailerURI)
                .WithMessage("Only Youtube Trailers are supported");
        }

        private bool ValidTrailerURI(string trailerURI)
        {
            return (!string.IsNullOrEmpty(trailerURI) && trailerURI.ToLower().StartsWith("https://www.youtube.com/watch?"));
        }
    }
}