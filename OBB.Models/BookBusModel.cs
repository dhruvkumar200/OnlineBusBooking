using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OBB.Models
{
    public class BookBusModel
    {
        public int BusId { get; set; }
        public int BookedBy { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Seats { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
         [Required]
        [MaxLength(10)]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNo{get;set;}
        public int Availseat { get; set; }
    }
}