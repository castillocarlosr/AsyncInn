using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        [Display(Name = "Amenity: ")]
        public int AmenitiesID { get; set; }

        [Display(Name = "Room Name: ")]
        public int RoomID { get; set; }


        //Navigation Properties
        public Room Room { get; set; }

        public Amenities Amenity { get; set; }

        //Navigation Properties
        //public ICollection<Amenities> Amenities { get; set; }

        //public ICollection<Room> Rooms { get; set; }
    }
}
