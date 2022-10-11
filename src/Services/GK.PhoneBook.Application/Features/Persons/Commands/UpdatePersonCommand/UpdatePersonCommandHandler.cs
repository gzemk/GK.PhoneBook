using FluentValidation;
using GK.PhoneBook.Application.Exceptions;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Domain.Entities;
using MediatR;

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

            personInDb.FullName = request.FullName;
            personInDb.PhoneNumber = request.PhoneNumber;
            personInDb.Address = request.Address;
            personInDb.CompanyId = request.CompanyId;

            _unitOfWork.PersonRepository.Update(personInDb);
             await _unitOfWork.Save();

            UpdatePersonCommandResponse response = new(){ Id = request.Id, Success = true, Message = "Person updated."};

            return response;
        }
    }
}
