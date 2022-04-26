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
  public class ReservationsControllers : Controller
  {
     private readonly PurrBnBContext _db;
     private readonly UserManager<ApplicationUser> _userManager;
     public ReservationsControllers(PurrBnBContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      // return View(_db.Reservations.ToList());
      List<Reservation> model = _db.Reservations.ToList();
      Console.WriteLine("We're in the Reservations Index!");
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.DwellingId = new SelectList(_db.Dwellings, "DwellingId", "DwellingName");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Reservation reservation, int DwellingId)
    {
      _db.Reservations.Add(reservation);
      _db.SaveChanges();
      if (DwellingId != 0)
      {
        _db.DwellingReservations.Add(new DwellingReservation() {DwellingId = DwellingId, ReservationId = reservation.ReservationId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Reservation foundReservation = _db.Reservations
        .Include(reservation => reservation.DwellingReservation)
        .ThenInclude(join => join.Dwelling)
        .FirstOrDefault(model => model.ReservationId == id);
      ViewBag.DwellingId = new SelectList(_db.Dwellings, "DwellingId", "DwellingName");
      return View(foundReservation);
    }
    public ActionResult Edit(int id)
    {
      var foundReservation = _db.Reservations.FirstOrDefault(reservation => reservation.ReservationId == id);
      ViewBag.DoctorId = new SelectList(_db.Dwellings, "DwellingId", "DwellingName");
      return View(foundReservation);
    }
    [HttpPost]
    public ActionResult Edit(Reservation reservation, int DwellingId)
    {
      if (DwellingId !=0)
      {
        _db.DwellingReservations.Add(new DwellingReservation() {DwellingId = DwellingId, ReservationId = reservation.ReservationId});        
      }
      _db.Entry(reservation).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      Reservation foundReservation = _db.Reservations.FirstOrDefault(reservation => reservation.ReservationId == id);
      return View(foundReservation);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Reservation foundReservation = _db.Reservations.FirstOrDefault(reservation => reservation.ReservationId == id);
      _db.Reservations.Remove(foundReservation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult AddDwelling(Reservation reservation, int DwellingId)
    {
      bool isDuplicate = _db.DwellingReservations.Any(join => join.DwellingId == DwellingId && join.ReservationId == reservation.ReservationId);
      if (DwellingId !=0 && isDuplicate == false)
      {
        _db.DwellingReservations.Add(new DwellingReservation() {DwellingId = DwellingId, ReservationId = reservation.ReservationId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = reservation.ReservationId});
    }
    [HttpPost]
    public ActionResult DeleteDwelling(int joinId)
    {
      var joinEntry = _db.DwellingReservations.FirstOrDefault(entry => entry.DwellingReservationId == joinId);
      int savedReservation = joinEntry.ReservationId;
      _db.DwellingReservations.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = savedReservation});
    }






  }
}