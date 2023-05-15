using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OBB.Business;
using OBB.Models;
using OBB.Web.Models;

namespace OBB.Web.Controllers;

public class BookingController : Controller
{
    private readonly ILogger<BookingController> _logger;
    private readonly IUserBusiness _iUserBusiness;
    private readonly IBookingBusiness _iBookingBusiness;

    public BookingController(ILogger<BookingController> logger,IUserBusiness iUserBusiness,IBookingBusiness iBookingBusiness)
    {
        _logger = logger;
         _iUserBusiness = iUserBusiness;
         _iBookingBusiness=iBookingBusiness;
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
