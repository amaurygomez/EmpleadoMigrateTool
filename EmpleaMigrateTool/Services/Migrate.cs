using System;
using System.Linq;
using AutoMapper;
using EmpleaMigrateTool.Infra.SqlServer;
using EmpleaMigrateTool.BetaEntities;
using Microsoft.Extensions.Configuration;

namespace EmpleaMigrateTool
{
    public class Migrate
    {
        private readonly IConfigurationRoot _config;
        private readonly IMapper _mapper;

        public Migrate(IConfigurationRoot config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }


        public void FromProductionToBeta()
        {
            var prodConnectionString = _config["ConnectionStrings:emplea-do-prod.local"];
            var betaConnectionString = _config["ConnectionStrings:emplea-do-beta.local"];
            var prodContext = new ProductionDbContext(prodConnectionString);
            var betaContext = new BetaDbContext(betaConnectionString);
            var JobOpportunities = prodContext.JobOpportunities.ToList();
            var model = _mapper.Map<Jobs>(JobOpportunities);

            Console.Write("Validating and updating data...");

        }

        public void FromBetaToProduction()
        {

        }

    }
}
