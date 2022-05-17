using System;
using System.Text.Json;
using Advertisements.RequestHelpers;
using Microsoft.AspNetCore.Http;

namespace Advertisements.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, MetaData metaData)
        {
            var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            response.Headers.Add("Pagination",JsonSerializer.Serialize(metaData, option));
            response.Headers.Add("Access-Control-Exponse-Headers", "Pagination");
        }
    }
}
