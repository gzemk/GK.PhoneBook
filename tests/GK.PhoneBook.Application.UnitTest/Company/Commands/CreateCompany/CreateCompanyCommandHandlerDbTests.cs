using GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.UnitTest.Mocks;
using GK.PhoneBook.Infrastructure;
using GK.PhoneBook.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.UnitTest.Company.Commands.CreateCompany
{
    [TestClass]
    public class CreateCompanyCommandHandlerDbTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateCompanyCommandHandler _handler;
        private readonly CreateCompanyCommandValidator _validator;
        private readonly CreateCompanyCommandResponse _response;

        public IConfiguration Configuration { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }

        public CreateCompanyCommandHandlerDbTests()
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
             _handler = new CreateCompanyCommandHandler(_unitOfWork);
            _validator = new CreateCompanyCommandValidator(_unitOfWork);
            _response = new CreateCompanyCommandResponse()
            {
                Message = "Company was created"
            };
        }


        [TestMethod]
        public async Task Company_Add()
        {
            var request = new CreateCompanyCommandRequest
            {
                Name = "HÇGO Company",
                EmployeeCount = 15
            };
            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Id);
            Assert.AreEqual(_response.Message, result.Message);
        }

    }
}
