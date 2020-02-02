using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class Services
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
