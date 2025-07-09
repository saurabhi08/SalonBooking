using Microsoft.EntityFrameworkCore;

namespace SalonBookingApp.Models
{
    // This class is used to interact with the database using Entity Framework
    public class SalonContext : DbContext
    {
        // Constructor for dependency injection
        public SalonContext(DbContextOptions<SalonContext> options) : base(options) { }

        // These DbSet properties represent tables in the database
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Stylist> Stylists { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
} 