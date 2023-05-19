using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using static OBB.Models.Common;

namespace OBB.Models
{
    public class AddBusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RouteFrom { get; set; }
        public string RouteTo { get; set; }
        public TimeSpan Time { get; set; }
        public int? Seats { get; set; }
        public string BusNo{get; set;}
        public int? BustypeId{get;set;}
        public List<SelectListItem> BusTypeList{get;set;} 
        public int SelectedItem{get; set;}
        [DataType(DataType.Date)]
        public string Date { get; set; }
        public int CreatedBy{get;set;}
    }
   
   
}