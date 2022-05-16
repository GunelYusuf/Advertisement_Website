using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertisements.Context;
using Advertisements.Dto;
using Advertisements.Models;
using Advertisements.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advertisements.Controllers
{
    [Route("api/[controller]")]
    public class AdvertisementController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        private readonly PhotoUploadService _photoUploadService;

        public AdvertisementController(IMapper mapper, AppDbContext appDbContext, PhotoUploadService photoUploadService)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
            _photoUploadService = photoUploadService;
        }

       
        [HttpGet("{id}",Name = "GetAd")]
        public async Task<IActionResult> Get(int id)
        {
            Advertisement advertisement = await _appDbContext.advertisements.Where(x => x.Id == id).Include(p => p.advertisementPhotos).FirstOrDefaultAsync();
            AdvertisementResponseDto advertisementResponseDto = _mapper.Map<AdvertisementResponseDto>(advertisement);
            if (advertisement != null) return new JsonResult(advertisementResponseDto) { StatusCode = 200 };
            return NotFound();
        }

      
    }
}
