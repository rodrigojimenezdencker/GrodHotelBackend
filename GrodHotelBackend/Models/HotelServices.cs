using System;
using System.Collections.Generic;
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
        public decimal Price { get; set; }
        public bool Availability { get; set; }
    }
}
