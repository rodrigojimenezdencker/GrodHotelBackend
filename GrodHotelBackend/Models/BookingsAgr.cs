using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class BookingsAgr
    {
        public int Id { get; set; }
        public int BookingsId { get; set; }
        public Bookings Bookings { get; set; }
        public int BookingAgrTypeId { get; set; }
        public int ComoditieServicesId { get; set; }
    }
}
