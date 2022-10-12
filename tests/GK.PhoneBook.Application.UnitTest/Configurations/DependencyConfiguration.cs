using GK.PhoneBook.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace GK.PhoneBook.Application.UnitTest.Configurations
{
    public class DependencyConfiguration
    {
        public IConfiguration Configuration { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }

        public DependencyConfiguration()
        {
            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var services = new ServiceCollection();
            services.ConfigureInfrastructureServices(Configuration);
            services.ConfigureApplicationServices();

            string connectionString = this.Configuration.GetConnectionString("PhoneBookConnectionString");

            services.AddDbContext<GK.PhoneBook.Infrastructure.PhoneBookDbContext>(options =>
               options.UseSqlServer(connectionString));

            ServiceProvider = services.BuildServiceProvider();  
        }
    }
}
