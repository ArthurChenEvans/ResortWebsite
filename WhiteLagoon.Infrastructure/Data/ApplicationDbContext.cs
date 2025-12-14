using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Villa> Villas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        var villas = new List<Villa>
        {
            new Villa
            {
                Id = 1,
                Name = "Azure Haven",
                Description = "A serene coastal villa with panoramic ocean views and a private infinity pool.",
                Price = 450.00,
                MeterSquared = 220,
                Occupancy = 6,
                ImageUrl = "https://placehold.co/600x400/EEE/31343C",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Villa
            {
                Id = 2,
                Name = "Pinecrest Lodge",
                Description = "Nestled in the mountains, this rustic-chic villa offers fireplace warmth and forest trails.",
                Price = 320.50,
                MeterSquared = 180,
                Occupancy = 4,
                ImageUrl = "https://placehold.co/600x400/EEE/31343C",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Villa
            {
                Id = 3,
                Name = "Sunny Palms Estate",
                Description = "Luxury meets comfort in this sun-drenched villa with tropical gardens and outdoor kitchen.",
                Price = 580.75,
                MeterSquared = 260,
                Occupancy = 8,
                ImageUrl = "https://placehold.co/600x400/EEE/31343C",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Villa
            {
                Id = 4,
                Name = "Urban Loft Retreat",
                Description = "Modern city-center villa with floor-to-ceiling windows and rooftop terrace access.",
                Price = 290.00,
                MeterSquared = 140,
                Occupancy = 3,
                ImageUrl = "https://placehold.co/600x400/EEE/31343C",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Villa
            {
                Id = 5,
                Name = "Lakeside Serenity",
                Description = "Tranquil lakeside property with canoe dock, fire pit, and cozy interior design.",
                Price = 410.25,
                MeterSquared = 200,
                Occupancy = 5,
                ImageUrl = "https://placehold.co/600x400/EEE/31343C",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        modelBuilder.Entity<Villa>().HasData(villas);
    }
}