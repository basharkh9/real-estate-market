using Microsoft.EntityFrameworkCore;
using real_estate_market.Models;

namespace real_estate_market.Persistence
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options)
        {

        }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Cladding> Claddings { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}