using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrodHotelBackend.Models
{
    public class Bookings
    {
        public int Id { get; set; }

        [Required]
        public int ClientsId { get; set; }

        public Clients Clients { get; set; }
        public int? RoomsId { get; set; }
        public Rooms Rooms { get; set; }
        public ICollection<BookingsAgr> BookingsAgrs { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime LeavingDate { get; set; }

        [Required]
        [Column(TypeName = "Money")]
        public decimal TotalPrice { get; set; }

        [Required]
        public int AdultNumbers { get; set; }

        [Required]
        public int MinorNumbers { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ConfirmationDate { get; set; }
    }
}