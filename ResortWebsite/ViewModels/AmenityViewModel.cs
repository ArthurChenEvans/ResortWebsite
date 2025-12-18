using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteLagoon.Domain.Entities;

namespace ResortWebsite.ViewModels;

public class AmenityViewModel
{
   public Amenity? Amenity { get; set; }
   [ValidateNever]
   public IEnumerable<SelectListItem> Villas { get; set; }
}