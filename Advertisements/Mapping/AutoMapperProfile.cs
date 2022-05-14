using System;
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

        }
    }
}
