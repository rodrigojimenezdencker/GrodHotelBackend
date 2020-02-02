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
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(40)]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(10)]
        public string Dni { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        public bool Subscribed { get; set; }
        [StringLength(200)]
        public string Comments { get; set; }
    }
}
