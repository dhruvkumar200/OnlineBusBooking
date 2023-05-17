using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OBB.Models
{
    public class AddUserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,6}", ErrorMessage = "Incorrect Email Format")]
        [EmailAddress]
        [Remote(action: "VerifyEmail", controller: "User")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Age")]
        public string Age { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "Required")]
        public string ? Phone { get; set; }
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]    
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
        
    }
}