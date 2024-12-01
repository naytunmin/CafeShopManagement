using MediatR;
using Microsoft.AspNetCore.Mvc;
using CafeShopMgmt.Application.UseCases.Employee.Queries.GetEmployeeQuery;
using CafeShopMgmt.Application.UseCases.Employee.CreateEmployeeCommand;
using CafeShopMgmt.Application.UseCases.Employee.UpdateEmployeeCommand;
using CafeShopMgmt.Application.UseCases.Employee.DeleteEmployeeCommand;

namespace CafeShopMgmt.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployees([FromQuery] string? cafe)
        {
            var response = await _mediator.Send(new GetEmployeeQuery() { cafeShopName = cafe });
            if (response.success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }


        [HttpPost("Insert")]
        public async Task<ActionResult> InsertEmployee([FromBody] CreateEmployeeCommand command)
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
        public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
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
        public async Task<ActionResult> DeleteAsync([FromQuery] DeleteEmployeeCommand command)
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
