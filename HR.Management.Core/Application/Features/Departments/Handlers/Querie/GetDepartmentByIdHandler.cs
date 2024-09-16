using HR.Management.Application.Queries;
using HR.Management.Application.Interfaces;
using HR.Management.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Management.Application.Handlers
{
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, Department>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetDepartmentByIdHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.GetDepartmentByIdAsync(request.Id);
        }
    }
}