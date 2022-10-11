using FluentValidation;
using GK.PhoneBook.Application.Exceptions;
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
            var validator = new UpdatePersonCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors);

            var personInDb = await _unitOfWork.PersonRepository.Get(request.Id);

            if (personInDb == null) 
                throw new NotFoundException(nameof(Person),request.Id);

                var person = ObjectMapper.Mapper.Map<Person>(request);
                await _unitOfWork.PersonRepository.Update(person);  // TODO
                await _unitOfWork.Save();

            UpdatePersonCommandResponse response = new(){ Id = request.Id, Success = true, Message = "Person updated."};

            return response;
        }
    }
}
