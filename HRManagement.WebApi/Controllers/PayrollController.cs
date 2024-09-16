using HR.Management.Application.Queries;
using HR.Management.Application.Commands;
using HR.Management.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Management.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayrollController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PayrollController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/payrolls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payroll>>> GetAll()
        {
            var query = new GetAllPayrollsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/payrolls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payroll>> Get(int id)
        {
            var query = new GetPayrollByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/payrolls
        [HttpPost]
        public async Task<ActionResult<Payroll>> Post([FromBody] CreatePayrollCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        // PUT: api/payrolls/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePayrollCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/payrolls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePayrollCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
