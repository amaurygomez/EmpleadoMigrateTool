using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.ProductionEntities
{
    public partial class Tags
    {
        public Tags()
        {
            TagJobOpportunities = new HashSet<TagJobOpportunities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<TagJobOpportunities> TagJobOpportunities { get; set; }
    }
}
