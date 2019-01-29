using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Hotel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Full Address")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        //Navigation Properties
        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
