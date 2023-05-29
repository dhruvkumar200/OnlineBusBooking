using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OBB.Data.Entities;
using OBB.Models;

namespace OBB.Business
{
    public interface IBusBusiness
    {
         public List<GetBusModel> GetBusList(int roleid);
        bool AddBus(AddBusModel addBusModel);
        bool DeleteBusInfo(int id);
        AddBusModel GetBusDetailById(int id);
        public bool EditBusDetail(AddBusModel editbus);
        public List<BusTypeTable> GetBusType();
    }
}