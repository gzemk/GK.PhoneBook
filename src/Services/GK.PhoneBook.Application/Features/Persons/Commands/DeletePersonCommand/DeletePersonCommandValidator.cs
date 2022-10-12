using FluentValidation;
using FluentValidation.Results;
using GK.PhoneBook.Application.Extensions;
using GK.PhoneBook.Application.Features.Persons.Commands.UpdatePersonCommand;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Persons.Commands.DeletePersonCommand
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePersonCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.Id)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
                  .WithMessage($"{{PropertyName}} is required.")
             .Must((item, value, context) => item.Id != default && context.PersonList().Any(x => x.Id == item.Id))
                 .WithMessage($"{{PropertyName}} must be exist.");
        }

        protected override bool PreValidate(ValidationContext<DeletePersonCommandRequest> context, ValidationResult result)
        {
            if (context.InstanceToValidate != null)
            {
                context.RootContextData["personList"] = _unitOfWork.PersonRepository.GetAll();
            }
            return base.PreValidate(context, result);
        }
    }
}
