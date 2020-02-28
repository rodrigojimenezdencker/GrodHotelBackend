using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

            
            /* IQueryable<Rooms> rooms = from hotel in _context.Hotels
                        join room in _context.Rooms
                        on hotel.Id equals room.HotelsId
                        join booking in _context.Bookings
                        on room.Id equals booking.RoomsId
                        where hotel.CitiesId == filters.City 
                        && room.Availability
                        select room; */

            var rooms2 = _context.Bookings
            .Include(x => x.Rooms).ThenInclude(x => x.Hotels)
            .Where(x => x.Rooms.Hotels.CitiesId == filters.City && 
                (filters.EntryDate < x.EntryDate && 
                x.EntryDate > filters.LeavingDate) ||
                (x.EntryDate < filters.EntryDate && 
                filters.EntryDate > x.LeavingDate))
            .Select(x => x.Rooms);

            return rooms2.ToList();
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
