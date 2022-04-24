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


namespace  PurrBnB.Controllers
{
  public class PetsController: Controller
{
  private readonly PurrBnBContext _db;
  public PetsController(PurrBnBContext db)
  {
    _db = db;
  }
  public ActionResult Index()
    {
      return View(_db.Pets.ToList());
    }
    public ActionResult Create()
    {
      ViewBag.DwellingId = new SelectList(_db.Dwellings, "DwellingId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Pet pet, int DwellingId)
    {
      _db.Pets.Add(pet);
      _db.SaveChanges();
      if (DwellingId != 0)
      {
        // _db.s.Add(new DwellingPet() {DwellingId = DwellingId, PetId = pet.PetId});
        // _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
}
