using GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.UnitTest.Mocks;
using GK.PhoneBook.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading;

namespace GK.PhoneBook.Application.UnitTest.Company.Commands.CreateCompany
{
    [TestClass]
    public class CreateCompanyCommandHandlerMockTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CreateCompanyCommandHandler _handler;
        private readonly CreateCompanyCommandValidator _validator;
        private readonly CreateCompanyCommandResponse _response;

        public CreateCompanyCommandHandlerMockTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            _handler = new CreateCompanyCommandHandler(_mockUnitOfWork.Object);

            _validator = new CreateCompanyCommandValidator(_mockUnitOfWork.Object);

            _response = new CreateCompanyCommandResponse()
            { 
                Id = 4,
                Success = true,
                Message = "Company created"
            };
        }

        [TestMethod]
        public async Task Add_Success_NameNotInDatabaseAndEmployeeCountGreaterThanZero()
        {
            var request  = new CreateCompanyCommandRequest
            {
                Name = "UnitTest1234 Company",
                EmployeeCount = 15
            };
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);
        }

        [TestMethod]
        public async Task Add_Fail_NameInDatabaseAndEmployeeCountGreaterThanZero()
        {
            var request = new CreateCompanyCommandRequest
            {
                Name = "Purple Company",
                EmployeeCount = 15
            };
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);
        }

        [TestMethod]
        public async Task Add_Fail_NameIsEmptyAndEmployeeCountGGreaterThanZero()
        {
            var request = new CreateCompanyCommandRequest
            {
                Name = " ",
                EmployeeCount = 15
            };
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);
        }

        [TestMethod]
        public async Task Add_Fail_NameNotInDatabaseAndEmployeeCountIsZero()
        {
            var request = new CreateCompanyCommandRequest
            {
                Name = "Brown Company",
                EmployeeCount = 0
            };
            //var validator = _validator.Validate(request);
            var result = await _handler.Handle(request, CancellationToken.None);


            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);

        }

        [TestMethod]
        public async Task Add_Fail_NameGratherThanAHundredCharactersAndEmployeeCountGreaterThanZero()
        {
            var request = new CreateCompanyCommandRequest
            {
                Name = "ABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHI ABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHI",
                EmployeeCount = 15
            };
            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);

        }

        [TestMethod]
        public async Task Add_Fail_NameGratherThanAHundredCharactersAndEmployeeCountEqual()
        {
            var request = new CreateCompanyCommandRequest
            {
                Name = "ABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHI ABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHI",
                EmployeeCount = 0
            };
            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);
        }
    }
}
