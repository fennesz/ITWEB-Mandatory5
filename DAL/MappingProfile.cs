using AutoMapper;
using ITWEB_Mandatory5.Models;
using ITWEB_Mandatory5.ViewModels;
using ITWEB_Mandatory5.ViewModels.CategoryController;
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

            // Category Details
            CreateMap<Category, CategoryDetailsViewmodel>()
                .ForMember(dest => dest.ComponentTypes, opts => opts.MapFrom(
                    src => src.ComponentTypeCategory.Select(
                        CTC => CTC.ComponentType)
                    )
                );

            // Category Index
            CreateMap<IEnumerable<Category>, CategoryIndexViewmodel>()
                .ForMember(dest => dest.Categories, opts => opts.MapFrom(src => src));

            // Removing the junction class
            CreateMap<Category, CategoryVM>()
                .ForMember(dest => dest.ComponentTypes, opts => opts.MapFrom(
                    src => src.ComponentTypeCategory.Select(
                        CTC => CTC.ComponentType)
                    )
                );

            CreateMap<CategoryVM, Category>()
                .ForMember(dest => dest.ComponentTypeCategory, opts => opts.MapFrom(
                    src => src.ComponentTypes.Select(
                        ComponentType => new ComponentTypeCategory { CategoryId = src.Id, ComponentTypeId = ComponentType.Id })
                    )
                );

            CreateMap<Component, ComponentVM>();

            CreateMap<ComponentType, ComponentTypeVM>()
                .ForMember(dest => dest.Categories, opts => opts.MapFrom(
                    src => src.ComponentTypeCategory.Select(
                        CTC => CTC.Category)
                    )
                );

            CreateMap<ComponentTypeVM, ComponentType>()
                .ForMember(dest => dest.ComponentTypeCategory, opts => opts.MapFrom(
                    src => src.Categories.Select(
                        Category => new ComponentTypeCategory {CategoryId = Category.Id, ComponentTypeId = src.Id })
                    )
                );


            /*
            CreateMap<ComponentTypeCategory, Category>()
                .ForMember(dest => dest, opts => opts.MapFrom(src => src.Category));
            */
        }
    }
}
