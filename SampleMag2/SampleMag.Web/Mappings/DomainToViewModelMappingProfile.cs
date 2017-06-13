using AutoMapper;
using SampleMag.Entities;
using SampleMag.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMag.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Sample, SampleViewModel>()
                .ForMember(vm => vm.Upvote, map => map.MapFrom(m => m.UpVoteCount))
                .ForMember(vm => vm.Genre, map => map.MapFrom(m => m.Genre.Name))
                .ForMember(vm => vm.GenreId, map => map.MapFrom(m => m.Genre.ID));

            Mapper.CreateMap<Genre, GenreViewModel>()
                .ForMember(vm => vm.NumberOfSamples, map => map.MapFrom(g => g.Samples.Count()));
        }
    }
}