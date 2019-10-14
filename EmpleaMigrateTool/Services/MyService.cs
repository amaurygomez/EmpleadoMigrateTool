using System;
using System.Threading.Tasks;
using AutoMapper;
using EmpleaMigrateTool.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EmpleaMigrateTool.Services
{
 
        public class MyService : IMyService
        {

        IConfigurationRoot _config;

            private readonly ILogger<MyService> _logger;
        
          private readonly IMapper _mapper;

        public MyService(ILoggerFactory loggerFactory, IConfigurationRoot config,IMapper mapper)
            {

            _config = config;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<MyService>();
            }

     

        public async Task MyServiceMethod()
            {
                _logger.LogDebug("test");
            Menu();
            Console.ReadLine();
            }


        public void Menu ()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Welcome to the EmpleaDO Migration Tool");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Where you wanna test (Transfer Data From Production to Beta)?");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1- Local");
            Console.WriteLine("2- Azure");

            string input = Console.ReadLine();
            int selectedOption;
            Migrate migrate = new Migrate(_config,_mapper);
            if (int.TryParse(input, out selectedOption))
            {
                switch (selectedOption)
                {
                    case 1:
                        migrate.FromProductionToBeta();
                        break;
                    case 2:
                     
                        break;
                       
                }

            }
            else
            {
                Console.WriteLine("Debe ser una opcion valida.");
            }
        }
        }
    }

