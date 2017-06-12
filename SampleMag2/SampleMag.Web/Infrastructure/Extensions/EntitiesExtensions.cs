using SampleMag.Entities;
using SampleMag.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMag.Web.Infrastructure.Extensions
{
    public static class EntitiesExtensions
    {
        public static void UpdateSample(this Sample Sample, SampleViewModel SampleVm)
        {
            Sample.Title = SampleVm.Title;
            Sample.GenreId = SampleVm.GenreId;
            Sample.Text = SampleVm.Text;
            Sample.Producer = SampleVm.Producer;
            Sample.Rating = SampleVm.Rating;
            Sample.TrailerURI = SampleVm.TrailerURI;
            Sample.PublishDate = SampleVm.PublishDate;
        }        
    }
}