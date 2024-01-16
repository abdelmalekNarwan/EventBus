using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Services
{
    public interface IEmployeeService
    {
        Task<List<string>> GetEmplyeeByDepartmentId(int id);
    }
}
