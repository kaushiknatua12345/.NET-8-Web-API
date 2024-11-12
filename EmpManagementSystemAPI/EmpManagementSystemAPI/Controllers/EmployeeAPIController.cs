using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpManagementSystemAPI.Models;
using EmpManagementSystemAPI.Repository;

namespace EmpManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeAPIController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeRepository.GetEmployees();
            if (employees==null)
            {
                return NotFound("No Records Found Under Collection");
                
            }
            return Ok(employees);

        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound("Searched Employee Not Found");
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeDB employee)
        {
            var addEmployee = _employeeRepository.AddEmployee(employee);
            if(addEmployee == null)
            {
                return BadRequest("Data Can Not Added");
            }
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + addEmployee.Id, addEmployee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDB employee,int id)
        {
            var updateEmployee = _employeeRepository.UpdateEmployee(employee, id);
            if (updateEmployee == null)
            {
                return NotFound("Employee can not updated or not found");
            }
            return Ok(updateEmployee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var result = _employeeRepository.DeleteEmployee(id);
            if (!result)
            {
                return NotFound("Data can be deleted");
            }
            return Ok();
        }
    }
}
