using System;
using System.Collections.Generic;

namespace OBB.Data.Entities
{
    public partial class UserRole
    {
        public int? UserId { get; set; }
        public int? RoleId { get; set; }

        public virtual RoleTable? Role { get; set; }
        public virtual UserTable? User { get; set; }
    }
}
