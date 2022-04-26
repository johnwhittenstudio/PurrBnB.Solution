namespace PurrBnB.Models
{
  public class DwellingReservation
  {       
    public int DwellingReservationId { get; set; }
    public int DwellingId { get; set; }
    public int ReservationId { get; set; }
    public float TotalCost { get; set; }
    public virtual Dwelling Dwelling{ get; set; }
    public virtual Reservation Reservation { get; set; }
  }
}