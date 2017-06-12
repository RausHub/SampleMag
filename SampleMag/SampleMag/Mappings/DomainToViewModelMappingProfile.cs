using AutoMapper;
using SampleMag.Entity;
using SampleMag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMag.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        
        protected override void Configure()
        {
            //Mapper.CreateMap<Sample, SampleViewModel>()
            //    .ForMember(vm => vm.Genre, map => map.MapFrom(m => m.Genre.Name))
            //    .ForMember(vm => vm.GenreId, map => map.MapFrom(m => m.Genre.ID))
            //    .ForMember(vm => vm.IsAvailable, map => map.MapFrom(m => m.Stocks.Any(s => s.IsAvailable)))
            //    .ForMember(vm => vm.NumberOfStocks, map => map.MapFrom(m => m.Stocks.Count))
            //    .ForMember(vm => vm.Image, map => map.MapFrom(m => string.IsNullOrEmpty(m.Image) == true ? "unknown.jpg" : m.Image));

            Mapper.CreateMap<Music_Genre, GenreViewModel>();

            //Mapper.CreateMap<Customer, CustomerViewModel>();

            //Mapper.CreateMap<Stock, StockViewModel>();

            //Mapper.CreateMap<Rental, RentalViewModel>();
        }
    }
}