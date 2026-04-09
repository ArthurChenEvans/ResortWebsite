using System.Security.Claims;
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

    public IActionResult Index()
    {
        return View();
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
            Villa = _unitOfWork.Villa.Get(x => x.Id == villaId, includeProperties: "VillaAmenity"),
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
        var villa = _unitOfWork.Villa.Get(x => x.Id == booking.VillaId);
        booking.Villa = villa;
        booking.TotalCost = villa.Price * booking.Nights;
        booking.BookingDate = DateTimeOffset.UtcNow;

        if (!string.IsNullOrEmpty(booking.PaddleTransactionId))
        {
            booking.Status = SD.StatusApproved;
            booking.IsPaymentSuccessful = true;
            booking.PaymentDate = DateTimeOffset.UtcNow;
        }
        else
        {
            booking.Status = SD.StatusPending;
        }

        _unitOfWork.Booking.Add(booking);
        _unitOfWork.Save();

        return RedirectToAction("BookingConfirmation", new { bookingId = booking.Id });
    }

    [Authorize]
    public IActionResult BookingConfirmation(int bookingId)
    {
        Booking booking = _unitOfWork.Booking
            .Get(u => u.Id == bookingId, includeProperties: "User,Villa");

        if (booking == null)
            return NotFound();

        return View(booking);
    }

    [Authorize]
    public IActionResult BookingDetails(int bookingId)
    {
        Booking booking =  _unitOfWork.Booking.Get(u => u.Id == bookingId,
            includeProperties: "User,Villa"); 
        
        return View(booking);
    }
    

    #region API Calls
    [HttpGet]
    [Authorize]
    public IActionResult GetAll(string status)
    {
        IEnumerable<Booking> objBookings;

        if (User.IsInRole(SD.Role_Admin))
        {
            objBookings = _unitOfWork.Booking.GetAll(includeProperties: "User,Villa");
        }
        else
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            objBookings = _unitOfWork.Booking
                .GetAll(u => u.UserId == userId, includeProperties: "User,Villa");
        }
        if (!string.IsNullOrEmpty(status))
            objBookings = objBookings.Where(x => x.Status.ToLower().Equals(status.ToLower()));
        
        return Json(new { data = objBookings });
    }
    #endregion
}
