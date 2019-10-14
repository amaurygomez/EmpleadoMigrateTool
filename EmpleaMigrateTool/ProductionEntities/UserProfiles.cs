using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.ProductionEntities
{
    public partial class UserProfiles
    {
        public UserProfiles()
        {
            JobOpportunities = new HashSet<JobOpportunities>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<JobOpportunities> JobOpportunities { get; set; }
    }
}
