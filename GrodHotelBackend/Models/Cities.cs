using System.ComponentModel.DataAnnotations;

namespace GrodHotelBackend.Models
{
    public class Cities
    {
        public int Id { get; set; }

        [Required]
        public int CountriesId { get; set; }

        public Countries Countries { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}