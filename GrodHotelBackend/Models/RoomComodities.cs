using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class RoomComodities
    {
        public int Id { get; set; }
        public int RoomsId { get; set; }
        public Rooms Rooms { get; set; }
        public int ComoditiesId { get; set; }
        public Comodities Comodities { get; set; }
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public bool Availability { get; set; }
    }
}
