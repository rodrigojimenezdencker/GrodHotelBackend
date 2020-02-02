using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class HotelServices
    {
        public int Id { get; set; }
        public int HotelsId { get; set; }
        public Hotels Hotels { get; set; }
        public int ServicesId { get; set; }
        public Services Services { get; set; }
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public bool Availability { get; set; }
    }
}
