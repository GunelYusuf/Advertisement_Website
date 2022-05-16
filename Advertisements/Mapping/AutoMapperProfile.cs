using System;
using System.Linq;
using Advertisements.Dto;
using Advertisements.Models;
using AutoMapper;

namespace Advertisements.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateAdvertisementDto, Advertisement>().ReverseMap();
            CreateMap<Advertisement, AdvertisementResponseDto>().ForMember(x => x.PhotoUrl, g => g.MapFrom(c => c.advertisementPhotos.FirstOrDefault(d => d.IsMain==true).PhotoUrl));
        }
    }
}
