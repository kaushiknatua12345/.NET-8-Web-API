using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject_.NET8WebAPIWithDocker.Models
{
    [Table("Insurance")]
    public class InsuranceModel
    {
        [Key]
        public int PolicyNumber { get; set; }

        public string PolicyName { get; set; }
        public string PolicyHolderName { get; set; }
        public string Email { get; set; }
        public int PolicyTenure { get; set; }
        public double PolicyAmount { get; set; }
    }
}
