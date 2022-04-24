using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PurrBnB.Models
{
  public class Dwelling
  {
    public Dwelling()
    {
      // this.JoinEntities = new HashSet<DwellingPet>();
      // this.JoinEntities2 = new HashSet<DwellingReservation>();
    }

      public int DwellingId { get; set ; }
      public string DwellingOwnerName { get; set; }
      [Required]
      public string DwellingType { get; set;}
      [Required]

      public int DwellingPetId { get; set; }

      public bool GroundLevelAccess { get; set;}
      [Required]
      public bool Kitchen { get; set; }
      [Required]
      public int NumberOfPeopleAllowed { get; set; }
      [Required]
      public int Bedrooms { get; set; }
      [Required]
      public int Bathrooms { get; set; }
      [Required]
      public bool PrivateAccess { get; set; }
      [Required]
      public string Accomodations { get; set; }


      public virtual ApplicationUser User { get; set; }
      //public virtual ICollection<DwellingPet> JoinEntities {get; set; }
      //public virtual ICollection<DwellingReservation> JoinEntities2 {get; set; }
 
  }
}