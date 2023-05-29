using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OBB.Data.Entities;
using OBB.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace OBB.Repository
{
    public class BusRepository:IBusRepository
    {
        private readonly BookingDBContext _context;
        public BusRepository(BookingDBContext context)
        {
            _context = context;
        }
        public  bool AddBus(AddBusModel addBus)
        {
            BusTable bus = new BusTable();
            bus.Name = addBus.Name;
            bus.RouteFrom = addBus.RouteFrom;
            bus.RouteTo = addBus.RouteTo;
            bus.Time = addBus.Time;
            bus.BusNo=addBus.BusNo;
            bus.Seats=addBus.Seats;
            bus.BusType=addBus.BustypeId;
            bus.CreatedBy=addBus.CreatedBy;
            bus.Date=addBus.Date;
            _context.Add(bus);
            return  _context.SaveChanges() > 0;
             
        }
        public List<GetBusModel> GetBusList(int roleid)
        {
            
            var busInfo =_context.BusTables.Include(x=>x.BusTypeNavigation).Include(x=>x.CreatedByNavigation).Include(x=>x.Bookings).ToList();
            List <GetBusModel> busList=new List<GetBusModel>();
            if(busInfo!=null)
            {

            foreach(var item in busInfo)
            {

            GetBusModel getBus=new GetBusModel();
            getBus.Name=item.Name;
            getBus.BusNo=item.BusNo;
            getBus.Bustype=item.BusTypeNavigation.Types;
            getBus.CreatedBy=item.CreatedBy;
            getBus.Totalseat=item.Seats;
            getBus.BookedSeat= item.Bookings!=null ? item.Bookings.Sum(x=>x.Quantity):0;
            getBus.AvlbSeat= item.Seats-getBus.BookedSeat;
            getBus.ClaimId=roleid;
            getBus.Role=item.CreatedByNavigation.RoleId;
            getBus.RouteFrom=item.RouteFrom;
            getBus.RouteTo=item.RouteTo;
            getBus.Time=(TimeSpan)item.Time;
            getBus.Date=item.Date;
            getBus.BusId=item.Id;
            busList.Add(getBus);
            }
            }
            return busList;
            
        }
        public List<BusTypeTable> GetBusType()
        {
            
           return _context.BusTypeTables.ToList();
            
        }
        public bool DeleteBusInfo(int id)
        {
            var detail = _context.BusTables.FirstOrDefault(x => x.Id == id);
            if (detail != null)
            {
                _context.BusTables.Remove(detail);
                _context.SaveChanges();
            }
            return true;
        }
        public AddBusModel GetBusDetailById(int id)
        {
            var busdetailbyId = _context.BusTables.FirstOrDefault(x => x.Id == id);
            AddBusModel editbus=new AddBusModel();
            editbus.Name=busdetailbyId.Name;
            editbus.RouteFrom=busdetailbyId.RouteFrom;
            editbus.RouteTo=busdetailbyId.RouteTo;
            editbus.Time= (TimeSpan)busdetailbyId.Time;
            editbus.Seats=busdetailbyId.Seats;
            editbus.Date=(busdetailbyId.Date);
            editbus.BusNo=busdetailbyId.BusNo;
            editbus.BustypeId=busdetailbyId.BusType;
            editbus.CreatedBy=Convert.ToInt32(busdetailbyId.CreatedBy);
            return editbus;
        }
        public bool EditBusDetail(AddBusModel editbus)
        {
            BusTable bus=new BusTable();
            bus.Name=editbus.Name;
            bus.RouteFrom=editbus.RouteFrom;
            bus.RouteTo=editbus.RouteTo;
            bus.Time=editbus.Time;
            bus.Id=editbus.Id;
            bus.BusType=editbus.BustypeId;
            bus.BusNo=editbus.BusNo;
            bus.Seats=editbus.Seats;
            bus.Date=editbus.Date;
            bus.CreatedBy=editbus.CreatedBy;
            _context.BusTables.Update(bus);
            return _context.SaveChanges()>0;

        }
    }
}