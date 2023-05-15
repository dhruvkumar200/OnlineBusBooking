using System.ComponentModel.DataAnnotations;

namespace OBB.Models
{
    public class LoginModel
    {
        
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }
    }
}