using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        //[ForeignKey("Amenities")]
        public int AmenitiesID { get; set; }

        //[ForeignKey("Room")]
        public int RoomID { get; set; }


        //Navigation Properties
        public Room Room { get; set; }

        public Amenities Amenity { get; set; }

        //Navigation Properties
        //public ICollection<Amenities> Amenities { get; set; }

        //public ICollection<Room> Rooms { get; set; }
    }
}
