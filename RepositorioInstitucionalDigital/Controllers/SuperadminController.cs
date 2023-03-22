using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using kindergarten.Data;
using kindergarten.Models;
using Microsoft.EntityFrameworkCore;

namespace kindergarten.Controllers
{
  [Authorize(Roles = "SUPERADMIN")]
  public class SuperadminController : Controller
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SuperadminController(UserManager<IdentityUser> userManager, ApplicationDbContext context,
        RoleManager<IdentityRole> roleManager)
    {
      _userManager = userManager;
      _context = context;
      _roleManager = roleManager;
    }

    public async Task<IActionResult> IndexAsync()
    {
      return View(await _userManager.Users.ToListAsync());
    }

  }
}
