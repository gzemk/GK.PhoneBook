using GK.PhoneBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Persons.Commands.DeletePersonCommand
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommandRequest, DeletePersonCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DeletePersonCommandResponse> Handle(DeletePersonCommandRequest request, CancellationToken cancellationToken)
        {
            DeletePersonCommandResponse response = new();

            var person =  _unitOfWork.PersonRepository.Get().Where(x => x.Id == request.Id).FirstOrDefault();

            if (person == null) return null;

            await _unitOfWork.PersonRepository.Delete(person);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Person deleted.";

            return response;
        }
    }
}
