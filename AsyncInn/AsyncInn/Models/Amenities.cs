using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Amenities
    {
        public int ID { get; set; }

        [Display(Name="Name of Amenity")]
        [Required]
        public string Name { get; set; }

        //Navigation Properties
        public ICollection<RoomAmenities> RoomAmenity { get; set; }
        //public ICollection<RoomAmenities> RoomAmenitiess { get; set; }
    }
}
