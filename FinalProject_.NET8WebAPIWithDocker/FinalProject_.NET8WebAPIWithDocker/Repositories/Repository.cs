using FinalProject_.NET8WebAPIWithDocker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using FinalProject_.NET8WebAPIWithDocker.Data;
namespace FinalProject_.NET8WebAPIWithDocker.Repositories
{
    public class Repository:IRepository
    {
        //implement IRepository
        
        private readonly InsuranceContext _context;
        public Repository(InsuranceContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<InsuranceModel>> GetInsurances()
        {
            return await _context.Insurances.ToListAsync();
        }
        
        public async Task<InsuranceModel> GetInsurance(int policyNumber)
        {
            return await _context.Insurances.FindAsync(policyNumber);
        }

        public async Task<InsuranceModel> AddInsurance(InsuranceModel insurance)
        {
            _context.Insurances.Add(insurance);
            await _context.SaveChangesAsync();
            return insurance;
        }

        public async Task<InsuranceModel> UpdateInsurance(int policyNumber, InsuranceModel insurance)
        {
            _context.Entry(insurance).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return insurance;
        }

        public async Task<InsuranceModel> DeleteInsurance(int policyNumber)
        {
            var insurance = await _context.Insurances.FindAsync(policyNumber);
            if (insurance == null)
            {
                return null;
            }
            _context.Insurances.Remove(insurance);
            await _context.SaveChangesAsync();
            return insurance;
        }
    }
}
