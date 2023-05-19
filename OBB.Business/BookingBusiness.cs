using OBB.Data.Entities;
using OBB.Models;
using OBB.Repository;

namespace OBB.Business
{
    public class BookingBusiness : IBookingBusiness
    {
        public readonly IBookingRepository _iBookingRepository;
        public BookingBusiness(IBookingRepository iBookingRepository)
        {
            _iBookingRepository = iBookingRepository;
        }

        public bool BookBus(BookBusModel bookBusModel)
        {
            return _iBookingRepository.BookBus(bookBusModel);
        }
    }
}