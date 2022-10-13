using GK.PhoneBook.Application.Dtos.Person;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Persons.Queries.GetAllPersonQuery
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQueryRequest, GetAllPersonQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllPersonQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetAllPersonQueryResponse> Handle(GetAllPersonQueryRequest request, CancellationToken cancellationToken)
        {
            GetAllPersonQueryResponse response = new();
            List<GetAllPersonDto> persons = new();

            var query = _unitOfWork.PersonRepository.Get();

            if (request.QueryItem != null)
            {
                request.QueryItem = request.QueryItem.Trim().ToLower();

                if (query != null)
                {
                    query = query.Include(q => q.Company).Where(q => q.FullName.ToLower().Contains(request.QueryItem)
                    || q.Address.ToLower().Contains(request.QueryItem)
                    || q.PhoneNumber.Contains(request.QueryItem)
                    || q.Company.Name.ToLower().Contains(request.QueryItem)
                    || q.Company.EmployeeCount.Equals(request.QueryItem));

                    foreach (var item in query.ToList())
                    {
                        var result = ObjectMapper.Mapper.Map<GetAllPersonDto>(item);
                        persons.Add(result);
                    }
                    response.Persons = persons;
                }

                else
                {
                    response.Message = "Results not found for your search criteria";
                    response.Persons = persons;
                }
            }
            else
            {
                foreach (var item in query.ToList())
                {
                    var result = ObjectMapper.Mapper.Map<GetAllPersonDto>(item);
                    persons.Add(result);
                }
                response.Persons = persons;
            }
            return response;
        }
    }
}
