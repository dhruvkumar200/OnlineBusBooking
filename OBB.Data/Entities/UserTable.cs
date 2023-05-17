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
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNo { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual RolesTable Role { get; set; } = null!;
        public virtual ICollection<BusTable> BusTables { get; set; }
    }
}
