using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Persons.Queries.GetAllPersonQuery
{
    public class GetAllPersonQueryValidator : AbstractValidator<GetAllPersonQueryRequest>
    {
        public GetAllPersonQueryValidator()
        {
            RuleFor(p => p.QueryItem)
             .NotEmpty();
        }
    }
}
