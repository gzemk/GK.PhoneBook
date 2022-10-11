using GK.PhoneBook.API.Controllers;
using GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GK.PhoneBook.API.UnitTest
{
    [TestClass]
    public class CompanyControllerTests
    {
        private readonly Mock<IMediator> mediatrmock;
        private readonly IMediator mediatr;
        private readonly ILogger<CompanyController> logger;
        private readonly CompanyController companyController;
        private readonly CreateCompanyCommandRequest _request;
        private readonly CreateCompanyCommandResponse _response;
        public CompanyControllerTests()
        {
            mediatrmock = new Mock<IMediator>();
            companyController = new CompanyController(mediatr, logger);
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
        public void Add(CreateCompanyCommandRequest request)
        {
            //act 
            var actionResul = companyController.CreateCompany(request).Result;

            actionResul.Equals(actionResul);

            //result.Success = true;
            //result.Message = "Company created";
            //result.Id = 4;
            //Assert.AreEqual(_response, result);
        }
    }
}