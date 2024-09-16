// HR.Management.WebApi/Controllers/DepartmentController.cs
using HR.Management.Application.Commands;
using HR.Management.Application.Queries;
using HR.Management.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Management.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
        {
            var query = new GetAllDepartmentsQuery();
            var departments = await _mediator.Send(query);
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            var query = new GetDepartmentByIdQuery { Id = id };
            var department = await _mediator.Send(query);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> AddDepartment(CreateDepartmentCommand command)
        {
            var departmentId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = departmentId }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(int id, UpdateDepartmentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var command = new DeleteDepartmentCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
