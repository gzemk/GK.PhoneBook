using FluentValidation;
using FluentValidation.Results;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.Extensions;

namespace GK.PhoneBook.Application.Features.Persons.Commands.UpdatePersonCommand
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePersonCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.Id)
               .NotEmpty()
                   .WithMessage($"{{PropertyName}} is required.")
              .Must((item, value, context) => item.Id != default && context.PersonList().Any(x => x.Id == item.Id))
                 .WithMessage($"{{PropertyName}} must be exist.");

            RuleFor(p => p.FullName)
               .NotEmpty()
                   .WithMessage($"{{PropertyName}} is required.")
               .NotNull()
               .MaximumLength(50)
                   .WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.PhoneNumber)
               .NotEmpty()
                    .WithMessage($"{{PropertyName}} is required.")
               .NotNull()
               .MaximumLength(20)
                    .WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.Address)
                .NotEmpty()
                    .WithMessage($"{{PropertyName}} is required.")
                .NotNull()
                .MaximumLength(200)
                    .WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.CompanyId)
               .NotEmpty()
                   .WithMessage($"{{PropertyName}} is required.")
              .Must((item, value, context) => item.Id != default && context.CompanyList().Any(x => x.Id == item.Id))
                 .WithMessage($"{{PropertyName}} must be exist.");

        }

        protected override bool PreValidate(ValidationContext<UpdatePersonCommandRequest> context, ValidationResult result)
        {
            if (context.InstanceToValidate != null)
            {
                context.RootContextData["personList"] = _unitOfWork.PersonRepository.GetAll();
                context.RootContextData["companyList"] = _unitOfWork.CompanyRepository.GetAll();
            }
            return base.PreValidate(context, result);
        }
    }
}
