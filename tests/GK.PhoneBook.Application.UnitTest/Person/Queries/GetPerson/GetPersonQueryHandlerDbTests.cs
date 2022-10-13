using GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand;
using GK.PhoneBook.Application.Features.Persons.Queries.GetAllPersonQuery;
using GK.PhoneBook.Application.Features.Persons.Queries.GetPersonQuery;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.UnitTest.Person.Queries.GetPerson
{
    [TestClass]
    public class GetPersonQueryHandlerDbTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly GetPersonQueryHandler _handler;
        private readonly GetPersonQueryResponse _response;

        public IConfiguration Configuration { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }

        public GetPersonQueryHandlerDbTests()
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
            _handler = new GetPersonQueryHandler(_unitOfWork);
        }

        [TestMethod]
        public async Task Person_Get()
        {
            //Arrange
            var request = new GetPersonQueryRequest();

            //Act
            var result = await _handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Id);
        }
    }
}
