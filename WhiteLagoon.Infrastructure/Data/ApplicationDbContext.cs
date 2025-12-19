using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Villa> Villas { get; set; }
    public DbSet<VillaNumber> VillaNumbers { get; set; }
    public DbSet<Amenity> Amenities { get; set; }

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
        
        var amenities = new List<Amenity>
        {
            new Amenity { Id = 1, Name = "Private Infinity Pool", Description = "Stunning infinity pool overlooking the ocean with automatic cleaning system", VillaId = 1 },
            new Amenity { Id = 2, Name = "Beach Access", Description = "Private stairway leading directly to the pristine white sand beach", VillaId = 1 },
            new Amenity { Id = 3, Name = "Ocean View Balcony", Description = "Spacious balcony with panoramic ocean views and comfortable seating", VillaId = 1 },
            new Amenity { Id = 4, Name = "Outdoor Shower", Description = "Luxurious outdoor rainfall shower surrounded by tropical plants", VillaId = 1 },
            new Amenity { Id = 5, Name = "Smart Home System", Description = "Integrated smart home controls for lighting, climate, and entertainment", VillaId = 1 },

            new Amenity { Id = 6, Name = "Stone Fireplace", Description = "Authentic stone fireplace with wood-burning capability and heated mantel", VillaId = 2 },
            new Amenity { Id = 7, Name = "Mountain Hiking Trails", Description = "Direct access to private hiking trails through scenic mountain forests", VillaId = 2 },
            new Amenity { Id = 8, Name = "Hot Tub", Description = "Premium hot tub with hydrotherapy jets and mountain view", VillaId = 2 },
            new Amenity { Id = 9, Name = "Wood Sauna", Description = "Traditional cedar wood sauna with aroma therapy options", VillaId = 2 },
            new Amenity { Id = 10, Name = "Heated Floors", Description = "Radiant floor heating throughout the villa for cozy winter comfort", VillaId = 2 },

            new Amenity { Id = 11, Name = "Tropical Gardens", Description = "Professionally landscaped gardens with exotic plants and water features", VillaId = 3 },
            new Amenity { Id = 12, Name = "Outdoor Kitchen", Description = "Fully equipped outdoor kitchen with BBQ grill, sink, and bar seating", VillaId = 3 },
            new Amenity { Id = 13, Name = "Swimming Pool", Description = "Large swimming pool with swim-up bar and underwater lighting", VillaId = 3 },
            new Amenity { Id = 14, Name = "Hammock Area", Description = "Relaxing hammock area under palm trees with shade sails", VillaId = 3 },
            new Amenity { Id = 15, Name = "Tiki Bar", Description = "Authentic tiki bar with thatched roof and tropical drink service", VillaId = 3 },

            new Amenity { Id = 16, Name = "Rooftop Terrace", Description = "Exclusive rooftop terrace with city views and lounge furniture", VillaId = 4 },
            new Amenity { Id = 17, Name = "Smart Home System", Description = "Advanced smart home system with voice control and automation", VillaId = 4 },
            new Amenity { Id = 18, Name = "City Skyline Views", Description = "Floor-to-ceiling windows offering breathtaking city skyline views", VillaId = 4 },
            new Amenity { Id = 19, Name = "High-Speed Internet", Description = "Gigabit fiber internet with dedicated Wi-Fi 6 access points", VillaId = 4 },
            new Amenity { Id = 20, Name = "Concierge Service", Description = "24/7 concierge service for restaurant reservations and city experiences", VillaId = 4 },

            new Amenity { Id = 21, Name = "Private Dock", Description = "Private wooden dock extending into the lake with seating area", VillaId = 5 },
            new Amenity { Id = 22, Name = "Fire Pit", Description = "Stone fire pit with comfortable seating for lakeside evenings", VillaId = 5 },
            new Amenity { Id = 23, Name = "Canoe/Kayak Access", Description = "Two-person canoe and two kayaks available for lake exploration", VillaId = 5 },
            new Amenity { Id = 24, Name = "Lakeside Patio", Description = "Large covered patio with dining area and lake views", VillaId = 5 },
            new Amenity { Id = 25, Name = "Botanical Garden", Description = "Professionally maintained botanical garden with walking paths", VillaId = 5 }
        };

        modelBuilder.Entity<Amenity>().HasData(amenities);;
    }
}