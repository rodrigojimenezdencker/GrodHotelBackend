using Microsoft.EntityFrameworkCore;

namespace GrodHotelBackend.Models
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<HotelsChain> HotelsChain { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<BookingsAgr> BookingsAgr { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<HotelServices> HotelServices { get; set; }
        public virtual DbSet<Comodities> Comodities { get; set; }
        public virtual DbSet<RoomComodities> RoomComodities { get; set; }
    }
}