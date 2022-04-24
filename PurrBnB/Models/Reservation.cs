using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurrBnB.Models
{
  // [Table("Reservation")]
  public class Reservation
  {
    public Reservation()
    {
      // this.JoinEntities = new HashSet<Model1Model2>();
    }

    // [Key]
    // [Column("ReservationId")]
    public int ReservationId { get; set; }
    // [Required]
    // [Column("Start Date")]
    public DateTime StartDate { get; set; }
    // [Required]
    // [Column("End Date")]
    public DateTime EndDate { get; set; }
    // [Required]
    // [Column("Cost Per Night")]
    public float CostPerNight { get; set; }
    // public virtual ICollection<Model1Model2> JoinEntities { get; set; }
  }
}