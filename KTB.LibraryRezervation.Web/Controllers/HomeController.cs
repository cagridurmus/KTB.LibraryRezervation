using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KTB.LibraryRezervation.Web.Models;
using KTB.LibraryRezervation.Core.Services;
using KTB.LibraryRezervation.Core.DTOs.Login;
using KTB.LibraryRezervation.Core.DTOs.Register;
using KTB.LibraryRezervation.Core.Models;
using KTB.LibraryRezervation.Web.Services;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace KTB.LibraryRezervation.Web.Controllers;

public class HomeController : Controller
{
    private readonly UserApiService _userService;

    private readonly AuthApiService _authService;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, UserApiService userService, AuthApiService authService)
    {

        _logger = logger;
        _userService = userService;
        _authService = authService;
    }

    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginUserDto user)
    {
        var result = await _authService.LoginAsync(user);
        if (result)
        {
            TempData["email"] = user.Email;
            return RedirectToAction("Index", "LibraryHall");
        }
        
        return View("Login");
    }

    public IActionResult Register()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto user)
    {
        var result = await _userService.CreateUserAsync(user);
        //var x = await _service.AddAsync(library);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

