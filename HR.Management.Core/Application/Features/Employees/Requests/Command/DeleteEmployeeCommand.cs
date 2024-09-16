using MediatR;

namespace HR.Management.Application.Features.Employees.Requests.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
