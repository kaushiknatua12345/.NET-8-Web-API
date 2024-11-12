using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNet8APIWithPostGreSQL.Repositories;
using DotNet8APIWithPostGreSQL.Models;

namespace DotNet8APIWithPostGreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                var result = _employeeRepository.GetEmployees();
                if (result == null)
                {
                    return NotFound("No Records Found");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var result = _employeeRepository.GetEmployee(id);
                if (result == null)
                {
                    return NotFound("Searched Record Not Found");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            try
            {
                var result = _employeeRepository.AddEmployee(employee);
                if (result == null)
                {
                    return BadRequest("Employee already exists");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding data to the database");
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee, int id)
        {
            try
            {
                var result = _employeeRepository.UpdateEmployee(employee,id);
                if (result == null)
                {
                    return NotFound("Employee Not Found");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data to the database");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var result = _employeeRepository.DeleteEmployee(id);
                if (result == null)
                {
                    return NotFound("Employee Not Found");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
            }
        }
    }
}
