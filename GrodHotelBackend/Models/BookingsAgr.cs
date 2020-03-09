using System.ComponentModel.DataAnnotations;

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