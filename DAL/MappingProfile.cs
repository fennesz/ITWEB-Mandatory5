using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_Mandatory5.DAL
{
    public class A
    {
        public int anInt;
        public float aFloat;
    }

    public class B
    {
        public long aLong;
        public double aDouble;
    }


    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<A, B>()
                .ForMember((dest) => dest.aLong, opts => opts.MapFrom(src => (long)src.anInt))
                .ForMember((dest) => dest.aDouble, opts => opts.MapFrom(src => (double)src.aFloat));

            CreateMap<B, A>()
                .ForMember((dest) => dest.anInt, opts => opts.MapFrom(src => (int)src.aLong))
                .ForMember((dest) => dest.aFloat, opts => opts.MapFrom(src => (double)src.aDouble));
        }
    }
}
