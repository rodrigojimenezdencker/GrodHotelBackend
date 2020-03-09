using System.ComponentModel.DataAnnotations;

namespace GrodHotelBackend.Models
{
    public class Comodities
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }
    }
}