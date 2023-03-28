using AppointmentBookingSystem.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBookingSystem.Context
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Turn> Turns { get; set; }       
    }
}
