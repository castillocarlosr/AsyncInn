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

        [Required]
        [Display(Name = "Room #:  ")]
        [Range(0, 1111, ErrorMessage = "Please enter valid integer Number")]
        public int RoomNumber { get; set; }

        //[ForeignKey("Room")]
        public int RoomID { get; set; }

        [Required]
        [DataType(DataType.Currency, ErrorMessage ="Please enter US currency only.  No BitCoin at this time.")]
        public decimal Rate { get; set; }

        public bool PetFriendly { get; set; }

        //Navigation Properties
        public Hotel Hotels { get; set; }

        public Room Rooms { get; set; }
    }
}
