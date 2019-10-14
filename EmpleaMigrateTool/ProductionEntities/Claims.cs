using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.ProductionEntities
{
    public partial class Claims
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string IdentityUserId { get; set; }
        public string UserId { get; set; }

        public virtual Users IdentityUser { get; set; }
    }
}
