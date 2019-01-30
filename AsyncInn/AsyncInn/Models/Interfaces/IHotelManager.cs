using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManager
    {
        //Create a Hotel
        Task CreateHotel(Hotel hotel);

        //Read Hotel
        Task<Hotel> GetHotel(int id);

        Task<IEnumerable<Hotel>> GetHotel();

        //Edit Hotel
        void EditHotel(Hotel hotel);

        //Delete Hotel
        void DeleteHotel(int id);
    }
}
