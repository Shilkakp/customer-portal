using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class Policyvehicle
    {
        [Key]
        public Guid PolicyId { get; set; }
        public Guid VehicleId { get; set; }
    }
}
