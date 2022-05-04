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
  public class ReservationsController : Controller
  {
    private readonly PurrBnBContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public ReservationsController(UserManager<ApplicationUser> UserManager, PurrBnBContext db)
    {
      _userManager = UserManager;
      _db = db;
    }

    public ActionResult Index()
    {
      List<Reservation> model = _db.Reservations.OrderBy(x => x.ReservationId).ToList();
      return View(model);
    }
    [Authorize]
    public async Task<ActionResult> Create()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      ViewBag.DwellingId = new SelectList(_db.Dwellings, "DwellingId", "DwellingName");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Reservation reservation, int DwellingId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);

      _db.Reservations.Add(reservation);
      _db.SaveChanges();
      float dwellingCost = _db.Dwellings.FirstOrDefault(dwelling => dwelling.DwellingId == DwellingId).CostPerNight;

      if (DwellingId != 0)
      {
        _db.DwellingReservations.Add(new DwellingReservation() { DwellingId = DwellingId, ReservationId = reservation.ReservationId, CostPerNight = dwellingCost });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
    [Authorize]
    public ActionResult Details(int id)
    {
      var thisReservation = _db.Reservations
        .Include(reservation => reservation.JoinEntities2)
        .ThenInclude(join => join.Dwelling)
        .FirstOrDefault(reservation => reservation.ReservationId == id);
      //ViewBag.Dwellings = _db.Dwellings.Where(entry = entry.DwellingId))
      return View(thisReservation);
    }
    [Authorize]
    public ActionResult Edit(int id)
    {
      var thisReservation = _db.Reservations.FirstOrDefault(reservation => reservation.ReservationId == id);
      ViewBag.DwellingId = new SelectList(_db.Dwellings, "DwellingId", "DwellingName");
      return View(thisReservation);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(Reservation reservation, int DwellingId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      // _db.Entry(reservation).State = EntityState.Modified;
      // _db.SaveChanges();
      bool duplicate = _db.DwellingReservations.Any(join => join.DwellingId == DwellingId && join.ReservationId == reservation.ReservationId);
      if (DwellingId != 0 && !duplicate)
      {
        _db.DwellingReservations.Add(new DwellingReservation() { DwellingId = DwellingId, ReservationId = reservation.ReservationId });
      }
      _db.Entry(reservation).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [Authorize]
    public ActionResult Delete(int id)
    {
      var thisReservation = _db.Reservations.FirstOrDefault(reservation => reservation.ReservationId == id);
      return View(thisReservation);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisReservation = _db.Reservations.FirstOrDefault(reservation => reservation.ReservationId == id);
      _db.Reservations.Remove(thisReservation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}