using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Persons.Queries.GetPersonQuery
{
    public class GetPersonQueryRequest : IRequest<GetPersonQueryResponse>
    {
    }
}
