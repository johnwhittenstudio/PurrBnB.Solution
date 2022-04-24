namespace PurrBnB.Models
{
  public class DwellingPet
  {
    public int DwellingPetId { get; set; }
    public int PetId { get; set; }
    public virtual Pet Pet { get; set; }
    public int DwellingId { get; set; }
    public virtual Dwelling Dwelling { get; set; }
  }
}