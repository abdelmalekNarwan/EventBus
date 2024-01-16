using DepartmentService.IServices;
using DepartmentService.Services.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase, IDepartmentAppService
    {
        private readonly IDepartmentAppService _appService;
        public DepartmentController(IDepartmentAppService appService)
        {
            _appService = appService;
        }
        [HttpGet]
        public async Task<List<string>> GetEmplyeeByDepartmentId ([FromQuery] CreateEmployeeDto input)
        {
            var names = await _appService.GetEmplyeeByDepartmentId(input);
            return names;
        }


    }
}
