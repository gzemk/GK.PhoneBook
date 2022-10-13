using GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand;
using GK.PhoneBook.Application.Features.Persons.Commands.DeletePersonCommand;
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
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.UnitTest.Person.Commands
{
    [TestClass]
    public class PersonCommandTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreatePersonCommandHandler _createHandler;
        private readonly CreatePersonCommandValidator _createValidator;
        private readonly UpdatePersonCommandHandler _updateHandler;
        private readonly UpdatePersonCommandValidator _updateValidator;
        private readonly DeletePersonCommandHandler _deleteHandler;
        private readonly DeletePersonCommandValidator _deleteValidator;

        public IConfiguration Configuration { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }

        public PersonCommandTest()
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
            _createHandler = new CreatePersonCommandHandler(_unitOfWork);
            _createValidator = new CreatePersonCommandValidator(_unitOfWork);
            _updateHandler = new UpdatePersonCommandHandler(_unitOfWork);
            _updateValidator = new UpdatePersonCommandValidator(_unitOfWork);
            _deleteHandler = new DeletePersonCommandHandler(_unitOfWork);
            _deleteValidator = new DeletePersonCommandValidator(_unitOfWork);
        }

        [TestMethod]
        public async Task Person_Create_Update_Delete()
        {
            #region create 

            //Arrange 
            var createRequest = new CreatePersonCommandRequest
            {
                FullName = "Hatice Doğan",
                PhoneNumber = "+905055550059",
                Address = "Muğla/Turkey",
                CompanyId = 1
            };
            var createExpected = new CreatePersonCommandResponse() { Message = "Person created" };

            //Act
            var createResult = await _createHandler.Handle(createRequest, CancellationToken.None);

            //Assert
            Assert.IsTrue(createResult.Success);
            Assert.IsNotNull(createResult.Id);
            Assert.AreEqual(createExpected.Message, createResult.Message);

            #endregion
            await Task.Delay(3000);
            #region update
            //Arrange 
            var updateRequest = new UpdatePersonCommandRequest
            {
                Id = createResult.Id,
                FullName = "Bediye Doğan",
                PhoneNumber = "+905055550059",
                Address = "Eskişehir/Turkey",
                CompanyId = 2
            };
            var updateExpected = new UpdatePersonCommandResponse() { Message = "Person updated" };

            //Act
            var updateResult = await _updateHandler.Handle(updateRequest, CancellationToken.None);

            //Assert
            Assert.IsTrue(updateResult.Success);
            Assert.IsNotNull(updateResult.Id);
            Assert.AreEqual(updateResult.Message, updateResult.Message);

            #endregion

            await Task.Delay(3000);
            #region delete
            //Arrange 
            var deleteRequest = new DeletePersonCommandRequest { Id = updateResult.Id };
            var deleteExpected = new DeletePersonCommandResponse() { Message = "Person deleted" };

            //Act
            var deleteResult = await _deleteHandler.Handle(deleteRequest, CancellationToken.None);

            //Assert
            Assert.IsTrue(deleteResult.Success);
            Assert.AreEqual(deleteResult.Message, deleteResult.Message);

            #endregion


        }
    }
}
