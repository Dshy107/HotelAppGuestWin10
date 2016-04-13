using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebservice2.DTO
{
    public class HotelRoomTypeDTO
    {
        /// <summary>
        /// Name of the hotel
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// room number
        /// </summary>
        public int Room_No { get; set; }

        /// <summary>
        /// types of the room ex Double : 'D'
        /// </summary>
        public string Types { get; set; }

        /// <summary>
        /// Price of the room pr night
        /// </summary>
        public double? Price { get; set; }

    }
}