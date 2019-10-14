using System;
using AutoMapper;
using EmpleaMigrateTool.ProductionEntities;
using EmpleaMigrateTool.BetaEntities;

namespace EmpleaMigrateTool.Configurations.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<JobOpportunities, Jobs>();
            CreateMap<Jobs, JobOpportunities>();
        }
    }
}
