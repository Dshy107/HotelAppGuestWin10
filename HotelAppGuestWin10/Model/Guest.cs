namespace HotelAppGuestWin10.Model
{
    using System;
    using System.Collections.Generic;
    public partial class Guest
    {
        public Guest()
        {
            //Booking = new HashSet<Booking>();
        }

        public int Guest_No { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return Guest_No + " : " + Name;
        }

        public string GuestDetails
        {
            get {return   Guest_No + " " + Name + " " + Address + "";}
        }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Booking> Booking { get; set; }
    }
}
