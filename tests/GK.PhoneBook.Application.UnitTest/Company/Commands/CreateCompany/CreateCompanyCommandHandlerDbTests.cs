using GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.UnitTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.UnitTest.Company.Commands.CreateCompany
{
    [TestClass]
    public class CreateCompanyCommandHandlerDbTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateCompanyCommandRequest _request;
        private readonly CreateCompanyCommandHandler _handler;
        private readonly CreateCompanyCommandValidator _validator;
        private readonly CreateCompanyCommandResponse _response;

        public CreateCompanyCommandHandlerDbTests()
        {
        }
    }
}
