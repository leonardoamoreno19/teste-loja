using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnline.Application.Customer.Commands.CreateCustomer;
using LojaOnline.Application.Customer.Commands.UpdateCustomer;
using LojaOnline.Application.Customer.Dtos;
using LojaOnline.Application.Customer.Queries.GetAllCustomers;
using LojaOnline.Application.Customer.Queries.GetCustomerById;
using LojaOnline.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LojaOnline.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllCustomersQuery());
            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(int id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery { Id = id });
            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Create(CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result.Data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDto>> Update(int id, UpdateCustomerCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id mismatch");

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Data);
        }
    }
}
