﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Hotel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Full Address")]
        public string Address { get; set; }

        public string Phone { get; set; }

        //Navigation Properties
        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
