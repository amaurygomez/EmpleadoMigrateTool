using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.ProductionEntities
{
    public partial class Roles
    {
        public Roles()
        {
            UserRolesJoin = new HashSet<UserRolesJoin>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserRolesJoin> UserRolesJoin { get; set; }
    }
}
