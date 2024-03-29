﻿using GK.PhoneBook.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.UnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockPersonRepo = MockPersonRepository.GetPersonRepository();
            var mockCompanyRepo = MockCompanyRepository.GetCompanyRepository();

            mockUnitOfWork.Setup(x => x.PersonRepository).Returns(mockPersonRepo.Object);
            mockUnitOfWork.Setup(x => x.CompanyRepository).Returns(mockCompanyRepo.Object);

            return mockUnitOfWork;
        }
    }
}
