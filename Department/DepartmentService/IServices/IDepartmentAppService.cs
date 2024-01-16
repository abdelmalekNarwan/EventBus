using DepartmentService.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentService.IServices
{
    public interface IDepartmentAppService
    {
        Task<List<string>> GetEmplyeeByDepartmentId(CreateEmployeeDto input);
    }
}
