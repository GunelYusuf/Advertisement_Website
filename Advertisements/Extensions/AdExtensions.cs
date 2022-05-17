using System;
using System.Linq;
using Advertisements.Models;

namespace Advertisements.Extensions
{
    public static class AdExtensions
    {
       public static IQueryable<Advertisement> Sort(this IQueryable<Advertisement> query, string orderBy)
       {
            if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(p => p.Title);
            query = orderBy switch
            {
                "price" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Title)
            };

            return query;
            
       }

        public static IQueryable<Advertisement> Search(this IQueryable<Advertisement> query, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return query;
            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
            return query.Where(p => p.Title.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
