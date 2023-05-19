using System;
using System.Collections.Generic;

namespace OBB.Data.Entities
{
    public partial class Booking
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? BusId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? BookedBy { get; set; }

        public virtual UserTable? BookedByNavigation { get; set; }
        public virtual BusTable? Bus { get; set; }
    }
}
