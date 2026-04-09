using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResortWebsite.ViewModels;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;

namespace ResortWebsite.Controllers;

public class VillaNumberController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public VillaNumberController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var villaNumbers = _unitOfWork.VillaNumber.GetAll(includeProperties: "Villa");
        return View(villaNumbers);
    }

    public IActionResult Create()
    {
        VillaNumberViewModel viewModel = new()
        {
            VillaNumber = new(),
            Villas = _unitOfWork.Villa.GetAll().Select(v => new SelectListItem
            {
                Text = v.Name,
                Value = v.Id.ToString()
            })
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(VillaNumberViewModel viewModel)
    {
        if (_unitOfWork.VillaNumber.Get(x => x.Villa_Number == viewModel.VillaNumber.Villa_Number) != null)
        {
            ModelState.AddModelError("VillaNumber.Villa_Number", "This room number already exists");
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.VillaNumber.Add(viewModel.VillaNumber);
            _unitOfWork.Save();
            TempData["success"] = "Room created successfully";
            return RedirectToAction("Index");
        }

        viewModel.Villas = _unitOfWork.Villa.GetAll().Select(v => new SelectListItem
        {
            Text = v.Name,
            Value = v.Id.ToString(),
            Selected = v.Id == viewModel.VillaNumber.VillaId
        });
        return View(viewModel);
    }

    public IActionResult Update(int villaNumber)
    {
        var villaNumberFromDb = _unitOfWork.VillaNumber.Get(x => x.Villa_Number == villaNumber, includeProperties: "Villa");
        if (villaNumberFromDb == null)
        {
            return RedirectToAction("Error", "Home");
        }

        VillaNumberViewModel viewModel = new()
        {
            VillaNumber = villaNumberFromDb,
            Villas = _unitOfWork.Villa.GetAll().Select(v => new SelectListItem
            {
                Text = v.Name,
                Value = v.Id.ToString(),
                Selected = v.Id == villaNumberFromDb.VillaId
            })
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Update(VillaNumberViewModel viewModel)
    {
        if (_unitOfWork.VillaNumber.Get(x => x.Villa_Number == viewModel.VillaNumber.Villa_Number 
            && x.Villa_Number != viewModel.VillaNumber.Villa_Number) != null)
        {
            ModelState.AddModelError("VillaNumber.Villa_Number", "This room number already exists");
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.VillaNumber.Update(viewModel.VillaNumber);
            _unitOfWork.Save();
            TempData["success"] = "Room updated successfully";
            return RedirectToAction("Index");
        }

        viewModel.Villas = _unitOfWork.Villa.GetAll().Select(v => new SelectListItem
        {
            Text = v.Name,
            Value = v.Id.ToString(),
            Selected = v.Id == viewModel.VillaNumber.VillaId
        });
        return View(viewModel);
    }

    public IActionResult Delete(int villaNumber)
    {
        var villaNumberFromDb = _unitOfWork.VillaNumber.Get(x => x.Villa_Number == villaNumber, includeProperties: "Villa");
        if (villaNumberFromDb == null)
        {
            return RedirectToAction("Error", "Home");
        }
        return View(villaNumberFromDb);
    }

    [HttpPost]
    public IActionResult Delete(VillaNumber villaNumber)
    {
        var objFromDb = _unitOfWork.VillaNumber.Get(x => x.Villa_Number == villaNumber.Villa_Number);
        if (objFromDb == null)
        {
            return View();
        }

        _unitOfWork.VillaNumber.Remove(objFromDb);
        _unitOfWork.Save();
        TempData["success"] = "Room deleted successfully";
        return RedirectToAction("Index");
    }
}