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
        [Required(ErrorMessage = "Name is empty!")]
        [StringLength(20, ErrorMessage = "The name has the capacity for 20 characters or less!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is empty!")]
        [StringLength(40, ErrorMessage = "The surname has the capacity for 40 characters or less!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "BirthDate is empty!")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "DNI is empty!")]
        [StringLength(9, ErrorMessage = "The DNI has the capacity for 9 characters or less!")]
        public string Dni { get; set; }
        [StringLength(50, ErrorMessage = "The email has the capacity for 50 characters or less!")]
        public string Email { get; set; }
        [Required]
        public bool Subscribed { get; set; }
        [StringLength(200, ErrorMessage = "The comment has the capacity for 200 characters or less!")]
        public string Comments { get; set; }
    }
}
