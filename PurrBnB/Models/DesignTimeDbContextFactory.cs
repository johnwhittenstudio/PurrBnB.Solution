using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PurrBnB.Models
{
  public class PurrBnBContextFactory : IDesignTimeDbContextFactory<PurrBnBContext>
  {
    PurrBnBContext IDesignTimeDbContextFactory<PurrBnBContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<PurrBnBContext>();
      
      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new PurrBnBContext(builder.Options);
    }
  }
}