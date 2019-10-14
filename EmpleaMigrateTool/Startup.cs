using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using EmpleaMigrateTool.Configurations.Mapping;
using EmpleaMigrateTool.Common.Interfaces;
using EmpleaMigrateTool.Services;

namespace EmpleaMigrateTool
{
    public class Startup
    {

        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton(Configuration);

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddTransient<IMyService, MyService>();
            services.AddSingleton<AutoMapper.IConfigurationProvider>(mappingConfig);
            services.AddTransient<IMapper, Mapper>();
        }
    }
}
