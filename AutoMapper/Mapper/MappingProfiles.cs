using AutoMapper;
using AutoMapper_FluentValidation.Dto;
using AutoMapper_FluentValidation.Entities;

namespace AutoMapper_FluentValidation.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
