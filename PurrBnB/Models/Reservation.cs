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
      // this.JoinEntities = new HashSet<Model1Model2>();
    }
//Fri sat 
// sun-th
    public int ReservationId { get; set; }
    public float TotalCost { get; set; }

    // public virtual ICollection<DwellingReservation> JoinDwellingReservation { get; set; }

    public virtual Dwelling Dwelling {get; set; } 
    public virtual ApplicationUser ApplicationUser {get; set; } // rentee
  }
}