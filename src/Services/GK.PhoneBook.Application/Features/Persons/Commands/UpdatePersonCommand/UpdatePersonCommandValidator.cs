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
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
                   .WithMessage($"{{PropertyName}} is required.")
              .Must((item, value, context) => item.Id != default && context.PersonList().Any(x => x.Id == item.Id))
                 .WithMessage($"{{PropertyName}} must be exist.");

            RuleFor(p => p.FullName)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
                   .WithMessage($"{{PropertyName}} is required.")
               .MaximumLength(50)
                   .WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

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
                    .WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.CompanyId)
               .Cascade(CascadeMode.Stop)
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
