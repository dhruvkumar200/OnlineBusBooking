using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBB.Models
{
    public class EditBusModel
    {
        public string Name { get; set; }
        public string RouteFrom { get; set; }
        public string RouteTo { get; set; }
        public TimeSpan Time { get; set; }
    }
}