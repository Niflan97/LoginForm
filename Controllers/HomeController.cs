using System.Diagnostics;
using LogInProject.Data;
using LogInProject.Models;
using LogInProject.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogInProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IAuthenticationService _authenticationService;
    private readonly UserDbContext _context;


    public HomeController(IAuthenticationService authenticationService, UserDbContext context)
    {
        _authenticationService = authenticationService;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        if (!_context.IsDatabaseConnected())
        {
            ViewBag.Error = "Unable to connect to the database. Please try again later.";
            return View("Error", "Home");
        }
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        try
        {
            if (!_context.IsDatabaseConnected())
            {
                ViewBag.Error = "Unable to connect to the database. Please try again later.";
                return View("Error", "Home");
            }

            var isAuthenticated = await _authenticationService.AuthenticateAsync(model.Username, model.Password);

            if (isAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Username or password is incorrect!";
                return View("Login"); 
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            ViewBag.Error = "An unexpected error occurred. Please try again.";
            return RedirectToAction("Login"); 
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


