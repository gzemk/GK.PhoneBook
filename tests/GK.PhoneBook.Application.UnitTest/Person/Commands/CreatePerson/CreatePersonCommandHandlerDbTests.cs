using GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand;
using GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand;
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

namespace GK.PhoneBook.Application.UnitTest.Person.Commands.CreatePerson
{
    [TestClass]
    public class CreatePersonCommandHandlerDbTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreatePersonCommandHandler _handler;
        private readonly CreatePersonCommandValidator _validator;

        public IConfiguration Configuration { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }

        public CreatePersonCommandHandlerDbTests()
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
            _handler = new CreatePersonCommandHandler(_unitOfWork);
            _validator = new CreatePersonCommandValidator(_unitOfWork);
        }

        [TestMethod]
        public async Task Person_Create()
        {
            //Arrange
            var request = new CreatePersonCommandRequest
            {
                FullName = "Bediye Doğan",
                PhoneNumber = "+905055550059",
                Address = "Muğla/Turkey",
                CompanyId =  1
            };
            var expected = new CreatePersonCommandResponse(){ Message = "Person was created" };

            //Act
            var result = await _handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Id);
            Assert.AreEqual(expected.Message, result.Message);
        }
    }

}
