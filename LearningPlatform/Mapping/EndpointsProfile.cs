using AutoMapper;
using LearningPlatform.DAL.Models;
using LearningPlatform.Models;

namespace LearningPlatform.Mapping;

public class EndpointsProfile : Profile
{
    public EndpointsProfile()
    {
        CreateMap<Category, CategoryDTO>()
            .ReverseMap();
            
        CreateMap<CategoryItem, CategoryItemDTO>()
            .ReverseMap();

        CreateMap<Content, ContentDTO>()
            .ReverseMap();

        CreateMap<MediaType, MediaTypeDTO>()
            .ReverseMap();

        CreateMap<Category, CategoryViewModelDTO>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
            .ReverseMap()
            .ForMember(dest => dest.CategoryItems, opt => opt.Ignore())
            .ForMember(dest => dest.UserCategories, opt => opt.Ignore());

        CreateMap<CategoryItem, CategoryItemViewModelDTO>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.TimeItemReleased, opt => opt.MapFrom(src => src.TimeItemReleased))
            .ReverseMap()
            .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
            .ForMember(dest => dest.MediaTypeId, opt => opt.Ignore());

        CreateMap<Content, ContentViewModelDTO>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.VideoLink, opt => opt.MapFrom(src => src.VideoLink))
            .ReverseMap()
            .ForMember(dest => dest.CatItemId, opt => opt.Ignore())
            .ForMember(dest => dest.CategoryItem, opt => opt.Ignore());

        CreateMap<MediaType, MediaTypeViewModelDTO>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
            .ReverseMap()
            .ForMember(dest => dest.CategoryItems, opt => opt.Ignore());

        CreateMap<ApplicationUser, UserDTO>()
            .ReverseMap()
            .ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore())
            .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
            .ForMember(dest => dest.EmailConfirmed, opt => opt.Ignore())
            .ForMember(dest => dest.LockoutEnabled, opt => opt.Ignore())
            .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())
            .ForMember(dest => dest.NormalizedEmail, opt => opt.Ignore())
            .ForMember(dest => dest.NormalizedUserName, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
            .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
            .ForMember(dest => dest.TwoFactorEnabled, opt => opt.Ignore());
    }
}
