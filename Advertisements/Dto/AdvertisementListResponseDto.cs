using System;
using System.Collections.Generic;

namespace Advertisements.Dto
{
    public class AdvertisementListResponseDto
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public List<string> Photos { get; set; } = new List<string>();
    }
}
