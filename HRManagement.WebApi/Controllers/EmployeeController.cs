using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Management.Application.DTOs;
using HR.Management.Application.Features.Employees.Requests.Commands;
using HR.Management.Application.Features.Employees.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace HR.Management.WebApi.Controllers
{
    
    [ApiController]
    [Authorize(Roles ="Admin , HR")]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/employee/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var query = new GetEmployeeByIdQuery { Id = id };
            var employee = await _mediator.Send(query);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // GET api/employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
        {
            var query = new GetAllEmployeesQuery();
            var employees = await _mediator.Send(query);

            return Ok(employees);
        }

        // GET api/employee/department/{departmentId}
        [HttpGet("department/{departmentId}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesByDepartment(int departmentId)
        {
            var query = new GetEmployeesByDepartmentQuery { DepartmentId = departmentId };
            var employees = await _mediator.Send(query);

            return Ok(employees);
        }

        // GET api/employee/search?name={name}
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> SearchEmployeesByName([FromQuery] string name)
        {
            var query = new SearchEmployeesByNameQuery { Name = name };
            var employees = await _mediator.Send(query);

            return Ok(employees);
        }

        // GET api/employee/paged?page={page}&pageSize={pageSize}
        [HttpGet("paged")]
        public async Task<ActionResult<PagedResult<EmployeeDto>>> GetPagedEmployees([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetEmployeesPagedQuery { Page = page, PageSize = pageSize };
            var pagedEmployees = await _mediator.Send(query);

            return Ok(pagedEmployees);
        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<int>> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            var employeeId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeId }, employeeId);
        }

        // PUT api/employee/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await _mediator.Send(command);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE api/employee/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
