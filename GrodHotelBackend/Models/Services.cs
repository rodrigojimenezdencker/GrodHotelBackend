﻿using System.ComponentModel.DataAnnotations;

namespace GrodHotelBackend.Models
{
    public class Services
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}