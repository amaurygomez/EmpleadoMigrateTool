using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.ProductionEntities
{
    public partial class Locations
    {
        public Locations()
        {
            JobOpportunities = new HashSet<JobOpportunities>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<JobOpportunities> JobOpportunities { get; set; }
    }
}
