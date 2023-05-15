using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OBB.Business;
using OBB.Models;

namespace OBB.Web.Controllers
{

    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserBusiness _iUserBusiness;

        public UserController(ILogger<UserController> logger, IUserBusiness iUserBusiness)
        {
            _logger = logger;
            _iUserBusiness = iUserBusiness;
            

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddUserForm()
        {
            return View();
        }
        
        public IActionResult AddUser(AddUserModel addUser)
        {
            addUser.Password=BCrypt.Net.BCrypt.HashPassword(addUser.Password);
            _iUserBusiness.AddUser(addUser);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult LoginForm()
        {
            return View();  
        }
        public IActionResult Login(LoginModel loginModel)
        {
            var UserDetails = _iUserBusiness.GetUserDetailbyEmail(loginModel.Email);
            if (UserDetails != null && BCrypt.Net.BCrypt.Verify(loginModel.Password, UserDetails.Password))
            {
                var claims = new Claim[] { new Claim(ClaimTypes.Email, UserDetails.Email), new Claim(ClaimTypes.Role, UserDetails.RoleId.ToString()) };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                 var del=User.Identities.FirstOrDefault().Claims.ToList();
       
                if (UserDetails.RoleId == 1)
                {
                    return RedirectToAction("BusDetails", "Bus");
                }
                else
                {
                    return RedirectToAction("BusDetails", "Bus");
                }
            }
            else
            {
                ViewData["Errormsg"] = "Incorrect Email or Password";
                return View("LoginForm");
            }


        }
        [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyEmail(string email)
    {
        if (_iUserBusiness.VerifyEmail(email) == true)
        {
            return Json($"Email {email} is already in use.");
        }
        return Json(true);
    }

    public IActionResult Logout()
    {
        HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}