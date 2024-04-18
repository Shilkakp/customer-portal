using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class VehicleTypes
    {
        [Key]
        public int VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
        public string Description { get; set; }
        public  bool IsActive { get; set; }
    }
}
