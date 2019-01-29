using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Layout Layouts { get; set; }

        public enum Layout
        {
            [Display(Name ="Open Studio")]
            Studio,
            OneBedroom,
            TwoBedroom
        }

        //Navigation
        public ICollection<HotelRoom> HotelRooms { get; set; }

        public ICollection<RoomAmenities> RoomAmenity { get; set; }
    }
}
