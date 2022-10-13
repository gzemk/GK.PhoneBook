using GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.Mappings;
using GK.PhoneBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommandRequest, CreatePersonCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreatePersonCommandResponse> Handle(CreatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            CreatePersonCommandResponse response = new();
            var validator = new CreatePersonCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Person couldn't be created";
                response.Errors = validationResult.Errors.Select(m => m.ErrorMessage).ToList();
            }
            else
            {
                var person = ObjectMapper.Mapper.Map<Person>(request);
                person = await _unitOfWork.PersonRepository.Add(person);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Person was created";
                response.Id = person.Id;
            }
            return response;
        }
    }
}
