using Microsoft.Extensions.DependencyInjection;
using PetShop2018.Core.ApplicationService;
using PetShop2018.Core.ApplicationService.Services;
using PetShop2018.Core.DomainService;
using PetShop2018.Infrastructure.Data.Repositories;
using PetShop2018.Printer;
using System;

namespace PetShop2018
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, PetPrinter>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();

            printer.InitiateMainMenu();
        }
    }
}
