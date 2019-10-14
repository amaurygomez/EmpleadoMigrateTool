using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.BetaEntities
{
    public partial class Jobs
    {
        public int Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string HowToApply { get; set; }
        public int ViewCount { get; set; }
        public int Likes { get; set; }
        public bool IsRemote { get; set; }
        public bool IsHidden { get; set; }
        public bool Approved { get; set; }
        public DateTime PublishedDate { get; set; }
        public int CategoryId { get; set; }
        public int? CompanyId { get; set; }
        public int HireTypeId { get; set; }
        public int? JoelTestId { get; set; }
        public int? LocationId { get; set; }
    }
}
