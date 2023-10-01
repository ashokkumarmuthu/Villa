using Microsoft.EntityFrameworkCore;
using Villa_Api.Model;

namespace Villa_Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Villa> Villas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Villa>().HasData(
            new Villa
            {
                id = 1,
                CreatedDate = DateTime.Now,
                name = "Ashok",
                Occupancy = 10000,
                rate = 20,
                Sqft = 10,
                UpdatedDate = DateTime.Now
            }
        );
    }
}