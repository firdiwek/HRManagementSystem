using MediatR;

namespace HR.Management.Application.Commands
{
    public class UpdateDepartmentCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}