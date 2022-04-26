using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurrBnB.Models
{
  public class Pet
  {
    public Pet()
    {
      this.JoinEntities = new HashSet<DwellingPet>();
    }

      [Key]
      [Column("PetId")]
      public int PetId { get; set ; }
      [Required]
      [Column("Name")]
      public string Name { get; set; }
      [Required]
      [Column("Age")]
      public int Age { get; set; }
      [Required]
      [Column("Color")]
      public string Color { get; set; }
      [Required]
      [Column("Interests")]
      public string Interests { get; set; }
      [Required]
      [Column("Favorite Toys")]
      public string FavoriteToys { get; set; }
      [Required]
      [Column("Schedule")]
      public string Schedule { get; set; }
      [Required]
      [Column("Personality")]
      public string Personality { get; set; }
      [Required]
      [Column("Species")]
      public string Species { get; set; }
      public virtual ApplicationUser User { get; set; }
      public virtual ICollection<DwellingPet> JoinEntities { get; }
 
  }
}