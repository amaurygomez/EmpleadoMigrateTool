using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.BetaEntities
{
    public partial class Permissions
    {
        public int Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
    }
}
