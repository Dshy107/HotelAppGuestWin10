namespace HotelRESTConsole
{
    using System;
    using System.Collections.Generic;

    public partial class Hotel
    {
        public Hotel()
        {
            Room = new HashSet<Room>();
        }

        public int Hotel_No { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
