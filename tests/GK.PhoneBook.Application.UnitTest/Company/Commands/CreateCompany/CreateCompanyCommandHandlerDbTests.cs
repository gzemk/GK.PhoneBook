using GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.UnitTest.Configurations;
using GK.PhoneBook.Application.UnitTest.Mocks;
using GK.PhoneBook.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
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
        public CreateCompanyCommandHandlerDbTests(DependencyConfiguration dependencyConfiguration)
        {
            _unitOfWork = dependencyConfiguration.ServiceProvider.GetRequiredService<IUnitOfWork>();  
            _handler = new CreateCompanyCommandHandler(_unitOfWork);
            _validator = new CreateCompanyCommandValidator(_unitOfWork);
            _response = new CreateCompanyCommandResponse()
            {
                Id = 4,
                Success = true,
                Message = "Company created"
            };
        }

        [TestMethod]
        public async Task Company_Add()
        {
            var request = new CreateCompanyCommandRequest
            {
                Name = "UnitTest1234 Company",
                EmployeeCount = 15
            };
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);
        }

    }
}
