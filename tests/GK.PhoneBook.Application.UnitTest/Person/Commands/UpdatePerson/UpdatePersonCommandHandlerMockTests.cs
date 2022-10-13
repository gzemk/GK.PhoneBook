using GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand;
using GK.PhoneBook.Application.Features.Persons.Commands.UpdatePersonCommand;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.UnitTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.UnitTest.Person.Commands.UpdatePerson
{
    [TestClass]
    public class UpdatePersonCommandHandlerMockTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly UpdatePersonCommandHandler _handler;
        private readonly UpdatePersonCommandValidator _validator;
        private readonly UpdatePersonCommandResponse _response;

        public UpdatePersonCommandHandlerMockTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _handler = new UpdatePersonCommandHandler(_mockUnitOfWork.Object);
            _validator = new UpdatePersonCommandValidator(_mockUnitOfWork.Object);
            _response = new UpdatePersonCommandResponse()
            {
                Id = 2,
                Success = true,
                Message = "Person was updated"
            };
        }

        [TestMethod]
        public async Task Update_Success_ValidAllData()
        {
            var request = new UpdatePersonCommandRequest()
            {
                Id = 2,
                FullName = "Gül Yılmaz",
                PhoneNumber = "+905055550051",
                Address = "Sapanca /Turkey",
                CompanyId = 1
            };
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);
        }
    }
}
