namespace HotelWebservice2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ViewHotelContext : DbContext
    {
        public ViewHotelContext()
            : base("name=ViewHotelContext")
        {
        }

        public virtual DbSet<View_PriceBookingGuest> View_PriceBookingGuest { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<View_PriceBookingGuest>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
