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

            int[] ids = personList.Select(x => x.Id).ToArray();

            var random = new Random();

            for (int i = 1; i < ids.First(); i++)
            {
                if (ids.Contains(i))
                {
                    var person = personList.Any(x => x.Id == ids[i]) == true ? personList.FirstOrDefault(x => x.Id == ids[i]) : null;
                    response = ObjectMapper.Mapper.Map<GetPersonQueryResponse>(person);
                    return response;
                }
            }
            return response;
        }
    }
}
