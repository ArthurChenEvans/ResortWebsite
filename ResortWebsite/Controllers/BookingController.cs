using System.Security.Claims;
using Braintree;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Domain.Entities;

namespace ResortWebsite.Controllers;

public class BookingController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public BookingController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [Authorize]
    public IActionResult FinalizeBooking(int villaId, DateOnly checkInDate, int nights)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        
        ApplicationUser user = _unitOfWork.User.Get(x => x.Id == userId);
        
        Booking booking = new Booking
        {
            VillaId = villaId,
            Villa = _unitOfWork.Villa.Get(x => x.Id == villaId, includeProperties:"VillaAmenity"),
            CheckInDate = checkInDate,
            Nights = nights,
            CheckOutDate = checkInDate.AddDays(nights),
            UserId = userId,
            Phone = user.PhoneNumber,
            Email = user.Email,
            Name = user.Name
        };
        
        booking.TotalCost = booking.Villa.Price * nights;
        
        return View(booking);
    }

    [Authorize]
    [HttpPost]
    public IActionResult FinalizeBooking(Booking booking)
    {
        booking.Villa = _unitOfWork.Villa.Get(x => x.Id == booking.VillaId);
        booking.TotalCost = booking.Villa.Price * booking.Nights;
        booking.Status = SD.StatusPending;
        booking.BookingDate = DateTimeOffset.UtcNow;
        
        _unitOfWork.Booking.Add(booking);
        _unitOfWork.Save();
        
        return RedirectToAction(nameof(BookingConfirmation), new { bookingId = booking.Id });
    }
    
    [Authorize]
    public IActionResult BookingConfirmation(int bookingId)
    {
        return View(bookingId);
    }
}