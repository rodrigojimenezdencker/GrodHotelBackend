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
                .Include(room => room.Bookings)
                .Include(booking => booking.Hotels)
                .Where(room => room.Bookings.All(booking => filters.EntryDate < booking.EntryDate &&
                    booking.EntryDate > filters.LeavingDate ||
                    booking.EntryDate < filters.EntryDate &&
                    filters.EntryDate > booking.LeavingDate) &&
                    room.Capacity >= (filters.AdultNumbers + filters.MinorNumbers));

            if (filters.MinimumPrice.HasValue)
            {
                RoomsGeneralQuery = RoomsGeneralQuery.Where(room => room.Price <= filters.MaximumPrice && room.Price >= filters.MinimumPrice);
            }

            return RoomsGeneralQuery.Where(room => room.Hotels.CitiesId == filters.City && room.Availability).ToList();
        }
    }
}