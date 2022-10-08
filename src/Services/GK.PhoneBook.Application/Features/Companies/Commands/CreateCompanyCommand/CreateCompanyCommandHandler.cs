using AutoMapper;
using GK.PhoneBook.Application.Interfaces;
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
        private readonly IMapper _mapper;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateCompanyCommandResponse();
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
                var company = _mapper.Map<Company>(request);
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
