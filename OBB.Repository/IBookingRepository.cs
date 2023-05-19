using OBB.Data.Entities;
using OBB.Models;

namespace OBB.Repository
{
    public interface IBookingRepository
    {
    public bool BookBus(BookBusModel bookBusModel);
    }
}