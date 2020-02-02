using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class RoomComodities
    {
        public int Id { get; set; }
        [Required]
        public int RoomsId { get; set; }
        public Rooms Rooms { get; set; }
        [Required]
        public int ComoditiesId { get; set; }
        public Comodities Comodities { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        [Required]
        public bool Availability { get; set; }
    }
}
