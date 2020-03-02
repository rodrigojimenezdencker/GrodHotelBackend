using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GrodHotelBackend.Models
{
    public class Searcher
    {
        private readonly Context _context;

        public Searcher(Context context)
        {
            _context = context;
        }

        public List<Rooms> Run(Filters filters)
        {
            var RoomsGeneralQuery = _context.Rooms
                .Include(x => x.Bookings)
                .Include(x => x.Hotels)
                .Where(room => room.Bookings.All(booking => filters.EntryDate < booking.EntryDate &&
                    booking.EntryDate > filters.LeavingDate ||
                    booking.EntryDate < filters.EntryDate &&
                    filters.EntryDate > booking.LeavingDate));


            //var RoomsGeneralQuery = _context.Bookings
            //    .Include(booking => booking.Rooms)
            //    .ThenInclude(room => room.Hotels)
            //    .Where(booking => (filters.EntryDate < booking.EntryDate &&
            //    booking.EntryDate > filters.LeavingDate) ||
            //    (booking.EntryDate < filters.EntryDate &&
            //    filters.EntryDate > booking.LeavingDate))
            //    .Select(booking => booking.Rooms);

            //List<Rooms> RoomsWithoutBookings = new List<Rooms>();
            //List<Rooms> RoomsWithPrice = new List<Rooms>();

            if (filters.MinimumPrice.HasValue)
            {
                RoomsGeneralQuery = RoomsGeneralQuery.Where(room => room.Price < filters.MaximumPrice && room.Price > filters.MinimumPrice);
            }

            return RoomsGeneralQuery.Where(x => x.Hotels.CitiesId == filters.City).ToList();
        }
    }

    /*public static class BookingExtension
    {
        public static bool Intersects(Bookings booking, Filters filters)
        {
            if (filters.EntryDate > booking.EntryDate && booking.EntryDate < filters.LeavingDate)
                return true;
            else if (booking.EntryDate > filters.EntryDate && filters.EntryDate < booking.EntryDate)
                return true;
            else return false;
        }
    }*/
}