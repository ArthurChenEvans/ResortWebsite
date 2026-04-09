using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repository;

public class BookingRepository : Repository<Booking>, IBookingRepository
{
    private readonly ApplicationDbContext _db;
    
    public BookingRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    
    public void Update(Booking entity)
    {
        _db.Bookings.Update(entity);
    }

    public void UpdateStatus(int bookingId, string bookingStatus, int villaNumber = 0)
    {
        var booking = _db.Bookings.FirstOrDefault(x => x.Id == bookingId);
        if (booking != null)
        {
            booking.Status = bookingStatus;

            if (bookingStatus == SD.StatusCheckedIn)
            {
                booking.VillaNumber = villaNumber;
                booking.ActualCheckInDate = DateTime.UtcNow;
            }

            if (bookingStatus == SD.StatusCompleted)
            {
                booking.ActualCheckOutDate = DateTime.UtcNow;
            }
        }
    }
    
    public void UpdatePayment(int bookingId, string paddleTransactionId)
    {
        var booking = _db.Bookings.FirstOrDefault(x => x.Id == bookingId);
        if (booking != null)
        {
            booking.PaddleTransactionId = paddleTransactionId;
            booking.IsPaymentSuccessful = true;
            booking.PaymentDate = DateTimeOffset.UtcNow;
        }
    }
}