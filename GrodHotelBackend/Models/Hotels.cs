using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class Hotels
    {
        public int Id { get; set; }
        public int HotelsChainId { get; set; }
        public HotelsChain HotelsChain { get; set; }
        public ICollection<Rooms> Rooms { get; set; }
        public int CitiesId { get; set; }
        public Cities Cities{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Trending { get; set; }
        public bool Availability { get; set; }
    }
}
