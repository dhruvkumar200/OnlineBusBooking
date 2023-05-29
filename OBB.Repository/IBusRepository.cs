using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OBB.Data.Entities;
using OBB.Models;

namespace OBB.Repository
{
    public interface IBusRepository
    {
        bool AddBus(AddBusModel addBus);
        public List<GetBusModel> GetBusList(int roleid);
        bool DeleteBusInfo(int id);
        AddBusModel GetBusDetailById(int id);
        public bool EditBusDetail(AddBusModel editbus);
        public List<BusTypeTable> GetBusType();
    }
}