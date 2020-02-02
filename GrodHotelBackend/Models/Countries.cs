using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class Countries
    {
        public int Id { get; set; }
        public ICollection<Cities> Cities{ get; set; }
        public string Name { get; set; }
    }
}
