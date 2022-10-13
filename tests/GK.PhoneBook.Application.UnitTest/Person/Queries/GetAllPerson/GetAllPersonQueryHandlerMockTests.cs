using GK.PhoneBook.Application.Dtos.Person;
using GK.PhoneBook.Application.Features.Persons.Commands.DeletePersonCommand;
using GK.PhoneBook.Application.Features.Persons.Queries.GetAllPersonQuery;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.UnitTest.Mocks;
using GK.PhoneBook.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.UnitTest.Person.Queries.GetAllPerson
{
    [TestClass]
    public class GetAllPersonQueryHandlerMockTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly GetAllPersonQueryHandler _handler;
        private readonly GetAllPersonQueryResponse _response;

        public GetAllPersonQueryHandlerMockTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _handler = new GetAllPersonQueryHandler(_mockUnitOfWork.Object);
            _response = new GetAllPersonQueryResponse()
            {
                Success = true
            };
        }

        [TestMethod]
        public async Task GetAll_Success_ExistIdInDatabase()
        {
            var request = new GetAllPersonQueryRequest()
            {
                QueryItem = "ren"
            };
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);
        }
    }
}
