using OBB.Data.Entities;
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
       






    }
}