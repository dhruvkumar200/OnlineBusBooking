using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OBB.Data.Entities;
using OBB.Models;
using OBB.Repository;

namespace OBB.Business
{
    public class BusBusiness : IBusBusiness
    {
        public readonly IBusRepository _iBusRepository;
        public BusBusiness(IBusRepository iBusRepository)
        {
            _iBusRepository = iBusRepository;
        }
        public List<BusTable> GetBusList()
        {
            return _iBusRepository.GetBusList();
        }
        public bool AddBus(AddBusModel addBusModel)
        {
            return _iBusRepository.AddBus(addBusModel);
        }
        public bool DeleteBusInfo(int id)
        {
            return _iBusRepository.DeleteBusInfo(id);
        }
        public AddBusModel GetBusDetailById(int id)
        {
            return _iBusRepository.GetBusDetailById(id);
        }
        public bool EditBusDetail(AddBusModel editbus)
        {
            return _iBusRepository.EditBusDetail(editbus);
        }

    }
}