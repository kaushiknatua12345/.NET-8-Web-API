using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HandsOn_.NET8APIWithUnitTesting.Models;
using HandsOn_.NET8APIWithUnitTesting.Repository;

namespace HandsOn_.NET8APIWithUnitTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        
        private readonly IPatientRepository _repository;
        public PatientController(IPatientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllPatients()
        {
            return Ok(_repository.GetAllPatients());
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            var patient = _repository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public IActionResult AddPatient([FromBody] PatientModel patient)
        {
            var addPatient = _repository.AddPatient(patient);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + addPatient.PatientId, addPatient);
        }

        //HttpPut
        [HttpPut("{id}")]
        public IActionResult UpdatePatient([FromBody] PatientModel patient, int id)
        {
            var updatePatient = _repository.UpdatePatient(patient, id);
            if (updatePatient == null)
            {
                return NotFound("Searched Patient Record Not Found");
            }
            return Ok(updatePatient);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var result = _repository.DeletePatient(id);
            if (!result)
            {
                return NotFound("Searched Patient Record Not Found");
            }
            return Ok();
        }
    }
}
