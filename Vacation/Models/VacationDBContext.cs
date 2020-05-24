using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation.Models;

namespace Vacation.Models
{
    public class VacationDBContext: DbContext
    {
        //public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<NutritionType> NutritionTypes { get; set; }
        public virtual DbSet<NutritionTypeInHotel> NutritionTypeInHotels { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<RoomTypeInHotel> RoomTypeInHotels { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }

        public VacationDBContext(DbContextOptions<VacationDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Vacation.Models.Basket> Basket { get; set; }
    }
}
