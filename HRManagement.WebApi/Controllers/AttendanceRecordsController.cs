using HR.Management.Application.Features.AttendanceRecords.Requests.Commands;
using HR.Management.Application.Features.AttendanceRecords.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR.Management.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceRecordsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttendanceRecordsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var attendanceRecords = await _mediator.Send(new GetAllAttendanceRecordsQuery());
            return Ok(attendanceRecords);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var attendanceRecord = await _mediator.Send(new GetAttendanceRecordByIdQuery { Id = id });
            return Ok(attendanceRecord);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAttendanceRecordCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAttendanceRecordCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAttendanceRecordCommand { Id = id });
            return NoContent();
        }
    }
}
