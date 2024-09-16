// using HR.Management.Application.Commands;
// using HR.Management.Application.Interfaces;
// using HR.Management.Domain.Entities;
// using MediatR;
// using System.Threading;
// using System.Threading.Tasks;

// namespace HR.Management.Application.Handlers
// {
//     public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand>
//     {
//         private readonly IDepartmentRepository _departmentRepository;

//         public UpdateDepartmentHandler(IDepartmentRepository departmentRepository)
//         {
//             _departmentRepository = departmentRepository;
//         }

//         public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
//         {
//             var department = new Department
//             {
//                 Id = request.Id,
//                 Name = request.Name,
//                 Description = request.Description,
//                 CreatedDate = request.CreatedDate
//             };

//             await _departmentRepository.UpdateDepartmentAsync(department);
//             return Unit.Value;
//         }
//     }
// }
