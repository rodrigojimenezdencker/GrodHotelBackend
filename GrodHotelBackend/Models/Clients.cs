using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class Clients
    {
        public int Id { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(40)]
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [StringLength(8)]
        public string Dni { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public bool Subscribed { get; set; }
        [StringLength(200)]
        public string Comments { get; set; }
    }
}
