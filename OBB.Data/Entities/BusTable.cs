using System;
using System.Collections.Generic;

namespace OBB.Data.Entities
{
    public partial class BusTable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? RouteFrom { get; set; }
        public string? RouteTo { get; set; }
        public string? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public int? BusType { get; set; }
        public int? Seats { get; set; }
        public string? BusNo { get; set; }
        public int? CreatedBy { get; set; }

        public virtual BusTypeTable? BusTypeNavigation { get; set; }
        public virtual UserTable? CreatedByNavigation { get; set; }
    }
}
