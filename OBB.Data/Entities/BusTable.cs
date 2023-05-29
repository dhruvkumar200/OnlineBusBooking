using System;
using System.Collections.Generic;

namespace OBB.Data.Entities
{
    public partial class BusTable
    {
        public BusTable()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string RouteFrom { get; set; } = null!;
        public string RouteTo { get; set; } = null!;
        public string Date { get; set; } = null!;
        public TimeSpan Time { get; set; }
        public int BusType { get; set; }
        public int Seats { get; set; }
        public string BusNo { get; set; } = null!;
        public int CreatedBy { get; set; }
        public int BookingId { get; set; }

        public virtual BusTypeTable BusTypeNavigation { get; set; } = null!;
        public virtual UserTable CreatedByNavigation { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
