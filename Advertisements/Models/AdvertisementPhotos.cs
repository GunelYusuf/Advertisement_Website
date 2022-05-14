using System;
namespace Advertisements.Models
{
    public class AdvertisementPhotos
    {
        public int Id { get; set; }

        public string PhotoUrl { get; set; }

        public bool IsMain { get; set; }

        public string PublicId { get; set; }

        public Advertisement Advertisement { get; set; }

        public int AdvertisementId { get; set; }

    }
}
