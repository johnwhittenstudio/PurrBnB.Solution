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
using System.Runtime.Serialization.Json;  
using GoogleMaps.LocationServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
      // List<Dwelling> model = _db.Dwellings.OrderBy(dwelling => dwelling.DwellingOwnerName).ToList();
      List<Dwelling> model = _db.Dwellings.OrderBy(x => x.DwellingName).ToList();
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
      dwelling.User = currentUser;
      var longitude = await ApiHelper.GeocodeLong(EnvironmentVariables.ApiKeyGeo, dwelling);
      dwelling.DwellingLong = longitude;
      var lat = await ApiHelper.GeocodeLat(EnvironmentVariables.ApiKeyGeo, dwelling);
      dwelling.DwellingLat = lat;
      _db.Dwellings.Add(dwelling);
      _db.SaveChanges();

      if (PetId != 0)
      {
   //     _db.DwellingPets.Add(new DwellingPet() { PetId = PetId, DwellingId = dwelling.DwellingId});
     //     _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisDwelling = _db.Dwellings
          .Include(dwelling => dwelling.JoinEntities)
          .ThenInclude(join => join.Pet)
          .FirstOrDefault(dwelling => dwelling.DwellingId == id);
      return View(thisDwelling);
    }

    public ActionResult Edit(int id)
    {
      var thisDwelling = _db.Dwellings.FirstOrDefault(dwelling => dwelling.DwellingId == id);
      ViewBag.PetId = new SelectList(_db.Pets, "PetId", "Name");
      return View(thisDwelling);
    }

    [HttpPost]
    public ActionResult Edit(Dwelling dwelling, int PetId)
    {
      if (PetId != 0)
      {
        _db.DwellingPet.Add(new DwellingPet() { PetId = PetId, DwellingId = dwelling.DwellingId});
      }
      _db.Entry(dwelling).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  
    public ActionResult AddPet(int id)
    {
      var thisDwelling = _db.Dwellings.FirstOrDefault(dwelling => dwelling.DwellingId == id);
      ViewBag.PetId = new SelectList(_db.Pets, "PetId", "Name");
      return View(thisDwelling);
    }

    [HttpPost]
    public ActionResult AddPet(Dwelling dwelling, int PetId)
    {
      if (PetId != 0)
      {
        _db.DwellingPet.Add(new DwellingPet() { PetId = PetId, DwellingId = dwelling.DwellingId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisDwelling = _db.Dwellings.FirstOrDefault(dwelling => dwelling.DwellingId == id);
      return View(thisDwelling);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDwelling = _db.Dwellings.FirstOrDefault(dwelling => dwelling.DwellingId == id);
      _db.Dwellings.Remove(thisDwelling);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeletePet(int joinId)
    {
      var joinEntry = _db.DwellingPet.FirstOrDefault(entry => entry.DwellingPetId == joinId);
      _db.DwellingPet.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}