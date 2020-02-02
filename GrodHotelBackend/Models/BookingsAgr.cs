using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class BookingsAgr
    {
        public int Id { get; set; }
        [Required]
        public int BookingsId { get; set; }
        public Bookings Bookings { get; set; }
        [Required]
        public int BookingAgrTypeId { get; set; }
        [Required]
        public int ComoditieServicesId { get; set; }
    }
}
