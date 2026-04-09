using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ResortWebsite.Models;
using ResortWebsite.ViewModels;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;

namespace ResortWebsite.Controllers;

public class HomeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    
    public HomeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public IActionResult Index()
    {
        HomeViewModel homeViewModel = new()
        {
            Villas = _unitOfWork.Villa.GetAll(includeProperties: "VillaAmenity"),
            Nights = 1,
            CheckInDate = DateOnly.FromDateTime(DateTime.Now),
        };
        return View(homeViewModel);
    }
   
    [HttpPost]
    public IActionResult GetVillasByDate(int nights, DateOnly checkInDate)
    {
        var villas = _unitOfWork.Villa.GetAll(includeProperties: "VillaAmenity").ToList();
        var villaNumbersList = _unitOfWork.VillaNumber.GetAll().ToList();
        var bookedVillas = _unitOfWork
            .Booking
            .GetAll(u => u.Status == SD.StatusApproved ||
                         u.Status == SD.StatusCheckedIn).ToList();

        foreach (var villa in villas)
        {
            int roomsAvailable = SD.VillaRoomsAvailable_Count
                (villa.Id, villaNumbersList, checkInDate, nights, bookedVillas);
            
            villa.IsAvailable = roomsAvailable > 0 ? true : false;
        }

        HomeViewModel homeViewModel = new()
        {
            CheckInDate = checkInDate,
            Villas = villas,
            Nights = nights
        };
        
        return PartialView("_Villas", homeViewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
}