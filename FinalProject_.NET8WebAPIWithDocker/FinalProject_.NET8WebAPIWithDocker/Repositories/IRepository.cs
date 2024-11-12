using FinalProject_.NET8WebAPIWithDocker.Models;

namespace FinalProject_.NET8WebAPIWithDocker.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<InsuranceModel>> GetInsurances();
        Task<InsuranceModel> GetInsurance(int policyNumber);
        Task<InsuranceModel> AddInsurance(InsuranceModel insurance);
        Task<InsuranceModel> UpdateInsurance(int policyNumber, InsuranceModel insurance);
        Task<InsuranceModel> DeleteInsurance(int id);
    }
}
