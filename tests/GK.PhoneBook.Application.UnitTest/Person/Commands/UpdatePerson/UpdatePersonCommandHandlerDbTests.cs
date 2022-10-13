using GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand;
using GK.PhoneBook.Application.Features.Persons.Commands.UpdatePersonCommand;
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

namespace GK.PhoneBook.Application.UnitTest.Person.Commands.UpdatePerson
{
    [TestClass]
    public class UpdatePersonCommandHandlerDbTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UpdatePersonCommandHandler _handler;
        private readonly UpdatePersonCommandValidator _validator;

        public IConfiguration Configuration { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }

        public UpdatePersonCommandHandlerDbTests()
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
            _handler = new UpdatePersonCommandHandler(_unitOfWork);
            _validator = new UpdatePersonCommandValidator(_unitOfWork);
        }

        [TestMethod]
        public async Task Person_Update()
        {
            //Arrange
            var request = new UpdatePersonCommandRequest
            {   
                Id = 1001,
                FullName = "Bediye Doğan",
                PhoneNumber = "+905055550059",
                Address = "Muğla/Turkey",
                CompanyId = 1
            };
            var expected = new UpdatePersonCommandResponse() { Message = "Person was updated" };

            //Act
            var result = await _handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Id);
            Assert.AreEqual(expected.Message, result.Message);
        }
    }
}
