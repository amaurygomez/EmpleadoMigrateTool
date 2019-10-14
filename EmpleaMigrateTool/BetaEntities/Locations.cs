using System;
using System.Collections.Generic;

namespace EmpleaMigrateTool.BetaEntities
{
    public partial class Locations
    {
        public int Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
