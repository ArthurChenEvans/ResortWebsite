using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ResortWebsite.Models;
using ResortWebsite.ViewModels;
using WhiteLagoon.Application.Common.Interfaces;

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

        foreach (var villa in villas)
        {
            // Temp to give example available Villas until Booking is implemented
            if (villa.Id % 2 == 0)
            {
                villa.IsAvailable = false;
            }
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