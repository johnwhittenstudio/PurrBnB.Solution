using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PurrBnB.Models
{
  public class PurrBnBContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Dwelling> Dwellings { get; set; }
    public DbSet<Dwelling> Images { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<DwellingPet> DwellingPet { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
     public DbSet<DwellingReservation> DwellingReservations { get; set; }

    public PurrBnBContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}