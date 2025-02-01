using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnline.Application.Order.Commands.CreateOrder;
using LojaOnline.Application.Order.Commands.UpdateOrder;
using LojaOnline.Application.Order.Dtos;
using LojaOnline.Application.Order.Queries.GetAllOrders;
using LojaOnline.Application.Order.Queries.GetOrderById;
using LojaOnline.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LojaOnline.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllOrdersQuery());
            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery { OrderId = id });
            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create(CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result.Data);
        }

        [HttpPut("{id}/status")]
        public async Task<ActionResult<OrderDto>> UpdateStatus(int id, UpdateOrderCommand command)
        {
            if (id != command.OrderId)
                return BadRequest("Id mismatch");

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Data);
        }
    }
}
