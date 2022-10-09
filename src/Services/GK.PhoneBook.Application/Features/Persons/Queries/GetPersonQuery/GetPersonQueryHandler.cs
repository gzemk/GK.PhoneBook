using GK.PhoneBook.Application.Dtos;
using GK.PhoneBook.Application.Dtos.Person;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.Mappings;
using MediatR;

namespace GK.PhoneBook.Application.Features.Persons.Queries.GetPersonQuery
{
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQueryRequest, GetPersonQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPersonQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetPersonQueryResponse> Handle(GetPersonQueryRequest request, CancellationToken cancellationToken)
        {
            GetPersonQueryResponse response = new();

            var personList = _unitOfWork.PersonRepository.Get().Select(x => new GetPersonDto
            {
                Id = x.Id,
                FullName = x.FullName,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                CompanyName = x.Company.Name
            }).OrderByDescending(x => x.Id).ToList();

            if (personList.Count == 0) return null;

            do
            {
                int max = personList.First().Id + 1;
                var randomPersonId = Random.Shared.Next(0, max);
                var person = personList.Any(x => x.Id == randomPersonId) == true ? personList.FirstOrDefault(x => x.Id == randomPersonId) : null;
                response = ObjectMapper.Mapper.Map<GetPersonQueryResponse>(person);
                return response;
            } while (response is null);
            
        }
    }
}
