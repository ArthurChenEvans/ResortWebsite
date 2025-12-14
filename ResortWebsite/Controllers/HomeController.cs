using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ResortWebsite.Models;

namespace ResortWebsite.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
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