using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace OBB.Models
{
    public class GetBusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RouteFrom { get; set; }
        public string RouteTo { get; set; }
        public TimeSpan Time { get; set; }
        public int? Seats { get; set; }
        public string BusNo{get; set;}
        public string Bustype{get;set;}
        public List<SelectListItem> BusTypeList{get;set;} 
        public int SelectedItem{get; set;}
        [DataType(DataType.Date)]
        public string Date { get; set; }
        public int CreatedBy{get;set;}
        public int ClaimId{get;set;}
        public int AvlbSeat {get; set;}
        public int BookedSeat{get;set;}
        public int Role{get;set;}
        public int Totalseat{get;set;}
        public int BusId{get; set;}
        public int PassangerName{get;set;}
        public int BookedSeats{get;set;}
        public int Email{get;set;}
        public string Password{get;set;}
        
    }
}