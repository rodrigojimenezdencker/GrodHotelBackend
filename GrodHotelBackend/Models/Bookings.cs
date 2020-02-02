using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        public int ClientsId { get; set; }
        public Clients Clients { get; set; }
        public int RoomsId { get; set; }
        public Rooms Rooms { get; set; }
        public ICollection<BookingsAgr> BookingsAgrs{ get; set; }
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime LeavingDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int AdultNumbers { get; set; }
        public int MinorNumbers { get; set; }
        [DataType(DataType.Date)]
        public DateTime ConfirmationDate { get; set; }
    }
}
