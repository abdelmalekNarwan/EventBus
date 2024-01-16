using EmployeeService.Services;
using Grpc.Core;
using GrpcEmployeeService.Protos;

namespace GrpcEmployeeService.Services
{
    public class EmployeeService : Employee.EmployeeBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async override Task<EmployeeDto> GetEmplyeeByDepartmentId(EmployeeInputDto request, ServerCallContext context)
        {
            var result = _employeeService.GetEmplyeeByDepartmentId(request.DepartmentId).Result.Select(a => new EmployeeDto { Name = a }).FirstOrDefault();
            return result?? new EmployeeDto { Name = "Ahmed" };
        }

    }
}
