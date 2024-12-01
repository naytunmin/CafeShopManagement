using MediatR;
using Microsoft.AspNetCore.Mvc;
using CafeShopMgmt.Application.UseCases.CafeShop.Queries.GetCafeShopQuery;
using CafeShopMgmt.Application.UseCases.CafeShop.CreateCafeShopCommand;
using CafeShopMgmt.Application.UseCases.CafeShop.UpdateCafeShopCommand;
using CafeShopMgmt.Application.UseCases.CafeShop.DeleteCafeShopCommand;

namespace CafeShopMgmt.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeShopController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CafeShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCafe([FromQuery] string? location)
        {
            var response = await _mediator.Send(new GetCafeShopQuery() { location = location });
            if (response.success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }



        [HttpPost("Insert")]
        public async Task<ActionResult> InsertCafeShop([FromBody] CreateCafeShopCommand command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateEmployee([FromBody] UpdateCafeShopCommand command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("Delete")]
        public async Task<ActionResult> DeleteAsync([FromQuery] DeleteCafeShopCommand command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

    }
}
