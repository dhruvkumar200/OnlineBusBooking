using System;
using System.Collections.Generic;

namespace OBB.Data.Entities
{
    public partial class RolesTable
    {
        public RolesTable()
        {
            UserTables = new HashSet<UserTable>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
