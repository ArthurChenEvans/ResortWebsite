using WhiteLagoon.Domain.Entities;

namespace ResortWebsite.ViewModels;

public class HomeViewModel
{
    public IEnumerable<Villa> Villas { get; set; }
    public DateOnly CheckInDate { get; set; }
    public DateOnly CheckOutDate { get; set; }
    public int Nights { get; set; }
}