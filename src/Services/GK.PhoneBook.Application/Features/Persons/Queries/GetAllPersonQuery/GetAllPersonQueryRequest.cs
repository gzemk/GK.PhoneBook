using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Persons.Queries.GetAllPersonQuery
{
    public class GetAllPersonQueryRequest : IRequest<GetAllPersonQueryResponse>
    {
        public string QueryItem { get; set; }
    }
}
