using System;
using System.Collections.Generic;

namespace OBB.Data.Entities
{
    public partial class BusTypeTable
    {
        public BusTypeTable()
        {
            BusTables = new HashSet<BusTable>();
        }

        public int Id { get; set; }
        public string? Types { get; set; }

        public virtual ICollection<BusTable> BusTables { get; set; }
    }
}
