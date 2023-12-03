using Microsoft.EntityFrameworkCore;
using Villa_Api.Model;

namespace Villa_Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Villa> Villas { get; set; }
    public DbSet<VillaNumber> VillaNumber { get; set; }

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
            },
            new Villa
            {
                id = 2,
                CreatedDate = DateTime.Now,
                name = "Kumar",
                Occupancy = 10000,
                rate = 20,
                Sqft = 10,
                UpdatedDate = DateTime.Now
            }
        );
        modelBuilder.Entity<VillaNumber>().HasData(
            new VillaNumber
            {
                VillaNo = 1,
                SpecialDetails = "Blue",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new VillaNumber
            {
                VillaNo = 2,
                SpecialDetails = "Orange",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            }
        );
    }
}