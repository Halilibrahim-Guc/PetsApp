#nullable disable
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetOwner> PetOwner { get; set; }

        public Db(DbContextOptions options) : base(options) 
        {

        }
    }
}
