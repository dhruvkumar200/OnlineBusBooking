using OBB.Data.Entities;
using OBB.Models;

namespace OBB.Business
{
    public interface IBookingBusiness
    {
        bool BookBus(BookBusModel bookBusModel);
    }
}