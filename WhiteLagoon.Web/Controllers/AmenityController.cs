using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResortWebsite.ViewModels;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Domain.Entities;

namespace ResortWebsite.Controllers;

[Authorize(Roles = SD.Role_Admin)]
public class AmenityController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public AmenityController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var amenitys = _unitOfWork.Amenity.GetAll(includeProperties: "Villa");
        return View(amenitys);
    }

    public IActionResult Create()
    {
        AmenityViewModel viewModel = new()
        {
            Villas = _unitOfWork.Villa.GetAll().Select(v => new SelectListItem
            {
                Text = v.Name,
                Value = v.Id.ToString()
            })
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(AmenityViewModel viewModel)
    {
        if (_unitOfWork.Amenity.Get(x => x.Id == viewModel.Amenity.Id) != null)
        {
            ModelState.AddModelError("Amenity.Id", "This room number already exists");
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.Amenity.Add(viewModel.Amenity);
            _unitOfWork.Save();
            TempData["success"] = "Room created successfully";
            return RedirectToAction("Index");
        }

        viewModel.Villas = _unitOfWork.Villa.GetAll().Select(v => new SelectListItem
        {
            Text = v.Name,
            Value = v.Id.ToString(),
            Selected = v.Id == viewModel.Amenity.VillaId
        });
        return View(viewModel);
    }

    public IActionResult Update(AmenityViewModel amenityViewModel)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Amenity.Update(amenityViewModel.Amenity);
            _unitOfWork.Save();
            TempData["success"] = "Amenity updated successfully";
            return RedirectToAction(nameof(Index));
        }

        amenityViewModel.Villas = _unitOfWork.Villa
            .GetAll()
            .Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
        return View(amenityViewModel);
    }


    public IActionResult Delete(int amenity)
    {
        var amenityFromDb = _unitOfWork.Amenity.Get(x => x.Id == amenity, includeProperties: "Villa");
        if (amenityFromDb == null)
        {
            return RedirectToAction("Error", "Home");
        }
        return View(amenityFromDb);
    }

    [HttpPost]
    public IActionResult Delete(Amenity amenity)
    {
        var objFromDb = _unitOfWork.Amenity.Get(x => x.Id == amenity.Id);
        if (objFromDb == null)
        {
            return View();
        }

        _unitOfWork.Amenity.Remove(objFromDb);
        _unitOfWork.Save();
        TempData["success"] = "Room deleted successfully";
        return RedirectToAction("Index");
    }
}