using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.ProductionEntities
{
    public partial class UserRolesJoin
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string IdentityRoleId { get; set; }
        public string IdentityUserId { get; set; }

        public virtual Roles IdentityRole { get; set; }
        public virtual Users IdentityUser { get; set; }
    }
}
