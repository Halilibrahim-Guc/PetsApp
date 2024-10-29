#nullable disable
using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Owner
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
    }
}
