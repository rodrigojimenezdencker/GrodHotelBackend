using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrodHotelBackend.Models
{
    public class Rooms
    {
        public int Id { get; set; }

        [Required]
        public int HotelsId { get; set; }

        public Hotels Hotels { get; set; }
        public decimal Dimensions { get; set; }

        [Required]
        public int Price { get; set; }

        public int Capacity { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public bool Availability { get; set; }

        public string Image { get; set; }
        public string SmallImage { get; set; }

        [Required]
        [StringLength(100)]
        public string Slug { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
        public virtual ICollection<RoomComodities> RoomComodities { get; set; }
    }
}