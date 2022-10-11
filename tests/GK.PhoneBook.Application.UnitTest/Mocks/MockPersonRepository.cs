using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.UnitTest.Mocks
{
    public static class MockPersonRepository
    {
        public static Mock<IPersonRepository> GetPersonRepository()
        {
            var persons = new List<GK.PhoneBook.Domain.Entities.Person>
            {
                new GK.PhoneBook.Domain.Entities.Person
                {
                    Id = 1,
                    FullName = "Gizem Küçük",
                    PhoneNumber = "+905055550055",
                    Address = "Bornova/Izmir/Turkey",
                    CompanyId = 1
                },
                  new GK.PhoneBook.Domain.Entities.Person
                {
                    Id = 1,
                    FullName = "Ceren Küçük",
                    PhoneNumber = "+905055550056",
                    Address = "Buca/Izmir/Turkey",
                    CompanyId = 1
                },
                    new GK.PhoneBook.Domain.Entities.Person
                {
                    Id = 1,
                    FullName = "Anıl Küçük",
                    PhoneNumber = "+905055550057",
                    Address = "Narlıdere/Izmir/Turkey",
                    CompanyId = 1
                }
            };

            var mockRepository = new Mock<IPersonRepository>();
            mockRepository.Setup(x => x.GetAll()).Returns(persons);
            mockRepository.Setup(x => x.Add(It.IsAny<GK.PhoneBook.Domain.Entities.Person>()))
                .ReturnsAsync((GK.PhoneBook.Domain.Entities.Person person) =>
            {
                persons.Add(person);
                return person;
            });

            return mockRepository;
        }
    }
}
