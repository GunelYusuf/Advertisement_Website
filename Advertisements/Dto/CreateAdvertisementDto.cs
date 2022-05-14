using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Advertisements.Dto
{
    public class CreateAdvertisementDto
    {
        [Required,MaxLength(200)]
        public string Title { get; set; }

        [Required,MaxLength(1000)]
        public string Description { get; set; }

        public long Price { get; set; }

        [Required,MaxLength(3)]
        public IFormFile[] photos { get; set; }

    }
}
