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

            if (filters.MinimumPrice.HasValue)
            {
                RoomsGeneralQuery = RoomsGeneralQuery.Where(room => room.Price < filters.MaximumPrice && room.Price > filters.MinimumPrice);
            }

            return RoomsGeneralQuery.Where(x => x.Hotels.CitiesId == filters.City && x.Availability).ToList();
        }
    }
}