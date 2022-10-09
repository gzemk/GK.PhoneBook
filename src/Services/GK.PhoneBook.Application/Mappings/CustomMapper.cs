using AutoMapper;
using GK.PhoneBook.Application.Dtos.Company;
using GK.PhoneBook.Application.Dtos.Person;
using GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand;
using GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand;
using GK.PhoneBook.Application.Features.Persons.Commands.UpdatePersonCommand;
using GK.PhoneBook.Application.Features.Persons.Queries.GetPersonQuery;
using GK.PhoneBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Mappings
{
    public class CustomMapper : Profile
    {
        public CustomMapper()
        {
            //CreateMap<source, destination>()
            //.ForMember(dest => dest.Id, src => src.MapForm(x => x.Id));

            CreateMap<CreateCompanyCommandRequest, Company>();
            CreateMap<Company, CompanyDto>();
            CreateMap<CreatePersonCommandRequest, Person>();
            CreateMap<Person, CreatePersonCommandRequest>();
            CreateMap<PersonDto, CreatePersonCommandRequest>();
            CreateMap<PersonDto, UpdatePersonCommandRequest>();
            CreateMap<GetAllPersonDto, GetPersonQueryResponse>();
            CreateMap<Person, GetAllPersonDto>()
                .ForMember(dest => dest.Company, src => src.MapFrom(x => x.Company));
            CreateMap<GetPersonDto, GetPersonQueryResponse>();
            CreateMap<UpdatePersonCommandRequest, Person>();

        }
    }
}
