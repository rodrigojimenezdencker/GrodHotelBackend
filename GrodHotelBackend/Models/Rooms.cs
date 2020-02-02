using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class Rooms
    {
        public int Id { get; set; }
        public int HotelsId { get; set; }
        public Hotels Hotels { get; set; }
        [Column(TypeName = "Money")]
        public decimal Dimensions { get; set; }
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public bool Availability { get; set; }
    }
}
