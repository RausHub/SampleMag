using SampleMag.Web.Infrastructure.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMag.Web.Models
{    
    public class SampleViewModel : IValidatableObject
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Genre { get; set; }
        public int GenreId { get; set; }
        public string Producer { get; set; }
        public DateTime PublishDate { get; set; }
        public int Upvote { get; set; }
        public string TrailerURI { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new SampleViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}