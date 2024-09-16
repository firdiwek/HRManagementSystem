using MediatR;

namespace HR.Management.Application.Commands
{
    public class DeleteDepartmentCommand : IRequest
    {
        public int Id { get; set; }
    }
}