namespace HotelWebservice2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ViewPsykopatContext2 : DbContext
    {
        public ViewPsykopatContext2()
            : base("name=ViewPsykopatContext2")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<View_psykopatQuery> View_psykopatQuery { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<View_psykopatQuery>()
                .Property(e => e.Types)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<View_psykopatQuery>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
