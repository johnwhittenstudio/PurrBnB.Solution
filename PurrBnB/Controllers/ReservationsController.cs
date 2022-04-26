using PurrBnB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace PurrBnB.Controllers
{
  public class ReservationsControllers : Controller
  {
     private readonly PurrBnBContext _db;
     public ReservationsControllers(PurrBnBContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Reservations.ToList());
    }
    public ActionResult Create()
    {
      ViewBag.DwellingId = new SelectList(_db.Dwellings, "DwellingId", "Name");
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
      ViewBag.DwellingId = new SelectList(_db.Dwellings, "DwellingId", "Name");
      return View(foundReservation);
    }
    public ActionResult Edit(int id)
    {
      var foundReservation = _db.Reservations.FirstOrDefault(reservation => reservation.ReservationId == id);
      ViewBag.DoctorId = new SelectList(_db.Dwellings, "DwellingId", "Name");
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




  }
}