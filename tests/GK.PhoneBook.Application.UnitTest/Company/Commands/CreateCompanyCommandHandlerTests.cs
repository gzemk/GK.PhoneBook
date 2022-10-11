using GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.UnitTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading;

namespace GK.PhoneBook.Application.UnitTest.Company.Commands
{
    [TestClass]
    public class CreateCompanyCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CreateCompanyCommandRequest _request;
        private readonly CreateCompanyCommandHandler _handler;
        private readonly CreateCompanyCommandValidator _validator;
        private readonly CreateCompanyCommandResponse _response;

        public CreateCompanyCommandHandlerTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _handler = new CreateCompanyCommandHandler(_mockUnitOfWork.Object);
            _request = new CreateCompanyCommandRequest
            {
                Name = "UnitTest Company",
                EmployeeCount = 15
            };
            _response = new CreateCompanyCommandResponse
            {
                Id = 4,
                Success = true,
                Message = "Company created"
            };
        }

        [TestMethod]
        public async Task Valid_Company_Added()
        {
            var result = await _handler.Handle(_request, CancellationToken.None);
            result.Success = true;
            result.Message = "Company created";
            result.Id = 4;
            Assert.AreEqual(_response, result);
        }

        [TestMethod]
        public async Task NonValid_CompanyNameLenght_Added()
        {
            _request.Name = "ABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHI";
            _request.EmployeeCount = 0;

            _response.Success = false;
            _response.Message = "Company was not created";

             var validator = _validator.Validate(_request);
           
            var result = await _handler.Handle(_request, CancellationToken.None);
            result.Success = false;
            result.Message = "Company was not created";
            result.Id = 3;
            Assert.AreEqual(_response, result);

        }

    }
}
