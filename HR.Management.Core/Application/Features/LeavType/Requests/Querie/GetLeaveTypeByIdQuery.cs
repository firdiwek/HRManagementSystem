using MediatR;
using HR.Management.Domain.Entities;

namespace HR.Management.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeByIdQuery : IRequest<LeaveType>
    {
        public int Id { get; set; }
    }
}
