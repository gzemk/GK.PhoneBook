using FluentValidation;
using FluentValidation.Results;
using GK.PhoneBook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCompanyCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
            RuleFor(p => p.Name)
                .NotEmpty()
                    .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100)
                    .WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.EmployeesCount)
                    .NotEmpty()
                        .WithMessage("{PropertyName} is required.")
                    .GreaterThan(0)
                        .WithMessage("{PropertyName} must be at least 1.");
        }

        protected override bool PreValidate(ValidationContext<CreateCompanyCommandRequest> context, ValidationResult result)
        {
            if (context.InstanceToValidate != null)
            {
                context.RootContextData["companyList"] = _unitOfWork.CompanyRepository.GetAll(x => x.Name == context.InstanceToValidate.Name);
            }
            return base.PreValidate(context, result);
        }
    }
}
