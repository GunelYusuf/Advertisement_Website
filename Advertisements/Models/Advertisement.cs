using System;
using System.Collections.Generic;

namespace Advertisements.Models
{
    public class Advertisement
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public List<AdvertisementPhotos> advertisementPhotos { get; set; }
    }
}
