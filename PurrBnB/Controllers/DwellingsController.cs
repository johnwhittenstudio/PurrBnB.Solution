using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;
using PurrBnB.Models;

namespace PurrBnB.Controllers
{
  public class DwellingsController : Controller
  {
    private readonly PurrBnBContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public DwellingsController(UserManager<ApplicationUser> UserManager, PurrBnBContext db)
    {
      _userManager = UserManager;
      _db = db;
    }


    public ActionResult Index()
    {
      List<Dwelling> model = _db.Dwellings.OrderBy(dwelling => dwelling.DwellingOwnerName).ToList();
      return View(model);
    }

    [Authorize]
    public async Task<ActionResult> Create()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      //ViewBag.PetId = new SelectList(_db.Pets.OrderBy(pet => pet.Name), "PetId", "Name");
      ViewBag.GroundLevelAccess = new SelectList(_db.Dwellings, "GroundLevelAccess", "GroundLevelAccess");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Dwelling dwelling, int PetId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);

      _db.Dwellings.Add(dwelling);
      _db.SaveChanges();

      if (PetId != 0)
      {
   //     _db.DwellingPets.Add(new DwellingPet() { PetId = PetId, DwellingId = dwelling.DwellingId});
     //     _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

  }
}