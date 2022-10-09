using GK.PhoneBook.Application.Dtos;
using GK.PhoneBook.Application.Dtos.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Persons.Queries.GetAllPersonQuery
{
    public class GetAllPersonQueryResponse : BaseResponseDto
    {
        public List<GetAllPersonDto> Persons { get; set; }
    }
}
