using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OBB.Business;
using OBB.Models;
using OBB.Web.Models;
using static OBB.Models.Common;

namespace OBB.Web.Controllers;

public class BookingController : Controller
{
    private readonly ILogger<BookingController> _logger;
    private readonly IUserBusiness _iUserBusiness;
    private readonly IBookingBusiness _iBookingBusiness;
    private readonly IBusBusiness _iBusBusiness;

    public BookingController(ILogger<BookingController> logger, IUserBusiness iUserBusiness, IBookingBusiness iBookingBusiness, IBusBusiness iBusBusiness)
    {
        _logger = logger;
        _iUserBusiness = iUserBusiness;
        _iBookingBusiness = iBookingBusiness;
        _iBusBusiness = iBusBusiness;
    }
    public IActionResult BookBusForm(int id, int seat)
    {
      
        BookBusModel bookBusModel = new BookBusModel();
        bookBusModel.Availseat = seat;
        bookBusModel.BusId = id;

        return View(bookBusModel);
    }
    public IActionResult BookBus(BookBusModel bookBusModel)
    {
        var claims = User.Identities.First().Claims.ToList();
        bookBusModel.BookedBy = Convert.ToInt32(claims.FirstOrDefault(x => x.Type.Contains("UserData", StringComparison.OrdinalIgnoreCase))?.Value);
        if (bookBusModel.Seats > bookBusModel.Availseat)
        {
            TempData["Warn"] = "please decrese seat value ";
        }
        else
        {
            var result = _iBookingBusiness.BookBus(bookBusModel);

            if (result != null)
            {
                TempData["Alert"] = "Seat Booked";
            }
        }

        return RedirectToAction("BookBusForm");
    }
    public ActionResult GetBookingDetails(int id)
    {
        // Retrieve booking details based on the busId
        var bookingDetails = _iBookingBusiness.GetBookingList(id); // Fetch booking details from the database or another data source

        // Return the booking details as a partial view
        return View("BookingDetails", bookingDetails);
    }




}



