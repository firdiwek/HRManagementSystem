using HR.Management.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace HR.Management.Application.Queries
{
    public class GetAllDepartmentsQuery : IRequest<IEnumerable<Department>>
    {
    }
}