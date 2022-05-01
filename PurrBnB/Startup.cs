using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using PurrBnB.Models;
using Microsoft.AspNetCore.Identity;





namespace PurrBnB
{
  public class Startup
  {
    public Startup(IWebHostEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
    }

    public Startup(IHostEnvironment env)
    {
      _env = env;
    }

    private IHostEnvironment _env;

    public IConfigurationRoot Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddEntityFrameworkMySql()
        .AddDbContext<PurrBnBContext>(options => options
        .UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));

      var physicalProvider = _env.ContentRootFileProvider;

      services.AddSingleton<IFileProvider>(
        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img"))
      );

      services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<PurrBnBContext>()
                .AddDefaultTokenProviders();
      services.Configure<IdentityOptions>(options =>

    {
      options.Password.RequireDigit = false;
      options.Password.RequiredLength = 0;
      options.Password.RequireLowercase = false;
      options.Password.RequireNonAlphanumeric = false;
      options.Password.RequireUppercase = false;
      options.Password.RequiredUniqueChars = 0;
    });
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();

      app.UseAuthentication();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(routes =>
      {
        routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
      });

      app.UseStaticFiles();

      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Oopsies! Hey there, our bad! Please go back to previous screen.");
      });
    }
  }
}
