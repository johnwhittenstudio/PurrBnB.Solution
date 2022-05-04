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
      List<Pet> model = _db.Pets.OrderBy(x => x.Name).ToList();
      return View(model);
    }
    [Authorize]
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
    [Authorize]
    public ActionResult Details(int id)
    {
      var thisPet = _db.Pets
          .Include(pet => pet.JoinEntities)
          .ThenInclude(join => join.Dwelling)
          .FirstOrDefault(pet => pet.PetId == id);
      return View(thisPet);
    }

    [Authorize]
    public ActionResult Edit(int id)
    {
      var thisPet = _db.Pets.FirstOrDefault(pet => pet.PetId == id);
      return View(thisPet);
    }

    [HttpPost]
    public ActionResult Edit(Pet pet)
    {
      _db.Entry(pet).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [Authorize]
    public ActionResult Delete(int id)
    {
      var thisPet = _db.Pets.FirstOrDefault(pet => pet.PetId == id);
      return View(thisPet);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPet = _db.Pets.FirstOrDefault(pet => pet.PetId == id);
      _db.Pets.Remove(thisPet);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
