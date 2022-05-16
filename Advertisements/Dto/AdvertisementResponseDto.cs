using System;
namespace Advertisements.Dto
{
    public class AdvertisementResponseDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public string PhotoUrl { get; set; }
    }
}
