using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIEFCoreCodeFir.Models
{
    [Table("ReceptionItems")]
    public class Items
    {
        [Key]
        [Required]
        public int ItemId { get; set; }
        [Required]
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        [Required]
        public int ItemQuantity { get; set; }        
    }   
}
