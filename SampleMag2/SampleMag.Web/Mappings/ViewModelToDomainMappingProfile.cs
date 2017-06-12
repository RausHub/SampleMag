using AutoMapper;
using SampleMag.Entities;
using SampleMag.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMag.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<SampleViewModel, Sample>()
                //.ForMember(m => m.Image, map => map.Ignore())
                .ForMember(m => m.Genre, map => map.Ignore());
        }
    }
}