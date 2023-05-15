using System;
using System.Collections.Generic;

namespace OBB.Data.Entities
{
    public partial class UserTable
    {
        public UserTable()
        {
            BusTables = new HashSet<BusTable>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public string? PhoneNo { get; set; }
        public int? RoleId { get; set; }

        public virtual ICollection<BusTable> BusTables { get; set; }
    }
}
