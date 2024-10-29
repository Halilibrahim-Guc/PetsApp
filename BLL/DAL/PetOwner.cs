#nullable disable
namespace BLL.DAL
{
    public class PetOwner
    {
        public int ID {  get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public List<PetOwner> PetOwners { get; set; } = new List<PetOwner>();

    }
}
