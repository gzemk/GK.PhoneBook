using FluentValidation;
using FluentValidation.Results;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.Extensions;

namespace GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCompanyCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage($"{{PropertyName}} is required.")
                .MaximumLength(100)
                    .WithMessage($"{{PropertyName}} must not exceed 100 characters.")
                .Must((item, value, context) => !context.CompanyList().Any(x => x.Name == item.Name.Trim()))
                    .WithMessage($"{{PropertyName}} must be unique");

            RuleFor(p => p.EmployeeCount)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                   .WithMessage($"{{PropertyName}} is required.")
                .GreaterThan(0)
                   .WithMessage($"{{PropertyName}} must be at least 1.");
        }

        protected override bool PreValidate(ValidationContext<CreateCompanyCommandRequest> context, ValidationResult result)
        {
            if (context.InstanceToValidate != null)
            {
                context.RootContextData["companyList"] = _unitOfWork.CompanyRepository.GetAll();
            }
            return base.PreValidate(context, result);
        }
    }
}
