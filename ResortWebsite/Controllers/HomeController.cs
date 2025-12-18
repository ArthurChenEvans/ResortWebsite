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

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
}