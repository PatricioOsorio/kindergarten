//using kindergaten.Models;
using kindergarten.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace kindergarten.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Usar modelos
    public DbSet<IdentityUser> User { get; set; }
    public DbSet<Student> Students { get; set; }
  }
}