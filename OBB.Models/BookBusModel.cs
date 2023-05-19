using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBB.Models
{
    public class BookBusModel
    {
        public int BusId { get; set; }
        public int BookedBy { get; set; }
        public int Seats { get; set; }
        public string Name{get;set;}
    }
}