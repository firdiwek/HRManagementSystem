using MediatR;
using HR.Management.Domain.Entities;

namespace HR.Management.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeByNameQuery : IRequest<LeaveType>
    {
        public string? Name { get; set; }
    }
}
