using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class Filters
    {
        [DataType(DataType.Date)]
        public DateTime EntyDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime LeavingDate { get; set; }
        public int AdultNumbers { get; set; }
        public int MinorNumbers { get; set; }
        public decimal MinimumPrice { get; set; }
        public decimal MaximumPrice { get; set; }
        public string City { get; set; }
    }
}
