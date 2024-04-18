using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class FuelTypes
    {
        [Key]
        public int FuelTypeId { get; set; }
        public string FuelType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }  
    }
}
