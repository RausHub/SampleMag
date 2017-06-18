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
            
            RuleFor(Sample => Sample.UserId).GreaterThan(0).When(Sample => string.IsNullOrEmpty( Sample.User ))
                .WithMessage("Must have an owner");
            
            RuleFor(Sample => Sample.Text).NotEmpty()
                .WithMessage("Select a text");

            RuleFor(Sample => Sample.Upvote).GreaterThanOrEqualTo(0)
                .WithMessage("Upvote must be higher than 0");

            RuleFor(Sample => Sample.TrailerURI).NotEmpty().Must(ValidTrailerURI)
                .WithMessage("Only Youtube Trailers are supported");
        }

        private bool ValidTrailerURI(string trailerURI)
        {
            return (!string.IsNullOrEmpty(trailerURI) && trailerURI.ToLower().StartsWith("https://www.youtube.com/watch?"));
        }
    }
}