using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject_.NET8WebAPIWithDocker.Models;
using FinalProject_.NET8WebAPIWithDocker.Repositories;

namespace FinalProject_.NET8WebAPIWithDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        //implement InsuranceController
        private readonly IRepository _repository;
        public InsuranceController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<InsuranceModel>> GetInsurances()
        {
            return await _repository.GetInsurances();
        }

        [HttpGet("{policyNumber}")]
        public async Task<ActionResult<InsuranceModel>> GetInsurance(int policyNumber)
        {
            var insurance = await _repository.GetInsurance(policyNumber);
            if (insurance == null)
            {
                return NotFound();
            }
            return insurance;
        }

        [HttpPost]
        public async Task<ActionResult<InsuranceModel>> AddInsurance(InsuranceModel insurance)
        {
            var newInsurance = await _repository.AddInsurance(insurance);
            return CreatedAtAction(nameof(GetInsurance), new { policyNumber = newInsurance.PolicyNumber }, newInsurance);
        }

        [HttpPut("{policyNumber}")]
        public async Task<ActionResult<InsuranceModel>> UpdateInsurance(int policyNumber, InsuranceModel insurance)
        {
            if (policyNumber != insurance.PolicyNumber)
            {
                return BadRequest();
            }
            var updatedInsurance = await _repository.UpdateInsurance(policyNumber, insurance);
            if (updatedInsurance == null)
            {
                return NotFound();
            }
            return updatedInsurance;
        }

        [HttpDelete("{policyNumber}")]
        public async Task<ActionResult<InsuranceModel>> DeleteInsurance(int policyNumber)
        {
            var insurance = await _repository.DeleteInsurance(policyNumber);
            if (insurance == null)
            {
                return NotFound();
            }
            return insurance;
        }
    }
}
