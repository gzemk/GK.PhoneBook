using GK.PhoneBook.Application.Dtos.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Persons.Commands.UpdatePersonCommand
{
    public class UpdatePersonCommandRequest : PersonDto,IRequest<UpdatePersonCommandResponse>
    {
        public int Id { get; set; } 
    }
}
