using AutoMapper;
using BandAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Profiles
{
    public class BandsProfile : Profile
    {
        public BandsProfile()
        {
            CreateMap<Entities.Band, Models.BandDto>()
                .ForMember(
                    dest => dest.FoundedYearsAgo,

                    //single line implementation of string interpolation
                    opt => opt.MapFrom(src => $"{src.Founded.ToString("yyyy") + (src.Founded.GetYearsAgo()) + " years ago"}"));
                    
                    // Double line implementation of string interpolation
                    //opt => opt.MapFrom(src => $"{src.Founded.ToString("yyyy")} " +
                    //$"({src.Founded.GetYearsAgo()}) years ago"));
                    
        }
    }
}
  