#nullable disable

using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Pet
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsFemale { get; set; }

        public DateTime? BirthDate { get; set; }

        public decimal? Height { get; set; }

        public decimal? Width { get; set; }

        public int? SpeciesId { get; set; }

        public Species Species { get; set; } // navigational property

        public List<PetOwner> PetOwners { get; set; } = new List<PetOwner>();
    }
}
