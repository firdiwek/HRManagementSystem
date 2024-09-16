using HR.Management.Application.Interfaces;
using HR.Management.Application.Queries;
using HR.Management.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Management.Application.Handlers
{
    public class GetAllDepartmentsHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<Department>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetAllDepartmentsHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.GetAllDepartmentsAsync();
        }
    }
}