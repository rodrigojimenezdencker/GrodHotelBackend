using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class HotelsChain
    {
        public int Id { get; set; }
        public ICollection<Hotels> Hotels{ get; set; }
        public string Name { get; set; }
        public bool Availability { get; set; }
    }
}
