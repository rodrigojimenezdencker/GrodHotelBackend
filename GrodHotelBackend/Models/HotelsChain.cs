using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrodHotelBackend.Models
{
    public class HotelsChain
    {
        public int Id { get; set; }
        public ICollection<Hotels> Hotels { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public bool Availability { get; set; }
    }
}