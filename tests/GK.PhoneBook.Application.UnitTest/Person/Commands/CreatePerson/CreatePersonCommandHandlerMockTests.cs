using GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand;
using GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.UnitTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.UnitTest.Person.Commands.CreatePerson
{
    [TestClass]
    public class CreatePersonCommandHandlerMockTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CreatePersonCommandHandler _handler;
        private readonly CreatePersonCommandValidator _validator;
        private readonly CreatePersonCommandResponse _response;

        public CreatePersonCommandHandlerMockTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _handler = new CreatePersonCommandHandler(_mockUnitOfWork.Object);
            _validator = new CreatePersonCommandValidator(_mockUnitOfWork.Object);
            _response = new CreatePersonCommandResponse()
            {   
                Id = 4,
                Success = true,
                Message = "Person created"
            };
        }

        [TestMethod]
        public async Task Add_Success_ValidAllData()
        {
            var request = new CreatePersonCommandRequest()
            {
                FullName = "Deniz Küçük",
                PhoneNumber = "+905055550051",
                Address = "Uşak /Turkey",
                CompanyId = 1
            };
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);
        }

        [TestMethod]
        public async Task Add_Faild_InValidAllData()
        {
            var request = new CreatePersonCommandRequest()
            {
                FullName = "Dilan Küçük Dilan Küçük Dilan Küçük Dilan Küçük Dilan Küçük Dilan Küçük Dilan KüçükDilan Küçük Dilan Küçük ",
                PhoneNumber = "+9050555500599999999999",
                Address = "ABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHI ABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHI ABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHI ABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHIABCDEFGHHI",
                CompanyId = 6
            };
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);
        }

        [TestMethod]
        public async Task Add_Faild_OnlyPhoneNumberLessThanElevenCharacters()
        {
            var request = new CreatePersonCommandRequest()
            {
                FullName = "Cansu Küçük",
                PhoneNumber = "+905055",
                Address = "Denizli/Turkey",
                CompanyId = 1
            };
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);
        }

        [TestMethod]
        public async Task Add_Faild_OnlyEmptyAllData()
        {
            var request = new CreatePersonCommandRequest()
            {
                FullName = "",
                PhoneNumber = " ",
                Address = " ",
                CompanyId = 0
            };
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);
        }

        [TestMethod]
        public async Task Add_Faild_OnlyAddressEmpty()
        {
            var request = new CreatePersonCommandRequest()
            {
                FullName = "Cansu Küçük",
                PhoneNumber = "+905055550059",
                Address = "Denizli/Turkey",
                CompanyId = 1
            };
            var result = await _handler.Handle(request, CancellationToken.None);
            Assert.AreEqual(_response.Id, result.Id);
            Assert.AreEqual(_response.Success, result.Success);
            Assert.AreEqual(_response.Message, result.Message);
        }
    }
}
