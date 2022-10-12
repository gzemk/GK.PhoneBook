using FluentValidation;
using FluentValidation.Results;
using GK.PhoneBook.Application.Extensions;
using GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePersonCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.FullName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage($"{{PropertyName}} is required.")
                .MaximumLength(50)
                    .WithMessage($"{{PropertyName}} must not exceed 50 characters.");

            RuleFor(p => p.PhoneNumber)
                  .Cascade(CascadeMode.Stop)
                  .NotEmpty()
                     .WithMessage($"{{PropertyName}} is required.")
                  .MinimumLength(11)
                    .WithMessage($"{{PropertyName}} must not be less than 11 characters")
                  .MaximumLength(14)
                     .WithMessage($"{{PropertyName}} must not be greater than 13 characters.");
                 
            RuleFor(p => p.Address)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage($"{{PropertyName}} is required.")
                .MaximumLength(200)
                    .WithMessage($"{{PropertyName}} must not exceed 200 characters.");

            RuleFor(p => p.CompanyId)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
                   .WithMessage($"{{PropertyName}} is required.")
              .Must((item, value, context) => item.CompanyId != default && context.CompanyList().Any(x => x.Id == item.CompanyId))
                    .WithMessage($"{{PropertyName}} must be exist");


        }

        protected override bool PreValidate(ValidationContext<CreatePersonCommandRequest> context, ValidationResult result)
        {
            if (context.InstanceToValidate != null)
            {
                context.RootContextData["companyList"] = _unitOfWork.CompanyRepository.GetAll();
            }
            return base.PreValidate(context, result);
        }
    }
}
