using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class Cities
    {
        public int Id { get; set; }
        public int CountriesId { get; set; }
        public Countries Countries{ get; set; }
        public string Name { get; set; }
    }
}
