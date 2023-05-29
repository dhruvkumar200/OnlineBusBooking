using Microsoft.EntityFrameworkCore;
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
            // booking.BookedBy=bookBusModel.BookedBy;
            booking.BusId=bookBusModel.BusId;
            booking.Name=bookBusModel.Name;
            booking.PhoneNo=bookBusModel.PhoneNo;
            _context.Add(booking);
            return _context.SaveChanges() > 0;
        }
        public IEnumerable <Booking> GetBookingList(int id)
        {
           IEnumerable <Booking> bookinginfo =_context.Bookings.Where(x=>x.BusId==id).ToList();
            return bookinginfo;
        }

       
    }
}