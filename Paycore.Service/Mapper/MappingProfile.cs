using AutoMapper;
using Paycore.Data.Model.Concrete;
using Paycore.Dto.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paycore.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Map creation process using Automapper
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<OfferDto, Offer>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
