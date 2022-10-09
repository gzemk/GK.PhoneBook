using GK.PhoneBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Persons.Commands.DeletePersonCommand
{
    public class DeletePersonCommandRequest : IRequest<DeletePersonCommandResponse>
    {
        public int Id { get; set; } 
    }
}
