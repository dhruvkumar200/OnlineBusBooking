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

    public BookingController(ILogger<BookingController> logger, IUserBusiness iUserBusiness, IBookingBusiness iBookingBusiness)
    {
        _logger = logger;
        _iUserBusiness = iUserBusiness;
        _iBookingBusiness = iBookingBusiness;
    }
    public IActionResult BookBusForm(int id)
    {
        BookBusModel bookBusModel = new BookBusModel();
        bookBusModel.BusId = id;
        return View(bookBusModel);
    }
    public IActionResult BookBus(BookBusModel bookBusModel)
    {
        var claims = User.Identities.First().Claims.ToList();
        bookBusModel.BookedBy = Convert.ToInt32(claims.FirstOrDefault(x => x.Type.Contains("UserData", StringComparison.OrdinalIgnoreCase))?.Value);

        var result = _iBookingBusiness.BookBus(bookBusModel);
        if (result != null)
        {
            TempData["Alert"] = "Seat Booked";
        }
        
        return RedirectToAction("BookBusForm");
    }



}



