using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Domain.Entities;

namespace ResortWebsite.Controllers;

public class BookingController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    public BookingController(
        IUnitOfWork unitOfWork,
        IConfiguration configuration,
        IHttpClientFactory httpClientFactory)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }
    
    private HttpClient CreatePaddleClient()
    {
        var client = _httpClientFactory.CreateClient();
        var apiKey = _configuration["Paddle:ApiKey"];
        var baseUrl = _configuration["Paddle:BaseUrl"];

        client.BaseAddress = new Uri(baseUrl!);
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", apiKey);
        client.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));

        return client;
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
        ModelState.Remove("User");
        ModelState.Remove("Villa");
        ModelState.Remove("VillaNumbers");
        
        if (!ModelState.IsValid)
        {
            booking.Villa = _unitOfWork.Villa.Get(
                x => x.Id == booking.VillaId, includeProperties: "VillaAmenity");
            return View(booking);
        }
        
        var villa = _unitOfWork.Villa.Get(x => x.Id == booking.VillaId);
        booking.TotalCost = villa.Price * booking.Nights;
        booking.CheckOutDate = booking.CheckInDate.AddDays(booking.Nights);
        booking.BookingDate = DateTimeOffset.UtcNow;
        booking.Status = SD.StatusPending;
        booking.IsPaymentSuccessful = false;

        _unitOfWork.Booking.Add(booking);
        _unitOfWork.Save();

        return RedirectToAction(nameof(PaddleCheckout), new { bookingId = booking.Id });
    }
    
    [Authorize]
    public IActionResult PaddleCheckout(int bookingId)
    {
        var booking = _unitOfWork.Booking.Get(
            x => x.Id == bookingId, includeProperties: "Villa");

        if (booking == null) return NotFound();

        // Don't let someone re-pay an already approved booking
        if (booking.Status == SD.StatusApproved)
            return RedirectToAction(nameof(BookingConfirmation), new { bookingId });

        return View(booking);
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreatePaddleTransaction([FromBody] int bookingId)
    {
        var booking = _unitOfWork.Booking.Get(
            x => x.Id == bookingId, includeProperties: "Villa");

        if (booking == null)
            return NotFound(new { error = "Booking not found" });

        // Paddle expects amounts as strings in the lowest denomination (cents)
        var amountInCents = ((long)(booking.TotalCost * 100)).ToString();

        var payload = new
        {
            items = new[]
            {
                new
                {
                    price_id = booking.Villa.PaddlePriceId,
                    quantity = booking.Nights
                }
            },
            customer = new
            {
                email = booking.Email
            },
            custom_data = new
            {
                booking_id = booking.Id.ToString()
            }
        };

        var json = JsonSerializer.Serialize(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var client = CreatePaddleClient();
        var response = await client.PostAsync("/transactions", content);
        
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            // Log it so you can see exactly what Paddle said
            Console.WriteLine($"Paddle error: {response.StatusCode} - {error}");
            return StatusCode(500, new { error = "Failed to create Paddle transaction", detail = error });
        }

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            return StatusCode(500, new { error = "Failed to create Paddle transaction", detail = error });
        }

        var responseJson = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseJson);
        var transactionId = doc.RootElement
            .GetProperty("data")
            .GetProperty("id")
            .GetString();

        return Ok(new { transactionId });
    }

    [Authorize]
    public async Task<IActionResult> BookingConfirmation(int bookingId, string? transactionId = null)
    {
        var booking = _unitOfWork.Booking.Get(
            x => x.Id == bookingId, includeProperties: "User,Villa");

        if (booking == null) return NotFound();

        // Already approved — just show confirmation
        if (booking.Status == SD.StatusApproved)
            return View(booking);

        // Save transaction ID if we've just come back from Paddle
        if (!string.IsNullOrEmpty(transactionId) &&
            string.IsNullOrEmpty(booking.PaddleTransactionId))
        {
            booking.PaddleTransactionId = transactionId;
            _unitOfWork.Booking.Update(booking);
            _unitOfWork.Save();
        }

        // Verify with Paddle server-side — never trust the client alone
        var txnIdToVerify = booking.PaddleTransactionId ?? transactionId;

        if (!string.IsNullOrEmpty(txnIdToVerify))
        {
            var client = CreatePaddleClient();
            var response = await client.GetAsync($"/transactions/{txnIdToVerify}");

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(responseJson);
                var status = doc.RootElement
                    .GetProperty("data")
                    .GetProperty("status")
                    .GetString();
                
                Console.WriteLine($"Paddle transaction status: {status}");

                if (status is "completed" or "paid" or "billed" or "ready")
                {
                    _unitOfWork.Booking.UpdateStatus(booking.Id, SD.StatusApproved);
                    _unitOfWork.Booking.UpdatePayment(booking.Id, txnIdToVerify);
                    _unitOfWork.Save();
                }
            }
        }

        // Re-fetch so the view gets the updated status
        booking = _unitOfWork.Booking.Get(
            x => x.Id == bookingId, includeProperties: "User,Villa");

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
