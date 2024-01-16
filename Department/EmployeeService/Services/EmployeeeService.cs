using EmployeeDomain.Entity;
using EmployeeReposatory.Repsatory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Services
{
    public class EmployeeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;

      

        public EmployeeeService(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }
        public async Task<List<string>> GetEmplyeeByDepartmentId(int id)
        {
           
            var Names = _repository.GetAll().Select(a => a.Name).ToList();
            return Names;
        }
    }
}
