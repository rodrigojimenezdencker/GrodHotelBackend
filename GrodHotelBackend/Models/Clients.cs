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
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public bool Subscribed { get; set; }
        public string Comments { get; set; }
    }
}
