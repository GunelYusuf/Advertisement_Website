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

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> AdCreation([FromForm] CreateAdvertisementDto createAdvertisementDto)
        {
            try
            {
                Advertisement advertisement = _mapper.Map<Advertisement>(createAdvertisementDto);
                await _appDbContext.AddAsync(advertisement);
                var result = await _appDbContext.SaveChangesAsync() > 0;


                if (result == true && createAdvertisementDto.photos != null)
                {
                    foreach (var (photo, index) in createAdvertisementDto.photos.Select((v, i) => (v, i)))
                    {
                        var imageResult = await _photoUploadService.AddImageAsync(photo);
                        if (imageResult.Error != null)
                        {
                            _appDbContext.advertisements.Remove(advertisement);
                            await _appDbContext.SaveChangesAsync();
                            return BadRequest(new ProblemDetails { Title = imageResult.Error.Message });
                        }

                        AdvertisementPhotos advertisementPhotos = new();
                        if (index == 0) advertisementPhotos.IsMain = true;
                        advertisementPhotos.AdvertisementId = advertisement.Id;
                        advertisementPhotos.PhotoUrl = imageResult.SecureUrl.ToString();
                        advertisementPhotos.PublicId = imageResult.PublicId;
                        await _appDbContext.advertisementPhotos.AddAsync(advertisementPhotos);

                        var res = await _appDbContext.SaveChangesAsync() > 0;
                        if (!res)
                        {
                            _appDbContext.advertisements.Remove(advertisement);
                            await _appDbContext.SaveChangesAsync();
                            return BadRequest(new ProblemDetails { Title = "An Error occurred while uploading the photo." });
                        }
                    };
                }
                return CreatedAtRoute("GetAd", new { Id = advertisement.Id }, advertisement.Id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
