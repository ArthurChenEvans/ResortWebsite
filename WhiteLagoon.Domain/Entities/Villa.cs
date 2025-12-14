using System.ComponentModel.DataAnnotations;

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
   [Display(Name = "Image Url")]
   public string? ImageUrl { get; set; }
   public DateTimeOffset CreatedAt { get; set; }
   public DateTimeOffset UpdatedAt { get; set; }
}