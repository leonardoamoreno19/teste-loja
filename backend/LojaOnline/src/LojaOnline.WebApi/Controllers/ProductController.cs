using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnline.Application.Product.Commands.CreateProduct;
using LojaOnline.Application.Product.Commands.UpdateProduct;
using LojaOnline.Application.Product.Dtos;
using LojaOnline.Application.Product.Queries.GetAllProducts;
using LojaOnline.Application.Product.Queries.GetProductById;
using LojaOnline.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LojaOnline.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery { Id = id });
            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result.Data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update(int id, UpdateProductCommand command)
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
