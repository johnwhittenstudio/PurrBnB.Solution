using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurrBnB.Models
{
  public class Reservation
  {
    public Reservation()
    {
      this.JoinEntities = new HashSet<Dwelling>();
    }

    public int ReservationId { get; set; }
    public string ReservationName { get; set; }
    public float TotalCost { get; set; }

    // public virtual ICollection<DwellingReservation> JoinDwellingReservation { get; set; }

    public virtual ICollection<Dwelling> JoinEntities {get; set; } 
    public virtual ApplicationUser ApplicationUser {get; set; } 
  }
}