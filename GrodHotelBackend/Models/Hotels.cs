using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class Hotels
    {
        public int Id { get; set; }
        [Required]
        public int HotelsChainId { get; set; }
        public HotelsChain HotelsChain { get; set; }
        public ICollection<Rooms> Rooms { get; set; }
        [Required]
        public int CitiesId { get; set; }
        public Cities Cities{ get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        public bool Trending { get; set; }
        [Required]
        public bool Availability { get; set; }
        public string Image { get; set; }
        public string SmallImage { get; set; }
    }
}
