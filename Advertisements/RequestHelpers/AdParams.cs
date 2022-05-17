using System;
namespace Advertisements.RequestHelpers
{
    public class AdParams:PaginationParams
    {
        public string? OrderBy { get; set; }

        public string? SearchTerm { get; set; }
    }
}
