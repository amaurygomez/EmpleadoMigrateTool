using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.ProductionEntities
{
    public partial class TagJobOpportunities
    {
        public int TagId { get; set; }
        public int JobOpportunityId { get; set; }

        public virtual JobOpportunities JobOpportunity { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
