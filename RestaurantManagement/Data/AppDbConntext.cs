using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;

namespace RestaurantManagement.Data
{
    public class AppDbConntext : DbContext
    {
        public AppDbConntext(DbContextOptions<AppDbConntext> options) : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
