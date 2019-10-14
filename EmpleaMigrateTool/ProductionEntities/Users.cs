using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.ProductionEntities
{
    public partial class Users
    {
        public Users()
        {
            Claims = new HashSet<Claims>();
            Logins = new HashSet<Logins>();
            UserRolesJoin = new HashSet<UserRolesJoin>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<Claims> Claims { get; set; }
        public virtual ICollection<Logins> Logins { get; set; }
        public virtual ICollection<UserRolesJoin> UserRolesJoin { get; set; }
    }
}
