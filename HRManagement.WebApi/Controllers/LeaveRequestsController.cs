using HR.Management.Application.Features.LeaveRequests.Requests.Commands;
using HR.Management.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using HR.Management.Core.Application.Features.LeaveRequests.Requests.Command;

namespace HR.Management.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeaveRequest([FromBody] CreateLeaveRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLeaveRequestById), new { id = result }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaveRequest(int id, [FromBody] UpdateLeaveRequestCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveRequestById(int id)
        {
            var query = new GetLeaveRequestByIdQuery { Id = id };
            var leaveRequest = await _mediator.Send(query);
            if (leaveRequest == null) return NotFound();
            return Ok(leaveRequest);
        }

        [HttpGet] // For getting all leave requests
        public async Task<IActionResult> GetAllLeaveRequests()
        {
            var query = new GetAllLeaveRequestsQuery();
            var leaveRequests = await _mediator.Send(query);
            return Ok(leaveRequests);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveRequest(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetLeaveRequestsByEmployee(int employeeId)
        {
            var query = new GetLeaveRequestsByEmployeeQuery { EmployeeId = employeeId };
            var leaveRequests = await _mediator.Send(query);
            return Ok(leaveRequests);
        }
    }
}
