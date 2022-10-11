using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Domain.Entities;
using Moq;

namespace GK.PhoneBook.Application.UnitTest.Mocks
{
    public static class MockCompanyRepository
    {
        public static Mock<ICompanyRepository> GetCompanyRepository()
        {
            var companies = new List<GK.PhoneBook.Domain.Entities.Company>
            {
                new GK.PhoneBook.Domain.Entities.Company
                {
                    Id = 1,
                    Name  = "Purple Company",
                    EmployeeCount = 10
                },
                new GK.PhoneBook.Domain.Entities.Company
                {
                    Id = 2,
                    Name  = "Pink Company",
                    EmployeeCount = 15
                },
                 new GK.PhoneBook.Domain.Entities.Company
                {
                    Id = 3,
                    Name  = "White Company",
                    EmployeeCount = 20
                },
            };

            var mockRepository = new Mock<ICompanyRepository>();
            mockRepository.Setup(x => x.Add(It.IsAny<GK.PhoneBook.Domain.Entities.Company>())).ReturnsAsync((GK.PhoneBook.Domain.Entities.Company company) =>
            {
                companies.Add(company);
                return company;
            });

            return mockRepository;
        }
    }
}
