using MediatR;

namespace HR.Management.Application.Commands
{
    public class DeletePayrollCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
