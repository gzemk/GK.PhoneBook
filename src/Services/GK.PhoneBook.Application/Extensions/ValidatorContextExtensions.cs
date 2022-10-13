using FluentValidation;
using GK.PhoneBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Extensions
{
    public static class ValidatorContextExtensions
    {
        public static List<Company> CompanyList<T>(this ValidationContext<T> context) => (List<Company>)context.RootContextData["companyList"];
        public static List<Person> PersonList<T>(this ValidationContext<T> context) => (List<Person>)context.RootContextData["personList"];
    }
}
