using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Utility;

public static class SD
{
   public const string Role_Admin = "Admin";
   public const string Role_Customer = "Customer";
   
   public const string StatusPending = "Pending";
   public const string StatusApproved = "Approved";
   public const string StatusCheckedIn = "CheckedIn";
   public const string StatusCompleted = "Completed";
   public const string StatusCancelled = "Cancelled";
   public const string StatusRefunded = "Refunded";

   public static int VillaRoomsAvailable_Count(int villaId,
      List<VillaNumber> villaNumberList, DateOnly checkInDate, int nights,
      List<Booking> bookings)
   {
      var roomsInVilla = villaNumberList.Count(x => x.VillaId == villaId);
      var checkOutDate = checkInDate.AddDays(nights);

      var overlappingBookings = bookings
         .Where(u => u.VillaId == villaId
                     && u.CheckInDate < checkOutDate
                     && u.CheckOutDate > checkInDate)
         .ToList();

      if (overlappingBookings.Count == 0)
         return roomsInVilla;

      int peakOccupancy = Enumerable.Range(0, nights)
         .Select(i =>
         {
            var date = checkInDate.AddDays(i);
            return overlappingBookings.Count(u => u.CheckInDate <= date && u.CheckOutDate > date);
         })
         .Max();

      return roomsInVilla - peakOccupancy;
   }
}