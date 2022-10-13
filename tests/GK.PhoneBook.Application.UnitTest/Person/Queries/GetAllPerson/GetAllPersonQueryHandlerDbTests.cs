using GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand;
using GK.PhoneBook.Application.Features.Persons.Queries.GetAllPersonQuery;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Infrastructure;
using GK.PhoneBook.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.UnitTest.Person.Queries.GetAllPerson
{
    [TestClass]
    public class GetAllPersonQueryHandlerDbTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly GetAllPersonQueryHandler _handler;

        public IConfiguration Configuration { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }
        public GetAllPersonQueryHandlerDbTests()
        {
            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var services = new ServiceCollection();
            services.ConfigureInfrastructureServices(Configuration);
            services.ConfigureApplicationServices();

            string connectionString = this.Configuration.GetConnectionString("PhoneBookConnectionString");

            services.AddDbContext<GK.PhoneBook.Infrastructure.PhoneBookDbContext>(options =>
               options.UseSqlServer(connectionString));

            ServiceProvider = services.BuildServiceProvider();

            _unitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
            _handler = new GetAllPersonQueryHandler(_unitOfWork);
        }

        [TestMethod]
        public async Task Person_GetAll()
        {
            //Arrange
            var request = new GetAllPersonQueryRequest();

            //Act
            var result = await _handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Persons.Count);
        }

        [TestMethod]
        public async Task Person_Search()
        {
            //Arrange
            var request = new GetAllPersonQueryRequest
            {
                QueryItem = "Mel"
            };

            //Act
            var result = await _handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Persons.Count);
        }
    }
}
