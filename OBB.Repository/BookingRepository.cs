using OBB.Data.Entities;
using OBB.Models;

namespace OBB.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDBContext _context;
        public BookingRepository(BookingDBContext context)
        {
            _context = context;
        }

        
       

    }
}