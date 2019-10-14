using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.ProductionEntities
{
    public partial class JobOpportunityLocations
    {
        public JobOpportunityLocations()
        {
            JobOpportunities = new HashSet<JobOpportunities>();
        }

        public int Id { get; set; }
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual ICollection<JobOpportunities> JobOpportunities { get; set; }
    }
}
