using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WhiteLagoon.Domain.Entities;

public class Villa
{
   public int Id { get; set; }
   [Required]
   public required string Name { get; set; }
   [MaxLength(100)]
   public string? Description { get; set; }
   [Required]
   [Display(Name = "Price per night")]
   [Range(10, 10000)]
   public double Price { get; set; }
   [Required]
   [Display(Name = "In squared meters")]
   public int MeterSquared { get; set; }
   [Required]
   public int Occupancy { get; set; }
   [NotMapped]
   public IFormFile? Image { get; set; }
   [Display(Name = "Image Url")]
   public string? ImageUrl { get; set; }
   public DateTimeOffset CreatedAt { get; init; } 
   public DateTimeOffset UpdatedAt { get; set; }
   
   [ValidateNever]
   public IEnumerable<Amenity> VillaAmenity { get; set; }
}