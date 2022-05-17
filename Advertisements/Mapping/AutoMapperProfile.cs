using System;
using System.Collections.Generic;
using System.Linq;
using Advertisements.Dto;
using Advertisements.Models;
using Advertisements.RequestHelpers;
using AutoMapper;

namespace Advertisements.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateAdvertisementDto, Advertisement>().ReverseMap();
            CreateMap<Advertisement, AdvertisementResponseDto>().ForMember(x => x.PhotoUrl, g => g.MapFrom(c => c.advertisementPhotos.FirstOrDefault(d => d.IsMain==true).PhotoUrl));
            CreateMap<Advertisement, AdvertisementListResponseDto>().ForMember(x => x.Photos, g => g.MapFrom(c => c.advertisementPhotos.Select(x=> x.PhotoUrl)));
        }
    }
}
