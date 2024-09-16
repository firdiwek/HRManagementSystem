using HR.Management.Domain.Entities;
using MediatR;

namespace HR.Management.Application.Queries
{
    public class GetDepartmentByIdQuery : IRequest<Department>
    {
        public int Id { get; set; }
    }
}