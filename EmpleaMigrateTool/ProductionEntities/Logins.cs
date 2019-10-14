using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.ProductionEntities
{
    public partial class Logins
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string IdentityUserId { get; set; }

        public virtual Users IdentityUser { get; set; }
    }
}
