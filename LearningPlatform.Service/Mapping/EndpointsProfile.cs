using AutoMapper;
using LearningPlatform.DAL.Models;
using LearningPlatform.Service.Models;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Service.Mapping;

public class EndpointsProfile : Profile
{
    public EndpointsProfile()
    {
        CreateMap<Category, CategoryDTO>()
            .ReverseMap()
            .ForMember(dest => dest.CategoryItems, opt => opt.Ignore())
            .ForMember(dest => dest.UserCategories, opt => opt.Ignore());

        CreateMap<CategoryItem, CategoryItemDTO>()
            .ReverseMap()
            .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
            .ForMember(dest => dest.MediaTypeId, opt => opt.Ignore());

        CreateMap<Content, ContentDTO>()
            .ReverseMap()
            .ForMember(dest => dest.CatItemId, opt => opt.Ignore())
            .ForMember(dest => dest.CategoryItem, opt => opt.Ignore());

        CreateMap<MediaType, MediaTypeDTO>()
            .ReverseMap()
            .ForMember(dest => dest.CategoryItems, opt => opt.Ignore());

        CreateMap<Category, CategoryViewModelDTO>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
            .ReverseMap()
            .ForMember(dest => dest.CategoryItems, opt => opt.Ignore())
            .ForMember(dest => dest.UserCategories, opt => opt.Ignore());

    }
}
