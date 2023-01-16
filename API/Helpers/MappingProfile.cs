using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using core.Entities;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(d=>d.productBrand,p=>p.MapFrom(x=>x.productBrand.Name))
            .ForMember(d=>d.productType,y=>y.MapFrom(x=>x.productType.Name))
            .ForMember(d=>d.PictureUrl,x=>x.MapFrom<ProductUrlResolver>());
        }
    }
}