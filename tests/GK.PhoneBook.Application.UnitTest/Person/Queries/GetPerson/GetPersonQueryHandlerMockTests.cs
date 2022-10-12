using GK.PhoneBook.Application.Features.Persons.Queries.GetAllPersonQuery;
using GK.PhoneBook.Application.Features.Persons.Queries.GetPersonQuery;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.UnitTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GK.PhoneBook.Application.UnitTest.Person.Queries.GetPerson
{
    [TestClass]
    public class GetPersonQueryHandlerMockTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly GetPersonQueryHandler _handler;
        private readonly GetPersonQueryResponse _response;

        public GetPersonQueryHandlerMockTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _handler = new GetPersonQueryHandler(_mockUnitOfWork.Object);
            _response = new GetPersonQueryResponse()
            {
                Success = true,
                Id = 2,
                FullName = "Ceren Küçük",
                PhoneNumber = "+905055550056",
                Address = "Buca/Izmir/Turkey",
                CompanyName = "Pink Company"
            };
        }

        [TestMethod]
        public async Task GetPerson_Success_RandomPerson()
        {
            var request = new GetPersonQueryRequest();
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.FullName, result.FullName);
            Assert.AreEqual(_response.Address, result.Address);
            Assert.AreEqual(_response.PhoneNumber, result.PhoneNumber);
            Assert.AreEqual(_response.CompanyName, result.CompanyName);
        }

    }
}
