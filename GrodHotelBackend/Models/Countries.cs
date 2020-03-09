using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrodHotelBackend.Models
{
    public class Countries
    {
        public int Id { get; set; }
        public ICollection<Cities> Cities { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}