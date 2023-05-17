using System;
using System.Collections.Generic;

namespace OBB.Data.Entities
{
    public partial class Booking
    {
        public int? Id { get; set; }
        public int? BusId { get; set; }
        public int? Quantity { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
