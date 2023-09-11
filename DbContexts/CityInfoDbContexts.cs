using CityInfo.API.Entities;
using CityInfo.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoDbContexts : DbContext
    {
        public CityInfoDbContexts(DbContextOptions<CityInfoDbContexts> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; } = null!;

        public DbSet<PointOfIntrest> PointsOfIntrest { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new List<City>()
            {
                new City("Tehran") { Id = 1, Description = "This Is Tehran" },

                new City("Mashhad") { Id = 2, Description = "This Is Mashhad" },

                new City("Shahroud") { Id = 3, Description = "This Is Shahroud" },

                new City ("Esfehan") { Id = 4, Description = "This Is Esfehan" },

                new City ("Tanriz") { Id = 5, Description = "This Is Tanriz"  }
            }
                );
            modelBuilder.Entity<PointOfIntrest>().HasData(
                new PointOfIntrest("Point Of Intrest 1")
                {
                    Id = 1,
                    cityId = 1,
                    Description = "This Is Point Of Intrest 1"
                },
                new PointOfIntrest("Point Of Intrest 2")
                {
                    Id = 2,
                    cityId = 1,
                    Description = "This Is Point Of Intrest 2"
                },

                new PointOfIntrest("Point Of Intrest 3")
                {
                    Id = 3,
                    cityId = 2,
                    Description = "This Is Point Of Intrest 3"
                },
                new PointOfIntrest("Point Of Intrest 4")
                {
                    Id = 4,
                    cityId = 2,
                    Description = "This Is Point Of Intrest 4"
                },
                new PointOfIntrest("Point Of Intrest 5")
                {
                    Id = 5,
                    cityId = 3,
                    Description = "This Is Point Of Intrest 5"
                },
                new PointOfIntrest("Point Of Intrest 6")
                {
                    Id = 6,
                    cityId = 3,
                    Description = "This Is Point Of Intrest 6"
                },
                new PointOfIntrest("Point Of Intrest 7")
                {
                    Id = 7,
                    cityId = 4,
                    Description = "This Is Point Of Intrest 7"
                },
                new PointOfIntrest("Point Of Intrest 8")
                {
                    Id = 8,
                    cityId = 4,
                    Description = "This Is Point Of Intrest 8"
                },
                new PointOfIntrest("Point Of Intrest 9")
                {
                    Id = 9,
                    cityId = 5,
                    Description = "This Is Point Of Intrest 9"
                },
                new PointOfIntrest("Point Of Intrest 10")
                {
                    Id = 10,
                    cityId = 5,
                    Description = "This Is Point Of Intrest 10"
                }
                );

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite();
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
