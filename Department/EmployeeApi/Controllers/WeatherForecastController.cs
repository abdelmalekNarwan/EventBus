using EmployeeService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public Task< List<string>> Get(int id)
        {
           var data= _employeeService.GetEmplyeeByDepartmentId(id);
            return data;
        }
    }
}