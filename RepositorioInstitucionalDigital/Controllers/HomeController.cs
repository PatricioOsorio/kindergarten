using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositorioInstitucionalDigital.Models;
using System.Diagnostics;

namespace RepositorioInstitucionalDigital.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      _logger = logger;
      _userManager = userManager;
      _roleManager = roleManager;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
      var user = await _userManager.FindByEmailAsync("patriciomiguel_12@hotmail.com");

      if (user == null)
      {
        await _roleManager.CreateAsync(new IdentityRole("ADMIN"));
        await _roleManager.CreateAsync(new IdentityRole("SYSADMIN"));

        var newUser = new IdentityUser()
        {
          UserName = "Patricio",
          Email = "patriciomiguel_12@hotmail.com",
          EmailConfirmed = true
        };

        await _userManager.CreateAsync(newUser, "Pato123.");
        await _userManager.AddToRoleAsync(newUser, "SYSADMIN");

      }
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
}