using Microsoft.AspNetCore.Identity;

namespace WhiteLagoon.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}