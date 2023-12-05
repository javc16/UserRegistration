using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Helpers;
using UserRegistration.Models.DTO;
using UserRegistration.Services;

namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDTO>> GetAll()
        {
            var result = _employeeService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(int id)
        {
            return Ok(await _employeeService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(EmployeeDTO item)
        {
            return Ok(await _employeeService.SaveEmployee(item));
        }
    }
}
