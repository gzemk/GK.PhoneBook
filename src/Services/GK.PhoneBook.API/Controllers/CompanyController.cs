using GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GK.PhoneBook.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator,ILogger<CompanyController> logger)
        {
            _mediator = mediator;   
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<CreateCompanyCommandResponse>> CreateCompany([FromBody] CreateCompanyCommandRequest request)
        {   
            var result = await _mediator.Send(request);
            return result;
        }
    }
}