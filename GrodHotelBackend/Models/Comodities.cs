﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Models
{
    public class Comodities
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string Name { get; set; }
    }
}
