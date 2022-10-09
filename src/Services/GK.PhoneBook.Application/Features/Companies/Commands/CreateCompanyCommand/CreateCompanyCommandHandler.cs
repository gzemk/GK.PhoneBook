using AutoMapper;
using GK.PhoneBook.Application.Interfaces;
using GK.PhoneBook.Application.Mappings;
using GK.PhoneBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, CreateCompanyCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            CreateCompanyCommandResponse response = new();
            var validator = new CreateCompanyCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Company couldn't create.";
                response.Errors = validationResult.Errors.Select(m => m.ErrorMessage).ToList();
            }
            else
            {
                request.Name = request.Name.Trim();
                var company = ObjectMapper.Mapper.Map<Company>(request);
                company = await _unitOfWork.CompanyRepository.Add(company);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Company created";
                response.Id = company.Id;
            }

            return response;
        }
    }
}
