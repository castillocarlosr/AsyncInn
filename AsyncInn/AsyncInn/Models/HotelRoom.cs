using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        //[ForeignKey("Hotel")]
        public int HotelID { get; set; }

        [Display(Name = "Room #:  ")]
        public int RoomNumber { get; set; }

        //[ForeignKey("Room")]
        public int RoomID { get; set; }

        [DataType(DataType.Currency)]
        public decimal Rate { get; set; }

        public bool PetFriendly { get; set; }

        //Navigation Properties
        public Hotel Hotels { get; set; }

        public Room Rooms { get; set; }
    }
}
