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
        
        var villaNumbers = new List<VillaNumber>
        {
            new VillaNumber 
            { 
                Villa_Number = 101, 
                VillaId = 1, 
                SpecialDetails = "Ocean view balcony with private hot tub" 
            },
            new VillaNumber 
            { 
                Villa_Number = 102, 
                VillaId = 1, 
                SpecialDetails = "Ground floor access, wheelchair accessible" 
            },
            new VillaNumber 
            { 
                Villa_Number = 103, 
                VillaId = 1, 
                SpecialDetails = "Rooftop terrace with telescope for stargazing" 
            },
            
            new VillaNumber 
            { 
                Villa_Number = 201, 
                VillaId = 2, 
                SpecialDetails = "Forest-facing room with suspended fireplace" 
            },
            new VillaNumber 
            { 
                Villa_Number = 202, 
                VillaId = 2, 
                SpecialDetails = "Private sauna and cold plunge pool access" 
            },
            new VillaNumber 
            { 
                Villa_Number = 203, 
                VillaId = 2, 
                SpecialDetails = "Artist's studio with natural lighting" 
            },
            
            new VillaNumber 
            { 
                Villa_Number = 301, 
                VillaId = 3, 
                SpecialDetails = "Infinity pool edge overlooking tropical gardens" 
            },
            new VillaNumber 
            { 
                Villa_Number = 302, 
                VillaId = 3, 
                SpecialDetails = "Chef's kitchenette with premium appliances" 
            },
            new VillaNumber 
            { 
                Villa_Number = 303, 
                VillaId = 3, 
                SpecialDetails = "Glass-walled bedroom with jungle canopy views" 
            },
            
            new VillaNumber 
            { 
                Villa_Number = 401, 
                VillaId = 4, 
                SpecialDetails = "Soundproofed media room with 4K projector" 
            },
            new VillaNumber 
            { 
                Villa_Number = 402, 
                VillaId = 4, 
                SpecialDetails = "Executive workspace with ergonomic setup" 
            },
            new VillaNumber 
            { 
                Villa_Number = 403, 
                VillaId = 4, 
                SpecialDetails = "Penthouse suite with 360° city skyline views" 
            },
            
            new VillaNumber 
            { 
                Villa_Number = 501, 
                VillaId = 5, 
                SpecialDetails = "Lakeside deck with private canoe dock" 
            },
            new VillaNumber 
            { 
                Villa_Number = 502, 
                VillaId = 5, 
                SpecialDetails = "Indoor/outdoor fireplace with lakeside seating" 
            },
            new VillaNumber 
            { 
                Villa_Number = 503, 
                VillaId = 5, 
                SpecialDetails = "Botanical garden conservatory with breakfast nook" 
            }
        };

        modelBuilder.Entity<VillaNumber>().HasData(villaNumbers);
    }
}