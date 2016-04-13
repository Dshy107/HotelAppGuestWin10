namespace HotelRESTConsole
{
    using System;
    using System.Collections.Generic;
    public partial class Guest
    {
        public Guest()
        {
            Booking = new HashSet<Booking>();
        }

        public int Guest_No { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
