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

        public bool BookBus(BookBusModel bookBusModel)
        {
            Booking booking = new Booking();
            booking.Quantity=bookBusModel.Seats;
            booking.CreatedDate=DateTime.Now;
            booking.BookedBy=bookBusModel.BookedBy;
            booking.BusId=bookBusModel.BusId;
            booking.Name=bookBusModel.Name;
            _context.Add(booking);
            return _context.SaveChanges() > 0;
        }
       

    }
}