using AutoMapper;
using ITWEB_Mandatory5.Models;
using ITWEB_Mandatory5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_Mandatory5.DAL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects

            // Removing the junction class
            CreateMap<Category, CategoryVM>()
                .ForMember(dest => dest.ComponentTypes, opts => opts.MapFrom(
                    src => src.ComponentTypeCategory.Select(
                        CTC => new ComponentTypeVM
                        {
                            AdminComment = CTC.ComponentType.AdminComment,
                            ComponentInfo = CTC.ComponentType.ComponentInfo,
                            ComponentName = CTC.ComponentType.ComponentName,
                            Datasheet = CTC.ComponentType.Datasheet,
                            Id = CTC.ComponentType.Id,
                            Image = CTC.ComponentType.Image,
                            ImageUrl = CTC.ComponentType.ImageUrl,
                            Location = CTC.ComponentType.Location,
                            Manufacturer = CTC.ComponentType.Manufacturer,
                            Status = CTC.ComponentType.Status,
                            WikiLink = CTC.ComponentType.WikiLink
                        })
                    )
                );

            CreateMap<CategoryVM, Category>()
                .ForMember(dest => dest.ComponentTypeCategory, opts => opts.MapFrom(
                    src => src.ComponentTypes.Select(
                        ComponentType => new ComponentTypeCategory { CategoryId = src.Id, ComponentTypeId = ComponentType.Id })
                    )
                );

            CreateMap<Component, ComponentVM>()
                .ForMember(dest => dest.ComponentType, opts => opts.MapFrom(src => src.ComponentType));

            CreateMap<ComponentVM, Component>()
                .ForMember(dest => dest.ComponentType, opts => opts.MapFrom(src => src.ComponentType));

            CreateMap<ComponentType, ComponentTypeVM>()
                .ForMember(dest => dest.Categories, opts => opts.MapFrom(
                    src => src.ComponentTypeCategory.Select(
                        CTC => new CategoryVM
                        {
                            Id = CTC.Category.Id,
                            Name = CTC.Category.Name
                        })
                    )
                );

            CreateMap<ComponentTypeCreateVM, ComponentType>()
                .ForMember(dest => dest.ComponentTypeCategory, opts => opts.MapFrom(
                    src => src.CategoryIDs.Select(
                        id => new ComponentTypeCategory { CategoryId = id, ComponentTypeId = src.Id })
                    )
                );

            CreateMap<ComponentTypeVM, ComponentType>()
                .ForMember(dest => dest.ComponentTypeCategory, opts => opts.MapFrom(
                    src => src.Categories.Select(
                        Category => new ComponentTypeCategory { CategoryId = Category.Id, ComponentTypeId = src.Id })
                    )
                );

            CreateMap<ComponentType, ComponentTypeCreateVM>()
                .ForMember(dest => dest.CategoryIDs, 
                    opts => opts.MapFrom(
                        src => src.ComponentTypeCategory.Select(Category => Category.CategoryId)
                    )
                )
                .ForMember(dest => dest.Categories, opts => opts.MapFrom(
                    src => src.ComponentTypeCategory.Select(
                        CTC => new CategoryVM
                        {
                            Id = CTC.Category.Id,
                            Name = CTC.Category.Name
                        })
                    )
                );


            /*
            CreateMap<ComponentTypeCategory, Category>()
                .ForMember(dest => dest, opts => opts.MapFrom(src => src.Category));
            */
        }
    }
}
