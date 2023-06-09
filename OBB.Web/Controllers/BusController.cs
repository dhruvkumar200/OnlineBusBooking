using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OBB.Business;
using OBB.Data.Entities;
using OBB.Models;


namespace OBB.Web.Controllers
{
    public class BusController : Controller
    {
        private readonly ILogger<BusController> _logger;
        private readonly IUserBusiness _iUserBusiness;
        private readonly IBusBusiness _iBusBusiness;
        private readonly IBookingBusiness _iBookingBusiness;

        public BusController(ILogger<BusController> logger, IUserBusiness iUserBusiness, IBusBusiness iBusBusiness ,IBookingBusiness iBookingBusiness)
        {
            _logger = logger;
            _iUserBusiness = iUserBusiness;
            _iBusBusiness = iBusBusiness;
            _iBookingBusiness=iBookingBusiness;
        }


        [HttpPost]
        
        public IActionResult AddBusDetail(AddBusModel addBusModel)
        {
            var bustype = addBusModel.BusTypeList;
            var claims = User.Identities.First().Claims.ToList();
            int Id = Convert.ToInt32(claims.FirstOrDefault(x => x.Type.Contains("UserData", StringComparison.OrdinalIgnoreCase))?.Value);
            addBusModel.CreatedBy = Id;
            _iBusBusiness.AddBus(addBusModel);
            return RedirectToAction("BusDetails", "Bus");
        }
        
        public IActionResult BusDetails()
        {
            var claims = User.Identities.First().Claims.ToList();
            // var claimRole=claims.FirstOrDefault(x=>x.Type.Contains("Role", StringComparison.OrdinalIgnoreCase))?.Value;
            int RoleId = Convert.ToInt32(claims.FirstOrDefault(x => x.Type.Contains("Role", StringComparison.OrdinalIgnoreCase))?.Value);

            var BusDetails = _iBusBusiness.GetBusList(RoleId);
            if (BusDetails != null)
            {
                return View(BusDetails);
            }
            return RedirectToAction("AddBusForm", "Bus");
        }
       [AuthorizeRoles(Common.Role.Admin)]
        public IActionResult AddBusForm()
        {
            var types = _iBusBusiness.GetBusType();
            if (types != null && types.Any())
            {
                List<SelectListItem> lstType = new List<SelectListItem>();
                foreach (var type in types)
                {
                    lstType.Add(new SelectListItem
                    {
                        Value = Convert.ToString(type.Id),
                        Text = type.Types
                    });
                }
                ViewBag.Types = lstType;
            }
            else
            {
                ViewBag.types = new List<SelectListItem>();
            }

            return View();
        }
    
        public IActionResult EditBus(int id)
        {
            var types = _iBusBusiness.GetBusType();
            if (types != null && types.Any())
            {
                List<SelectListItem> lstType = new List<SelectListItem>();
                foreach (var type in types)
                {
                    lstType.Add(new SelectListItem
                    {
                        Value = Convert.ToString(type.Id),
                        Text = type.Types
                    });
                }
                ViewBag.Types = lstType;
            }
            else
            {
                ViewBag.types = new List<SelectListItem>();
            }

            AddBusModel busModel = _iBusBusiness.GetBusDetailById(id);
            return View(busModel);

        }
        public IActionResult EditBusDetail(AddBusModel editbus)
        {
            var claims = User.Identities.First().Claims.ToList();
            int Id = Convert.ToInt32(claims.FirstOrDefault(x => x.Type.Contains("UserData", StringComparison.OrdinalIgnoreCase))?.Value);
            editbus.CreatedBy = Id;
            var editedbusdetail = _iBusBusiness.EditBusDetail(editbus);
            return RedirectToAction("BusDetails", "Bus");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}