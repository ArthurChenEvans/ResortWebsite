using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhiteLagoon.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    
    [Required]
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }
    
    [Required]
    public int VillaId { get; set; }
    [ForeignKey("VillaId")]
    public Villa Villa { get; set; }
    
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    public string? Phone { get; set; }

    [Required] 
    public double TotalCost { get; set; }
    public int Nights { get; set; }
    public string? Status { get; set; }
    
    [Required]
    public DateTimeOffset BookingDate { get; set; }
    [Required]
    public DateOnly CheckInDate { get; set; }
    [Required]
    public DateOnly CheckOutDate { get; set; }
    
    public bool IsPaymentSuccessful { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
    
    public string? BraintreeTransactionId { get; set; }
    public string? BraintreePaymentNonce { get; set; }
    
    public DateTimeOffset ActualCheckInDate { get; set; }
    public DateTimeOffset ActualCheckOutDate { get; set; }
    
    public int VillaNumber { get; set; }
}