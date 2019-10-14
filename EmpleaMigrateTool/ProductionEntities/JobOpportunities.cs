using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.ProductionEntities
{
    public partial class JobOpportunities
    {
        public JobOpportunities()
        {
            TagJobOpportunities = new HashSet<TagJobOpportunities>();
        }

        public int JobOpportunityId { get; set; }
        public string Title { get; set; }
        public int? LocationId { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public string CompanyUrl { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyLogoUrl { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime Created { get; set; }
        public bool Approved { get; set; }
        public bool IsRemote { get; set; }
        public int ViewCount { get; set; }
        public int? JoelTestId { get; set; }
        public bool IsActive { get; set; }
        public int? JobOpportunityLocationId { get; set; }
        public int JobType { get; set; }
        public int? UserProfileId { get; set; }
        public string HowToApply { get; set; }
        public bool IsHidden { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }

        public virtual JobOpportunityLocations JobOpportunityLocation { get; set; }
        public virtual JoelTests JoelTest { get; set; }
        public virtual Locations Location { get; set; }
        public virtual UserProfiles UserProfile { get; set; }
        public virtual ICollection<TagJobOpportunities> TagJobOpportunities { get; set; }
    }
}
