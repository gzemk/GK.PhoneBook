using GK.PhoneBook.Application.Dtos.Person;
using GK.PhoneBook.Application.Features.Companies.Commands.CreateCompanyCommand;
using GK.PhoneBook.Application.Features.Persons.Commands.CreatePersonCommand;
using GK.PhoneBook.Application.Features.Persons.Commands.DeletePersonCommand;
using GK.PhoneBook.Application.Features.Persons.Commands.UpdatePersonCommand;
using GK.PhoneBook.Application.Features.Persons.Queries.GetAllPersonQuery;
using GK.PhoneBook.Application.Features.Persons.Queries.GetPersonQuery;
using GK.PhoneBook.Application.Mappings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GK.PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator, ILogger<PersonController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("search")]
        public async Task<ActionResult<GetAllPersonQueryResponse>> GetAll([FromQuery] string searchKey)
        {
            var response = await _mediator.Send(new GetAllPersonQueryRequest { QueryItem = searchKey });
            return response is null ? NotFound(response) : Ok(response);
        }

        [HttpGet("wildCard")]
        public async Task<ActionResult<GetPersonQueryResponse>> Get()
        {
            var response = await _mediator.Send(new GetPersonQueryRequest());
            return response is null ? NotFound(response) : Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreatePersonCommandResponse>> Create([FromBody] CreatePersonCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return response is null ? NotFound(response) : Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdatePersonCommandResponse>> Update([FromRoute] int id, [FromBody] PersonDto request )
        {
            var requestModel  = ObjectMapper.Mapper.Map<UpdatePersonCommandRequest>(request);
            requestModel.Id = id;
            var response = await _mediator.Send(requestModel);
            return response is null ? NotFound(response) : Ok(response);    

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdatePersonCommandResponse>> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeletePersonCommandRequest { Id = id});
            return response is null ? NotFound(response) : Ok(response);

        }

    }
}
