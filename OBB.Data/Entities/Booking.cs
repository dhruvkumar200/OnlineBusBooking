using System;
using System.Collections.Generic;

namespace OBB.Data.Entities
{
    public partial class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int BusId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BookedBy { get; set; }
        public string? PhoneNo { get; set; }

        public virtual BusTable Bus { get; set; } = null!;
    }
}
