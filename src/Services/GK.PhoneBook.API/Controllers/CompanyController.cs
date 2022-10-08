using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GK.PhoneBook.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator,ILogger<CompanyController> logger)
        {
            _mediator = mediator;   
            _logger = logger;
        }

        //[HttpPost]
        //public async Task<ActionResult<>>

       
    }
}