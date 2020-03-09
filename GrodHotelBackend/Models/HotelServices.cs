using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrodHotelBackend.Models
{
    public class HotelServices
    {
        public int Id { get; set; }

        [Required]
        public int HotelsId { get; set; }

        public Hotels Hotels { get; set; }

        [Required]
        public int ServicesId { get; set; }

        public Services Services { get; set; }

        [Required]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [Required]
        public bool Availability { get; set; }
    }
}