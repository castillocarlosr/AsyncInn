using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        //Create an Amenities
        Task CreateAmenities(Amenities amenities);

        //Read Amenities
        Task<Amenities> GetAmenities(int id);

        Task<IEnumerable<Amenities>> GetAmenities();

        //Edit Amenities
        Task EditAmenities(Amenities amenities);

        //Delete Amenities
        Task DeleteAmenities(int id);
    }
}
