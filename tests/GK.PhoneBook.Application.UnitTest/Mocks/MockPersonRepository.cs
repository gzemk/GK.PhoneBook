using GK.PhoneBook.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
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
                    FullName = "Gizem Yılmaz",
                    PhoneNumber = "+905055550055",
                    Address = "Bornova/Izmir/Turkey",
                    CompanyId = 1
                },
                  new GK.PhoneBook.Domain.Entities.Person
                {
                    Id = 2,
                    FullName = "Ceren Yılmaz",
                    PhoneNumber = "+905055550056",
                    Address = "Buca/Izmir/Turkey",
                    CompanyId = 2
                },
                  new GK.PhoneBook.Domain.Entities.Person
                {
                    Id = 3,
                    FullName = "Anıl Yılmaz",
                    PhoneNumber = "+905055550057",
                    Address = "Narlıdere/Izmir/Turkey",
                    CompanyId = 3
                },
                 new GK.PhoneBook.Domain.Entities.Person
                {
                    Id = 4,
                    FullName = "Dilan Yılmaz",
                    PhoneNumber = "+905055550056",
                    Address = "Maraş/Turkey",
                    CompanyId = 3
                }
            };

            var mockRepository = new Mock<IPersonRepository>();

            mockRepository.Setup(x => x.Get()).Returns(persons.AsQueryable());

            mockRepository.Setup(x => x.GetById(It.IsInRange(0, 4, Moq.Range.Exclusive)));

            mockRepository.Setup(x => x.GetAll()).Returns(persons);

            mockRepository.Setup(x => x.Add(It.IsAny<GK.PhoneBook.Domain.Entities.Person>()))
                .ReturnsAsync((GK.PhoneBook.Domain.Entities.Person person) =>
            {
                person.Id = persons.Last().Id + 1;
                persons.Add(person);
                return person;
            });

            mockRepository.Setup(x => x.Update(It.IsAny<GK.PhoneBook.Domain.Entities.Person>()))
                .Callback((GK.PhoneBook.Domain.Entities.Person newPerson) =>
                {
                    var personInMock = persons.Where(q => q.Id == newPerson.Id).Single();

                    if (personInMock is null) throw new InvalidOperationException();

                    personInMock.FullName = newPerson.FullName;
                    personInMock.PhoneNumber = newPerson.PhoneNumber;
                    personInMock.Address = newPerson.Address;
                    personInMock.CompanyId = newPerson.CompanyId;
                });

            mockRepository.Setup(p => p.Delete(It.IsAny<Domain.Entities.Person>()))
                .Callback(new Action<Domain.Entities.Person>(x =>
                {
                    var personToRemove =persons.Find(y => y.Id == x.Id);

                    if (personToRemove != null)
                        persons.Remove(personToRemove);
                }));

            return mockRepository;
        }
    }
}
