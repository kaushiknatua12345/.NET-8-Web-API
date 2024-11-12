using Microsoft.EntityFrameworkCore;
using FinalProject_.NET8WebAPIWithDocker.Models;

namespace FinalProject_.NET8WebAPIWithDocker.Data
{
    public class InsuranceContext:DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options):base(options)
        {
        }
        public DbSet<InsuranceModel> Insurances { get; set; }
    }
    
}
