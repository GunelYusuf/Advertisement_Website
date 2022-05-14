using System;
using Advertisements.Models;
using Microsoft.EntityFrameworkCore;

namespace Advertisements.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Advertisement> advertisements { get; set; }
        public DbSet<AdvertisementPhotos> advertisementPhotos { get; set; }
    }
}
