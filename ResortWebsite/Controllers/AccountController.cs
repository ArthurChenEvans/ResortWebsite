using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResortWebsite.ViewModels;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Domain.Entities;

namespace ResortWebsite.Controllers;

public class AccountController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(IUnitOfWork unitOfWork,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }
    
    public IActionResult Login(string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        LoginViewModel loginViewModel = new()
        {
            ReturnUrl = returnUrl,
        };
        
        return View(loginViewModel);
    }

    public async Task<IActionResult> Register()
    {
        if (!await _roleManager.RoleExistsAsync(SD.Role_Admin))
        {
            // I would prefer to manually seed them in ApplicationDbContext, but I'm just
            // following what the course is showing.
            // I think it is showing to do it this way to demonstrate what RoleManage provides.
            await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
            await _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer));
        }

        RegisterViewModel registerViewModel = new()
        {
            Roles = _roleManager.Roles.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Name
            })
        };
        
        return View(registerViewModel);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        ApplicationUser user = new()
        {
            Name = registerViewModel.Name,
            Email = registerViewModel.Email,
            PhoneNumber = registerViewModel.PhoneNumber,
            NormalizedEmail = registerViewModel.Email.ToUpper(),
            EmailConfirmed = true,
            UserName = registerViewModel.Email,
        };
            
        var result = await _userManager.CreateAsync(user, registerViewModel.Password);

        if (result.Succeeded)
        {
            if (!string.IsNullOrEmpty(registerViewModel.Role))
            {
                await _userManager.AddToRoleAsync(user, registerViewModel.Role);
            }
            else
            {
                await _userManager.AddToRoleAsync(user, SD.Role_Customer);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            if (string.IsNullOrEmpty(registerViewModel.ReturnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            
            // Ensures always redirect to the same domain and not a malicious website
            return LocalRedirect(registerViewModel.ReturnUrl);
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        registerViewModel.Roles = _roleManager.Roles.Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Name
        });
        
        return View(registerViewModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
           var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email,
               loginViewModel.Password,
               loginViewModel.RememberMe,
               false); 
           
           if (result.Succeeded)
           {
               
               if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
               {
                   return RedirectToAction("Index", "Home");
               }
               
               // Ensures always redirect to the same domain and not a malicious website
               return LocalRedirect(loginViewModel.ReturnUrl);
           }
           
           ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }
        
        return View(loginViewModel);
    }
}