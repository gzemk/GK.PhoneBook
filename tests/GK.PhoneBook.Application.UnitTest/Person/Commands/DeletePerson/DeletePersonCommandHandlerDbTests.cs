using GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand;
using GK.PhoneBook.Application.Features.Persons.Commands.DeletePersonCommand;
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

namespace GK.PhoneBook.Application.UnitTest.Person.Commands.DeletePerson
{
    [TestClass]
    public class DeletePersonCommandHandlerDbTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DeletePersonCommandHandler _handler;
        private readonly DeletePersonCommandValidator _validator;

        public IConfiguration Configuration { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }

        public DeletePersonCommandHandlerDbTests()
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
            _handler = new DeletePersonCommandHandler(_unitOfWork);
            _validator = new DeletePersonCommandValidator(_unitOfWork);
        }

        [TestMethod]
        public async Task Person_Delete()
        {
            //Arrange
            var request = new DeletePersonCommandRequest{ Id = 2001 };
            var expected = new DeletePersonCommandResponse() { Message = "Person was deleted" };

            //Act
            var result = await _handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(expected.Message, result.Message);
        }
    }
}
