using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.BetaEntities
{
    public partial class Logins
    {
        public int Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}
