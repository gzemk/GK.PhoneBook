using GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.Mappings;
using GK.PhoneBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Persons.Commands.UpdatePersonCommand
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommandRequest, UpdatePersonCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdatePersonCommandResponse> Handle(UpdatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdatePersonCommandResponse();
            var validator = new UpdatePersonCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Person couldn't update.";
                response.Errors = validationResult.Errors.Select(m => m.ErrorMessage).ToList();
            }
            else
            {
                var person = ObjectMapper.Mapper.Map<Person>(request);
                await _unitOfWork.PersonRepository.Update(person);  // TODO
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Person updated.";
                response.Id = request.Id;
            }
            return response;
        }
    }
}
