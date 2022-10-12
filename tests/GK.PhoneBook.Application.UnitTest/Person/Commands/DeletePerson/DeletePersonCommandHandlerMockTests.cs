using GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand;
using GK.PhoneBook.Application.Features.Persons.Commands.DeletePersonCommand;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.UnitTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.UnitTest.Person.Commands.DeletePerson
{
    [TestClass]
    public class DeletePersonCommandHandlerMockTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly DeletePersonCommandHandler _handler;
        private readonly DeletePersonCommandValidator _validator;
        private readonly DeletePersonCommandResponse _response;

        public DeletePersonCommandHandlerMockTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _handler = new DeletePersonCommandHandler(_mockUnitOfWork.Object);
            _validator = new DeletePersonCommandValidator(_mockUnitOfWork.Object);
            _response = new DeletePersonCommandResponse()
            {
                Id = 4,
                Success = true,
                Message = "Person deleted."
            };
        }

        [TestMethod]
        public async Task Delete_Success_ExistIdInDatabase()
        {
            var request = new DeletePersonCommandRequest()
            {
                Id=4
            };
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);
        }
    }
}
