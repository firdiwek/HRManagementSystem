using MediatR;

namespace HR.Management.Application.Commands
{
    public class CreateDepartmentCommand : IRequest<int>
    {
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}