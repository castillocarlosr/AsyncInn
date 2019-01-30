﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        //Create an Room
        Task CreateRoom(Room room);

        //Read Room
        Task<Room> GetRoom(int id);

        Task<IEnumerable<Room>> GetRoom();

        //Edit Amenities
        void EditRoom(Room room);

        //Delete Amenities
        void DeleteRoom(int id);
    }
}
